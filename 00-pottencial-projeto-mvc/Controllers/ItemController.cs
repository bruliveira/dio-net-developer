using Microsoft.AspNetCore.Mvc;
using TestePaymentApi.Models;
using TestePaymentApi.Context;

namespace _00_pottencial_projeto_mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly TestPaymentApiContext _context;

        public ItemController(TestPaymentApiContext context)
        {
            _context = context;
        }

        [HttpPost("CriarItem")]

        public IActionResult CriarItem(Item item)
        {
            _context.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(nameof(VisualizarItemPorId), new { id = item.Id }, item);
        }
        [HttpGet("VisualizarItemPorId")]
        public IActionResult VisualizarItemPorId(int id)
        {
            var item = _context.Items.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }
        [HttpGet("VisualizarTodosItenss")]
        public IActionResult VisualizarItens()
        {
            var item = _context.Items;
            return Ok(item);
        }
        [HttpDelete("DeletarItem")]
        public IActionResult Deletar(int id)
        {
            var item = _context.Items.Find(id);

            if (item == null)
            {
                return NotFound();
            }
            _context.Items.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("AtualizarValorItem")]
        public IActionResult Atualizar(int id, Item item)
        {
            var itemBd = _context.Items.Find(id);

            if (itemBd == null)
            {
                return NotFound();
            }

            itemBd.Descricao = item.Descricao;
            itemBd.Valor = item.Valor;

            _context.Items.Update(itemBd);
            _context.SaveChanges();
            return Ok(itemBd);
        }
    }
}