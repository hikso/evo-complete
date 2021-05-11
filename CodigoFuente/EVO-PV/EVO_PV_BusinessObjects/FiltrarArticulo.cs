using System.Runtime.Serialization;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Objeto que contiene los filtros de los Artículos
    /// </summary>
    [DataContract]
    public partial class FiltrarArticulo
    {
        /// <summary>
        /// Indica el número de registro desde el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro desde el cuál se deben obtener los registros</value>
        [DataMember(Name = "desde")]
        public int Desde { get; set; }

        /// <summary>
        /// Indica el número de registro hasta el cuál se deben obtener los registros
        /// </summary>
        /// <value>Indica el número de registro hasta el cuál se deben obtener los registros</value>
        [DataMember(Name = "hasta")]
        public int Hasta { get; set; }


    }
}
