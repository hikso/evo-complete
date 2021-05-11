using EVO_PV.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOInvoice : NotifyPropertyChanged
    {
        /// <summary>
        ///  Total de la factura sumatoria de los artículos sin descuento por parte de antioqueña
        /// </summary>
        private float totalBeforeDiscount { get; set; }
        public float TotalBeforeDiscount
        {
            get { return this.totalBeforeDiscount; }
            set
            {
                this.totalBeforeDiscount = value;
                this.OnPropertyChanged("TotalBeforeDiscount");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private decimal bagsQuantity { get; set; }
        public decimal BagsQuantity
        {
            get { return this.bagsQuantity; }
            set
            {
                this.bagsQuantity = value;
                this.BagsTotalValue = new BOBagTax().ValorBolsa * this.BagsQuantity;
                this.OnPropertyChanged("BagsQuantity");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private decimal bagsTotalValue { get; set; }
        public decimal BagsTotalValue
        {
            get { return this.bagsTotalValue; }
            set
            {
                this.bagsTotalValue = value;
                this.OnPropertyChanged("BagsTotalValue");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private float taxValue { get; set; }
        public float TaxValue
        {
            get { return this.taxValue; }
            set
            {
                this.taxValue = value;
                this.OnPropertyChanged("TaxValue");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private float totalInvoice { get; set; }
        public float TotalInvoice
        {
            get { return this.totalInvoice; }
            set
            {
                this.totalInvoice = value;
                this.OnPropertyChanged("TotalInvoice");
            }
        }
    }
}
