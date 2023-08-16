using AutoMapper;
using HospAPI.DTOs.LaboratoriosDTOs;
using HospAPI.Models;
using HospAPI.Servicios.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospAPI.Controllers
{
    public class LaboratoriosController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string contenedor = "ArchivosLaboratorio";

        public LaboratoriosController(ApplicationDbContext context,
            IMapper mapper,
            IAlmacenadorArchivos almacenadorArchivos)
        {
            _context = context;
            _mapper = mapper;
            _almacenadorArchivos = almacenadorArchivos;
        }

        /*********************************************************************/
        /*                       METODO POST                                 */
        /*                    INSERTAR REGISTROS                             */
        /*********************************************************************/

        [HttpPost("Api/post")]
        public async Task<ActionResult> PostLab([FromForm] InsertarLaboratoriosDTO laboratoriosDTO)
        {
            var laboratorio = _mapper.Map<Laboratorio>(laboratoriosDTO);

            if(laboratoriosDTO.ArchivoLab != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await laboratoriosDTO.ArchivoLab.CopyToAsync(memoryStream);
                    var contenido = memoryStream.ToArray();
                    var extension = Path.GetExtension(laboratoriosDTO.ArchivoLab.FileName);
                    laboratorio.ArchivoLab = await _almacenadorArchivos.GuardarArchivo(contenido, extension,
                        contenedor, laboratoriosDTO.ArchivoLab.ContentType);
                }
            }
            var existePacienteId = await _context.Pacientes.AnyAsync(pacienteDB => pacienteDB.PacienteId == laboratoriosDTO.PacienteId);

            if(!existePacienteId)
            {
                return BadRequest($"El paciente con id: {laboratoriosDTO.PacienteId} no existe");
            }
            _context.Add(laboratorio);
            await _context.SaveChangesAsync();
            return Ok(  );

        }

        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/

        [HttpGet("Api/GetLaboratorioPorId")]
        public async Task<ActionResult<GetLaboratoriosDTO>> GetLaboratoriosId(int id)
        {
            var laboratorioDB = await _context.Laboratorios.Include(pacientDB => pacientDB.Paciente).FirstOrDefaultAsync(labDB => labDB.LaboratorioId == id);

            if(laboratorioDB is null)
            {
                return BadRequest($"los estudios de laboratorio con id: {id} no existe");
            }

            return  _mapper.Map<GetLaboratoriosDTO>(laboratorioDB);
        }


        [HttpGet("PaicneteporFecha")]
        public async Task<ActionResult<List<GetLaboratoriosDTO>>> GetLabFecha(DateTime date)
        {
            var laboratorio = await _context.Laboratorios
                .Include(pacienteDB =>pacienteDB.Paciente)
                .Where(LabDB => LabDB.FechaRealizacion
                .Equals(date))
                .ToListAsync();
            if(laboratorio is null)
            {
                return BadRequest();
            }

            return _mapper.Map<List<GetLaboratoriosDTO>>(laboratorio);
        }


        [HttpGet("Api/GetLabboratorioPorIdPaciente")]
        public async Task<ActionResult<GetpacienteLabDTO>> GetLaboratorioByIdPaciente(int id,int pagina = 1)
        {
            var cantidadDeRegistros = 5;

            var LabPacientes = await _context.Pacientes
                .Include(labDB => labDB.Laboratorios
                .OrderByDescending(lab =>lab.FechaRealizacion)
                .Skip((pagina -1)*cantidadDeRegistros )
                .Take(cantidadDeRegistros))
                .FirstOrDefaultAsync(PacienteDB => PacienteDB.PacienteId == id);

            if(LabPacientes is null)
            {
                return NotFound($"El paciente con id: {id} no existe");
            }
            return _mapper.Map<GetpacienteLabDTO>(LabPacientes);

        }
    }
}
