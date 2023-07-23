namespace HospAPI.Models
{
    public class Expediente
    {
        public int ExpedienteId { get; set; }
        public  string Descripcion { get; set; }
        public DateTime FechaUltimaActualizacion { get;}
        public string ArchivoExpediente { get; set; }
        public int PacienteId { get; set; } 
        public List<Medico> Medicos { get; set; }
    }
}
