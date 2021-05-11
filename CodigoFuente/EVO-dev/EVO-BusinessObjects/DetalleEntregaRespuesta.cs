using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 2-Mar/2020
    /// Descripción     : Clase que representa el cliente de la entrega en alistamiento
    /// </summary>
    public class DetalleEntregaRespuesta
    {
        /// <summary>
        /// Representa la tolerancia inferior del pesaje de un cliente
        /// </summary>
        /// <value>5678</value>       
        public decimal ToleranciaInferior { get; set; }

        /// <summary>
        /// Representa la tolerancia superiors del pesaje de un cliente
        /// </summary>
        /// <value>5678</value>       
        public decimal ToleranciaSuperior { get; set; }

        /// <summary>
        /// Representa el consecutivo del alistamiento
        /// </summary>
        /// <value>Representa el consecutivo del alistamiento</value>      
        public int? Consecutivo { get; set; }

        /// <summary>
        /// Representa la fecha del alistamiento
        /// </summary>
        /// <value>Representa la fecha del alistamiento</value>      
        public string Fecha { get; set; }

        /// <summary>
        /// Representa el muelle donde estará el vehiculo
        /// </summary>
        /// <value>Representa el muelle donde estará el vehiculo</value>      
        public string Muelle { get; set; }

        /// <summary>
        /// Representa el tipo de cliente
        /// </summary>
        /// <value>Representa el tipo de cliente</value>      
        public string TipoCliente { get; set; }

        /// <summary>
        /// Representa el nombre del cliente
        /// </summary>
        /// <value>Representa el nombre del cliente</value>     
        public string Cliente { get; set; }

        /// <summary>
        /// Representa la zona del cliente
        /// </summary>
        /// <value>Norte</value>     
        public string Zona { get; set; }

        public List<ArticuloPesajeRespuesta> ArticulosResponse { get; set; }
    }
}
