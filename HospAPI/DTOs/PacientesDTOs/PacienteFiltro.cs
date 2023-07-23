using HospAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.PacientesDTOs
{
    public class PacienteFiltro
    {
        public int PacienteId { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int NSS { get; set; }
        public string Estado { get; set; }
        public string UMF { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string Descripcion { get; set; }
    }
}
