using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospAPI.DTOs;
using HospAPI.DTOs.MedcosDTOs;
using HospAPI.Models;
using HospAPI.Servicios;
using HospAPI.Servicios.interfaces;
using HospAPI.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospAPI.Controllers
{
    [ApiController]
    [Route("api/Medicos")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicosServices _services;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MedicosController(IMedicosServices services,ApplicationDbContext context,IMapper mapper)
        {
            _services = services;
            _context = context;
            _mapper = mapper;
        }
        /*********************************************************************/
        /*                       METODO POST                                 */
        /*                    INSERTAR REGISTROS                             */
        /*********************************************************************/

        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> PostMedico( InsertarMedicoDTO insertarMedicoDTO,CancellationToken cancellationToken = default)
        {
;
            return await _services.PostMedicoAsync(insertarMedicoDTO, cancellationToken);
        }

        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/

        // forma 1 de paginación
        [HttpGet("listaPaginada")]
        //[AllowAnonymous]
        public async Task<IEnumerable<GetMedicoDTO>> GetMedicoList(int pagina = 1, CancellationToken cancellationToken = default)
        {

            return await _services.getMedicoListAsync(pagina, cancellationToken);
        }


        [HttpGet("listaPaginadaConDTO")]//TODO pendiente
        public async Task<ActionResult<List<GetMedicoDTO>>> GetMedicoListConDTO([FromQuery] PaginacionDTO paginacionDTO,CancellationToken cancellationToken = default)
        {
            var queryable = _context.Medicos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var medicos = await queryable.OrderBy(medicoDb => medicoDb.NombreMedico).Paginar(paginacionDTO).ToListAsync(cancellationToken);
            return _mapper.Map<List<GetMedicoDTO>>(medicos);
        }

        //filtro por id
        [HttpGet("FiltroPorId{id:int}")]
        public async Task<ActionResult<GetMedicoDTO>> GetMedico(int id,CancellationToken cancellationToken = default)
        {

            return await _services.GetMedicoAsync(id,cancellationToken);
        }

        [HttpGet("PorNombre")]
        public async Task<ActionResult<List<GetMedicoDTO>>> GetByName(string nombre,CancellationToken cancellationToken = default)
        {

            return await _services.GetByNameAsync(nombre, cancellationToken);
        }


        [HttpGet("PorMatricula")]
        public async Task<ActionResult<GetMedicoDTO>> GetByMatricula(int matriucla, CancellationToken cancellationToken = default)
        {

            return await _services.GetByMatriculaAsync(matriucla,cancellationToken);
        }
        [HttpGet("PorCedula")]
        public async Task<ActionResult<GetMedicoDTO>> GetByCedula(int cedula, CancellationToken cancellationToken = default)
        {

            return await _services.GetByCedulaAsync(cedula,cancellationToken);
        }


        //filtrado dinamico o ejecucion diferida
        [HttpGet("FiltrarPorParametro")]
        public async Task<ActionResult<List<GetMedicoDTO>>> FiltrarParametro
            ([FromQuery] MedicoFiltroDTO medicoFiltroDTO,CancellationToken cancellation = default)
        {

            return await _services.FiltrarParametroAsync(medicoFiltroDTO,cancellation);

        }


        /*********************************************************************/
        /*                           METODO PUT                              */
        /*                     ACTUALIZAR REGISTROS                          */
        /*********************************************************************/

        [HttpPut("Actualizacion/{id:int}")]
        public async Task<ActionResult> PutActualizacion(InsertarMedicoDTO insertarMedicoDTO,int id,CancellationToken cancellationToken)
        {

            return await _services.PutActualizacionAsync(insertarMedicoDTO,id);

        }

        /*********************************************************************/
        /*                       METODO DELETE/POST                           */
        /*                    BORRAR REGISTROS LOGICO                        */
        /*********************************************************************/

        [HttpDelete("EliminacionLogica")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {

            return await _services.DeleteAsync(id,cancellationToken);
        }
        [HttpPost("Restaurar")]
        public async Task<ActionResult> Restaurar(int id,CancellationToken cancellationToken)
        {

            return await _services.RestaurarAsync(id,cancellationToken);
        }


        /*                 Ejemplo paginación dos                       */

        //[HttpGet]
        //public async Task<IEnumerable<GetMedicoDTO>> GetMedicos(int pagina = 1)
        //{
        //    var numRegistrosPagina = 10;

        //    return await _context.Medicos
        //        .Select(med => new GetMedicoDTO
        //        {
        //            MedicoId        = med.MedicoId,
        //            NombreMedico    = med.NombreMedico,
        //            ApellidoMaterno = med.ApellidoMaterno,
        //            ApellidoPaterno = med.ApellidoPaterno,
        //            Especialidad    = med.Especialidad,
        //            Genero          = med.Genero,
        //            SubEspecialidad   = med.SubEspecialidad,
        //            Matricula         = med.Matricula,
        //            CedulaProfesional = med.CedulaProfesional,
        //            Email             = med.Email,

        //        })
        //        .Skip((pagina -1)*numRegistrosPagina)
        //        .Take(numRegistrosPagina)//paginacion
        //        .OrderBy(med => med.NombreMedico)//ordenado por nombre
        //        .ToListAsync();
        //}




    }

}
