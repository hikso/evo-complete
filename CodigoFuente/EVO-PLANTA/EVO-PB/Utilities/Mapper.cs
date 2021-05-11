using AutoMapper;
using EVO_PB.Models.ArticlesApi;
using EVO_PB.Models.BusinessObjects;
using EVO_PB.Models.DTOs.WareHouseApi;
using EVO_PB.Models.OrderListApi;
using EVO_WebApi_New.Models.SettingsApi;
using EVO_WebApi_New.Models.UsuariosApi;
using EVO_WebApi_New.Models.EntregasOrderApi;
using EVO_WebApi_New.Models.EntregasApi;
using EVO_PB.Models.AlistamientoApi;
using EVO_PB.Models.DTOs.BasculasApi;
using EVO_PB.Models.DTOs.ArticulosApi;

namespace EVO_PB.Utilities
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 15-Ene/2020
    /// Descripción      : Esta clase implementa los automapeos de los BOs
    /// </summary>
    public class Mapper
    {
        #region Campos Privados
        protected IMapper mapper;
        #endregion

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public Mapper() 
        {
            // Se carga la configuración del mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTOVersionResponse, BOVersion>();
                cfg.CreateMap<BodegaResponse, BOWareHouse>();
                cfg.CreateMap<ObtenerTodosArticulosResponse, BOPaginationArticle>()
                .ForMember(d => d.TotalNumberRecords, s => s.MapFrom(src => src.NumeroTotalRegistros))
                .ForMember(d => d.PaginationSize, s => s.MapFrom(src => src.TamanhoPaginacion))
                .ForMember(d => d.Articles, s => s.MapFrom(src => src.Registros));
                cfg.CreateMap<ObtenerTodosArticulosResponseRegistros, BOArticle>()
                .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.CodigoArticulo))
                .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                .ForPath(d => d.Maximum, s => s.MapFrom(src => src.Maximo))
                .ForPath(d => d.Minimum, s => s.MapFrom(src => src.Minimo))
                .ForPath(d => d.Stock, s => s.MapFrom(src => src.Stock))
                .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
                .ForPath(d => d.SuggestedOrder, s => s.MapFrom(src => src.PedidoSugerido));
                cfg.CreateMap<DTOParametroGeneralResponse, BOGeneralParameter>();
                cfg.CreateMap<UsuarioResponse, BOUser>()
                .ForPath(d => d.Name, s => s.MapFrom(src => src.Nombre))
                .ForPath(d => d.UserName, s => s.MapFrom(src => src.NombreUsuario))
                .ForPath(d => d.UserId, s => s.MapFrom(src => src.UsuarioId));
                cfg.CreateMap<ObtenerTodosPedidosResponse, BOOrderList>()
                .ForPath(d => d.TotalNumberRecords, s => s.MapFrom(src => src.NumeroTotalRegistros))
                .ForPath(d => d.PaginationSize, s => s.MapFrom(src => src.TamanhoPaginacion))
                .ForPath(d => d.Registers, s => s.MapFrom(src => src.Registros));
                cfg.CreateMap<ObtenerTodosPedidosResponseRegistros, BORegisterorderlist>()
                .ForPath(d => d.CodeOrder, s => s.MapFrom(src => src.CodigoPedido))
                .ForPath(d => d.DateRequest, s => s.MapFrom(src => src.FechaSolicitud))
                .ForPath(d => d.DateDelivery, s => s.MapFrom(src => src.FechaEntrega))
                .ForPath(d => d.State, s => s.MapFrom(src => src.Estado))
                .ForPath(d => d.OrderId, s => s.MapFrom(src => src.PedidoId))
                .ForPath(d => d.Factory, s => s.MapFrom(src => src.Planta))
                .ForPath(d => d.DaysDelivery, s => s.MapFrom(src => src.DiasEntrega));
                cfg.CreateMap<ConsultaPedidoResponse, BOOrderListDetails>()
                .ForPath(d => d.NumberOrderList, s => s.MapFrom(src => src.NumeroPedido))
                .ForPath(d => d.State, s => s.MapFrom(src => src.EstadoPedido))
                .ForPath(d => d.DateRequest, s => s.MapFrom(src => src.FechaSolicitud))
                .ForPath(d => d.DateSend, s => s.MapFrom(src => src.FechaEnvio))
                .ForPath(d => d.DateReceipt, s => s.MapFrom(src => src.FechaRecibido))
                .ForPath(d => d.DateCars, s => s.MapFrom(src => src.FechaCargueEnVehiculo))
                .ForPath(d => d.NameConductive, s => s.MapFrom(src => src.NombreConductor))
                .ForPath(d => d.LicensePlate, s => s.MapFrom(src => src.PlacaVehiculo))
                .ForPath(d => d.NameAuxiliary, s => s.MapFrom(src => src.NombreAuxiliar))
                .ForPath(d => d.Plant, s => s.MapFrom(src => src.Planta))
                .ForPath(d => d.Registers, s => s.MapFrom(src => src.Detalles));
                cfg.CreateMap<ConsultaPedidoResponseDetalles, BORegisterOrderListDetails>()
               .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.CodigoArticulo))
               .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
               .ForPath(d => d.StateArticle, s => s.MapFrom(src => src.EstadoArticulo))
               .ForPath(d => d.QuantityRequest, s => s.MapFrom(src => src.CantidadSolicitada))
               .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
               .ForPath(d => d.QuantityApprove, s => s.MapFrom(src => src.CantidadAprobada))
               .ForPath(d => d.QuantitySend, s => s.MapFrom(src => src.CantidadEnviada))
               .ForPath(d => d.DateDeliveries, s => s.MapFrom(src => src.FechaEntrega))
               .ForPath(d => d.CostTransferred, s => s.MapFrom(src => src.CostoTraslado))
               .ForPath(d => d.CostTransferred, s => s.MapFrom(src => src.CostoTransporte));
                cfg.CreateMap<EstadoArticuloResponse, BOStateArticle>()
               .ForPath(d => d.StateArticleId, s => s.MapFrom(src => src.EstadoArticuloId))
               .ForPath(d => d.Name, s => s.MapFrom(src => src.Nombre));
                cfg.CreateMap<BOArticleOrder, BOArticleOrder>();
                cfg.CreateMap<BOArticle, BOArticleOrder>();

                cfg.CreateMap<BOOrderRequest, EntregaOrderResponse>();
                cfg.CreateMap<EntregaOrderResponse, BOOrderRequest>();



                cfg.CreateMap<DetalleEntregaResponse, BODelivery>()
               .ForPath(d => d.Consecutive, s => s.MapFrom(src => src.Consecutivo))
               .ForPath(d => d.DateDelivery, s => s.MapFrom(src => src.Fecha))
               .ForPath(d => d.Dock, s => s.MapFrom(src => src.Muelle))
               .ForPath(d => d.TypeClient, s => s.MapFrom(src => src.TipoCliente))
               .ForPath(d => d.Client, s => s.MapFrom(src => src.Cliente))
               .ForPath(d => d.EnlistmentArticles, s => s.MapFrom(src => src.ArticulosResponse));

                cfg.CreateMap<ArticuloAlistamientoResponse, BOEnlistmentArticles>()
               .ForPath(d => d.DeliveryDetailId, s => s.MapFrom(src => src.DetalleEntregaId))
               .ForPath(d => d.ArticleCode, s => s.MapFrom(src => src.CodigoArticulo))
               .ForPath(d => d.ArticleName, s => s.MapFrom(src => src.NombreArticulo))
               .ForPath(d => d.State, s => s.MapFrom(src => src.Estado))
               .ForPath(d => d.DeliveryQuantity, s => s.MapFrom(src => src.CantidadEntrega))
               .ForPath(d => d.PendingQuantity, s => s.MapFrom(src => src.CantidadPendiente))
               .ForPath(d => d.MeasureUnit, s => s.MapFrom(src => src.UnidadMedida));


                cfg.CreateMap<TipoContenedorResponse, BOContainers>()
                .ForPath(d => d.ContainerHasBarCode, s => s.MapFrom(src => src.CodigoBarras))
                .ForPath(d => d.ContainerId, s => s.MapFrom(src => src.TipoContenedorId))
                .ForPath(d => d.ContainerName, s => s.MapFrom(src => src.Nombre))
                .ForPath(d => d.ContainerWeight, s => s.MapFrom(src => src.Peso));

                cfg.CreateMap<EntregaResponse, BODelivery>()
               .ForPath(d => d.DeliveryId, s => s.MapFrom(src => src.EntregaId))
               .ForPath(d => d.DeliveryNumber, s => s.MapFrom(src => src.NumeroEntrega));

                cfg.CreateMap<TipoBasculaResponse, BOBascules>()
               .ForPath(d => d.TypeBasculeId, s => s.MapFrom(src => src.TipoBasculaId))
               .ForPath(d => d.NameBasule, s => s.MapFrom(src => src.Nombre));

                cfg.CreateMap<BOOrderRequestDetail, PedidoRequestDetalles>()
               .ForPath(d => d.Cantidad, s => s.MapFrom(src => src.Quantity))
               .ForPath(d => d.EstadoArticuloId, s => s.MapFrom(src => src.StateArticleId));

                cfg.CreateMap<ObtenerPedidoResponse, BOOrderListPreview>()
                .ForPath(d => d.DateorderList, s => s.MapFrom(src => src.FechaPedido))
                .ForPath(d => d.CodeOrderList, s => s.MapFrom(src => src.CodigoPedido))
                .ForPath(d => d.RequestFor, s => s.MapFrom(src => src.SolicitudPara))
                .ForPath(d => d.DateDelivery, s => s.MapFrom(src => src.FechaEntrega))
                .ForPath(d => d.StateOrderListId, s => s.MapFrom(src => src.EstadoPedidoId))
                .ForPath(d => d.Registers, s => s.MapFrom(src => src.Detalles));

                cfg.CreateMap<ObtenerPedidoResponseDetalles, BOArticleOrder>()
                .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.ItemCode))
                .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                .ForPath(d => d.Quantity, s => s.MapFrom(src => src.Cantidad))
                .ForPath(d => d.Maximum, s => s.MapFrom(src => src.StockMaximo))
                .ForPath(d => d.Minimum, s => s.MapFrom(src => src.StockMinimo))
                .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
                .ForPath(d => d.Stock, s => s.MapFrom(src => src.Stock))
                .ForPath(d => d.StateArticleId, s => s.MapFrom(src => src.EstadoArticulo))
                .ForPath(d => d.SuggestedOrder, s => s.MapFrom(src => src.PedidoSugerido));

                cfg.CreateMap<BOOrderEditRequest, PedidoIdRequest>()
                .ForPath(d => d.PedidoId, s => s.MapFrom(src => src.OrderListId))
                .ForPath(d => d.WhsCode, s => s.MapFrom(src => src.WhsCodePointSale))
                .ForPath(d => d.SolicitudPara, s => s.MapFrom(src => src.WhsCodeFactory))
                .ForPath(d => d.EstadoPedido, s => s.MapFrom(src => src.StateOrder))
                .ForPath(d => d.Detalles, s => s.MapFrom(src => src.Details))
                .ForPath(d => d.Usuario, s => s.MapFrom(src => src.User))
                .ForPath(d => d.FechaEntrega, s => s.MapFrom(src => src.DateDelivery));
                
                cfg.CreateMap<PesajesArticuloResponse, BOWeighingByArticle>()
                .ForPath(d => d.ArticleCode, s => s.MapFrom(src => src.CodigoArticulo))
                .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                .ForPath(d => d.MeasureUnit, s => s.MapFrom(src => src.UnidadMedida))
                .ForPath(d => d.ArticleState, s => s.MapFrom(src => src.EstadoArticulo))
                .ForPath(d => d.TotalBasculeWeight, s => s.MapFrom(src => src.TotalPesoBascula))
                .ForPath(d => d.BasculeWeighings, s => s.MapFrom(src => src.PesajesBascula));

                cfg.CreateMap<PesajeBasculaResponse, BOBasculeWeighings>()
                .ForPath(d => d.BasculeWeight, s => s.MapFrom(src => src.PesoBascula))
                .ForPath(d => d.ArticleWeight, s => s.MapFrom(src => src.PesoArticulo))
                .ForPath(d => d.WareHouse, s => s.MapFrom(src => src.Bodega))
                .ForPath(d => d.Containers, s => s.MapFrom(src => src.ContenedoresRequest));

                cfg.CreateMap<PesajeContenedorRequest, BOContainers>()
                .ForPath(d => d.ContainerId, s => s.MapFrom(src => src.TipoContenedorId))
                .ForPath(d => d.ContainerQuantity, s => s.MapFrom(src => src.Cantidad));

                cfg.CreateMap<BOWeighing, PesajeBasculaRequest>()
                .ForPath(d => d.DetalleEntregaId, s => s.MapFrom(src => src.DeliveryDetailId))
                .ForPath(d => d.TipoBasculaId, s => s.MapFrom(src => src.TypeBasculeId))
                .ForPath(d => d.CodigoBodega, s => s.MapFrom(src => src.WhsCode))
                .ForPath(d => d.PesoBascula, s => s.MapFrom(src => src.Weight))
                .ForPath(d => d.PesoArticulos, s => s.MapFrom(src => src.TotalArticleWeight))
                .ForPath(d => d.ContenedoresRequest, s => s.MapFrom(src => src.Containers));

                cfg.CreateMap<BOContainers, PesajeContenedorRequest>()
                .ForPath(d => d.Cantidad, s => s.MapFrom(src => src.ContainerQuantity))
                .ForPath(d => d.TipoContenedorId, s => s.MapFrom(src => src.ContainerId));

                cfg.CreateMap<BOGetOrderErasedRequest,ObtenerPedidoBorradorRequest>()
                .ForPath(d => d.SolicitudPara, s => s.MapFrom(src => src.CodeFactory))             
                .ForPath(d => d.WhsCode, s => s.MapFrom(src => src.CodePointSale));

                cfg.CreateMap<ArticuloResponse,BOArticle>()
                .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.CodigoArticulo))
                .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                .ForPath(d => d.Maximum, s => s.MapFrom(src => src.Maximo))
                .ForPath(d => d.Minimum, s => s.MapFrom(src => src.Minimo))
                .ForPath(d => d.Stock, s => s.MapFrom(src => src.Stock))
                .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
                .ForPath(d => d.SuggestedOrder, s => s.MapFrom(src => src.PedidoSugerido));

                cfg.CreateMap<BOSearchArticleRequest,BuscarArticuloRequest>()
                .ForPath(d => d.Codigo, s => s.MapFrom(src => src.Code))
                .ForPath(d => d.Nombre, s => s.MapFrom(src => src.Name))
                .ForPath(d => d.PrefijoCodigoArticulo, s => s.MapFrom(src => src.PrefixCodeArticle))
                .ForPath(d => d.CodigoBodega, s => s.MapFrom(src => src.WhsCode));
             

            });

            this.mapper = config.CreateMapper();

        }
        #endregion
    }
}
