using System.ComponentModel.DataAnnotations;

namespace HospAPI.Validaciones
{
    public class PrimeraLetraMayusculaAtribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value/*valor del campo de la clase*/, ValidationContext validationContext)/*valor del objeto*/
        {
            if(value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            var primeraLetra = value.ToString()[0].ToString();
            if(primeraLetra != primeraLetra.ToUpper())
            {
                return new ValidationResult("La Primera letra debe ser mayúscula");
            }
            return ValidationResult.Success;
        }
    }
}
