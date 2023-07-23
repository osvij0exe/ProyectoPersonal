using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HospAPI.Helpers
{
    public class TypeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //propiedad en la que se desa trabajar
            var nombrePropiedad = bindingContext.ModelName;
            // obtener el valor de la propiedad
            var proveedorDeValores = bindingContext.ValueProvider.GetValue(nombrePropiedad);

            //si el valor es nulo
            if(proveedorDeValores == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            try
            {
                var valorDeserializado = JsonConvert.DeserializeObject<List<int>>(proveedorDeValores.FirstValue);
                bindingContext.Result = ModelBindingResult.Success(valorDeserializado);
            }
            catch
            {
                bindingContext.ModelState.TryAddModelError(nombrePropiedad, "Valor inválido para tipo List<int>");
            }
            return Task.CompletedTask;

        }
    }
}
