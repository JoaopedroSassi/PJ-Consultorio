using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Context
{
    public class ConsultorioDbContext : DbContext
    {
        public DbSet<Consulta> Consultas {get; set;}
        //public DbSet<Especialidade> Especialidades { get; set; }
        //public DbSet<Paciente> Pacientes { get; set; }
        //public DbSet<Profissional> Profissionais { get; set; }
        //public DbSet<ProfissionalEspecialidade> ProfissionaisEspecialidades { get; set; }

        public ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
