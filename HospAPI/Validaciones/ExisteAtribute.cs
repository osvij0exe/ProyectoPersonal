using System.ComponentModel.DataAnnotations;

namespace HospAPI.Validaciones
{
    //TODO revisar error de validacion no permite ingresar ningun registro
    public class ExisteAtribute: ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

 

            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var matricula = value.ToString();

            if(matricula == value.ToString())
            {
                return new ValidationResult("El campo no se puede repetir");
            }
                return ValidationResult.Success;
        }
    }
}
