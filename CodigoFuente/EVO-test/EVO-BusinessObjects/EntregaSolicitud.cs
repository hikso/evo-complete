using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 6-Feb/2020
    /// Descripción     : Clase que representa un objeto de negocio de solicitud para actualizar una entrega
    /// </summary>
    public class EntregaSolicitud
    {
        /// <summary>
        /// Id del tipo de vehículo
        /// </summary>
        /// <value>4</value>      
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Id del motivo
        /// </summary>
        /// <value>Id del motivo</value>  
        public int MotivoID { get; set; }

        /// <summary>
        /// Id de la entrega
        /// </summary>
        /// <value>Id de la entrega</value>       
        public int EntregaId { get; set; }

        /// <summary>
        /// Fecha de entrega
        /// </summary>
        /// <value>Fecha de entrega</value>
       
        public string FechaEntrega { get; set; }
        ///TODO: corregir en el .yaml
        /// <summary>
        /// Hora entrega
        /// </summary>
        /// <value>Código del pedido</value>      
        public string HoraEntrega { get; set; }

        /// <summary>
        /// Fecha generada con FechaEntrega y HoraEntrega
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Lista artículos de la entrega a actualizar
        /// </summary>
        /// <value>Lista artículos de la entrega a actualizar</value>      
        public List<EntregaSolicitudArticulos> Articulos { get; set; }
    }
}
