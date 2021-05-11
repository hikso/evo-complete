using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOBoxSetting : NotifyPropertyChanged
    {
        /// <summary>
        /// Código punto de vent
        /// </summary>
        /// <value>Indica la fecha de apertura de caja</value>
        public string CodePointOfStore { get; set; }

        /// <summary>
        /// Indica la fecha de apertura de caja
        /// </summary>
        /// <value>Indica la fecha de apertura de caja</value>
        public string OpenDate { get; set; }

        /// <summary>
        /// Indica la fecha de cierre de caja
        /// </summary>
        /// <value>Indica la fecha de cierre de caja</value>
        public string CloseDate { get; set; }

        /// <summary>
        /// Indica el valor asignado a la caja
        /// </summary>
        /// <value>Indica el valor asignado a la caja</value>
        public decimal AsignedValue { get; set; }

        /// <summary>
        /// Indica el valor real ingresado por el usuario
        /// </summary>
        /// <value>Indica el valor asignado a la caja</value>
        public decimal RealValue { get; set; }

        /// <summary>
        /// Indica el valor en diferencia en la caja
        /// </summary>
        /// <value>Indica el valor asignado a la caja</value>
        public decimal difference;
        public decimal Difference
        {
            get
            {
                return this.difference;
            }
            set
            {
                this.difference = value;
                this.OnPropertyChanged("Difference");
            }
        }
    }
}
