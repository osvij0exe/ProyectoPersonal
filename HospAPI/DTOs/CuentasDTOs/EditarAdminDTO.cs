using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.CuentasDTOs
{
    public class EditarAdminDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "No es un Email valido")]
        public string Email { get; set; }
    }
}
