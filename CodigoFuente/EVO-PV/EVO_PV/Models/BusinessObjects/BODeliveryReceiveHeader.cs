using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BODeliveryReceiveHeader : NotifyPropertyChanged
    {

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        /// <value>Nombre del cliente</value>
        public string ClientName { get; set; }

        /// <summary>
        /// Consecutivo del pesaje por entrega
        /// </summary>
        /// <value>Consecutivo del pesaje por entrega</value>
        public int Consecutive { get; set; }

        /// <summary>
        /// Fecha entrega
        /// </summary>
        /// <value>Fecha entrega</value>
        public string DeliveryDate { get; set; }

        /// <summary>
        /// Fecha actual
        /// </summary>
        /// <value>Fecha actual</value>
        public string CurrentDate { get; set; }


        /// <summary>
        /// Id de entrega pesaje
        /// </summary>
        /// <value>Id de entrega</value>
        public string DeliveryReceiveId { get; set; }

        /// <summary>
        /// Indica si la entrega está finalizada
        /// </summary>
        /// <value>Id de entrega</value>
        public bool IsFinalized { get; set; }



        public List<BOInconsistenceFile> Documents { get; set; }

    }
}
