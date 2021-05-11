using EVO_PV.Utilities;

namespace EVO_PV.Models.BusinessObjects
{
    public class BORegisterOrderListDetails : NotifyPropertyChanged
    {
        /// <summary>
        /// Código del artículo
        /// </summary>
        /// <value>Código del artículo</value>
        public string CodeArticle { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Nombre del artículo</value>
        public string NameArticle { get; set; }

        /// <summary>
        /// Observación artículo
        /// </summary>
        /// <value>Observación artículo</value>
        public string Observation { get; set; }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Estado del artículo</value>
        public string StateArticle { get; set; }

        /// <summary>
        /// Cantidad del artículo solicitada
        /// </summary>
        /// <value>Cantidad del artículo solicitada</value>
        public string QuantityRequest { get; set; }

        /// <summary>
        /// Unidad de medida del artículo
        /// </summary>
        /// <value>Unidad de medida del artículo</value>
        public string UnitMeasure { get; set; }

        /// <summary>
        /// Cantidad aprobada por la planta
        /// </summary>
        /// <value>Cantidad aprobada por la planta</value>
        public string QuantityApprove { get; set; }

        /// <summary>
        /// Cantidad enviada por la planta
        /// </summary>
        /// <value>Cantidad enviada por la planta</value>
        public string QuantitySend { get; set; }

        /// <summary>
        /// Fecha cuando llego el artículo a la bodega que solicitó el pedido que fue aprobado
        /// </summary>
        /// <value>Fecha cuando llego el artículo a la bodega que solicitó el pedido que fue aprobado</value>
        public string DateDeliveries { get; set; }

        /// <summary>
        /// Costo de traslado por artículo
        /// </summary>
        /// <value>Costo de traslado por artículo</value>
        public string CostTransferred { get; set; }

        /// <summary>
        /// Costo de transporte por artículo
        /// </summary>
        /// <value>Costo de transporte por artículo</value>
        public string TransportationCost { get; set; }
        
        
        /// <summary>
        /// Costo de transporte por artículo
        /// </summary>
        /// <value>Costo de transporte por artículo</value>
        public string Package { get; set; }

        /// <summary>
        /// Observaciones para el artículo
        /// </summary>
        /// <value>Maximum</value>
        private bool isPopObservationOpen { get; set; }
        public bool IsPopObservationOpen
        {
            get { return isPopObservationOpen; }
            set
            {
                this.isPopObservationOpen = value;
                this.OnPropertyChanged("IsPopObservationOpen");
            }
        }
    }
}
