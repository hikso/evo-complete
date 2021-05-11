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
        Aceptado_Parcial,
        Aceptado,
        Programado,
        Enrutamiento,
        Alistamiento,
        Facturacion,
        Cargue_de_Vehiculo,
        En_Tránsito,
        Cancelado_por_el_cliente,
        Cancelado_por_la_planta,
        Cerrado
    }
}