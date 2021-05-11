namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 11-Abr/2020
    /// Descripción     : Clase que representa un objeto de tipo Parametrización
    /// </summary>
    public class BOParametrizacionResponse
    {
        /// <summary>
        /// Representa la tolerancia inferior en recepción
        /// </summary>
        /// <value>Representa la tolerancia inferior en recepción</value>       
        public decimal? RecepcionToleranciaInferior { get; set; }

        /// <summary>
        /// Representa la tolerancia superior en recepción
        /// </summary>
        /// <value>Representa la tolerancia superior en recepción</value>    
        public decimal? RecepcionToleranciaSuperior { get; set; }

        /// <summary>
        /// Representa si se hace pesaje por código de barras
        /// </summary>
        /// <value>Representa si se hace pesaje por código de barras</value>     
        public bool? RecepcionPesajeCodigoBarras { get; set; }

        /// <summary>
        /// Define el porcentaje de descuento para facturación
        /// </summary>
        /// <value>50</value>     
        public decimal? FacturacionPorcentajeDescuento { get; set; }
    }
}
