using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BODelivery : NotifyPropertyChanged
    {
        /// <summary>
        /// Codigo de la entrega
        /// </summary>
        /// <value>PT-1485</value>     
        //private int entregaId { get; set; }

        public int DeliveryId { get; set; }
        ////{
        //{
        //    get { return entregaId; }
        //    set { entregaId = value; }
        //}

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string numeroEntrega { get; set; }

        public string DeliveryNumber { get; set; }
        //{
        //{
        //    get { return numeroEntrega; }
        //    set { numeroEntrega = value; }
        //}

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string consecutivo { get; set; }

        public string Consecutive { get; set; }
        ////{
        //{
        //    get { return consecutivo; }
        //    set { consecutivo = value; }
        //}

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string fecha { get; set; }

        public string DateDelivery { get; set; }
        //{
        //{
        //    get { return fecha; }
        //    set { fecha = value; }
        //}

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string muelle { get; set; }

        public string Dock { get; set; }
        //{
        //{
        //    get { return muelle; }
        //    set { muelle = value; }
        //}

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string tipoCliente { get; set; }

        public string TypeClient { get; set; }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string tipoCliente { get; set; }

        public string FinalizedDate { get; set; }


        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string tipoCliente { get; set; }

        public bool IsFinalized { get; set; }

        /// <summary>
        /// PArametro para saber si puede ser recibido
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string tipoCliente { get; set; }
        public bool CanBeReceive { get; set; }

        //{
        //{
        //    get { return tipoCliente; }
        //    set { tipoCliente = value; }
        //}

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        //private string cliente { get; set; }

        public string Client { get; set; }
        //{
        //{
        //    get { return cliente; }
        //    set { cliente = value; }
        //}

        //private List<BOArticuloAlistamiento> articuloAlistamiento { get; set; }

        public List<BOEnlistmentArticles> EnlistmentArticles { get; set; }
        //{
        //    get { return articuloAlistamiento; }
        //    set { articuloAlistamiento = value; }
        //}

    }
}
