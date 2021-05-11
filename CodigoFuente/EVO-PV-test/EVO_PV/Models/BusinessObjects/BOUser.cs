using EVO_PV.Utilities;
using System.Collections.Generic;

namespace EVO_PV.Models.BusinessObjects
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 07-Ene/2020
    /// Descripción      : Esta clase representa un Registro de Usuario EVO
    /// </summary>
    public class BOUser : NotifyPropertyChanged
    {
        /// <summary>
        /// Id de el registro
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Usuario del Usuario
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Nombres de los cargos(roles) del usuario
        /// </summary>
        /// <value>Nombres de los cargos(roles) del usuario</value>
        private List<string> positions { get; set; }
        public List<string> Positions
        {
            get
            {
                return this.positions;
            }
            set
            {
                this.positions = value;
                this.OnPropertyChanged("Positions");
            }
        }
    }
}