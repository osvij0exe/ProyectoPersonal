using AutoMapper;
using HospAPI.DTOs;
using HospAPI.DTOs.PacientesDTOs;
using HospAPI.Models;
using HospAPI.Servicios.interfaces;
using HospAPI.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospAPI.Controllers
{
    [ApiController]
    [Route("api/Pacientes")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PacientesController(IPacienteService Service, ApplicationDbContext context, IMapper mapper)
        {
            _service = Service;
            _context = context;
            _mapper = mapper;
        }

        /*********************************************************************/
        /*                       METODO POST                                 */
        /*                    INSERTAR REGISTROS                             */
        /*********************************************************************/



        [HttpPost("AgregarPaciente")]
        public async Task<ActionResult> PostPaciente(InsertarPacienteDTO insertarPacienteDTO,CancellationToken cancellationToken = default)
        {

            return await _service.PostPacienteAsync(insertarPacienteDTO, cancellationToken);
        }


        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/

        [HttpGet("ListaPacientesPorNombre")]
        public async Task<ActionResult<List<GetPacienteDTO>>> GetListaPaciente([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Pacientes.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var paciente = queryable.OrderBy(pacienteDB => pacienteDB.NombrePaciente).Paginar(paginacionDTO).ToList();
            return _mapper.Map<List<GetPacienteDTO>>(paciente);
        }


        [HttpGet("PacientePorId/{id:int}")]
        public async Task<ActionResult<GetPacienteDTO>> GetPacienteId(int id,CancellationToken cancellationToken = default)
        {

            return await _service.GetPacienteIdAsync(id,cancellationToken);
        }


        [HttpGet("PacientePorNSS")]
        public async Task<ActionResult<GetPacienteDTO>> GetPacienteNss(int nss,CancellationToken cancellationToken = default)
        {

            return await _service.GetPacienteNssAsync(nss,cancellationToken);

        }
        [HttpGet("PacientePorNombre")]
        public async Task<ActionResult<List<GetPacienteDTO>>> GetPacientePorNombre(string nombre,CancellationToken cancellationToken = default)
        {

            return await _service.GetPacientePorNombreAsync(nombre,cancellationToken );
        }

        [HttpGet("FiltrarPorParametro")]
        public async Task<ActionResult<List<GetPacienteDTO>>> Getfiltro([FromQuery] PacienteFiltro pacienteFiltro, CancellationToken cancellationToken = default)
        {
            return await _service.GetfiltroAsync(pacienteFiltro,cancellationToken);
        }

        /*********************************************************************/
        /*                           METODO PUT                              */
        /*                     ACTUALIZAR REGISTROS                          */
        /*********************************************************************/
        [HttpPut("ActualizarPaciente/{id:int}")]
        public async Task<ActionResult> PutPaciente(ActualizarPacienteDTO actualizarPacienteDTO,int id, CancellationToken cancellationToken = default)
        {
            return await _service.PutPacienteAsync(actualizarPacienteDTO,id,cancellationToken);
        }

        /*********************************************************************/
        /*                       METODO DELETE/POST                           */
        /*                    BORRAR REGISTROS LOGICO                        */
        /*********************************************************************/

        [HttpDelete("BorradoLogico/{id:int}")]
        public async Task<ActionResult> DeletePaciente(int id,CancellationToken cancellationToken = default)
        {
            return await _service.DeletePacienteAsync(id, cancellationToken);
        }
        [HttpPost("RestaruarPaciente/{id:int}")]
        public async Task<ActionResult> RestaurarPaciente(int id, CancellationToken cancellationToken = default)
        {

            return await _service.RestaurarPacienteAsync(id,cancellationToken);
            
        }

    }
}
