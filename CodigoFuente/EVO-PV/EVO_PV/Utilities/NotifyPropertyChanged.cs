using EVO_PV.Utilities;
using System.ComponentModel;

namespace EVO_PV.Utilities
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 15-Ene/2019
    /// Descripción      : Esta clase implementa la interface INotifyPropertyChanged
    /// </summary>
    public class NotifyPropertyChanged : Mapper, INotifyPropertyChanged
    {
        #region Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Método que notifica bidireccionalmente el cambio de propiedades entre el formulario y el viewmodel
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad</param>
        protected void OnPropertyChanged(string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
