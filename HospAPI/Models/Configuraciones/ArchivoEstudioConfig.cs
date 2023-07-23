using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospAPI.Models.Configuraciones
{
    public class ArchivoEstudioConfig : IEntityTypeConfiguration<ArchivoEstudio>
    {
        public void Configure(EntityTypeBuilder<ArchivoEstudio> builder)
        {
            builder.HasKey(prop => prop.ArchivoEstudioId);

            //builder.Property(prop => prop.Descripcion)
            //    .HasMaxLength(300);
            //builder.Property(prop => prop.ImagenDicom)
            //    .HasMaxLength(150);
            //builder.Property(prop => prop.FechaRealizacion)
            //    .HasColumnType("date");
        }
    }
}
