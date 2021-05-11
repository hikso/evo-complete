using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 21-Sep/2019
    /// Descripción      : Implementa el acceso a datos de los artículos
    /// </summary>
    public class DAArticulo : DABase
    {
        private string prefijoAseo;
        private string prefijoCAF;
        private string prefijoCAL;
        private string prefijoDOT;
        private string prefijoETI;
        private string prefijoHC;
        private string prefijoING;
        private string prefijoMA;
        private string prefijoME;
        private string prefijoMTO;
        private string prefijoPAP;

        #region Métodos Públicos

        /// <summary>
        /// Gestiona la eliminación de la compra/traslado de un artículo en una acción
        /// </summary>
        /// <param name="detallePedidoId">Indica el id del detalle del pedido</param>
        /// <param name="accionId">Indica el id de la acción</param>
        /// <response >bool</response>
        public bool EliminarCompra(int detallePedidoId, int accionId)
        {
            using (Contexto contexto = new Contexto())
            {
                EFGestionCompra gestionCompra = contexto.GestionCompras.FirstOrDefault(gc => gc.DetallePedidoId == detallePedidoId && gc.AccionId == accionId);
                contexto.Remove(gestionCompra);
                contexto.SaveChanges();
            }

            return true;

        }


        /// <summary>
        /// Este método obtiene los artìculos por el codigo de la bodega y el codigo del artìculo
        /// </summary>
        /// <param name="codigoBodega">Indica el codigo de la bodega</param>
        /// <param name="codigoArticulo">Indica el codigo del artìculo</param>
        /// <returns>Instancia de objeto de tipo ArticuloBodega</returns>
        public ArticuloBodega ObtenerArticuloxCodigoBodegaCodigoArticulo(string codigoBodega, string codigoArticulo)
        {
            EFArticuloBodega EFArticuloBodega = null;

            using (var contexto = new Contexto())
            {
                EFArticuloBodega = contexto.ArticulosXBodega.
                    FirstOrDefault(x => x.ItemCode == codigoArticulo && x.WhsCode == codigoBodega);
            }

            ArticuloBodega articuloBodega = null;

            if (EFArticuloBodega != null)
            {
                articuloBodega = this.mapper.Map<EFArticuloBodega, ArticuloBodega>(EFArticuloBodega);
            }

            return articuloBodega;
        }

        /// <summary>
        /// Obtiene artículo por código
        /// </summary>
        /// <param name="codigo">Indica el código del artículo</param>
        /// <returns>Articulo</returns>
        public BOArticulo obtenerArticuloxCodigo(string codigo)
        {
            BOArticulo articulo = null;
            EFArticulo eFArticulo = null;

            using (Contexto contexto = new Contexto())
            {
                eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode == codigo);
            }

            if (eFArticulo != null)
            {
                articulo = this.mapper.Map<EFArticulo, BOArticulo>(eFArticulo);
            }

            return articulo;

        }

        /// <summary>
        /// Este método obtiene los artículos de la bodega por el codigo para obtener el nombre
        /// </summary>
        /// <param name="buscarArticuloBodegaSolicitud">Indica el artículo de la bodega</param>
        /// <returns>Instancia de objeto de tipo ArticuloBodega</returns>
        /// 

        public List<ArticuloBodega> ObtenerArticulosBodegaxCodigoNombreArticulo(BuscarArticuloBodegaSolicitud buscarArticuloBodegaSolicitud)
        {
            List<EFArticulo> eFArticulos = new List<EFArticulo>();
            List<EFArticuloBodega> eFArticuloBodega = new List<EFArticuloBodega>();
            List<ArticuloBodega> articulosBodega = new List<ArticuloBodega>();


            using (Contexto contexto = new Contexto())
            {
                if (buscarArticuloBodegaSolicitud.TipoSolicitud == 2)
                {
                    #region CUANDO TIPO SOLICITUD ES COMPRA
                    eFArticuloBodega = contexto.ArticulosXBodega.Where(a => a.WhsCode.ToUpper() == buscarArticuloBodegaSolicitud.CodigoBodega.ToUpper()).ToList();

                    eFArticuloBodega = eFArticuloBodega.Where(a => buscarArticuloBodegaSolicitud.PrefijosArticulosCompras.Contains(a.ItemCode.Substring(0, a.ItemCode.IndexOf("-")))).ToList();

                    //eFArticulos = eFArticulos.Where(a => a.ArticuloCompraPV == null).ToList();

                    if (!string.IsNullOrEmpty(buscarArticuloBodegaSolicitud.Nombre))
                    {
                        eFArticulos = contexto.Articulos.Where(a => eFArticuloBodega.Where(ab => ab.ItemCode == a.ItemCode).Count() > 0).ToList();

                        if (eFArticulos.Count > 0)
                        {
                            eFArticulos.RemoveAll(a => !EF.Functions.Like(a.ItemName, "%" + buscarArticuloBodegaSolicitud.Nombre + "%"));
                        }

                        if (eFArticuloBodega.Count > 0)
                        {
                            eFArticuloBodega.RemoveAll(ab => eFArticulos.Where(a => a.ItemCode == ab.ItemCode).Count() == 0);
                        }

                    }
                    else if (!string.IsNullOrEmpty(buscarArticuloBodegaSolicitud.Codigo))
                    {

                        if (eFArticuloBodega.Count > 0)
                        {
                            eFArticuloBodega.RemoveAll(a => !EF.Functions.Like(a.ItemCode, "%" + buscarArticuloBodegaSolicitud.Codigo + "%"));
                        }
                    }

                    if (eFArticuloBodega.Count() > 0)
                    {

                        foreach (EFArticuloBodega item in eFArticuloBodega.OrderBy(x => x.ItemCode).Take(5))
                        {
                            ArticuloBodega articuloBodega = this.mapper.Map<EFArticuloBodega, ArticuloBodega>(item);

                            EFArticulo eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode == item.ItemCode);


                            if (eFArticulo != null)
                            {
                                articuloBodega.NombreArticulo = eFArticulo.ItemName;
                                articuloBodega.UnidadMedida = eFArticulo.SalUnitMsr;
                                if (articuloBodega.Minimo != null && articuloBodega.Stock != null)
                                {
                                    articuloBodega.PedidoSugerido = articuloBodega.Minimo - articuloBodega.Stock;
                                    articuloBodega.PedidoSugerido = articuloBodega.PedidoSugerido <= 0 ? 0 : articuloBodega.PedidoSugerido;
                                }

                            }
                            if (eFArticulo.ArticuloCompraPV != "true")
                            {
                                articulosBodega.Add(articuloBodega);
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region CUANDO TIPO SOLICITUD ES TRASLADO
                    eFArticuloBodega = contexto.ArticulosXBodega.Where(a => EF.Functions.Like(a.ItemCode.ToUpper(), $"{buscarArticuloBodegaSolicitud.PrefijoCodigoArticulo.ToUpper()}%") && a.WhsCode.ToUpper() == buscarArticuloBodegaSolicitud.CodigoBodega.ToUpper()).ToList();

                    if (!string.IsNullOrEmpty(buscarArticuloBodegaSolicitud.Nombre))
                    {
                        eFArticulos = contexto.Articulos.Where(a => eFArticuloBodega.Where(ab => ab.ItemCode == a.ItemCode).Count() > 0).ToList();

                        if (eFArticulos.Count > 0)
                        {
                            eFArticulos.RemoveAll(a => !EF.Functions.Like(a.ItemName, "%" + buscarArticuloBodegaSolicitud.Nombre + "%"));
                        }

                        if (eFArticuloBodega.Count > 0)
                        {
                            eFArticuloBodega.RemoveAll(ab => eFArticulos.Where(a => a.ItemCode == ab.ItemCode).Count() == 0);
                        }

                    }
                    else if (!string.IsNullOrEmpty(buscarArticuloBodegaSolicitud.Codigo))
                    {

                        if (eFArticuloBodega.Count > 0)
                        {
                            eFArticuloBodega.RemoveAll(a => !EF.Functions.Like(a.ItemCode, "%" + buscarArticuloBodegaSolicitud.Codigo + "%"));
                        }
                    }

                    if (eFArticuloBodega.Count() > 0)
                    {

                        foreach (EFArticuloBodega item in eFArticuloBodega.OrderBy(x => x.ItemCode).Take(5))
                        {
                            ArticuloBodega articuloBodega = this.mapper.Map<EFArticuloBodega, ArticuloBodega>(item);

                            EFArticulo eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode == item.ItemCode);

                            articuloBodega.NombreArticulo = eFArticulo.ItemName;
                            articuloBodega.UnidadMedida = eFArticulo.SalUnitMsr;
                            articuloBodega.EmpaqueId = eFArticulo.EmpaqueId;
                            articuloBodega.EstadoId = eFArticulo.EstadoId;

                            if (articuloBodega.Minimo != null && articuloBodega.Stock != null)
                            {
                                articuloBodega.PedidoSugerido = articuloBodega.Minimo - articuloBodega.Stock;
                                articuloBodega.PedidoSugerido = articuloBodega.PedidoSugerido <= 0 ? 0 : articuloBodega.PedidoSugerido;
                            }

                            articulosBodega.Add(articuloBodega);
                        }
                    }
                    #endregion
                }
            }

            return articulosBodega;
        }

        /// <summary>
        /// Asigna un artículo a una bodega
        /// </summary>
        /// <param name="articuloBodega">Artículo bodega</param>
        /// <response>bool</response>
        public async Task<bool> AsignarArticuloBodega(ArticuloBodega asignarArticuloBodega)
        {
            using (Contexto contexto = new Contexto())
            {
                EFArticuloBodega eFArticuloBodega = null;

                if (asignarArticuloBodega.Nuevo)
                {
                    eFArticuloBodega = this.mapper.Map<ArticuloBodega, EFArticuloBodega>(asignarArticuloBodega);
                    contexto.Add(eFArticuloBodega);
                }
                else
                {
                    eFArticuloBodega = contexto.ArticulosXBodega.
                        FirstOrDefault(a => a.ItemCode == asignarArticuloBodega.CodigoArticulo 
                        && a.WhsCode== asignarArticuloBodega.WhsCode);
                    eFArticuloBodega.OnHand = asignarArticuloBodega.Stock;
                    eFArticuloBodega.MinStock = asignarArticuloBodega.Minimo;
                    eFArticuloBodega.MaxStock = asignarArticuloBodega.Maximo;
                    contexto.Update(eFArticuloBodega);
                }

                await contexto.SaveChangesAsync();

            }

            return true;
        }

        /// <summary>
        /// Asigna un artículo
        /// </summary>
        /// <param name="bOArticulo">Artículo</param>
        /// <response>bool</response>
        public async Task<bool> AsignarArticulo(BOArticulo bOArticulo)
        {
            using (Contexto contexto=new Contexto())
            {
                EFArticulo eFArticulo = null;

                if (bOArticulo.Nuevo)
                {
                    eFArticulo = this.mapper.Map<BOArticulo, EFArticulo>(bOArticulo);
                    contexto.Add(eFArticulo);
                }
                else
                {
                    eFArticulo = contexto.Articulos.FirstOrDefault(a=>a.ItemCode == bOArticulo.ItemCode);
                    eFArticulo.ItemName = bOArticulo.ItemName;
                    eFArticulo.SalUnitMsr = bOArticulo.SalUnitMsr;
                    contexto.Update(eFArticulo);
                }

                await contexto.SaveChangesAsync();               

            }

            return true;
        }


        /// <summary>
        /// Gestiona la eliminación de todas las ordenes de compras de todos los artículos
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <response>bool</response>
        public bool LimpiarCompras(List<int> detallesPedidoIds)
        {
            using (Contexto contexto=new Contexto())
            {
                using (var tran=contexto.Database.BeginTransaction())
                {
                    try
                    {
                        List<EFGestionCompra> articulosCompras = contexto.GestionCompras.Where(gc => detallesPedidoIds.Contains(gc.DetallePedidoId)).ToList();
                        contexto.GestionCompras.RemoveRange(articulosCompras);
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

            return true;
        }

        /// <summary>
        /// Gestiona la actualización de la compra de los artículos
        /// </summary>
        /// <param name="compras">Artículos a gestionar en la solicitud de pedido</param>        
        /// <param name="pedidoId">Id del pedido</param>
        /// <response>bool</response>
        public bool ActualizarCompra(List<BOGestionCompra> compras, int pedidoId)
        {
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                       
                        foreach (var c in compras.Where(c=>c.Actualizar))
                        {
                            EFGestionCompra efGC = null;

                            if (c.Actualizar)
                            {
                                efGC = contexto.GestionCompras
                                .FirstOrDefault(gc => gc.DetallePedidoId == c.DetallePedidoId && gc.AccionId == c.AccionId);

                                efGC.Cantidad = c.Cantidad;

                                contexto.Update(efGC);
                            }

                            if (c.Nuevo)
                            {
                                efGC = new EFGestionCompra()
                                {
                                    AccionId = c.AccionId,
                                    DetallePedidoId = c.DetallePedidoId,
                                    Cantidad = c.Cantidad
                                };

                                contexto.Add(efGC);
                            }                         
                            
                        }
                      
                        contexto.SaveChanges();                       

                        EFPedido eFPedido = contexto.Pedidos.FirstOrDefault(p => p.PedidoId == pedidoId);

                        eFPedido.FechaGestionCompra = DateTime.Now;

                        contexto.Update(eFPedido);

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

            return true;
        }

        /// <summary>
        /// Gestiona la finalización de la compra de los artículos
        /// </summary>
        /// <param name="compras">Artículos a gestionar en la solicitud de pedido</param>
        /// <param name="estadoPedidoId">Id del estado del pedido</param>
        /// <param name="pedidoId">Id del pedido</param>
        /// <response>bool</response>
        public bool FinalizarCompra(List<BOGestionCompra> compras, int pedidoId,int estadoPedidoId)
        {
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {

                        foreach (var c in compras.Where(c => c.Actualizar))
                        {
                            EFGestionCompra efGC = null;

                            if (c.Actualizar)
                            {
                                efGC = contexto.GestionCompras
                                .FirstOrDefault(gc => gc.DetallePedidoId == c.DetallePedidoId && gc.AccionId == c.AccionId);

                                efGC.Cantidad = c.Cantidad;

                                contexto.Update(efGC);
                            }

                            if (c.Nuevo)
                            {
                                efGC = new EFGestionCompra()
                                {
                                    AccionId = c.AccionId,
                                    DetallePedidoId = c.DetallePedidoId,
                                    Cantidad = c.Cantidad
                                };

                                contexto.Add(efGC);
                            }
                        }

                        EFPedido eFPedido = contexto.Pedidos.FirstOrDefault(p => p.PedidoId == pedidoId);

                        eFPedido.FechaGestionCompra = DateTime.Now;
                        eFPedido.EstadoPedidoId = estadoPedidoId;

                        contexto.Update(eFPedido);

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

            return true;
        }

        /// <summary>
        /// Gestiona la compra de los artículos
        /// </summary>
        /// <param name="body">Solicitud para la compra de los artículos</param>
        /// <response>bool</response>
        public bool AsignarCompra(BOCompraRequest compraRequest)
        {
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        compraRequest.ArticulosCompra.ForEach(detalle =>
                        {
                            EFGestionCompra eFGestionCompra = contexto.GestionCompras
                            .Include(i => i.DetallePedido)
                            .FirstOrDefault(gc => gc.AccionId == compraRequest.AccionId && gc.DetallePedidoId == detalle.DetallePedidoId);
                            if (eFGestionCompra != null)
                            {
                                contexto.GestionCompras.Remove(eFGestionCompra);
                            }
                        });
                        
                        contexto.GestionCompras.AddRange(
                                  compraRequest.ArticulosCompra.Select(ac =>
                                     new EFGestionCompra()
                                     {
                                         AccionId = compraRequest.AccionId,
                                         Cantidad = Convert.ToDecimal(ac.CantidadGestionar),
                                         DetallePedidoId = ac.DetallePedidoId,
                                         OrdenCompra = null
                                     }
                                  )
                                              );
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

            return true;
        }

        /// <summary>
        /// Obtiene todas las tranformaciones
        /// </summary>       
        /// <responses>List<BOTransformacion></response>
        public List<BOTransformacion> ObtenerTodasTransformaciones()
        {
            List<BOTransformacion> bOTransformaciones = null;
            List<EFTransformacion> eFTransformaciones = null;

            using (Contexto contexto = new Contexto())
            {
                eFTransformaciones = contexto.Transformaciones.Include(i => i.Articulo).ToList();
            }

            if (eFTransformaciones != null)
            {
                bOTransformaciones = this.mapper.Map<List<EFTransformacion>, List<BOTransformacion>>(eFTransformaciones);
            }

            return bOTransformaciones;
        }

        /// <summary>
        /// Obtiene los artículos de una entrega en estado alistamiento
        /// </summary>
        /// <param name="id">Indica el id de la entrega</param>
        /// <response>DetalleEntregaRespuesta</response>
        public DetalleEntregaRespuesta ObtenerArticulosPesaje(int id)
        {
            DetalleEntregaRespuesta detalleEntregaRespuesta = new DetalleEntregaRespuesta();

            detalleEntregaRespuesta.ArticulosResponse = new List<ArticuloPesajeRespuesta>();

            using (Contexto contexto = new Contexto())
            {
                ArticuloPesajeRespuesta articuloPesajeRespuesta = null;

                EFArticulo eFArticulo = null;

                foreach (EFDetalleEntrega eFDetalleEntrega in contexto.DetalleEntregas.Include(d => d.DetallePedido.EstadoArticulo).Where(e => e.EntregaId == id))
                {
                    eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode == eFDetalleEntrega.DetallePedido.ItemCode);

                    articuloPesajeRespuesta = new ArticuloPesajeRespuesta()
                    {
                        DetalleEntregaId = eFDetalleEntrega.DetalleEntregaId,
                        CodigoArticulo = eFDetalleEntrega.DetallePedido.ItemCode,
                        NombreArticulo = eFArticulo.ItemName,
                        Estado = eFDetalleEntrega.DetallePedido.EstadoArticulo.Nombre,
                        CantidadSolicitada = eFDetalleEntrega.DetallePedido.Cantidad,
                        CantidadAprobada = eFDetalleEntrega.DetallePedido.CantidadAprobada.Value,
                        CantidadEntrega = eFDetalleEntrega.Cantidad,
                        UnidadMedida = eFArticulo.SalUnitMsr
                    };

                    detalleEntregaRespuesta.ArticulosResponse.Add(articuloPesajeRespuesta);
                }
            }

            return detalleEntregaRespuesta;

        }

        /// <summary>
        /// Este método obtiene el estado del artículo por el id
        /// </summary>
        /// <param name="EstadoArticuloId">Indica el id del Artículo</param>
        /// <returns>Instancia de objeto de tipo EstadoArticulo</returns>
        public BOEstadoArticulo ObtenerEstadoArticuloxId(int EstadoArticuloId)
        {
            EFEstadoArticulo eFEstadoArticulo = null;

            using (var contexto = new Contexto())
            {
                eFEstadoArticulo = contexto.EstadosArticulo.FirstOrDefault(x => x.EstadoArticuloId == EstadoArticuloId);
            }

            BOEstadoArticulo estadoArticulo = null;

            if (eFEstadoArticulo != null)
            {
                //estadoArticulo = this.mapper.Map<EFEstadoArticulo, EstadoArticulo>(eFEstadoArticulo);
                estadoArticulo = new BOEstadoArticulo()
                {
                    EstadoArticuloId = eFEstadoArticulo.EstadoArticuloId,
                    Nombre = eFEstadoArticulo.Nombre,
                    Activo = eFEstadoArticulo.Activo
                };
            }

            return estadoArticulo;

        }

        /// <summary>
        /// Este método obtiene todos los artículos por el filtro 
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro</param>
        /// <returns>Lista de ArticuloBodega</returns>
        public List<ArticuloBodega> ObtenerTodosArticulosxFiltro(FiltroArticulo filtro)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@desde",
                    Value = filtro.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@hasta",
                    Value = filtro.Hasta
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@codigoBodega",
                    Value = filtro.WhsCode
                });

                if (!string.IsNullOrWhiteSpace(filtro.CodigoArticulo))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@codigoArticulo",
                        Value = filtro.CodigoArticulo
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.NombreArticulo))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@nombreArticulo",
                        Value = filtro.NombreArticulo
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Stock))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@stock",
                        Value = filtro.Stock
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Minimo))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@minimo",
                        Value = filtro.Minimo
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Maximo))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@maximo",
                        Value = filtro.Maximo
                    });
                }

                List<ArticuloBodega> articulosBodega = contexto.LoadSPAutoMapper<ArticuloBodega>("ObtenerTodosArticulosBodegaxFiltro", dbParameters);

                return articulosBodega;
            }
        }

        /// <summary>
        /// Este método obtiene todos los conteos del registro por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro</param>
        /// <returns>Conteo de todos los registros por filtro</returns>
        public object ObtenerConteoTodosRegistrosxFiltro(FiltroArticulo filtro)
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@codigoBodega",
                    Value = filtro.WhsCode
                });

                if (!string.IsNullOrWhiteSpace(filtro.CodigoArticulo))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@codigoArticulo",
                        Value = filtro.CodigoArticulo
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.NombreArticulo))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@nombreArticulo",
                        Value = filtro.NombreArticulo
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Stock))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@stock",
                        Value = filtro.Stock
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Minimo))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@minimo",
                        Value = filtro.Minimo
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Maximo))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@maximo",
                        Value = filtro.Maximo
                    });
                }

                object result = contexto.LoadSPScalar("ObtenerConteoTodosArticulosBodegaxFiltro", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtienen todos los artículos por bodega
        /// </summary>
        /// <param name="desde">Indica el valor de Desde</param>
        /// <param name="hasta">Indica el valor hasta</param>
        /// <param name="whsCode">Indica el valor de la bodega</param>
        /// <returns>Lista de ArticuloBodega</returns>
        public List<ArticuloBodega> ObtenerTodosArticulosxBodega(int desde, int hasta, string whsCodePuntoVenta, string whsCodePlanta, string tipoSolicitud,string tipoSolicitudId)
        {

            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();
                List<ArticuloBodega> articulosBodega = null;

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = hasta
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@whsCodePuntoVenta",
                    Value = whsCodePuntoVenta
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@whsCodePlanta",
                    Value = whsCodePlanta
                });

                if (tipoSolicitud.Equals(tipoSolicitudId))
                {
                    articulosBodega = contexto.LoadSPAutoMapper<ArticuloBodega>("ObtenerTodosArticulosxBodegaCompras", dbParameters);
                }
                else
                {
                    articulosBodega = contexto.LoadSPAutoMapper<ArticuloBodega>("ObtenerTodosArticulosxBodega", dbParameters);
                }

                return articulosBodega;
            }
        }

        /// <summary>
        /// Este método obtienen todos los artículos del punto de venta que se fabrican en las dos plantas
        /// </summary>       
        /// <param name="whsCode">Indica el valor de la bodega</param>
        /// <returns>Lista de ArticuloBodega</returns>
        public List<ArticuloBodega> ObtenerTodosArticulosxBodegaPlantas(string whsCode)
        {

            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@whsCodePuntoVenta",
                    Value = whsCode
                });

                List<ArticuloBodega> articulosBodega = contexto.LoadSPAutoMapper<ArticuloBodega>("ObtenerTodosArticulosxBodegaPlantas", dbParameters);

                return articulosBodega;
            }
        }

        /// <summary>
        /// Este método obtiene los conteo de los registros
        /// </summary>
        /// <param name="whsCode">Indica el valor de la bodega punto de venta</param>
        /// <param name="whsCodePlanta">Indica el valor de la bodega planta</param>
        /// <returns>Conteo de todos los registros</returns>
        public object ObtenerConteoTodosRegistros(string whsCode, string whsCodePlanta)
        {
            int nRegistros = 0;

            List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

            dbParameters.Add(new EFCoreExtensionParameter()
            {
                ParameterName = "@WhsCode",
                Value = whsCode
            });

            dbParameters.Add(new EFCoreExtensionParameter()
            {
                ParameterName = "@whsCodePlanta",
                Value = whsCodePlanta
            });

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosArticulosxBodega", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene los conteo de los registros
        /// </summary>
        /// <param name="whsCode">Indica el valor de la bodega punto de venta</param>      
        /// <returns>Conteo de todos los registros</returns>
        public object ObtenerConteoTodosRegistrosPlantas(string whsCode, string tipoSolicitud)
        {
            int nRegistros = 0;

            List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

            dbParameters.Add(new EFCoreExtensionParameter()
            {
                ParameterName = "@WhsCode",
                Value = whsCode
            });

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosArticulosxBodegaPlantas", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene los conteo de los registros para compras
        /// </summary>
        /// <param name="whsCode">Indica el valor de la bodega punto de venta</param>      
        /// <returns>Conteo de todos los registros</returns>
        public object ObtenerConteoTodosRegistrosCompras(string whsCode)
        {
            int nRegistros = 0;

            List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

            dbParameters.Add(new EFCoreExtensionParameter()
            {
                ParameterName = "@WhsCode",
                Value = whsCode
            });

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosArticulosxBodegaCompras", dbParameters);//Crear el SP (OK)

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los estados 
        /// </summary>
        /// <returns>Lista de EstadoArticulo</returns>
        public List<BOEstadoArticulo> ObtenerTodosEstados()
        {
            List<EFEstadoArticulo> efEstadosArticulo = null;

            using (Contexto contexto = new Contexto())
            {
                efEstadosArticulo = contexto.EstadosArticulo.Where(e => e.Activo).ToList();
            }

            List<BOEstadoArticulo> estadosArticulo = null;

            if (efEstadosArticulo.Count > 0)
            {
                estadosArticulo = this.mapper.Map<List<EFEstadoArticulo>, List<BOEstadoArticulo>>(efEstadosArticulo);
            }

            return estadosArticulo;
        }

        /// <summary>
        /// Este método obtiene todos las acciones de un artículo 
        /// </summary>
        /// <returns>Lista de Acciones</returns>
        public List<Accion> ObtenerAcciones()
        {
            List<EFAccion> eFAcciones = null;

            using (Contexto contexto = new Contexto())
            {
                eFAcciones = contexto.Acciones.OrderBy(a => a.AccionId).ToList();
            }

            List<Accion> accionesResponse = null;

            if (eFAcciones.Count > 0)
            {
                accionesResponse = this.mapper.Map<List<EFAccion>, List<Accion>>(eFAcciones);
            }

            return accionesResponse;
        }
        /// <summary>
        /// Este método obtiene todos los artículos
        /// </summary>
        /// <returns>Lista de Articulo</returns>
        public List<BOArticulo> ObtenerTodosArticulos()
        {
            List<EFArticulo> efArticulo = null;

            using (Contexto contexto = new Contexto())
            {
                efArticulo = contexto.Articulos.ToList();
            }

            List<BOArticulo> articulos = null;

            if (efArticulo.Count > 0)
            {
                articulos = this.mapper.Map<List<EFArticulo>, List<BOArticulo>>(efArticulo);
            }

            return articulos;
        }

        /// <summary>
        /// Este método obtiene todo los artículos del punto de venta
        /// </summary>
        /// <param name="codigoPuntoVenta">Indica el valor del código del punto de venta</param>
        /// <returns>Lista de todos los artículos del punto de venta</returns>
        public List<BOArticulo> ObtenerTodosArticulosxPuntoVenta(string codigoPuntoVenta)
        {
            List<EFArticulo> eFArticulos = null;
            List<EFArticuloBodega> eFArticuloBodegas = null;
            List<BOArticulo> bOArticulos = new List<BOArticulo>();

            using (Contexto contexto = new Contexto())
            {
                eFArticuloBodegas = contexto.ArticulosXBodega.Where(ab => ab.WhsCode == codigoPuntoVenta).ToList();

                if (eFArticuloBodegas != null)
                {
                    eFArticulos = contexto.Articulos
                        .Include("ImpuestosArticulos.Impuesto")
                        .Include("ImpuestosSociosArticulos.Impuesto")
                        .Include("ListasPrecios.TipoListaPrecio")
                        .Where(a => eFArticuloBodegas.Select(ab => ab.ItemCode).Contains(a.ItemCode))
                        .ToList();
                }
            }

            if (eFArticulos != null)
            {
                bOArticulos = this.mapper.Map<List<EFArticulo>, List<BOArticulo>>(eFArticulos);
            }

            return bOArticulos;

        }

        /// <summary>
        /// Este método actualiza el artículo en la bodega
        /// </summary>
        /// <param name="articuloBodega">Objeto de negocio de tipo ArticuloBodega</param>      
        /// <returns>bool</returns>
        public bool ActualizarArticuloBodega(ArticuloBodega articuloBodega)
        {
            EFArticuloBodega eFArticuloBodega = this.mapper.Map<ArticuloBodega, EFArticuloBodega>(articuloBodega);

            using (Contexto contexto = new Contexto())
            {
                contexto.Update(articuloBodega);
                contexto.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Este método retorna los empaques
        /// </summary>       
        /// <returns>List<BOEmpaque></returns>
        public List<BOEmpaque> ObtenerEmpaques()
        {
            List<EFEmpaque> eFEmpaques = null;

            string query = string.Empty;

            using (Contexto contexto = new Contexto())
            {
                eFEmpaques = contexto.Empaques.Where(e => e.EmpaqueActivo).ToList();
            }

            string dd = query;

            List<BOEmpaque> bOEmpaques = new List<BOEmpaque>();

            if (eFEmpaques != null)
            {
                bOEmpaques = this.mapper.Map<List<EFEmpaque>, List<BOEmpaque>>(eFEmpaques);
            }

            return bOEmpaques;

        }


        #endregion
    }
}