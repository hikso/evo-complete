using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace EVO_DataAccess.Utils
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga
    /// Fecha de Creación: 31-Jul/2019
    /// Descripción      : Esta clase permite leer elementos de configuración del archivo appsettings.json
    ///                    Tomado de: https://www.ttmind.com/techpost/How-to-read-appSettings-JSON-from-Class-Library-in-ASP-NET-Core
    /// </summary>
    /// 
    public class AppConfiguration
    {
        /// <summary>
        /// Sección de elementos de configuración AppSettings
        /// </summary>
        public IConfigurationSection AppSettings { get; private set; }

        /// <summary>
        /// Sección de elementos de Cadenas de Conexión
        /// </summary>
        public IConfigurationSection ConnectionString { get; private set; }

        /// <summary>
        /// Lee el archivo appsettings.json de la ruta raíz y busca las propiedades ConnectionString y ApplicationSettings
        /// </summary>
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();

            //Importante el Directory.GetCurrentDirectory() devuelve la ruta de ejecución del proyecto de inicio.
            //El proyecto de inicio debe ser EVO-WebApi
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            //var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");            

            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();

            ConnectionString = root.GetSection("ConnectionStrings");

            AppSettings = root.GetSection("ApplicationSettings");
        }
    }
}