using System.ComponentModel.DataAnnotations;

namespace HospAPI.Validaciones
{
    public class PesoArchivoValidacion: ValidationAttribute
    {
        private readonly int _pesoMaximoEnMegaBytes;

        //tamaño maximo del archivo
        public PesoArchivoValidacion(int PesoMaximoEnMegaBytes)
        {
            _pesoMaximoEnMegaBytes = PesoMaximoEnMegaBytes;

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //validando si se envio un valor
            if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile formFile = value as IFormFile;
            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if(formFile.Length > _pesoMaximoEnMegaBytes * 1024 *1024)
            {
                return new ValidationResult($"El peso del archivo no deber ser mayor a {_pesoMaximoEnMegaBytes}mb");
            }
            return ValidationResult.Success;

        }
    }
}
