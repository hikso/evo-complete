using AutoMapper;
using EVO_PV.Models.ArticlesApi;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.DTOs.WareHouseApi;
using EVO_PV.Models.OrderListApi;
using EVO_WebApi_New.Models.SettingsApi;
using EVO_PV.Models.SettingsApi;
using EVO_PV.Models.UsuariosApi;
using EVO_PV.Models.DTOs.ArticlesApi;
using EVO_PV.Models.EntregasOrderApi;
using EVO_PV.Models.EntregasApi;
using EVO_PV.Models.RecepcionApi;
using EVO_PV.Models.ArticulosApi;
using EVO_PV.Models.DTOs.BusinessObjects;
using EVO_PV.Models.PesajeApi;
using EVO_PV.Models.ContenedoresApi;
using EVO_PV.Models.CajasApi;
using EVO_PV.Models.FacturacionApi;
using EVO_PV.Models;
using System;
using EVO_PV.Models.PedidosApi;
using EVO_PV.Models.DTOs.WareHousesApi;
using EVO_PV.Models.ArticuloApi;
using EVO_PV.Models.AuditApi;
using EVO_PV.Models.DTOs.PedidosApi;

namespace EVO_PV.Utilities
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
            if (GlobalVariables.mapper == null)
            {
                // Se carga la configuración del mapper
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DTOVersionResponse, BOVersion>();

                    cfg.CreateMap<BodegaResponse, BOWareHouse>()
                    .ForMember(d => d.Email, s => s.MapFrom(src => src.Email))
                    .ForMember(d => d.InvoiceDiscountPercent, s => s.MapFrom(src => src.FacturacionPorcentajeDescuento));

                    cfg.CreateMap<ObtenerTodosArticulosResponse, BOPaginationArticle>()
                    .ForMember(d => d.TotalNumberRecords, s => s.MapFrom(src => src.NumeroTotalRegistros))
                    .ForMember(d => d.PaginationSize, s => s.MapFrom(src => src.TamanhoPaginacion))
                    .ForMember(d => d.Articles, s => s.MapFrom(src => src.Registros));

                    cfg.CreateMap<ObtenerTipoSolicitudPedidoResponse, BOOrderType>()
                    .ForMember(d => d.OrderTypeId, s => s.MapFrom(src => src.TipoSolicitudId))
                    .ForMember(d => d.OrderTypeName, s => s.MapFrom(src => src.TipoSolicitudNombre));


                    cfg.CreateMap<AccionResponse, BOActions>()
                    .ForMember(d => d.ActionId, s => s.MapFrom(src => src.AccionId))
                    .ForMember(d => d.Name, s => s.MapFrom(src => src.Nombre));

                    cfg.CreateMap<MotivoResponse, BOReason>()
                    .ForMember(d => d.ReasonId, s => s.MapFrom(src => src.MotivoId))
                    .ForMember(d => d.ReasonName, s => s.MapFrom(src => src.Motivo));

                    cfg.CreateMap<ObtenerTodosArticulosResponseRegistros, BOArticle>()
                    .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.CodigoArticulo))
                    .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                    .ForPath(d => d.Maximum, s => s.MapFrom(src => src.Maximo))
                    .ForPath(d => d.Minimum, s => s.MapFrom(src => src.Minimo))
                    .ForPath(d => d.Stock, s => s.MapFrom(src => src.Stock))
                    .ForPath(d => d.StateId, s => s.MapFrom(src => src.EstadoId))
                    .ForPath(d => d.PackageId, s => s.MapFrom(src => src.EmpaqueId))
                    .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
                    .ForPath(d => d.SuggestedOrder, s => s.MapFrom(src => src.PedidoSugerido));

                    cfg.CreateMap<DTOParametroGeneralResponse, BOGeneralParameter>();

                    cfg.CreateMap<UsuarioResponse, BOUser>()
                    .ForPath(d => d.Name, s => s.MapFrom(src => src.Nombre))
                    .ForPath(d => d.UserName, s => s.MapFrom(src => src.NombreUsuario))
                    .ForPath(d => d.UserId, s => s.MapFrom(src => src.UsuarioId))
                    .ForPath(d => d.ID, s => s.MapFrom(src => src.Identificacion))
                    .ForPath(d => d.Positions, s => s.MapFrom(src => src.Cargos));

                    cfg.CreateMap<ObtenerTodosPedidosResponse, BOOrderList>()
                    .ForPath(d => d.TotalNumberRecords, s => s.MapFrom(src => src.NumeroTotalRegistros))
                    .ForPath(d => d.PaginationSize, s => s.MapFrom(src => src.TamanhoPaginacion))
                    .ForPath(d => d.Registers, s => s.MapFrom(src => src.Registros));

                    cfg.CreateMap<ObtenerSolicitudPedidoBorradorResponse, BORegisterorderlist>()
                    .ForPath(d => d.OrderId, s => s.MapFrom(src => src.PedidoId))
                    .ForPath(d => d.WhoIsFor, s => s.MapFrom(src => src.SolicitudA))
                    .ForPath(d => d.DateRequest, s => s.MapFrom(src => src.FechaSolicitud))
                    .ForPath(d => d.DateLimit, s => s.MapFrom(src => src.FechaLimiteSolicitud))
                    .ForPath(d => d.State, s => s.MapFrom(src => src.EstadoPedido))
                    .ForPath(d => d.DaysDelivery, s => s.MapFrom(src => src.DiasEntrega));

                    cfg.CreateMap<ObtenerTodosPedidosResponseRegistros, BORegisterorderlist>()
                    .ForPath(d => d.CodeOrder, s => s.MapFrom(src => src.CodigoPedido))
                    .ForPath(d => d.DateRequest, s => s.MapFrom(src => src.FechaSolicitud))
                    .ForPath(d => d.DateDelivery, s => s.MapFrom(src => src.FechaEntrega))
                    .ForPath(d => d.State, s => s.MapFrom(src => src.Estado))
                    .ForPath(d => d.OrderId, s => s.MapFrom(src => src.PedidoId))
                    .ForPath(d => d.Factory, s => s.MapFrom(src => src.Planta))
                    .ForPath(d => d.CanDuply, s => s.MapFrom(src => src.Duplicar))
                    .ForPath(d => d.CanEdit, s => s.MapFrom(src => src.Editar))
                    .ForPath(d => d.DaysDelivery, s => s.MapFrom(src => src.DiasEntrega));

                    cfg.CreateMap<PedidoConsultaResponse, BOOrderListDetails>()
                    .ForPath(d => d.NumberOrderList, s => s.MapFrom(src => src.NumeroPedido))
                    .ForPath(d => d.State, s => s.MapFrom(src => src.EstadoPedido))
                    .ForPath(d => d.DateRequest, s => s.MapFrom(src => src.FechaSolicitud))
                    .ForPath(d => d.DateSend, s => s.MapFrom(src => src.FechaEntrega))
                    .ForPath(d => d.DateReceipt, s => s.MapFrom(src => src.FechaLimiteSugerida))
                    .ForPath(d => d.DateCars, s => s.MapFrom(src => src.FechaCargueVehiculo))
                    .ForPath(d => d.NameConductive, s => s.MapFrom(src => src.NombreConductor))
                    .ForPath(d => d.DeliveryIsFor, s => s.MapFrom(src => src.SolicitudA))
                    .ForPath(d => d.TypeOrder, s => s.MapFrom(src => src.TipoSolicitud))
                    .ForPath(d => d.CancelOrder, s => s.MapFrom(src => src.CancelarPedido))
                    .ForPath(d => d.Actions, s => s.MapFrom(src => src.Acciones))
                    .ForPath(d => d.Registers, s => s.MapFrom(src => src.Articulos));

                    cfg.CreateMap<AccionCompraResponse, BOPurchaceAction>()
                   .ForPath(d => d.ActionId, s => s.MapFrom(src => src.AccionId))
                   .ForPath(d => d.Articles, s => s.MapFrom(src => src.Articulos))
                   .ForPath(d => d.ActionName, s => s.MapFrom(src => src.NombreAccion));

                    cfg.CreateMap<ArticuloAccionCompraResponse, BOPurchaceActionArticle>()
                   .ForPath(d => d.Quantity, s => s.MapFrom(src => src.Cantidad))
                   .ForPath(d => d.QuantityLeftManagement, s => s.MapFrom(src => src.CantidadFaltanteGestionar))
                   .ForPath(d => d.QuantityRequested, s => s.MapFrom(src => src.CantidadSolicitada))
                   .ForPath(d => d.ArticleCode, s => s.MapFrom(src => src.CodigoArticulo))
                   .ForPath(d => d.DetailDeliveryId, s => s.MapFrom(src => src.DetallePedidoId))
                   .ForPath(d => d.ArticleName, s => s.MapFrom(src => src.NombreArticulo))
                   .ForPath(d => d.Observation, s => s.MapFrom(src => src.Observaciones))
                   .ForPath(d => d.DeliveryOrder, s => s.MapFrom(src => src.OrdenCompra))
                   .ForPath(d => d.DeportStock, s => s.MapFrom(src => src.StockAlmacen))
                   .ForPath(d => d.MeasureUnit, s => s.MapFrom(src => src.UnidadMedida));

                    cfg.CreateMap<ArticuloConsultaResponse, BORegisterOrderListDetails>()
                    .ForPath(d => d.QuantityApprove, s => s.MapFrom(src => src.CantidadAprobada))
                    .ForPath(d => d.QuantitySend, s => s.MapFrom(src => src.CantidadProgramada))
                    .ForPath(d => d.QuantityRequest, s => s.MapFrom(src => src.CantidadSolicitada))
                    .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.CodigoArticulo))
                    .ForPath(d => d.Package, s => s.MapFrom(src => src.Empaque))
                    .ForPath(d => d.StateArticle, s => s.MapFrom(src => src.Estado))
                    .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                    .ForPath(d => d.Observation, s => s.MapFrom(src => src.Observaciones))
                    .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida));

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
                   .ForPath(d => d.Observation, s => s.MapFrom(src => src.Observacion))
                   .ForPath(d => d.CostTransferred, s => s.MapFrom(src => src.CostoTransporte));

                    cfg.CreateMap<EstadoArticuloResponse, BOStateArticle>()
                   .ForPath(d => d.StateArticleId, s => s.MapFrom(src => src.EstadoArticuloId))
                   .ForPath(d => d.Name, s => s.MapFrom(src => src.Nombre));

                    cfg.CreateMap<ObtenerEstadoPedidoResponse, BOStateArticle>()
                   .ForPath(d => d.StateArticleId, s => s.MapFrom(src => src.EstadoId))
                   .ForPath(d => d.Name, s => s.MapFrom(src => src.EstadoNombre));

                    cfg.CreateMap<BOArticleOrder, BOArticleOrder>();

                    cfg.CreateMap<BOArticle, BOArticleOrder>();

                    cfg.CreateMap<BOOrderRequest, PedidoRequest>()
                    .ForPath(d => d.WhsCode, s => s.MapFrom(src => src.WhsCodePointSale))
                    .ForPath(d => d.SolicitudPara, s => s.MapFrom(src => src.WhsCodeFactory))
                    .ForPath(d => d.TipoSolicitudId, s => s.MapFrom(src => src.OrderTypeId))
                    .ForPath(d => d.EstadoPedido, s => s.MapFrom(src => src.StateOrder))
                    .ForPath(d => d.Detalles, s => s.MapFrom(src => src.Details))
                    .ForPath(d => d.Usuario, s => s.MapFrom(src => src.User))
                    .ForPath(d => d.Usuario, s => s.MapFrom(src => src.WhsEmail))
                    .ForPath(d => d.NombreUsuario, s => s.MapFrom(src => src.UserName))
                    .ForPath(d => d.EmailBodega, s => s.MapFrom(src => src.WhsEmail))
                    .ForPath(d => d.FechaEntrega, s => s.MapFrom(src => src.DateDelivery));

                    cfg.CreateMap<BOOrderRequestDetail, PedidoRequestDetalles>()
                   .ForPath(d => d.Cantidad, s => s.MapFrom(src => src.Quantity))
                   .ForPath(d => d.DetallePedidoId, s => s.MapFrom(src => src.DetailDeliveryId))
                   .ForPath(d => d.Observacion, s => s.MapFrom(src => src.Observations))
                   .ForPath(d => d.EmpaqueId, s => s.MapFrom(src => src.PackageId))
                   .ForPath(d => d.EstadoArticuloId, s => s.MapFrom(src => src.StateArticleId));

                    cfg.CreateMap<ObtenerPedidoResponse, BOOrderListPreview>()
                    .ForPath(d => d.DateorderList, s => s.MapFrom(src => src.FechaPedido))
                    .ForPath(d => d.CodeOrderList, s => s.MapFrom(src => src.CodigoPedido))
                    .ForPath(d => d.RequestFor, s => s.MapFrom(src => src.SolicitudPara))
                    .ForPath(d => d.DateDelivery, s => s.MapFrom(src => src.FechaEntrega))
                    .ForPath(d => d.TypeOrderId, s => s.MapFrom(src => src.TipoSolicitudId))
                    .ForPath(d => d.StateOrderListId, s => s.MapFrom(src => src.EstadoPedidoId))
                    .ForPath(d => d.Registers, s => s.MapFrom(src => src.Detalles));

                    cfg.CreateMap<ObtenerPedidoResponseDetalles, BOArticleOrder>()
                    .ForPath(d => d.DetailId, s => s.MapFrom(src => src.DetallePedidoId))
                    .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.CodigoArticulo))
                    .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                    .ForPath(d => d.Quantity, s => s.MapFrom(src => src.Cantidad))
                    .ForPath(d => d.Maximum, s => s.MapFrom(src => src.StockMaximo))
                    .ForPath(d => d.Minimum, s => s.MapFrom(src => src.StockMinimo))
                    .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
                    .ForPath(d => d.Stock, s => s.MapFrom(src => src.Stock))
                    .ForPath(d => d.StateArticleId, s => s.MapFrom(src => src.EstadoArticulo))
                    .ForPath(d => d.SuggestedOrder, s => s.MapFrom(src => src.PedidoSugerido))
                    .ForPath(d => d.PackageId, s => s.MapFrom(src => src.EmpaqueId))
                    .ForPath(d => d.Observations, s => s.MapFrom(src => src.Observacion));

                    cfg.CreateMap<BOOrderEditRequest, EditarPedidoRequest>()
                    .ForPath(d => d.PedidoId, s => s.MapFrom(src => src.OrderListId))
                    .ForPath(d => d.Articulos, s => s.MapFrom(src => src.Details));

                    cfg.CreateMap<BOOrderRequestDetail, EditarPedidoRequestArticulos>()
                    .ForPath(d => d.Cantidad, s => s.MapFrom(src => src.Quantity))
                    .ForPath(d => d.DetallePedidoId, s => s.MapFrom(src => src.DetailDeliveryId))
                    .ForPath(d => d.EmpaqueId, s => s.MapFrom(src => src.PackageId))
                    .ForPath(d => d.EstadoArticuloId, s => s.MapFrom(src => src.StateArticleId))
                    .ForPath(d => d.Observacion, s => s.MapFrom(src => src.Observations));

                    cfg.CreateMap<BOOrderEditRequest, PedidoIdRequest>()
                    .ForPath(d => d.PedidoId, s => s.MapFrom(src => src.OrderListId))
                    .ForPath(d => d.WhsCode, s => s.MapFrom(src => src.WhsCodePointSale))
                    .ForPath(d => d.SolicitudPara, s => s.MapFrom(src => src.WhsCodeFactory))
                    .ForPath(d => d.EstadoPedido, s => s.MapFrom(src => src.StateOrder))
                    .ForPath(d => d.Detalles, s => s.MapFrom(src => src.Details))
                    .ForPath(d => d.Usuario, s => s.MapFrom(src => src.User))
                    .ForPath(d => d.EmailBodega, s => s.MapFrom(src => src.WhsEmail))
                    .ForPath(d => d.NombreUsuario, s => s.MapFrom(src => src.UserName))
                    .ForPath(d => d.TipoSolicitudId, s => s.MapFrom(src => src.OrderTypeId))
                    .ForPath(d => d.FechaEntrega, s => s.MapFrom(src => src.DateDelivery));

                    cfg.CreateMap<BOGetOrderErasedRequest, ObtenerPedidoBorradorRequest>()
                    .ForPath(d => d.SolicitudPara, s => s.MapFrom(src => src.CodeFactory))
                    .ForPath(d => d.WhsCode, s => s.MapFrom(src => src.CodePointSale));

                    cfg.CreateMap<ArticuloResponse, BOArticle>()
                    .ForPath(d => d.CodeArticle, s => s.MapFrom(src => src.CodigoArticulo))
                    .ForPath(d => d.NameArticle, s => s.MapFrom(src => src.NombreArticulo))
                    .ForPath(d => d.Maximum, s => s.MapFrom(src => src.Maximo))
                    .ForPath(d => d.Minimum, s => s.MapFrom(src => src.Minimo))
                    .ForPath(d => d.Stock, s => s.MapFrom(src => src.Stock))
                    .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
                    .ForPath(d => d.StateId, s => s.MapFrom(src => src.EstadoId))
                    .ForPath(d => d.PackageId, s => s.MapFrom(src => src.EmpaqueId))
                    .ForPath(d => d.SuggestedOrder, s => s.MapFrom(src => src.PedidoSugerido));

                    cfg.CreateMap<BOSearchArticleRequest, BuscarArticuloRequest>()
                    .ForPath(d => d.Codigo, s => s.MapFrom(src => src.Code))
                    .ForPath(d => d.Nombre, s => s.MapFrom(src => src.Name))
                    .ForPath(d => d.TipoSolicitud, s => s.MapFrom(src => src.TypeOrder))
                    .ForPath(d => d.PrefijoCodigoArticulo, s => s.MapFrom(src => src.PrefixCodeArticle))
                    .ForPath(d => d.CodigoBodega, s => s.MapFrom(src => src.WhsCode));

                    cfg.CreateMap<EntregaOrderResponse, BOOrderRequestList>()
                    .ForPath(d => d.OrderId, s => s.MapFrom(src => src.PedidoId))
                    .ForPath(d => d.Code, s => s.MapFrom(src => src.Codigo));

                    cfg.CreateMap<EntregaResponse, BODelivery>()
                    .ForPath(d => d.DeliveryId, s => s.MapFrom(src => src.EntregaId))
                    .ForPath(d => d.FinalizedDate, s => s.MapFrom(src => src.FechaHoraEntrega))
                    .ForPath(d => d.IsFinalized, s => s.MapFrom(src => src.FinalizadoRecepcion))
                    .ForPath(d => d.DeliveryNumber, s => s.MapFrom(src => src.NumeroEntrega));

                    cfg.CreateMap<RecepcionEncabezadoResponse, BODeliveryReceiveHeader>()
                    .ForPath(d => d.ClientName, s => s.MapFrom(src => src.NombreCliente))
                    .ForPath(d => d.Consecutive, s => s.MapFrom(src => src.Consecutivo))
                    .ForPath(d => d.DeliveryDate, s => s.MapFrom(src => src.FechaEntrega))
                    .ForPath(d => d.DeliveryReceiveId, s => s.MapFrom(src => src.PesajeEntregaId))
                    .ForPath(d => d.IsFinalized, s => s.MapFrom(src => src.Finalizado))
                    .ForPath(d => d.Documents, s => s.MapFrom(src => src.Documentos))
                    .ForPath(d => d.CurrentDate, s => s.MapFrom(src => src.FechaActual));

                    cfg.CreateMap<ArticuloDocumentoResponse, BOInconsistenceFile>()
                    .ForPath(d => d.FileName, s => s.MapFrom(src => src.NombreDocumento))
                    .ForPath(d => d.DocumentId, s => s.MapFrom(src => src.DocumentoId));

                    cfg.CreateMap<ArticuloRecepcionResponse, BOArticleReceive>()
                    .ForPath(d => d.ArticleCode, s => s.MapFrom(src => src.CodigoArticulo))
                    .ForPath(d => d.ArticleWeighingId, s => s.MapFrom(src => src.PesajeArticuloId))
                    .ForPath(d => d.ArticleName, s => s.MapFrom(src => src.NombreArticulo))
                    .ForPath(d => d.DeliveryDetailId, s => s.MapFrom(src => src.DetalleEntregaId))
                    .ForPath(d => d.QuantityAprobed, s => s.MapFrom(src => src.CantidadAprobada))
                    .ForPath(d => d.QuantitySended, s => s.MapFrom(src => src.CantidadEnviada))
                    .ForPath(d => d.QuantityReceive, s => s.MapFrom(src => src.CantidadRecibida))
                    .ForPath(d => d.QuantityRequested, s => s.MapFrom(src => src.CantidadSolicitada))
                    .ForPath(d => d.MeasureUnit, s => s.MapFrom(src => src.UnidadMedida))
                    .ForPath(d => d.State, s => s.MapFrom(src => src.EstadoArticulo));

                    cfg.CreateMap<TipoContenedorResponse, BOContainers>()
                    .ForPath(d => d.ContainerHasBarCode, s => s.MapFrom(src => src.CodigoBarras))
                    .ForPath(d => d.ContainerId, s => s.MapFrom(src => src.TipoContenedorId))
                    .ForPath(d => d.ContainerName, s => s.MapFrom(src => src.Nombre))
                    .ForPath(d => d.ContainerWeight, s => s.MapFrom(src => src.Peso));

                    cfg.CreateMap<BOWeighing, PesajeRequest>()
                    .ForPath(d => d.DetalleEntregaId, s => s.MapFrom(src => src.DeliveryDetailId))
                    .ForPath(d => d.CodigoArticulo, s => s.MapFrom(src => src.CodeArticle))
                    .ForPath(d => d.EntregaId, s => s.MapFrom(src => src.DeliveryId))
                    .ForPath(d => d.PesoBascula, s => s.MapFrom(src => src.Weight))
                    .ForPath(d => d.Contenedores, s => s.MapFrom(src => src.Containers))
                    .ForPath(d => d.PesoArticulo, s => s.MapFrom(src => src.TotalArticleWeight));

                    cfg.CreateMap<BOContainers, ContenedorRequest>()
                    .ForPath(d => d.Cantidad, s => s.MapFrom(src => src.ContainerQuantity))
                    .ForPath(d => d.TipoContenedorId, s => s.MapFrom(src => src.ContainerId));

                    cfg.CreateMap<PesajeResponse, BOWeighingByArticle>()
                    .ForPath(d => d.ArticleWeighingId, s => s.MapFrom(src => src.PesajeId))
                    .ForPath(d => d.ArticleWeight, s => s.MapFrom(src => src.PesoArticulo))
                    .ForPath(d => d.TotalBasculeWeight, s => s.MapFrom(src => src.PesoBascula));

                    cfg.CreateMap<PesajeContenedorResponse, BOContainers>()
                    .ForPath(d => d.ContainerId, s => s.MapFrom(src => src.TipoContenedorId))
                    .ForPath(d => d.ContainerWeight, s => s.MapFrom(src => src.Peso))
                    .ForPath(d => d.ContainerQuantity, s => s.MapFrom(src => src.Cantidad))
                    .ForPath(d => d.ContainerName, s => s.MapFrom(src => src.Nombre));

                    cfg.CreateMap<CodigoBarrasResponse, BOBarCodeWeighing>()
                    .ForPath(d => d.BarCode, s => s.MapFrom(src => src.CodigoBarras))
                    .ForPath(d => d.Lot, s => s.MapFrom(src => src.Lote))
                    .ForPath(d => d.ExpirationDate, s => s.MapFrom(src => src.FechaVencimiento))
                    .ForPath(d => d.ArticleQuantity, s => s.MapFrom(src => src.Unidades))
                    .ForPath(d => d.Weight, s => s.MapFrom(src => src.Peso));

                    cfg.CreateMap<InconsistenciaResponse, BOInconsistence>()
                    .ForPath(d => d.InconsistenceId, s => s.MapFrom(src => src.Id))
                    .ForPath(d => d.SalePoint, s => s.MapFrom(src => src.PuntoVenta))
                    .ForPath(d => d.RequestNumber, s => s.MapFrom(src => src.NumeroPedido))
                    .ForPath(d => d.DeliveryNumber, s => s.MapFrom(src => src.NumeroEntrega))
                    .ForPath(d => d.EvidenceDate, s => s.MapFrom(src => src.FechaEvidencia));

                    cfg.CreateMap<InconsistenciaDetailResponse, BOInconsistenceDetail>()
                    .ForPath(d => d.InconsistenceId, s => s.MapFrom(src => src.Id))
                    .ForPath(d => d.SalePoint, s => s.MapFrom(src => src.PuntoVenta))
                    .ForPath(d => d.RequestNumber, s => s.MapFrom(src => src.NumeroPedido))
                    .ForPath(d => d.User, s => s.MapFrom(src => src.Usuario))
                    .ForPath(d => d.EvidenceDate, s => s.MapFrom(src => src.FechaEvidencia))
                    .ForPath(d => d.EmailFrom, s => s.MapFrom(src => src.CorreoOrigen))
                    .ForPath(d => d.EmailTo, s => s.MapFrom(src => src.CorreoDestino))
                    .ForPath(d => d.Description, s => s.MapFrom(src => src.Observaciones))
                    .ForPath(d => d.GUID, s => s.MapFrom(src => src.GUID))
                    .ForPath(d => d.Files, s => s.MapFrom(src => src.Archivos))
                    .ForPath(d => d.DocumentArticles, s => s.MapFrom(src => src.DocumentosArticulos));

                    cfg.CreateMap<InconsistenciaArchivoResponse, BOInconsistenceFile>()
                    .ForPath(d => d.FileName, s => s.MapFrom(src => src.NombreArchivo))
                    .ForPath(d => d.FileExtension, s => s.MapFrom(src => src.ExtensionArchivo));

                    cfg.CreateMap<ArticuloDocumentoResponse, BOArticuloDocumento>()
                    .ForPath(d => d.ArticleCode, s => s.MapFrom(src => src.CodigoArticulo))
                    .ForPath(d => d.ArticleName, s => s.MapFrom(src => src.NombreArticulo))
                    .ForPath(d => d.DocumentId, s => s.MapFrom(src => src.DocumentoId))
                    .ForPath(d => d.Document, s => s.MapFrom(src => src.Documento))
                    .ForPath(d => d.ArticleState, s => s.MapFrom(src => src.EstadoArticulo))
                    .ForPath(d => d.DocumentName, s => s.MapFrom(src => src.NombreDocumento));

                    cfg.CreateMap<BOInconsistenceNew, EvidenciaRequest>()
                    .ForPath(d => d.Detalles, s => s.MapFrom(src => src.Details))
                    .ForPath(d => d.PesajeEntregaId, s => s.MapFrom(src => src.ArticleWeighingId))
                    .ForPath(d => d.Observaciones, s => s.MapFrom(src => src.Observation));

                    cfg.CreateMap<BOInconsistenceFile, ArchivoRequest>()
                   .ForPath(d => d.Base64, s => s.MapFrom(src => src.Base64Code))
                   .ForPath(d => d.ExtensionArchivo, s => s.MapFrom(src => src.FileExtension))
                   .ForPath(d => d.NombreArchivo, s => s.MapFrom(src => src.FileName));

                    cfg.CreateMap<AperturaCajaResponse, BOBoxSetting>()
                    .ForPath(d => d.AsignedValue, s => s.MapFrom(src => src.ValorAsignado))
                    .ForPath(d => d.CloseDate, s => s.MapFrom(src => src.FechaCierre))
                    .ForPath(d => d.OpenDate, s => s.MapFrom(src => src.FechaApertura));

                    cfg.CreateMap<BOBoxSetting, AperturaCajaRequest>()
                    .ForPath(d => d.CodigoPuntoVenta, s => s.MapFrom(src => src.CodePointOfStore))
                    .ForPath(d => d.ValorApertura, s => s.MapFrom(src => src.RealValue));

                    cfg.CreateMap<SociosNegocioResponse, BOCustomer>()
                    .ForPath(d => d.Identification, s => s.MapFrom(src => src.Identificacion))
                    .ForPath(d => d.Name, s => s.MapFrom(src => src.Nombre));

                    cfg.CreateMap<ArticuloPuntoVentaResponse, BOBillingArticle>()
                   .ForPath(d => d.Code, s => s.MapFrom(src => src.CodigoArticulo))
                   .ForPath(d => d.Name, s => s.MapFrom(src => src.NombreArticulo))
                   .ForPath(d => d.Stock, s => s.MapFrom(src => src.Stock))
                   .ForPath(d => d.UnitMeasure, s => s.MapFrom(src => src.UnidadMedida))
                   .ForPath(d => d.Lote, s => s.MapFrom(src => src.Lote))
                   .ForPath(d => d.UnitPrice, s => s.MapFrom(src => src.PrecioUnitario))
                   .ForPath(d => d.IVA, s => s.MapFrom(src => src.ValorIVA))
                   .ForPath(d => d.IVACode, s => s.MapFrom(src => src.CodigoIVA))
                   .ForPath(d => d.WithholdingTax, s => s.MapFrom(src => src.ValorRetencion))
                   .ForPath(d => d.WarehouseCode, s => s.MapFrom(src => src.Lote))
                   .ForPath(d => d.DiscountWholesalers, s => s.MapFrom(src => src.PrecioUnitarioPorMayor))
                   .ForPath(d => d.MinQuantityDiscountWholesalers, s => s.MapFrom(src => src.CantidadMinimaPrecioPorMayor));
                    //.ForPath(d => d.PriceDiscountWholesalers, s => s.MapFrom(src => src.))
                    //.ForPath(d => d.IngredientsOutStock, s => s.MapFrom(src => src.ArticulosTransformacionResponse));

                    cfg.CreateMap<EstadoCajaResponse, BOBoxState>()
                    .ForPath(d => d.TodayIsConfigured, s => s.MapFrom(src => src.AperturaCajaActual))
                    .ForPath(d => d.YesterdayIsClosed, s => s.MapFrom(src => src.CierreCajaAnterior));

                    cfg.CreateMap<BOWeighing, CantidadRecibidaRequest>()
                    .ForPath(d => d.CantidadRecibida, s => s.MapFrom(src => src.TotalArticleQuantity))
                    .ForPath(d => d.DetalleEntregaId, s => s.MapFrom(src => src.DeliveryDetailId))
                    .ForPath(d => d.EntregaId, s => s.MapFrom(src => src.DeliveryId))
                    .ForPath(d => d.CodigoArticulo, s => s.MapFrom(src => src.CodeArticle));

                    cfg.CreateMap<RecepcionResponse, BOReceiveFinalizedDocuments>()
                    .ForPath(d => d.Documents, s => s.MapFrom(src => src.Documentos))
                    .ForPath(d => d.BarCodeInconsistences, s => s.MapFrom(src => src.InconsistenciaCodigoBarras));

                    cfg.CreateMap<ArticuloDocumentoResponse, BOArticuloDocumento>()
                    .ForPath(d => d.DocumentName, s => s.MapFrom(src => src.NombreDocumento))
                    .ForPath(d => d.DocumentId, s => s.MapFrom(src => src.DocumentoId));

                    cfg.CreateMap<VendedorResponse, BOSeller>()
                    .ForPath(d => d.FirstName, s => s.MapFrom(src => src.Nombres))
                    .ForPath(d => d.LastName, s => s.MapFrom(src => src.Apellidos))
                    .ForPath(d => d.SellerId, s => s.MapFrom(src => src.VendedorId));

                    cfg.CreateMap<OtraFormaPagoResponse, BOPayWays>()
                    .ForPath(d => d.Name, s => s.MapFrom(src => src.Nombre))
                    .ForPath(d => d.Id, s => s.MapFrom(src => src.Id));

                    cfg.CreateMap<BancoResponse, BOBank>()
                    .ForPath(d => d.Name, s => s.MapFrom(src => src.Nombre))
                    .ForPath(d => d.BankId, s => s.MapFrom(src => src.BancoId));

                    cfg.CreateMap<BOGenerateInvoice, FacturaRequest>()
                    .ForPath(d => d.Articulos, s => s.MapFrom(src => src.Articles))
                    .ForPath(d => d.CantidadBolsas, s => s.MapFrom(src => src.BagsQuantity))
                    .ForPath(d => d.CodigoPuntoVenta, s => s.MapFrom(src => src.SalePointId))
                    .ForPath(d => d.FormasPago, s => s.MapFrom(src => src.PaymentWays))
                    .ForPath(d => d.IdentificacionCliente, s => s.MapFrom(src => src.ClientId))
                    .ForPath(d => d.ImpuestoBolsas, s => s.MapFrom(src => src.BagsTax))
                    .ForPath(d => d.Observaciones, s => s.MapFrom(src => src.Observations))
                    .ForPath(d => d.PorcentajeCobroBolsa, s => s.MapFrom(src => src.BagPlasticPercent))
                    .ForPath(d => d.PorcentajeDescuento, s => s.MapFrom(src => src.DiscountPercent))
                    .ForPath(d => d.TipoBasculaId, s => s.MapFrom(src => src.TypeBasculeId))
                    .ForPath(d => d.TotalAntesDescuento, s => s.MapFrom(src => src.TotalBeforeDiscount))
                    .ForPath(d => d.TotalConDescuento, s => s.MapFrom(src => src.TotalWithDiscount))
                    .ForPath(d => d.TotalDocumento, s => s.MapFrom(src => src.TotalDocument))
                    .ForPath(d => d.ValorBolsa, s => s.MapFrom(src => src.BagValue))
                    .ForPath(d => d.ValorImpuestos, s => s.MapFrom(src => src.TaxValue))
                    .ForPath(d => d.VendedorId, s => s.MapFrom(src => src.SellerId));

                    cfg.CreateMap<BOPaymentWayStructure, FormaPagoRequest>()
                    .ForPath(d => d.BancoId, s => s.MapFrom(src => src.BankId))
                    .ForPath(d => d.ConsecutivoBono, s => s.MapFrom(src => src.ConsecutiveBond))
                    .ForPath(d => d.EmpleadoBono, s => s.MapFrom(src => src.EmployeeBond))
                    .ForPath(d => d.FormaPagoId, s => s.MapFrom(src => src.PaymentWayId));

                    cfg.CreateMap<BOBillingArticle, ArticuloRequest>()
                    .ForPath(d => d.Cantidad, s => s.MapFrom(src => decimal.Parse(src.Quantity.ToString())))
                    .ForPath(d => d.CodigoArticulo, s => s.MapFrom(src => src.Code))
                    .ForPath(d => d.CodigoBodega, s => s.MapFrom(src => src.WarehouseCode))
                    .ForPath(d => d.CodigoIVA, s => s.MapFrom(src => src.IVA))
                    .ForPath(d => d.Eliminado, s => s.MapFrom(src => src.IsDeleted))
                    .ForPath(d => d.PorcentajeIVA, s => s.MapFrom(src => decimal.Parse(src.IVA)))
                    .ForPath(d => d.CodigoIVA, s => s.MapFrom(src => src.IVACode))
                    .ForPath(d => d.Total, s => s.MapFrom(src => int.Parse(src.Total.ToString())))
                    .ForPath(d => d.ValorUnitario, s => s.MapFrom(src => (int)Convert.ToDouble(src.UnitPrice)))
                    .ForPath(d => d.ValorUnitarioMasIVA, s => s.MapFrom(src => (int)src.TotalPricePlusIVA));

                    cfg.CreateMap<BOObtenerTipoBodegaAResponse, BOWareHouseTypes>()
                    .ForPath(d => d.WhsPrefix, s => s.MapFrom(src => src.PrefijoBodega))
                    .ForPath(d => d.WhsTypeName, s => s.MapFrom(src => src.TipoBodega))
                    .ForPath(d => d.WareHouses, s => s.MapFrom(src => src.Bodegas));

                    cfg.CreateMap<BOObtenerTipoBodegaAResponseBodegas, BOWareHouse>()
                    .ForPath(d => d.WhsCode, s => s.MapFrom(src => src.Codigo))
                    .ForPath(d => d.WhsName, s => s.MapFrom(src => src.Nombre));

                    cfg.CreateMap<EmpaqueResponse, BOPackage>()
                    .ForPath(d => d.PackageId, s => s.MapFrom(src => src.EmpaqueId))
                    .ForPath(d => d.PackageName, s => s.MapFrom(src => src.EmpaqueNombre));

                    cfg.CreateMap<BOAudit, RegistroAuditoriaRequest>()
                    .ForPath(d => d.Accion, s => s.MapFrom(src => src.Action))
                    .ForPath(d => d.Parametros, s => s.MapFrom(src => src.Parameters));

                    cfg.CreateMap<PedidoRespuestaResponse, BOPedidoRespuesta>();
                   
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
