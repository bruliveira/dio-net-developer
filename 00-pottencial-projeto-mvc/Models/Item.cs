using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _00_pottencial_projeto_mvc.Models
{
    public class Item
    {
        [Key()]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
    }
}