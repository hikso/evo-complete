using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace EVO_PV_Proxy.Models.PedidoAPI
{ 
    /// <summary>
    /// Artículo encontrado
    /// </summary>
    [DataContract]
    public partial class SerieResponse 
    { 
        /// <summary>
        /// Codigo de la serie
        /// </summary>
        /// <value>Codigo de la serie</value>
        [DataMember(Name="Series")]
        public string Series { get; set; }

       
    }
}
