using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospAPI.Models.Configuraciones
{
    public class TipoEstudioConfig : IEntityTypeConfiguration<TipoEstudio>
    {
        public void Configure(EntityTypeBuilder<TipoEstudio> builder)
        {
            //builder.Property(prop => prop.TipoEstudioId)
            //    .HasMaxLength(3)
            //    .IsRequired();
            //builder.Property(prop => prop.NombreTipoEstudio)
            //    .HasMaxLength(25)
            //    .IsRequired();
        }
    }
}
