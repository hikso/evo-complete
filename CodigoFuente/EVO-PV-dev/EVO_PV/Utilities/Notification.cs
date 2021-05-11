using Notifications.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using Notifications.Wpf.Controls;

namespace EVO_PV.Utilities
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
        public void Show(string title, string message, NotificationType type, double?timeSpan = null)
        {
            if (timeSpan == null)
            {
                notificationManager.Show(
                    new NotificationContent { Title = title, Message = message, Type = type },
                    areaName: "WindowArea");
            }
            else
            {
                notificationManager.Show(
                    new NotificationContent { Title = title, Message = message, Type = type },
                    areaName: "WindowArea", TimeSpan.FromDays(timeSpan.GetValueOrDefault(1)));
            }
        } 
        #endregion

    }
}
