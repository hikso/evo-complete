using EVO_PV.Utilities;

namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 23-Feb/2020
    /// Descripción     : Clase que representa un artículo de una entrega de un pedido
    /// </summary>
    public class BODeliveryArticle : NotifyPropertyChanged
    {
        /// <summary>
        /// Codigo del artículo
        /// </summary>
        /// <value>PT-1485</value>     
        private int deliveryDetailId { get; set; }

        public int DeliveryDetailId
        {
            get { return deliveryDetailId; }
            set { deliveryDetailId = value; }
        }

        /// <summary>
        /// Codigo del artículo
        /// </summary>
        /// <value>PT-1485</value>     
        private string codeArticle { get; set; }

        public string CodeArticle
        {
            get { return codeArticle; }
            set { codeArticle = value; }
        }

        /// <summary>
        /// Nombre del artículo
        /// </summary>
        /// <value>Cabeza de Cerdo</value>    
        private string nameArticle { get; set; }

        public string NameArticle
        {
            get { return nameArticle; }
            set { nameArticle = value; }
        }
        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>Congelado</value>    
        private string stateArticle { get; set; }
        public string StateArticle
        {
            get { return stateArticle; }
            set { stateArticle = value; }
        }
        /// <summary>
        /// Cantidad
        /// </summary>
        /// <value>340</value>    
        private string quantity { get; set; }
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        /// <summary>
        /// Cantidad pendiente
        /// </summary>
        /// <value>340</value> 
        private string quantityPending { get; set; }
        public string QuantityPending
        {
            get { return quantityPending; }
            set { quantityPending = value; }
        }
        /// <summary>
        /// Unidad de medida
        /// </summary>
        /// <value>340</value> 
        private string unitMeasure { get; set; }
        public string UnitMeasure
        {
            get { return unitMeasure; }
            set { unitMeasure = value; }
        }
        /// <summary>
        /// Error
        /// </summary>
        /// <value>#FFFFF</value> 
        private string error { get; set; }
        public string Error
        {
            get { return error; }
            set { error = value; }
        }

    }
}
