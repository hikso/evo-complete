namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor           : Juan Camilo Usuga
    /// Fecha de Creacón: 24-May/2020
    /// Descripción     : Clase que representa un objeto de negocio de FormaPagoRequest
    /// </summary>
    public class FormaPagoRequestBO
    {
        /// <summary>
        /// Indica el id de la forma de pago
        /// </summary>
        /// <value>Indica el id de la forma de pago</value>
        public int FormaPagoId { get; set; }

        /// <summary>
        /// Indica el id del banco
        /// </summary>
        /// <value>Indica el id del banco</value>
       public int? BancoId { get; set; }

        /// <summary>
        /// Indica el valor del pago
        /// </summary>
        /// <value>Indica el valor del pago</value>
        public int ValorPago { get; set; }

        /// <summary>
        /// Indica el consecutivo del bono
        /// </summary>
        /// <value>Indica el consecutivo del bono</value>
        public string ConsecutivoBono { get; set; }

        /// <summary>
        /// Indica el nombre del empleado del bono(todo usuario EVO es empleado pero no todo empleado es usuario EVO)
        /// </summary>
        /// <value>Indica el nombre del empleado del bono(todo usuario EVO es empleado pero no todo empleado es usuario EVO)</value>
        public string EmpleadoBono { get; set; }
    }
}
