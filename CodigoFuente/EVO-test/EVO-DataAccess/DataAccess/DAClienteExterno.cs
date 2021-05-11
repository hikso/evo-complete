using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga
    /// Fecha de Creación: 24-Oct/2019
    /// Descripción      : Esta clase implementa los métodos de acceso a datos de los Clientes externos
    /// </summary>
    public class DAClienteExterno : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método obtiene todos los clientes externos
        /// </summary>
        /// <returns>Lista de Clientes Externos</returns>
        public List<ClienteExterno> ObtenerTodosClientesExternos()
        {
            List<EFClienteExterno> eFClientesExternos = null;

            using (Contexto contexto = new Contexto())
            {
                eFClientesExternos = contexto.ClientesExternos.ToList();
            }

            List<ClienteExterno> clientesExternos = null;

            if (eFClientesExternos.Count > 0) 
            {
                clientesExternos = this.mapper.Map<List<EFClienteExterno>, List<ClienteExterno>>(eFClientesExternos);
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
            EFClienteExterno eFClienteExterno = null;

            using (Contexto contexto = new Contexto())
            {
                eFClienteExterno = contexto.ClientesExternos.FirstOrDefault(ce=>ce.CodigoCliente==codigo);
            }

            ClienteExterno clienteExterno = null;

            if (eFClienteExterno != null)
            {
                clienteExterno = this.mapper.Map<EFClienteExterno,ClienteExterno>(eFClienteExterno);
            }

            return clienteExterno;
        }
        #endregion
    }
}