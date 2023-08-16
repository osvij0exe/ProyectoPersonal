using HospAPI.Models;

namespace HospAPI.DTOs.LaboratoriosDTOs
{
    public class LaboratoriosDTO
    {
        public int LaboratorioId { get; set; }
        public string ArchivoLab { get; set; } //TOODO investigar almacen de archivos
        public DateTime FechaRealizacion { get; set; }
        public int Urea { get; set; }
        public int Creatinina { get; set; }
        public int PacienteId { get; set; }
    }
}
