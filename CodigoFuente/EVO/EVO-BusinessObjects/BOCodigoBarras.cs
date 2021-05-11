namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 23-Mar/2020
    /// Descripción      : Esta clase respresenta un objeto de negocio BOCodigoBarrasResponse
    /// </summary>
    public class BOCodigoBarras
    {
        /// <summary>
        /// Código de barras (01421=código artículo | 00123=lote | 2=Estado Artículo | 220120=fecha vencimiento | 00006 = cantidad artículo | 0000000000022=peso entero(13) | 300000=peso decimal(6))       
        /// </summary>
        /// <value>01421001232220820000060000000000022300000</value>
        public string CodigoBarras { get; set; }

        /// <summary>
        /// Lote de la bodega
        /// </summary>
        /// <value>Lote de la bodega</value>        
        public string Lote { get; set; }

        /// <summary>
        /// Fecha de vencimiento de los artículos del contenedor
        /// </summary>
        public string FechaVencimiento { get; set; }

        /// <summary>
        /// Unidades del artículo del contenedor
        /// </summary>
        /// <value>Unidades del artículo del contenedor</value>      
        public int Unidades { get; set; }

        /// <summary>
        /// Peso del contenedor con los articulos
        /// </summary>
        /// <value>Peso del contenedor con los articulos</value>      
        public decimal Peso { get; set; }

        /// <summary>
        /// Indica si existe alguna inconsistencia entre pesaje de código de barras y báscula
        /// </summary>
        /// <value>Indica si existe alguna inconsistencia entre pesaje de código de barras y báscula</value>      
        public bool? InconsistenciaCodigoBarras { get; set; }


    }
}
