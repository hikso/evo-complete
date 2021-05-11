using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EVO_PV_BusinessObjects
{
    /// <summary>
    /// Indica la unidad de medida del artículo
    /// </summary>
    [DataContract]
    public partial class UnidadMedida
    {
        /// <summary>
        /// Id del Artículo
        /// </summary>
        /// <value>Id del Artículo</value>
        [Required]
        [DataMember(Name = "UnidadMedidaId")]
        public int UnidadMedidaId { get; set; }

        /// <summary>
        /// Unidad del Artículo
        /// </summary>
        /// <value>Unidad del Artículo</value>
        [Required]
        [DataMember(Name = "Nombre")]
        public string Nombre { get; set; }

        /// <summary>
        /// Código del Artículo
        /// </summary>
        /// <value>Código del Artículo</value>
        [Required]
        [DataMember(Name = "Codigo")]
        public string Codigo { get; set; }


    }
}
