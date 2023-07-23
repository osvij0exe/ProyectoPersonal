using HospAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.PacientesDTOs
{
    public class InsertarPacienteDTO
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo debe ser menor de 20")]
        [PrimeraLetraMayusculaAtribute]
        public string NombrePaciente { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo debe ser menor de 20")]
        [PrimeraLetraMayusculaAtribute]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo debe ser menor de 20")]
        [PrimeraLetraMayusculaAtribute]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [ValidarGeneroAtribute]
        public char Genero { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int NSS { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Agregado { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string UMF { get; set; }
        public int Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? FechaIngreso { get; set; }
        public string Descripcion { get; set; }
    }
}
