using HospAPI.Controllers;
using HospAPI.Models;
using HospAPI.Servicios.interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopiApiTest.PruebasUnitarias
{
    [TestClass]
    public class MedicosControllerTests: BasePruebas
    {
        [TestMethod]
        public async Task GetMedicosIdTest()
        {
            //Preparacion
            /// base de datos aleatoria unica
            var nombreDB = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreDB);
            var _mapper = configurarAutoMapper();
            var mock = new Mock<IMedicosServices>();

            contexto.Medicos.Add(new Medico() { NombreMedico = "Medico 1" });
            contexto.Medicos.Add(new Medico() { NombreMedico = "Medico 2" });
            await contexto.SaveChangesAsync();

            //var _contexto2 = ConstruirContext(nombreDB);
            ////Prueba

            //var controller = new MedicosController(/*_services,*/ _contexto2, _mapper);
            //var id = 1;
            //var respuesta = await controller.GetMedico(id);

            ////Verificación

            //var resultado = respuesta.Value;
            //Assert.AreEqual(id, resultado.MedicoId);

        }
    }
}
