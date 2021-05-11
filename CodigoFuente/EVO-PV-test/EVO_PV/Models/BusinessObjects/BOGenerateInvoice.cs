using System;
using System.Collections.Generic;
using System.Text;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOGenerateInvoice
    {
        /// <summary>
        /// Indica el código del punto de venta
        /// </summary>
        /// <value>Indica el código del punto de venta</value>
        //Required
        public string SalePointId { get; set; }

        /// <summary>
        /// Indica el id del vendedor
        /// </summary>
        /// <value>Indica el id del vendedor</value>
        //Required
        public int SellerId { get; set; }

        /// <summary>
        /// Indica la identificación del socio de negocio(cliente de la factura)
        /// </summary>
        /// <value>Indica la identificación del socio de negocio(cliente de la factura)</value>
        //Required
        public string ClientId { get; set; }

        /// <summary>
        /// Indica el id del tipo de báscula
        /// </summary>
        /// <value>Indica el id del tipo de báscula</value>
        //Required
        public int TypeBasculeId { get; set; }

        /// <summary>
        /// Indica las observaciones de la factura(Opcional)
        /// </summary>
        /// <value>Indica las observaciones de la factura(Opcional)</value>
        public string Observations { get; set; }

        /// <summary>
        /// Indica la sumatoria de los totales por artículo
        /// </summary>
        /// <value>Indica la sumatoria de los totales por artículo</value>
        //Required
        public float TotalBeforeDiscount { get; set; }

        /// <summary>
        /// Indica el porcentaje de descuento(Opcional)
        /// </summary>
        /// <value>Indica el porcentaje de descuento(Opcional)</value>
        public decimal? DiscountPercent { get; set; }

        /// <summary>
        /// Indica el total de descuento(Opcional)
        /// </summary>
        /// <value>12345</value>
        public int? TotalWithDiscount { get; set; }

        /// <summary>
        /// Indica la cantidad de bolsas
        /// </summary>
        /// <value>Indica la cantidad de bolsas</value>
        public int BagsQuantity { get; set; }

        /// <summary>
        ///  Indica el porcentaje de cobro del valor de la bolsa(Opcional)
        /// </summary>
        /// <value>40</value>
        public int? BagPlasticPercent { get; set; }

        /// <summary>
        /// Indica el valor de la bolsa(Opcional)
        /// </summary>
        /// <value>40</value>
        public int? BagValue { get; set; }

        /// <summary>
        /// Indica el valor del impuesto de bolsas(Opcional)
        /// </summary>
        /// <value>40</value>
        public int? BagsTax { get; set; }

        /// <summary>
        /// Indica el valor de los impuestos de la factura
        /// </summary>
        /// <value>75000</value>
        //Required
        public int TaxValue { get; set; }

        /// <summary>
        /// Indica el total de la factura
        /// </summary>
        /// <value>Indica el total de la factura</value>
        //Required
        public float TotalDocument { get; set; }

        /// <summary>
        /// Gets or Sets Articulos
        /// </summary>
        //Required
        public List<BOBillingArticle> Articles { get; set; }

        /// <summary>
        /// Gets or Sets FormasPago
        /// </summary>
        public List<BOPaymentWayStructure> PaymentWays { get; set; }
    }
}
