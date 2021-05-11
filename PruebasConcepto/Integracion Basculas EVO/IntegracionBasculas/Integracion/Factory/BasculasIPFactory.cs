using IntegracionBasculasPorcicarnes.Adapter;

namespace IntegracionBasculasPorcicarnes.Factory
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 28-Nov/2019
    /// Descripción      : Esta clase es la implementación del patrón de diseño fábrica, que permite generar instancias específicas de adaptadores de básculas.
    ///                    NOTA: Esta clase se construyó cómo un ejemplo, es posible que dentro de la marca Avery, existan múltiples tipos de báscula y se requieran clases por cada una.
    /// </summary>
    public abstract class BasculasIPFactory
    {
        /// <summary>
        /// Este método permite obtener el adaptador específico de una báscula.
        /// </summary>
        public abstract BasculasIPAdapter GetAdapter();
    }
}