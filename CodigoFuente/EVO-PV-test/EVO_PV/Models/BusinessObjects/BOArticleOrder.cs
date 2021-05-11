using EVO_PV.Enums;
using EVO_PV.Resources.Dictionaries;
using EVO_PV.Utilities;
using System.Windows.Markup;
using Notifications.Wpf;

namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 12-Ene/2019
    /// Descripción     : Clase que representa un artículo en una solicitud de pedido
    /// </summary>
    public class BOArticleOrder : NotifyPropertyChanged
    {
        private Notification notification;

        public BOArticleOrder()
        {
            this.notification = new Notification();
        }

        /// <summary>
        /// Stock mínimo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Minimum</value>     
        public int DetailId { get; set; }

        /// <summary>
        /// Codigo del artículo
        /// </summary>
        /// <value>CodeArticle</value>      
        public string CodeArticle { get; set; }

        /// <summary>
        /// Nombre de el artículo
        /// </summary>
        /// <value>NameArticle</value>      
        public string NameArticle { get; set; }

        /// <summary>
        /// Cantidad solicitada del artículo
        /// </summary>
        /// <value>56.000</value>       
        //public decimal? Quantity { get; set; }

        private decimal quantity { get; set; }
        public decimal Quantity
        {
            get { return quantity; }

            set
            {
                if (!Helpers.ValidateRegex(value.ToString(), EnumRegexs.ONLY_NUMBERT_WITH_DECIMALS))
                {
                    return;
                }

                if (this.MaxModification != 0 && value > MaxModification)
                {
                    this.notification.Show(DictMessages.Error, DictMessages.ErrorCantidadArticuloMaximoPermitido, NotificationType.Error);
                    return;
                }

                this.quantity = value;

                this.ErrorQuantity = string.Empty;
                this.OnPropertyChanged("Quantity");

            }
        }
        public decimal MaxModification { get; set; }
        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>1</value>      
        public int? stateArticleId { get; set; }

        public int? StateArticleId
        {
            get { return stateArticleId; }

            set
            {

                this.stateArticleId = value;

                this.ErrorStateArticleId = string.Empty;

                this.OnPropertyChanged("StateArticleId");

            }
        }

        /// <summary>
        /// Estado del artículo
        /// </summary>
        /// <value>1</value>      
        public int? packageId { get; set; }

        public int? PackageId
        {
            get { return packageId; }

            set
            {
                this.packageId = value;

                this.OnPropertyChanged("PackageId");
            }
        }
        /// <summary>
        /// Nombre de la unidad de medida
        /// </summary>
        /// <value>UnitMeasure</value>       
        public string UnitMeasure { get; set; }

        /// <summary>
        /// Pedido sugerido
        /// </summary>
        /// <value>SuggestedOrder</value>      
        public string SuggestedOrder { get; set; }

        /// <summary>
        /// Stock de el producto en bodega
        /// </summary>
        /// <value>Stock de el producto en bodega</value>      
        public string Stock { get; set; }

        /// <summary>
        /// Stock mínimo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Minimum</value>     
        public string Minimum { get; set; }

        /// <summary>
        /// Stock máximo que se debe tener de el producto en bodega
        /// </summary>
        /// <value>Maximum</value>      
        public string Maximum { get; set; }

        /// <summary>
        /// Observaciones para el artículo
        /// </summary>
        /// <value>Maximum</value>
        private string observations { get; set; }
        public string Observations
        {
            get { return observations; }
            set
            {
                if (value != null && value.Length>100)
                {
                    return;
                }
                this.observations = value;
                this.OnPropertyChanged("Observations");
            }
        }

        /// <summary>
        /// Observaciones para el artículo
        /// </summary>
        /// <value>Maximum</value>
        private bool isPopObservationOpen { get; set; }
        public bool IsPopObservationOpen
        {
            get { return isPopObservationOpen; }
            set
            {
                this.isPopObservationOpen = value;
                this.OnPropertyChanged("IsPopObservationOpen");
            }
        }

        /// <summary>
        /// Asigna color a la celda de estado del artículo
        /// </summary>
        /// <value>Red</value>      
        private string errorStateArticleId { get; set; }

        public string ErrorStateArticleId
        {
            get { return errorStateArticleId; }

            set
            {
                this.errorStateArticleId = value;

                this.OnPropertyChanged("ErrorStateArticleId");

            }
        }

        /// <summary>
        /// Asigna color a la celda de cántidad
        /// </summary>
        /// <value>Red</value>      
        private string errorQuantity { get; set; }

        public string ErrorQuantity
        {
            get { return errorQuantity; }

            set
            {
                this.errorQuantity = value;

                this.OnPropertyChanged("ErrorQuantity");

            }
        }

        private string errorNameArticle { get; set; }

        public string ErrorNameArticle
        {
            get { return errorNameArticle; }

            set
            {
                this.errorNameArticle = value;

                this.OnPropertyChanged("ErrorNameArticle");

            }
        }

        private string errorCodeArticle { get; set; }

        public string ErrorCodeArticle
        {
            get { return errorCodeArticle; }

            set
            {
                this.errorCodeArticle = value;

                this.OnPropertyChanged("ErrorCodeArticle");

            }
        }

        private string errorArticle { get; set; }

        public string ErrorArticle
        {
            get { return errorArticle; }

            set
            {
                this.errorArticle = value;

                this.OnPropertyChanged("ErrorArticle");

            }
        }


        //#region Implementación de INotifyPropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged;
        ///// <summary>
        ///// Método que notifica bidireccionalmente el cambio de propiedades entre el formulario y el viewmodel
        ///// </summary>
        ///// <param name="propertyName">Nombre de la propiedad</param>
        //protected void OnPropertyChanged(string propertyName = "")
        //{
        //    if (this.PropertyChanged != null)
        //    {
        //        this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        //#endregion


    }
}
