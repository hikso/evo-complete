using AutoMapper;
using EVO_PV_BusinessObjects;
using EVO_PV_Proxy.Models.ArticulosApi;
using EVO_PV_Proxy.Models.AuditoriaApi;
using EVO_PV_Proxy.Models.BodegasApi;
using EVO_PV_Proxy.Models.ConfigApi;
using EVO_PV_Proxy.Models.FacturacionApi;
using EVO_PV_Proxy.Models.PedidoApi;
using EVO_PV_Proxy.Models.PedidoAPI;
using EVO_PV_Proxy.Models.PedidosApi;
using System.Collections.Generic;

namespace EVO_PV_WebApi.AutoMapperConfig
{
    /// <summary>
    /// 
    /// </summary>
    /// 
  
    public class BaseController 
    {
        #region Campos Privados
        protected IMapper iMapper;
        #endregion

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public BaseController() : base()
        {
            //En esta sección se configuran los mapeos a utilizar
            //Favor organizar los mapeos en orden alfabético
            var config = new MapperConfiguration(cfg => {
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
                cfg.CreateMap<PedidoRequestDetalles, DetallePedido>().ReverseMap();
                cfg.CreateMap<RegistroAuditoriaRequest, Auditoria>();
                cfg.CreateMap<List<EstadoPedido>, List<ObtenerEstadoPedidoResponse>>();
                cfg.CreateMap<ObtenerPedidos, ObtenerPedidoResponse>();
                cfg.CreateMap<ObtenerPedidosRegistros, ObtenerPedidoResponseDetalles>();
                cfg.CreateMap<ObtenerPedidosRegistros, ObtenerTodosPedidosResponseRegistros>();
                cfg.CreateMap<ObtenerTodosPedidosResponse, ObtenerPedidos>();
                cfg.CreateMap<ObtenerTodosPedidosResponseRegistros, ObtenerPedidosRegistros>();
                cfg.CreateMap<Bodega, BodegaResponse>();
                cfg.CreateMap<Pedido, ObtenerPedidoResponse>();
                cfg.CreateMap<DetallePedido, ObtenerPedidoResponseDetalles>().
                   ForMember(d => d.ItemCode, s => s.MapFrom(src => src.ItemCode));
                cfg.CreateMap<ObtenerTodosPedidosDistribucion, ObtenerTodosPedidosDistribucionResponse>();
                cfg.CreateMap<ObtenerTodosPedidosDistribucionRegistros,ObtenerTodosPedidosDistribucionResponseRegistros>();
                cfg.CreateMap<OtraFormaPagoBO,OtraFormaPagoResponse>();
            });

            this.iMapper = config.CreateMapper();
        }
        #endregion
    }
}