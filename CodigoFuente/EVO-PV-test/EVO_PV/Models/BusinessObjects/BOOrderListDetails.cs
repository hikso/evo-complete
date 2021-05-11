using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOOrderListDetails : NotifyPropertyChanged
    {
        /// <summary>
        /// Número del pedido
        /// </summary>
        /// <value>Número del pedido</value>
        public string NumberOrderList { get; set; }

        /// <summary>
        /// Estado del pedido
        /// </summary>
        /// <value>Estado del pedido</value>
        public string State { get; set; }

        /// <summary>
        /// Fecha de la solicitud del pedido
        /// </summary>
        /// <value>Fecha de la solicitud del pedido</value>
        public string DateRequest { get; set; }

        /// <summary>
        /// Fecha cuando se envíó el pedido
        /// </summary>
        /// <value>Fecha cuando se envíó el pedido</value>
        private string dateSend { get; set; }
        public string DateSend
        {
            get { return dateSend; }
            set
            {
                this.dateSend = value;
                this.OnPropertyChanged("DateSend");
            }
        }
        /// <summary>
        /// Fecha cuando el pedido fué recibído en el punto de venta
        /// </summary>
        /// <value>Fecha cuando el pedido fué recibído en el punto de venta</value>
        public string DateReceipt { get; set; }

        /// <summary>
        /// Fecha de cargue en vehículo
        /// </summary>
        /// <value>Fecha de cargue en vehículo</value>
        public string DateCars { get; set; }

        /// <summary>
        /// Nombre del conductor del vehículo
        /// </summary>
        /// <value>Nombre del conductor del vehículo</value>
        public string NameConductive { get; set; }

        /// <summary>
        /// Placa del vehículo
        /// </summary>
        /// <value>Placa del vehículo</value>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Nombre del auxiliar
        /// </summary>
        /// <value>Nombre del auxiliar</value>
        public string NameAuxiliary { get; set; }

        /// <summary>
        /// Nombre de la planta
        /// </summary>
        /// <value>Nombre de la planta</value>
        public string Plant { get; set; }


        /// <summary>
        /// Nombre de la planta
        /// </summary>
        /// <value>Nombre de la planta</value>
        public string TypeOrder { get; set; }

        /// <summary>
        /// Nombre de la planta a la que se solicita
        /// </summary>
        /// <value>Nombre de la planta</value>
        public string DeliveryIsFor { get; set; }

        /// <summary>
        /// Cancelar pedido
        /// </summary>
        /// <value>true</value>
        public bool CancelOrder { get; set; }

        /// <summary>
        /// Lista de detalles del Pedido
        /// </summary>
        /// <value>Lista de detalles del Pedido</value>
        public List<BORegisterOrderListDetails> Registers { get; set; }

        /// <summary>
        /// Lista de acciones del Pedido tipo compra
        /// </summary>
        /// <value>Lista de detalles del Pedido</value>
        public List<BOPurchaceAction> Actions { get; set; }
    }
}
