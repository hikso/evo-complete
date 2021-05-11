using System;
using System.Collections.Generic;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Microsoft.Extensions.Logging;
using NLog;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga
    /// Fecha de Creación: 24-Oct/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de los clientes externos
    /// </summary>
    public class BLClienteExterno
    {

        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Crea un pedido
        /// </summary>
        /// <param name="pedido">Registro de pedido de tipo Pedido</param>
        /// <returns>Verdadero si se pudo persistir el pedido</returns>
        public List<ClienteExterno> ObtenerTodosClientesExternos()
        {
            logger.Info("Entró al método ObtenerTodosClientesExternos");

            DAClienteExterno dAClientesExternos = new DAClienteExterno();

            List<ClienteExterno> clientesExternos = new List<ClienteExterno>();

            try
            {
                clientesExternos = dAClientesExternos.ObtenerTodosClientesExternos();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return clientesExternos;
        }

        /// <summary>
        /// Obtiene un cliente externo por código
        /// </summary>
        /// <param name="codigo">C-1017149286</param>
        /// <returns>Objeto de negoio de tipo cliente externo</returns>
        public ClienteExterno ObtenerTodosClienteExternoxCodigo(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                EVOException e = new EVOException(errores.errCodigoClienteNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerTodosClienteExternoxCodigo en blClientesExternoss con el parámetro = {codigo}");

            DAClienteExterno dAClientesExternos = new DAClienteExterno();

            ClienteExterno clienteExterno = new ClienteExterno();

            try
            {
                clienteExterno = dAClientesExternos.ObtenerTodosClienteExternoxCodigo(codigo);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return clienteExterno;
        }
        #endregion
    }
}
