using IntegracionBasculasPorcicarnes.Adapter;

namespace IntegracionBasculasPorcicarnes.Factory
{
    /// <summary>
    /// Autor            : Andrés Giraldo
    /// Fecha de Creación: 28-Nov/2019
    /// Descripción      : Esta clase es la implementación de una clase específica de una báscula serial; Avery E1010.
    /// </summary>
    public class BasculasSerialesAveryE1010 : BasculasSerialesFactory
    {        
        #region Campos Privados
        /// <summary>
        /// Adaptador específico de la marca Avery
        /// </summary>
        private BasculasSerialesAveryE1010Adapter _adapter;
        #endregion

        #region BasculasFactory
        /// <summary>
        /// Ese método permite obtener una instancia específica del adaptador Avery
        /// </summary>
        /// <returns>Adaptador Avery</returns>
        public override BasculasSerialesAdapter GetAdapter()
        {
            this._adapter = new BasculasSerialesAveryE1010Adapter();

            return this._adapter;          
        }
        #endregion
    }
}