using System.ComponentModel.DataAnnotations;

namespace HospAPI.Models
{
    public class Investigacion
    {
        public int InvestigacionId { get; set; }
        [Display(Name = "Nombre Articulo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo debe ser menor de 20")]
        public string NombreArticulo { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 1000, ErrorMessage = "El campo debe ser menor de 20")]
        public string Resumen { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string  Articulo { get; set; } // TODO investigar almacenar archivos
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public DateTime FechaPublicacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public List<Medico> Medicos { get; set; }
        
    }
}
