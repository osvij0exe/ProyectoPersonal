using AutoMapper;
using HospAPI.DTOs;
using HospAPI.DTOs.PacientesDTOs;
using HospAPI.Models;
using HospAPI.Servicios.interfaces;
using HospAPI.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospAPI.Servicios
{
    public class PacientesServices : ControllerBase, IPacienteService

    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PacientesServices(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /*********************************************************************/
        /*                       METODO POST                                 */
        /*                    INSERTAR REGISTROS                             */
        /*********************************************************************/

        public async Task<ActionResult> PostPacienteAsync(InsertarPacienteDTO insertarPacienteDTO, CancellationToken cancellationToken = default)
        {
            var existeNss = await _context.Pacientes.AnyAsync(paceitneDB => paceitneDB.NSS == insertarPacienteDTO.NSS,cancellationToken);

            if (existeNss)
            {
                return BadRequest($"el Paciente con Numero de Seguridad social: {insertarPacienteDTO.NSS} ya existe");
            }

            var paciente = _mapper.Map<Paciente>(insertarPacienteDTO);
            _context.Add(paciente);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok("El Paciente fue agregado exitosamenete");
        }

        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/
        public async Task<ActionResult<List<GetPacienteDTO>>> GetListaPacienteAsync([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Pacientes.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var paciente = queryable.OrderBy(pacienteDB => pacienteDB.NombrePaciente).Paginar(paginacionDTO).ToList();
            return _mapper.Map<List<GetPacienteDTO>>(paciente);
        }

        public async Task<ActionResult<GetPacienteDTO>> GetPacienteIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(pacienteDB => pacienteDB.PacienteId == id, cancellationToken);
            if (paciente is null)
            {
                return BadRequest($"El paciente con id: {id} no existe");
            }

            return _mapper.Map<GetPacienteDTO>(paciente);
        }
        public async Task<ActionResult<GetPacienteDTO>> GetPacienteNssAsync(int nss, CancellationToken cancellationToken = default)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(pacienteDB => pacienteDB.NSS == nss, cancellationToken);
            if (paciente is null)
            {
                return BadRequest($"El paciente con NSS: {nss} no existe");
            }
            return _mapper.Map<GetPacienteDTO>(paciente);
        }
        public async Task<ActionResult<List<GetPacienteDTO>>> GetPacientePorNombreAsync(string nombre, CancellationToken cancellationToken = default)
        {
            var paciente = await _context.Pacientes.Where(pacienteDB => pacienteDB.NombrePaciente.Contains(nombre)).ToListAsync(cancellationToken);
            if (paciente.IsNullOrEmpty())
            {
                return BadRequest("No existe paciente con ese nombre");
            }
            return _mapper.Map<List<GetPacienteDTO>>(paciente);
        }

        public async Task<ActionResult<List<GetPacienteDTO>>> GetfiltroAsync([FromQuery] PacienteFiltro pacienteFiltro, CancellationToken cancellationToken = default)
        {
            var pacientequeryable = _context.Pacientes.AsQueryable();

            if (pacienteFiltro.PacienteId != 0)
            {
                pacientequeryable = pacientequeryable.Where(pacienteDB => pacienteDB.PacienteId.Equals(pacienteFiltro.PacienteId));
            }

            if (!string.IsNullOrEmpty(pacienteFiltro.NombrePaciente))
            {
                pacientequeryable = pacientequeryable.Where(pacienteDB => pacienteDB.NombrePaciente.Contains(pacienteFiltro.NombrePaciente));
            }
            if (!string.IsNullOrEmpty(pacienteFiltro.ApellidoMaterno))
            {
                pacientequeryable = pacientequeryable.Where(pacienteDB => pacienteDB.ApellidoMaterno.Contains(pacienteFiltro.ApellidoMaterno));
            }
            if (!string.IsNullOrEmpty(pacienteFiltro.ApellidoPaterno))
            {
                pacientequeryable = pacientequeryable.Where(pacienDB => pacienDB.ApellidoPaterno.Contains(pacienteFiltro.ApellidoPaterno));
            }
            if (pacienteFiltro.NSS != 0)
            {
                pacientequeryable = pacientequeryable.Where(pacienteDB => pacienteDB.NSS.Equals(pacienteFiltro.NSS));
            }
            if (!string.IsNullOrEmpty(pacienteFiltro.Estado))
            {
                pacientequeryable = pacientequeryable.Where(pacienteDB => pacienteDB.Estado.Contains(pacienteFiltro.Estado));
            }
            if (!string.IsNullOrEmpty(pacienteFiltro.UMF))
            {
                pacientequeryable = pacientequeryable.Where(pacienteDB => pacienteDB.UMF.Contains(pacienteFiltro.UMF));
            }
            if (pacienteFiltro.FechaIngreso is not null)
            {
                pacientequeryable = pacientequeryable.Where(pacienteDB => pacienteDB.FechaIngreso.Equals(pacienteFiltro.FechaIngreso));
            }
            if (pacienteFiltro.FechaAlta is not null)
            {
                pacientequeryable = pacientequeryable.Where(pacienteDB => pacienteDB.FechaAlta.Equals(pacienteFiltro.FechaAlta));
            }

            var paciente = await pacientequeryable.ToListAsync(cancellationToken);
            if (paciente.IsNullOrEmpty())
            {
                return BadRequest("El paciente no existe");
            }
            return _mapper.Map<List<GetPacienteDTO>>(paciente);
        }




        /*********************************************************************/
        /*                           METODO PUT                              */
        /*                     ACTUALIZAR REGISTROS                          */
        /*********************************************************************/

        public async Task<ActionResult> PutPacienteAsync(ActualizarPacienteDTO actualizarPacienteDTO, int id, CancellationToken cancellationToken = default)
        {
            var existePaciente = await _context.Pacientes.AnyAsync(pacienteDB => pacienteDB.PacienteId == id,cancellationToken);

            if (!existePaciente)
            {
                return NotFound($"El paciente con con id: {id} no existe");
            }

            var paciente = _mapper.Map<Paciente>(actualizarPacienteDTO);
            paciente.PacienteId = id;

            _context.Update(paciente);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /*********************************************************************/
        /*                       METODO DELETE/POST                           */
        /*                    BORRAR REGISTROS LOGICO                        */
        /*********************************************************************/
        public async Task<ActionResult> DeletePacienteAsync(int id, CancellationToken cancellationToken = default)
        {
            var paciente = await _context.Pacientes.AsTracking().FirstOrDefaultAsync(pacienteDB => pacienteDB.PacienteId == id,cancellationToken);

            if (paciente is null)
            {
                return NotFound($"No existe un paciente con id: {id}");
            }

            paciente.Estatus = true;
            await _context.SaveChangesAsync();
            return Ok($"El paciente con id: {id} fue borrado exitosamente");
        }
        public async Task<ActionResult> RestaurarPacienteAsync(int id, CancellationToken cancellationToken = default)
        {
            var paciente = await _context.Pacientes.AsTracking()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(pacienteDB => pacienteDB.PacienteId == id, cancellationToken);
            if (paciente is null)
            {
                return NotFound($"No existe paciente con el id {id}");
            }
            if (paciente.Estatus == false)
            {
                return BadRequest("El paciente existe en la Base de datos");
            }

            paciente.Estatus = false;
            await _context.SaveChangesAsync();
            return Ok($"El Paciente con id: {id} fue agregado exitosamente");
        }
    }
}
