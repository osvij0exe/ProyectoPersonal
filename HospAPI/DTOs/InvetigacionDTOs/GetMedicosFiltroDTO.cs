using HospAPI.Models;

namespace HospAPI.DTOs.InvetigacionDTOs
{
    public class GetMedicosFiltroDTO
    {
        public int MedicoId { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int Matricula { get; set; }
        public List<InvestigacionFiltroDTO> Investigaciones { get; set; }

    }
}
