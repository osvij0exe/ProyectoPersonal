using HospAPI.Servicios.interfaces;

namespace HospAPI.Servicios
{
    public class AlmacenadorArchivosAzure : IAlmacenadorArchivos
    {
        private readonly string connectionString;
        public AlmacenadorArchivosAzure(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AzureStorage (TODO pendiente)");
        }
        public Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta, string contenType)
        {
            throw new NotImplementedException();
        }
        Task IAlmacenadorArchivos.BorrarArchivo(string ruta, string contenedor)
        {
            throw new NotImplementedException();
        }

        Task<string> IAlmacenadorArchivos.GuardarArchivo(byte[] contenido, string extension, string contenedor, string contenType)
        {
            throw new NotImplementedException();
        }
    }
}
