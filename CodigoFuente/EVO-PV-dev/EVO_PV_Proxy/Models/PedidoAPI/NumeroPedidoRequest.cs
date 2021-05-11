using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;


namespace EVO_PV_Proxy.Models.PedidoAPI
{
    [DataContract]
    public class NumeroPedidoRequest
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