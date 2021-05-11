using AutoMapper;
using EVO_PV_New.Models.ArticlesApi;
using EVO_PV_New.Models.BusinessObjects;
using EVO_PV_New.Models.DTOs.WareHouseApi;
using EVO_PV_New.Models.OrderListApi;
using EVO_PV_New.Models.PedidosApi;
using EVO_WebApi_New.Models.SettingsApi;
using EVO_WebApi_New.Models.UsuariosApi;

namespace EVO_PV_New.Services
{
    /// <summary>
    /// Autor            : Edwin Tapie
    /// Fecha de Creación: 11-Dic/2019
    /// Descripción      : Esta clase implementa la clase base de los servicios
    /// </summary>
    public class BaseService
    {
        #region Campos Privados
        protected IMapper mapper;
        #endregion

        #region Constructores
        /// <summary>
        /// 
        /// </summary>
        public BaseService() : base()
        {
            // Se carga la configuración del mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTOVersionResponse,BOVersion>();
                cfg.CreateMap<BodegaResponse,BOWareHouse>();              
                cfg.CreateMap<ObtenerTodosArticulosResponse, BOPaginationArticle>()
                .ForMember(d => d.TotalNumberRecords, s => s.MapFrom(src => src.NumeroTotalRegistros))
                .ForMember(d => d.PaginationSize, s => s.MapFrom(src => src.TamanhoPaginacion))
                .ForMember(d => d.Articles, s => s.MapFrom(src => src.Registros));
                cfg.CreateMap<ObtenerTodosArticulosResponseRegistros,BOArticle>()
                .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.CodigoArticulo))
                .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                .ForPath(d => d.Maximum, s => s.MapFrom(src => src.Maximo))
                .ForPath(d => d.Minimum, s => s.MapFrom(src => src.Minimo))
                .ForPath(d => d.Stock, s => s.MapFrom(src => src.Stock))
                .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
                .ForPath(d => d.SuggestedOrder, s => s.MapFrom(src => src.PedidoSugerido));
                cfg.CreateMap<DTOParametroGeneralResponse,BOGeneralParameter>();
                cfg.CreateMap<UsuarioResponse,BOUser>()
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
                cfg.CreateMap<EstadoArticuloResponse,BOStateArticle>()
               .ForPath(d => d.StateArticleId, s => s.MapFrom(src => src.EstadoArticuloId))
               .ForPath(d => d.Name, s => s.MapFrom(src => src.Nombre));
                cfg.CreateMap<BOArticleOrder, BOArticleOrder>();
                cfg.CreateMap<BOArticle, BOArticleOrder>();

            });

            this.mapper = config.CreateMapper();

        }
        #endregion
    }
}
