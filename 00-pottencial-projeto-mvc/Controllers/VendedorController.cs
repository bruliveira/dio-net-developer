using Microsoft.AspNetCore.Mvc;
using TestePaymentApi.Models;
using TestePaymentApi.Context;

namespace _00_pottencial_projeto_mvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly TestPaymentApiContext _context;
        public VendedorController(TestPaymentApiContext context)
        {
            _context = context;
        }

        [HttpPost("CriarVendedor")]
        public IActionResult CriarVendedor(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(VisualizarVendedorPorId), new { id = vendedor.Id }, vendedor);
        }
        [HttpGet("VisualizarVendedorPorId")]
        public IActionResult VisualizarVendedorPorId(int id)
        {
            var vendedor = _context.Vendedors.Find(id);

            if (vendedor == null)
            {
                return NotFound();
            }

            return Ok(vendedor);
        }
        [HttpGet("VisualizarTodosVendedores")]
        public IActionResult VisualizarVendedores()
        {
            var vendedor = _context.Vendedors;
            return Ok(vendedor);
        }
        [HttpDelete("DeletarVendedor")]
        public IActionResult Deletar(int id)
        {
            var vendedor = _context.Vendedors.Find(id);

            if (vendedor == null)
            {
                return NotFound();
            }
            _context.Vendedors.Remove(vendedor);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("AtualizarVendedor")]
        public IActionResult Atualizar(int id, Vendedor vendedor)
        {
            var vendedorBd = _context.Vendedors.Find(id);

            if (vendedorBd == null)
            {
                return NotFound();
            }

            vendedorBd.Nome = vendedor.Nome;
            vendedorBd.Cpf = vendedor.Cpf;
            vendedorBd.Email = vendedor.Email;
            vendedorBd.Telefone = vendedor.Telefone;

            _context.Vendedors.Update(vendedorBd);
            _context.SaveChanges();
            return Ok(vendedorBd);
        }

    }
}