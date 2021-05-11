using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 29-Abr/2020
    /// Descripción     : Clase que representa un objeto de negocio de tipo ArticuloPuntoVentaResponse
    /// </summary>
    public class BOArticuloPuntoVentaResponse
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>      
        public string CodigoArticulo { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>     
        public string NombreArticulo { get; set; }

        /// <summary>
        /// Stock
        /// </summary>
        /// <value>Stock</value>       
        public decimal? Stock { get; set; }

        /// <summary>
        /// Unidad de medida
        /// </summary>
        /// <value>Unidad de medida</value>       
        public string UnidadMedida { get; set; }

        /// <summary>
        /// Lote
        /// </summary>
        /// <value>Lote</value>        [
        public string Lote { get; set; }

        /// <summary>
        /// Precio unitario
        /// </summary>
        /// <value>Precio unitario</value>        
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Código del IVA
        /// </summary>
        /// <value>Código del IVA</value>        
        public string CodigoIVA { get; set; }

        /// <summary>
        /// Valor del IVA
        /// </summary>
        /// <value>Valor del IVA</value>       
        public decimal? ValorIVA { get; set; }

        /// <summary>
        /// Incida el código de la retención
        /// </summary>
        /// <value>Retencion</value>       
        public string CodigoRetencion { get; set; }

        /// <summary>
        /// Retencion
        /// </summary>
        /// <value>Retencion</value>       
        public decimal? ValorRetencion { get; set; }

        /// <summary>
        /// Indica la cantidad mínima para obtener el precio unitario al por mayor
        /// </summary>
        /// <value>Indica la cantidad mínima para obtener el precio unitario al por mayor</value>        
        public decimal? CantidadMinimaPrecioPorMayor { get; set; }

        /// <summary>
        /// Indica el precio unitario por mayor
        /// </summary>
        /// <value>Indica el precio unitario por mayor</value>      
        public decimal? PrecioUnitarioPorMayor { get; set; }

        /// <summary>
        /// Indica los artículos que hacen parte de la transformación
        /// </summary>        
        public List<BOArticuloTransformacionResponse> ArticulosTransformacionResponse { get; set; }
    }
}
