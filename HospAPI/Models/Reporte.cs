namespace HospAPI.Models
{
    public class Reporte
    {
        public int ReporteId { get; set; }
        public string ReporteMedico { get; set; } // investigar almacenar archivos
        public DateTime FechaReporte { get; set; }
        public string Descripcion { get; set; }
        public string Caso { get; set; }
        public int EstudioId { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
    }
}
