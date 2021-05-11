using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 28-Abr/2020
    /// Descripción      : Se crea la clase de acceso a datos de Vendedores
    /// </summary>
    public class DAVendedores :DABase
    {

        /// <summary>
        /// Obtiene los vendedores por punto de venta
        /// </summary>
        /// <response>List<BOVendedorResponse></response>
        public List<BOVendedorResponse> ObtenerVendedoresxPuntoVenta(string codigoPuntoVenta)
        {
            List<BOVendedorResponse> bOVendedoresResponse = null;
            List<EFVendedor> eFVendedores = null;

            using (Contexto contexto=new Contexto())
            {
                eFVendedores = contexto.VendedoresPuntoVenta
                    .Include(i => i.Vendedor)
                    .Where(vpv => vpv.CodigoPuntoVenta == codigoPuntoVenta && vpv.Vendedor.Activo)
                    .ToList().Select(v=>new EFVendedor() {
                        VendedorId= v.Vendedor.VendedorId,
                        Nombres= v.Vendedor.Nombres,
                        Apellidos= v.Vendedor.Apellidos })
                    .ToList();
            }

            if (eFVendedores!=null)
            {
                bOVendedoresResponse = this.mapper.Map<List<EFVendedor>, List<BOVendedorResponse>>(eFVendedores);
            }

            return bOVendedoresResponse;
        }

        /// <summary>
        /// Obtiene vendedor por id
        /// </summary>    
        /// <param name="id">Indica el id del vendedor</param>
        /// <response>BOVendedorResponse</response>
        public BOVendedorResponse ObtenerVendedor(int id)
        {
            BOVendedorResponse bOVendedorResponse = null;
            EFVendedor eFVendedor = null;

            using (Contexto contexto=new Contexto())
            {
                eFVendedor = contexto.Vendedores.FirstOrDefault(v => v.VendedorId == id);
            }

            if (eFVendedor!=null)
            {
                bOVendedorResponse = this.mapper.Map<EFVendedor, BOVendedorResponse>(eFVendedor);
            }

            return bOVendedorResponse;
        }
    }
}
