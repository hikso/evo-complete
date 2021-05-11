namespace EVO_PV.Interfaces
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 15-Ene/2019
    /// Descripción      : Esta interface define el contrato para generar notificaciones entre view models padre e hijo.
    /// </summary>
    public interface INotificationVM
    {
        void NotificationVMFather();
        string FactoryCode { get; set; }
    }
}
