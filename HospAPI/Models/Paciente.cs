using HospAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.Models
{
    public class Paciente
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
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "El campo debe ser menor de 20")]
        public int NSS { get; set; }
        [Required]
        [StringLength(maximumLength: 20,MinimumLength = 1, ErrorMessage = "El campo debe ser menor de 20")]
        public int Agregado { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo debe ser menor de 20")]
        [PrimeraLetraMayusculaAtribute]
        public string Estado { get; set; }
        public string UMF { get; set; }
        public int Telefono { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Descripcion { get; set; }
        public bool Estatus { get; set; }
        public Expediente Expediente { get; set; }
        public List<Reporte> Reportes { get; set; }
        public List<Laboratorio> Laboratorios { get; set; }

    }
}
