﻿using HospAPI.Models;
using HospAPI.Models.Configuraciones;
using HospAPI.Models.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HospAPI
{
    public class ApplicationDbContext : IdentityDbContext/*<HospIdentityUsers> */// <clase Propira de Usuarios>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        /************                       Seeding                      ***************/ 

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingModels.Seed(modelBuilder);

        /************              Configuracion de los Models           ********************/
            modelBuilder.ApplyConfiguration(new ReporteConfig());
            modelBuilder.ApplyConfiguration(new EstudioConfig());
            modelBuilder.ApplyConfiguration(new ExpedienteConfig());
            modelBuilder.ApplyConfiguration(new InvestigacionConfig());
            modelBuilder.ApplyConfiguration(new LabConfig());
            modelBuilder.ApplyConfiguration(new MedicoConfig());
            modelBuilder.ApplyConfiguration(new PacienteConfig());
            modelBuilder.ApplyConfiguration(new TipoEstudioConfig());

            //renombrar las tablas de los Usuarios
            ///modelBuilder.Entity<HospIdentityUsers>(h => h.ToTable("Usuarios"));
            ///modelBuilder.Entity<IdentityRole>(e => e.ToTable("Role"));
            ///modelBuilder.Entity<IdentityUserRole<string>>(e => e.ToTable("UsuariosRoles"));
        }


        /************   convertir los models en tabblas para SQL Server  ********************/
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Estudio> Etudios{ get; set; }
        public DbSet<Expediente> Expedientes{ get; set; }
        public DbSet<Investigacion> Investigaciones{ get; set; }
        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<TipoEstudio> TiposEstudios{ get; set; }
        public DbSet<ArchivoEstudio> ArchivosEstudios{ get; set; }


    }
}
