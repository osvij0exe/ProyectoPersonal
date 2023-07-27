using System.ComponentModel.DataAnnotations;

namespace HospAPI.DTOs.CuentasDTOs
{
    public class CredencialesUsuario
    {
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo {0} debe ser un Email aceptado")]
        public string Email { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string Password { get; set; }
    }
}
