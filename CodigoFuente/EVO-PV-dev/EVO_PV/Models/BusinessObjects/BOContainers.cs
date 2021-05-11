using EVO_PV.Utilities;

namespace EVO_PV.Models.BusinessObjects
{
    /*
     * Author: 
     * Date:
     * Description:
     */
    public class BOContainers : NotifyPropertyChanged
    {

        /// <summary>
        /// Identificador del contenedor
        /// </summary>
        /// <value>NameArticle</value>      
        public int ContainerId { get; set; }


        /// <summary>
        /// El contenedor tiene código de barras
        /// </summary>
        /// <value>NameArticle</value>      
        public bool ContainerHasBarCode { get; set; }

        /// <summary>
        /// Nombre del contenedor
        /// </summary>
        /// <value>CodeArticle</value>      
        public string ContainerName { get; set; }

        /// <summary>
        /// Nombre del contenedor
        /// </summary>
        /// <value>CodeArticle</value>      

        public string ContainerLabel
        {
            get
            {
                return $"{ContainerName}  (Peso {ContainerWeight} KG/Ud)";
            }
        }

        /// <summary>
        /// Peso del contenedor
        /// </summary>
        /// <value>NameArticle</value>      
        public double ContainerWeight { get; set; }

        /// <summary>
        /// Peso del contenedor
        /// </summary>
        /// <value>NameArticle</value>      
        public int containerQuantity { get; set; }
        public int ContainerQuantity
        {
            get { return containerQuantity; }

            set
            {
                this.containerQuantity = value;
                this.OnPropertyChanged("ContainerQuantity");
            }
        }

    }
}
