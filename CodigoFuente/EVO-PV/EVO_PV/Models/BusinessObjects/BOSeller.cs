using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    public class BOSeller : NotifyPropertyChanged
    {
        /// <summary>
        /// Id del vendedor
        /// </summary>
        /// <value>Id del vendedor</value>
        public int SellerId { get; set; }

        /// <summary>
        /// Nombres del vendedor
        /// </summary>
        /// <value>Nombres del vendedor</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Apellidos del vendedor
        /// </summary>
        /// <value>Apellidos del vendedor</value>
        public string LastName { get; set; }

        /// <summary>
        /// Nombre y Apellidos
        /// </summary>
        /// <value>Juan Camilo Usuga Sepúlveda</value>
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }          
        }

    }
}
