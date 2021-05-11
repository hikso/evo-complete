using IntegracionBasculasPorcicarnes.Adapter;

namespace IntegracionBasculasPorcicarnes.Factory
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 09-Dic/2019
    /// Descripción      : Esta clase es la implementación de una clase específica de una báscula IP; Avery ZM201.
    /// </summary>
    public class BasculasIPAveryZM201 : BasculasIPFactory
    {
        #region Campos Privados
        /// <summary>
        /// Adaptador específico de la marca Avery
        /// </summary>
        private BasculasIPAveryZM201Adapter _adapter;
        #endregion

        #region BasculasFactory
        /// <summary>
        /// Ese método permite obtener una instancia específica del adaptador Avery
        /// </summary>
        /// <returns>Adaptador Avery</returns>
        public override BasculasIPAdapter GetAdapter()
        {
            this._adapter = new BasculasIPAveryZM201Adapter();

            return this._adapter;
        }
        #endregion
    }
}