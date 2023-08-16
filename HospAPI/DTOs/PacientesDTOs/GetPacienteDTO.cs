using HospAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.PacientesDTOs
{
    public class GetPacienteDTO
    {
        public int PacienteId { get; set; }
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
        [StringLength(maximumLength: 11, ErrorMessage = "El campo debe ser menor de 11")]
        public int NSS { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 8, ErrorMessage = "El campo debe ser menor de 8")]
        public int Agregado { get; set; }
        public string Estado { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo debe ser menor de 20")]
        public string UMF { get; set; }
        [Range(10000000, 99999999, ErrorMessage = "No es un {0} valido")]
        public int Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Descripcion { get; set; }
    }
}
