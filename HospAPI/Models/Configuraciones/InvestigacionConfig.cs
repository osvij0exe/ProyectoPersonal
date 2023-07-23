using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospAPI.Models.Configuraciones
{
    public class InvestigacionConfig : IEntityTypeConfiguration<Investigacion>
    {
        public void Configure(EntityTypeBuilder<Investigacion> builder)
        {
            //builder.Property(prop => prop.Resumen)
            //    .HasMaxLength(500)
            //    .IsRequired();
            builder.Property(prop => prop.FechaPublicacion)
                .HasColumnType("date");
        }
    }
}
