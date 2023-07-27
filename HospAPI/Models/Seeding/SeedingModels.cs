using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HospAPI.Models.Seeding
{
    public static class SeedingModels
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var rolAdminId   = "6e764357-10d2-4c58-9657-1a834586ef6c";
            var rolMedicoId  = "f4dff315-308f-4591-a06b-a148e37e23f8";
            var rolUsuarioId = "5890c3b5-382f-4ff3-abec-5aaabbc0e056";

            var rolAdmin = new IdentityRole()
            {
                Id = rolAdminId,
                Name = "Admin",
                NormalizedName = "Admin"
            };
            var rolMedico = new IdentityRole()
            {
                Id = rolMedicoId,
                Name = "Medico",
                NormalizedName = "Medico"
            };
            var rolUsuario = new IdentityRole()
            {
                Id = rolUsuarioId,
                Name = "Usruaio",
                NormalizedName = "Usuario"
            };

            modelBuilder.Entity<IdentityRole>()
                .HasData(rolAdmin,rolMedico,rolUsuario);

        }

    }
}
