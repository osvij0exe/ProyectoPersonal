﻿using AutoMapper;
using HospAPI.DTOs;
using HospAPI.DTOs.InvetigacionDTOs;
using HospAPI.Models;
using HospAPI.Servicios.interfaces;
using HospAPI.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HospAPI.Servicios
{
    public class InvestigacionServices : ControllerBase, IInvestigacionesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAlmacenadorArchivos _almacenadorArchivos;
        private readonly string contenedor = "Articulos";

        public InvestigacionServices(ApplicationDbContext context,
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


        public async Task<ActionResult> PostArticuloAsync([FromForm] InsertarInvestigacionDTO insertarInvestigacionDTO, CancellationToken cancellationToken = default)
        {
            var articulo = _mapper.Map<Investigacion>(insertarInvestigacionDTO);

            if (insertarInvestigacionDTO.Articulo != null)
            {
                using (var memorystream = new MemoryStream())
                {
                    await insertarInvestigacionDTO.Articulo.CopyToAsync(memorystream);
                    var contendio = memorystream.ToArray();
                    var extension = Path.GetExtension(insertarInvestigacionDTO.Articulo.FileName);
                    articulo.Articulo = await _almacenadorArchivos.GuardarArchivo(contendio, extension,
                        contenedor, insertarInvestigacionDTO.Articulo.ContentType);
                }
            }

              articulo.Medicos.ForEach(medicoDb => _context.Entry(medicoDb).State = EntityState.Unchanged);

            if (articulo.Medicos.IsNullOrEmpty())
            {
                return BadRequest("Se requiere minimo un Id de un Médico");
            }
            var medicosId = _context.Medicos.Select(x => x.MedicoId).ToList();
            var getArticulosMedicosId = articulo.Medicos.Select(x => x.MedicoId).ToList();


            foreach (var id in getArticulosMedicosId)
            {
                if (!medicosId.Contains(id))
                {
                    return BadRequest($"El médico con id: {id} no existe");
                }
            }

             _context.Add(articulo);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok("El Articulo fue agregado exitosamente");
        }

        /*********************************************************************/
        /*                       METODO GET                                 */
        /*                  CONSULTAR REGISTROS                             */
        /*********************************************************************/
        public async Task<ActionResult<List<GetInvestigacionDTO>>> GetListaArticulosAsync([FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default)
        {
            var artQueryable = _context.Investigaciones.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(artQueryable);

            var ArticuloBD = await artQueryable.OrderBy(artDB => artDB.NombreArticulo)
                .Include(medicoDb => medicoDb.Medicos
                .OrderBy(m => m.ApellidoMaterno))
                .Paginar(paginacionDTO)
                .ToListAsync(cancellationToken);
            return _mapper.Map<List<GetInvestigacionDTO>>(ArticuloBD);

        }
        public async Task<ActionResult<GetInvestigacionDTO>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var articulo = await _context.Investigaciones
             .Include(MeidocoDb => MeidocoDb.Medicos)
            .FirstOrDefaultAsync(art => art.InvestigacionId == id);

            if (articulo is null)
            {
                return NotFound($"El articulo con {id} no existe");
            }
            return _mapper.Map<GetInvestigacionDTO>(articulo);
        }
        public async Task<ActionResult<List<GetInvestigacionDTO>>> GetInvestigacionPorNombreAsync(string nombre, CancellationToken cancellationToken = default)
        {
            //var articulo = await _context.Investigaciones.FirstOrDefaultAsync(m => m.NombreArticulo == nombre);
            var articulo = await _context.Investigaciones
                .Include(medicoDB => medicoDB.Medicos)
                .Where(articuloDB => articuloDB.NombreArticulo.Contains(nombre)).ToListAsync()
;

            if (articulo is null)
            {
                return NotFound($"El articulo con nombre: {nombre} no fue encontrado o no existe");
            }
            return _mapper.Map<List<GetInvestigacionDTO>>(articulo);
        }
        public async Task<ActionResult<List<GetMedicosFiltroDTO>>> GetInvestigacionPorDatosMedicoAsync([FromQuery] MedicoInvestigacionDTO medicoInvestigacionDTO, int pagina = 1, CancellationToken cancellationToken = default)
        {
            var cantidadRegistrosPorPagina = 5;

            var medicoQueriable = _context.Medicos.AsQueryable();

            if (medicoInvestigacionDTO.MedicoId != 0)
            {
                medicoQueriable = medicoQueriable.Where(medicoDB => medicoDB.MedicoId.Equals(medicoInvestigacionDTO.MedicoId));
            }
            if (!string.IsNullOrEmpty(medicoInvestigacionDTO.NombreMedico))
            {

                medicoQueriable = medicoQueriable.Where(medicoDB => medicoDB.NombreMedico.Contains(medicoInvestigacionDTO.NombreMedico));
            }
            if (!string.IsNullOrEmpty(medicoInvestigacionDTO.ApellidoMaterno))
            {
                medicoQueriable = medicoQueriable.Where(medicoDB => medicoDB.ApellidoMaterno.Contains(medicoInvestigacionDTO.ApellidoMaterno));
            }
            if (!string.IsNullOrEmpty(medicoInvestigacionDTO.ApellidoPaterno))
            {
                medicoQueriable = medicoQueriable.Where(medicoDB => medicoDB.ApellidoPaterno.Contains(medicoInvestigacionDTO.ApellidoPaterno));
            }
            if (medicoInvestigacionDTO.Matricula != 0)
            {
                medicoQueriable = medicoQueriable.Where(medicoDB => medicoDB.Matricula.Equals(medicoInvestigacionDTO.Matricula));
            }


            var artMedicos = await medicoQueriable
                .Include(invest => invest.Investigaciones
                .OrderByDescending(i => i.FechaPublicacion)
                .Skip((pagina - 1) * cantidadRegistrosPorPagina)
                .Take(cantidadRegistrosPorPagina))
                .ToListAsync(cancellationToken);

            if (artMedicos.IsNullOrEmpty())
            {
                return BadRequest("No se encontro ningun articulo");
            }


            return _mapper.Map<List<GetMedicosFiltroDTO>>(artMedicos);
        }
        public async Task<ActionResult<List<GetInvestigacionDTO>>> GetInvestigacionPorDatosAsync([FromQuery] InvestigacionFiltroDTO investigacionFiltroDTO, [FromQuery] PaginacionDTO paginacionDTO, CancellationToken cancellationToken = default)
        {
            var articuloMedQueriable = _context.Investigaciones.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnCabecera(articuloMedQueriable);

            var medicoQueriable = _context.Medicos.AsQueryable();

            if (investigacionFiltroDTO.InvestigacionId != 0)
            {
                articuloMedQueriable = articuloMedQueriable.Where(articuloDB => articuloDB.InvestigacionId.Equals(investigacionFiltroDTO.InvestigacionId));
            }
            if (!string.IsNullOrEmpty(investigacionFiltroDTO.NombreArticulo))
            {
                articuloMedQueriable = articuloMedQueriable.Where(articuloDB => articuloDB.NombreArticulo.Contains(investigacionFiltroDTO.NombreArticulo));
            }
            if (investigacionFiltroDTO.FechaPublicacion.ToString() is null)
            {
                articuloMedQueriable = articuloMedQueriable.Where(articuloDB => articuloDB.FechaPublicacion.Equals(investigacionFiltroDTO.FechaPublicacion));
            }




            var articuloMedico = await articuloMedQueriable
                .Include(medicoDB => medicoDB.Medicos.OrderBy(m => m.ApellidoMaterno))
                .Paginar(paginacionDTO).OrderByDescending(a => a.FechaPublicacion)
                .ToListAsync(cancellationToken);

            if (articuloMedico.IsNullOrEmpty())
            {
                return BadRequest("No se encontro ningun articulo");
            }

            return _mapper.Map<List<GetInvestigacionDTO>>(articuloMedico);
        }

    }
}
