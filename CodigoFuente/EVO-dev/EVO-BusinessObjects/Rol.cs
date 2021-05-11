using System.Collections.Generic;

namespace EVO_BusinessObjects
{
    /// <summary>
    /// Autor            : Kevin Restrepo
    /// Fecha de Creación: 06-Ago/2019
    /// Descripción      : Esta clase representa un Rol de usuario
    /// </summary>
    public class Rol
    {
        /// <summary>   
        /// Id del Rol
        /// </summary>
        public int RolId { get; set; }

        /// <summary>
        /// Nombre del Rol
        /// </summary>
        public string Nombre { get; set; }       

        /// <summary>
        /// Lista de usuarios asignados al Rol
        /// </summary>
        public List<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Indica si el rol tiene acceso a el modulo de Planta de Beneficio
        /// </summary>
        public bool PlantaBeneficio { get; set; }

        /// <summary>
        /// Indica si el rol tiene acceso a el modulo de Planta de Derivados Carnicos
        /// </summary>
        public bool PlantaDerivadosCarnicos { get; set; }

        /// <summary>
        /// Indica si el rol tiene acceso a el modulo de Puntos de Venta
        /// </summary>
        public bool PuntosVenta { get; set; }

        /// <summary>
        /// Indica si el rol tiene acceso a el modulo de Administracion
        /// </summary>
        public bool Administracion { get; set; }
        
        /// <summary>
        /// Lista de funcionalidades autoirzadas para el rol
        /// </summary>
        public List<Funcionalidad> Funcionalidades { get; set; }

        /// <summary>
        /// Define si el registro se encuentra activo o inactivo
        /// </summary>
        public bool Activo { get; set; }
    }
}