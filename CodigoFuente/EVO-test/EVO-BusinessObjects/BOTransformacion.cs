namespace EVO_BusinessObjects
{
    public class BOTransformacion
    {
        /// <summary>
        /// Define la clave primaria
        /// </summary>
        public int TransformacionId { get; set; }

        /// <summary>
        /// Define el código del artículo transformado
        /// </summary>
        public string CodigoArticuloTransformado { get; set; }

        /// <summary>
        /// Define el nombre del artículo transformado
        /// </summary>
        public string NombreArticuloTransformado { get; set; }

        /// <summary>
        /// Define la clave foránea de Articulo
        /// </summary>     
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Define la propiedad de navegación a Artículo
        /// </summary>     
        public BOArticulo Articulo { get; set; }

        /// <summary>
        /// Define la cantidad minima en stock para poder ser transformado
        /// </summary>
        public decimal CantidadMinima { get; set; }

        /// <summary>
        /// Define si el artículo puede ser eliminado
        /// </summary>
        public bool Eliminar { get; set; } = false;
    }
}
