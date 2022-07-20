using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Context
{
    public class ConsultorioDbContext : DbContext
    {
        public DbSet<Agendamento> Agendamentos { get; set; }

        public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> opt) : base(opt)
        {
        }
    }
}
