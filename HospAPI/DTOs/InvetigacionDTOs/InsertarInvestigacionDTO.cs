using HospAPI.Helpers;
using HospAPI.Validaciones;
using HospAPI.Validaciones.validacionArchivosEnum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.InvetigacionDTOs
{
    public class InsertarInvestigacionDTO
    {
        [Display(Name = "Nombre Articulo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} debe ser menor de {1}")]
        public string NombreArticulo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 1000, ErrorMessage = "El campo debe ser menor de 20")]
        public string Resumen { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [PesoArchivoValidacion(PesoMaximoEnMegaBytes: 5)]
        [TipoArchivoValidacion(grupoTipoArchivo: GrupoTipoArchivo.Documento)]
        [Unicode]
        public IFormFile Articulo { get; set; } 
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime FechaPublicacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [ModelBinder(BinderType = typeof(TypeBinder))]
      
        public List<int> Medicos { get; set; }
    }
}
