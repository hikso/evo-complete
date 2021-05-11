using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
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
    /// Fecha de Creación: 20-Mar/2020
    /// Descripción      : Implementa el acceso a datos del proceso de recepción
    /// </summary>
    public class DARecepcion : DABase
    {

        /// <summary>
        /// Confirma que se recibió la mercancia
        /// </summary>
        /// <param name="pesajeEntregaId">Indica el id del pesaje entrega</param>
        /// <param name="documentosRecepcion">Indica que documentos se generan </param>       
        /// <response >bool</response>
        public bool AsignarConfirmacion(int pesajeEntregaId, List<BODocumentoRecepcionArticulo> documentosRecepcion,int usuarioId)
        {
            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        EFPesajeEntrega eFPesajeEntrega = contexto.PesajesEntrega.Include(i => i.PesajesArticulo)
                                               .FirstOrDefault(pe => pe.PesajeEntregaId == pesajeEntregaId);

                        foreach (BODocumentoRecepcionArticulo documentoRecepcion in documentosRecepcion)
                        {
                            EFPesajeArticulo eFPesajeArticulo = eFPesajeEntrega.PesajesArticulo.FirstOrDefault(pa => pa.DetalleEntregaId == documentoRecepcion.DetalleEntregaId);

                            if (eFPesajeArticulo != null)
                            {
                                eFPesajeArticulo.DocumentoId = documentoRecepcion.DocumentoId.Value;                               
                                contexto.Update(eFPesajeArticulo);                              
                            }
                            else
                            {

                                eFPesajeArticulo = new EFPesajeArticulo()
                                {
                                     PesajeEntregaId  = pesajeEntregaId,
                                     DetalleEntregaId = documentoRecepcion.DetalleEntregaId,
                                     UsuarioId = usuarioId,
                                     DocumentoId = documentoRecepcion.DocumentoId,
                                     CantidadRecibida=0
                                };

                                contexto.Add(eFPesajeArticulo);
                                
                            }

                            contexto.SaveChanges();

                        }

                        if (eFPesajeEntrega != null)
                        {
                            eFPesajeEntrega.Finalizado = true;

                            contexto.Update(eFPesajeEntrega);

                            respuesta = contexto.SaveChanges() > 0;
                        }

                        tran.Commit();

                        return respuesta;

                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }


            }


        }
    }
}
