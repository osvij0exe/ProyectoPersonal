using HospAPI.Models;
using HospAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.MedcosDTOs
{
    public class GetMedicoDTO
    {
        public int MedicoId { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20)]
        [PrimeraLetraMayusculaAtribute]
        public string NombreMedico { get; set; }
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20)]
        [PrimeraLetraMayusculaAtribute]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20)]
        [PrimeraLetraMayusculaAtribute]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [ValidarGeneroAtribute]
        public char Genero { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20)]
        [PrimeraLetraMayusculaAtribute]
        public string Especialidad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20)]
        [PrimeraLetraMayusculaAtribute]
        public string SubEspecialidad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(10000000, 99999999, ErrorMessage = "No es una {0} valida")]
        public int Matricula { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(10000000, 99999999, ErrorMessage = "No es una {0} valida")]
        public int CedulaProfesional { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? FechaIngreso { get; set; }
        [Range(10000000, 99999999, ErrorMessage = "No es un {0} valido")]

        public int Telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "EL {0} no es un correo valido")]
        public string Email { get; set; }
        public string Descripcion { get; set; }

    }
}
