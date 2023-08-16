using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.Models
{
    //propiedades adicionales para la tabla de usuarios de .et
    public class HospIdentityUsers: IdentityUser
    {
        [StringLength(50)]
        public string Nombres { get; set; } = default!;
        [StringLength(50)]
        public string Apellidos { get; set; } = default!;
    }
}
