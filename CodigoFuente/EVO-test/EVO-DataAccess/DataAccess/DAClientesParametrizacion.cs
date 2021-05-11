using AutoMapper.Mappers;
using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 11-Abr/2020
    /// Descripción      : Implementa el acceso a datos del proceso de parametrización de clientes
    /// </summary>
    public class DAClientesParametrizacion:DABase
    {
        /// <summary>
        /// Obtiene las parametrizaciones del cliente
        /// </summary>
        /// <param name="codigoCliente">Indica el código del cliente</param>
        /// <response>BOParametrizacionResponse</response>
        public BOParametrizacionResponse ObtenerPatrametrizacionesxCliente(string codigoCliente)
        {
            BOParametrizacionResponse bOParametrizacionResponse = null;
            EFClienteParametrizacion eFClienteParametrizacion = null;

            using (Contexto contexto = new Contexto())
            {
                eFClienteParametrizacion = contexto.ClientesParametrizacion
                    .FirstOrDefault(cp => cp.CodigoCliente == codigoCliente);
            }

            if (eFClienteParametrizacion != null)
            {
                bOParametrizacionResponse = this.mapper.Map<EFClienteParametrizacion,BOParametrizacionResponse>(eFClienteParametrizacion);
            }

            return bOParametrizacionResponse;

        }
    }
}
