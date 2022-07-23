using Consultorio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
   public class EspecialidadeMap : BaseMap<Especialidade>
    {
        public EspecialidadeMap() : base("tb_especialidade")
        {
        }

        public override void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Ativa);
        }
   }
}