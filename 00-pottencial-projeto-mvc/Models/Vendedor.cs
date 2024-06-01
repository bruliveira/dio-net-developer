using System.ComponentModel.DataAnnotations;

namespace _00_pottencial_projeto_mvc.Models
{
    public class Vendedor
    {
        [Key()]
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

    }
}