using System.ComponentModel.DataAnnotations;

namespace HospAPI.Validaciones
{
    public class ValidarGeneroAtribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var genero = char.ToUpper(value.ToString()[0]);


            if(genero == 'F' || genero == 'M')
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("No es un genero valido ( F / M )");
        }
    }
}
