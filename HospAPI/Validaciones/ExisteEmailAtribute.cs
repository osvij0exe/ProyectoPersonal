using System.ComponentModel.DataAnnotations;

namespace HospAPI.Validaciones
{
    //TODO revisar error de validacion no permite ingresar ningun registro

    public class ExisteEmailAtribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var correo = value.ToString().ToUpper();
            if(correo == value.ToString().ToUpper())
            {
                return new ValidationResult("El Email debe ser unico");
            }
            return ValidationResult.Success;

        }
    }
}
