using AutoMapper;
using EVO_BusinessObjects;
using EVO_WebApi.Models.ArticuloApi;
using EVO_WebApi.Models.ArticulosApi;
using EVO_WebApi.Models.AuditoriaApi;
using EVO_WebApi.Models.AutenticarApi;
using EVO_WebApi.Models.BasculasApi;
using EVO_WebApi.Models.BodegasApi;
using EVO_WebApi.Models.CajasApi;
using EVO_WebApi.Models.ClientesExternosApi;
using EVO_WebApi.Models.ClientesParametrizacionApi;
using EVO_WebApi.Models.ContenedoresApi;
using EVO_WebApi.Models.DocumentosApi;
using EVO_WebApi.Models.EntregasApi;
using EVO_WebApi.Models.EvidenciaApi;
using EVO_WebApi.Models.FacturacionApi;
using EVO_WebApi.Models.IntegracionesApi;
using EVO_WebApi.Models.ModulosApi;
using EVO_WebApi.Models.MotivosApi;
using EVO_WebApi.Models.ParametrosGeneralesApi;
using EVO_WebApi.Models.PedidosApi;
using EVO_WebApi.Models.PesajeApi;
using EVO_WebApi.Models.RecepcionApi;
using EVO_WebApi.Models.RolesApi;
using EVO_WebApi.Models.SociosNegocioApi;
using EVO_WebApi.Models.UsuariosApi;
using EVO_WebApi.Models.VehiculosApi;
using IO.Swagger.Models.PedidosApi;
using IO.Swagger.Models.VehiculosApi;

namespace EVO_WebApi.Models.AutoMapperConfig
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Se agregan todos los mapeos necesarios
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<EnrutamientoRespuesta, EnrutamientoResponse>();
            CreateMap<TipoVehiculoRespuesta, TipoVehiculoResponse>();
            CreateMap<VehiculoRespuesta, VehiculoResponse>();
            CreateMap<MuelleRespuesta, MuelleResponse>();
            CreateMap<Empleado, EmpleadoResponse>();

            CreateMap<RegistroAuditoria, ObtenerTodosRegistrosResponseRegistros>();
            CreateMap<RegistroAuditoriaRequest, RegistroAuditoria>();
            CreateMap<CrearRolRequest, Rol>();
            CreateMap<FiltrarAuditoriaRequest, FiltroAuditoria>().
               ForMember(d => d.Accion, s => s.MapFrom(src => src.Filtro.Accion)).
               ForMember(d => d.Fecha, s => s.MapFrom(src => src.Filtro.Fecha)).
               ForMember(d => d.IP, s => s.MapFrom(src => src.Filtro.Ip)).
               ForMember(d => d.Parametros, s => s.MapFrom(src => src.Filtro.Parametros)).
               ForMember(d => d.Usuario, s => s.MapFrom(src => src.Filtro.Usuario));
            CreateMap<RegistroAuditoria, ObtenerTodosRegistrosResponseRegistros>();
            CreateMap<Modulo, ObtenerModuloResponse>();
            CreateMap<Funcionalidad, ObtenerModuloResponseFuncionalidades>();
            CreateMap<ParametroGeneral, ParametroGeneralResponse>();
            CreateMap<ActualizarParametroGeneralRequest, ParametroGeneral>();
            CreateMap<Modulo, ObtenerTodosModulosResponseRegistros>();
            CreateMap<Funcionalidad, ObtenerTodosModulosResponseFuncionalidades>();
            CreateMap<ActivarParametroGeneralRequest, ParametroGeneral>();
            CreateMap<CrearParametroGeneralRequest, ParametroGeneral>();
            CreateMap<ParametroGeneral, ObtenerTodosParametrosGeneralesResponseRegistros>();
            CreateMap<ActualizarRolRequest, Rol>().ForMember(d => d.Administracion, s => s.MapFrom(src => src.Administrador));
            CreateMap<DesasociarUsuariosARolRequest, DesasociarUsuariosARol>();
            CreateMap<ActivarRolRequest, Rol>();
            CreateMap<Rol, ObtenerRolResponse>();
            CreateMap<Usuario, EVO_WebApi.Models.RolesApi.UsuarioResponse>();
            CreateMap<Funcionalidad, FuncionalidadResponse>();
            CreateMap<Rol, ObtenerRolResponse>();
            CreateMap<Rol, ObtenerTodosRolesResponseRegistros>();
            CreateMap<FiltrarRolRequest, FiltroRol>().ForMember(d => d.Nombre, s => s.MapFrom(src => src.Filtro.Nombre));
            CreateMap<Usuario, ObtenerTodosUsuariosGrupoDominioMenosRolResponseRegistros>().
                ForMember(d => d.Usuario, s => s.MapFrom(src => src.NombreUsuario));
            CreateMap<AsociarUsuariosARolRequest, AsociarUsuariosARol>();
            CreateMap<EVO_WebApi.Models.UsuariosApi.UsuarioResponse, Usuario>();
            CreateMap<Usuario, ObtenerTodosUsuariosRolResponseRegistros>().
                ForMember(d => d.Usuario, s => s.MapFrom(src => src.NombreUsuario));
            CreateMap<FiltrarUsuarioXRolRequest, FiltroUsuario>().
                ForMember(d => d.Usuario, s => s.MapFrom(src => src.Filtro.Usuario)).
                ForMember(d => d.Nombre, s => s.MapFrom(src => src.Filtro.Nombre));
            CreateMap<AutenticarRequest, AutenticarSolicitud>();
            CreateMap<AutenticarRespuesta, AutenticarResponse>();
            CreateMap<SesionRespuesta, ObtenerTodosSesionesResponseRegistros>();
            CreateMap<RegistroLogRequest, RegistroLOG>();
            CreateMap<FiltrarSesionRequest, FiltroSesion>().
                ForMember(d => d.FechaExpiracion, s => s.MapFrom(src => src.Filtro.FecheExpiracion)).
                ForMember(d => d.FechaInicio, s => s.MapFrom(src => src.Filtro.FecheInicio)).
                ForMember(d => d.SesionId, s => s.MapFrom(src => src.Filtro.SesionId)).
                ForMember(d => d.Token, s => s.MapFrom(src => src.Filtro.Token)).
                ForMember(d => d.ÏP, s => s.MapFrom(src => src.Filtro.Ip)).
                ForMember(d => d.Usuario, s => s.MapFrom(src => src.Filtro.Usuario));
            CreateMap<ProgramarEjecucionRequest, ProgramarEjecucionIntegracionSolicitud>();
            CreateMap<ProgramarEjecucionRequest, ProgramarEjecucionIntegracionSolicitud>();
            CreateMap<HabilitarIntegracionRequest, HabilitarEjecucionIntegracionSolicitud>();
            CreateMap<EstadoEjecucionIntegracionRespuesta, ObtenerEstadoEjecucionArticulosResponse>();
            CreateMap<LogIntegracionRespuesta, ObtenerLogsEjecucionArticulosResponseRegistros>();
            CreateMap<FiltrarLogsEjecucionArticulosRequest, FiltroIntegracion>().
                ForMember(d => d.Estado, s => s.MapFrom(src => src.Filtro.Estado)).
                ForMember(d => d.FechaInicio, s => s.MapFrom(src => src.Filtro.FechaInicio)).
                ForMember(d => d.FechaFin, s => s.MapFrom(src => src.Filtro.FechaFin)).
                ForMember(d => d.LogJob, s => s.MapFrom(src => src.Filtro.LogJob)).
                ForMember(d => d.LogIntegracion, s => s.MapFrom(src => src.Filtro.LogIntegracion));
            CreateMap<LogIntegracionRespuesta, ObtenerLogsEjecucionArticulosResponseRegistros>();
            CreateMap<PedidoRequest, Pedido>();
            CreateMap<PedidoRequestDetalles, DetallePedido>();
            CreateMap<BOBodega, BodegaResponse>();
            CreateMap<BOEstadoArticulo, EstadoArticuloResponse>();
            CreateMap<UnidadMedida, UnidadMedidaResponse>();
            CreateMap<ArticuloBodega, ObtenerTodosArticulosResponseRegistros>();
            CreateMap<FiltrarArticuloRequest, FiltroArticulo>().
                ForMember(d => d.CodigoArticulo, s => s.MapFrom(src => src.Filtro.CodigoArticulo)).
                ForMember(d => d.Stock, s => s.MapFrom(src => src.Filtro.Stock)).
                ForMember(d => d.NombreArticulo, s => s.MapFrom(src => src.Filtro.NombreArticulo)).
                ForMember(d => d.Maximo, s => s.MapFrom(src => src.Filtro.Maximo)).
                ForMember(d => d.Minimo, s => s.MapFrom(src => src.Filtro.Minimo)).
                ForMember(d => d.WhsCode, s => s.MapFrom(src => src.Filtro.WhsCode));
            CreateMap<BuscarArticuloRequest, BuscarArticuloBodegaSolicitud>();
            CreateMap<ArticuloBodega, ArticuloResponse>();
            CreateMap<FiltrarPedidoRequest, FiltroPedido>().
                ForMember(d => d.PlantaDerivados, s => s.MapFrom(src => src.Filtro.PlantaDerivados)).
                ForMember(d => d.PlantaBeneficio, s => s.MapFrom(src => src.Filtro.PlantaBeneficio)).
                ForMember(d => d.Desde, s => s.MapFrom(src => src.Desde)).
                ForMember(d => d.Estado, s => s.MapFrom(src => src.Filtro.Estado)).
                ForMember(d => d.Pendientes, s => s.MapFrom(src => src.Filtro.Pendientes)).
                ForMember(d => d.FechaDesde, s => s.MapFrom(src => src.Filtro.Desde)).
                ForMember(d => d.FechaHasta, s => s.MapFrom(src => src.Filtro.Hasta)).
                ForMember(d => d.Hasta, s => s.MapFrom(src => src.Hasta)).
                ForMember(d => d.Numeropedido, s => s.MapFrom(src => src.Filtro.Numeropedido));
            CreateMap<PedidoRespuesta, ObtenerTodosPedidosResponseRegistros>();
            CreateMap<ConsultaPedidoRespuesta, ConsultaPedidoResponse>();
            CreateMap<ConsultaDetallePedidoRespuesta, ConsultaPedidoResponseDetalles>();
            CreateMap<ObtenerPedidoRespuesta, ObtenerPedidoResponse>();
            CreateMap<ObtenerPedidoRespuestaDetalles, ObtenerPedidoResponseDetalles>();
            CreateMap<EstadoPedido, ObtenerEstadoPedidoResponse>().
                ForMember(d => d.EstadoNombre, s => s.MapFrom(src => src.Nombre)).
                ForMember(d => d.EstadoId, s => s.MapFrom(src => src.EstadoPedidoId));
            CreateMap<ObtenerPedidoBorradorRequest, ObtenerPedidoBorradorPeticion>();
            CreateMap<BOArticulo, ArticuloUnicoResponse>();
            CreateMap<PedidoBeneficioRespuesta, ObtenerTodosPedidosBeneficioResponseRegistros>();
            CreateMap<ClienteExterno, ObtenerClienteExternoResponse>();
            CreateMap<FiltrarPedidoBeneficioRequest, FiltroPedidoBeneficio>().
                ForMember(d => d.FechaSolicitud, s => s.MapFrom(src => src.Filtro.FechaSolicitud)).
                ForMember(d => d.FechaEntrega, s => s.MapFrom(src => src.Filtro.FechaEntrega)).
                ForMember(d => d.Desde, s => s.MapFrom(src => src.Desde)).
                ForMember(d => d.Hasta, s => s.MapFrom(src => src.Hasta)).
                ForMember(d => d.CodigoPedido, s => s.MapFrom(src => src.Filtro.CodigoPedido)).
                ForMember(d => d.DiasEntrega, s => s.MapFrom(src => src.Filtro.DiasEntrega)).
                ForMember(d => d.Estado, s => s.MapFrom(src => src.Filtro.Estado)).
                ForMember(d => d.Cliente, s => s.MapFrom(src => src.Filtro.Cliente)).
                ForMember(d => d.Zona, s => s.MapFrom(src => src.Filtro.Zona));
            CreateMap<PedidoBeneficioRespuesta, ObtenerTodosPedidosResponseRegistros>();
            CreateMap<PedidoEnPlantaRespuesta, ObtenerPedidoEnPlantaResponse>();
            CreateMap<PedidoDetalleEnPlantaRespuesta, ObtenerPedidoEnPlantaResponsePedidoDetallesRespuesta>();
            CreateMap<PedidoRequest, Pedido>();
            CreateMap<PedidoRequestDetalles, DetallePedido>();
            CreateMap<ActualizarPedidoPlantaBeneficioRequest, PedidoPlantaBeneficio>();
            CreateMap<ActualizarPedidoPlantaBeneficioRequestDetalles, PedidoPlantaBeneficioDetalle>();
            CreateMap<PedidoBeneficioRespuesta, ObtenerTodosPedidosBeneficioResponseRegistros>();
            CreateMap<FiltrarEntregasDistribucionRequest, FiltroPedidoDistribucion>().
                ForMember(d => d.Cliente, s => s.MapFrom(src => src.Filtro.Cliente)).
                ForMember(d => d.CodigoPedido, s => s.MapFrom(src => src.Filtro.CodigoPedido)).
                ForMember(d => d.Desde, s => s.MapFrom(src => src.Desde)).
                ForMember(d => d.Hasta, s => s.MapFrom(src => src.Hasta)).
                ForMember(d => d.NumeroEntrega, s => s.MapFrom(src => src.Filtro.NumeroEntrega)).
                ForMember(d => d.FechaEntrega, s => s.MapFrom(src => src.Filtro.FechaEntrega)).
                ForMember(d => d.HoraEntrega, s => s.MapFrom(src => src.Filtro.HoraEntrega)).
                ForMember(d => d.Peso, s => s.MapFrom(src => src.Filtro.Peso)).
                ForMember(d => d.Zona, s => s.MapFrom(src => src.Filtro.Zona));
            CreateMap<PedidoDistribucionRespuesta, ObtenerTodosPedidosDistribucionResponseRegistros>();
            CreateMap<ObtenerPedidoDistribucion, ObtenerPedidoDistribucionResponse>().
                ForMember(d => d.PedidoDetallesRespuesta, s => s.MapFrom(src => src.Detalles));
            CreateMap<ObtenerPedidoDistribucionDetalle, ObtenerPedidoDistribucionResponseDetallesRespuesta>();
            CreateMap<EntregasRequest, EntregaPedido>();
            CreateMap<EntregasRequestDetalles, DetalleEntregaPedido>();
            CreateMap<ActualizarEntregaRequest, ActualizarEntrega>();
            CreateMap<ActualizarEntregaRequestDetalles, ActualizarEntregaDetalle>();
            CreateMap<EntregaRespuesta, EntregasResponse>();
            CreateMap<EntregaArticulo, EntregasResponseArticulos>();
            CreateMap<Entrega, EntregasResponseEntregas>();
            CreateMap<EntregaDetalle, EntregasResponseDetalles>();
            CreateMap<EntregaPedido, EntregaxIdRespuesta>();
            CreateMap<DetalleEntregaPedido, DetalleEntregaPedido>();
            CreateMap<MotivoRespuesta, MotivoResponse>();
            CreateMap<EntregaEnrutamientoRespuesta, ObtenerTodosEntregasDistribucionResponseRegistros>();
            CreateMap<TipoVehiculoRespuesta, TipoVehiculoResponse>();
            CreateMap<VehiculoRespuesta, VehiculoResponse>();
            CreateMap<EntregaBO, Models.PedidosApi.EntregaResponse>();
            CreateMap<EntregaDetalleBO, EntregaResponseDetalles>();
            CreateMap<Empleado, EmpleadoResponse>();
            CreateMap<AsignarDistribucionRequest, DistribucionSolicitud>();
            CreateMap<Usuario, EVO_WebApi.Models.UsuariosApi.UsuarioResponse>();
            CreateMap<ObtenerViajeEntregasRespuesta, ObtenerViajeEntregasResponse>();
            CreateMap<ObtenerViajeEntregasRespuestaEntregas, ObtenerViajeEntregasResponseEntregas>();
            CreateMap<ObtenerViajeEntregasRespuestaArticulos, ObtenerViajeEntregasResponseArticulos>();
            CreateMap<EntregaRequest, EntregaSolicitud>();
            CreateMap<EntregaRequestArticulos, EntregaSolicitudArticulos>();
            CreateMap<EntregaDistribucionRequest, EntregaSolicitud>();
            CreateMap<EntregaRequestArticulos, EntregaSolicitudArticulos>();
            CreateMap<ArticuloPendienteRespuesta, ArticuloPendienteResponse>();
            CreateMap<EliminarArticuloDistribucionRequest, EliminarArticuloDistribucion>();
            CreateMap<MuelleRespuesta, MuelleResponse>();
            CreateMap<EntregaEnrutamientoRespuesta, ObtenerTodosEntregasEnrutamientoResponseRegistros>();
            CreateMap<AsignarDistribucionRequest, ActualizarVehiculoEnrutamiento>();
            CreateMap<ActualizaVehiculoEnrutamientoRequest, ActualizarVehiculoEnrutamiento>();
            CreateMap<EntregaEnrutamientoRespuesta, ObtenerTodosEntregasEnrutamientoResponseRegistros>();
            CreateMap<VehiculoEnrutamientoRespuesta, VehiculoEnrutamientoResponse>();
            CreateMap<PedidoRespuesta, PedidoResponse>().
                ForMember(d => d.Codigo, s => s.MapFrom(src => src.CodigoPedido));
            CreateMap<EntregaRespuesta, Models.EntregasApi.EntregaResponse>();
            CreateMap<DetalleEntregaRespuesta, DetalleEntregaResponse>();
            CreateMap<ArticuloPesajeRespuesta, ArticuloAlistamientoResponse>();
            CreateMap<BOTipoBascula, TipoBasculaResponse>();
            CreateMap<BOTipoContenedorRespuesta, TipoContenedorResponse>();
            CreateMap<BOBodega, BodegaResponse>();
            CreateMap<RecepcionEncabezadoRespuesta, RecepcionEncabezadoResponse>();
            CreateMap<BOArticuloDocumentoResponse, ArticuloDocumentoResponse>();
            CreateMap<ArticuloRecepcionRespuesta, ArticuloRecepcionResponse>();
            CreateMap<PesajeRequest, BOPesajeRequest>();
            CreateMap<ContenedorRequest, BOContenedorRequest>();
            CreateMap<BOCodigoBarras, CodigoBarrasResponse>();
            CreateMap<BOPesajeContenedorResponse, PesajeContenedorResponse>();
            CreateMap<BOCodigoBarrasResponse, CodigoBarrasResponse>();
            CreateMap<CantidadRecibidaRequest, BOCantidadRecibidaRequest>();
            CreateMap<BOPesaje, PesajeResponse>().
                ForMember(d => d.PesoArticulo, s => s.MapFrom(src => src.PesoBasculaArticulos));
            CreateMap<EvidenciaRequest, BOEvidenciaRequest>();
            CreateMap<ArchivoRequest, BOArchivoRequest>();
            CreateMap<BODocumento,DocumentoResponse>();          
            CreateMap<BOEvidenciaResponse,EvidenciaResponse>();
            CreateMap<BODetalleEvidenciaResponse, DetalleEvidenciaResponse>();
            CreateMap<BOArchivoResponse, ArchivoResponse>();
            CreateMap<BODocumentoArticuloResponse,DocumentoArticuloResponse>();
            CreateMap<BORecepcionResponse,RecepcionResponse>();
            CreateMap<BOArticuloDocumentoResponse,ArticuloDocumentoResponse>();
            CreateMap<BOParametrizacionResponse, ParametrizacionResponse>();
            CreateMap<AperturaCajaRequest, BOAperturaCajaRequest>();
            CreateMap<BOAperturaCajaResponse, AperturaCajaResponse>();
            CreateMap<BOEstadoCajaResponse, EstadoCajaResponse>();
            CreateMap<BOSocioNegocioResponse, SocioNegocioResponse>();
            CreateMap<BOVendedorResponse,VendedorResponse>();
            CreateMap<BOArticuloPuntoVentaResponse,ArticuloPuntoVentaResponse>();
            CreateMap<BOArticuloTransformacionResponse, ArticuloTransformacionResponse>();
            CreateMap<FiltrarArticulosFacturacionRequest, BOFiltrarArticulosFacturacionRequest>();
            CreateMap<FormaPagoBO,FormaPagoResponse>();
            CreateMap<BancoBO,BancoResponse>();
            CreateMap<FacturaRequest, FacturaRequestBO>();
            CreateMap<ArticuloRequest, ArticuloRequestBO>();
            CreateMap<FormaPagoRequest, FormaPagoRequestBO>();
            CreateMap<BOObtenerTipoSolicitudPedidoResponse,ObtenerTipoSolicitudPedidoResponse>();
            CreateMap<BOObtenerSolicitudPedidoBorradorResponse,ObtenerSolicitudPedidoBorradorResponse>();
            CreateMap<BOObtenerTipoBodegaAResponse,ObtenerTipoBodegaAResponse>();
            CreateMap<BOObtenerTipoBodegaAResponseBodegas, ObtenerTipoBodegaAResponseBodegas>();
            CreateMap<BOEmpaque,EmpaqueResponse>();
            CreateMap<BOBodega,BodegaResponse>();
            CreateMap<BOPedidoConsultaResponse,PedidoConsultaResponse>();
            CreateMap<BOArticuloConsultaResponse, ArticuloConsultaResponse>();
            CreateMap<BOAccionCompraResponse, AccionCompraResponse>();
            CreateMap<CancelarPedidoRequest, BOCancelarPedidoRequest>();
            CreateMap<EditarPedidoRequest, BOEditarPedidoRequest>();
            CreateMap<EditarPedidoRequestArticulos, BOEditarPedidoRequestArticulos>();
            CreateMap<Accion, AccionResponse>();
            CreateMap<SerieRespuesta, SerieResponse>();
            CreateMap<FiltrarPedidoCompraRequest, BOFiltrarPedidoCompraRequest>().
                ForMember(d => d.Cliente, s => s.MapFrom(src => src.Filtro.Cliente)).
                ForMember(d => d.DiasEntrega, s => s.MapFrom(src => src.Filtro.DiasEntrega)).
                ForMember(d => d.Desde, s => s.MapFrom(src => src.Desde)).
                ForMember(d => d.Hasta, s => s.MapFrom(src => src.Hasta)).
                ForMember(d => d.EstadoPedido, s => s.MapFrom(src => src.Filtro.EstadoPedido)).
                ForMember(d => d.FechaLimiteSugerida, s => s.MapFrom(src => src.Filtro.FechaLimiteSugerida)).
                ForMember(d => d.FechaSolicitud, s => s.MapFrom(src => src.Filtro.FechaSolicitud)).
                ForMember(d => d.NumeroPedido, s => s.MapFrom(src => src.Filtro.NumeroPedido));
            CreateMap<BOPedidoCompraGestionResponse, PedidoCompraGestionResponse>();
            CreateMap<BOArticuloCompraResponse, ArticuloCompraResponse>();
            CreateMap<BOAccionCompraResponse, AccionCompraResponse>();
            CreateMap<BOArticuloAccionCompraResponse, ArticuloAccionCompraResponse>();
            CreateMap<BOObtenerPedidosCompraResponseRegistros, ObtenerPedidosCompraResponseRegistros>();
            CreateMap<CompraRequest, BOCompraRequest>();
            CreateMap<ArticuloCompraRequest, BOArticuloCompraRequest>();
            CreateMap<ActualizarCompraRequest, BOActualizarCompraRequest>();
            CreateMap<ArticuloActualizarCompraRequest, BOArticuloActualizarCompraRequest>();
            CreateMap<BOArticuloPendienteCompraResponse,ArticuloPendienteCompraResponse>();
            CreateMap<PedidoTrasladoRequest, BOPedidoTrasladoRequest>();
            CreateMap<ArticuloTrasladoRequest, BOArticuloTrasladoRequest>();

            CreateMap<CargarArchivoRequest, BOCargarArchivoRequest>();
            CreateMap<EliminarArchivoRequest, BOCargarArchivoRequest>();
            CreateMap<FiltrarArchivoRequest, FiltroArchivo>().
                ForMember(d => d.NombreArchivo, s => s.MapFrom(src => src.Filtro.NombreArchivo)).
                ForMember(d => d.Desde, s => s.MapFrom(src => src.Desde)).
                ForMember(d => d.Hasta, s => s.MapFrom(src => src.Hasta)).
                ForMember(d => d.FechaCarga, s => s.MapFrom(src => src.Filtro.FechaCarga)).
                ForMember(d => d.FechaInicial, s => s.MapFrom(src => src.Filtro.FechaDesde)).
                ForMember(d => d.FechaFinal, s => s.MapFrom(src => src.Filtro.FechaHasta))
                ;

            CreateMap<ArchivoRespuesta, ObtenerTodosArchivosResponseRegistros>();
            CreateMap<BOPedidoRespuesta, PedidoRespuestaResponse>();
        }
    }
}