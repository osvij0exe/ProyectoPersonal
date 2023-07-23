using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospAPI.Models.Configuraciones
{
    public class ExpedienteConfig : IEntityTypeConfiguration<Expediente>
    {
        public void Configure(EntityTypeBuilder<Expediente> builder)
        {
            //builder.Property(prop => prop.Descripcion)
            //    .HasMaxLength(300);
            //builder.Property(prop => prop.FechaUltimaActualizacion)
            //     .HasColumnType("date");
        }
    }
}
