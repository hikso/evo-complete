using EFCoreExtensions.ExtensionMethods;
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
    /// Fecha de Creación: 26-Mar/2020
    /// Descripción      : Implementa el acceso a datos del proceso de Evidencia
    /// </summary>
    public class DAEvidencia : DABase
    {
        /// <summary>
        /// Registra la evidencia
        /// </summary>
        /// <param name="bOEvidenciaRequest">Indica el objeto de negocio que contiene las eviencias</param>      
        /// <response>bool</response>
        public bool AsignarEvidencia(BOEvidenciaRequest bOEvidenciaRequest)
        {
            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        EFEvidencia eFEvidencia = new EFEvidencia()
                        {
                            PesajeEntregaId = bOEvidenciaRequest.PesajeEntregaId,
                            UsuarioId = bOEvidenciaRequest.UsuarioId,
                            GUID = bOEvidenciaRequest.GUID,
                            Observaciones = bOEvidenciaRequest.Observaciones,
                            FechaEvidencia = bOEvidenciaRequest.FechaEvidencia
                        };

                        contexto.Add(eFEvidencia);

                        contexto.SaveChanges();

                        contexto.AddRange(bOEvidenciaRequest.Detalles.Select(d => new EFDetalleEvidencia()
                        {
                            EvidenciaId = eFEvidencia.EvidenciaId,
                            NombreArchivo = d.NombreArchivo,
                            ExtensionArchivo = d.ExtensionArchivo
                        }));

                        contexto.SaveChanges();

                        tran.Commit();

                    }
                    catch (Exception e)
                    {
                        tran.Rollback();

                        throw e;
                    }
                }

            }

            return respuesta;

        }

        /// <summary>
        /// Obtiene las evidencias
        /// </summary>
        /// <response>List<BOEvidenciaResponse></response>
        public List<BOEvidenciaResponse> ObtenerEvidencias()
        {
            using (var contexto = new Contexto())
            {
                List<BOEvidenciaResponse> bOEvidenciasResponses = contexto.LoadSPAutoMapper<BOEvidenciaResponse>("ObtenerTodosEvidencias");

                if (bOEvidenciasResponses == null)
                {
                    bOEvidenciasResponses = new List<BOEvidenciaResponse>();
                }

                return bOEvidenciasResponses;
            }
        }

        /// <summary>
        /// Obtiene la evidencia por evidenciaId
        /// </summary>
        /// <param name="evidenciaId">Indica de la evidencia</param>
        /// <response>BOEvidencia</response>
        public BOEvidencia ObtenerEvidencia(int evidenciaId)
        {
            BOEvidencia bOEvidencia = null;
            EFEvidencia eFEvidencia = null;

            using (Contexto contexto = new Contexto())
            {
                eFEvidencia = contexto.Evidencias
                    .Include(i => i.Usuario)
                    .Include(i => i.DetallesEvidencia)
                    .FirstOrDefault(e => e.EvidenciaId == evidenciaId);
            }

            if (eFEvidencia != null)
            {
                bOEvidencia = this.mapper.Map<EFEvidencia, BOEvidencia>(eFEvidencia);
            }

            return bOEvidencia;

        }

        /// <summary>
        /// Obtiene las evidencias filtradas
        /// </summary>
        /// <param name="fechaInicio">Indica la fecha de inicio de la evidencia(dd/mm/aaa)</param>
        /// <param name="fechaFin">Indica la fecha de fin de la evidencia(dd/mm/aaa)</param>
        /// <param name="puntoVenta">Indica el nombre del punto de venta</param>
        /// <response>List<BOEvidenciaResponse></response>
        public List<BOEvidenciaResponse> ObtenerEvidenciasxFiltro(string fechaInicio, string fechaFin, string puntoVenta)
        {
            // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
            List<EFCoreExtensionParameter> parameters = new List<EFCoreExtensionParameter>();

            if (!string.IsNullOrWhiteSpace(puntoVenta))
            {
                parameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@puntoVenta",
                    Value = puntoVenta
                });
            }

            parameters.Add(new EFCoreExtensionParameter()
            {
                ParameterName = "@fechaInicio",
                Value = fechaInicio
            });

            parameters.Add(new EFCoreExtensionParameter()
            {
                ParameterName = "@fechaFin",
                Value = fechaFin
            });

            using (var contexto = new Contexto())
            {
                List<BOEvidenciaResponse> bOEvidenciasResponses = contexto.LoadSPAutoMapper<BOEvidenciaResponse>("ObtenerTodosEvidenciasxFiltro", parameters);

                if (bOEvidenciasResponses == null)
                {
                    bOEvidenciasResponses = new List<BOEvidenciaResponse>();
                }

                return bOEvidenciasResponses;
            }
        }
    }
}
