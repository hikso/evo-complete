using Notifications.Wpf;

namespace EVO_PB.Utilities
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 11-Dic/2019
    /// Descripción      : Esta clase implementa la utilidad para notificar mensajes al usuario desde la interfaz
    /// </summary>
    public class Notification
    {
        #region Atributos 
        private NotificationManager notificationManager { get; set; } 

        #endregion

        #region Contructores
        public Notification()
        {
            notificationManager = new NotificationManager();
        }
        #endregion

        #region Métodos Públicos
        public void Show(string title, string message, NotificationType type)
        {
            notificationManager.Show(
                new NotificationContent { Title = title, Message = message, Type = type },
                areaName: "WindowArea");
        } 
        #endregion

    }
}
