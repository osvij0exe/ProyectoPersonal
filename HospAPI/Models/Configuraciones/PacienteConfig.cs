using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospAPI.Models.Configuraciones
{
    public class PacienteConfig : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            //builder.Property(prop => prop.NombrePaciente)
            //    .HasMaxLength(20)
            //    .IsRequired();
            //builder.Property(prop => prop.ApellidoPaterno)
            //    .HasMaxLength(20)
            //    .IsRequired();
            //builder.Property(prop => prop.ApellidoMaterno)
            //    .HasMaxLength(20)
            //    .IsRequired();
            //builder.Property(prop => prop.Genero)
            //    .HasMaxLength(1);
            //builder.Property(prop => prop.Estado)
            //    .HasMaxLength(20)
            //    .IsRequired();
            //builder.Property(prop => prop.UMF)
            //    .HasMaxLength(50)
            //    .IsRequired();
            //builder.Property(prop => prop.NSS)
            //    .HasMaxLength(12);
            //builder.Property(prop => prop.Agregado)
            //    .HasMaxLength(8);
            //builder.Property(prop => prop.FechaNacimiento)
            //    .HasColumnType("date");
            //builder.Property(prop => prop.FechaIngreso)
            //    .HasColumnType("date");
            //builder.Property(prop => prop.FechaAlta)
            //    .HasColumnType("date");
            //builder.Property(prop => prop.Descripcion)
            //    .HasMaxLength(50);

            builder.HasQueryFilter(pacienteDB => !pacienteDB.Estatus);
        }
    }
}
