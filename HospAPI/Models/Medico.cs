using HospAPI.Validaciones;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.Models
{
    public class Medico
    {
        public int MedicoId { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20,ErrorMessage ="El campo debe ser menor de 20")]
        [PrimeraLetraMayusculaAtribute]
        public string NombreMedico { get; set;}
        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo debe ser menor de 20")]
        [PrimeraLetraMayusculaAtribute]
        public string ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20)]
        [PrimeraLetraMayusculaAtribute]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [ValidarGeneroAtribute]
        public char Genero { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo debe ser menor de 20")]
        [PrimeraLetraMayusculaAtribute]
        public string Especialidad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo debe ser menor de 20")]
        [PrimeraLetraMayusculaAtribute]
        public string SubEspecialidad { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(10000000, 99999999, ErrorMessage = "No es una {0} valida")]
        public int Matricula { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(10000000, 99999999, ErrorMessage = "No es una {0} valida")]
        public int CedulaProfesional { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public DateTime? FechaIngreso { get; set;}
        [Range(10000000, 99999999, ErrorMessage = "No es un {0} valido")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "EL {0} no es un correo valido")]
        public string Email { get; set; }
        [StringLength(maximumLength: 10000, ErrorMessage = "El campo debe ser menor de 10000")]
        public string Descripcion { get; set; }
        public bool Estaus { get; set; } = false;
        public List<Expediente> Expedientes { get; set; }
        public List<Reporte> Reportes { get; set; }
        public List<Investigacion> Investigaciones { get; set; } // relacion muchos a muchos

    }
}
