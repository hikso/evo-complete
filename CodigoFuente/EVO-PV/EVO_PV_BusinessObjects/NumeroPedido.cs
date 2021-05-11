using System.Runtime.Serialization;

namespace EVO_PV_BusinessObjects
{
    [DataContract]
    public class NumeroPedido
    {

        /// <summary>
        /// Solicitud de pedido De
        /// </summary>
        [DataMember(Name = "SolicitudDe")]
        public string SolicitudDe { get; set; }

        /// <summary>
        /// Solicitud de pedido Para
        /// </summary>
        [DataMember(Name = "SolicitudPara")]
        public string SolicitudPara { get; set; }

    }
}