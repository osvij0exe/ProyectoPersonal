using HospAPI.Validaciones.validacionArchivosEnum;
using System.ComponentModel.DataAnnotations;

namespace HospAPI.Validaciones
{
    public class TipoArchivoValidacion: ValidationAttribute
    {
        private readonly string[] _tiposValidos;

        public TipoArchivoValidacion(string[] tiposValidos)
        {
            this._tiposValidos = tiposValidos;
        }
        public TipoArchivoValidacion(GrupoTipoArchivo grupoTipoArchivo)
        {
            if(grupoTipoArchivo == GrupoTipoArchivo.Documento)
            {
                _tiposValidos = new string[] { "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
            }
            if (grupoTipoArchivo == GrupoTipoArchivo.Imagen)
            {
                _tiposValidos = new string[] { "image/jpeg", "image/png", "image/gif" };
            }
            if (grupoTipoArchivo == GrupoTipoArchivo.Dicom)
            {
                _tiposValidos = new string[] { "image/dc3", "image/dic", "image/dcm" };
            }
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

            if(!_tiposValidos.Contains(formFile.ContentType))
            {
                return new ValidationResult($"El tipo del archivo debe ser uno de los siguientes: {string.Join(", ", _tiposValidos)}");
            }
            return ValidationResult.Success;

        }
    }
}
