using EVO_PV.Utilities;

namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Gabriel Alfonso
    /// Fecha de Creacón: 22-Abril/2020
    /// Descripción     : Clase que representa un objeto de negocio de artículo
    /// </summary>
    public class BOBillingArticle : NotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indica s iel artículo fue eliminado de la factura
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Stock { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string IVACode { get; set; }

        private float quantity { get; set; }
        /// <summary>
        ///  Cantidad del artículo
        /// </summary>
        public float Quantity 
        {
            get { return this.quantity; }
            set 
            {
                this.quantity = value;
                this.Total = this.Quantity * float.Parse(this.UnitPrice);
                
                this.TotalIVA = float.Parse(this.IVA) / 100 * this.Total;
                this.TotalPricePlusIVA = this.Total + this.totalIVA;
                this.OnPropertyChanged("Quantity");
            }
        }

        private float total { get; set; }
        /// <summary>
        ///  Cantidad del artículo
        /// </summary>
        public float Total
        {
            get { return this.total; }
            set
            {
                this.total = value;
                this.OnPropertyChanged("Total");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UnitMeasure { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Lote { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// Valor del iva en porcentaje para este articulo
        /// </summary>
        public string IVA { get; set; }

        /// <summary>
        /// Valor total del iva por articulo
        /// </summary>
        private float totalIVA { get; set; }
        public float TotalIVA
        {
            get { return this.totalIVA; }
            set
            {
                this.totalIVA = value;
                this.OnPropertyChanged("TotalIVA");
            }
        }

        /// <summary>
        /// Valor del iva mas el total
        /// </summary>
        private float totalPricePlusIVA { get; set; }
        public float TotalPricePlusIVA
        {
            get { return this.totalPricePlusIVA; }
            set
            {
                this.totalPricePlusIVA = value;
                this.OnPropertyChanged("TotalPricePlusIVA");
            }
        }
        /// <summary>
        /// retención
        /// </summary>
        public string WithholdingTax { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WarehouseCode { get; set; }

        /// <summary>
        /// Descuento para mayoristas
        /// </summary>
        public bool DiscountWholesalers { get; set; }

        /// <summary>
        /// CantidadMinimaDescuentoPorMayor
        /// </summary>
        public int MinQuantityDiscountWholesalers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PriceDiscountWholesalers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string[] IngredientsOutStock { get; set; }
    }
}
