using HospAPI.Models;
using HospAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.LaboratoriosDTOs
{
    public class GetpacienteLabDTO
    {
        public int PacienteId { get; set; }

        public string NombrePaciente { get; set; }

        public string ApellidoPaterno { get; set; }

        public string ApellidoMaterno { get; set; }

        public char Genero { get; set; }

        public int NSS { get; set; }

        public int Agregado { get; set; }
        public string UMF { get; set; }
        public List<LaboratoriosDTO> Laboratorios { get; set; }

    }
}
