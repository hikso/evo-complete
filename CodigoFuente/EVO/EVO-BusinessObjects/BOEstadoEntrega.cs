namespace EVO_BusinessObjects
{
    public class BOEstadoEntrega
    {
        /// <summary>
        /// Define la clave primaria del estado del pedido
        /// </summary>
        public int EstadoEntregaId { get; set; }

        /// <summary>
        /// Define el nombre del estado de la entrega
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Define si el estado está activo
        /// </summary>
        public bool Activo { get; set; } = true;

    }
}
