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
        }
    }
}