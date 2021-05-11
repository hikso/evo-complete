
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Bodega
    { 
        /// <summary>
        /// Código bodega
        /// </summary>
        /// <value>Código bodega</value>
        [Required]
        [DataMember(Name="WhsCode")]
        public string WhsCode { get; set; }

        /// <summary>
        /// Nombre bodega
        /// </summary>
        /// <value>Nombre bodega</value>
        [Required]
        [DataMember(Name="WhsName")]
        public string WhsName { get; set; }

        /// <summary>
        /// email bodega
        /// </summary>
        /// <value>email bodega</value>
        [Required]
        [DataMember(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Define el porcentaje de descuento para facturación
        /// </summary>
        /// <value>50</value>
        [Required]
        [DataMember(Name = "facturacionPorcentajeDescuento")]
        public decimal? FacturacionPorcentajeDescuento { get; set; }

    }
}
