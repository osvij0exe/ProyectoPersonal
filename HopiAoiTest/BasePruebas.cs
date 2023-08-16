using AutoMapper;
using HospAPI;
using HospAPI.Models;
using HospAPI.Servicios.interfaces;
using HospAPI.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopiApiTest
{
    public class BasePruebas
    {
        protected ApplicationDbContext ConstruirContext(string nombreDB)
        {
            var opciones = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(nombreDB).Options;

            var dbContext = new ApplicationDbContext(opciones);
            return dbContext;
        }
        // configuracion de automapper
        protected IMapper configurarAutoMapper()
        {
            var config = new MapperConfiguration(opt => opt.AddProfile(new AutoMapperProfiles()));
            return config.CreateMapper();
        }

 
    }
}
