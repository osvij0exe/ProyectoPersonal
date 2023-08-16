
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HospAPI.DTOs;
using HospAPI.DTOs.MedcosDTOs;
using HospAPI.Models;
using HospAPI.Servicios.interfaces;
using HospAPI.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospAPI.Servicios
{
    public class MedicoServices :ControllerBase, IMedicosServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MedicoServices(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper  = mapper;
        }

        /*********************************************************************/
        /*                       METODO POST                                 */
        /*                    INSERTAR REGISTROS                             */
        /*********************************************************************/
        public async Task<ActionResult> PostMedicoAsync(InsertarMedicoDTO insertarMedicoDTO, CancellationToken cancellationToken = default)
        {
            var existeMatricula = await _context.Medicos.AnyAsync(medicoDB => medicoDB.Matricula == insertarMedicoDTO.Matricula, cancellationToken);
            var existeCedula = await _context.Medicos.AnyAsync(medicoDB => medicoDB.CedulaProfesional == insertarMedicoDTO.CedulaProfesional, cancellationToken);
            var existeEmail = await _context.Medicos.AnyAsync(medicoDB => medicoDB.Email == insertarMedicoDTO.Email, cancellationToken);


            if (existeMatricula)
            {
                return BadRequest($"ya existe un Médico con la Matricula: {insertarMedicoDTO.Matricula}");
            }
            if (existeCedula)
            {
                return BadRequest($"ya existe un Médico con la Cedula: {insertarMedicoDTO.CedulaProfesional}");
            }
            if (existeEmail)
            {
                return BadRequest($"El Email debe ser unico");
            }

            var medico = _mapper.Map<Medico>(insertarMedicoDTO);
            _context.Add(medico);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok("El médico fue agregado exitosamente");
        }

        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/

        public async Task<IEnumerable<GetMedicoDTO>> getMedicoListAsync(int pagina = 1, CancellationToken cancellationToken = default)
        {
            var PaginaRegistros = 5;

            return await _context.Medicos
                .ProjectTo<GetMedicoDTO>(_mapper.ConfigurationProvider)
                .Skip((pagina - 1) * PaginaRegistros)
                .Take(PaginaRegistros)
                .OrderBy(medicoDB => medicoDB.NombreMedico)
                .ToListAsync(cancellationToken);
        }
        public async Task<ActionResult<List<GetMedicoDTO>>> getMedicoListConDTOAsync([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default)
        {
            var queryable = _context.Medicos.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(queryable);

            var medicos = await queryable.OrderBy(medicoDb => medicoDb.NombreMedico).Paginar(paginacionDTO).ToListAsync(cancellationToken);
            return _mapper.Map<List<GetMedicoDTO>>(medicos);
        }

        public async Task<ActionResult<GetMedicoDTO>> GetMedicoAsync(int id, CancellationToken cancellationToken = default)
        {
            var medico = await _context.Medicos.FirstOrDefaultAsync(medicoDB => medicoDB.MedicoId == id,cancellationToken);
            if (medico is null)
            {
                return BadRequest($"El Médico con Id: {id} No se encontro");
            }
            return _mapper.Map<GetMedicoDTO>(medico);
        }
        public async Task<ActionResult<List<GetMedicoDTO>>> GetByNameAsync(string nombre, CancellationToken cancellationToken = default)
        {
            var medico = await _context.Medicos.Where(medicoDB => medicoDB.NombreMedico.Contains(nombre)).ToListAsync(cancellationToken);
            if (medico.IsNullOrEmpty())
            {
                return BadRequest($"El Médico con Nombre: {nombre} no existe");
            }
            return _mapper.Map<List<GetMedicoDTO>>(medico);
        }
        public async Task<ActionResult<GetMedicoDTO>> GetByMatriculaAsync(int matriucla, CancellationToken cancellationToken = default)
        {
            var matriculamedico = await _context.Medicos.FirstOrDefaultAsync(medicoDB => medicoDB.Matricula == matriucla, cancellationToken);
            if (matriculamedico is null)
            {
                return BadRequest($"El Médico con Matricula: {matriucla} no existe");
            }
            return _mapper.Map<GetMedicoDTO>(matriculamedico);
        }
        public async Task<ActionResult<GetMedicoDTO>> GetByCedulaAsync(int cedula, CancellationToken cancellationToken = default)
        {
            var cedulaMedico = await _context.Medicos.FirstOrDefaultAsync(medicoDB => medicoDB.CedulaProfesional == cedula,cancellationToken);
            if (cedulaMedico is null)
            {
                return BadRequest($"El Médico con Cedula Profesional: {cedula} no existe");
            }
            return _mapper.Map<GetMedicoDTO>(cedulaMedico);
        }
        public async Task<ActionResult<List<GetMedicoDTO>>> FiltrarParametroAsync([FromQuery] MedicoFiltroDTO medicoFiltroDTO, CancellationToken cancellationToken = default)
        {
            var medicosQueryable = _context.Medicos.AsQueryable();

            if (medicoFiltroDTO.MedicoId != 0)
            {
                medicosQueryable = medicosQueryable.Where(medicoDB => medicoDB.MedicoId.Equals(medicoFiltroDTO.MedicoId));
            }

            if (!string.IsNullOrEmpty(medicoFiltroDTO.NombreMedico))
            {
                medicosQueryable = medicosQueryable.Where(medicoDB => medicoDB.NombreMedico.Contains(medicoFiltroDTO.NombreMedico));
            }

            if (!string.IsNullOrEmpty(medicoFiltroDTO.ApellidoPaterno))
            {
                medicosQueryable = medicosQueryable.Where(medicoDB => medicoDB.ApellidoPaterno.Contains(medicoFiltroDTO.ApellidoPaterno));
            }
            if (!string.IsNullOrEmpty(medicoFiltroDTO.ApellidoMaterno))
            {
                medicosQueryable = medicosQueryable.Where(medicoDB => medicoDB.ApellidoMaterno.Contains(medicoFiltroDTO.ApellidoMaterno));
            }
            if (!string.IsNullOrEmpty(medicoFiltroDTO.Especialidad))
            {
                medicosQueryable = medicosQueryable.Where(medicoBD => medicoBD.Especialidad.Contains(medicoFiltroDTO.Especialidad));
            }
            if (!string.IsNullOrEmpty(medicoFiltroDTO.SubEspecialidad))
            {
                medicosQueryable = medicosQueryable.Where(medicoDB => medicoDB.SubEspecialidad.Contains(medicoFiltroDTO.SubEspecialidad));
            }
            if (medicoFiltroDTO.Matricula != 0)
            {
                medicosQueryable = medicosQueryable.Where(medicoDB => medicoDB.Matricula.Equals(medicoFiltroDTO.Matricula));
            }
            if (medicoFiltroDTO.CedulaProfesional != 0)
            {
                medicosQueryable = medicosQueryable.Where(medicoDB => medicoDB.CedulaProfesional.Equals(medicoFiltroDTO.CedulaProfesional));
            }

            var medicos = await medicosQueryable.ToListAsync(cancellationToken);

            if (medicos.IsNullOrEmpty())
            {
                return BadRequest("El Medico no existe");
            }


            return _mapper.Map<List<GetMedicoDTO>>(medicos);
        }


        /*********************************************************************/
        /*                           METODO PUT                              */
        /*                     ACTUALIZAR REGISTROS                          */
        /*********************************************************************/


        public async Task<ActionResult> PutActualizacionAsync(InsertarMedicoDTO insertarMedicoDTO, int id, CancellationToken cancellationToken = default)
        {
            var medicoDB = await _context.Medicos.AsTracking().FirstOrDefaultAsync(m => m.MedicoId == id,cancellationToken);

            if (medicoDB is null)
            {
                return BadRequest("El id del Médico no con concide con el id del URL");
            }

            medicoDB = _mapper.Map(insertarMedicoDTO, medicoDB);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok();
        }

        /*********************************************************************/
        /*                       METODO DELETE/POST                          */
        /*                    BORRAR REGISTROS LOGICO                        */
        /*********************************************************************/

        public async Task<ActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var medico = await _context.Medicos.AsTracking().FirstOrDefaultAsync(m => m.MedicoId == id, cancellationToken);
            if (medico is null)
            {
                return NotFound($"El Médico con id: {id} no se encontro");
            }
            medico.Estaus = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Ok($"El Médico con id: {id} fue borrado con exito");
        }

        public async Task<ActionResult> RestaurarAsync(int id, CancellationToken cancellationToken = default)
        {
            var medico = await _context.Medicos.AsTracking()
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(m => m.MedicoId == id, cancellationToken);
            if (medico is null)
            {
                return NotFound($"El Médico con id: {id} no se encontro");
            }
            if (medico.Estaus == false)
            {
                return BadRequest("El paciente existe en la Base de datos");
            }

            medico.Estaus = false;
            await _context.SaveChangesAsync(cancellationToken);
            return Ok($"El Médico con id: {id} fue agregado con exito");
        }
    }
}