using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospAPI.Models.Configuraciones
{
    public class ReporteConfig : IEntityTypeConfiguration<Reporte>
    {
        public void Configure(EntityTypeBuilder<Reporte> builder)
        {
            //builder.Property(prop => prop.Descripcion)
            //    .HasMaxLength(150);
            //builder.Property(prop => prop.FechaReporte)
            //    .HasColumnType("date");
            //builder.Property(prop => prop.Caso)
            //    .HasMaxLength(20)
            //    .IsRequired();
        }
    }
}
