using HospAPI.Servicios.interfaces;

namespace HospAPI.Servicios
{
    public class AlmacenadorArchivosLocal : IAlmacenadorArchivos
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AlmacenadorArchivosLocal(IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task BorrarArchivo(string ruta, string contenedor)
        {
            if (ruta != null)
            {
                var nombreArchivo = Path.GetFileName(ruta);
                string directorioArchivo = Path.Combine(_env.WebRootPath, contenedor, nombreArchivo);

                if(File.Exists(directorioArchivo))
                {
                    File.Delete(directorioArchivo);
                }
            }
                return Task.FromResult(0);
        }

        public async Task<string> EditarArchivo(byte[] contenido, string extension, string contenedor, string ruta, string contenType)
        {
            await BorrarArchivo(ruta, contenedor);
            return await GuardarArchivo(contenido, extension, contenedor, contenType);
        }

        public async Task<string> GuardarArchivo(byte[] contenido, string extension, string contenedor, string contenType)
        {
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.WebRootPath, contenedor);
            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }   
            string ruta = Path.Combine(folder, nombreArchivo);
            await File.WriteAllBytesAsync(ruta, contenido);

            var urlActual = $"{_httpContextAccessor.HttpContext.Request.Scheme}:// {_httpContextAccessor.HttpContext.Request.Host}";
            var urlParaBD = Path.Combine(urlActual,contenedor, nombreArchivo).Replace("\\", "/");
            return urlParaBD;
        }
    }
}
