using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 15-Abr/2020
    /// Descripción      : Implementa el acceso a datos del proceso de SocioNegocio
    /// </summary>
    public class DASocioNegocio:DABase
    {
        /// <summary>
        /// Obtiene los socios de negocio 
        /// </summary>      
        /// <response>List<BOSocioNegocioResponse></response>
        public List<BOSocioNegocioResponse> ObtenerSociosNegocio()
        {
            List<BOSocioNegocioResponse> bOSociosNegocioResponse = null;            

            using (var contexto = new Contexto())
            { 
                bOSociosNegocioResponse = contexto.LoadSPAutoMapper<BOSocioNegocioResponse>("ObtenerSociosNegocio");               
            }

            if (bOSociosNegocioResponse == null)
            {
                bOSociosNegocioResponse = new List<BOSocioNegocioResponse>();
            }

            return bOSociosNegocioResponse;
        }

        /// <summary>
        /// Obtiene los socios de negocio por identificacion o nombre
        /// </summary>
        /// <param name="identificacion">Indica la identificación</param>
        /// <param name="nombre">Indica el nombre</param>
        /// <response>List<BOSocioNegocioResponse></response>
        public List<BOSocioNegocioResponse> ObtenerSociosNegocioxFiltro(string identificacion, string nombre)
        {
            // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
            List<EFCoreExtensionParameter> parameters = new List<EFCoreExtensionParameter>();

            if (!string.IsNullOrWhiteSpace(identificacion))
            {
                parameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@identificacion",
                    Value = identificacion
                });
            }

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                parameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@nombre",
                    Value = nombre
                });
            }

            List<BOSocioNegocioResponse> bOSociosNegocioResponse = null;

            using (var contexto = new Contexto())
            {
                bOSociosNegocioResponse = contexto.LoadSPAutoMapper<BOSocioNegocioResponse>("ObtenerSociosNegocioxFiltro", parameters);
            }

            if (bOSociosNegocioResponse == null)
            {
                bOSociosNegocioResponse = new List<BOSocioNegocioResponse>();
            }

            return bOSociosNegocioResponse;
        }

        /// <summary>
        /// Obtiene socio de negocio por identificación
        /// </summary>    
        /// <param name="identificacion">Indica la identificación</param>
        /// <response>BOSocioNegocio</response>
        public BOSocioNegocio ObtenerSocioNegocio(string identificacion)
        {
            EFSocioNegocio eFSocioNegocio = null;
            BOSocioNegocio bOSocioNegocio = null;

            using (var contexto = new Contexto())
            {
                eFSocioNegocio = contexto.SociosNegocio.FirstOrDefault(sn => sn.Identificacion == identificacion);
            }

            if (eFSocioNegocio != null)
            {
                bOSocioNegocio = this.mapper.Map<EFSocioNegocio,BOSocioNegocio>(eFSocioNegocio);
            }

            return bOSocioNegocio;
        }
    }
}
