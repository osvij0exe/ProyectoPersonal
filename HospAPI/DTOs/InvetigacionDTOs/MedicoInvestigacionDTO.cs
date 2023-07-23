using HospAPI.DTOs.MedcosDTOs;
using HospAPI.Models;

namespace HospAPI.DTOs.InvetigacionDTOs
{
    public class MedicoInvestigacionDTO
    {
        public int MedicoId { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Matricula { get; set; }

    }
}
