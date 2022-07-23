using Microsoft.EntityFrameworkCore;
using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
    public class ProfissionalMap : BaseMap<Profissional>
    {
        public ProfissionalMap() : base("tb_profissional")
        {
        }

        public override void Configure(EntityTypeBuilder<Profissional> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnType("varchar(150)").IsRequired();
            builder.Property(x => x.Ativo);

            builder.HasMany(x => x.Especialidades)
                   .WithMany(x => x.Profissionais)
                   .UsingEntity<ProfissionalEspecialidade>(
                        x => x.HasOne(e => e.Especialidade).WithMany().HasForeignKey(x => x.EspecialidadeId),

                        x => x.HasOne(p => p.Profissionais).WithMany().HasForeignKey(p => p.ProfissionalId),
                        
                        x => 
                        {
                            x.ToTable("tb_profissional_especialidade");

                            x.HasKey(x => new {x.ProfissionalId, x.EspecialidadeId});

                            x.Property(e => e.EspecialidadeId).IsRequired();
                            x.Property(p => p.ProfissionalId).IsRequired();
                        }
                    ); 
        }
    }
}