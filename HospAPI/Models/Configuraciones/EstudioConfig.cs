using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospAPI.Models.Configuraciones
{
    public class EstudioConfig : IEntityTypeConfiguration<Estudio>
    {
        public void Configure(EntityTypeBuilder<Estudio> builder)
        {
            //builder.Property(prop => prop.NombreEstudio)kk
            //    .HasMaxLength(50)
            //    .IsRequired();
            //builder.Property(prop => prop.Descripcion)
            //    .HasMaxLength(150);
        }
    }
}
