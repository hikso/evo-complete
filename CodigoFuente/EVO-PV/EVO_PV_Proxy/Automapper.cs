using AutoMapper;
using EVO_BusinessObjects;
using EVO_PV_BusinessObjects;
using EVO_PV_Proxy.Models.ArticuloApi;
using EVO_PV_Proxy.Models.ArticulosApi;
using EVO_PV_Proxy.Models.AuditoriaApi;
using EVO_PV_Proxy.Models.BodegasApi;
using EVO_PV_Proxy.Models.ConfigApi;
using EVO_PV_Proxy.Models.FacturacionApi;
using EVO_PV_Proxy.Models.PedidoApi;
using EVO_PV_Proxy.Models.PedidoAPI;
using EVO_PV_Proxy.Models.PedidosApi;
using EVO_PV_Proxy.Models.UsuariosApi;

namespace EVO_PV_Proxy
{

    public class Automapper
    {
        #region Campos Privados
        protected IMapper iMapper;
        #endregion

        #region Constructores
        /// <summary>
        ///
        /// </summary>
        public Automapper()
        {
            //En esta sección se configuran los mapeos a utilizar
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ObtenerPedidoResponse, ObtenerPedidos>().ReverseMap();
                cfg.CreateMap<ObtenerPedidoResponseDetalles, ObtenerPedidosRegistros>();
                cfg.CreateMap<ObtenerTodosArticulosResponse, ObtenerArticulos>();
                cfg.CreateMap<ObtenerTodosArticulosResponseRegistros, ObtenerTodosArticulos>();
                cfg.CreateMap<ObtenerTodosPedidosResponse, ObtenerPedidos>();
                cfg.CreateMap<ArticuloBodega, ArticuloUnicoResponse>();
                cfg.CreateMap<ArticuloBodega, BuscarArticuloRequest>();
                cfg.CreateMap<EstadoPedido, ObtenerEstadoPedidoResponse>();
                cfg.CreateMap<FiltrarPedidoRequest, Pedido>();
                cfg.CreateMap<ObtenerPedidos, ObtenerTodosPedidosResponse>();
                cfg.CreateMap<ObtenerPedidoResponseDetalles, ObtenerPedidoResponseDetalles>();
                cfg.CreateMap<ObtenerVersion, VersionResponse>();
                cfg.CreateMap<ObtenerTodosArticulosResponse, ObtenerArticulos>();
                cfg.CreateMap<PedidoRequest, Pedido>().ReverseMap();
                cfg.CreateMap<PedidoRequestDetalles, DetallePedido>().
                ForMember(d => d.EstadoArticulo, s => s.MapFrom(src => src.EstadoArticuloId)).ReverseMap();
                cfg.CreateMap<RegistroAuditoriaRequest, Auditoria>();
                cfg.CreateMap<EstadoPedido, ObtenerEstadoPedidoResponse>();
                cfg.CreateMap<ObtenerPedidos, ObtenerPedidoResponse>().ReverseMap(); 
                cfg.CreateMap<ObtenerPedidosRegistros, ObtenerPedidoResponseDetalles>();
                cfg.CreateMap<ObtenerPedidosRegistros, ObtenerTodosPedidosResponseRegistros>();
                cfg.CreateMap<ObtenerTodosPedidosResponseRegistros, ObtenerPedidosRegistros>();
                cfg.CreateMap<Bodega, BodegaResponse>().ReverseMap();
                cfg.CreateMap<ObtenerPedidoResponse, Pedido>();
                cfg.CreateMap<ObtenerPedidoResponseDetalles,DetallePedido>().ReverseMap();
                cfg.CreateMap<ObtenerTodosPedidosDistribucionResponse, ObtenerTodosPedidosDistribucion>();
                cfg.CreateMap<ObtenerTodosPedidosDistribucionResponseRegistros,ObtenerTodosPedidosDistribucionRegistros>();
                cfg.CreateMap<ParametroGeneralResponse, ParametroGeneral>();
                cfg.CreateMap<UsuarioResponse,Usuario>();
                cfg.CreateMap<ConsultaPedidoResponse, ConsultaPedidoRespuesta>();
                cfg.CreateMap<ConsultaPedidoResponseDetalles, ConsultaDetallePedidoRespuesta>();
                cfg.CreateMap<ObtenerPedidoBorrador, ObtenerPedidoBorradorRequest>();
                cfg.CreateMap<BuscarArticuloSolicitud, BuscarArticuloRequest>();
                cfg.CreateMap<OtraFormaPagoResponse,OtraFormaPagoBO>();
                cfg.CreateMap<EmpaqueResponse,BOEmpaque>();

            }); 

            this.iMapper = config.CreateMapper();
        }
        #endregion
    }
}