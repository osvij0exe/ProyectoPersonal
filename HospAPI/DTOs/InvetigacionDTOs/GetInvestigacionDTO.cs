using HospAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.InvetigacionDTOs
{
    public class GetInvestigacionDTO
    {
        public int InvestigacionId { get; set; }

        public string NombreArticulo { get; set; }

        public string Resumen { get; set; }

        public string Articulo { get; set; } // TODO investigar almacenar archivos


        public DateTime FechaPublicacion { get; set; }

        public List<MedicoInvestigacionDTO> Medicos { get; set; }
    }
}
