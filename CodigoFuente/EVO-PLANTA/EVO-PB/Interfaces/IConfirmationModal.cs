using EVO_PB.Enums;

namespace EVO_PB.Interfaces
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 15-Ene/2019
    /// Descripción      : Esta interface define el contrato para generar confirmaciones entre view models padre e hijo.
    /// </summary>
    public interface IConfirmationModal
    {
       void ExecuteConfirmationYes();
       void ExecuteConfirmationNot();
       string IconName { get; }
       string MessageConfirmation { get; }
       EnumNamesMethods EnumNameMethodYes  { get; }
       EnumNamesMethods EnumNameMethodNot { get; }
       string Foreground { get; }
    }
}
