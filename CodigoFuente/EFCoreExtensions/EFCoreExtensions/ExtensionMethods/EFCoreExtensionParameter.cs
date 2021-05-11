using System.Data;

namespace EFCoreExtensions.ExtensionMethods
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 31-Jul/2019
    /// Descripción      : Esta clase representa una abstracción de un DbParameter
    /// </summary>
    public class EFCoreExtensionParameter
    {
        /// <summary>
        /// Nombre del parámetro
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        /// Tipo de dato del parámetro
        /// </summary>
        public DbType DbType { get; set; }

        /// <summary>
        /// Valor del parámetro
        /// </summary>
        public object Value { get; set; }
    }
}