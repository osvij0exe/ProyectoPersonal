namespace HospAPI.Models
{
    public class ArchivoEstudio
    {
        public int ArchivoEstudioId{ get; set; }
        public string Descripcion { get; set; }
        public string ImagenDicom { get; set; }
        public DateTime FechaRealizacion { get; set; }
        public int EstudioId { get; set; }
        public Estudio Estudio { get; set; }
    }
}
