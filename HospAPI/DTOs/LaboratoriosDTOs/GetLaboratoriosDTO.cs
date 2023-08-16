using HospAPI.DTOs.PacientesDTOs;
using HospAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.LaboratoriosDTOs
{
    public class GetLaboratoriosDTO
    {
        [Required]
        public int LaboratorioId { get; set; }
        public string ArchivoLab { get; set; } //TOODO investigar almacen de archivos
        public DateTime FechaRealizacion { get; set; }
        public int Urea { get; set; }
        public int Creatinina { get; set; }
        public GetPacienteDTO Paciente { get; set; }
    }
}
