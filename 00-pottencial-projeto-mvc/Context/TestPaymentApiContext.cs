using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestePaymentApi.Models;

namespace _00_pottencial_projeto_mvc.Controllers
{
    public class TestPaymentApiContext : DbContext
    {
        public TestPaymentApiContext(DbContextOptions<TestPaymentApiContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedors { get; set; }

    }
}