using EFCoreExtensions.ExtensionMethods;
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
    public class DAEntrega:DABase
    {
        /// <summary>
        /// Este método obtiene el estado de la entrega por el nombre
        /// </summary>
        /// <param name="estadoEntregaEnum">Indica el estado de la entrega</param>
        /// <returns>BOEstadoEntrega</returns>
        public BOEstadoEntrega ObtenerEstadoEntregaxNombre(EstadosEntregasEnum estadoEntregaEnum)
        {
            EFEstadoEntrega eFEstadoEntrega = null;

            using (var contexto = new Contexto())
            {
                eFEstadoEntrega = contexto.EstadosEntrega.FirstOrDefault(p => p.Nombre.Trim() == estadoEntregaEnum.ToString().Replace("_", " ").Trim());
            }

            BOEstadoEntrega bOEstadoEntrega = null;

            if (eFEstadoEntrega != null)
            {
                bOEstadoEntrega = this.mapper.Map<EFEstadoEntrega,BOEstadoEntrega>(eFEstadoEntrega);
            }

            return bOEstadoEntrega;
        }

        public object ObtenerConteoTodosEntregasEnrutamiento()
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                object result = contexto.LoadSPScalar("ObtenerConteoTodosEntregasEnrutamiento");

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }


        /// <summary>
        /// Obtiene todas las entregas en enrutamiento
        /// </summary>
        /// <param name="desde">Indica el parametro desde donde se va obtener el pedido ejemplo: 1</param>
        /// <param name="hasta">Indica el parametro hasta donde se va obtener el pedido ejemplo: 10</param>
        /// <returns>Lista de tipo EntregaDistribucionRespuesta</returns>
        public List<EntregaEnrutamientoRespuesta> ObtenerTodosEntregasEnrutamiento(int desde, int hasta)
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

                List<EntregaEnrutamientoRespuesta> entregas = contexto.LoadSPAutoMapper<EntregaEnrutamientoRespuesta>("ObtenerTodosEntregasEnrutamiento",dbParameters);

                if (entregas == null)
                {
                    entregas = new List<EntregaEnrutamientoRespuesta>();
                }

                return entregas;
            }
        }

        public BOEntrega ObtenerEntregaxEntregaId(int entregaId)
        {
            BOEntrega bOEntrega = null;
            EFEntrega eFEntrega = null;

            using (Contexto contexto=new Contexto())
            {
                 eFEntrega = contexto.Entregas
                    .Include("Detalles.DetallePedido.EstadoArticulo")                    
                    .Include(i=>i.Pedido)
                    .FirstOrDefault(e => e.EntregaId == entregaId);
            }

            if (eFEntrega!=null)
            {
                bOEntrega = this.mapper.Map<EFEntrega,BOEntrega>(eFEntrega);
            }

            return bOEntrega;

        }
   

        public EntregaBO ObtenerEntregaxId(int id)
        {
            EFEntrega eFEntrega = null;
            EntregaBO entrega = null;

            using (Contexto contexto = new Contexto())
            {
                eFEntrega = contexto.Entregas.Include(e => e.Usuario).Include("Pedido.EstadoPedido").Include("Detalles.DetallePedido").FirstOrDefault(x => x.EntregaId == id);

                EFVehiculoEntregaDetalle eFVehiculoEntregaDetalle = contexto.VehiculoEntregasDetalles.Include("VehiculoEntrega.Vehiculo").Include("VehiculoEntrega.Muelle").FirstOrDefault(x => x.EntregaId == id);

                if (eFEntrega != null)
                {
                    entrega = new EntregaBO()
                    {
                        CodigoCliente= contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFEntrega.Pedido.WhsCode).WhsCode,
                        WhsPlanta =eFEntrega.Pedido.SolicitudPara,
                        PedidoId = eFEntrega.PedidoId,
                        CodigoPedido = $"{eFEntrega.Pedido.WhsCode.Substring(0, eFEntrega.Pedido.WhsCode.IndexOf("-"))}-{eFEntrega.Pedido.NumeroPedido.ToString()}",
                        Cliente = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFEntrega.Pedido.WhsCode).WhsName,
                        Zona = contexto.Bodegas.FirstOrDefault(b => b.WhsCode == eFEntrega.Pedido.WhsCode).Zona,
                        OrdenCompra = string.Empty,
                        FechaEntrega = eFEntrega.FechaEntrega.ToString("dd/MM/yyyy"),
                        HoraEntrega = eFEntrega.FechaEntrega.ToString("HH:mm"),
                        Estado = eFEntrega.Pedido.EstadoPedido.Nombre,
                        Placa = string.Empty,
                        Usuario = eFEntrega.Usuario.Nombre,
                        Muelle= string.Empty
                    };

                    if (eFVehiculoEntregaDetalle != null)
                    {
                        entrega.Placa = eFVehiculoEntregaDetalle.VehiculoEntrega.Vehiculo.Placa;
                    }

                    if (eFVehiculoEntregaDetalle!=null)
                    {
                        entrega.Muelle = eFVehiculoEntregaDetalle.VehiculoEntrega.Muelle.Muelle;
                    }                   

                    entrega.Detalles = new List<EntregaDetalleBO>();

                    List<EFDetalleEntrega> efDetalleEntregas = contexto.DetalleEntregas
                        .Include(e => e.Entrega)
                        .Include("DetallePedido")
                        .Where(e => e.Entrega.PedidoId == eFEntrega.PedidoId).ToList();

                    foreach (EFDetalleEntrega efDetalle in eFEntrega.Detalles)
                    {

                        EntregaDetalleBO detalleBo = new EntregaDetalleBO()
                        {
                            IdEstadoArticulo = efDetalle.DetallePedido.EstadoArticuloId == null ? null: efDetalle.DetallePedido.EstadoArticuloId,
                            DetalleEntregaId = efDetalle.DetalleEntregaId,
                            CantidadEntrega = efDetalle.Cantidad.ToString(),
                            Codigo = efDetalle.DetallePedido.ItemCode,
                            CantidadAprobada = efDetalle.DetallePedido.CantidadAprobada.ToString()
                        };

                        decimal cantidadAprobadaEntregas = eFEntrega.Detalles
                            .Where(d => d.DetallePedido.EstadoArticuloId == detalleBo.IdEstadoArticulo && d.DetallePedido.ItemCode == detalleBo.Codigo).ToList()
                            .Select(de => de.Cantidad).Sum();

                        detalleBo.CantidadPendiente = (Convert.ToDecimal(detalleBo.CantidadAprobada) - Convert.ToDecimal(cantidadAprobadaEntregas)).ToString();

                        detalleBo.Nombre = contexto.Articulos.FirstOrDefault(a => a.ItemCode == efDetalle.DetallePedido.ItemCode).ItemName;

                        entrega.Detalles.Add(detalleBo);
                     
                    }

                }
            }

            return entrega;

        }

        /// <summary>
        /// Obtiene el objeto de negocio DetalleEntrega
        /// </summary>
        /// <param name="detalleEntregaId">3</param>
        /// <returns>DetalleEntrega</returns>
        public DetalleEntrega GetDetalleEntregaxId(int detalleEntregaId)
        {
            DetalleEntrega detalleEntrega = null;
            EFDetalleEntrega eFDetalleEntrega = null;

            using (Contexto contexto=new Contexto())
            {
                eFDetalleEntrega = contexto.DetalleEntregas.Include(i=>i.DetallePedido.Pedido).FirstOrDefault(d => d.DetalleEntregaId == detalleEntregaId);
            }

            if (eFDetalleEntrega!=null)
            {
                detalleEntrega = this.mapper.Map<EFDetalleEntrega,DetalleEntrega>(eFDetalleEntrega);
            }

            return detalleEntrega;

        }

        #region Eliminar Entrega Distribución

        /// <summary>
        /// Edita un artículo asociado a una entrega en el módulo de distribución, en el negocio se entiende por eliminar
        /// </summary>
        /// <param name="eliminarArticuloDistribucion">solicitud eliminarArticuloDistribucion</param>
        /// <response code="200">Booleano Operación realizada con éxito</response>
        public bool EliminarArticuloDistribucion(EliminarArticuloDistribucion eliminarArticuloDistribucion)
        {
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        EFDetalleEntrega eFDetalleEntrega = contexto.DetalleEntregas.FirstOrDefault(e => e.DetalleEntregaId == eliminarArticuloDistribucion.DetalleEntregaId);
                        if (eFDetalleEntrega != null)
                        {
                            eFDetalleEntrega.Cantidad = 0;
                            contexto.Update(eFDetalleEntrega);
                        }


                        EFMotivoProceso eFMotivoProceso = new EFMotivoProceso()
                        {
                            FechaRegistro = DateTime.Now,
                            MotivoId = eliminarArticuloDistribucion.MotivoId,
                            TablaId = eliminarArticuloDistribucion.DetalleEntregaId,
                            NombreTabla = TablasEnum.DetalleEntregas.ToString()
                        };
                        contexto.Add(eFMotivoProceso);

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
        #endregion



    }
}
