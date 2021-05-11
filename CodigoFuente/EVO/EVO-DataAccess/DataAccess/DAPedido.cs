using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using EVO_PV_BusinessObjects.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{

    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 20-Sep/2019
    /// Descripción      : Se crea la clase de acceso a datos de Pedidos
    /// </summary>
    public class DAPedido : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método crea el pedido 
        /// </summary>
        /// <param name="pedido">Indica el pedido a crear</param>
        /// <returns>Verdadero si se pudo crear el pedido</returns>
        public bool CrearPedido(Pedido pedido)
        {
            EFPedido efPedido = new EFPedido()
            {
                WhsCode = pedido.WhsCode,
                SolicitudPara = pedido.SolicitudPara,
                EstadoPedidoId = pedido.EstadoPedidoId,
                FechaPedido = pedido.FechaPedido,
                UsuarioId = pedido.UsuarioId,
                NumeroPedido = pedido.NumeroPedido,
                TipoSolicitudId=pedido.TipoSolicitudId                
            };

            if (pedido.FechaEntrega != null)
            {
                efPedido.FechaEntrega = pedido.FechaEntrega;
            }

            using (Contexto contexto = new Contexto())
            {
                using (var transaction = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        contexto.Add(efPedido);

                        contexto.SaveChanges();

                        foreach (DetallePedido detallePedido in pedido.Detalles)
                        {
                            EFDetallePedido eFDetallePedido = new EFDetallePedido()
                            {
                                PedidoId = efPedido.PedidoId,
                                ItemCode = detallePedido.ItemCode,
                                EstadoArticuloId = detallePedido.EstadoArticuloId,
                                Cantidad = detallePedido.Cantidad,
                                CantidadAprobada = 0,
                                Observacion = detallePedido.Observacion,
                                EmpaqueId=detallePedido.EmpaqueId
                            };

                            contexto.Add(eFDetallePedido);
                        }

                        contexto.SaveChanges();
                        transaction.Commit();

                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

        }

        /// <summary>
        /// Obtiene las solicitudes de un pedido en estado borrador
        /// </summary>
        /// <param name="solicitudDe">Punto de venta que realiza la solicitud del pedido</param>
        /// <response >List<BOObtenerSolicitudPedidoBorradorResponse></response>
        public List<BOObtenerSolicitudPedidoBorradorResponse> ObtenerSolicitudPedidoBorrador(string solicitudDe)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@solicitudDe",
                    Value = solicitudDe
                });
               
                List<BOObtenerSolicitudPedidoBorradorResponse> pedidosRespuesta = contexto.LoadSPAutoMapper<BOObtenerSolicitudPedidoBorradorResponse>("ObtenerTodosPedidosBorrador", dbParameters);

                if (pedidosRespuesta == null)
                {
                    pedidosRespuesta = new List<BOObtenerSolicitudPedidoBorradorResponse>();
                }

                return pedidosRespuesta;
            }
        }

        /// <summary>
        /// Obtiene los tipos de solicitud de un pedido
        /// </summary>
        /// <response >List<BOObtenerTipoSolicitudPedidoResponse></response>   
        public List<BOObtenerTipoSolicitudPedidoResponse> ObtenerTiposSolicitudPedido()
        {
            List<EFTipoSolicitud> efTiposSolicitud = null;

            using (Contexto contexto = new Contexto())
            {
                efTiposSolicitud = contexto.TiposSolicitud.Where(e => e.Activo).ToList();
            }

            List<BOObtenerTipoSolicitudPedidoResponse> boTiposSolciitud = null;

            if (efTiposSolicitud.Count > 0)
            {
                boTiposSolciitud = this.mapper.Map<List<EFTipoSolicitud>, List<BOObtenerTipoSolicitudPedidoResponse>>(efTiposSolicitud);
            }

            return boTiposSolciitud;
        }

        /// <summary>
        /// Este método elimina un artículo de una entrega
        /// </summary>
        /// <param name="id">2</param>
        /// <returns>boolean</returns>
        public bool EliminarArticuloEntrega(int id)
        {
            bool eliminado = false;

            using (Contexto contexto = new Contexto())
            {
                EFDetalleEntrega eFDetalleEntrega = contexto.DetalleEntregas.FirstOrDefault(de => de.DetalleEntregaId == id);

                if (eFDetalleEntrega != null)
                {
                    contexto.Remove(eFDetalleEntrega);
                    contexto.SaveChanges();
                    eliminado = true;
                }
            }

            return eliminado;
        }

        /// <summary>
        /// Obtiene los pedidos que tiene entregas en estado alistamiento
        /// </summary>
        /// <param name="estadoId">2</param>
        /// <response>List<PedidoRespuesta></response>
        public List<PedidoRespuesta> ObtenerPedidosEntregasxEstadoId(int estadoId)
        {
            List<PedidoRespuesta> pedidosRespuesta = null;

            using (Contexto contexto = new Contexto())
            {
                pedidosRespuesta = this.mapper.Map<List<EFPedido>, List<PedidoRespuesta>>(contexto.Pedidos.Include(p => p.EntregasXPedido).Where(p => p.EntregasXPedido.Where(ep => ep.EstadoEntregaId == estadoId).Count() > 0).ToList());
            }

            return pedidosRespuesta;
        }

        /// <summary>
        /// Este método valida que el artículo exista en la entrega
        /// </summary>
        /// <param name="id">2</param>
        /// <returns>Instancia de tipo EstadoPedido</returns>
        public bool ExisteArticuloEntrega(int id)
        {
            bool existe = false;

            using (Contexto contexto = new Contexto())
            {
                EFDetalleEntrega eFDetalleEntrega = contexto.DetalleEntregas.
                    FirstOrDefault(de => de.DetalleEntregaId == id);

                if (eFDetalleEntrega != null)
                {
                    existe = true;
                }
            }

            return existe;

        }

        /// <summary>
        /// Este método obtiene el estado del pedido por id
        /// </summary>
        /// <param name="estadoPedidoId">Indica el estado del pedido</param>
        /// <returns>Instancia de tipo EstadoPedido</returns>
        public EstadoPedido ObtenerEstadoPedidoxId(int estadoPedidoId)
        {
            EFEstadoPedido eFEstadoPedido = null;

            using (var contexto = new Contexto())
            {
                eFEstadoPedido = contexto.EstadosXPedido.FirstOrDefault(p => p.EstadoPedidoId == estadoPedidoId);
            }

            EstadoPedido estadoPedido = null;

            if (eFEstadoPedido != null)
            {
                estadoPedido = this.mapper.Map<EFEstadoPedido, EstadoPedido>(eFEstadoPedido);
            }

            return estadoPedido;
        }


        /// <summary>
        /// Este método retorna los vehiculos que tienen entregas todavia en sin cerrar 
        /// </summary>       
        /// <returns>Lista de tipo VehiculoRespuesta</returns>
        public List<EnrutamientoRespuesta> ObtenerVehiculosConEntregas()
        {
            List<EFVehiculoEntrega> eFVehiculoEntregas = null;

            List<EFVehiculoEntrega> eFVehiculoEntregasCumple = null;

            List<EnrutamientoRespuesta> enrutamientoRespuesta = null;

            using (Contexto contexto = new Contexto())
            {
                eFVehiculoEntregas = contexto.VehiculoEntregas
                    .Include(d => d.Muelle)
                    .Include("Vehiculo.TipoVehiculo")
                    .Include("VehiculoEntregasDetalles.Entrega.EstadoEntrega")
                    .Include("VehiculoEntregasDetalles.Entrega.Detalles")
                    .Include(d => d.Conductor)
                    .Include(d => d.Auxiliar)
                    .OrderByDescending(o => o.FechaRegistro)
                    .ToList();
            }

            if (eFVehiculoEntregas != null)
            {
                eFVehiculoEntregasCumple = new List<EFVehiculoEntrega>();

                foreach (EFVehiculoEntrega efVehiculoEntrega in eFVehiculoEntregas)
                {
                    int entregasCerradas = efVehiculoEntrega.VehiculoEntregasDetalles.
                         Where(x => x.Entrega.EstadoEntrega.Nombre == EstadosEntregasEnum.Cerrado.ToString()).Count();

                    int totalEntregas = efVehiculoEntrega.VehiculoEntregasDetalles.Count();

                    if (entregasCerradas < totalEntregas)
                    {
                        eFVehiculoEntregasCumple.Add(efVehiculoEntrega);
                    }
                }

                eFVehiculoEntregas = null;

                if (eFVehiculoEntregasCumple.Count() > 0)
                {
                    enrutamientoRespuesta = new List<EnrutamientoRespuesta>();

                    foreach (EFVehiculoEntrega efVE in eFVehiculoEntregasCumple)
                    {
                        var pesoEntregas = efVE.VehiculoEntregasDetalles.Select(e => e.Entrega.Detalles.Select(d => d.Cantidad).Sum()).Sum();

                        EnrutamientoRespuesta ve = new EnrutamientoRespuesta()
                        {
                            VehiculoEntregaId = efVE.VehiculoEntregaId,
                            TotalPeso = pesoEntregas,
                            CantidadEntregas = efVE.VehiculoEntregasDetalles.Count(),
                            Auxiliar = this.mapper.Map<EFEmpleado, Empleado>(efVE.Auxiliar),
                            Conductor = this.mapper.Map<EFEmpleado, Empleado>(efVE.Conductor),
                            Muelle = this.mapper.Map<EFMuelle, MuelleRespuesta>(efVE.Muelle),
                            TipoVehiculo = this.mapper.Map<EFTipoVehiculo, TipoVehiculoRespuesta>(efVE.Vehiculo.TipoVehiculo),
                            Vehiculo = this.mapper.Map<EFVehiculo, VehiculoRespuesta>(efVE.Vehiculo)
                        };

                        enrutamientoRespuesta.Add(ve);

                    }
                }

            }

            return enrutamientoRespuesta;
        }

        /// <summary>
        /// Este método retorna un booleano indicando si la entrega en programación ha sido actualizada
        /// </summary>       
        /// <param name="entregaSolicitud"></param>
        /// <returns>Booleano</returns>
        public bool ActualizarProgramacionEntrega(EntregaSolicitud entregaSolicitud)
        {
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        EFEntrega eFEntrega = contexto.Entregas.Include("Pedido.DetallesXPedido").Include("Detalles.DetallePedido").FirstOrDefault(e => e.EntregaId == entregaSolicitud.EntregaId);

                        eFEntrega.FechaEntrega = entregaSolicitud.Fecha;
                        eFEntrega.TipoVehiculoId = entregaSolicitud.TipoVehiculoId;

                        //BO incluye el estado del artículo ya que puede exister el mismo artículo con dos estados diferentes en la misma solicitud
                        foreach (EntregaSolicitudArticulos entregaSolicitudArticulo in entregaSolicitud.Articulos)
                        {
                            EFDetalleEntrega eFDetalleEntrega = eFEntrega.Detalles.FirstOrDefault(d => d.DetallePedido.ItemCode == entregaSolicitudArticulo.Codigo && d.DetallePedido.EstadoArticuloId == entregaSolicitudArticulo.IdEstadoArticulo);

                            if (eFDetalleEntrega != null)
                            {
                                eFDetalleEntrega.Cantidad = entregaSolicitudArticulo.CantidadEntrega;
                                contexto.Update(eFEntrega);
                            }
                            else
                            {
                                eFDetalleEntrega = new EFDetalleEntrega();
                                eFDetalleEntrega.EntregaId = eFEntrega.EntregaId;
                                eFDetalleEntrega.Cantidad = entregaSolicitudArticulo.CantidadEntrega;
                                eFDetalleEntrega.DetallePedidoId = eFEntrega.Pedido.DetallesXPedido.FirstOrDefault(d => d.ItemCode == entregaSolicitudArticulo.Codigo && d.EstadoArticuloId == entregaSolicitudArticulo.IdEstadoArticulo).DetallePedidoId;
                                contexto.Add(eFDetalleEntrega);
                            }

                        }

                        contexto.SaveChanges();

                        tran.Commit();

                        return true;
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }


        /// <summary>
        /// Este método retorna un booleano indicando si la entrega en distribución ha sido actualizada
        /// </summary>
        /// <param name="entregaSolicitud">Referencia del body al modelo request</param>
        /// <returns>Booleano</returns>
        public bool ActualizarDistribucionEntrega(EntregaSolicitud entregaSolicitud)
        {
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        EFEntrega eFEntrega = contexto.Entregas.Include("Pedido.DetallesXPedido").Include("Detalles.DetallePedido").FirstOrDefault(e => e.EntregaId == entregaSolicitud.EntregaId);

                        eFEntrega.FechaEntrega = entregaSolicitud.Fecha;

                        EFMotivoProceso eFMotivoProceso = new EFMotivoProceso()
                        {
                            FechaRegistro = DateTime.Now,
                            MotivoId = entregaSolicitud.MotivoID,
                            TablaId = entregaSolicitud.EntregaId,
                            NombreTabla = TablasEnum.Entregas.ToString()
                        };

                        contexto.Add(eFMotivoProceso);

                        //BO incluye el estado del artículo ya que puede existe el mismo artículo con dos estados diferentes en la misma solicitud
                        foreach (EntregaSolicitudArticulos entregaSolicitudArticulo in entregaSolicitud.Articulos)
                        {
                            EFDetalleEntrega eFDetalleEntrega = eFEntrega.Detalles.FirstOrDefault(d => d.DetallePedido.ItemCode == entregaSolicitudArticulo.Codigo && d.DetallePedido.EstadoArticuloId == entregaSolicitudArticulo.IdEstadoArticulo);


                            if (eFDetalleEntrega != null)
                            {
                                eFDetalleEntrega.Cantidad = entregaSolicitudArticulo.CantidadEntrega;
                                contexto.Update(eFEntrega);
                            }
                            else
                            {
                                eFDetalleEntrega = new EFDetalleEntrega();
                                eFDetalleEntrega.EntregaId = eFEntrega.EntregaId;
                                eFDetalleEntrega.Cantidad = entregaSolicitudArticulo.CantidadEntrega;
                                eFDetalleEntrega.DetallePedidoId = eFEntrega.Pedido.DetallesXPedido.FirstOrDefault(d => d.ItemCode == entregaSolicitudArticulo.Codigo && d.EstadoArticuloId == entregaSolicitudArticulo.IdEstadoArticulo).DetallePedidoId;
                                contexto.Add(eFDetalleEntrega);
                            }

                        }

                        contexto.SaveChanges();

                        tran.Commit();

                        return true;
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Este método retorna un booleano si el viaje existe o no
        /// </summary>       
        /// <param name="vehiculoEntregaId">2</param>
        /// <returns>bool</returns>
        public bool ValidarViaje(int vehiculoEntregaId)
        {
            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                EFVehiculoEntrega eFVehiculoEntrega = contexto.VehiculoEntregas.FirstOrDefault(v => v.VehiculoEntregaId == vehiculoEntregaId);

                if (eFVehiculoEntrega != null)
                {
                    respuesta = true;
                }
            }

            return respuesta;
        }

        /// <summary>
        /// Este método retorna un objeto que representa un viaje(con entregas y artículos asociados)
        /// </summary>       
        /// <param name="vehiculoEntregaId">2</param>
        /// <returns>ObtenerViajeEntregasRespuesta</returns>
        public ObtenerViajeEntregasRespuesta ObtenerViajeEntregas(int vehiculoEntregaId)
        {
            ObtenerViajeEntregasRespuesta obtenerViajeEntregasRespuesta = new ObtenerViajeEntregasRespuesta();

            using (Contexto contexto = new Contexto())
            {
                EFVehiculoEntrega eFVehiculoEntrega = contexto.VehiculoEntregas
                    .Include(tv => tv.Vehiculo.TipoVehiculo)
                    .Include("VehiculoEntregasDetalles.Entrega.Detalles.DetallePedido.EstadoArticulo")
                    .Include("VehiculoEntregasDetalles.Entrega.Detalles.DetallePedido.Pedido")
                    .FirstOrDefault(ve => ve.VehiculoEntregaId == vehiculoEntregaId);

                obtenerViajeEntregasRespuesta.TipoVehiculo = eFVehiculoEntrega.Vehiculo.TipoVehiculo.TipoVehiculo;
                obtenerViajeEntregasRespuesta.Placa = eFVehiculoEntrega.Vehiculo.Placa;
                obtenerViajeEntregasRespuesta.CapacidadVehiculo = eFVehiculoEntrega.Vehiculo.Capacidad.ToString();
                obtenerViajeEntregasRespuesta.TotalEntregasAsociadas = eFVehiculoEntrega.VehiculoEntregasDetalles.Count.ToString();
                obtenerViajeEntregasRespuesta.CantidadTotal = eFVehiculoEntrega.VehiculoEntregasDetalles.Select(d => d.Entrega.Detalles.Select(dd => dd.Cantidad).Sum()).Sum().ToString();
                obtenerViajeEntregasRespuesta.UnidadesTotales = string.Empty;
                obtenerViajeEntregasRespuesta.UnidadesCanastas = string.Empty;

                int numeroEntrega = 1;

                obtenerViajeEntregasRespuesta.Entregas = new List<ObtenerViajeEntregasRespuestaEntregas>();

                foreach (EFEntrega eFEntrega in eFVehiculoEntrega.VehiculoEntregasDetalles.Select(e => e.Entrega).OrderBy(o => o.FechaEntrega))
                {
                    ObtenerViajeEntregasRespuestaEntregas entrega = new ObtenerViajeEntregasRespuestaEntregas()
                    {
                        NumeroEntrega = numeroEntrega.ToString(),
                        NumeroPedido = $"{eFEntrega.Pedido.WhsCode.Substring(eFEntrega.Pedido.WhsCode.IndexOf("-") + 1)}-{eFEntrega.Pedido.NumeroPedido}",
                        Cliente = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFEntrega.Pedido.WhsCode).WhsName,
                        Codigo = eFEntrega.Pedido.WhsCode,
                        Zona = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFEntrega.Pedido.WhsCode).Zona,
                        FechaEntrega = eFEntrega.FechaEntrega.ToString("dd/MM/yyyy"),
                        HoraEntrega = eFEntrega.FechaEntrega.ToString("hh:mm"),
                        Cantidad = eFEntrega.Detalles.Select(d => d.Cantidad).Sum().ToString(),
                        Unidades = string.Empty
                    };

                    numeroEntrega++;

                    entrega.Articulos = new List<ObtenerViajeEntregasRespuestaArticulos>();

                    foreach (EFDetalleEntrega eFDetalleEntrega in eFEntrega.Detalles)
                    {
                        ObtenerViajeEntregasRespuestaArticulos articulo = new ObtenerViajeEntregasRespuestaArticulos()
                        {
                            Codigo = eFDetalleEntrega.DetallePedido.ItemCode,
                            Nombre = contexto.Articulos.FirstOrDefault(a => a.ItemCode == eFDetalleEntrega.DetallePedido.ItemCode).ItemName,
                            Estado = eFDetalleEntrega.DetallePedido.EstadoArticulo.Nombre,
                            Cantidad = eFDetalleEntrega.Cantidad.ToString(),
                            UnidadMedida = contexto.Articulos.FirstOrDefault(a => a.ItemCode == eFDetalleEntrega.DetallePedido.ItemCode).SalUnitMsr,
                            Observaciones = string.Empty,
                            Observacion = eFDetalleEntrega.DetallePedido.Observacion
                        };

                        entrega.Articulos.Add(articulo);

                    }

                    obtenerViajeEntregasRespuesta.Entregas.Add(entrega);

                }

            }

            return obtenerViajeEntregasRespuesta;

        }

        public ObtenerPedidoDistribucion ObtenerPedidoDistribucionxId(int pedidoId)
        {
            EFPedido eFPedido = null;

            using (Contexto contexto = new Contexto())
            {
                eFPedido = contexto.Pedidos
                    .Include(e => e.EstadoPedido)
                    .Include(u => u.Usuario)
                    .FirstOrDefault(p => p.PedidoId == pedidoId);

                ObtenerPedidoDistribucion obtenerPedidoRespuesta = null;

                if (eFPedido != null)
                {
                    string numeroPedido = eFPedido.NumeroPedido == null ? string.Empty : eFPedido.NumeroPedido.Value.ToString();

                    EFBodega bodega = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFPedido.WhsCode);

                    obtenerPedidoRespuesta = new ObtenerPedidoDistribucion()
                    {
                        Codigo = eFPedido.NumeroPedido == null ? string.Empty : $"{eFPedido.WhsCode.Substring(eFPedido.WhsCode.LastIndexOf("-") + 1)}-{numeroPedido}",
                        FechaSolicitud = eFPedido.FechaPedido.Date.ToString("dd/MM/yyyy"),
                        Estado = eFPedido.EstadoPedido.Nombre,
                        Cliente = bodega == null ? null : bodega.WhsName,
                        Zona = bodega == null ? null : bodega.Zona
                    };

                    obtenerPedidoRespuesta.Detalles = new List<ObtenerPedidoDistribucionDetalle>();

                    foreach (EFDetallePedido eFDetallePedido in contexto.DetallesPedido.Include(e => e.EstadoArticulo).Where(d => d.PedidoId == pedidoId))
                    {
                        EFArticulo eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode.Trim() == eFDetallePedido.ItemCode.Trim());
                        EFArticuloBodega eFArticuloBodega = contexto.ArticulosXBodega.FirstOrDefault(ab => ab.WhsCode == eFPedido.SolicitudPara && ab.ItemCode == eFDetallePedido.ItemCode);

                        ObtenerPedidoDistribucionDetalle detalle = new ObtenerPedidoDistribucionDetalle()
                        {
                            Codigo = eFArticulo.ItemCode,
                            Nombre = eFArticulo.ItemName,
                            Estado = eFDetallePedido.EstadoArticulo.Nombre,
                            CantidadSolicitada = eFDetallePedido.Cantidad.ToString(),
                            UnidadMedida = eFArticulo.SalUnitMsr,
                            CantidadAprobada = eFDetallePedido.CantidadAprobada.ToString(),
                            StockDisponible = eFArticuloBodega.OnHand == null ? string.Empty : eFArticuloBodega.OnHand.ToString()
                        };

                        obtenerPedidoRespuesta.Detalles.Add(detalle);
                    }
                }

                return obtenerPedidoRespuesta;
            }
        }

        /// <summary>
        /// Actualiza el pedido y las entregas al estado enrutamiento
        /// </summary>
        /// <param name="idPedido">6</param>
        /// <param name="idEstado">7</param>
        /// <returns>Booleano</returns>
        public bool ActualizarEstadoAPedido(int ididPedido, int idEstado)
        {
            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                EFPedido eFPedido = contexto.Pedidos.Include(e => e.EntregasXPedido).FirstOrDefault(p => p.PedidoId == ididPedido);

                if (eFPedido != null)
                {
                    eFPedido.EstadoPedidoId = idEstado;

                    foreach (EFEntrega efEntrega in eFPedido.EntregasXPedido)
                    {
                        efEntrega.EstadoEntregaId = idEstado;
                        contexto.Update(efEntrega);
                        contexto.SaveChanges();
                    }
                    contexto.Update(eFPedido);
                    contexto.SaveChanges();
                    respuesta = true;
                }
            }

            return respuesta;
        }

        /// <summary>
        /// Retorna una lista de entregas 
        /// </summary>
        /// <param name="id">Id del pedido</param>
        /// <returns>lista de entregas</returns>
        public EntregaRespuesta ObtenerEntregasPedidoxId(int id)
        {
            EntregaRespuesta respuesta = null;

            using (Contexto contexto = new Contexto())
            {
                EFPedido pedido = contexto.Pedidos.Include(e => e.EstadoPedido).Include("DetallesXPedido").FirstOrDefault(p => p.PedidoId == id);
                EFBodega cliente = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == pedido.WhsCode);

                respuesta = new EntregaRespuesta()
                {
                    NumeroPedido = $"{pedido.WhsCode.Substring(pedido.WhsCode.LastIndexOf("-") + 1)}-{pedido.NumeroPedido}",
                    Cliente = cliente.WhsName,
                    Zona = cliente.Zona,
                    Estado = pedido.EstadoPedido.Nombre
                };

                respuesta.Articulos = new List<EntregaArticulo>();

                EFArticulo efArticulo = null;

                foreach (EFDetallePedido detalle in pedido.DetallesXPedido)
                {
                    if (detalle.CantidadAprobada == 0)
                    {
                        continue;
                    }

                    EntregaArticulo entregaArticulo = new EntregaArticulo()
                    {
                        IdEstadoArticulo = detalle.EstadoArticuloId,
                        DetallePedidoId = detalle.DetallePedidoId,
                        CantidadAprobada = detalle.CantidadAprobada != null ? detalle.CantidadAprobada.Value : 0,
                        Codigo = detalle.ItemCode,
                        Observacion = detalle.Observacion
                    };

                    efArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode == detalle.ItemCode);

                    entregaArticulo.Nombre = efArticulo.ItemName;
                    entregaArticulo.UnidadMedida = efArticulo.SalUnitMsr;

                    EFEstadoArticulo eFEstadoPedido = contexto.EstadosArticulo.FirstOrDefault(e => e.EstadoArticuloId == detalle.EstadoArticuloId);

                    entregaArticulo.Estado = eFEstadoPedido.Nombre;

                    respuesta.Articulos.Add(entregaArticulo);

                }

                List<EFEntrega> entregas = contexto.Entregas
                    .Include("PesajesEntrega.EstadoEntrega")
                    .Include(tv => tv.TipoVehiculo)
                    .Include("Detalles.DetallePedido").Where(e => e.PedidoId == id).ToList();

                respuesta.NumeroEntregas = entregas.Count().ToString();

                respuesta.Entregas = new List<Entrega>();

                foreach (EFEntrega efEntrega in entregas.OrderBy(f => f.FechaEntrega))
                {
                    Entrega entrega = new Entrega()
                    {
                        EntregaId = efEntrega.EntregaId,
                        FechaEntrega = efEntrega.FechaEntrega.ToString("dd/MM/yyyy"),
                        HoraEntrega = efEntrega.FechaEntrega.ToString("HH:mm"),
                        NombreTipoVehiculo = efEntrega.TipoVehiculo.TipoVehiculo,
                        CapacidadTipoVehiculo = efEntrega.TipoVehiculo.Capacidad.ToString(),
                        CantidadEntrega = efEntrega.Detalles.Select(d => d.Cantidad).Sum(),
                        FechaHoraEntrega = efEntrega.FechaEntrega
                    };

                    entrega.Detalles = new List<EntregaDetalle>();

                    if (efEntrega.PesajesEntrega != null)
                    {
                        string estadoEntrega = EstadosEntregasEnum.En_Tránsito.ToString().Trim().ToLower().Replace("_", " ");

                        entrega.FinalizadoRecepcion =
                            contexto.PesajesEntrega
                            .Where(i => i.EntregaId == entrega.EntregaId && i.EstadoEntrega.Nombre.Trim().ToLower() == estadoEntrega)
                            .Count() > 0;
                    }

                    foreach (EFDetalleEntrega efDetalle in efEntrega.Detalles)
                    {
                        EntregaDetalle entregaDetalle = new EntregaDetalle()
                        {
                            DetalleEntregaId = efDetalle.DetalleEntregaId,
                            DetallePedidoId = efDetalle.DetallePedidoId,
                            Cantidad = efDetalle.Cantidad,
                            Observacion = efDetalle.DetallePedido.Observacion
                        };

                        efArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode == efDetalle.DetallePedido.ItemCode);
                        entregaDetalle.CodigoArticulo = efArticulo.ItemCode;
                        entregaDetalle.NombreArticulo = efArticulo.ItemName;

                        entrega.Detalles.Add(entregaDetalle);
                    }

                    respuesta.Entregas.Add(entrega);

                    entrega.CantidadTotal = entrega.Detalles.Select(d => d.Cantidad).Sum();

                }

            }

            return respuesta;
        }

        /// <summary>
        /// Obtiene el vehiculo , auxiliar , conductor y detalles de entregas asociadas al viaje de entregas , con capacidad de más entregas
        /// </summary>
        /// <param name="id">Id del vehiculo</param>        
        /// <returns>Objeto de tipo VehiculoEntrega</returns>
        public VehiculoEntrega ObtenerVehiculoEntregas(int id)
        {
            EFVehiculoEntrega efVehiculoEntrega = null;

            using (Contexto contexto = new Contexto())
            {
                efVehiculoEntrega = contexto.VehiculoEntregas
                    .Include("Vehiculo.TipoVehiculo")
                    .Include("VehiculoEntregasDetalles.Entrega.Detalles")
                    .Include("VehiculoEntregasDetalles.Entrega.EstadoEntrega")
                    .OrderByDescending(od => od.FechaRegistro)
                    .FirstOrDefault(v => v.VehiculoId == id);
            }

            VehiculoEntrega vehiculoEntrega = null;

            if (efVehiculoEntrega != null)
            {
                vehiculoEntrega = new VehiculoEntrega();

                vehiculoEntrega.Detalles = new List<VehiculoEntregaDetalle>();

                decimal capacidadVehiculo = efVehiculoEntrega.Vehiculo.TipoVehiculo.Capacidad;

                decimal pesoEntregas = efVehiculoEntrega.VehiculoEntregasDetalles.Select(p => p.Entrega.Detalles.Select(d => d.Cantidad).Sum()).Sum();

                if (pesoEntregas <= capacidadVehiculo)
                {
                    vehiculoEntrega = this.mapper.Map<EFVehiculoEntrega, VehiculoEntrega>(efVehiculoEntrega);

                    vehiculoEntrega.Detalles = efVehiculoEntrega.VehiculoEntregasDetalles.Select(e => new VehiculoEntregaDetalle() { EntregaId = e.EntregaId }).ToList();

                    vehiculoEntrega.PesoEntregas = pesoEntregas;
                }
            }

            return vehiculoEntrega;

        }

        /// <summary>
        /// Crea o Actualiza una distribución
        /// </summary>
        /// <param name="distribucion">Objeto de tipo AsignarDistribucion</param>
        /// <returns></returns>
        public bool CrearActualizarDistribucion(DistribucionSolicitud distribucion)
        {
            EFVehiculoEntrega eFVehiculoEntrega = null;

            EFVehiculoEntregaDetalle efDetalle = null;

            EFEntrega eFEntrega = null;

            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        if (distribucion.NuevoViaje.Value == true)
                        {
                            eFVehiculoEntrega = new EFVehiculoEntrega()
                            {
                                UsuarioId = distribucion.UsuarioId,
                                MuelleId = distribucion.MuelleId,
                                ConductorId = distribucion.ConductorId,
                                AuxiliarId = distribucion.AuxiliarId,
                                VehiculoId = distribucion.VehiculoId,
                                FechaRegistro = distribucion.FechaRegistro
                            };
                            eFVehiculoEntrega.VehiculoEntregaId = 0;
                            List<EFVehiculoEntregaDetalle> efDetalles = new List<EFVehiculoEntregaDetalle>();

                            contexto.Add(eFVehiculoEntrega);
                            contexto.SaveChanges();

                            foreach (int entregaId in distribucion.EntregasIds)
                            {
                                efDetalle = new EFVehiculoEntregaDetalle()
                                {
                                    EntregaId = entregaId,
                                    VehiculoEntregaId = eFVehiculoEntrega.VehiculoEntregaId
                                };

                                efDetalles.Add(efDetalle);

                                eFEntrega = contexto.Entregas.FirstOrDefault(e => e.EntregaId == entregaId);
                                eFEntrega.EstadoEntregaId = distribucion.EstadoId;

                                contexto.Update(eFEntrega);
                                contexto.SaveChanges();

                            }

                            contexto.AddRange(efDetalles);
                        }

                        if (distribucion.NuevoViaje.Value == false)
                        {
                            eFVehiculoEntrega = contexto.VehiculoEntregas
                                .OrderByDescending(o => o.FechaRegistro)
                                .Include(d => d.VehiculoEntregasDetalles)
                                .FirstOrDefault(ve => ve.VehiculoId == distribucion.VehiculoId);

                            eFVehiculoEntrega.UsuarioId = distribucion.UsuarioId;
                            eFVehiculoEntrega.ConductorId = distribucion.ConductorId;
                            eFVehiculoEntrega.AuxiliarId = distribucion.AuxiliarId;
                            eFVehiculoEntrega.MuelleId = distribucion.MuelleId;

                            foreach (int entregaId in distribucion.EntregasIds)
                            {
                                efDetalle = new EFVehiculoEntregaDetalle()
                                {
                                    EntregaId = entregaId,
                                    VehiculoEntregaId = eFVehiculoEntrega.VehiculoEntregaId
                                };

                                eFVehiculoEntrega.VehiculoEntregasDetalles.Add(efDetalle);

                                eFEntrega = contexto.Entregas.FirstOrDefault(e => e.EntregaId == entregaId);
                                eFEntrega.EstadoEntregaId = distribucion.EstadoId;

                                contexto.Update(eFEntrega);
                                contexto.SaveChanges();

                            }

                            contexto.Update(eFVehiculoEntrega);
                        }


                        contexto.SaveChanges();

                        tran.Commit();
                        return true;

                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// AgregarEntregas
        /// </summary>
        /// <param name="entregas">Colección de entregas</param>       
        /// <returns>Booleano</returns>
        public bool AgregarEntregas(List<EntregaPedido> entregas)
        {
            List<EFEntrega> eFEntregas = this.mapper.Map<List<EntregaPedido>, List<EFEntrega>>(entregas);

            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        contexto.AddRange(eFEntregas);
                        contexto.SaveChanges();

                        tran.Commit();

                        return true;
                    }
                    catch
                    {
                        tran.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Este método obtiene el estado del pedido por el nombre
        /// </summary>
        /// <param name="estadoPedidoEnum">Indica el estado del pedido</param>
        /// <returns>El estado del pedido por nombre</returns>
        public EstadoPedido ObtenerEstadoPedidoxNombre(EstadosPedidoEnum estadoPedidoEnum)
        {
            EFEstadoPedido eFEstadoPedido = null;

            using (var contexto = new Contexto())
            {
                eFEstadoPedido = contexto.EstadosXPedido.FirstOrDefault(p => p.Nombre.Trim() == estadoPedidoEnum.ToString().Replace("_", " ").Trim());
            }

            EstadoPedido estadoPedido = null;

            if (eFEstadoPedido != null)
            {
                estadoPedido = this.mapper.Map<EFEstadoPedido, EstadoPedido>(eFEstadoPedido);
            }

            return estadoPedido;
        }

        /// <summary>
        /// Este método obtiene el número del pedido por el codigo de la bodega
        /// </summary>
        /// <param name="whsCode">Indica el código de la bodega</param>       
        /// <returns>2</returns>
        public int ObtenerNumeroPedidoXCodigoBodega(string whsCode)
        {
            using (Contexto contexto = new Contexto())
            {
                int nPedido = contexto.Pedidos.Include(d => d.EstadoPedido)
                    .Where(p => p.WhsCode == whsCode && p.EstadoPedido.Nombre != EstadosPedidoEnum.Borrador.ToString()).Count();

                return (nPedido + 1);
            }
        }

        /// <summary>
        /// Elimina entregas y detalles del pedido
        /// </summary>
        /// <param name="ids">Colección de ids de entregas</param>    
        /// <returns>Booleano</returns>
        public bool EliminarEntregas(List<int> ids)
        {
            bool respuesta = false;

            using (Contexto contexto = new Contexto())
            {
                List<EFEntrega> entregas = contexto.Entregas.Include(d => d.Detalles).Where(e => ids.Contains(e.EntregaId)).ToList();
                contexto.RemoveRange(entregas);
                contexto.SaveChanges();
                respuesta = true;
            }

            return respuesta;
        }

        /// <summary>
        /// Este método obtiene todos los registros
        /// </summary>
        /// <param name="desde">Indica desde que parametro obtendra los registros ejemplo: 1</param>
        /// <param name="hasta">Indica hasta que parametro obtendra los registros ejemplo: 10</param>
        /// <param name="whsCode">Indica el código de la bodega</param>
        /// <returns>Lista de todos los registros</returns>
        public List<PedidoRespuesta> ObtenerTodosRegistros(int desde, int hasta, string whsCode)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

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
                    ParameterName = "@whsCode",
                    Value = whsCode
                });

                List<PedidoRespuesta> pedidosRespuesta = contexto.LoadSPAutoMapper<PedidoRespuesta>("ObtenerTodosPedidos", dbParameters);

                if (pedidosRespuesta == null)
                {
                    pedidosRespuesta = new List<PedidoRespuesta>();
                }

                return pedidosRespuesta;
            }
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los registros
        /// </summary>
        /// <param name="whsCode">Indica el código de la bodega</param>
        /// <returns>Número de todos los registros</returns>
        public int ObtenerConteoTodosRegistros(string whsCode)
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@whsCode",
                    Value = whsCode
                });

                object result = contexto.LoadSPScalar("ObtenerConteoTodosPedidos", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los registros por filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro</param>
        /// <returns>Lista de todos los registros por filtro</returns>
        public List<PedidoRespuesta> ObtenerTodosRegistrosxFiltro(FiltroPedido filtro)
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

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@plantaBeneficio",
                    Value = filtro.CodigoPlantaBeneficio
                });


                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@plantaDerivados",
                    Value = filtro.CodigoPlantaDerivados
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@estado",
                    Value = filtro.Estado
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@fechaDesde",
                    Value = filtro.FechaDesde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@fechaHasta",
                    Value = filtro.FechaHasta
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@pendientes",
                    Value = filtro.Pendientes
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@numeropedido",
                    Value = filtro.Numeropedido
                });

                List<PedidoRespuesta> pedidosRespuesta = contexto.LoadSPAutoMapper<PedidoRespuesta>("ObtenerTodosPedidosxFiltro", dbParameters);

                if (pedidosRespuesta == null)
                {
                    pedidosRespuesta = new List<PedidoRespuesta>();
                }

                return pedidosRespuesta;
            }
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los registros por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro</param>
        /// <returns>Número de todos los registro realizado el filtro</returns>
        public int ObtenerConteoTodosRegistrosxFiltro(FiltroPedido filtro)
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                if (filtro.PlantaDerivados != null)
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@plantaDerivados",
                        Value = filtro.PlantaDerivados
                    });
                }

                if (filtro.PlantaBeneficio != null)
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@plantaBeneficio",
                        Value = filtro.PlantaBeneficio
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Estado))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@estado",
                        Value = filtro.Estado
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaDesde))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@fechaDesde",
                        Value = filtro.FechaDesde
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaHasta))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@fechaHasta",
                        Value = filtro.FechaHasta
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Pendientes))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@pendientes",
                        Value = filtro.Pendientes
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Numeropedido))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@numeropedido",
                        Value = filtro.Numeropedido
                    });
                }

                object result = contexto.LoadSPScalar("ObtenerConteoTodosPedidosxFiltro", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        public MotivoRespuesta ObtenerMotivoxId(int id)
        {
            EFMotivo eFMotivo = null;

            using (Contexto contexto = new Contexto())
            {
                eFMotivo = contexto.Motivos.FirstOrDefault(m => m.Activo && m.MotivoId == id);
            }

            MotivoRespuesta motivo = null;

            if (eFMotivo != null)
            {
                motivo = this.mapper.Map<EFMotivo, MotivoRespuesta>(eFMotivo);
            }

            return motivo;
        }

        public EntregaBO ObtenerEntregaxId(int id)
        {
            EFEntrega eFEntrega = new EFEntrega();
            EntregaBO entrega = null;

            using (Contexto contexto = new Contexto())
            {
                eFEntrega = contexto.Entregas.Include(e => e.Usuario).Include("Pedido.EstadoPedido").Include("Detalles.DetallePedido").Include("Detalles.DetallePedido.EstadoArticulo").FirstOrDefault(x => x.EntregaId == id);

                EFVehiculoEntregaDetalle eFVehiculoEntregaDetalle = contexto.VehiculoEntregasDetalles.Include("VehiculoEntrega.Vehiculo").Include(m => m.VehiculoEntrega.Muelle).FirstOrDefault(x => x.EntregaId == id);

                if (eFEntrega != null)
                {
                    EFTipoVehiculo eFTipoVehiculo = contexto.TiposVehiculo.FirstOrDefault(b => b.TipoVehiculoId == eFEntrega.TipoVehiculoId);

                    entrega = new EntregaBO()
                    {
                        PedidoId = eFEntrega.PedidoId,
                        CodigoPedido = $"{eFEntrega.Pedido.WhsCode.Substring(eFEntrega.Pedido.WhsCode.IndexOf("-") + 1)}-{eFEntrega.Pedido.NumeroPedido.ToString()}",
                        Cliente = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFEntrega.Pedido.WhsCode).WhsName,
                        Zona = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFEntrega.Pedido.WhsCode).Zona,
                        OrdenCompra = string.Empty,
                        FechaEntrega = eFEntrega.FechaEntrega.ToString("dd/MM/yyyy"),
                        HoraEntrega = eFEntrega.FechaEntrega.ToString("HH:mm"),
                        Estado = eFEntrega.Pedido.EstadoPedido.Nombre,
                        Placa = eFVehiculoEntregaDetalle != null ? eFVehiculoEntregaDetalle.VehiculoEntrega.Vehiculo.Placa : string.Empty,
                        TipoVehiculoId = eFTipoVehiculo.TipoVehiculoId,
                        TipoVehiculo = eFTipoVehiculo.TipoVehiculo,
                        CapacidadTipoVehiculo = contexto.TiposVehiculo.FirstOrDefault(b => b.TipoVehiculoId == eFEntrega.TipoVehiculoId).Capacidad.ToString(),
                        Usuario = eFEntrega.Usuario.Usuario,
                        NombresApellidos = eFEntrega.Usuario.Nombre,
                        FechaEntregaDT = eFEntrega.FechaEntrega
                    };

                    entrega.Detalles = new List<EntregaDetalleBO>();
                    List<EFDetalleEntrega> efDetalleEntregas = contexto.DetalleEntregas
                        .Include(e => e.Entrega)
                        .Include("DetallePedido")
                        .Where(e => e.Entrega.PedidoId == eFEntrega.PedidoId).ToList();

                    foreach (EFDetalleEntrega efDetalle in eFEntrega.Detalles)
                    {
                        EFArticulo eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode == efDetalle.DetallePedido.ItemCode);

                        EntregaDetalleBO detalleBo = new EntregaDetalleBO()
                        {
                            IdEstadoArticulo = efDetalle.DetallePedido.EstadoArticuloId,
                            DetalleEntregaId = efDetalle.DetalleEntregaId,
                            CantidadEntrega = efDetalle.Cantidad.ToString(),
                            Codigo = efDetalle.DetallePedido.ItemCode,
                            CantidadAprobada = efDetalle.DetallePedido.CantidadAprobada.ToString(),
                            EstadoArticulo = efDetalle.DetallePedido.EstadoArticulo.Nombre,
                            UnidadMedida = eFArticulo != null ? eFArticulo.SalUnitMsr : string.Empty,
                            Observacion = efDetalle.DetallePedido.Observacion
                        };

                        decimal cantidadAprobadaEntregas = efDetalleEntregas
                            .Where(d => d.DetallePedido.EstadoArticuloId == detalleBo.IdEstadoArticulo && d.DetallePedido.ItemCode == detalleBo.Codigo).ToList()
                            .Select(de => de.Cantidad).Sum();

                        detalleBo.CantidadPendiente = (Convert.ToDecimal(detalleBo.CantidadAprobada) - Convert.ToDecimal(cantidadAprobadaEntregas)).ToString();

                        detalleBo.Nombre = contexto.Articulos.FirstOrDefault(a => a.ItemCode == efDetalle.DetallePedido.ItemCode).ItemName;

                        entrega.Detalles.Add(detalleBo);
                    }

                    entrega.CantidadTotal = entrega.Detalles.Select(d => decimal.Parse(d.CantidadEntrega)).Sum().ToString();

                }
            }

            return entrega;

        }

        /// <summary>
        /// Actualiza entrega del pedido
        /// </summary>
        /// <param name="entrega">Entrega de un pedido</param>      
        /// <returns>Booleano</returns>
        public bool ActualizarEntrega(ActualizarEntrega entrega)
        {
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        EFEntrega eFEntrega = contexto.Entregas.Include(d => d.Detalles)
                            .FirstOrDefault(x => x.EntregaId == entrega.EntregaId);
                        eFEntrega.FechaActualizo = entrega.FechaActualizo;
                        eFEntrega.FechaEntrega = entrega.FechaHoraEntrega;
                        eFEntrega.EstadoEntregaId = entrega.EstadoEntregaId == null ? null : entrega.EstadoEntregaId;
                        //eFEntrega.MotivoEdicionId = entrega.MotivoEdicionId == null ? null : entrega.MotivoEdicionId;
                        eFEntrega.TipoVehiculoId = entrega.TipoVehiculoId;

                        List<EFDetalleEntrega> detallesEliminar = eFEntrega.Detalles.Where(i => !entrega.Detalles.Select(s => s.DetalleEntregaId).Contains(i.DetalleEntregaId)).ToList();
                        foreach (EFDetalleEntrega detalle in detallesEliminar)
                        {
                            eFEntrega.Detalles.Remove(detalle);
                        }

                        foreach (ActualizarEntregaDetalle detalle in entrega.Detalles)
                        {
                            if (detalle.DetalleEntregaId > 0)
                            {
                                EFDetalleEntrega efEditar = eFEntrega.Detalles.FirstOrDefault(d => d.DetalleEntregaId == detalle.DetalleEntregaId);
                                efEditar.Cantidad = detalle.Cantidad;
                            }

                            if (detalle.DetalleEntregaId == 0)
                            {
                                EFDetalleEntrega efNuevo = this.mapper.Map<ActualizarEntregaDetalle, EFDetalleEntrega>(detalle);
                                efNuevo.EntregaId = eFEntrega.EntregaId;
                                eFEntrega.Detalles.Add(efNuevo);
                            }
                        }

                        contexto.SaveChanges();
                        tran.Commit();
                        return true;
                    }
                    catch
                    {
                        tran.Rollback();

                        return false;

                    }
                }
            }
        }

        public List<string> ObtenerCodigosPedidosAPlanta(string SolicitudPara)
        {
            List<string> codigos = null;

            using (Contexto contexto = new Contexto())
            {
                codigos = contexto.Pedidos.
                    Where(w => w.SolicitudPara == SolicitudPara).
                    Select(p => $"{p.WhsCode.Substring(p.WhsCode.IndexOf("-") + 1)}-{p.NumeroPedido.ToString()}")
                    .ToList();
            }

            return codigos;
        }

        public bool ActualizarPedidoPlantaBeneficio(PedidoPlantaBeneficio pedido)
        {
            //this.mapper.Map<PedidoPlantaBeneficio, EFPedido>(pedido);
            EFPedido eFPedido;

            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        eFPedido = contexto.Pedidos.
                                    Include(de => de.DetallesXPedido).
                                    Where(p => p.PedidoId == pedido.PedidoId).FirstOrDefault();

                        if (eFPedido != null)
                        {
                            if (pedido.FechaAprobacionPlanta != null) eFPedido.FechaAprobacionPlanta = pedido.FechaAprobacionPlanta;
                            eFPedido.EstadoPedidoId = pedido.EstadoPedidoId;
                        }
                        contexto.Update(eFPedido);
                        contexto.SaveChanges();

                        foreach (PedidoPlantaBeneficioDetalle detalle in pedido.Detalles)
                        {
                            EFDetallePedido eFDetalle = contexto.DetallesPedido.FirstOrDefault(d => d.DetallePedidoId == detalle.DetallePedidoId);

                            if (eFDetalle != null)
                            {
                                eFDetalle.CantidadAprobada = detalle.CantidadAprobada;
                                contexto.Update(eFDetalle);
                                contexto.SaveChanges();
                            }

                        }

                        tran.Commit();
                        return true;
                    }
                    catch
                    {
                        tran.Rollback();
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Este método obtiene todos los pedidos a distribución por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro</param>
        /// <returns>Lista de todos los pedidos en despachos realizado el filtro</returns>
        public List<PedidoDistribucionRespuesta> ObtenerTodosPedidosADistribucionxFiltro(FiltroPedidoDistribucion filtro)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = filtro.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = filtro.Hasta
                });

                if (!string.IsNullOrEmpty(filtro.Zona))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Zona",
                        Value = filtro.Zona
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Estado))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Estado",
                        Value = filtro.Estado
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Cliente))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Cliente",
                        Value = filtro.Cliente
                    });
                }

                if (!string.IsNullOrEmpty(filtro.CodigoPedido))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@CodigoPedido",
                        Value = filtro.CodigoPedido
                    });
                }

                if (!string.IsNullOrEmpty(filtro.FechaSolicitud))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@FechaSolicitud",
                        Value = filtro.FechaSolicitud
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Entregas))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Entregas",
                        Value = filtro.Entregas
                    });
                }

                List<PedidoDistribucionRespuesta> pedidosRespuesta = contexto.LoadSPCustomMapper<PedidoDistribucionRespuesta>("ObtenerTodosPedidosADistribucionxFiltro", dbParameters, mapeadorPedidoDistribucion);

                if (pedidosRespuesta == null)
                {
                    pedidosRespuesta = new List<PedidoDistribucionRespuesta>();
                }

                return pedidosRespuesta;
            }
        }

        /// <summary>
        /// Este método obtiene todos los pedidos a la planta de Beneficio por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro</param>
        /// <returns>Lista de todos los pedidos de la planta de beneficio realizado el filtro</returns>
        public List<PedidoBeneficioRespuesta> ObtenerTodosPedidosAbiertosxFiltro(FiltroPedidoBeneficio filtro)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = filtro.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = filtro.Hasta
                });

                if (!string.IsNullOrEmpty(filtro.Zona))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Zona",
                        Value = filtro.Zona
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Estado))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Estado",
                        Value = filtro.Estado
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Cliente))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Cliente",
                        Value = filtro.Cliente
                    });
                }

                if (!string.IsNullOrEmpty(filtro.CodigoPedido))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@CodigoPedido",
                        Value = filtro.CodigoPedido
                    });
                }

                if (!string.IsNullOrEmpty(filtro.DiasEntrega))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@DiasEntrega",
                        Value = filtro.DiasEntrega
                    });
                }

                if (!string.IsNullOrEmpty(filtro.FechaEntrega))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@FechaEntrega",
                        Value = filtro.FechaEntrega
                    });
                }

                if (!string.IsNullOrEmpty(filtro.FechaSolicitud))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@FechaSolicitud",
                        Value = filtro.FechaSolicitud
                    });
                }

                List<PedidoBeneficioRespuesta> pedidosRespuesta = contexto.LoadSPCustomMapper<PedidoBeneficioRespuesta>("ObtenerTodosPedidosAbiertosxFiltro", dbParameters, mapeadorPedidoBeneficio);

                if (pedidosRespuesta == null)
                {
                    pedidosRespuesta = new List<PedidoBeneficioRespuesta>();
                }

                return pedidosRespuesta;
            }
        }

        /// <summary>
        /// Este método obtiene todos los pedidos aceptados y parciales filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro</param>
        /// <returns>List<PedidoBeneficioRespuesta></returns>
        public List<PedidoBeneficioRespuesta> ObtenerTodosPedidosAceptadosxFiltro(FiltroPedidoBeneficio filtro)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = filtro.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = filtro.Hasta
                });

                if (!string.IsNullOrEmpty(filtro.Zona))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Zona",
                        Value = filtro.Zona
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Estado))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Estado",
                        Value = filtro.Estado
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Cliente))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Cliente",
                        Value = filtro.Cliente
                    });
                }

                if (!string.IsNullOrEmpty(filtro.CodigoPedido))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@CodigoPedido",
                        Value = filtro.CodigoPedido
                    });
                }

                if (!string.IsNullOrEmpty(filtro.DiasEntrega))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@DiasEntrega",
                        Value = filtro.DiasEntrega
                    });
                }

                if (!string.IsNullOrEmpty(filtro.FechaEntrega))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@FechaEntrega",
                        Value = filtro.FechaEntrega
                    });
                }

                if (!string.IsNullOrEmpty(filtro.FechaSolicitud))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@FechaSolicitud",
                        Value = filtro.FechaSolicitud
                    });
                }

                List<PedidoBeneficioRespuesta> pedidosRespuesta = contexto.LoadSPCustomMapper<PedidoBeneficioRespuesta>("ObtenerTodosPedidosAceptadosxFiltro", dbParameters, mapeadorPedidoBeneficio);

                if (pedidosRespuesta == null)
                {
                    pedidosRespuesta = new List<PedidoBeneficioRespuesta>();
                }

                return pedidosRespuesta;
            }
        }

        /// <summary>
        /// Este método obtiene todos los pedidos a la planta de Beneficio por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor del filtro</param>
        /// <returns>Lista de todos los pedidos de la planta de beneficio realizado el filtro</returns>
        public List<PedidoBeneficioRespuesta> ObtenerTodosPedidosABenficioxFiltro(FiltroPedidoBeneficio filtro)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = filtro.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = filtro.Hasta
                });

                if (!string.IsNullOrEmpty(filtro.Zona))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Zona",
                        Value = filtro.Zona
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Estado))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Estado",
                        Value = filtro.Estado
                    });
                }

                if (!string.IsNullOrEmpty(filtro.Cliente))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@Cliente",
                        Value = filtro.Cliente
                    });
                }

                if (!string.IsNullOrEmpty(filtro.CodigoPedido))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@CodigoPedido",
                        Value = filtro.CodigoPedido
                    });
                }

                if (!string.IsNullOrEmpty(filtro.DiasEntrega))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@DiasEntrega",
                        Value = filtro.DiasEntrega
                    });
                }

                if (!string.IsNullOrEmpty(filtro.FechaEntrega))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@FechaEntrega",
                        Value = filtro.FechaEntrega
                    });
                }

                if (!string.IsNullOrEmpty(filtro.FechaSolicitud))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@FechaSolicitud",
                        Value = filtro.FechaSolicitud
                    });
                }

                List<PedidoBeneficioRespuesta> pedidosRespuesta = contexto.LoadSPCustomMapper<PedidoBeneficioRespuesta>("ObtenerTodosPedidosABeneficioxFiltro", dbParameters, mapeadorPedidoBeneficio);

                if (pedidosRespuesta == null)
                {
                    pedidosRespuesta = new List<PedidoBeneficioRespuesta>();
                }

                return pedidosRespuesta;
            }
        }

        /// <summary>
        /// Obtiene el stock de un artículo en la(s) bodega(s) EVO 
        /// </summary>
        /// <param name="codigoArticulo">Código del artículo</param>
        /// <param name="prefijoBodegas">Prefijo de las bodegas</param>
        /// <returns>Retorna la cantidad en decimal</returns>
        public decimal ObtenerStockArticuloBodegas(string codigoArticulo, string prefijoBodegas)
        {
            decimal stock = 0;

            using (Contexto contexto = new Contexto())
            {
                stock = contexto.ArticulosXBodega.Where(
                      x => x.OnHand != null && x.WhsCode.Trim() != "PB-PRSMT"
                      && x.ItemCode.Trim() == codigoArticulo.Trim()
                      && x.WhsCode.Substring(0, x.WhsCode.IndexOf("-")) == prefijoBodegas
                      ).Sum(y => y.OnHand.Value);
            }

            return stock;

        }

        /// <summary>
        /// Este método obtiene el conteo de todos los pedidos a la planta de Beneficio
        /// </summary>
        /// <returns>Número de todos los pedidos a planta de beneficio</returns>
        public object ObtenerConteoTodosPedidosABeneficio()
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosPedidosABeneficio");

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método actualiza el pedido
        /// </summary>
        /// <param name="pedido">Indica el pedido a realizar</param>
        /// <returns>Verdadero o falso si se pudo actualizar el pedido</returns>
        public bool ActualizarPedido(Pedido pedido)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@PedidoId",
                    Value = pedido.PedidoId
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@WhsCode",
                    Value = pedido.WhsCode
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@SolicitudPara",
                    Value = pedido.SolicitudPara
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@UsuarioId",
                    Value = pedido.UsuarioId
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@EstadoPedidoId",
                    Value = pedido.EstadoPedidoId
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@FechaPedido",
                    Value = pedido.FechaPedido
                });

                if (pedido.FechaEntrega != null)
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@FechaEntrega",
                        Value = pedido.FechaEntrega
                    });
                }

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@NumeroPedido",
                    Value = pedido.NumeroPedido
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Detalles",
                    Value = pedido.DetallesSerializados
                });

                contexto.LoadSPScalar("ActualizarPedidoPuntoVenta", dbParameters);

                return true;
            }
        }

        /// <summary>
        /// Este método obtiene todos los pedidos a planta de Beneficio
        /// </summary>
        /// <param name="desde">Indica el parametro desde donde se va obtener el pedido ejemplo: 1</param>
        /// <param name="hasta">Indica el parametro hasta donde se va obtener el pedido ejemplo: 10</param>
        /// <returns>Lista de todos los pedidos a planta de beneficio</returns>
        public List<PedidoBeneficioRespuesta> ObtenerTodosPedidosABeneficio(int desde, int hasta)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

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

                List<PedidoBeneficioRespuesta> pedidos = contexto.LoadSPAutoMapper<PedidoBeneficioRespuesta>("ObtenerTodosPedidosABeneficio", dbParameters);

                if (pedidos == null)
                {
                    pedidos = new List<PedidoBeneficioRespuesta>();
                }

                return pedidos;
            }
        }

        /// <summary>
        /// Este método obtiene todos los pedidos a distribución
        /// </summary>
        /// <param name="desde">Indica el parametro desde donde se va obtener el pedido ejemplo: 1</param>
        /// <param name="hasta">Indica el parametro hasta donde se va obtener el pedido ejemplo: 10</param>
        /// <returns>Lista de todos los pedidos a distribución</returns>
        public List<PedidoDistribucionRespuesta> ObtenerTodosPedidosADistribucion(int desde, int hasta)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

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

                List<PedidoDistribucionRespuesta> pedidos = contexto.LoadSPAutoMapper<PedidoDistribucionRespuesta>("ObtenerTodosPedidosADistribucion", dbParameters);

                if (pedidos == null)
                {
                    pedidos = new List<PedidoDistribucionRespuesta>();
                }

                return pedidos;
            }
        }

        /// <summary>
        /// Este método obtiene todas las cantidades del pedido por el id del estado
        /// </summary>
        /// <param name="estadoPedidoId">Indica el id del pedido</param>
        /// <returns>Número de todos los id por el estado</returns>
        public int ObtenerTodosCantidadPedidosxEstadoId(int estadoPedidoId)
        {
            int cantidad = 0;

            using (Contexto contexto = new Contexto())
            {
                cantidad = contexto.Pedidos.Where(p => p.EstadoPedidoId == estadoPedidoId).ToList().Count();
            }

            return cantidad;
        }

        /// <summary>
        /// Este método comprueba si el pedido existe
        /// </summary>
        /// <param name="pedido">Indica el pedido</param>
        /// <returns>Verdadero o falso si existe el pedido</returns>
        public bool ExistePedido(ObtenerPedidoBorradorPeticion pedido)
        {
            bool respuesta;

            using (Contexto contexto = new Contexto())
            {
                respuesta = (contexto.Pedidos.FirstOrDefault(p => p.WhsCode == pedido.WhsCode &&
                    p.SolicitudPara == pedido.SolicitudPara &&
                    p.EstadoPedidoId == pedido.EstadoPedidoId) != null);
            }

            return respuesta;
        }

        /// <summary>
        /// Este método obtiene todos los estados del pedido
        /// </summary>
        /// <returns>Lista de todos los estados del pedido</returns>
        public List<EstadoPedido> ObtenerTodosEstadosPedido()
        {
            List<EFEstadoPedido> eFEstadosPedido = null;

            using (Contexto contexto = new Contexto())
            {
                eFEstadosPedido = contexto.EstadosXPedido.Where(e => e.Activo).ToList();
            }

            List<EstadoPedido> estadosPedido = null;

            if (eFEstadosPedido.Count > 0)
            {
                estadosPedido = this.mapper.Map<List<EFEstadoPedido>, List<EstadoPedido>>(eFEstadosPedido);
            }

            return estadosPedido;
        }

        /// <summary>
        /// Este método obtiene el id del pedido a consultar
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <returns>Instancia de tipo ConsultaPedidoRespuesta el cual consulta el pedido por el id</returns>
        public ConsultaPedidoRespuesta ObtenerConsultaPedidoxId(int pedidoId)
        {
            EFPedido eFPedido = null;

            using (Contexto contexto = new Contexto())
            {
                eFPedido = contexto.Pedidos
                    .Include(e => e.EstadoPedido)
                    .FirstOrDefault(p => p.PedidoId == pedidoId);
            }

            ConsultaPedidoRespuesta consultaPedidoRespuesta = null;

            if (eFPedido != null)
            {
                consultaPedidoRespuesta = new ConsultaPedidoRespuesta()
                {
                    NumeroPedido = eFPedido.NumeroPedido == null ? string.Empty : $"{eFPedido.WhsCode.Substring(eFPedido.WhsCode.LastIndexOf("-") + 1)}-{eFPedido.NumeroPedido.ToString()}",
                    FechaSolicitud = eFPedido.FechaPedido.ToString("dd/MM/yyyy"),
                    FechaEnvio = eFPedido.FechaAprobacionPlanta == null ? String.Empty : eFPedido.FechaAprobacionPlanta.Value.ToString("dd/MM/yyyy"),
                    FechaRecibido = eFPedido.FechaEntrega == null ? String.Empty : eFPedido.FechaEntrega.Value.ToString("dd/MM/yyyy"),
                    FechaCargueEnVehiculo = string.Empty,
                    NombreConductor = string.Empty,
                    PlacaVehiculo = string.Empty,
                    NombreAuxiliar = string.Empty,
                    EstadoPedido = eFPedido.EstadoPedido.Nombre
                };

                consultaPedidoRespuesta.Detalles = new List<ConsultaDetallePedidoRespuesta>();

                using (Contexto contexto = new Contexto())
                {
                    consultaPedidoRespuesta.Planta = contexto.Bodegas.FirstOrDefault(x => x.WhsCode == eFPedido.SolicitudPara).WhsName;
                    foreach (EFDetallePedido eFDetallePedido in contexto.DetallesPedido.Include(e => e.EstadoArticulo).Where(d => d.PedidoId == pedidoId))
                    {
                        EFArticulo eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode.Trim() == eFDetallePedido.ItemCode.Trim());

                        ConsultaDetallePedidoRespuesta consultaDetallePedidoRespuesta = new ConsultaDetallePedidoRespuesta()
                        {
                            CodigoArticulo = eFArticulo.ItemCode,
                            NombreArticulo = eFArticulo.ItemName,
                            EstadoArticulo = eFDetallePedido.EstadoArticulo.Nombre,
                            CantidadSolicitada = eFDetallePedido.Cantidad.ToString(),
                            UnidadMedida = eFArticulo.SalUnitMsr,
                            CantidadAprobada = eFDetallePedido.CantidadAprobada.ToString(),
                            FechaEntrega = string.Empty,
                            CostoTraslado = eFArticulo.Price == null ? string.Empty : eFArticulo.Price.Value.ToString(),
                            CostoTransporte = string.Empty,
                            Observacion = eFDetallePedido.Observacion
                        };

                        consultaPedidoRespuesta.Detalles.Add(consultaDetallePedidoRespuesta);
                    }
                }
            }

            return consultaPedidoRespuesta;
        }

        /// <summary>
        /// Este método obtiene el pedido por el id del pedido
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <returns>Instancia de tipo ObtenerPedidoRespuesta el cual obtiene el pedido por id</returns>
        public ObtenerPedidoRespuesta ObtenerPedidoxId(int pedidoId)
        {
            EFPedido eFPedido = null;

            using (Contexto contexto = new Contexto())
            {
                eFPedido = contexto.Pedidos
                    .Include(e => e.EstadoPedido)
                    .FirstOrDefault(p => p.PedidoId == pedidoId);

            }

            ObtenerPedidoRespuesta obtenerPedidoRespuesta = null;

            if (eFPedido != null)
            {
                string numeroPedido = eFPedido.NumeroPedido == null ? string.Empty : eFPedido.NumeroPedido.Value.ToString();

                obtenerPedidoRespuesta = new ObtenerPedidoRespuesta()
                {
                    CodigoPedido = eFPedido.NumeroPedido == null ? string.Empty : $"{eFPedido.WhsCode.Substring(eFPedido.WhsCode.LastIndexOf("-") + 1)}-{numeroPedido}",
                    FechaPedido = eFPedido.FechaPedido,
                    SolicitudPara = eFPedido.SolicitudPara,
                    FechaEntrega = eFPedido.FechaEntrega == null ? null : eFPedido.FechaEntrega,
                    EstadoPedidoId = eFPedido.EstadoPedidoId,
                    SolicitudDe = eFPedido.WhsCode,
                    NumeroPedido = eFPedido.NumeroPedido.ToString()
                };

                obtenerPedidoRespuesta.Detalles = new List<ObtenerPedidoRespuestaDetalles>();

                using (Contexto contexto = new Contexto())
                {
                    foreach (EFDetallePedido eFDetallePedido in contexto.DetallesPedido.Include(e => e.EstadoArticulo).Where(d => d.PedidoId == pedidoId))
                    {
                        EFArticulo eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode.Trim() == eFDetallePedido.ItemCode.Trim());
                        EFArticuloBodega eFArticuloBodega = contexto.ArticulosXBodega.FirstOrDefault(ab => ab.WhsCode == obtenerPedidoRespuesta.SolicitudPara && ab.ItemCode == eFDetallePedido.ItemCode);

                        ObtenerPedidoRespuestaDetalles obtenerPedidoRespuestaDetalles = new ObtenerPedidoRespuestaDetalles()
                        {
                            DetallePedidoId = eFDetallePedido.DetallePedidoId,
                            CodigoArticulo = eFArticulo.ItemCode,
                            NombreArticulo = eFArticulo.ItemName,
                            EstadoArticulo = eFDetallePedido.EstadoArticuloId,
                            Cantidad = eFDetallePedido.Cantidad,
                            UnidadMedida = eFArticulo.SalUnitMsr,
                            Stock = (eFArticuloBodega.OnHand == null) ? string.Empty : eFArticuloBodega.OnHand.ToString(),
                            StockMinimo = (eFArticuloBodega.MinStock == null) ? string.Empty : eFArticuloBodega.MinStock.ToString(),
                            StockMaximo = eFArticuloBodega.MaxStock.ToString(),
                            PedidoSugerido = (eFArticuloBodega.MaxStock == null || eFArticuloBodega.MinStock == null)
                            ? string.Empty : (eFArticuloBodega.MaxStock - eFArticuloBodega.MinStock).ToString(),
                            CantidadAprobada = eFDetallePedido.CantidadAprobada == null ? null : eFDetallePedido.CantidadAprobada,
                            Observacion = eFDetallePedido.Observacion
                        };

                        obtenerPedidoRespuesta.Detalles.Add(obtenerPedidoRespuestaDetalles);
                    }
                }
            }

            return obtenerPedidoRespuesta;
        }

        /// <summary>
        /// Este método obtiene la solicitud del pedido en la planta
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <returns>Instancia de tipo PedidoEnPlantaRespuesta para obtener la solicitud del pedido en la planta</returns>
        public PedidoEnPlantaRespuesta ObtenerSolicitudPedidoEnPlanta(int pedidoId)
        {
            EFPedido eFPedido = null;

            using (Contexto contexto = new Contexto())
            {
                eFPedido = contexto.Pedidos
                    .Include(e => e.EstadoPedido)
                    .Include(u => u.Usuario)
                    .FirstOrDefault(p => p.PedidoId == pedidoId);

                PedidoEnPlantaRespuesta obtenerPedidoRespuesta = null;

                if (eFPedido != null)
                {
                    string numeroPedido = eFPedido.NumeroPedido == null ? string.Empty : eFPedido.NumeroPedido.Value.ToString();

                    EFBodega bodega = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFPedido.WhsCode);

                    obtenerPedidoRespuesta = new PedidoEnPlantaRespuesta()
                    {
                        Codigo = eFPedido.NumeroPedido == null ? string.Empty : $"{eFPedido.WhsCode.Substring(eFPedido.WhsCode.LastIndexOf("-") + 1)}-{numeroPedido}",
                        FechaSolicitud = eFPedido.FechaPedido.Date.ToString("dd/MM/yyyy"),
                        Estado = eFPedido.EstadoPedido.Nombre,
                        FechaAprobacionPlanta = eFPedido.FechaAprobacionPlanta == null ? string.Empty : eFPedido.FechaAprobacionPlanta.Value.Date.ToString("dd/MM/yyyy"),
                        FechaEntrega = eFPedido.FechaEntrega == null ? string.Empty : eFPedido.FechaEntrega.Value.Date.ToString("dd/MM/yyyy"),
                        Cliente = bodega == null ? null : bodega.WhsName,
                        Usuario = $"{eFPedido.Usuario.Nombre}({eFPedido.Usuario.Usuario})",
                        SolicitudPara = eFPedido.SolicitudPara,
                        FechaAprobacion = eFPedido.FechaAprobacionPlanta == null ? DateTime.Now.Date.ToString("dd/MM/yyyy") : eFPedido.FechaAprobacionPlanta.Value.Date.ToString("dd/MM/yyyy"),
                        Zona = bodega == null ? null : bodega.Zona,
                    };

                    obtenerPedidoRespuesta.PedidoDetallesRespuesta = new List<PedidoDetalleEnPlantaRespuesta>();

                    foreach (EFDetallePedido eFDetallePedido in contexto.DetallesPedido.Include(e => e.EstadoArticulo).Where(d => d.PedidoId == pedidoId))
                    {
                        EFArticulo eFArticulo = contexto.Articulos.FirstOrDefault(a => a.ItemCode.Trim() == eFDetallePedido.ItemCode.Trim());
                        EFArticuloBodega eFArticuloBodega = contexto.ArticulosXBodega.FirstOrDefault(ab => ab.WhsCode == obtenerPedidoRespuesta.SolicitudPara && ab.ItemCode == eFDetallePedido.ItemCode);

                        PedidoDetalleEnPlantaRespuesta pedidoDetalleEnPlantaRespuesta = new PedidoDetalleEnPlantaRespuesta()
                        {
                            DetallePedidoId = eFDetallePedido.DetallePedidoId,
                            Codigo = eFArticulo.ItemCode,
                            Nombre = eFArticulo.ItemName,
                            Estado = eFDetallePedido.EstadoArticulo.Nombre,
                            CantidadSolicitada = eFDetallePedido.Cantidad,
                            UnidadMedida = eFArticulo.SalUnitMsr,
                            CantidadAprobada = eFDetallePedido.CantidadAprobada,
                            StockDisponible = eFArticuloBodega.OnHand == null ? 0 : eFArticuloBodega.OnHand,
                            Observacion = eFDetallePedido.Observacion
                        };

                        obtenerPedidoRespuesta.PedidoDetallesRespuesta.Add(pedidoDetalleEnPlantaRespuesta);
                    }
                }

                return obtenerPedidoRespuesta;
            }
        }

        /// <summary>
        /// Este método obtiene todos los pedidos en estado abierto
        /// </summary>
        /// <param name="desde">Indica apartir desde que valor se obtendran los datos ejemplo: desde 1</param>
        /// <param name="hasta">Indica apartir hasta que valor se obtendran los datos ejemplo: hasta 10</param>
        /// <returns>Lista de negocio PedidoBeneficioRespuesta</returns>
        public List<PedidoBeneficioRespuesta> ObtenerPedidosAbiertos(int desde, int hasta)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

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

                List<PedidoBeneficioRespuesta> pedidos = contexto.LoadSPAutoMapper<PedidoBeneficioRespuesta>("ObtenerTodosPedidosAbiertos", dbParameters);

                if (pedidos == null)
                {
                    pedidos = new List<PedidoBeneficioRespuesta>();
                }

                return pedidos;
            }
        }

        /// <summary>
        /// Este método obtiene todos los pedidos en estado aceptado y aceptado parcial
        /// </summary>
        /// <param name="desde">Indica apartir desde que valor se obtendran los datos ejemplo: desde 1</param>
        /// <param name="hasta">Indica apartir hasta que valor se obtendran los datos ejemplo: hasta 10</param>
        /// <returns>Lista de negocio PedidoBeneficioRespuesta</returns>
        public List<PedidoBeneficioRespuesta> ObtenerPedidosAceptados(int desde, int hasta)
        {
            using (var contexto = new Contexto())
            {
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

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

                List<PedidoBeneficioRespuesta> pedidos = contexto.LoadSPAutoMapper<PedidoBeneficioRespuesta>("ObtenerTodosPedidosAceptados", dbParameters);

                if (pedidos == null)
                {
                    pedidos = new List<PedidoBeneficioRespuesta>();
                }

                return pedidos;
            }
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los pedidos en estado abiertos
        /// </summary>
        /// <returns>Número total de pedidos en estado abierto</returns>
        public object ObtenerConteoTodosPedidosAbiertos()
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosPedidosAbiertos");

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los pedidos en estado aprobado y aprobado parcial
        /// </summary>
        /// <returns>Número total de pedidos en estado aprobado y aprobado parcial</returns>
        public object ObtenerConteoTodosPedidosAceptados()
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosPedidosAceptados");

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        #endregion

        #region Métodos Privados
        /// <summary>
        /// Mapea un objeto DbDataReader a un objeto de tipo PedidoBeneficioRespuesta
        /// </summary>
        /// <param name="reader">DbDataReader</param>
        /// <returns>Instancia de objeto de tipo PedidoBeneficioRespuesta</returns>
        private PedidoBeneficioRespuesta mapeadorPedidoBeneficio(DbDataReader reader)
        {
            PedidoBeneficioRespuesta r = null;

            if (reader != null)
            {
                r = new PedidoBeneficioRespuesta()
                {
                    PedidoId = int.Parse(reader["PedidoId"].ToString()),
                    CodigoPedido = reader["CodigoPedido"].ToString(),
                    FechaSolicitud = reader["FechaSolicitud"].ToString(),
                    FechaEntrega = reader["FechaEntrega"].ToString(),
                    Estado = reader["Estado"].ToString(),
                    Cliente = reader["Cliente"].ToString(),
                    DiasEntrega = reader["DiasEntrega"].ToString(),
                    Zona = reader["Zona"].ToString()
                };

            }

            return r;
        }

        /// <summary>
        /// Mapea un objeto DbDataReader a un objeto de tipo PedidoDistribucionRespuesta
        /// </summary>
        /// <param name="reader">DbDataReader</param>
        /// <returns>Instancia de objeto de tipo PedidoDistribucionRespuesta</returns>
        private PedidoDistribucionRespuesta mapeadorPedidoDistribucion(DbDataReader reader)
        {
            PedidoDistribucionRespuesta r = null;

            if (reader != null)
            {
                r = new PedidoDistribucionRespuesta()
                {
                    PedidoId = int.Parse(reader["PedidoId"].ToString()),
                    CodigoPedido = reader["CodigoPedido"].ToString(),
                    FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString()).ToString("dd/MM/yyyy"),
                    Entregas = reader["Entregas"].ToString(),
                    Estado = reader["Estado"].ToString(),
                    Cliente = reader["Cliente"].ToString(),
                    OrdenCompra = string.Empty,
                    Zona = reader["Zona"].ToString()
                };
            }

            return r;
        }
        #endregion
    }
}