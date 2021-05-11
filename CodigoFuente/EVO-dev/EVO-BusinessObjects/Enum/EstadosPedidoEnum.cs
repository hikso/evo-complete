namespace EVO_PV_BusinessObjects.Enum
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 12-Mar/2020
    /// Descripción     : Clase que representa un enumerador de Estados de pedido
    /// </summary>
    public enum EstadosPedidoEnum
    {
        Borrador,
        Abierto,      
        Aprobación_Parcial,
        Aprobación_Completa,
        Programado,
        En_Ruta,
        Recibido_Diferida,       
        Cerrado,
        Cancelado,
        Gestión_Traslado,
        Gestión_de_Compra
    }
}