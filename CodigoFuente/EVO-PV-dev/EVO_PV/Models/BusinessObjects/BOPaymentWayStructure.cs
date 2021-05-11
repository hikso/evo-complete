using EVO_PV.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOPaymentWayStructure : NotifyPropertyChanged
    {
        /// <summary>
        /// Indica el id de la forma de pago
        /// </summary>
        /// <value>Indica el id de la forma de pago</value>
        //Required
        public int PaymentWayId { get; set; }

        /// <summary>
        /// Indica el id de la forma de pago
        /// </summary>
        /// <value>Indica el id de la forma de pago</value>
        //Required
        public string PaymentName { get; set; }
        private BOBank bankSelected { get; set; }

        public BOBank BankSelected
        {
            get { return this.bankSelected; }
            set
            {
                this.bankSelected = value;
                this.BankId = this.bankSelected.BankId;
                this.OnPropertyChanged("BankSelected");
            }
        }

        /// <summary>
        /// Indica el id del banco
        /// </summary>
        /// <value>Indica el id del banco</value>
        public int BankId { get; set; }

        /// <summary>
        /// Indica si la forma de pago tiene  banco
        /// </summary>
        /// <value>Indica si tiene baanco</value>
        public bool HasBank { get; set; }

        /// <summary>
        /// Indica el valor del pago
        /// </summary>
        /// <value>Indica el valor del pago</value>
        //Required
        public int PaymentValue { get; set; }

        /// <summary>
        /// Indica el consecutivo del bono
        /// </summary>
        /// <value>Indica el consecutivo del bono</value>
        public string ConsecutiveBond { get; set; }

        /// <summary>
        /// Indica si el pago tiene consecutivo de bono
        /// </summary>
        /// <value>Indica si el pago tiene consecutivo de bono</value>
        public bool HasConsecutiveBond { get; set; }

        /// <summary>
        /// Indica el nombre del empleado del bono(todo usuario EVO es empleado pero no todo empleado es usuario EVO)
        /// </summary>
        /// <value>Indica el nombre del empleado del bono(todo usuario EVO es empleado pero no todo empleado es usuario EVO)</value>
        public string EmployeeBond { get; set; }

    }
}
