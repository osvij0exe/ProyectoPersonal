namespace HospAPI.Models
{
    public class Estudio
    {
        public int EstudioId { get; set; }
        public string NombreEstudio { get; set; }
        public string Descripcion { get; set; }
        public char TipoEstudioId { get; set; } // relacion uno a muchos llaveForanea
        public TipoEstudio TipoEstudio { get; set; }// propiedad de navegacón
        public Reporte Reporte { get; set; }
        public List<ArchivoEstudio> ArchivosEstudios { get; set; }
    }
}
