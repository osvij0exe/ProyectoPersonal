using AutoMapper;
using HospAPI.DTOs;
using HospAPI.DTOs.InvetigacionDTOs;
using HospAPI.DTOs.MedcosDTOs;
using HospAPI.Models;
using HospAPI.Servicios.interfaces;
using HospAPI.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospAPI.Controllers
{
    [ApiController]
    [Route("api/Investigacion")]
    public class InvestigacionController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly IInvestigacionesServices _services;
        private readonly string contenedor = "Articulos";

        public InvestigacionController(ApplicationDbContext context,
            IMapper mapper,
            IAlmacenadorArchivos almacenadorArchivos,
            IInvestigacionesServices services)
        {
            _context = context;
            _mapper = mapper;
            _almacenadorArchivos = almacenadorArchivos;
            _services = services;
        }

        /*********************************************************************/
        /*                       METODO POST                                 */
        /*                    INSERTAR REGISTROS                             */
        /*********************************************************************/


        [HttpPost("InsertArticulo")]
        public async Task<ActionResult> PostArticulo([FromForm] InsertarInvestigacionDTO insertarInvestigacionDTO, CancellationToken cancellationToken = default)
        {

            return await _services.PostArticuloAsync(insertarInvestigacionDTO, cancellationToken);

        }
        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/



        [HttpGet("ListaArticulosPaginado")]
        public async Task<ActionResult<List<GetInvestigacionDTO>>> GetListaArticulos([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default)
        {
            var artQueryable = _context.Investigaciones.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(artQueryable);

            var ArticuloBD = await artQueryable.OrderBy(artDB => artDB.NombreArticulo).Include(medicoDb => medicoDb.Medicos.OrderBy(m =>m.ApellidoMaterno)).Paginar(paginacionDTO).ToListAsync(cancellationToken);
            return _mapper.Map<List<GetInvestigacionDTO>>(ArticuloBD);


        }

        [HttpGet("ArticuloInvestigacionPorId")]
        public async Task<ActionResult<GetInvestigacionDTO>> Get(int id, CancellationToken cancellationToken)
        {

            return  await _services.GetAsync(id, cancellationToken);
        }
        [HttpGet("ArticuloPorNombre")]
        
        public async Task<ActionResult<List<GetInvestigacionDTO>>> GetInvestigacionPorNombre(string nombre, CancellationToken cancellationToken)
        {

            return await _services.GetInvestigacionPorNombreAsync(nombre,cancellationToken);

        }
        [HttpGet("ArticuloPorDatosMedico")]

        public async Task<ActionResult<List<GetMedicosFiltroDTO>>> GetInvestigacionPorDatosMedico([FromQuery] MedicoInvestigacionDTO medicoInvestigacionDTO,int pagina = 1,CancellationToken cancellationToken = default)
        {



            return await _services.GetInvestigacionPorDatosMedicoAsync(medicoInvestigacionDTO,pagina,cancellationToken);
        }

        [HttpGet("ArticuloPorDatos")]
        public async Task<ActionResult<List<GetInvestigacionDTO>>> GetInvestigacionPorDatos([FromQuery] InvestigacionFiltroDTO investigacionFiltroDTO,
            [FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default)
        {
            var articuloMedQueriable = _context.Investigaciones.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(articuloMedQueriable);

            var medicoQueriable = _context.Medicos.AsQueryable();

            if (investigacionFiltroDTO.InvestigacionId != 0) 
            {
                articuloMedQueriable = articuloMedQueriable.Where(articuloDB => articuloDB.InvestigacionId.Equals(investigacionFiltroDTO.InvestigacionId));
            }
            if(!string.IsNullOrEmpty(investigacionFiltroDTO.NombreArticulo))
            {
                articuloMedQueriable = articuloMedQueriable.Where(articuloDB => articuloDB.NombreArticulo.Contains(investigacionFiltroDTO.NombreArticulo));
            }
            if(investigacionFiltroDTO.FechaPublicacion.ToString() is null) 
            {
                articuloMedQueriable = articuloMedQueriable.Where(articuloDB => articuloDB.FechaPublicacion.Equals(investigacionFiltroDTO.FechaPublicacion));
            }




            var articuloMedico = await articuloMedQueriable
                .Include(medicoDB => medicoDB.Medicos.OrderBy(m => m.ApellidoMaterno))
                .Paginar(paginacionDTO).OrderByDescending(a =>a.FechaPublicacion)
                .ToListAsync(cancellationToken);

            if(articuloMedico.IsNullOrEmpty())
            {
                return BadRequest("No se encontro ningun articulo");
            }

            return _mapper.Map<List<GetInvestigacionDTO>>(articuloMedico);

        }

    }



}
