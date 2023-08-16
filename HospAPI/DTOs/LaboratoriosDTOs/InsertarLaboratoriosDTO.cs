using HospAPI.Models;
using HospAPI.Validaciones.validacionArchivosEnum;
using HospAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.LaboratoriosDTOs
{
    public class InsertarLaboratoriosDTO
    {
        [Required]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Documento)]
        public IFormFile ArchivoLab { get; set; } //TOODO investigar almacen de archivos
        [Required]
        public DateTime FechaRealizacion { get; set; }
        [Required]
        public int Urea { get; set; }
        [Required]

        public int Creatinina { get; set; }
        [Required]
        public int PacienteId { get; set; }
    }
}
