using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace HospAPI.Models.Configuraciones
{
    public class MedicoConfig : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            //builder.Property(prop => prop.NombreMedico)
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
            //builder.Property(prop => prop.Especialidad)
            //    .HasMaxLength(30)
            //    .IsRequired();
            //builder.Property(prop => prop.SubEspecialidad)
            //    .HasMaxLength(30)
            //    .IsRequired();
            //builder.Property(prop => prop.FechaIngreso)
            //    .HasColumnType("date");
            //builder.Property(prop => prop.Email)
            //    .HasMaxLength(50);
            //builder.Property(prop => prop.Descripcion)
            //    .HasMaxLength(300);


            builder.HasQueryFilter(m => !m.Estaus); //borrado logico
        }
    }
}
