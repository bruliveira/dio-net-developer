using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestePaymentApi.Models;
using TestePaymentApi.Context;

namespace _00_pottencial_projeto_mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {

        private readonly TestPaymentApiContext _context;
        public VendaController(TestPaymentApiContext context)
        {
            _context = context;
        }
        [HttpPost("CriarPedidoVenda")]
        public IActionResult CriarPedido(Venda venda)
        {
            venda.Status = EnumStatusVenda.Aguadando_Pagamento;
            venda.Data = DateTime.Now;

            var vendedor = _context.Vendedors.Find(venda.VendedorId);
            if (vendedor == null)
            {
                return BadRequest(new { Erro = "Vendedor Não Cadastrado" });
            }

            var item = _context.Items.Find(venda.ItemId);
            if (item == null)
            {
                return BadRequest(new { Erro = "Item não cadastrado!" });
            }

            _context.Add(venda);
            _context.SaveChanges();

            return CreatedAtAction(nameof(VisualizarPedidoPorId), new { id = venda.Id }, venda);
        }
        [HttpGet("VisualizarPedidoPorId")]
        public IActionResult VisualizarPedidoPorId(int id)
        {
            var venda = _context.Vendas.Find(id);
            var vendedor = _context.Vendedors.Find(venda.VendedorId);
            var item = _context.Items.Find(venda.ItemId);

            if (venda == null)
            {
                return NotFound();
            }

            return Ok(venda);
        }

        [HttpPost("AtualizarStatusPedido")]
        public IActionResult Atualizar(int id, Venda pedido)
        {
            var pedidoBd = _context.Vendas.Find(pedido.Id);

            if (pedidoBd.Status == EnumStatusVenda.Aguadando_Pagamento)
            {
                if (pedido.Status == EnumStatusVenda.Pagamento_Aprovado)
                {
                    pedidoBd.Status = EnumStatusVenda.Pagamento_Aprovado;
                }
                else if (pedido.Status == EnumStatusVenda.Cancelado)
                {
                    pedidoBd.Status = EnumStatusVenda.Cancelado;
                }
                else
                {
                    return BadRequest(new { Erro = "Atualização não disponivel!" });
                }
            }
            else if (pedidoBd.Status == EnumStatusVenda.Pagamento_Aprovado)
            {
                if (pedido.Status == EnumStatusVenda.Enviado_para_transportadora)
                {
                    pedidoBd.Status = EnumStatusVenda.Enviado_para_transportadora;
                }
                else if (pedido.Status == EnumStatusVenda.Cancelado)
                {
                    pedidoBd.Status = EnumStatusVenda.Cancelado;
                }
                else
                {
                    return BadRequest(new { Erro = "Atualização não disponivel!" });
                }
            }
            else if (pedidoBd.Status == EnumStatusVenda.Enviado_para_transportadora)
            {
                if (pedido.Status == EnumStatusVenda.Entregue)
                {
                    pedidoBd.Status = EnumStatusVenda.Entregue;
                }
                else
                {
                    return BadRequest(new { Erro = "Atualização não disponivel!" });
                }
            }
            else
            {
                return BadRequest(new { Erro = "Atualização não disponivel!" });
            }

            _context.Vendas.Update(pedidoBd);
            _context.SaveChanges();
            return Ok(pedidoBd);
        }


    }
}