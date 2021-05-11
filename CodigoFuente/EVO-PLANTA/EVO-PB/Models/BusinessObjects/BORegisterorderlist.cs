using System;

namespace EVO_PB.Models.BusinessObjects
{
    public class BORegisterorderlist
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
        public string CodeOrder { get; set; }

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
        /// Días para la entrega del pedido
        /// </summary>
        /// <value>Días para la entrega del pedido</value>
        public string DaysDelivery { get; set; }

        public Boolean BtnEye { get; set; } = false;

        public Boolean BtnDuplicate { get; set; } = true;

    }
}
