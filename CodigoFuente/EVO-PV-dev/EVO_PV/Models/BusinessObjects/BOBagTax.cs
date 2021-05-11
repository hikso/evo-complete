using EVO_PV.Enums;
using EVO_PV.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOBagTax : NotifyPropertyChanged
    {

        public BOBagTax()
        {
            this.BagValue = decimal.Parse(App.Current.Properties[EnumConstanst.BAGVALUE.ToString()].ToString());
            this.BagPlasticPercent = decimal.Parse(App.Current.Properties[EnumConstanst.BagPlasticPercent.ToString()].ToString());
            this.ValorBolsa = (BagPlasticPercent / 100) * BagValue;

        }

        /// <summary>
        ///  Cantidad del artículo
        /// </summary>
        private decimal valorBolsa { get; set; }
        public decimal ValorBolsa
        {
            get { return this.valorBolsa; }
            set
            {
                this.valorBolsa = value;
                this.OnPropertyChanged("ValorBolsa");
            }
        }

        /// <summary>
        ///  Cantidad del artículo
        /// </summary>
        private decimal bagValue { get; set; }
        public decimal BagValue
        {
            get { return this.bagValue; }
            set
            {
                this.bagValue = value;
                this.OnPropertyChanged("BagValue");
            }
        }

        /// <summary>
        ///  Cantidad del artículo
        /// </summary>
        private decimal bagPlasticPercent { get; set; }
        public decimal BagPlasticPercent
        {
            get { return this.bagPlasticPercent; }
            set
            {
                this.bagPlasticPercent = value;
                this.OnPropertyChanged("BagPlasticPercent");
            }
        }
    }
}
