using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _00_pottencial_projeto_mvc.Models
{
    public class Venda
    {
        [Key()]
        public int Id { get; set; }
        [ForeignKey("Vendedor")]
        public int VendedorId { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public DateTime Data { get; set; }
        public EnumStatusVenda Status { get; set; }
    }
}