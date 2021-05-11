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
    /// Fecha de Creación: 21-Sep/2019
    /// Descripción      : Implementa el acceso a datos de los artículos
    /// </summary>
    public class DAArticulo : DABase
    {
        #region Métodos Públicos
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

                        if (articuloBodega.Minimo != null && articuloBodega.Stock != null)
                        {
                            articuloBodega.PedidoSugerido = articuloBodega.Stock - articuloBodega.Minimo;
                        }

                        articulosBodega.Add(articuloBodega);
                    }
                }

            }

            return articulosBodega;
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
        public List<ArticuloBodega> ObtenerTodosArticulosxBodega(int desde, int hasta, string whsCodePuntoVenta, string whsCodePlanta)
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
                    ParameterName = "@whsCodePuntoVenta",
                    Value = whsCodePuntoVenta
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@whsCodePlanta",
                    Value = whsCodePlanta
                });

                List<ArticuloBodega> articulosBodega = contexto.LoadSPAutoMapper<ArticuloBodega>("ObtenerTodosArticulosxBodega", dbParameters);

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
        public object ObtenerConteoTodosRegistrosPlantas(string whsCode)
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