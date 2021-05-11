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
    /// Fecha de Creación: 22-Mar/2020
    /// Descripción      : Se crea la clase de acceso a datos de Pesaje
    /// </summary>
    public class DAPesaje : DABase
    {
        /// <summary>
        /// Obtiene todos los pesajes de la entrega en un estado en concreto
        /// </summary>
        /// <param name="entregaId">Indica el id de la entrega</param>
        /// <param name="estadoEntregaId">Indica el id del estado de la entrega</param>
        /// <response>BOPesajeEntrega</response>
        public BOPesajeEntrega ObtenerPesajeEntrega(int entregaId, int estadoEntregaId)
        {
            BOPesajeEntrega bOPesajeEntrega = null;
            EFPesajeEntrega eFPesajeEntrega = null;

            using (Contexto contexto = new Contexto())
            {
                eFPesajeEntrega = contexto.PesajesEntrega
                    .Include("PesajesArticulo.Pesajes.PesajesCodigoBarras")
                    .Include("PesajesArticulo.Pesajes.PesajeContenedor")
                    .Include("PesajesArticulo.Documento")
                    .FirstOrDefault(pe => pe.EntregaId == entregaId && pe.EstadoEntregaId == estadoEntregaId);
            }

            if (eFPesajeEntrega != null)
            {
                bOPesajeEntrega = this.mapper.Map<EFPesajeEntrega,BOPesajeEntrega>(eFPesajeEntrega);
            }

            return bOPesajeEntrega;
        }

        /// <summary>
        /// Obtiene la entrega asociada al pesaje
        /// </summary>
        /// <param name="pesajeEntregaId">Indica el id de la entrega del pesaje</param>      
        /// <response>BOPesajeEntrega</response>
        public BOPesajeEntrega ObtenerPesajeEntrega(int pesajeEntregaId)
        {
            EFPesajeEntrega eFPesajeEntrega = null;
            BOPesajeEntrega bOPesajeEntrega = null;

            using (Contexto contexto = new Contexto())
            {
                eFPesajeEntrega = contexto.PesajesEntrega
                    .Include(i=>i.Entrega.Pedido)
                    .Include("PesajesArticulo.DetalleEntrega.DetallePedido")
                    .Include("PesajesArticulo.Documento")
                    .FirstOrDefault(pa => pa.PesajeEntregaId == pesajeEntregaId);
            }

            if (eFPesajeEntrega != null)
            {
                bOPesajeEntrega = this.mapper.Map<EFPesajeEntrega, BOPesajeEntrega>(eFPesajeEntrega);
            }

            return bOPesajeEntrega;

        }

        /// <summary>
        /// Obtiene el objeto a pesar
        /// </summary>
        /// <param name="pesajeArticuloId">Indica el id del artículo en pesaje</param>      
        /// <response>BOPesajeArticulo</response>
        public BOPesajeArticulo ObtenerPesajeArticulo(int pesajeArticuloId)
        {
            EFPesajeArticulo eFPesajeArticulo = null;
            BOPesajeArticulo bOPesajeArticulo = null;

            using (Contexto contexto=new Contexto())
            {
                eFPesajeArticulo = contexto.PesajesArticulo.Include(i=>i.Pesajes).FirstOrDefault(pa => pa.PesajeArticuloId == pesajeArticuloId);
            }

            if (eFPesajeArticulo!=null)
            {
                bOPesajeArticulo=this.mapper.Map<EFPesajeArticulo,BOPesajeArticulo>(eFPesajeArticulo);
            }

            return bOPesajeArticulo;

        }

        /// <summary>
        /// Registra un pesaje en recepción
        /// </summary>
        /// <param name="body">Solicitud para el registro del pesaje</param>
        /// <response>bool</response>
        public bool AsignarPesajeRecepcion(BOPesajeRequest bOPesajeRequest)
        {
            //EFPesaje eFPesaje = this.mapper.Map<BOPesajeRequest,EFPesaje>(bOPesajeRequest);
            //eFPesaje.PesajeContenedor = new List<EFPesajeContenedor>();

            EFPesaje eFPesaje = new EFPesaje()
            {
                PesajeArticuloId = bOPesajeRequest.PesajeArticuloId,
                UsuarioId = bOPesajeRequest.UsuarioId,
                TipoBasculaId = bOPesajeRequest.TipoBasculaId,
                PesoBascula = bOPesajeRequest.PesoBascula,
                PesoBasculaArticulos = bOPesajeRequest.PesoArticulo,
                FechaPesaje = bOPesajeRequest.FechaPesaje,
                PesajeAl= bOPesajeRequest.PesajeAl.ToString()
            };

            List<EFPesajeContenedor> eFPesajesContenedores =
                bOPesajeRequest.Contenedores.Select(c => new EFPesajeContenedor()
                {
                    TipoContenedorId = c.TipoContenedorId,
                    Cantidad = c.Cantidad
                }).ToList();

            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        contexto.Pesajes.Add(eFPesaje);

                        contexto.SaveChanges();

                        foreach (EFPesajeContenedor eFPesajeContenedor in eFPesajesContenedores)
                        {
                            eFPesajeContenedor.PesajeId = eFPesaje.PesajeId;
                        }

                        contexto.PesajesContenedor.AddRange(eFPesajesContenedores);

                        respuesta = contexto.SaveChanges() > 0;

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
        /// Obtiene el pesaje por id
        /// </summary>
        /// <param name="pesajeId">1</param>
        /// <response>BOPesaje</response>
        public BOPesaje ObtenerPesaje(int pesajeId)
        {
            BOPesaje bOPesaje = null;
            EFPesaje eFPesaje = null;

            using (Contexto contexto=new Contexto())
            {
                eFPesaje = contexto.Pesajes
                    .Include("PesajeArticulo.DetalleEntrega.DetallePedido.Pedido")
                    .Include(i=>i.PesajeContenedor)
                    .FirstOrDefault(p => p.PesajeId == pesajeId);
            }

            if (eFPesaje!=null)
            {
                bOPesaje = this.mapper.Map<EFPesaje, BOPesaje>(eFPesaje);
            }

            return bOPesaje;
        }

        /// <summary>
        /// Registra un pesaje entrega
        /// </summary>
        /// <param name="entregaId">Id de la entrega</param>
        /// <param name="estadoEntregaId">Id del estado de la entrega</param>
        /// <response>bool</response>
        public bool AsignarPesajeEntrega(int entregaId,int estadoEntregaId)
        {
            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                contexto.PesajesEntrega.Add(new EFPesajeEntrega()
                {
                    EntregaId = entregaId,
                    EstadoEntregaId = estadoEntregaId,
                    //FechaPesaje = DateTime.Now,
                    Consecutivo = contexto.PesajesEntrega.Count()+1
                });

                respuesta = contexto.SaveChanges() > 0;

            }

            return respuesta;

        }

        /// <summary>
        /// Registra un pesaje artículo
        /// </summary>
        /// <param name="pesajeEntregaId">Id del pesaje entrega</param>
        /// <param name="detalleEntregaId">Id del detalle de la entrega</param>
        /// <param name="cantidadRecibida">Cantida recibida del artículo</param>
        /// <param name="usuarioId">Id del Usuario</param>
        /// <response>bool</response>
        public bool AsignarPesajeArticulo(int pesajeEntregaId, int detalleEntregaId,decimal cantidadRecibida,int usuarioId)
        {
            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                EFPesajeArticulo eFPesajeArticulo = contexto.PesajesArticulo
                    .FirstOrDefault(pa=>pa.PesajeEntregaId == pesajeEntregaId && pa.DetalleEntregaId== detalleEntregaId);

                if (eFPesajeArticulo==null)
                {
                    contexto.PesajesArticulo.Add(new EFPesajeArticulo()
                    {
                        PesajeEntregaId = pesajeEntregaId,
                        DetalleEntregaId = detalleEntregaId,
                        CantidadRecibida = cantidadRecibida,
                        UsuarioId=usuarioId
                    });
                }
                else
                {
                    eFPesajeArticulo.CantidadRecibida += cantidadRecibida;
                    contexto.Update(eFPesajeArticulo);
                }               

                respuesta = contexto.SaveChanges() > 0;

            }

            return respuesta;
        }

        /// <summary>
        /// Actualiza un pesaje artículo con la inconsistencia
        /// </summary>
        /// <param name="pesajeArticuloId">id del artículo asociado al pesaje</param>
        /// <param name="inconsistencia">indica si existe inconsistencia en el pesaje</param>
        /// <response>bool</response>
        public bool ActualizarInconsistenciaCodigoBarras(int pesajeArticuloId, bool inconsistencia)
        {
            using (Contexto contexto=new Contexto())
            {
                EFPesajeArticulo eFPesajeArticulo = contexto.PesajesArticulo
                    .FirstOrDefault(pa => pa.PesajeArticuloId == pesajeArticuloId);

                eFPesajeArticulo.InconsistenciaCodigoBarras = inconsistencia;

                contexto.Update(eFPesajeArticulo);
                contexto.SaveChanges();
            }

            return true;
        }
    }
}
