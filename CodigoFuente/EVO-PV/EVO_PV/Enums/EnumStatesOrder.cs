namespace EVO_PV.Enum
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 23-Ene/2020
    /// Descripción     : Enumerado que representa los estados del pedido
    /// </summary>
    public enum EnumStatesOrder
    {
        Borrador,
        Abierto,      
        Aceptado_parcial,
        Aceptado,
        Distribución,
        Enrutamiento,
        Alistamiento,
        Facturacion,
        Cargue_de_vehiculo,
        En_Transito,
        Cancelado_por_el_cliente,
        Cancelado_por_la_planta,
        Cerrado
    }
}