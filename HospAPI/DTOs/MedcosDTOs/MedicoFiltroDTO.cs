namespace HospAPI.DTOs.MedcosDTOs
{
    public class MedicoFiltroDTO
    {
        public int MedicoId { get; set; }
        public string NombreMedico { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Especialidad { get; set; }
        public string SubEspecialidad { get; set; }
        public int Matricula { get; set; }
        public int CedulaProfesional { get; set; }
    }
}
