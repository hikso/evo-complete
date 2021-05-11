using EVO_PV.Utilities;
using System;

namespace EVO_PV.Models.BusinessObjects
{
    public class BORegisterorderlist : NotifyPropertyChanged
    {

        /// <summary>
        /// Id del pedido
        /// </summary>
        /// <value>Id del pedido</value>
        public int OrderId { get; set; }

        /// <summary>
        /// Código del pedido
        /// </summary>
        /// <value>Código del pedido</value>
        private string codeOrder { get; set; }
        public string CodeOrder
        {
            get { return this.codeOrder; }
            set
            {
                this.codeOrder = value;
                this.OnPropertyChanged("CodeOrder");
            }
        }

        /// <summary>
        /// Fecha en la que se registra el pedido
        /// </summary>
        /// <value>Fecha en la que se registra el pedido</value>
        public string DateRequest { get; set; }

        /// <summary>
        /// Fecha en que se entrega el pedido
        /// </summary>
        /// <value>Fecha en que se entrega el pedido</value>
        public string DateDelivery { get; set; }

        /// <summary>
        /// Estado el pedido
        /// </summary>
        /// <value>Estado el pedido</value>
        public string State { get; set; }

        /// <summary>
        /// Nombre de la planta
        /// </summary>
        /// <value>Nombre de la planta</value>
        public string Factory { get; set; }


        /// <summary>
        /// Quien recibe la solicitud
        /// </summary>
        /// <value>Quien recibe la solicitud</value>
        public string WhoIsFor { get; set; }

        /// <summary>
        /// Fecha limite de la solicitud
        /// </summary>
        /// <value>Fecha limite de la solicitud</value>
        public string DateLimit { get; set; }


        /// <summary>
        /// Duplicar pedido
        /// </summary>
        /// <value>True</value>
        public bool CanDuply { get; set; }

        /// <summary>
        /// Editar pedido
        /// </summary>
        /// <value>True</value>
        public bool CanEdit { get; set; }

        /// <summary>
        /// Días para la entrega del pedido
        /// </summary>
        /// <value>Días para la entrega del pedido</value>
        public string DaysDelivery { get; set; }

        public Boolean BtnEye { get; set; } = true;

        public Boolean BtnDuplicate { get; set; } = true;
        
        public Boolean BtnEdit { get; set; } = true;

    }
}
