using _05_api_bd_agendamento.Models;
using Microsoft.EntityFrameworkCore;

namespace _05_api_bd_agendamento.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
