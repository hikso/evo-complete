//using IDocumentFilter = Swashbuckle.Swagger.IDocumentFilter;
using Swashbuckle.Swagger;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http.Description;

namespace EVO_WebApi.Filters
{
    /// <summary>
    /// BasePath Document Filter sets BasePath property of Swagger and removes it from the individual URL paths
    /// </summary>
    public class BasePathFilter : IDocumentFilter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="basePath">BasePath to remove from Operations</param>
        public BasePathFilter(string basePath)
        {
            BasePath = basePath;
        }

        /// <summary>
        /// Gets the BasePath of the Swagger Doc
        /// </summary>
        /// <returns>The BasePath of the Swagger Doc</returns>
        public string BasePath { get; }

        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.basePath = this.BasePath;

            var pathsToModify = swaggerDoc.paths.Where(p => p.Key.StartsWith(this.BasePath)).ToList();

            foreach (var path in pathsToModify)
            {
                if (path.Key.StartsWith(this.BasePath))
                {
                    string newKey = Regex.Replace(path.Key, $"^{this.BasePath}", string.Empty);
                    swaggerDoc.paths.Remove(path.Key);
                    swaggerDoc.paths.Add(newKey, path.Value);
                }
            }
        }
    }
}