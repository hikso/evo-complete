using AutoMapper;
using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using EVO_PV_Proxy.Models.FacturacionApi;
using EVO_PV_WebApi.Models;
using EVO_PV_WebApi.Models.ArticulosApi;
using EVO_PV_WebApi.Models.AuditoriaApi;
using EVO_PV_WebApi.Models.BodegasApi;
using EVO_PV_WebApi.Models.ConfigApi;
using EVO_PV_WebApi.Models.PedidoApi;
using EVO_PV_WebApi.Models.PedidosApi;
using EVO_PV_WebApi.Models.UsuariosApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVO_PV_WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Authorize]
    public class BaseController : ControllerBase
    {
        #region Campos Privados
        protected IMapper mapper;
        #endregion

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public BaseController() : base()
        {
            //En esta sección se configuran los mapeos a utilizar
            //Favor organizar los mapeos en orden alfabético

            if (GlobalVariables.mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticuloBodega, ArticuloUnicoResponse>();
                cfg.CreateMap<ArticuloBodega, BuscarArticuloRequest>();
                cfg.CreateMap<EstadoArticulo, EstadoArticuloResponse>();
                cfg.CreateMap<EstadoPedido, ObtenerEstadoPedidoResponse>();
                cfg.CreateMap<FiltrarPedidoRequest, Pedido>();
                cfg.CreateMap<ObtenerPedidos, ObtenerTodosPedidosResponse>();
                cfg.CreateMap<ObtenerPedidoResponseDetalles, ObtenerPedidoResponseDetalles>();
                cfg.CreateMap<ObtenerVersion, VersionResponse>();
                cfg.CreateMap<ObtenerTodosArticulosResponse, ObtenerArticulos>();
                cfg.CreateMap<ObtenerTodosArticulosResponseRegistros, ObtenerTodosArticulos>();
                cfg.CreateMap<ObtenerTodosPedidosResponse, ObtenerPedidos>();
                cfg.CreateMap<PedidoRequest, Pedido>().ReverseMap();
                cfg.CreateMap<ObtenerPedidosRegistros, DetallePedido>().ReverseMap();
                cfg.CreateMap<PedidoRequestDetalles, DetallePedido>().ForMember(d => d.EstadoArticulo, s => s.MapFrom(src => src.EstadoArticuloId)).ReverseMap();
                cfg.CreateMap<RegistroAuditoriaRequest, Auditoria>();
                cfg.CreateMap<EstadoPedido, ObtenerEstadoPedidoResponse>();
                cfg.CreateMap<ObtenerPedidos, EVO_PV_WebApi.Models.PedidosApi.ObtenerPedidoResponse>();
                cfg.CreateMap<ObtenerPedidosRegistros, EVO_PV_WebApi.Models.PedidosApi.ObtenerPedidoResponseDetalles>();
                cfg.CreateMap<ObtenerPedidosRegistros, ObtenerTodosPedidosResponseRegistros>();
                cfg.CreateMap<ObtenerTodosPedidosResponse, ObtenerPedidos>();
                cfg.CreateMap<ObtenerTodosPedidosResponseRegistros, ObtenerPedidosRegistros>();
                cfg.CreateMap<Bodega, BodegaResponse>()
                   .ForMember(d => d.FacturacionPorcentajeDescuento, s => s.MapFrom(src => src.FacturacionPorcentajeDescuento));
                cfg.CreateMap<Pedido, ObtenerPedidoResponse>();
                cfg.CreateMap<DetallePedido, ObtenerPedidoResponseDetalles>().
                   ForMember(d => d.ItemCode, s => s.MapFrom(src => src.ItemCode));
                cfg.CreateMap<ObtenerTodosPedidosDistribucion, ObtenerTodosPedidosDistribucionResponse>();
                cfg.CreateMap<ObtenerTodosPedidosDistribucionRegistros, ObtenerTodosPedidosDistribucionResponseRegistros>();
                cfg.CreateMap<ConsultaPedidoRespuesta, ConsultaPedidoResponse>();
                cfg.CreateMap<ConsultaDetallePedidoRespuesta, ConsultaPedidoResponseDetalles>();
                cfg.CreateMap<ObtenerArticulos, ObtenerTodosArticulosResponse>();
                cfg.CreateMap<ObtenerTodosArticulos, ObtenerTodosArticulosResponseRegistros>();
                cfg.CreateMap<Usuario, UsuarioResponse>();
                cfg.CreateMap<ParametroGeneral, ParametroGeneralResponse>();
                cfg.CreateMap<ObtenerPedidoBorradorRequest, ObtenerPedidoBorrador>();
                cfg.CreateMap<BuscarArticuloRequest, BuscarArticuloSolicitud>();
                cfg.CreateMap<ArticuloBodega, ArticuloResponse>();
                cfg.CreateMap<VendedorResponseBO,VendedorResponse>();
                cfg.CreateMap<OtraFormaPagoBO,OtraFormaPagoResponse>();
                cfg.CreateMap<BOEmpaque,EmpaqueResponse>();
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