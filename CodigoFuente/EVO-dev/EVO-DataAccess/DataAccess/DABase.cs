using AutoMapper;
using EVO_BusinessObjects;
using EVO_DataAccess.Entities;
using EVO_DataAccess.Utils;
using System.Collections.Generic;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Duban Camilo Cardona
    /// Fecha de Creación: 05-Nov/2019
    /// Descripción      : Esta es la clase base de los objetos de acceso a datos. Desde aquí se configura el mapeador con automapper.
    /// </summary>
    public class DABase
    {
        #region Campos Privados
        protected IMapper mapper;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase, aquí se configura el automapper
        /// </summary>
        public DABase()
        {
            if (GlobalVariables.mapper == null)
            {
                //En esta sección se configuran los mapeos a utilizar
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AutenticarSolicitud, EFSesion>();
                    cfg.CreateMap<EFArticulo, BOArticulo>();
                    cfg.CreateMap<EFArticuloBodega, ArticuloBodega>();
                    cfg.CreateMap<EFArticulo, ArticuloBodega>();
                    cfg.CreateMap<EFBodega, BOBodega>();
                    cfg.CreateMap<EFClienteExterno, ClienteExterno>();
                    cfg.CreateMap<EFEstadoArticulo, BOEstadoArticulo>();
                    cfg.CreateMap<EFEstadoPedido, EstadoPedido>();
                    cfg.CreateMap<EFFuncionalidad, Funcionalidad>();
                    cfg.CreateMap<EFParametroGeneral, ParametroGeneral>();
                    cfg.CreateMap<EFPedido, ConsultaPedidoRespuesta>();
                    cfg.CreateMap<Rol, EFRol>().ReverseMap();
                    cfg.CreateMap<EFSesion, SesionSolicitud>();
                    cfg.CreateMap<EFUsuario, Usuario>().
                        ForMember(d => d.Nombre, s => s.MapFrom(src => src.Nombre)).
                        ForMember(d => d.NombreUsuario, s => s.MapFrom(src => src.Usuario));
                    cfg.CreateMap<Pedido, EFDetallePedido>();
                    cfg.CreateMap<Pedido, EFPedido>();
                    cfg.CreateMap<RegistroAuditoria, EFRegistroAuditoria>().
                        ForPath(d => d.Usuario.Usuario, s => s.MapFrom(src => src.Usuario));
                    cfg.CreateMap<SesionSolicitud, EFSesion>();
                    cfg.CreateMap<EFFuncionalidad, Funcionalidad>();
                    cfg.CreateMap<Usuario, EFUsuario>().
                        ForMember(d => d.Usuario, s => s.MapFrom(src => src.NombreUsuario));
                    cfg.CreateMap<PedidoPlantaBeneficio, EFPedido>();
                    cfg.CreateMap<PedidoPlantaBeneficioDetalle, EFDetallePedido>();
                    cfg.CreateMap<EntregaPedido, EFEntrega>().
                        ForMember(d => d.FechaEntrega, s => s.MapFrom(src => src.FechaHoraEntrega));
                    cfg.CreateMap<DetalleEntregaPedido, EFDetalleEntrega>();
                    cfg.CreateMap<EFEntrega, EntregaPedido>().
                    ForMember(d => d.FechaHoraEntrega, s => s.MapFrom(src => src.FechaEntrega));
                    cfg.CreateMap<EFDetalleEntrega, DetalleEntregaPedido>();
                    cfg.CreateMap<ActualizarEntregaDetalle, EFDetalleEntrega>();
                    cfg.CreateMap<EFMotivo, MotivoRespuesta>();
                    cfg.CreateMap<EFTipoVehiculo, TipoVehiculoRespuesta>();
                    cfg.CreateMap<EFVehiculo, VehiculoRespuesta>();
                    cfg.CreateMap<EFEntrega, EntregaRespuesta>();
                    cfg.CreateMap<EFDetalleEntrega, EntregaRespuesta>();
                    cfg.CreateMap<EFEntrega, EntregaBO>();
                    cfg.CreateMap<EFDetalleEntrega, EntregaDetalleBO>();
                    cfg.CreateMap<EFEmpleado, Empleado>();
                    cfg.CreateMap<DistribucionSolicitud, EFVehiculoEntrega>();
                    cfg.CreateMap<EFVehiculoEntrega, VehiculoEntrega>();                                  
                    cfg.CreateMap<EFVehiculoEntregaDetalle, VehiculoEntregaDetalle>();
                    cfg.CreateMap<EFEntrega, Entrega>();
                    cfg.CreateMap<EFTipoVehiculo, TipoVehiculoRespuesta>();
                    cfg.CreateMap<EFRol, Rol>();
                    cfg.CreateMap<EFArticuloBodega, ArticuloBodega>().
                      ForMember(d => d.CodigoArticulo, s => s.MapFrom(src => src.ItemCode)).
                      ForMember(d => d.Maximo, s => s.MapFrom(src => src.MaxStock)).
                      ForMember(d => d.Minimo, s => s.MapFrom(src => src.MinStock)).
                      ForMember(d => d.Stock, s => s.MapFrom(src => src.OnHand));
                    cfg.CreateMap<EFMuelle, MuelleRespuesta>();
                    cfg.CreateMap<EFTipoBascula, BOTipoBascula>();
                    cfg.CreateMap<EFTipoContenedor, BOTipoContenedorRespuesta>();
                    cfg.CreateMap<EFBodega, BOBodega>();
                    cfg.CreateMap<EFPedido, PedidoRespuesta>();
                    cfg.CreateMap<EFDetalleEntrega, DetalleEntrega>().
                    ForMember(d => d.ItemCode, s => s.MapFrom(src => src.DetallePedido.ItemCode))
                    .ForMember(d => d.ClienteCode, s => s.MapFrom(src => src.DetallePedido.Pedido.WhsCode));
                    cfg.CreateMap<EFTipoBascula, BOTipoBascula>();
                    cfg.CreateMap<EFTipoContenedor, BOTipoContenedorRespuesta>();
                    cfg.CreateMap<EFEntrega, BOEntrega>();
                    cfg.CreateMap<EFPedido, BOPedido>();
                    cfg.CreateMap<EFDetalleEntrega, BODetalleEntrega>();
                    cfg.CreateMap<EFDetallePedido, BODetallePedido>();
                    cfg.CreateMap<EFEstadoArticulo, BOEstadoArticulo>();
                    cfg.CreateMap<EFEstadoEntrega, BOEstadoEntrega>();
                    cfg.CreateMap<EFPesajeEntrega, BOPesajeEntrega>();
                    cfg.CreateMap<EFPesajeCodigoBarras, BOPesajeCodigoBarras>();
                    cfg.CreateMap<EFPesajeArticulo, BOPesajeArticulo>();
                    cfg.CreateMap<EFDocumento, BODocumento>();
                    cfg.CreateMap<BOPesajeRequest, EFPesaje>();
                    cfg.CreateMap<BOContenedorRequest, EFPesajeContenedor>();
                    cfg.CreateMap<EFPesaje, BOPesaje>();
                    cfg.CreateMap<EFPesajeContenedor, BOPesajeContenedor>();
                    cfg.CreateMap<EFPesajeArticulo, BOPesajeArticulo>();
                    cfg.CreateMap<EFDetalleEntrega, DetalleEntrega>();
                    cfg.CreateMap<EFDetallePedido, DetallePedido>();
                    cfg.CreateMap<EFPedido, Pedido>();
                    cfg.CreateMap<BOCodigoBarras, EFPesajeCodigoBarras>();
                    cfg.CreateMap<EFPesajeContenedor, BOPesajeContenedorResponse>()
                    .ForMember(d => d.Peso, s => s.MapFrom(src => src.TipoContenedor.Peso))
                    .ForMember(d => d.Nombre, s => s.MapFrom(src => src.TipoContenedor.Nombre));
                    cfg.CreateMap<EFTipoContenedor, BOTipoContenedor>();
                    cfg.CreateMap<EFPesajeCodigoBarras, BOCodigoBarrasResponse>();
                    cfg.CreateMap<EFDocumento, BODocumento>();
                    cfg.CreateMap<EFEvidencia, BOEvidencia>();
                    cfg.CreateMap<EFUsuario, BOUsuario>();
                    cfg.CreateMap<EFDetalleEvidencia, BODetalleEvidencia>();
                    cfg.CreateMap<EFClienteParametrizacion, BOParametrizacionResponse>();
                    cfg.CreateMap<EFCaja, BOCaja>();
                    cfg.CreateMap<EFCuadreCaja, BOCuadreCaja>();
                    cfg.CreateMap<EFEstadoCuadreCaja, BOEstadoCuadreCaja>();
                    cfg.CreateMap<EFInconsistencia, BOInconsistencia>();
                    cfg.CreateMap<BOAperturaCajaRequest, EFCuadreCaja>();
                    cfg.CreateMap<EFVendedor, BOVendedorResponse>();
                    cfg.CreateMap<EFImpuestoArticulo, BOImpuestoArticulo>();
                    cfg.CreateMap<EFImpuestoSocioArticulo, BOImpuestoSocioArticulo>();
                    cfg.CreateMap<EFImpuesto, BOImpuesto>();
                    cfg.CreateMap<EFListaPrecio, BOListaPrecio>();
                    cfg.CreateMap<EFTipoListaPrecio, BOTipoListaPrecio>();
                    cfg.CreateMap<EFTransformacion,BOTransformacion>();
                    cfg.CreateMap<EFSocioNegocio, BOSocioNegocio>();
                    cfg.CreateMap<EFFormaPago,FormaPagoBO>();
                    cfg.CreateMap<EFProceso,ProcesoBO>();
                    cfg.CreateMap<EFBanco,BancoBO>();
                    cfg.CreateMap<ArticuloBodega, EFArticuloBodega>()
                      .ForMember(d => d.ItemCode, s => s.MapFrom(src => src.CodigoArticulo))
                      .ForMember(d => d.MaxStock, s => s.MapFrom(src => src.Maximo))
                      .ForMember(d => d.MinStock, s => s.MapFrom(src => src.Minimo))
                      .ForMember(d => d.OnHand, s => s.MapFrom(src => src.Stock));
                    cfg.CreateMap<EFVendedor, BOVendedorResponse>();
                    cfg.CreateMap<EFImpuesto,BOImpuesto>();
                    cfg.CreateMap<EFTipoFactura,BOTipoFactura>();
                    cfg.CreateMap<EFTipoInventario,TipoInventarioBO>();
                    cfg.CreateMap<InventarioBO,EFInventario>();
                    cfg.CreateMap<EFTipoSolicitud,BOObtenerTipoSolicitudPedidoResponse>();
                    cfg.CreateMap<EFEmpaque,BOEmpaque>();
                    cfg.CreateMap<EFTipoBodegaParametrizacion, BOTipoBodegaParametrizacion>();
                    cfg.CreateMap<EFPedido,BOPedido>();
                    cfg.CreateMap<EFPedido, BOPedidoConsultaResponse>()
                      .ForMember(d => d.TipoSolicitud, s => s.MapFrom(src => src.TipoSolicitud.TipoSolicitudNombre))
                      .ForMember(d => d.WhsCode, s => s.MapFrom(src => src.WhsCode))
                      .ForMember(d => d.NumeroPedido, s => s.MapFrom(src => src.NumeroPedido.Value.ToString()))
                      .ForMember(d => d.EstadoPedido, s => s.MapFrom(src => src.EstadoPedido.Nombre))
                      .ForMember(d => d.FechaSolicitud, s => s.MapFrom(src => src.FechaPedido.ToString("dd/MM/yyyy")))                     
                      .ForMember(d => d.Articulos, s => s.MapFrom(src => src.DetallesXPedido))
                      .ForMember(d => d.SolicitudA, s => s.MapFrom(src => src.BodegaPara.WhsName))
                      .ForMember(d => d.CancelarPedido, s => s.MapFrom(src => src.EstadoPedido.CancelarPedido));
                    cfg.CreateMap<EFDetallePedido, BOArticuloConsultaResponse>()
                      .ForMember(d => d.CodigoArticulo, s => s.MapFrom(src => src.ItemCode))
                      .ForMember(d => d.NombreArticulo, s => s.MapFrom(src => src.Articulo.ItemName))
                      .ForMember(d => d.CantidadSolicitada, s => s.MapFrom(src => src.Cantidad.ToString()))
                      .ForMember(d => d.Estado, s => s.MapFrom(src => src.EstadoArticulo.Nombre))
                      .ForMember(d => d.Empaque, s => s.MapFrom(src => src.Empaque.EmpaqueNombre))
                      .ForMember(d => d.UnidadMedida, s => s.MapFrom(src => src.Articulo.SalUnitMsr))
                      .ForMember(d => d.Observaciones, s => s.MapFrom(src => src.Observacion));
                    cfg.CreateMap<EFAccion, Accion>();
                    cfg.CreateMap<EFSerie, SerieRespuesta>();
                    cfg.CreateMap<EFGestionCompra, BOGestionCompra>();
                    cfg.CreateMap<SerieRespuesta, EFSerie>();
                    cfg.CreateMap<EFSerie,SerieRespuesta>();
                    cfg.CreateMap<BOArticulo, EFArticulo>();
                    cfg.CreateMap<BOBodega, EFBodega>();

                });

                this.mapper = config.CreateMapper();
                GlobalVariables.mapper = this.mapper;
            }
            else
            {
                this.mapper = GlobalVariables.mapper;
            }
        }
        #endregion
    }
}