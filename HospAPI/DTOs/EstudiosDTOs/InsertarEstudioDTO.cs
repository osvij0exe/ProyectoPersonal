using HospAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.EstudiosDTOs
{
    public class InsertarEstudioDTO
    {
        [Required]
        public string NombreEstudio { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public char TipoEstudioId { get; set; } // relacion uno a muchos llaveForanea
        public TipoEstudio TipoEstudio { get; set; }// propiedad de navegacón
        public Reporte Reporte { get; set; }
        public List<int> ArchivosEstudios { get; set; }
    }
}
