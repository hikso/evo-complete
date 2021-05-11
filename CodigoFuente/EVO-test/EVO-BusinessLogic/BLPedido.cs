using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using EVO_Proxy;
using EVO_PV_BusinessObjects.Enum;
using EVO_Services;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.SqlServer.Management.Smo;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga
    /// Fecha de Creación: 20-Sep/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de los pedidos
    /// </summary>     

    public class BLPedido
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Notificacion notificacion = null;
        #endregion      

        #region Contructores
        public BLPedido()
        {
            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();
            notificacion = new Notificacion(
                bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.NOTIFICACION_CREDENCIALES_CORREO),
                bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.NOTIFICACION_CREDENCIALES_CONTRASENIA),
                bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.SMTP_HOST),
               int.Parse(bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.SMTP_PORT))
                );
        }

        /// <summary>
        /// Asigna las ordenes de compra a un documento
        /// </summary>
        /// <param name="documento">Número de documento</param>
        /// <param name="gestionesCompras">Ordenes de compra</param>
        /// <response>true</response>
        public async Task<bool> AsignarOrdenesCompraxDocumento(string documento, List<BOGestionCompra> gestionesCompras)
        {
            if (string.IsNullOrEmpty(documento))
            {
                EVOException e = new EVOException(errores.errDocumentoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (gestionesCompras==null || gestionesCompras.Count==0)
            {
                EVOException e = new EVOException(errores.errGestionesComprasNoInformadas);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método AsignarOrdenesCompraxDocumento con parámetros documento = {documento} , gestionesCompras = {JsonConvert.SerializeObject(gestionesCompras)} ");

            foreach (var gestionCompra in gestionesCompras)
            {
                if (string.IsNullOrEmpty(gestionCompra.OrdenCompra))
                {
                    EVOException e = new EVOException(errores.errOrdenCompraNoInformada);

                    logger.Error(e);

                    throw e;
                }

                if (string.IsNullOrEmpty(gestionCompra.CodigoArticulo))
                {
                    EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                    logger.Error(e);

                    throw e;
                }
            }           

            DAPedido dAPedido = new DAPedido();          

            try
            {
                await dAPedido.AsignarOrdenesCompraxDocumento(documento,gestionesCompras);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;
        }



        #endregion

        #region Métodos Públicos        

        /// <summary>
        /// Retorna los números de documento pendientes de números de orden
        /// </summary>       
        /// <response>BOGestionCompra</response>
        public async Task<List<string>> ObtenerDocumentosPendientesOrdenesSAP()
        {
            logger.Info($"Entró al método ObtenerDocumentosPendientesOrdenesSAP sin parámetros");

            DAPedido dAPedido = new DAPedido();

            List<string> documentos = null;

            try
            {
                 documentos = await dAPedido.ObtenerDocumentosPendientesOrdenesSAP();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }            

            return documentos.Where(d => !string.IsNullOrEmpty(d)).ToList();
        }

        /// <summary>
        /// Este método se encarga de cargar y mapear las líneas de un archivo plano de canales  a obejtos de negocio
        /// </summary>
        /// <param name="bOArchivoRequest">Instancia del objeto de carga de archivo request</param>
        /// <returns>true/false</returns>
        public bool CargarArchivoCanales(BOCargarArchivoRequest bOArchivoRequest)
        {
            this.ValidarParametrosCargaArchivos(bOArchivoRequest);
            string rutaCompletaArchivoCargar = this.ValidarArchivo(bOArchivoRequest);
            List<ProduccionSemanal> lstproduccionSemanal = null;
            DAPedido dAPedido = new DAPedido();
            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            lstproduccionSemanal = this.prvCrearProduccionFutura(rutaCompletaArchivoCargar);

            #region Codigo old Archivo Plano Completo
            //List<ArchivosPlanosMapeo> valoresMapeadosArchivosPlano = File.ReadAllLines(rutaCompletaArchivoCargar)
            //                                      .Skip(1)
            //                                      .Select(v => ArchivosPlanosMapeo.FromCsv(v, bOArchivoRequest.Separador.ToString()))
            //                                      .ToList();
            //DAPedido dAPedido = new DAPedido();
            //BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
            //ArchivosPlanosMapeo objArchivosPlanosMapeo = new ArchivosPlanosMapeo();

            //objArchivosPlanosMapeo.FechaInicial = Convert.ToDateTime(bOArchivoRequest.FechaInicial);
            //objArchivosPlanosMapeo.FechaFinal = Convert.ToDateTime(bOArchivoRequest.FechaFinal);
            //objArchivosPlanosMapeo.NombreArchivo = nombreArchivoAlmacenar;

            //for (int i = 0; i < valoresMapeadosArchivosPlano.Count; i++)
            //{
            //    valoresMapeadosArchivosPlano[i].FechaInicial = objArchivosPlanosMapeo.FechaInicial;
            //    valoresMapeadosArchivosPlano[i].FechaFinal = objArchivosPlanosMapeo.FechaFinal;
            //    valoresMapeadosArchivosPlano[i].NombreArchivo = objArchivosPlanosMapeo.NombreArchivo;
            //}
            #endregion
            
            try
            {
                //dAPedido.CargarArchivosPlanosCanales(valoresMapeadosArchivosPlano);
                dAPedido.CargarProduccionSemanal(lstproduccionSemanal);

            }
            catch (Exception e)
            {
                string rutaArchivoBorrado= bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.RUTA_ARCHIVOCANALES);
                Directory.Delete(rutaArchivoBorrado, true);

                throw e;
            }

            return true;

        }

        private List<ProduccionSemanal> prvCrearProduccionFutura(string rutaCompletaArchivoCargar)
        {
            string[] values = rutaCompletaArchivoCargar.Split("/");
            string nombreArchivoAlmacenar = values[1].ToString();

            List<ProduccionSemanal> lstproduccionSemanalCargar = new List<ProduccionSemanal>();
            List<ProduccionDiaria> lstproduccionDiariaCargar = new List<ProduccionDiaria>();
            List<DetalleProduccionDiaria> lstdetalleProduccionDiaria = new List<DetalleProduccionDiaria>();

            ProduccionSemanal oProduccionSemanalFila = new ProduccionSemanal();
            ProduccionDiaria oProduccionDiariaFila = new ProduccionDiaria();
            DetalleProduccionDiaria odetalleProduccionDiaria = new DetalleProduccionDiaria();


            using (var stream = File.Open(rutaCompletaArchivoCargar, FileMode.Open, FileAccess.Read))
                {
                    
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();

                        // Ejemplos de acceso a datos
                        DataTable table = result.Tables[0];
                        DataRow row = null;                      
                        for (int i = 1; i < table.Rows.Count; i++)
                            {
                            row = table.Rows[i];
                            oProduccionSemanalFila = new ProduccionSemanal(); 
                            oProduccionSemanalFila.Ano = int.Parse(row.ItemArray[0].ToString());
                            oProduccionSemanalFila.Mes = Convert.ToInt32(row.ItemArray[1]);
                            oProduccionSemanalFila.Semana = Convert.ToInt32(row.ItemArray[2]);
                            oProduccionSemanalFila.PesoTotal = Convert.ToDecimal(row.ItemArray[3]);
                            oProduccionSemanalFila.PesoDeshuesadoTotal = Convert.ToDecimal(row.ItemArray[4]);
                            oProduccionSemanalFila.PorcentajeArticulo = Convert.ToDecimal(row.ItemArray[5]);
                            oProduccionSemanalFila.CodigoArticulo = row.ItemArray[6].ToString();
                            oProduccionSemanalFila.FechaCarga = System.DateTime.Now;
                            oProduccionSemanalFila.NombreArchivo = nombreArchivoAlmacenar;

                            lstproduccionSemanalCargar.Add(oProduccionSemanalFila);
                        }
                        table = result.Tables[1];
                        row = null;
                        for (int i = 1; i < table.Rows.Count; i++)
                        {
                            row = table.Rows[i];
                            oProduccionDiariaFila = new ProduccionDiaria();
                            oProduccionDiariaFila.FechaProduccion = Convert.ToDateTime(row.ItemArray[0]);
                            oProduccionDiariaFila.NumeroCanales = Convert.ToInt32(row.ItemArray[1]);
                            oProduccionDiariaFila.PesoCaliente = Convert.ToDecimal(row.ItemArray[4]);
                            oProduccionDiariaFila.PesoPromedioDia = Convert.ToDecimal(row.ItemArray[5]);                           

                        lstproduccionSemanalCargar.Add(oProduccionSemanalFila);
                        }


                }
                }
            return lstproduccionSemanalCargar;
        }

        /// <summary>
        /// Elimina el archivo de cargas canales , hospedado en el servidor
        /// </summary>
        /// <param name="bOEliminarRequest"></param>
        /// <returns></returns>
        public object EliminarArchivoCanales(BOCargarArchivoRequest bOEliminarRequest)
        {
            this.ValidarParametrosEliminarArchivos(bOEliminarRequest);
            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
            string rutaDirectorioArchivoCanales;
            string rutaArchivoCanales;

            try
            {
                rutaDirectorioArchivoCanales = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.RUTA_ARCHIVOCANALES);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (Directory.Exists(rutaDirectorioArchivoCanales))
            {
                try
                {
                    rutaArchivoCanales = rutaDirectorioArchivoCanales + "/" + bOEliminarRequest.NombreArchivo;
                    if (File.Exists(rutaArchivoCanales))
                    {
                        DirectoryInfo directoryInfo = null;
                        directoryInfo = new DirectoryInfo(rutaDirectorioArchivoCanales);
                        File.Delete(rutaArchivoCanales);
                    }
                    else
                    {
                        EVOException e = new EVOException(errores.errArchivoCargaNoInformado);

                        logger.Error(e);

                        throw e;
                    }
                  
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    throw;
                }
            }
            else
            {
                EVOException e = new EVOException(errores.errDirectorioNoExiste);

                logger.Error(e);

                throw e;
            }

            return true;
        }


        /// <summary>
        /// Función que retorna la lista de archivos cargados en BD
        /// </summary>
        /// <param name="filtroArchivo"></param>
        /// <returns></returns>
        public List<ArchivoRespuesta> ObtenerTodosArchivosxFiltro(FiltroArchivo filtroArchivo)
        {
            ValidarParametrosFiltroArchivos(filtroArchivo);

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();
            string valorPaginacion = null;
            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
            int maximoPaginacion = int.Parse(valorPaginacion);
            if ((filtroArchivo.Hasta - filtroArchivo.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));
                logger.Error(e);
                throw e;
            }

            if (filtroArchivo.NombreArchivo == null && string.IsNullOrWhiteSpace(filtroArchivo.FechaCarga) && string.IsNullOrWhiteSpace(filtroArchivo.FechaInicial) && string.IsNullOrWhiteSpace(filtroArchivo.FechaFinal))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);
                logger.Error(e);
                throw e;
            }

            //if (string.IsNullOrEmpty(filtroArchivo.FechaCarga))
            //{
            //    EVOException e = new EVOException(errores.errFechaCarga);
            //    logger.Error(e);
            //    throw e;
            //}

            //if (string.IsNullOrEmpty(filtroArchivo.FechaInicial))
            //{
            //    EVOException e = new EVOException(errores.errFechaDesde);
            //    logger.Error(e);
            //    throw e;
            //}

            //if (string.IsNullOrEmpty(filtroArchivo.FechaFinal))
            //{
            //    EVOException e = new EVOException(errores.errFechaHasta);
            //    logger.Error(e);
            //    throw e;
            //}
            List<ArchivoRespuesta> lstarchivosRespuesta = null;
            try
            {
                lstarchivosRespuesta = dAPedidos.ObtenerTodosRegistrosArchivosxFiltro(filtroArchivo);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
            return lstarchivosRespuesta;
        }
       
        /// <summary>
        /// Retorna un objecto de negocio tipo GestionCompra
        /// </summary>
        /// <param name="detallePedidoId">Id del detalle del pedido</param>
        /// <param name="accionId">Id de la acción de compra</param>
        /// <response>BOGestionCompra</response>
        public BOGestionCompra ObtenerGestionCompra(int detallePedidoId, int accionId, bool validarGestionCompraNull)
        {
            if (detallePedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (accionId <= 0)
            {
                EVOException e = new EVOException(errores.errAccionIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerGestionCompra con los parámetros detallePedidoId = {detallePedidoId} , accionId = {accionId}");


            DAPedido dAPedido = new DAPedido();
            BOGestionCompra gestionCompra = null;

            try
            {
                gestionCompra = dAPedido.ObtenerGestionCompra(detallePedidoId, accionId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (validarGestionCompraNull)
            {
                if (gestionCompra == null)
                {
                    EVOException e = new EVOException(errores.errGestionCompraNoRegistrado);

                    logger.Error(e);

                    throw e;
                }
            }

            return gestionCompra;

        }

        /// <summary>
        /// Asigna un pedido en comercial como borrador(Abierto).
        /// </summary>
        /// <param name="body">Solicitud de una actualización a pedido en comercial traslado</param>
        /// <response>bool</response>
        public bool AsignarComercialTrasladoBorrado(BOPedidoTrasladoRequest pedido)
        {
            if (pedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método AsignarComercialTrasladoBorrado EVO - BLPedido con los parámetros: {0}",
               JsonConvert.SerializeObject(pedido)));

            ConfiguracionNotificacion configuracionNotificacion = new ConfiguracionNotificacion();

            if (pedido.PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(pedido.FechaLimiteSugerida))
            {
                EVOException e = new EVOException(errores.errFechaLimiteSugeridaNoInformada);

                logger.Error(e);

                throw e;
            }

            string pattern = string.Empty;

            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();

            try
            {
                pattern = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_FECHA_DDMMAA);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            Match regFechaMatch = Regex.Match(pedido.FechaLimiteSugerida, pattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                logger.Error(e);

                throw e;
            }

            if (DateTime.Parse(pedido.FechaLimiteSugerida) < DateTime.Now.Date)
            {
                EVOException e = new EVOException(errores.errFechaLimiteSugeridaMenorAHoy);

                logger.Error(e);

                throw e;
            }

            BLUsuario blUsuario = new BLUsuario();

            int nBackSlash = pedido.Usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                pedido.Usuario = pedido.Usuario.Substring(nBackSlash + 1, pedido.Usuario.Length - nBackSlash - 1);
            }

            Usuario buscar = blUsuario.ObtenerUsuarioPorUsuario(pedido.Usuario);

            if (buscar == null)
            {
                EVOException e = new EVOException(string.Format(errores.errUsuarioNoExiste,
                    pedido.Usuario));

                logger.Error(e);

                throw e;
            }

            pedido.UsuarioId = buscar.UsuarioId;

            BLArticulo bLArticulo = new BLArticulo();

            if (pedido.Articulos == null || pedido.Articulos.Count == 0)
            {
                EVOException e = new EVOException(errores.errArticulosNoInformados);

                logger.Error(e);

                throw e;
            }

            ObtenerPedidoRespuesta boPedido = ObtenerPedidoxId(pedido.PedidoId);

            foreach (var articulo in pedido.Articulos)
            {
                ObtenerPedidoRespuestaDetalles detalle = boPedido.Detalles.FirstOrDefault(d => d.DetallePedidoId == articulo.DetallePedidoId);

                if (detalle == null)
                {
                    EVOException e = new EVOException(errores.errArticuloBodegaNoInformado);

                    logger.Error(e);

                    throw e;
                }

                BOEmpaque bOEmpaque = bLArticulo.ObtenerEmpaques().FirstOrDefault(e => e.EmpaqueId == articulo.EmpaqueId);

                if (bOEmpaque == null)
                {
                    EVOException e = new EVOException(errores.errEmpaqueNoInformado);

                    logger.Error(e);

                    throw e;
                }

                BOEstadoArticulo estadoArticulo = bLArticulo.ObtenerEstadoArticuloxId(articulo.EstadoArticuloId);

                if (decimal.Parse(articulo.CantidadAprobada) <= 0)
                {
                    EVOException e = new EVOException(errores.errCantidadAprobadaCeroNegativa);

                    logger.Error(e);

                    throw e;
                }

                if (decimal.Parse(articulo.CantidadAprobada) > detalle.Cantidad)
                {
                    EVOException e = new EVOException(errores.errAprobadaExcedeSolciitada);

                    logger.Error(e);

                    throw e;
                }

            }

            DAPedido dAPedido = new DAPedido();

            try
            {
                dAPedido.AsignarComercialTrasladoBorrado(pedido);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }


            return true;
        }

        /// <summary>
        /// Obtiene las solicitudes de un pedido en estado borrador
        /// </summary>
        /// <param name="solicitudDe">Punto de venta que realiza la solicitud del pedido</param>
        /// <response >List<BOObtenerSolicitudPedidoBorradorResponse></response>
        public List<BOObtenerSolicitudPedidoBorradorResponse> ObtenerSolicitudPedidoBorrador(string solocitudDe)
        {
            logger.Info($"Entró al método ObtenerSolicitudPedidoBorrador en EVO-WebApi - BLPedidos con el parámetro solocitudDe = {solocitudDe}");

            if (string.IsNullOrEmpty(solocitudDe))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            List<BOObtenerSolicitudPedidoBorradorResponse> solicitudesBorrador = null;

            try
            {
                solicitudesBorrador = dAPedidos.ObtenerSolicitudPedidoBorrador(solocitudDe);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            foreach (BOObtenerSolicitudPedidoBorradorResponse solicitud in solicitudesBorrador)
            {
                solicitud.SolicitudA = solicitud.TipoSolicitudNombre == TiposSolicitudEnum.Compras.ToString() ? "ÁREA DE COMPRAS" : solicitud.SolicitudA;
            }

            return solicitudesBorrador;
        }

        /// <summary>
        /// Retorna el detalle del pedido de tipo compra a gestionar
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <response>BOPedidoCompraGestionResponse</response>
        public BOPedidoCompraGestionResponse ObtenerPedidoCompraGestion(int pedidoId)
        {
            logger.Info($"Entró el método ObtenerPedidoCompraGestion en EVO-WebApi - BLPedido con el parametro pedidoId = {pedidoId}");

            if (pedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedido = new DAPedido();

            BOPedidoCompraGestionResponse pedido = null;

            List<EstadoPedido> estadosPedido = ObtenerTodosEstadosPedido();

            if (estadosPedido.Count == 0)
            {
                EVOException e = new EVOException(errores.errEstadosPedidoNoRegistrados);

                logger.Error(e);

                throw e;
            }

            string[] estadosPedidoComprometidos = {
                EstadosPedidoEnum.Abierto.ToString(),
                EstadosPedidoEnum.Gestión_de_Compra.ToString().Replace("_"," "),
                EstadosPedidoEnum.Gestión_Traslado.ToString().Replace("_"," ")
            };

            try
            {
                pedido = dAPedido.ObtenerPedidoCompraGestion(pedidoId, estadosPedidoComprometidos);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (pedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoNOExiste);

                throw e;
            }

            try
            {

                BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
                BLArticulo blArticulo = new BLArticulo();

                string codigoAlmacen = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CODIGO_ALMACEN_COMPRA);

                foreach (var articulo in pedido.Articulos)
                {
                    articulo.Incluir = true;

                    BOArticuloBodegaSAP bOArticuloBodegaSAP = blArticulo.ObtenerArticuloxBodegaSAP(articulo.CodigoArticulo, codigoAlmacen);

                    articulo.StockAlmacen = bOArticuloBodegaSAP == null ? string.Empty : (bOArticuloBodegaSAP.Stock - articulo.CantidadComprometida).ToString();

                    if (!string.IsNullOrEmpty(articulo.StockAlmacen))
                    {
                        articulo.StockAlmacen = decimal.Parse(articulo.StockAlmacen) < 0 ? articulo.StockAlmacen = "0" : articulo.StockAlmacen;
                    }

                    foreach (var accion in pedido.Acciones)
                    {
                        BOArticuloAccionCompraResponse articuloAccion = accion.Articulos.FirstOrDefault(a => a.DetallePedidoId == articulo.DetallePedidoId);

                        if (articuloAccion != null)
                        {
                            articuloAccion.StockAlmacen = articulo.StockAlmacen.ToString();
                        }
                    }

                    List<BOArticuloAccionCompraResponse> articulos = new List<BOArticuloAccionCompraResponse>();

                    pedido.Acciones.ForEach(a => articulos.AddRange(a.Articulos));

                    decimal cantidadGestionada = 0;

                    if (articulos.Where(a => a.DetallePedidoId == articulo.DetallePedidoId).Count() >= 1)
                    {
                        cantidadGestionada = articulos
                            .Where(a => a.DetallePedidoId == articulo.DetallePedidoId).Sum(a => decimal.Parse(a.Cantidad));

                        articulo.CantidadFaltanteGestionar = (decimal.Parse(articulo.CantidadSolicitada) - cantidadGestionada).ToString();

                    }
                    else
                    {
                        articulo.CantidadFaltanteGestionar = articulo.CantidadSolicitada;
                    }

                    if (cantidadGestionada > decimal.Parse(articulo.CantidadSolicitada))
                    {
                        EVOException e = new EVOException(errores.errGestionadaExcedeSolicitada);

                        throw e;
                    }

                    if (cantidadGestionada == decimal.Parse(articulo.CantidadSolicitada))
                    {
                        articulo.Incluir = false;
                    }
                }

                //pedido.Articulos = pedido.Articulos.Where(a => a.Incluir).ToList();

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedido;
        }

        /// <summary>
        /// Cancelar un pedido
        /// </summary>
        /// <param name="body">Solicitud de cancelación de pedido</param>
        /// <response>true</response>
        public bool CancelarPedido(BOCancelarPedidoRequest cancelar)
        {
            if (cancelar == null)
            {
                EVOException e = new EVOException(errores.errCancelarPedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método CancelarPedido en EVO_WebApi - BL con los parametros body = {JsonConvert.SerializeObject(cancelar)}");

            if (cancelar.PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BOPedidoConsultaResponse boPedido = null;

            try
            {
                boPedido = ObtenerConsultaPedido(cancelar.PedidoId);
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }

            if (boPedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoNOExiste);

                logger.Error(e);

                throw e;
            }

            if (cancelar.MotivoId <= 0)
            {
                EVOException e = new EVOException(errores.errMotivoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLMotivo bLMotivo = new BLMotivo();

            MotivoRespuesta motivoRespuesta = null;

            try
            {
                motivoRespuesta = bLMotivo.ObtenerMotivoxId(cancelar.MotivoId);
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }

            EstadoPedido estadoPedido = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Cancelado)
                ;
            DAPedido dAPedido = new DAPedido();

            cancelar.EstadoPedidoId = estadoPedido.EstadoPedidoId;

            try
            {
                dAPedido.CancelarPedido(cancelar);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;

        }

        public BOArticuloBodegaSAP ObtenerArticuloxBodegaSAP(string codigoArticulo, string codigoBodega)
        {
            logger.Info($"Entró al método ObtenerArticuloxBodegaSAP en EVO-WebApi - BLPedidos con los parámetros codigoArticulo = {codigoArticulo}, codigoBodega = {codigoBodega}");

            ArticuloProxy articuloProxy = new ArticuloProxy();

            //StringBuilder solicitud = new StringBuilder();

            //solicitud.Append("<ObjetosIntegracion BaseDatos=\"PRU_ANT\">");
            //solicitud.Append("<SAPBO>");
            //solicitud.Append("<SAP Objeto=\"ObtenerArticloxBodegaSAP\" Operacion=\"Read\">");
            //solicitud.Append("<Propiedad_Encabezado>");
            //solicitud.Append("<NombreColumna>@Codigo</NombreColumna>");
            //solicitud.Append("<ValorColumna>" + codigoArticulo + "</ValorColumna>");
            //solicitud.Append("</Propiedad_Encabezado>");
            //solicitud.Append("<Propiedad_Encabezado>");
            //solicitud.Append("<NombreColumna>@WhsCode</NombreColumna>");
            //solicitud.Append("<ValorColumna>" + codigoBodega + "</ValorColumna>");
            //solicitud.Append("</Propiedad_Encabezado>");
            //solicitud.Append("</SAP>");
            //solicitud.Append("</SAPBO>");
            //solicitud.Append("</ObjetosIntegracion>");


            BOArticuloBodegaSAP bOArticuloBodegaSAP = null;

            try
            {
                bOArticuloBodegaSAP = articuloProxy.ObtenerArticuloxBodegaSAP(codigoArticulo, codigoBodega);

                logger.Info($"Salió del método ObtenerArticuloxBodegaSAP en EVO-WebApi - BLPedidos con respuesta bOArticuloBodegaSAP = {JsonConvert.SerializeObject(bOArticuloBodegaSAP)}");
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return bOArticuloBodegaSAP;
        }

        ///// <summary>
        ///// Retorna el detalle del pedido de tipo compra a gestionar
        ///// </summary>
        ///// <param name="pedidoId">Indica el id del pedido</param>
        ///// <response>BOPedidoCompraGestionResponse</response>
        //public BOPedidoCompraGestionResponse ObtenerPedidoCompraGestion(int pedidoId)
        //{
        //    logger.Info($"Entró el método ObtenerPedidoCompraGestion en EVO-WebApi - BLPedido con el parametro pedidoId = {pedidoId}");

        //    if (pedidoId <= 0)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoIdNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    DAPedido dAPedido = new DAPedido();

        //    BOPedidoCompraGestionResponse pedido = null;

        //    try
        //    {
        //        pedido = dAPedido.ObtenerPedidoCompraGestion(pedidoId);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    if (pedido == null)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoNOExiste);

        //        throw e;
        //    }

        //    try
        //    {

        //        BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

        //        string codigoAlmacen = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CODIGO_ALMACEN_COMPRA);

        //        foreach (var articulo in pedido.Articulos)
        //        {
        //            articulo.Incluir = true;

        //            BOArticuloBodegaSAP bOArticuloBodegaSAP = ObtenerArticuloxBodegaSAP(articulo.CodigoArticulo, codigoAlmacen);

        //            articulo.StockAlmacen = bOArticuloBodegaSAP == null ? string.Empty : bOArticuloBodegaSAP.Stock.ToString();

        //            foreach (var accion in pedido.Acciones)
        //            {
        //                BOArticuloAccionCompraResponse articuloAccion = accion.Articulos.FirstOrDefault(a => a.DetallePedidoId == articulo.DetallePedidoId);

        //                if (articuloAccion != null)
        //                {
        //                    articuloAccion.StockAlmacen = articulo.StockAlmacen;
        //                }
        //            }

        //            List<BOArticuloAccionCompraResponse> articulos = new List<BOArticuloAccionCompraResponse>();

        //            pedido.Acciones.ForEach(a => articulos.AddRange(a.Articulos));

        //            decimal cantidadGestionada = 0;

        //            if (articulos.Where(a => a.DetallePedidoId == articulo.DetallePedidoId).Count() >= 1)
        //            {

        //                cantidadGestionada = articulos
        //                    .Where(a => a.DetallePedidoId == articulo.DetallePedidoId).Sum(a => decimal.Parse(a.Cantidad));

        //                articulo.CantidadFaltanteGestionar = (decimal.Parse(articulo.CantidadSolicitada) - cantidadGestionada).ToString();

        //            }
        //            else
        //            {
        //                articulo.CantidadFaltanteGestionar = articulo.CantidadSolicitada;
        //            }                   

        //            if (cantidadGestionada > decimal.Parse(articulo.CantidadSolicitada))
        //            {
        //                EVOException e = new EVOException(errores.errGestionadaExcedeSolicitada);

        //                throw e;
        //            }

        //            if (cantidadGestionada == decimal.Parse(articulo.CantidadSolicitada))
        //            {
        //                articulo.Incluir = false;
        //            }
        //        }

        //        //pedido.Articulos = pedido.Articulos.Where(a => a.Incluir).ToList();

        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    return pedido;
        //}

        ///// <summary>
        ///// Cancelar un pedido
        ///// </summary>
        ///// <param name="body">Solicitud de cancelación de pedido</param>
        ///// <response>true</response>
        //public bool CancelarPedido(BOCancelarPedidoRequest cancelar)
        //{
        //    if (cancelar == null)
        //    {
        //        EVOException e = new EVOException(errores.errCancelarPedidoNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    logger.Info($"Entró al método CancelarPedido en EVO_WebApi - BL con los parametros body = {JsonConvert.SerializeObject(cancelar)}");

        //    if (cancelar.PedidoId <= 0)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoIdNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    BOPedidoConsultaResponse boPedido = null;

        //    try
        //    {
        //        boPedido = ObtenerConsultaPedido(cancelar.PedidoId);
        //    }
        //    catch (EVOException e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    if (boPedido == null)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoNOExiste);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    if (cancelar.MotivoId <= 0)
        //    {
        //        EVOException e = new EVOException(errores.errMotivoIdNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    BLMotivo bLMotivo = new BLMotivo();

        //    MotivoRespuesta motivoRespuesta = null;

        //    try
        //    {
        //        motivoRespuesta = bLMotivo.ObtenerMotivoxId(cancelar.MotivoId);
        //    }
        //    catch (EVOException e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    EstadoPedido estadoPedido = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Cancelado)
        //        ;
        //    DAPedido dAPedido = new DAPedido();

        //    cancelar.EstadoPedidoId = estadoPedido.EstadoPedidoId;

        //    try
        //    {
        //        dAPedido.CancelarPedido(cancelar);
        //    }
        //    catch (Exception e)
        //    {
        //        logger.Error(e);

        //        throw e;
        //    }

        //    return true;

        //}

        /// <summary>
        /// Retorna el detalle del pedido
        /// </summary>
        /// <param name="pedidoId"></param>
        /// <response>BOPedidoConsultaResponse</response>
        public BOPedidoConsultaResponse ObtenerConsultaPedido(int pedidoId)
        {
            logger.Info($"Entró el método ObtenerConsultaPedido en EVO-WebApi - BLPedido con el parametro pedidoId = {pedidoId}");

            if (pedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedido = new DAPedido();

            BOPedidoConsultaResponse boPedido = null;

            try
            {
                boPedido = dAPedido.ObtenerConsultaPedido(pedidoId);

                if (boPedido.EstadoPedido != EstadosPedidoEnum.Borrador.ToString())
                {
                    boPedido.FechaLimiteSugerida = boPedido.FechaEntrega.Value.ToString("dd/MM/yyyy");
                    boPedido.NumeroPedido = $"{boPedido.WhsCode.Split("-")[1]}-{boPedido.NumeroPedido}";
                }

                //Aholguin: 2020-Agos-11 - Se valida si es compra y se inhabilita cancelar pedido en consulta pedidos de compras
                if (boPedido.TipoSolicitud == TiposSolicitudEnum.Compras.ToString())
                {
                    if (boPedido.EstadoPedido == EstadosPedidoEnum.Borrador.ToString())
                    {
                        boPedido.CancelarPedido = true;
                    }

                    BOPedidoCompraGestionResponse pedidoCompra = ObtenerPedidoCompraGestion(pedidoId);
                    boPedido.Acciones = pedidoCompra.Acciones;
                }

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return boPedido;

        }

        /// <summary>
        /// Retorna el conteo de los pedidos compra abiertos por filtro o sin filtro
        /// </summary>
        /// <param name="filtro">Contiene los campos para filtrar</param>
        /// <response>int</response>
        public int ObtenerConteoPedidosCompraAbiertoxFiltro(BOFiltrarPedidoCompraRequest filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerConteoPedidosCompraAbiertoxFiltro con los parámetros {0}",
             JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedido = new DAPedido();
            int nRegistros = 0;

            try
            {
                if (
                       string.IsNullOrEmpty(filtro.NumeroPedido) &&
                       string.IsNullOrEmpty(filtro.FechaSolicitud) &&
                       string.IsNullOrEmpty(filtro.FechaLimiteSugerida) &&
                       string.IsNullOrEmpty(filtro.EstadoPedido) &&
                       string.IsNullOrEmpty(filtro.Cliente) &&
                       string.IsNullOrEmpty(filtro.DiasEntrega)
                       )
                {
                    object result = dAPedidos.ObtenerConteoPedidosCompraAbierto();

                    if (result != null)
                    {
                        nRegistros = int.Parse(result.ToString());
                    }

                }
                else
                {
                    object result = dAPedidos.ObtenerConteoPedidosCompraAbiertoxFiltro(filtro);

                    if (result != null)
                    {
                        nRegistros = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;

        }

        /// <summary>
        /// Obtiene todos los registros de pedidos de tipo solicitud compra con o sin filtros de búsqueda
        /// </summary>
        /// <param name="body">Solicitud de filtro de pedidos compra . Si no se ingresa ninguno de los criterios del filtro retorna todo</param>
        /// <response>List<BOObtenerPedidosCompraResponseRegistros></response>
        public List<BOObtenerPedidosCompraResponseRegistros> ObtenerPedidosCompraAbiertoxFiltro(BOFiltrarPedidoCompraRequest filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerPedidosCompraAbiertoxFiltro con los parámetros {0}",
             JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedido = new DAPedido();
            List<BOObtenerPedidosCompraResponseRegistros> pedidos = null;

            try
            {
                if (
                       string.IsNullOrEmpty(filtro.NumeroPedido) &&
                       string.IsNullOrEmpty(filtro.FechaSolicitud) &&
                       string.IsNullOrEmpty(filtro.FechaLimiteSugerida) &&
                       string.IsNullOrEmpty(filtro.EstadoPedido) &&
                       string.IsNullOrEmpty(filtro.Cliente) &&
                       string.IsNullOrEmpty(filtro.DiasEntrega)
                       )
                {
                    pedidos = dAPedido.ObtenerPedidosCompraAbierto(filtro.Desde, filtro.Hasta);
                }
                else
                {
                    pedidos = dAPedido.ObtenerPedidosCompraAbiertoxFiltro(filtro);
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidos;
        }

        /// <summary>
        /// Indica si es posible gestionar solicitudes de pedido a un tipo de bodega
        /// </summary>
        /// <param name="codigoBodegaDe">Indica el código de donde se realizará el pedido</param>
        /// <param name="tipoBodega">Indica del tipo de bodega al cual se le hará el pedido</param>
        /// <response>booleando</response>
        public bool ObtenerRealizarPedido(string codigoBodegaDe, string prefijoBodega)
        {
            logger.Info($"Entró al método ObtenerRealizarPedido en EVO-WebApi - BLPedido con los parámetros codigoBodegaDe = {codigoBodegaDe} , prefijoBodega={prefijoBodega}");

            if (string.IsNullOrEmpty(codigoBodegaDe))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodega = new BLBodega();

            BOBodega puntoVenta = bLBodega.ObtenerBodegaPorCodigo(codigoBodegaDe);

            if (string.IsNullOrEmpty(prefijoBodega))
            {
                EVOException e = new EVOException(errores.errPrefijoBodegasNoInformado);

                logger.Error(e);

                throw e;
            }

            int CantidadPedidosBorrador = 1;

            BOTipoBodegaParametrizacion bOTipoBodegaParametrizacion = null;

            bOTipoBodegaParametrizacion = bLBodega.ObtenerTipoBodegaParametrizacion(codigoBodegaDe, prefijoBodega);

            if (bOTipoBodegaParametrizacion != null)
            {
                CantidadPedidosBorrador = bOTipoBodegaParametrizacion.CantidadPedidosBorrador;
            }

            List<BOPedido> borradores = ObtenerPedidosBorrador(codigoBodegaDe);

            if (borradores == null)
            {
                return true;
            }

            borradores = borradores.Where(b => b.SolicitudPara.Split("-")[0] == prefijoBodega).ToList();

            if (borradores.Count() < CantidadPedidosBorrador)
            {
                return true;
            }

            return false;


        }

        /// <summary>
        /// Obtiene los tipos de solicitud de un pedido
        /// </summary>
        /// <param name="codigoSolicita">Indica el código de donde se solicita el pedido</param>
        /// <response >List<BOPedido></response>       
        public List<BOPedido> ObtenerPedidosBorrador(string codigoSolicita)
        {
            logger.Info($"Entró al método ObtenerPedidosBorrador en EVO_WebApi - BLPedido con el parámetro codigoSolicita={codigoSolicita}");

            if (string.IsNullOrEmpty(codigoSolicita))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            DAPedido daPedidos = new DAPedido();

            List<BOPedido> pedidos = null;

            try
            {
                pedidos = daPedidos.ObtenerPedidosBorrador(codigoSolicita);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidos;
        }


        /// <summary>
        /// Obtiene los tipos de solicitud de un pedido
        /// </summary>
        /// <response >List<BOObtenerTipoSolicitudPedidoResponse></response>       
        public List<BOObtenerTipoSolicitudPedidoResponse> ObtenerTiposSolicitudPedido()
        {

            logger.Info("Entró al método ObtenerTiposSolicitudPedido en EVO_WebApi - BLPedido sin parámetros");

            DAPedido daPedidos = new DAPedido();

            List<BOObtenerTipoSolicitudPedidoResponse> tiposSolicitudPedido = new List<BOObtenerTipoSolicitudPedidoResponse>();

            try
            {
                tiposSolicitudPedido = daPedidos.ObtenerTiposSolicitudPedido();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return tiposSolicitudPedido;
        }

        /// <summary>
        /// Este método retorna un booleano indicando la eliminación del artículo asociado a la entrega
        /// </summary>       
        /// <param name="id">2</param>
        /// <returns>Booleano</returns>
        public bool EliminarArticuloEntrega(int id)
        {
            logger.Info($"Entró al método EliminarArticuloEntrega en BLPedidos con el parámetro id= {id}");

            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errIdArticuloEntrega);

                logger.Error(e);

                throw e;
            }

            if (!ExisteArticuloEntrega(id))
            {
                EVOException e = new EVOException(errores.errArtuloEntregaNoExiste);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            return dAPedidos.EliminarArticuloEntrega(id);
        }

        /// <summary>
        /// Obtiene los pedidos en recepción con entregas en estado \&quot;Programado\&quot;
        /// </summary>
        /// <response>List<PedidoRespuesta></response>
        public List<PedidoRespuesta> ObtenerPedidosRecepcion()
        {
            logger.Info("Entró al método ObtenerPedidosRecepcion en BLPedidos");

            List<PedidoRespuesta> pedidosRespuesta = null;

            //EstadoPedido estadoPedido = null;

            //try
            //{
            //    estadoPedido = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.En_Tránsito);
            //}
            //catch (EVOException e)
            //{
            //    throw e;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}

            //DAPedido dAPedidos = new DAPedido();

            //try
            //{
            //    pedidosRespuesta = dAPedidos.ObtenerPedidosEntregasxEstadoId(estadoPedido.EstadoPedidoId);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}

            //foreach (PedidoRespuesta pedidoRespuesta in pedidosRespuesta)
            //{
            //    pedidoRespuesta.CodigoPedido = $"{pedidoRespuesta.WhsCode.Substring(pedidoRespuesta.WhsCode.IndexOf("-") + 1)}-{pedidoRespuesta.NumeroPedido}";
            //}

            return pedidosRespuesta;
        }

        /// <summary>
        /// Obtiene los pedidos que tiene entregas en estado alistamiento
        /// </summary>
        /// <response>List<PedidoRespuesta></response>
        public List<PedidoRespuesta> ObtenerPedidosAlistamiento()
        {
            logger.Info("Entró al método ObtenerArticulosPendientes en BLPedidos");

            List<PedidoRespuesta> pedidosRespuesta = null;

            EstadoPedido estadoPedido = null;

            try
            {
                estadoPedido = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.En_Ruta);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            try
            {
                pedidosRespuesta = dAPedidos.ObtenerPedidosEntregasxEstadoId(estadoPedido.EstadoPedidoId);
            }
            catch (Exception e)
            {
                throw e;
            }

            foreach (PedidoRespuesta pedidoRespuesta in pedidosRespuesta)
            {
                pedidoRespuesta.CodigoPedido = $"{pedidoRespuesta.WhsCode.Substring(pedidoRespuesta.WhsCode.IndexOf("-") + 1)}-{pedidoRespuesta.NumeroPedido}";
            }

            return pedidosRespuesta;

        }

        /// <summary>
        /// Este método retorna una lista de tipo ArticuloPendienteRespuesta que representa los artículos pendientes en una entrega
        /// </summary>       
        /// <param name="entregaId">2</param>
        /// <returns>List<ArticuloPendienteRespuesta></returns>
        public List<ArticuloPendienteRespuesta> ObtenerArticulosPendientes(int entregaId)
        {
            logger.Info($"Entró al método ObtenerArticulosPendientes en BLPedidos con el parámetro entregaId = {entregaId}");

            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            EntregaBO entregaActualizar = null;

            try
            {
                entregaActualizar = ObtenerEntregaxId(entregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            EntregaRespuesta entregaRespuesta = null;

            try
            {
                entregaRespuesta = ObtenerEntregasPedidoxId(entregaActualizar.PedidoId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            entregaRespuesta.Entregas = entregaRespuesta.Entregas.Where(e => e.EntregaId != entregaId).ToList();

            entregaRespuesta.Articulos = entregaRespuesta.Articulos.Where(a => !entregaActualizar.Detalles.Select(c => c.Codigo).Contains(a.Codigo)).ToList();

            List<ArticuloPendienteRespuesta> articulosPendientes = new List<ArticuloPendienteRespuesta>();

            BLArticulo bLArticulos = new BLArticulo();

            foreach (EntregaArticulo articulo in entregaRespuesta.Articulos)
            {
                ArticuloPendienteRespuesta articuloPendiente = new ArticuloPendienteRespuesta()
                {
                    IdEstadoArticulo = articulo.IdEstadoArticulo,
                    Codigo = articulo.Codigo,
                    Nombre = articulo.Nombre,
                    CantidadAprobada = articulo.CantidadAprobada.ToString(),
                    CantidadPendiente = (articulo.CantidadAprobada - (entregaRespuesta.Entregas.Select(e => e.Detalles.Where(d => d.CodigoArticulo == articulo.Codigo).Select(c => c.Cantidad).Sum()).Sum())).ToString()
                };

                articulosPendientes.Add(articuloPendiente);
            }

            return articulosPendientes;

        }

        /// <summary>
        /// Este método retorna un booleano indicando si la entrega en distribución ha sido actualizada
        /// </summary>       
        /// <param name="entregaSolicitud"></param>
        /// <returns>Booleano</returns>
        public bool ActualizarEntregaDistribucion(EntregaSolicitud entregaSolicitud)
        {
            if (entregaSolicitud == null)
            {
                EVOException e = new EVOException(errores.errActualizarEntregaNula);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarEntregaDistribucion en blPedidos con los parametros parámetros {JsonConvert.SerializeObject(entregaSolicitud)}");

            if (entregaSolicitud.MotivoID <= 0)
            {
                EVOException e = new EVOException(errores.errMotivoIdNoInformado);

                logger.Error(e);

                throw e;
            }


            if (entregaSolicitud.EntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(entregaSolicitud.FechaEntrega))
            {
                EVOException e = new EVOException(errores.errFechaEntrega);

                logger.Error(e);

                throw e;
            }

            Match regFechaMatch;

            //Expresión regular valida formato dd/mm/yyyy
            string pattern = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
            regFechaMatch = Regex.Match(entregaSolicitud.FechaEntrega, pattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(entregaSolicitud.HoraEntrega))
            {
                EVOException e = new EVOException(errores.errHoraEntrega);

                logger.Error(e);

                throw e;
            }

            //Expresión regular valida formato HH:MM
            pattern = @"^(0[0-9]|1[0-9]|2[0-3]|[0-9]):[0-5][0-9]$";
            regFechaMatch = Regex.Match(entregaSolicitud.HoraEntrega, pattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errHoraFormatoHHMM);

                logger.Error(e);

                throw e;
            }

            if (entregaSolicitud.Articulos == null)
            {
                EVOException e = new EVOException(errores.errArticulosEntregasNulo);

                logger.Error(e);

                throw e;
            }

            if (entregaSolicitud.Articulos.Count > 0)
            {
                foreach (EntregaSolicitudArticulos articulo in entregaSolicitud.Articulos)
                {
                    //0 significa que es un nuevo artículo

                    if (articulo.DetalleEntregaId < 0)
                    {
                        EVOException e = new EVOException(errores.errDetalleEntregaIdNoInformado);

                        logger.Error(e);

                        throw e;
                    }

                    if (string.IsNullOrEmpty(articulo.Codigo))
                    {
                        EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                        logger.Error(e);

                        throw e;
                    }

                    if (articulo.IdEstadoArticulo <= 0)
                    {
                        EVOException e = new EVOException(errores.errIdEstadoArticulo);

                        logger.Error(e);

                        throw e;
                    }

                    if (articulo.CantidadEntrega <= 0)
                    {
                        EVOException e = new EVOException(errores.errCantidadArticuloEntrega);

                        logger.Error(e);

                        throw e;
                    }
                }
            }

            string[] fecha = entregaSolicitud.FechaEntrega.Split("/");
            string[] hora = entregaSolicitud.HoraEntrega.Split(":");

            entregaSolicitud.Fecha = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0]), int.Parse(hora[0]), int.Parse(hora[1]), 0);

            DAPedido dAPedidos = new DAPedido();

            try
            {
                dAPedidos.ActualizarDistribucionEntrega(entregaSolicitud);

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;
        }


        /// <summary>
        /// Este método retorna un booleano indicando si la entrega ha sido actualizada
        /// </summary>       
        /// <param name="entregaSolicitud"></param>
        /// <returns>Booleano</returns>
        public bool ActualizarEntrega(EntregaSolicitud entregaSolicitud)
        {
            if (entregaSolicitud == null)
            {
                EVOException e = new EVOException(errores.errActualizarEntregaNula);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarEntrega en blPedidos con los parametros parámetros {JsonConvert.SerializeObject(entregaSolicitud)}");

            if (entregaSolicitud.EntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (entregaSolicitud.TipoVehiculoId <= 0)
            {
                EVOException e = new EVOException(errores.errTipoVehiculoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(entregaSolicitud.FechaEntrega))
            {
                EVOException e = new EVOException(errores.errFechaEntrega);

                logger.Error(e);

                throw e;
            }

            Match regFechaMatch;
            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();

            string pattern = string.Empty;

            try
            {
                pattern = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_FECHA_DDMMAA);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            regFechaMatch = Regex.Match(entregaSolicitud.FechaEntrega, pattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(entregaSolicitud.HoraEntrega))
            {
                EVOException e = new EVOException(errores.errHoraEntrega);

                logger.Error(e);

                throw e;
            }

            try
            {
                pattern = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_HORA_HHMM);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            regFechaMatch = Regex.Match(entregaSolicitud.HoraEntrega, pattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errHoraFormatoHHMM);

                logger.Error(e);

                throw e;
            }

            if (entregaSolicitud.Articulos == null)
            {
                EVOException e = new EVOException(errores.errArticulosEntregasNulo);

                logger.Error(e);

                throw e;
            }

            if (entregaSolicitud.Articulos.Count > 0)
            {
                foreach (EntregaSolicitudArticulos articulo in entregaSolicitud.Articulos)
                {
                    if (articulo.CantidadEntrega <= 0)
                    {
                        EVOException e = new EVOException(errores.errCantidadEntregaCeroNegativa);

                        logger.Error(e);

                        throw e;
                    }

                    if (articulo.DetalleEntregaId > 0) // Actualizar
                    {
                        if (articulo.CantidadAprobada <= 0)
                        {
                            EVOException e = new EVOException(errores.errCantidadAprobadaCeroNegativa);

                            logger.Error(e);

                            throw e;
                        }

                        if (articulo.CantidadEntrega > articulo.CantidadAprobada)
                        {
                            EVOException e = new EVOException(errores.errCantidadEntregaAprobada);

                            logger.Error(e);

                            throw e;
                        }
                    }
                    else
                    {
                        // Nuevo
                        if (articulo.CantidadPendiente <= 0)
                        {
                            EVOException e = new EVOException(errores.errCantidadPendienteCeroNegativa);

                            logger.Error(e);

                            throw e;
                        }

                        if (articulo.CantidadEntrega > articulo.CantidadPendiente)
                        {
                            EVOException e = new EVOException(errores.errCantidadEntregaPendiente);

                            logger.Error(e);

                            throw e;
                        }
                    }

                    if (string.IsNullOrEmpty(articulo.Codigo))
                    {
                        EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                        logger.Error(e);

                        throw e;
                    }

                    if (articulo.IdEstadoArticulo <= 0)
                    {
                        EVOException e = new EVOException(errores.errIdEstadoArticulo);

                        logger.Error(e);

                        throw e;
                    }
                }
            }

            string[] fecha = entregaSolicitud.FechaEntrega.Split("/");
            string[] hora = entregaSolicitud.HoraEntrega.Split(":");

            entregaSolicitud.Fecha = new DateTime(int.Parse(fecha[2]), int.Parse(fecha[1]), int.Parse(fecha[0]), int.Parse(hora[0]), int.Parse(hora[1]), 0);

            DAPedido dAPedidos = new DAPedido();

            try
            {
                dAPedidos.ActualizarProgramacionEntrega(entregaSolicitud);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;

        }


        /// <summary>
        /// Este método retorna un booleano indicando si existe el artículo en la entrega
        /// </summary>       
        /// <param name="id">2</param>
        /// <returns>Booleano</returns>
        private bool ExisteArticuloEntrega(int id)
        {
            logger.Info($"Entró al método ExisteArticuloEntrega en BLPedidos con el parámetro id= {id}");

            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errIdArticuloEntrega);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            return dAPedidos.ExisteArticuloEntrega(id);

        }

        /// <summary>
        /// Verifica si existen solicitud de pedidos en estado borrador hacia todas las plantas , ya que no se pueden hacer nuevas solicitudes si existen en borrador.
        /// </summary>   
        /// <returns>Retorna una booleano indicando si permite solicitar pedidos en los puntos de ventas y clientes externoes</returns>
        public bool HabilitarSolicitudPedido(string codigoCliente)
        {
            logger.Info($"Entró al método HabilitarSolicitudPedido");

            BLBodega bLBodegas = new BLBodega();

            BOBodega bodega = null;

            try
            {
                bodega = bLBodegas.ObtenerBodegaPorCodigo(codigoCliente);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<BOBodega> plantas = bLBodegas.ObtenerBodegasTipoPlanta();

            int solicitudesBorrador = 0;

            foreach (BOBodega planta in plantas)
            {
                ObtenerPedidoBorradorPeticion opbp = new ObtenerPedidoBorradorPeticion()
                {
                    WhsCode = bodega.WhsCode,
                    SolicitudPara = planta.WhsCode
                };

                if (ExistePedidoBorrador(opbp))
                {
                    solicitudesBorrador++;
                }
            }

            return solicitudesBorrador != plantas.Count;

        }

        /// <summary>
        /// Este método retorna un objeto que representa un viaje(con entregas y artículos asociados)
        /// </summary>       
        /// <param name="vehiculoEntregaId">2</param>
        /// <returns>ObtenerViajeEntregasRespuesta</returns>
        public ObtenerViajeEntregasRespuesta ObtenerViajeEntregas(int vehiculoEntregaId)
        {
            logger.Info($"Entró al método ObtenerViajeEntregas en BLPedidos con el parámetro {vehiculoEntregaId}");

            if (vehiculoEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errVehiculoEntregaId);

                logger.Error(e);

                throw e;
            }

            if (!ValidarViaje(vehiculoEntregaId))
            {
                EVOException e = new EVOException(errores.errViajeNoExiste);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            return dAPedidos.ObtenerViajeEntregas(vehiculoEntregaId);

        }

        /// <summary>
        /// Este método retorna un booleano si el viaje existe o no
        /// </summary>       
        /// <param name="vehiculoEntregaId">2</param>
        /// <returns>bool</returns>
        private bool ValidarViaje(int vehiculoEntregaId)
        {
            logger.Info($"Entró al método ValidarViaje en BLPedidos con el parámetro {vehiculoEntregaId}");

            if (vehiculoEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errVehiculoEntregaId);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            return dAPedidos.ValidarViaje(vehiculoEntregaId);

        }

        /// <summary>
        /// Este método retorna si existen solicitud de pedidos en estado "Borrador" en todas las plantas
        /// </summary>       
        /// <param name="codigoPuntoVenta">PB-PRA</param>
        /// <returns>Booleano</returns>
        public bool ExisteSolicitudPlantasBorrador(string codigoPuntoVenta)
        {
            logger.Info($"Entró al método ExisteSolicitudPlantasBorrador en BLPedidos con el parámetro {codigoPuntoVenta}");

            BLBodega bLBodegas = new BLBodega();

            if (string.IsNullOrEmpty(codigoPuntoVenta))
            {
                EVOException e = new EVOException(errores.errCodigoPuntoVentaNoInformado);

                logger.Error(e);

                throw e;
            }

            BOBodega puntoVenta = null;

            try
            {
                puntoVenta = bLBodegas.ObtenerBodegaPorCodigo(codigoPuntoVenta);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {

                throw e;
            }

            EstadoPedido estadoPedido = null;

            try
            {
                estadoPedido = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Borrador);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            int borradores = 0;

            try
            {

                foreach (BOBodega bodega in bLBodegas.ObtenerBodegasTipoPlanta())
                {
                    ObtenerPedidoBorradorPeticion obtenerPedidoBorradorPeticion = new ObtenerPedidoBorradorPeticion()
                    {
                        EstadoPedidoId = estadoPedido.EstadoPedidoId,
                        SolicitudPara = bodega.WhsCode,
                        WhsCode = codigoPuntoVenta
                    };

                    borradores += ExistePedidoBorrador(obtenerPedidoBorradorPeticion) ? 1 : 0;

                }

                if (bLBodegas.ObtenerBodegasTipoPlanta().Count == borradores)
                {
                    return true;
                }

                return false;

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

        }

        /// <summary>
        /// Este método retorna los vehiculos que tienen entregas todavia en sin cerrar 
        /// </summary>       
        /// <returns>Lista de tipo VehiculoRespuesta</returns>
        public List<EnrutamientoRespuesta> ObtenerVehiculosConEntregas()
        {

            logger.Info($"Entró al método ObtenerVehiculosConEntregas en blPedidos sin parámetros");

            DAPedido dAPedidos = new DAPedido();

            List<EnrutamientoRespuesta> enrutamientos = null;

            try
            {
                enrutamientos = dAPedidos.ObtenerVehiculosConEntregas();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return enrutamientos;

        }

        /// <summary>
        /// Este método realiza un distribución del pedido en entregas
        /// </summary>
        /// <param name="distribucion"></param>
        /// <returns></returns>
        public bool AsignarAlistamiento(DistribucionSolicitud distribucion)
        {
            logger.Info($"Entró al método AsignarAlistamiento en blPedidos con los parametros parámetros {JsonConvert.SerializeObject(distribucion)}");

            if (distribucion == null)
            {
                EVOException e = new EVOException(errores.errEntregaDistribucionNoInformada);

                logger.Error(e);

                throw e;
            }

            BLVehiculo bLVehiculos = new BLVehiculo();

            if (distribucion.AuxiliarId <= 0)
            {
                EVOException e = new EVOException(errores.errAuxiliarIdNoInformada);

                logger.Error(e);

                throw e;
            }

            if (distribucion.MuelleId <= 0)
            {
                EVOException e = new EVOException(errores.errMuelleIdIdNoInformado);
                logger.Error(e);
                throw e;
            }

            Empleado auxiliar = null;
            Empleado conductor = null;

            try
            {
                auxiliar = bLVehiculos.ObtenerConductorAuxiliarxId(distribucion.AuxiliarId);
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (auxiliar == null)
            {
                EVOException e = new EVOException(errores.errAuxiliarNoRegistrado);

                logger.Error(e);

                throw e;
            }

            if (distribucion.ConductorId <= 0)
            {
                EVOException e = new EVOException(errores.errConductorIdNoInformada);

                logger.Error(e);

                throw e;
            }

            if (distribucion.ConductorId == distribucion.AuxiliarId)
            {
                EVOException e = new EVOException(errores.errConductorAuxiliarIgual);

                logger.Error(e);

                throw e;
            }

            try
            {
                conductor = bLVehiculos.ObtenerConductorAuxiliarxId(distribucion.ConductorId);
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (conductor == null)
            {
                EVOException e = new EVOException(errores.errConductorNoRegistrado);

                logger.Error(e);

                throw e;
            }

            if (conductor.Cargo == auxiliar.Cargo)
            {
                EVOException e = new EVOException(errores.errEmpleadosMismoCargo);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(distribucion.Usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = distribucion.Usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                distribucion.Usuario = distribucion.Usuario.Substring(nBackSlash + 1, distribucion.Usuario.Length - nBackSlash - 1);
            }

            BLUsuario bLUsuarios = new BLUsuario();

            Usuario usuario = null;

            try
            {
                usuario = bLUsuarios.ObtenerUsuarioPorUsuario(distribucion.Usuario);
            }
            catch (EVOException e)
            {
                logger.Error(e);

                throw e;
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            distribucion.UsuarioId = usuario.UsuarioId;

            if (distribucion.EntregasIds.Count == 0)
            {
                EVOException e = new EVOException(errores.errEntregasNoInformadas);

                logger.Error(e);

                throw e;
            }

            decimal pesoEntregas = 0;

            EntregaBO entrega = null;

            foreach (int entregaId in distribucion.EntregasIds)
            {
                if (entregaId <= 0)
                {
                    EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                try
                {
                    entrega = ObtenerEntregaxId(entregaId);
                }
                catch (EVOException e)
                {
                    logger.Error(e);

                    throw e;
                }
                catch (Exception e)
                {
                    logger.Error(e);

                    throw e;
                }

                //TODO: Por el momento no existe el módulo Enrutamiento(Estado) se cambiará por En Tránsito(Estado)
                //if (entrega.Estado == EstadosPedidoEnum.En_Tránsito.ToString().Replace("_", " "))
                //{
                //    EVOException e = new EVOException(errores.errEntregaAsignadaViaje);

                //    logger.Error(e);

                //    throw e;
                //}

                pesoEntregas += entrega.Detalles.Select(d => Convert.ToDecimal(d.CantidadEntrega)).Sum();

            }

            if (distribucion.VehiculoId <= 0)
            {
                EVOException e = new EVOException(errores.errVehiculoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            VehiculoRespuesta vehiculo = bLVehiculos.ObtenerVehiculoxId(distribucion.VehiculoId);

            if (vehiculo == null)
            {
                EVOException e = new EVOException(errores.errVehiculoNoRegistrado);

                logger.Error(e);

                throw e;
            }

            VehiculoEntrega vehiculoEntregasDisponible = ObtenerVehiculoEntregas(distribucion.VehiculoId);

            distribucion.NuevoViaje = true;

            if (vehiculoEntregasDisponible != null)
            {
                pesoEntregas += vehiculoEntregasDisponible.PesoEntregas;

                distribucion.NuevoViaje = false;
            }

            if (pesoEntregas > vehiculo.Capacidad)
            {
                EVOException e = new EVOException(string.Format(errores.errCapacidadVehiculoExcedida, string.Format("{0:#,0.000}", pesoEntregas), string.Format("{0:#,0.000}", vehiculo.Capacidad), vehiculo.Placa));

                logger.Error(e);

                throw e;
            }

            EstadoPedido estadoPedido = null;

            try
            {
                //TODO:Por el momento como no existe "El módulo alistamiento" se cambiará de estado "Enrutamiento" a En_Tránsito para que sea visible "Recepción"
                //estadoPedido = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.En_Tránsito);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            distribucion.EstadoId = estadoPedido.EstadoPedidoId;

            DAPedido dAPedidos = new DAPedido();

            distribucion.FechaRegistro = DateTime.Now;

            bool respuesta = false;

            try
            {
                respuesta = dAPedidos.CrearActualizarDistribucion(distribucion);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;
        }

       
       

        /// <summary>
        /// Obtiene el vehiculo , auxiliar , conductor y detalles de entregas asociadas al viaje de entregas
        /// </summary>
        /// <param name="id">Id del vehiculo</param>      
        /// <returns>Objeto de tipo VehiculoEntrega</returns>
        private VehiculoEntrega ObtenerVehiculoEntregas(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errVehiculoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerPesoEntregasxVehiculoId en BLVehiculos con el parámetro: id: {id}");

            DAPedido dAPedidos = new DAPedido();

            VehiculoEntrega vehiculoEntrega = null;

            try
            {
                vehiculoEntrega = dAPedidos.ObtenerVehiculoEntregas(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            return vehiculoEntrega;
        }



        /// <summary>
        /// Actualiza el pedido y las entregas al estado enrutamiento
        /// </summary>
        /// <param name="id">Id del pedido</param>
        /// <returns>True/False</returns>
        public bool PedidoEntregasEnrutamiento(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método PedidoEntregasEnrutamiento en BLPedidos con el parámetro: id: {id}");

            EstadoPedido estado = null;

            try
            {
                estado = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Programado);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            bool respuesta = false;

            EntregaRespuesta entregas;

            try
            {
                entregas = ObtenerEntregasPedidoxId(id);
            }
            catch (Exception e)
            {
                throw e;
            }

            if (entregas.Entregas.Count == 0)
            {
                EVOException e = new EVOException(errores.errEntregasNoInformadas);

                logger.Error(e);

                throw e;
            }

            try
            {
                respuesta = dAPedidos.ActualizarEstadoAPedido(id, estado.EstadoPedidoId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return respuesta;
        }

        /// <summary>
        /// Retorna una lista de entregas 
        /// </summary>
        /// <param name="id">Id del pedido</param>
        /// <returns>lista de entregas</returns>
        public EntregaRespuesta ObtenerEntregasPedidoxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEntregasPedidoxId con el parámetro: id: {id}");

            DAPedido dAPedidos = new DAPedido();

            EntregaRespuesta entregas;

            try
            {
                entregas = dAPedidos.ObtenerEntregasPedidoxId(id);

            }
            catch (Exception e)
            {
                throw e;
            }

            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();

            int cantidadDecimales = 0;

            try
            {
                cantidadDecimales = int.Parse(bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_DECIMALES));
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            entregas.Entregas.ForEach(e => e.CantidadTotal = Math.Round(e.CantidadTotal, cantidadDecimales));

            return entregas;
        }

        /// <summary>
        /// AgregarEntregas
        /// </summary>
        /// <param name="entregas">Colección de entregas</param>
        /// <param name="usuario">Usuario que ingresó las entregas</param>
        /// <returns>Booleano</returns>
        public bool AgregarEntregas(List<EntregaPedido> entregas, string usuario)
        {
            if (entregas == null)
            {
                EVOException e = new EVOException(errores.errEntregaNoInformada);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método AgregarEntregas con los parámetros: entregas: {JsonConvert.SerializeObject(entregas)} y usuario {usuario}");

            BLUsuario blUsuario = new BLUsuario();

            int nBackSlash = usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                usuario = usuario.Substring(nBackSlash + 1, usuario.Length - nBackSlash - 1);
            }

            Usuario buscar = blUsuario.ObtenerUsuarioPorUsuario(usuario);

            if (buscar == null)
            {
                EVOException e = new EVOException(string.Format(errores.errUsuarioNoExiste, usuario));

                logger.Error(e);

                throw e;
            }

            if (entregas[0].PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            ObtenerPedidoRespuesta pedido = ObtenerPedidoxId(entregas[0].PedidoId);

            if (pedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoNOExiste);

                logger.Error(e);

                throw e;
            }

            foreach (EntregaPedido entrega in entregas)
            {
                if (entrega.TipoVehiculoId <= 0)
                {
                    EVOException e = new EVOException(errores.errTipoVehiculoIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (entrega.PedidoId <= 0)
                {
                    EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (string.IsNullOrEmpty(entrega.FechaEntrega))
                {
                    EVOException e = new EVOException(errores.errFechaEntrega);

                    logger.Error(e);

                    throw e;
                }

                if (string.IsNullOrEmpty(entrega.HoraEntrega))
                {
                    EVOException e = new EVOException(errores.errHoraEntrega);

                    logger.Error(e);

                    throw e;
                }

                entrega.UsuarioId = buscar.UsuarioId;

                entrega.FechaRegistro = DateTime.Now;

                string pattern = string.Empty;

                Match regFechaMatch;

                BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();

                try
                {
                    ///TODO: Cambiar parámetro por el tipo NombresParametrosGeneralesEnum
                    pattern = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_FECHA_DDMMAA);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

                regFechaMatch = Regex.Match(entrega.FechaEntrega, pattern);

                if (!regFechaMatch.Success)
                {
                    EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                    logger.Error(e);

                    throw e;
                }

                try
                {
                    pattern = bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.EXPRESION_REGULAR_HORA_HHMM);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

                regFechaMatch = Regex.Match(entrega.HoraEntrega, pattern);

                if (!regFechaMatch.Success)
                {
                    EVOException e = new EVOException(errores.errHoraFormatoHHMM);

                    logger.Error(e);

                    throw e;
                }

                string[] fechaEntrega = entrega.FechaEntrega.Split("/");

                int anio = int.Parse(fechaEntrega[2]);
                int mes = int.Parse(fechaEntrega[1]);
                int dia = int.Parse(fechaEntrega[0]);

                fechaEntrega = entrega.HoraEntrega.Split(":");

                int horas = int.Parse(fechaEntrega[0]);
                int minutos = int.Parse(fechaEntrega[1]);

                entrega.FechaHoraEntrega = new DateTime(anio, mes, dia, horas, minutos, 0);

                foreach (DetalleEntregaPedido entregaDetalle in entrega.Detalles)
                {
                    if (entregaDetalle.DetallePedidoId <= 0)
                    {
                        EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

                        logger.Error(e);

                        throw e;
                    }

                    if (entregaDetalle.Cantidad == 0)
                    {
                        EVOException e = new EVOException(errores.errCantidadEntregaCeroNegativa);

                        logger.Error(e);

                        throw e;
                    }

                    ObtenerPedidoRespuestaDetalles articulo = pedido.Detalles.FirstOrDefault(x => x.DetallePedidoId == entregaDetalle.DetallePedidoId);

                    if (articulo == null)
                    {
                        EVOException e = new EVOException(errores.errDetallePedidoEntregaNoPedido);

                        logger.Error(e);

                        throw e;
                    }

                    if (articulo.CantidadAprobada == 0)
                    {
                        EVOException e = new EVOException(errores.errArticuloNoAprobadoEnPlanta);

                        logger.Error(e);

                        throw e;
                    }

                }

            }

            DAPedido dAPedidos = new DAPedido();

            return dAPedidos.AgregarEntregas(entregas.OrderBy(x => x.FechaHoraEntrega).ToList());

        }

        /// <summary>
        /// Elimina entregas y detalles del pedido
        /// </summary>
        /// <param name="ids">Colección de ids de entregas</param>    
        /// <returns>Booleano</returns>
        public bool EliminarEntregas(List<int> ids)
        {
            if (ids == null)
            {
                EVOException e = new EVOException(errores.errIdsEntregasNoInformados);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método EliminarEntregas con los parámetros: entregas: {JsonConvert.SerializeObject(ids)}");

            DAPedido dAPedidos = new DAPedido();

            bool respuesta = false;

            try
            {
                respuesta = dAPedidos.EliminarEntregas(ids);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return respuesta;

        }

        /// <summary>
        /// Actualiza la serie
        /// </summary>
        /// <param name="serieRespuesta"></param>    
        /// <returns>Booleano</returns>
        public bool ActualizarSerie(SerieRespuesta serieRespuesta)
        {
            if (serieRespuesta == null)
            {
                EVOException e = new EVOException(errores.errSerieRespuestaNoInformada);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarSerie - blPedido con los parámetros: serieRespuesta: {JsonConvert.SerializeObject(serieRespuesta)}");

            if (serieRespuesta.SerieID <= 0)
            {
                EVOException e = new EVOException(errores.errSerieIDNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(serieRespuesta.NextNumber))
            {
                EVOException e = new EVOException(errores.errProximoNumeroDocumentoNoInformado);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            try
            {
                dAPedidos.ActualizarSerie(serieRespuesta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;

        }

        /// <summary>
        /// Crea la serie
        /// </summary>
        /// <param name="serieRespuesta"></param>    
        /// <returns>Booleano</returns>
        public bool CrearSerie(SerieRespuesta serieRespuesta)
        {
            if (serieRespuesta == null)
            {
                EVOException e = new EVOException(errores.errSerieRespuestaNoInformada);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método CrearSerie - blPedido con los parámetros: serieRespuesta = {JsonConvert.SerializeObject(serieRespuesta)}");

            //if (serieRespuesta.SerieID <= 0)
            //{
            //    EVOException e = new EVOException(errores.errSerieIDNoInformado);

            //    logger.Error(e);

            //    throw e;
            //}            

            if (string.IsNullOrEmpty(serieRespuesta.Series))
            {
                EVOException e = new EVOException(errores.errSerieNoInformado);

                logger.Error(e);

                throw e;
            }

            try
            {
                int.Parse(serieRespuesta.Series);
            }
            catch
            {

                EVOException e = new EVOException(errores.errSerieNoNumero);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(serieRespuesta.SeriesName))
            {
                EVOException e = new EVOException(errores.errSerieNameNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(serieRespuesta.InitialNum))
            {
                EVOException e = new EVOException(errores.errInitialNumNoInformado);

                logger.Error(e);

                throw e;
            }

            try
            {
                int.Parse(serieRespuesta.InitialNum);
            }
            catch
            {

                EVOException e = new EVOException(errores.errInitialNumNoNumero);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(serieRespuesta.NextNumber))
            {
                EVOException e = new EVOException(errores.errNextNumberNoInformado);

                logger.Error(e);

                throw e;
            }

            try
            {
                int.Parse(serieRespuesta.NextNumber);
            }
            catch
            {

                EVOException e = new EVOException(errores.errNextNumberNoNumero);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(serieRespuesta.LastNum))
            {
                EVOException e = new EVOException(errores.errLastNumNoInformado);

                logger.Error(e);

                throw e;
            }

            try
            {
                int.Parse(serieRespuesta.LastNum);
            }
            catch
            {

                EVOException e = new EVOException(errores.errLastNumNoNumero);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            try
            {
                dAPedidos.CrearSerie(serieRespuesta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return true;

        }

        /// <summary>
        /// Obtiene serie por punto de venta
        /// </summary>
        /// <param name="codigoBodega">PV-PRA</param>      
        /// <returns>SerieRespuesta</returns>
        public SerieRespuesta ObtenerSerie(string codigoBodega)
        {
            if (string.IsNullOrEmpty(codigoBodega))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerSerie con el parámetros: codigoBodega = {codigoBodega}");

            DAPedido dAPedidos = new DAPedido();

            SerieRespuesta respuestaSerie = new SerieRespuesta();

            try
            {
                respuestaSerie = dAPedidos.ObtenerSerie(codigoBodega);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (respuestaSerie == null)
            {
                PedidoProxy pedidoProxy = new PedidoProxy();

                logger.Info($"Entró al método ObtenerSeriesSAP sin parámetros");

                List<SerieRespuesta> seriesSAP = pedidoProxy.ObtenerSeriesSAP();

                logger.Info($"Respuesta ObtenerSeriesSAP = {JsonConvert.SerializeObject(seriesSAP)}");

                if (seriesSAP == null)
                {
                    EVOException e = new EVOException(errores.errSerieNoRegistrada);

                    logger.Error(e);

                    throw e;
                }

                List<SerieRespuesta> series = ObtenerTodasSeries();

                if (series.Count == 0)
                {
                    foreach (var serieSAP in seriesSAP)
                    {
                        CrearSerie(serieSAP);
                    }
                }
                else
                {
                    foreach (var serieSAP in seriesSAP.ToList())
                    {
                        if (!series.Select(se => se.Series).Contains(serieSAP.Series))
                        {
                            CrearSerie(serieSAP);
                        }
                        
                    }
                }

                respuestaSerie = ObtenerSerie(codigoBodega);

            }

            return respuestaSerie;

        }

        /// <summary>
        /// Obtiene todas las series</summary>           
        /// <returns>List<SerieRespuesta></SerieRespuesta></returns>
        public List<SerieRespuesta> ObtenerTodasSeries()
        {
            logger.Info("Entró al método ObtenerTodasSeries sin parámetros");

            DAPedido dAPedidos = new DAPedido();

            List<SerieRespuesta> series = null;

            try
            {
                series = dAPedidos.ObtenerTodasSeries();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return series;

        }

        /// <summary>
        /// Actualiza entrega del pedido
        /// </summary>
        /// <param name="entrega">Entrega de un pedido</param>
        /// <param name="usuario">Usuario que ingresó la entrega</param>
        /// <returns>Booleano</returns>
        public bool ActualizarEntrega(ActualizarEntrega entrega, string usuario)
        {
            if (entrega == null)
            {
                EVOException e = new EVOException(errores.errEntregaNoInformada);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarEntrega con los parámetros: entrega: {JsonConvert.SerializeObject(entrega)} y usuario {usuario}");

            if (entrega.Detalles.Count == 0)
            {
                EVOException e = new EVOException(errores.errEntregaSinDetalles);

                logger.Error(e);

                throw e;
            }

            BLUsuario blUsuario = new BLUsuario();

            int nBackSlash = usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                usuario = usuario.Substring(nBackSlash + 1, usuario.Length - nBackSlash - 1);
            }

            Usuario buscar = blUsuario.ObtenerUsuarioPorUsuario(usuario);

            if (buscar == null)
            {
                EVOException e = new EVOException(string.Format(errores.errUsuarioNoExiste, usuario));

                logger.Error(e);

                throw e;
            }

            if (entrega.EntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (entrega.PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            ObtenerPedidoRespuesta pedido = ObtenerPedidoxId(entrega.PedidoId);

            if (pedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoNOExiste);

                logger.Error(e);

                throw e;
            }

            EntregaBO entregaExiste = null;

            if (entrega.EntregaId > 0)
            {
                entregaExiste = ObtenerEntregaxId(entrega.EntregaId);

                if (entregaExiste == null)
                {
                    EVOException e = new EVOException(errores.errEntregaNoExiste);

                    logger.Error(e);

                    throw e;
                }
            }

            if (string.IsNullOrEmpty(entrega.FechaEntrega))
            {
                EVOException e = new EVOException(errores.errFechaEntrega);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(entrega.HoraEntrega))
            {
                EVOException e = new EVOException(errores.errHoraEntrega);

                logger.Error(e);

                throw e;
            }

            if (entrega.TipoVehiculoId <= 0)
            {
                EVOException e = new EVOException(errores.errTipoVehiculoIdNoInformado);
                logger.Error(e);
                throw e;
            }

            if (entrega.EstadoEntregaId != null)
            {

                EstadoPedido estadoPedido = null;

                try
                {
                    estadoPedido = ObtenerEstadoPedidoxId(entrega.EstadoEntregaId.Value);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

            if (entrega.MotivoEdicionId != null)
            {

                MotivoRespuesta motivo = null;

                try
                {
                    motivo = ObtenerMotivoxId(entrega.MotivoEdicionId.Value);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

            }

            entrega.UsuarioId = buscar.UsuarioId;
            entrega.FechaActualizo = DateTime.Now;

            string pattern = string.Empty;

            Match regFechaMatch;

            //Expresión regular valida formato dd/mm/yyyy
            pattern = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
            regFechaMatch = Regex.Match(entrega.FechaEntrega, pattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                logger.Error(e);

                throw e;
            }

            //Expresión regular valida formato HH:MM
            pattern = @"^(0[0-9]|1[0-9]|2[0-3]|[0-9]):[0-5][0-9]$";
            regFechaMatch = Regex.Match(entrega.HoraEntrega, pattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errHoraFormatoHHMM);

                logger.Error(e);

                throw e;
            }

            string[] fechaEntrega = entrega.FechaEntrega.Split("/");

            int anio = int.Parse(fechaEntrega[2]);
            int mes = int.Parse(fechaEntrega[1]);
            int dia = int.Parse(fechaEntrega[0]);

            fechaEntrega = entrega.HoraEntrega.Split(":");

            int horas = int.Parse(fechaEntrega[0]);
            int minutos = int.Parse(fechaEntrega[1]);

            entrega.FechaHoraEntrega = new DateTime(anio, mes, dia, horas, minutos, 0);

            if (entrega.Detalles.Count == 0)
            {
                EVOException e = new EVOException(errores.errEntreaSinDetalles);

                logger.Error(e);

                throw e;
            }

            foreach (ActualizarEntregaDetalle entregaDetalle in entrega.Detalles)
            {
                if (entregaDetalle.DetallePedidoId <= 0)
                {
                    EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (entregaExiste != null && entregaDetalle.DetalleEntregaId > 0)
                {
                    if (entregaExiste.Detalles.FirstOrDefault(x => x.DetalleEntregaId == entregaDetalle.DetalleEntregaId) == null)
                    {
                        EVOException e = new EVOException(errores.errDetalleEntregaIdNoInformado);

                        logger.Error(e);

                        throw e;
                    }
                }

                ObtenerPedidoRespuestaDetalles articulo = pedido.Detalles.FirstOrDefault(x => x.DetallePedidoId == entregaDetalle.DetallePedidoId);

                if (articulo == null)
                {
                    EVOException e = new EVOException(errores.errDetallePedidoEntregaNoPedido);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.CantidadAprobada == 0)
                {
                    EVOException e = new EVOException(errores.errArticuloNoAprobadoEnPlanta);

                    logger.Error(e);

                    throw e;
                }

            }

            DAPedido dAPedidos = new DAPedido();

            return dAPedidos.ActualizarEntrega(entrega);
        }

        private MotivoRespuesta ObtenerMotivoxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errMotivoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerMotivoxId con el parámetro: id: {id}");

            DAPedido dAPedidos = new DAPedido();

            MotivoRespuesta motivo;

            try
            {
                motivo = dAPedidos.ObtenerMotivoxId(id);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (motivo == null)
            {
                EVOException e = new EVOException(errores.errMotivoNoExiste);

                logger.Error(e);

                throw e;
            }

            return motivo;
        }

        public EntregaBO ObtenerEntregaxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEntregaxId con el parámetro: id: {id}");

            DAPedido dAPedidos = new DAPedido();

            EntregaBO entrega = null;

            try
            {
                entrega = dAPedidos.ObtenerEntregaxId(id);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (entrega == null)
            {
                EVOException e = new EVOException(errores.errEntregaNoExiste);

                logger.Error(e);

                throw e;
            }

            BLParametroGeneral bLParametrosGenerales = new BLParametroGeneral();

            int cantidadDecimales = 0;

            try
            {
                cantidadDecimales = int.Parse(bLParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_DECIMALES));
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            entrega.CantidadTotal = Math.Round(decimal.Parse(entrega.CantidadTotal), cantidadDecimales).ToString();


            return entrega;
        }

        public ObtenerPedidoDistribucion ObtenerPedidoDistribucionxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerPedidoDistribucionxId con el parámetro: pedidoId: {id}");

            DAPedido dAPedidos = new DAPedido();

            ObtenerPedidoDistribucion pedido;

            try
            {
                pedido = dAPedidos.ObtenerPedidoDistribucionxId(id);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedido;
        }

        /// <summary>
        /// Editar un pedido
        /// </summary>
        /// <param name="body">Solicitud de edición de pedido</param>
        /// <response>bool</response>
        public string EditarPedido(BOEditarPedidoRequest boPedido)
        {
            if (boPedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método EditarPedido EVO_WebApi - BLPedido con los parámetros: boPedido = {JsonConvert.SerializeObject(boPedido)}");

            if (boPedido.PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            ObtenerPedidoRespuesta pedido = ObtenerPedidoxId(boPedido.PedidoId);

            List<EstadoPedido> estadosPedido = ObtenerTodosEstadosPedido().Where(e => e.EditarPedido).ToList();

            if (estadosPedido.Where(ep => ep.EstadoPedidoId == pedido.EstadoPedidoId).Count() == 0)
            {
                EVOException e = new EVOException(errores.errPedidoNoEditable);

                logger.Error(e);

                throw e;
            }

            if (boPedido.Articulos != null && pedido.Detalles.Count == 0)
            {
                EVOException e = new EVOException(errores.errArticulosNoInformados);

                logger.Error(e);

                throw e;
            }

            if (boPedido.Articulos.Count() != pedido.Detalles.Count())
            {
                EVOException e = new EVOException(errores.errCantidadArticulosDiferente);

                logger.Error(e);

                throw e;
            }

            BLArticulo bLArticulo = new BLArticulo();

            foreach (BOEditarPedidoRequestArticulos articulo in boPedido.Articulos)
            {
                if (articulo.DetallePedidoId <= 0)
                {
                    EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

                    logger.Error(e);

                    throw e;
                }

                ObtenerPedidoRespuestaDetalles articuloPedido = pedido.Detalles.FirstOrDefault(d => d.DetallePedidoId == articulo.DetallePedidoId);

                if (articuloPedido == null)
                {
                    EVOException e = new EVOException(errores.errArticuloNoExistePedido);

                    logger.Error(e);

                    throw e;
                }

                if (pedido.TipoSolicitudId == 1)
                {
                    if (articulo.EmpaqueId <= 0)
                    {
                        EVOException e = new EVOException(errores.errEmpaqueNoInformado);

                        logger.Error(e);

                        throw e;
                    }

                    if (articulo.EstadoArticuloId <= 0)
                    {
                        EVOException e = new EVOException(errores.errEstadoArticuloNoInformado);

                        logger.Error(e);

                        throw e;
                    }
                    BOEstadoArticulo estadoArticulo = bLArticulo.ObtenerEstadoArticuloxId(articulo.EstadoArticuloId.GetValueOrDefault());
                }
                else
                {
                    articulo.EstadoArticuloId = null;
                    articulo.EmpaqueId = null;
                }


                if (articulo.Cantidad <= 0)
                {
                    EVOException e = new EVOException(errores.errCantidadArticuloNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (articulo.Cantidad > articuloPedido.Cantidad)
                {
                    EVOException e = new EVOException(errores.errModificarCantidadArticuloPedido);

                    logger.Error(e);

                    throw e;
                }

                if (!string.IsNullOrEmpty(articulo.Observacion))
                {
                    if (articulo.Observacion.Length > 4000)
                    {
                        EVOException e = new EVOException(errores.errObservacionExcede);

                        logger.Error(e);

                        throw e;
                    }
                }

            }

            DAPedido dAPedidos = new DAPedido();

            try
            {
                dAPedidos.EditarPedido(boPedido);
            }
            catch (Exception e)
            {
                throw e;
            }

            ObtenerPedidoRespuesta obtenerPedidoRespuesta = dAPedidos.ObtenerPedidoxId(boPedido.PedidoId);
            return $"{obtenerPedidoRespuesta.SolicitudDe.Substring(obtenerPedidoRespuesta.SolicitudDe.LastIndexOf("-") + 1)}-{boPedido.PedidoId}";
        }

        ///// <summary>
        ///// Editar un pedido
        ///// </summary>
        ///// <param name="body">Solicitud de edición de pedido</param>
        ///// <response>bool</response>
        //public string EditarPedido(BOEditarPedidoRequest boPedido)
        //{
        //    if (boPedido == null)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoVacio);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    logger.Info($"Entró al método EditarPedido EVO_WebApi - BLPedido con los parámetros: boPedido = {JsonConvert.SerializeObject(boPedido)}");

        //    if (boPedido.PedidoId <= 0)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoIdNoInformado);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    ObtenerPedidoRespuesta pedido = ObtenerPedidoxId(boPedido.PedidoId);

        //    List<EstadoPedido> estadosPedido = ObtenerTodosEstadosPedido().Where(e => e.EditarPedido).ToList();

        //    if (estadosPedido.Where(ep => ep.EstadoPedidoId == pedido.EstadoPedidoId).Count() == 0)
        //    {
        //        EVOException e = new EVOException(errores.errPedidoNoEditable);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    if (boPedido.Articulos != null && pedido.Detalles.Count == 0)
        //    {
        //        EVOException e = new EVOException(errores.errArticulosNoInformados);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    if (boPedido.Articulos.Count() != pedido.Detalles.Count())
        //    {
        //        EVOException e = new EVOException(errores.errCantidadArticulosDiferente);

        //        logger.Error(e);

        //        throw e;
        //    }

        //    BLArticulo bLArticulo = new BLArticulo();

        //    foreach (BOEditarPedidoRequestArticulos articulo in boPedido.Articulos)
        //    {
        //        if (articulo.DetallePedidoId <= 0)
        //        {
        //            EVOException e = new EVOException(errores.errDetallePedidoIdNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        ObtenerPedidoRespuestaDetalles articuloPedido = pedido.Detalles.FirstOrDefault(d => d.DetallePedidoId == articulo.DetallePedidoId);

        //        if (articuloPedido == null)
        //        {
        //            EVOException e = new EVOException(errores.errArticuloNoExistePedido);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (pedido.TipoSolicitudId == 1)
        //        {
        //            if (articulo.EmpaqueId <= 0)
        //            {
        //                EVOException e = new EVOException(errores.errEmpaqueNoInformado);

        //                logger.Error(e);

        //                throw e;
        //            }

        //            if (articulo.EstadoArticuloId <= 0)
        //            {
        //                EVOException e = new EVOException(errores.errEstadoArticuloNoInformado);

        //                logger.Error(e);

        //                throw e;
        //            }
        //            BOEstadoArticulo estadoArticulo = bLArticulo.ObtenerEstadoArticuloxId(articulo.EstadoArticuloId.GetValueOrDefault());
        //        }
        //        else
        //        {
        //            articulo.EstadoArticuloId = null;
        //            articulo.EmpaqueId = null;
        //        }


        //        if (articulo.Cantidad <= 0)
        //        {
        //            EVOException e = new EVOException(errores.errCantidadArticuloNoInformado);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (articulo.Cantidad > articuloPedido.Cantidad)
        //        {
        //            EVOException e = new EVOException(errores.errModificarCantidadArticuloPedido);

        //            logger.Error(e);

        //            throw e;
        //        }

        //        if (!string.IsNullOrEmpty(articulo.Observacion))
        //        {
        //            if (articulo.Observacion.Length > 4000)
        //            {
        //                EVOException e = new EVOException(errores.errObservacionExcede);

        //                logger.Error(e);

        //                throw e;
        //            }
        //        }

        //    }

        //    DAPedido dAPedidos = new DAPedido();

        //    try
        //    {
        //        dAPedidos.EditarPedido(boPedido);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    ObtenerPedidoRespuesta obtenerPedidoRespuesta = dAPedidos.ObtenerPedidoxId(boPedido.PedidoId);
        //    return $"{obtenerPedidoRespuesta.SolicitudDe.Substring(obtenerPedidoRespuesta.SolicitudDe.LastIndexOf("-") + 1)}-{boPedido.PedidoId}";
        //}

        /// <summary>
        /// Actualizar un pedido
        /// </summary>
        /// <param name="pedido">Objeto de negocio de una actualización del pedido</param>
        /// <returns>Verdadero si se pudo persistir la actualiazación el pedido</returns>
        public string ActualizarPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarPedido con los parámetros: {JsonConvert.SerializeObject(pedido)}");

            if (pedido.PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            ObtenerPedidoRespuesta pedidoPersistente= ObtenerPedidoxId(pedido.PedidoId);

            if (string.IsNullOrEmpty(pedido.EstadoPedido))
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(pedido.Usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            if (pedido.TipoSolicitudId <= 0)
            {
                EVOException e = new EVOException(errores.errTipoSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            BLUsuario blUsuario = new BLUsuario();

            int nBackSlash = pedido.Usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                pedido.Usuario = pedido.Usuario.Substring(nBackSlash + 1, pedido.Usuario.Length - nBackSlash - 1);
            }

            Usuario buscar = blUsuario.ObtenerUsuarioPorUsuario(pedido.Usuario);

            if (buscar == null)
            {
                EVOException e = new EVOException(string.Format(errores.errUsuarioNoExiste,
                    pedido.Usuario));

                logger.Error(e);

                throw e;
            }

            pedido.UsuarioId = buscar.UsuarioId;

            EstadosPedidoEnum estadoPedidoEnum = new EstadosPedidoEnum();

            switch (pedido.EstadoPedido)
            {
                //EstadosPedidoEnum.Borrador.ToString() no es soportado en C# 7.3 , pero si en c# 8.0 o superior.
                case "Borrador":
                    estadoPedidoEnum = EstadosPedidoEnum.Borrador;
                    break;
                case "Abierto":
                    estadoPedidoEnum = EstadosPedidoEnum.Abierto;
                    break;
            }

            if (string.IsNullOrEmpty(pedido.SolicitudPara))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            EstadoPedido estadoPedido = null;

            try
            {
                estadoPedido = ObtenerEstadoPedidoxNombre(estadoPedidoEnum);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            pedido.EstadoPedidoId = estadoPedido.EstadoPedidoId;

            DAPedido dAPedidos = new DAPedido();

            ConfiguracionNotificacion configuracionNotificacion = new ConfiguracionNotificacion();

            if (EstadosPedidoEnum.Abierto.ToString().Equals(estadoPedido.Nombre))
            {
                if (pedido.FechaEntrega == null)
                {
                    EVOException e = new EVOException(errores.errFechaEntregaObligatoria);

                    logger.Error(e);

                    throw e;
                }

                pedido.NumeroPedido = dAPedidos.ObtenerNumeroPedidoXCodigoBodega(pedido.WhsCode);

                configuracionNotificacion.NumeroPedido = $"{pedido.WhsCode.Substring(pedido.WhsCode.LastIndexOf("-") + 1)}-{pedido.NumeroPedido}";
            }

            if (pedido.FechaEntrega != null)
            {
                if (pedido.FechaEntrega < DateTime.Now.Date)
                {
                    EVOException e = new EVOException(errores.errFechaEntregaFechaPedidoMenor);

                    logger.Error(e);

                    throw e;
                }
            }

            if (pedido.Detalles != null && pedido.Detalles.Count > 0)
            {
                BLArticulo bLArticulos = new BLArticulo();

                BOObtenerTipoSolicitudPedidoResponse boTipoSolicitud = null;

                foreach (var detalle in pedido.Detalles)
                {
                    ArticuloBodega articuloBodega = null;

                    try
                    {
                        articuloBodega = bLArticulos.ObtenerArticuloxCodigoBodegaCodigoArticulo(pedido.WhsCode, detalle.ItemCode);
                    }
                    catch (EVOException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    BOEstadoArticulo estadoArticulo = null;

                    boTipoSolicitud = ObtenerTiposSolicitudPedido().FirstOrDefault(ts => ts.TipoSolicitudNombre == TiposSolicitudEnum.Traslado.ToString());

                    if (pedido.TipoSolicitudId == boTipoSolicitud.TipoSolicitudId.Value)
                    {
                        try
                        {
                            estadoArticulo = bLArticulos.ObtenerEstadoArticuloxId(detalle.EstadoArticuloId.Value);
                        }
                        catch (EVOException e)
                        {
                            throw e;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }

                        if (detalle.EmpaqueId <= 0)
                        {
                            EVOException e = new EVOException(errores.errEmpaqueNoInformado);

                            logger.Error(e);

                            throw e;
                        }
                    }

                    boTipoSolicitud = ObtenerTiposSolicitudPedido().FirstOrDefault(ts => ts.TipoSolicitudNombre == TiposSolicitudEnum.Compras.ToString());

                    if (pedido.TipoSolicitudId == boTipoSolicitud.TipoSolicitudId.Value)
                    {
                        // se asigna NULL porque es tipo solicitud de Compras.
                        detalle.EstadoArticuloId = null;
                        detalle.EmpaqueId = null;

                    }

                    List<DetallePedido> detallesPedido = pedido.Detalles.Where(x => x.ItemCode == detalle.ItemCode).ToList();

                    if (detallesPedido.Count() > 2)
                    {
                        EVOException e = new EVOException(errores.errArticuloCantidadPedidoExcede);

                        logger.Error(e);

                        throw e;
                    }

                    if (detallesPedido.Count() == 2)
                    {
                        if (detallesPedido[0].EstadoArticuloId == detallesPedido[1].EstadoArticuloId)
                        {
                            EVOException e = new EVOException(errores.errArticulosConelMismoEstado);

                            logger.Error(e);

                            throw e;
                        }
                    }

                    if (detalle.Cantidad <= 0)
                    {
                        EVOException e = new EVOException(errores.errCantidadArticuloNoInformado);

                        logger.Error(e);

                        throw e;
                    }


                    if (!string.IsNullOrEmpty(detalle.Observacion))
                    {
                        if (detalle.Observacion.Length > 100)
                        {
                            EVOException e = new EVOException(errores.errObservacionExcede);

                            logger.Error(e);

                            throw e;
                        }
                    }

                }

                pedido.DetallesSerializados = JsonConvert.SerializeObject(pedido.Detalles);
            }

            pedido.FechaPedido = DateTime.Now.Date;

            BLBodega bLBodegas = new BLBodega();

            BOBodega bodega = null;

            try
            {
                bodega = bLBodegas.ObtenerBodegaPorCodigo(pedido.WhsCode);

                configuracionNotificacion.EmailDe = bodega.Email;

                configuracionNotificacion.PuntoDeVenta = bodega.WhsName;

                bodega = bLBodegas.ObtenerBodegaPorCodigo(pedido.SolicitudPara);

                configuracionNotificacion.EmailPara = bodega.Email;

                configuracionNotificacion.EstadoPedidoNuevo = pedido.EstadoPedido;

                buscar = blUsuario.ObtenerUsuarioPorUsuario(pedido.Usuario);

                if (buscar == null)
                {
                    EVOException e = new EVOException(string.Format(errores.errUsuarioNoExiste,
                        pedido.Usuario));

                    logger.Error(e);

                    throw e;
                }

                pedido.UsuarioId = buscar.UsuarioId;

                configuracionNotificacion.Nombre = buscar.Nombre;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                if (dAPedidos.ActualizarPedido(pedido))
                {
                    if (!string.IsNullOrEmpty(configuracionNotificacion.EmailDe) && estadoPedidoEnum.ToString() != EstadosPedidoEnum.Borrador.ToString())
                    {
                        //notificacion.Enviar(configuracionNotificacion);
                    }
                    return $"{pedido.WhsCode.Substring(pedido.WhsCode.LastIndexOf("-") + 1)}-{pedido.PedidoId}";
                }
            }
            catch (Exception e)
            {

                logger.Error(e);

                throw e;
            }

            return configuracionNotificacion.NumeroPedido;

        }

        public List<PedidoDistribucionRespuesta> ObtenerTodosPedidosADistribucion(int desde, int hasta)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosPedidosADistribucion con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<PedidoDistribucionRespuesta> pedidosRespuestas = null;

            try
            {
                pedidosRespuestas = dAPedidos.ObtenerTodosPedidosADistribucion(desde, hasta);

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosRespuestas;
        }

        public List<string> ObtenerCodigosPedidosBeneficio()
        {
            logger.Info("Entró al método ObtenerCodigosPedidosBeneficio sin parámetros");

            DAPedido daPedidos = new DAPedido();

            List<string> codigos;

            BLBodega bLBodegas = new BLBodega();

            BOBodega bodega = null;

            try
            {
                bodega = bLBodegas.ObtenerBodegaPorCodigo("PB-PT");
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                codigos = daPedidos.ObtenerCodigosPedidosAPlanta(bodega.WhsCode);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return codigos;
        }

        public bool ActualizarPedidoPlantaBeneficio(PedidoPlantaBeneficio pedido)
        {
            bool envioProduccion = false;

            if (pedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarPedidoPlantaBeneficio con los parámetros: {JsonConvert.SerializeObject(pedido)}");

            if (pedido.PedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(pedido.Estado))
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            EstadosPedidoEnum estadoPedidoEnum = new EstadosPedidoEnum();

            if (pedido.Estado.Equals(EstadosPedidoEnum.Abierto.ToString()))
            {
                estadoPedidoEnum = EstadosPedidoEnum.Abierto;
            }else if (pedido.Estado.Equals(EstadosPedidoEnum.Aprobación_Parcial.ToString().Replace("_", " ")))
            {
                estadoPedidoEnum = EstadosPedidoEnum.Aprobación_Parcial;
                pedido.FechaAprobacionPlanta = DateTime.Now.Date;
            }else if (pedido.Estado.Equals(EstadosPedidoEnum.Aprobación_Completa.ToString().Replace("_", " ")))
            {
                estadoPedidoEnum = EstadosPedidoEnum.Aprobación_Completa;
                pedido.FechaAprobacionPlanta = DateTime.Now.Date;
            }
            else
            {
                EVOException e = new EVOException(errores.errEstadoInvalido);

                logger.Error(e);

                throw e;
            }

            EstadoPedido estadoPedido = null;

            try
            {
                estadoPedido = ObtenerEstadoPedidoxNombre(estadoPedidoEnum);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            pedido.EstadoPedidoId = estadoPedido.EstadoPedidoId;

            DAPedido dAPedidos = new DAPedido();

            ObtenerPedidoRespuesta obtenerPedido = ObtenerPedidoxId(pedido.PedidoId);

            BLParametroGeneral parametrosGenerales = new BLParametroGeneral();

            string prefijoBodegas = string.Empty;

            try
            {
                prefijoBodegas = parametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.PREFIJO_BODEGAS_PLANTA_BENEFICIO);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            BOBodega bodega = null;
            ConfiguracionNotificacion conf = null;

            try
            {
                if (dAPedidos.ActualizarPedidoPlantaBeneficio(pedido))
                {
                    if (estadoPedidoEnum.ToString() != EstadosPedidoEnum.Abierto.ToString())
                    {
                        conf = new ConfiguracionNotificacion();

                        BLBodega bLBodegas = new BLBodega();

                        bodega = null;

                        try
                        {
                            bodega = bLBodegas.ObtenerBodegaPorCodigo(obtenerPedido.SolicitudDe);

                            conf.EmailDe = bodega.Email;

                            conf.PuntoDeVenta = bodega.WhsName;

                            bodega = bLBodegas.ObtenerBodegaPorCodigo(obtenerPedido.SolicitudPara);

                            conf.EmailPara = bodega.Email;

                            conf.EstadoPedidoAnterior = EstadosPedidoEnum.Abierto.ToString();

                            conf.EstadoPedidoNuevo = estadoPedido.Nombre;

                            BLUsuario bLUsuarios = new BLUsuario();

                            int nBackSlash = pedido.Usuario.IndexOf(@"\");

                            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
                            if (nBackSlash > 0)
                            {
                                pedido.Usuario = pedido.Usuario.Substring(nBackSlash + 1, pedido.Usuario.Length - nBackSlash - 1);
                            }

                            conf.Nombre = bLUsuarios.ObtenerUsuarioPorUsuario(pedido.Usuario).Nombre;

                            conf.NumeroPedido = $"{obtenerPedido.SolicitudDe.Substring(obtenerPedido.SolicitudDe.LastIndexOf("-") + 1)}-{obtenerPedido.NumeroPedido}";

                            notificacion.Enviar(conf);

                        }
                        catch (EVOException e)
                        {
                            throw e;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }

                    if (estadoPedidoEnum.ToString() != EstadosPedidoEnum.Abierto.ToString())
                    {
                        //Notificar a producción el stock que se necesita producir para este pedido.
                        List<string> articulosProducir = new List<string>();

                        foreach (ObtenerPedidoRespuestaDetalles detalle in obtenerPedido.Detalles)
                        {
                            PedidoPlantaBeneficioDetalle aprobado = pedido.Detalles.FirstOrDefault(d => d.DetallePedidoId == detalle.DetallePedidoId);

                            if (aprobado == null)
                            {
                                articulosProducir = new List<string>();
                                break;
                            }

                            decimal stock = decimal.Parse(detalle.Stock);

                            if (aprobado.CantidadAprobada > stock)
                            {
                                articulosProducir.Add($"{detalle.CodigoArticulo} {detalle.NombreArticulo} cantidad {aprobado.CantidadAprobada - stock} {detalle.UnidadMedida}");
                            }

                        }

                        if (articulosProducir.Count > 0)
                        {
                            List<string> correosDestinatarios = new List<string>();

                            try
                            {
                                correosDestinatarios.Add(parametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CORREO_APROBACION_PEDIDOS));
                            }
                            catch (EVOException e)
                            {
                                throw e;
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                            try
                            {
                                correosDestinatarios.Add(parametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CORREO_PRODUCCION));
                            }
                            catch (EVOException e)
                            {
                                throw e;
                            }
                            catch (Exception e)
                            {
                                throw e;
                            }

                            MailAddress mailAddress = null;

                            try
                            {
                                mailAddress = new MailAddress(correosDestinatarios.FirstOrDefault());
                            }
                            catch (Exception)
                            {
                                EVOException e = new EVOException(errores.errCorreoElectronicoNoValido);

                                logger.Error(e);

                                throw e;
                            }

                            try
                            {
                                mailAddress = new MailAddress(correosDestinatarios.LastOrDefault());
                            }
                            catch (Exception)
                            {
                                EVOException e = new EVOException(errores.errCorreoElectronicoNoValido);

                                logger.Error(e);

                                throw e;
                            }

                            BLCorreoElectronico bLCorreoElectronico = null;

                            bLCorreoElectronico = new BLCorreoElectronico(correosDestinatarios);

                            envioProduccion = bLCorreoElectronico.EnviarProduccion(bodega.WhsName, conf.NumeroPedido, articulosProducir);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return envioProduccion;

        }

        /// <summary>
        /// Obtiene una solicitud de pedido para ser gestionado en planta
        /// </summary>
        /// <param name="pedidoId">Id del pedido a solicitar</param>
        /// <returns>Retorna un objeto de negocio de tipo PedidoEnPlantaRespuesta</returns>
        public PedidoEnPlantaRespuesta ObtenerSolicitudPedidoEnPlanta(int pedidoId)
        {
            if (pedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerSolicitudPedido con el parámetro: pedidoId: {pedidoId}");

            DAPedido dAPedidos = new DAPedido();

            PedidoEnPlantaRespuesta pedidoEnPlanta;

            try
            {
                pedidoEnPlanta = dAPedidos.ObtenerSolicitudPedidoEnPlanta(pedidoId);

                ArticuloProxy articuloProxy = new ArticuloProxy();

                foreach (var detalle in pedidoEnPlanta.PedidoDetallesRespuesta)
                {
                    logger.Info($"Entró al método ObtenerArticuloxBodegaSAP con los parametros detalle.Codigo = {detalle.Codigo} , pedidoEnPlanta.SolicitudPara = {pedidoEnPlanta.SolicitudPara}");
                   
                    BOArticuloBodegaSAP articuloSAP = articuloProxy.ObtenerArticuloxBodegaSAP(detalle.Codigo, pedidoEnPlanta.SolicitudPara);
                   
                    logger.Info($"Salió del método ObtenerArticuloxBodegaSAP con respuesta = {articuloSAP} ");
                   
                    detalle.StockDisponible = 0;


                    if (articuloSAP != null)
                    {
                        detalle.StockDisponible = articuloSAP.Stock - detalle.CantidadComprometida;
                        detalle.StockDisponible = detalle.StockDisponible < 0 ? 0 : detalle.StockDisponible;
                    }

                    //Aholguin - Obtener Producción futura.
                 //  List<ArchivoPlano> articuloFuturo = DAPedido.ObtenerProduccionFuturaArticulo(detalle.Codigo,pedidoEnPlanta.FechaSolicitud,pedidoEnPlanta.FechaEntrega);


                }

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidoEnPlanta;
        }

        /// <summary>
        /// Obtiene el stock de un artículo en la(s) bodega(s) EVO 
        /// </summary>
        /// <param name="codigoArticulo">Código del artículo</param>
        /// <param name="prefijoBodegas">Prefijo de las bodegas</param>
        /// <returns>Retorna la cantidad en decimal</returns>
        public decimal ObtenerStockArticuloBodegas(string codigoArticulo, string prefijoBodegas)
        {
            if (string.IsNullOrEmpty(codigoArticulo))
            {
                EVOException e = new EVOException(errores.codigoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(prefijoBodegas))
            {
                EVOException e = new EVOException(errores.errPrefijoBodegasNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerStockPorArticulo con los parámetros: codigoArticulo: {codigoArticulo}, prefijoBodegas: {prefijoBodegas}");

            DAPedido dAPedidos = new DAPedido();

            decimal stock;

            try
            {
                stock = dAPedidos.ObtenerStockArticuloBodegas(codigoArticulo, prefijoBodegas);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return stock;
        }

        /// <summary>
        /// Crea un pedido
        /// </summary>
        /// <param name="pedido">Registro de pedido de tipo Pedido</param>
        /// <returns>Verdadero si se pudo persistir el pedido</returns>
        public string CrearPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                EVOException e = new EVOException(errores.errPedidoVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método CrearPedido con los parámetros: {0}",
                JsonConvert.SerializeObject(pedido)));

            ConfiguracionNotificacion configuracionNotificacion = new ConfiguracionNotificacion();

            if (pedido.TipoSolicitudId <= 0)
            {
                EVOException e = new EVOException(errores.errTipoSolicitudNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(pedido.WhsCode))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodegas = new BLBodega();

            BOBodega solicitudDe = null;

            EnviarPedido enviarPedido = new EnviarPedido();
            List<string> emails = new List<string>();

            try
            {
                solicitudDe = bLBodegas.ObtenerBodegaPorCodigo(pedido.WhsCode);

                //configuracionNotificacion.EmailDe = solicitudDe.Email;
                emails.Add(solicitudDe.Email);
                //configuracionNotificacion.PuntoDeVenta = solicitudDe.WhsName;
                enviarPedido.PuntoVenta = solicitudDe.WhsName;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLUsuario blUsuario = new BLUsuario();

            int nBackSlash = pedido.Usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                pedido.Usuario = pedido.Usuario.Substring(nBackSlash + 1, pedido.Usuario.Length - nBackSlash - 1);
            }

            Usuario buscar = blUsuario.ObtenerUsuarioPorUsuario(pedido.Usuario);

            if (buscar == null)
            {
                EVOException e = new EVOException(string.Format(errores.errUsuarioNoExiste,
                    pedido.Usuario));

                logger.Error(e);

                throw e;
            }

            pedido.UsuarioId = buscar.UsuarioId;

            //configuracionNotificacion.Nombre = buscar.Nombre;
            enviarPedido.Nombre = buscar.Nombre;

            BOBodega solicitudPara = null;

            try
            {
                solicitudPara = bLBodegas.ObtenerBodegaPorCodigo(pedido.SolicitudPara);

                // configuracionNotificacion.EmailPara = solicitudPara.Email;
                emails.Add(solicitudPara.Email);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }


            if (string.IsNullOrEmpty(pedido.EstadoPedido))
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            EstadoPedido estadoPedido = null;

            EstadosPedidoEnum estadoPedidoEnum = new EstadosPedidoEnum();

            switch (pedido.EstadoPedido)
            {
                //EstadosPedidoEnum.Borrador.ToString() no es soportado en C# 7.3 , pero si en c# 8.0 o superior.
                case "Borrador":
                    estadoPedidoEnum = EstadosPedidoEnum.Borrador;
                    break;
                case "Abierto":
                    estadoPedidoEnum = EstadosPedidoEnum.Abierto;
                    break;
            }

            try
            {
                estadoPedido = ObtenerEstadoPedidoxNombre(estadoPedidoEnum);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            pedido.EstadoPedidoId = estadoPedido.EstadoPedidoId;

            string nombreEstadoPedido = estadoPedido.Nombre;

            //configuracionNotificacion.EstadoPedidoNuevo = nombreEstadoPedido;
            enviarPedido.EstadoPedido = nombreEstadoPedido;

            try
            {
                estadoPedido = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Abierto);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            if (nombreEstadoPedido.Equals(estadoPedido.Nombre))
            {
                if (pedido.FechaEntrega == null)
                {
                    EVOException e = new EVOException(errores.errFechaEntregaObligatoria);

                    logger.Error(e);

                    throw e;
                }

                pedido.NumeroPedido = dAPedidos.ObtenerNumeroPedidoXCodigoBodega(pedido.WhsCode);

                //configuracionNotificacion.NumeroPedido = $"{pedido.WhsCode.Substring(pedido.WhsCode.LastIndexOf("-") + 1)}-{pedido.NumeroPedido}";
                enviarPedido.NumeroPedido = $"{pedido.WhsCode.Substring(pedido.WhsCode.LastIndexOf("-") + 1)}-{pedido.NumeroPedido}";
            }

            if (pedido.FechaEntrega != null)
            {
                if (pedido.FechaEntrega < DateTime.Now.Date)
                {
                    EVOException e = new EVOException(errores.errFechaEntregaFechaPedidoMenor);

                    logger.Error(e);

                    throw e;
                }
            }

            enviarPedido.Articulos = new List<string>();

            BOObtenerTipoSolicitudPedidoResponse boTipoSolicitud = null;

            if (pedido.Detalles != null && pedido.Detalles.Count > 0)
            {
                foreach (var detalle in pedido.Detalles)
                {
                    BLArticulo bLArticulos = new BLArticulo();

                    ArticuloBodega articuloBodega = null;

                    try
                    {
                        articuloBodega = bLArticulos.ObtenerArticuloxCodigoBodegaCodigoArticulo(pedido.WhsCode, detalle.ItemCode);
                    }
                    catch (EVOException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    BOArticulo bOArticulo = bLArticulos.ObtenerArticuloxCodigo(detalle.ItemCode);

                    detalle.ItemName = bOArticulo.ItemName;
                    detalle.UnidadMedida = bOArticulo.SalUnitMsr;

                    BOEstadoArticulo estadoArticulo = null;

                    boTipoSolicitud = ObtenerTiposSolicitudPedido().FirstOrDefault(ts => ts.TipoSolicitudNombre == TiposSolicitudEnum.Traslado.ToString());

                    if (pedido.TipoSolicitudId == boTipoSolicitud.TipoSolicitudId.Value)
                    {
                        try
                        {
                            estadoArticulo = bLArticulos.ObtenerEstadoArticuloxId(detalle.EstadoArticuloId.Value);
                        }
                        catch (EVOException e)
                        {
                            throw e;
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }

                        if (detalle.EmpaqueId <= 0)
                        {
                            EVOException e = new EVOException(errores.errEmpaqueNoInformado);

                            logger.Error(e);

                            throw e;
                        }
                        if (pedido.Detalles.Where(x => x.ItemCode == detalle.ItemCode && x.EstadoArticuloId == detalle.EstadoArticuloId).Count() > 1)
                        {
                            EVOException e = new EVOException(errores.errArticuloTipoPedidoExcede);

                            logger.Error(e);

                            throw e;
                        }
                    }

                    if (detalle.Cantidad <= 0)
                    {
                        EVOException e = new EVOException(errores.errCantidadArticuloNoInformado);

                        logger.Error(e);

                        throw e;
                    }

                    if (!string.IsNullOrEmpty(detalle.Observacion))
                    {
                        if (detalle.Observacion.Length > 100)
                        {
                            EVOException e = new EVOException(errores.errObservacionExcede);

                            logger.Error(e);

                            throw e;
                        }
                    }


                    if (pedido.Detalles.Where(x => x.ItemCode == detalle.ItemCode).Count() > 2)
                    {
                        EVOException e = new EVOException(errores.errArticuloCantidadPedidoExcede);

                        logger.Error(e);

                        throw e;
                    }

                }
            }

            pedido.FechaPedido = DateTime.Now;

            boTipoSolicitud = ObtenerTiposSolicitudPedido().FirstOrDefault(ts => ts.TipoSolicitudNombre == TiposSolicitudEnum.Compras.ToString());

            if (pedido.TipoSolicitudId == boTipoSolicitud.TipoSolicitudId.Value && pedido.EstadoPedidoId==2)
            {
                BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
                pedido.SolicitudPara = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CODIGO_ALMACEN_COMPRA);

                pedido.EmailBodega = solicitudDe.Email;
                pedido.NombreUsuario = buscar.NombreUsuario;

                SerieRespuesta serie = ObtenerSerie(pedido.WhsCode.Replace("PV", "SC"));

                pedido.NumeroDocumento = serie.NextNumber;
                pedido.Series = serie.Series;

                if (serie.NextNumber == serie.LastNum)
                {
                    serie.Activo = false;
                }

                serie.NextNumber = (int.Parse(serie.NextNumber) + 1).ToString();
                
                PedidoProxy pedidoProxy = new PedidoProxy();

                logger.Info($"Enviar pedido compra a SAP con parámetros  { JsonConvert.SerializeObject(pedido)}");

                string respuestaSAP = pedidoProxy.EnviarPedido(SerializarPedido(pedido));

                if (bool.Parse(respuestaSAP.Split("|")[0]))
                {
                    ActualizarSerie(serie);
                }
                else
                {
                    EVOException e = new EVOException(string.Format(errores.errEnviarPedidoSAP, respuestaSAP));

                    logger.Error(e);

                    throw e;
                }

                logger.Info($"Respuesta pedido compra desde SAP : { respuestaSAP}");

            }

            if (dAPedidos.CrearPedido(pedido))
            {
                if (!string.IsNullOrEmpty(solicitudDe.Email) && estadoPedidoEnum.ToString() != EstadosPedidoEnum.Borrador.ToString())
                {
                    try
                    {
                        //notificacion.Enviar(configuracionNotificacion);

                        pedido.Detalles.ForEach(d =>
                          enviarPedido.Articulos.Add($"{d.ItemCode} - {d.ItemName} {d.Cantidad}{d.UnidadMedida}")
                        );

                        BLCorreoElectronico bLCorreoElectronico = null;

                        bLCorreoElectronico = new BLCorreoElectronico(emails);

                        enviarPedido.Usuario = pedido.Usuario;

                        bLCorreoElectronico.EnviarPedidoNuevo(enviarPedido);

                        return enviarPedido.NumeroPedido;
                    }
                    catch (Exception e)
                    {
                        logger.Error(e);

                        throw e;
                    }
                }
            }

            return $"{pedido.WhsCode.Split("-")[1]}-{pedido.NumeroPedido}";
        }

        /// <summary>
        /// Este método obtiene todos los pedidos aceptados y parciales por filtro
        /// </summary>
        /// <param name="filtro">Indica el valor por el cual se va a realizar el filtro</param>
        /// <returns>Los valores del por el cual se realizo el filtro</returns>
        public List<PedidoBeneficioRespuesta> ObtenerTodosPedidosAceptadosxFiltro(FiltroPedidoBeneficio filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosPedidosAceptadosxFiltro con los parámetros {0}",
                JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            if (
                string.IsNullOrEmpty(filtro.Zona) &&
                string.IsNullOrEmpty(filtro.FechaSolicitud) &&
                string.IsNullOrEmpty(filtro.FechaEntrega) &&
                string.IsNullOrEmpty(filtro.Estado) &&
                string.IsNullOrEmpty(filtro.Cliente) &&
                string.IsNullOrEmpty(filtro.CodigoPedido) &&
                string.IsNullOrEmpty(filtro.DiasEntrega)
                )
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodegas = new BLBodega();
            BOBodega planta = null;

            try
            {
                planta = bLBodegas.ObtenerBodegaPorCodigo("PB-PT");
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<PedidoBeneficioRespuesta> pedidosRespuesta = null;

            try
            {
                pedidosRespuesta = dAPedidos.ObtenerTodosPedidosAceptadosxFiltro(filtro);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosRespuesta;
        }

        /// <summary>
        /// Este método obtiene todos los pedidos abiertos por filtro
        /// </summary>
        /// <param name="filtro">Indica el valor por el cual se va a realizar el filtro</param>
        /// <returns>Los valores del por el cual se realizo el filtro</returns>
        public List<PedidoBeneficioRespuesta> ObtenerTodosPedidosAbiertosxFiltro(FiltroPedidoBeneficio filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosPedidosAbiertosxFiltro con los parámetros {0}",
                JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            if (
                string.IsNullOrEmpty(filtro.Zona) &&
                string.IsNullOrEmpty(filtro.FechaSolicitud) &&
                string.IsNullOrEmpty(filtro.FechaEntrega) &&
                string.IsNullOrEmpty(filtro.Estado) &&
                string.IsNullOrEmpty(filtro.Cliente) &&
                string.IsNullOrEmpty(filtro.CodigoPedido) &&
                string.IsNullOrEmpty(filtro.DiasEntrega)
                )
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodegas = new BLBodega();
            BOBodega planta = null;

            try
            {
                planta = bLBodegas.ObtenerBodegaPorCodigo("PB-PT");
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<PedidoBeneficioRespuesta> pedidosRespuesta = null;

            try
            {
                pedidosRespuesta = dAPedidos.ObtenerTodosPedidosAbiertosxFiltro(filtro);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosRespuesta;
        }


        /// <summary>
        /// Este método obtiene todos los pedidos a planta de beneficio por filtro
        /// </summary>
        /// <param name="filtro">Indica el valor por el cual se va a realizar el filtro</param>
        /// <returns>Los valores del por el cual se realizo el filtro</returns>
        public List<PedidoBeneficioRespuesta> ObtenerTodosPedidosABenficioxFiltro(FiltroPedidoBeneficio filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosPedidosABenficioxFiltro con los parámetros {0}",
                JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            if (
                string.IsNullOrEmpty(filtro.Zona) &&
                string.IsNullOrEmpty(filtro.FechaSolicitud) &&
                string.IsNullOrEmpty(filtro.FechaEntrega) &&
                string.IsNullOrEmpty(filtro.Estado) &&
                string.IsNullOrEmpty(filtro.Cliente) &&
                string.IsNullOrEmpty(filtro.CodigoPedido) &&
                string.IsNullOrEmpty(filtro.DiasEntrega)
                )
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodegas = new BLBodega();
            BOBodega planta = null;

            try
            {
                planta = bLBodegas.ObtenerBodegaPorCodigo("PB-PT");
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<PedidoBeneficioRespuesta> pedidosRespuesta = null;

            try
            {
                pedidosRespuesta = dAPedidos.ObtenerTodosPedidosAbiertosxFiltro(filtro);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosRespuesta;
        }

        /// <summary>
        /// Este método obtiene todos los pedidos a distribución por filtro
        /// </summary>
        /// <param name="filtro">Indica el valor por el cual se va a realizar el filtro</param>
        /// <returns>Los valores del por el cual se realizó el filtro</returns>
        public List<PedidoDistribucionRespuesta> ObtenerTodosPedidosADistribucionxFiltro(FiltroPedidoDistribucion filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosPedidosADespachoxFiltro con los parámetros {0}",
                JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            if (
                string.IsNullOrEmpty(filtro.Estado) &&
                string.IsNullOrEmpty(filtro.CodigoPedido) &&
                string.IsNullOrEmpty(filtro.Cliente) &&
                string.IsNullOrEmpty(filtro.Entregas) &&
                string.IsNullOrEmpty(filtro.FechaSolicitud) &&
                string.IsNullOrEmpty(filtro.OrdenCompra) &&
                string.IsNullOrEmpty(filtro.Zona))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodegas = new BLBodega();
            BOBodega planta = null;

            try
            {
                planta = bLBodegas.ObtenerBodegaPorCodigo("PB-PT");
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            List<PedidoDistribucionRespuesta> pedidosRespuesta = null;

            try
            {
                pedidosRespuesta = dAPedidos.ObtenerTodosPedidosADistribucionxFiltro(filtro);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosRespuesta;
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los pedidos a planta de beneficio
        /// </summary>
        /// <returns>El conteo de los pedidos a planta de beneficio</returns>
        public int ObtenerConteoTodosPedidosABeneficio()
        {
            logger.Info($"Entró al método ObtenerConteoTodosPedidosABeneficio");

            DAPedido dAPedidos = new DAPedido();

            int nRegistros = 0;

            try
            {
                object result = dAPedidos.ObtenerConteoTodosPedidosABeneficio();

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los pedidos a planta de beneficio de forma parametrizable
        /// </summary>
        /// <param name="desde">Indica apartir desde que valor se obtendran los datos ejemplo: desde 1</param>
        /// <param name="hasta">Indica apartir hasta que valor se obtendran los datos ejemplo: hasta 10</param>
        /// <returns>Obtiene los registros de los parametros</returns>
        public List<PedidoBeneficioRespuesta> ObtenerTodosPedidosABeneficio(int desde, int hasta)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosPedidosABeneficio con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<PedidoBeneficioRespuesta> pedidosBeneficioRespuestas = null;

            try
            {
                pedidosBeneficioRespuestas = dAPedidos.ObtenerTodosPedidosABeneficio(desde, hasta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosBeneficioRespuestas;
        }

        /// <summary>
        /// Este método obtiene todas las cantidades de los pedidos por su estado
        /// </summary>
        /// <returns>Cantidad de pedidos por su estado</returns>
        public List<EstadoPedido> ObtenerTodosCantidadPedidosxEstado()
        {
            logger.Info("Entró al método ObtenerTodosCantidadPedidosxEstado en BlPedidos");

            List<EstadoPedido> estadosPedido = new List<EstadoPedido>();

            try
            {
                estadosPedido = ObtenerTodosEstadosPedido();
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            DAPedido dAPedidos = new DAPedido();

            EstadoPedido borrador = null;

            try
            {
                borrador = ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Borrador);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            estadosPedido.RemoveAll(e => e.Nombre == borrador.Nombre);
            estadosPedido.Insert(estadosPedido.Count, borrador);

            foreach (EstadoPedido estadoPedido in estadosPedido)
            {
                int cantidad = dAPedidos.ObtenerTodosCantidadPedidosxEstadoId(estadoPedido.EstadoPedidoId);

                estadoPedido.Nombre = $"{estadoPedido.Nombre}({cantidad})";

            }

            return estadosPedido;

        }


        /// <summary>
        /// Este método valida si existe el pedido en estado borrador 
        /// </summary>
        /// <param name="obtenerPedidoBorradorPeticion">Obtiene la petición al pedido</param>
        /// <returns>Valida si el pedido existe en pedido borrador</returns>
        public bool ExistePedidoBorrador(ObtenerPedidoBorradorPeticion obtenerPedidoBorradorPeticion)
        {
            if (obtenerPedidoBorradorPeticion == null)
            {
                EVOException e = new EVOException(errores.errPedidoBorrador);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ExistePedidoBorrador con los parámetros; {0}",
                JsonConvert.SerializeObject(obtenerPedidoBorradorPeticion)));

            if (string.IsNullOrEmpty(obtenerPedidoBorradorPeticion.SolicitudPara))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            BOBodega bodega = null;

            BLBodega bLBodegas = new BLBodega();

            try
            {
                bodega = bLBodegas.ObtenerBodegaPorCodigo(obtenerPedidoBorradorPeticion.SolicitudPara);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (string.IsNullOrEmpty(obtenerPedidoBorradorPeticion.WhsCode))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            try
            {
                bodega = bLBodegas.ObtenerBodegaPorCodigo(obtenerPedidoBorradorPeticion.SolicitudPara);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            EstadoPedido estadoPedido = null;
            DAPedido dAPedidos = new DAPedido();

            try
            {
                estadoPedido = dAPedidos.ObtenerEstadoPedidoxNombre(EstadosPedidoEnum.Borrador);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            bool respuesta = false;
            obtenerPedidoBorradorPeticion.EstadoPedidoId = estadoPedido.EstadoPedidoId;

            try
            {
                respuesta = dAPedidos.ExistePedido(obtenerPedidoBorradorPeticion);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return respuesta;
        }

        /// <summary>
        /// Este método obtiene todos los estados del pedido
        /// </summary>
        /// <returns>Lista de todos los estados del pedido</returns>
        public List<EstadoPedido> ObtenerTodosEstadosPedido()
        {
            logger.Info("Entró al método ObtenerTodosEstadosPedido sin parámetros");

            DAPedido daPedidos = new DAPedido();

            List<EstadoPedido> estadosPedido = new List<EstadoPedido>();

            try
            {
                estadosPedido = daPedidos.ObtenerTodosEstadosPedido();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return estadosPedido;
        }

        /// <summary>
        /// Este método obtiene el conteo por todos los pedidos
        /// </summary>
        /// <param name="whsCode">Indica el código de la planta</param>
        /// <returns>Número de todos los pedidos</returns>
        public int ObtenerConteoTodosPedidos(string whsCode)
        {
            logger.Info($"Entró al método ObtenerConteoTodosPedidos con el parametro whsCode {whsCode}");

            DAPedido dAPedidos = new DAPedido();

            int nRegistros = 0;

            try
            {
                object result = dAPedidos.ObtenerConteoTodosRegistros(whsCode);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los registros de forma parametrizable
        /// </summary>
        /// <param name="desde">Indica apartir desde que valor se obtendran los datos ejemplo: desde 1</param>
        /// <param name="hasta">Indica apartir hasta que valor se obtendran los datos ejemplo: hasta 10</param>
        /// <param name="whsCode">Indica el código de la planta</param>
        /// <returns>Lista por el cual se realizo el filtro</returns>
        public List<PedidoRespuesta> ObtenerTodosRegistros(int desde, int hasta, string whsCode)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosRegistros con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            if (string.IsNullOrEmpty(whsCode))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoInformado);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<PedidoRespuesta> pedidosRespuesta = null;

            //bool duplicar = true;

            //try
            //{
            //    duplicar = bool.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.DUPLICAR_PEDIDO));
            //}
            //catch
            //{
            //    EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

            //    logger.Error(e);

            //    throw e;
            //}

            try
            {
                pedidosRespuesta = dAPedidos.ObtenerTodosRegistros(desde, hasta, whsCode);

                BLClientesParametrizacion bLClientesParametrizacion = new BLClientesParametrizacion();

                BOParametrizacionResponse bOParametrizacionResponse = bLClientesParametrizacion.ObtenerPatrametrizacionesxCliente(whsCode); ;

                foreach (PedidoRespuesta pedidoRespuesta in pedidosRespuesta)
                {
                    pedidoRespuesta.Planta = pedidoRespuesta.TipoSolicitud == TiposSolicitudEnum.Compras.ToString() ? "ÁREA DE COMPRAS" : pedidoRespuesta.Planta;

                    pedidoRespuesta.CodigoPedido = $"{pedidoRespuesta.WhsCode.Substring(pedidoRespuesta.WhsCode.LastIndexOf("-") + 1)}-{pedidoRespuesta.NumeroPedido.ToString()}";
                    if (pedidoRespuesta.FechaEntrega == null)
                    {
                        pedidoRespuesta.FechaEntrega = string.Empty;
                        continue;
                    }

                    DateTime solicitud = DateTime.Parse(pedidoRespuesta.FechaSolicitud);
                    DateTime entrega = DateTime.Parse(pedidoRespuesta.FechaEntrega);

                    pedidoRespuesta.DiasEntrega = (entrega - solicitud).Days.ToString();

                    if (bOParametrizacionResponse == null)
                    {
                        pedidoRespuesta.Duplicar = false;
                    }

                    if (bOParametrizacionResponse != null)
                    {
                        pedidoRespuesta.Duplicar = bOParametrizacionResponse.DuplicarPedido.Value;
                    }


                    if (pedidoRespuesta.TipoSolicitud == TiposSolicitudEnum.Compras.ToString())
                    {
                        pedidoRespuesta.Duplicar = false;
                        pedidoRespuesta.Editar = false;
                    }
                }

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosRespuesta;
        }

        /// <summary>
        /// Obtiene el pedido por el id
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <returns>Id del pedido</returns>
        public ObtenerPedidoRespuesta ObtenerPedidoxId(int pedidoId)
        {
            if (pedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerPedidoxId con el parámetro: pedidoId: {pedidoId}");

            DAPedido dAPedidos = new DAPedido();

            ObtenerPedidoRespuesta obtenerPedidoRespuesta;

            try
            {
                obtenerPedidoRespuesta = dAPedidos.ObtenerPedidoxId(pedidoId);

                if (obtenerPedidoRespuesta == null)
                {
                    EVOException e = new EVOException(errores.errPedidoNOExiste);

                    logger.Error(e);

                    throw e;
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return obtenerPedidoRespuesta;
        }

        /// <summary>
        /// Este método obtiene la consulta por el id del pedido
        /// </summary>
        /// <param name="pedidoId">Indica el id del pedido</param>
        /// <returns>El pedido por su id</returns>
        public ConsultaPedidoRespuesta ObtenerConsultaPedidoxId(int pedidoId)
        {
            if (pedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errPedidoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerConsultaPedidoxId con el parámetro: pedidoId: {pedidoId}");

            DAPedido dAPedidos = new DAPedido();

            ConsultaPedidoRespuesta consultaPedidoRespuesta;

            try
            {
                consultaPedidoRespuesta = dAPedidos.ObtenerConsultaPedidoxId(pedidoId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return consultaPedidoRespuesta;
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los pedidos por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor por el cual se va a realizar el filtro</param>
        /// <returns>Número por el cual se realizó el filtro</returns>
        public int ObtenerConteoTodosPedidosxFiltro(FiltroPedido filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerConteoTodosPedidosxFiltro con los parámetros; {0}",
                JsonConvert.SerializeObject(filtro)));

            DAPedido dAPedidos = new DAPedido();

            if (
                filtro.PlantaBeneficio == null &&
                filtro.PlantaDerivados == null &&
                string.IsNullOrWhiteSpace(filtro.Estado) &&
                string.IsNullOrWhiteSpace(filtro.FechaDesde) &&
                string.IsNullOrWhiteSpace(filtro.FechaHasta) &&
                string.IsNullOrWhiteSpace(filtro.Pendientes))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }


            if (string.IsNullOrEmpty(filtro.FechaDesde))
            {
                EVOException e = new EVOException(errores.errFechaDesde);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(filtro.FechaHasta))
            {
                EVOException e = new EVOException(errores.errFechaHasta);

                logger.Error(e);

                throw e;
            }

            string FechaPattern = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";

            Match regFechaMatch = Regex.Match(filtro.FechaDesde, FechaPattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                logger.Error(e);

                throw e;
            }

            regFechaMatch = Regex.Match(filtro.FechaHasta, FechaPattern);

            if (!regFechaMatch.Success)
            {
                EVOException e = new EVOException(errores.errFechaFormatoDDMMYYY);

                logger.Error(e);

                throw e;
            }

            filtro.FechaDesde = DateTime.ParseExact(filtro.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                 .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            filtro.FechaHasta = DateTime.ParseExact(filtro.FechaDesde, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                 .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            int nRegistros = 0;

            try
            {
                object result = dAPedidos.ObtenerConteoTodosRegistrosxFiltro(filtro);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los pedidos por el filtro
        /// </summary>
        /// <param name="filtro">Indica el valor de la busqueda por el caul se realizara el filtro</param>
        /// <returns>Lista por el cual se realizo la busqueda</returns>
        public List<PedidoRespuesta> ObtenerTodosPedidosxFiltro(FiltroPedido filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosPedidosxFiltro con los parámetros {0}",
                JsonConvert.SerializeObject(filtro)));

            if (string.IsNullOrEmpty(filtro.WhsCode))
            {
                EVOException e = new EVOException(errores.codigoBodegaNoFormato);

                logger.Error(e);

                throw e;
            }

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DAPedido dAPedidos = new DAPedido();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            if (
                filtro.PlantaBeneficio == null &&
                filtro.PlantaDerivados == null &&
                string.IsNullOrWhiteSpace(filtro.Estado) &&
                string.IsNullOrWhiteSpace(filtro.FechaDesde) &&
                string.IsNullOrWhiteSpace(filtro.FechaHasta) &&
                string.IsNullOrWhiteSpace(filtro.Pendientes))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            BLBodega bLBodegas = new BLBodega();
            BOBodega planta = null;

            try
            {
                planta = bLBodegas.ObtenerBodegaPorCodigo("PB-PT");
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (filtro.PlantaBeneficio != null)
            {
                filtro.CodigoPlantaBeneficio = string.Empty;
                if (filtro.PlantaBeneficio.Value)
                {
                    filtro.CodigoPlantaBeneficio = planta.WhsCode;
                }
            }

            try
            {
                planta = bLBodegas.ObtenerBodegaPorCodigo("PDC-PTD");
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (filtro.PlantaDerivados != null)
            {
                filtro.CodigoPlantaDerivados = string.Empty;
                if (filtro.PlantaDerivados.Value)
                {
                    filtro.CodigoPlantaDerivados = planta.WhsCode;
                }
            }

            if (string.IsNullOrEmpty(filtro.Estado))
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(filtro.Pendientes))
            {
                EVOException e = new EVOException(errores.errPendientePedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(filtro.FechaDesde))
            {
                EVOException e = new EVOException(errores.errFechaDesde);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(filtro.FechaHasta))
            {
                EVOException e = new EVOException(errores.errFechaHasta);

                logger.Error(e);

                throw e;
            }

            List<PedidoRespuesta> pedidosRespuesta = null;

            try
            {
                pedidosRespuesta = dAPedidos.ObtenerTodosRegistrosxFiltro(filtro);

                foreach (PedidoRespuesta pedidoRespuesta in pedidosRespuesta)
                {
                    pedidoRespuesta.CodigoPedido = $"{pedidoRespuesta.WhsCode.Substring(pedidoRespuesta.WhsCode.LastIndexOf("-") + 1)}-{pedidoRespuesta.NumeroPedido.ToString()}";
                    if (pedidoRespuesta.FechaEntrega == null)
                    {
                        pedidoRespuesta.FechaEntrega = string.Empty;
                        continue;
                    }

                    DateTime solicitud = DateTime.Parse(pedidoRespuesta.FechaSolicitud);
                    DateTime entrega = DateTime.Parse(pedidoRespuesta.FechaEntrega);

                    pedidoRespuesta.DiasEntrega = (entrega - solicitud).Days.ToString();

                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosRespuesta;
        }

        /// <summary>
        ///  Este método obtiene el estado del pedido por el id
        /// </summary>
        /// <param name="estadoPedidoId">Indica el id del pedido</param>
        /// <returns>Estado del pedido por el id</returns>
        public EstadoPedido ObtenerEstadoPedidoxId(int estadoPedidoId)
        {
            if (estadoPedidoId <= 0)
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEstadoPedidoxId con el parámetro estadoPedidoId = {estadoPedidoId}");

            DAPedido dAPedidos = new DAPedido();

            EstadoPedido estadoPedido = null;

            try
            {
                estadoPedido = dAPedidos.ObtenerEstadoPedidoxId(estadoPedidoId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (estadoPedido == null)
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return estadoPedido;

        }

        /// <summary>
        /// Este método obtiene el estado del pedido por el nombre 
        /// </summary>
        /// <param name="estadoPedidoEnum">Indica el nombre del estado del pedido</param>
        /// <returns>Estado del pedido por su nombre</returns>
        public EstadoPedido ObtenerEstadoPedidoxNombre(EstadosPedidoEnum estadoPedidoEnum)
        {
            if (string.IsNullOrEmpty(estadoPedidoEnum.ToString()))
            {
                EVOException e = new EVOException(errores.errNomobreEstadoPedidoNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerEstadoPedidoxNombre con el parámetro nombre = {estadoPedidoEnum}");

            DAPedido dAPedidos = new DAPedido();

            EstadoPedido estadoPedido = null;

            try
            {
                estadoPedido = dAPedidos.ObtenerEstadoPedidoxNombre(estadoPedidoEnum);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (estadoPedido == null)
            {
                EVOException e = new EVOException(errores.errEstadoPedidoNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return estadoPedido;

        }

        /// <summary>
        /// Este método obtiene todos los pedidos en estado abierto
        /// </summary>
        /// <param name="desde">Indica apartir desde que valor se obtendran los datos ejemplo: desde 1</param>
        /// <param name="hasta">Indica apartir hasta que valor se obtendran los datos ejemplo: hasta 10</param>
        /// <returns>Lista de negocio PedidoBeneficioRespuesta</returns>
        public List<PedidoBeneficioRespuesta> ObtenerPedidosAbiertos(int desde, int hasta)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerPedidosAbiertos con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            DAPedido dAPedidos = new DAPedido();

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<PedidoBeneficioRespuesta> pedidosBeneficioRespuestas = null;

            try
            {
                pedidosBeneficioRespuestas = dAPedidos.ObtenerPedidosAbiertos(desde, hasta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosBeneficioRespuestas;
        }

        /// <summary>
        /// Este método obtiene todos los pedidos en estado aceptado y aceptado parcial
        /// </summary>
        /// <param name="desde">Indica apartir desde que valor se obtendran los datos ejemplo: desde 1</param>
        /// <param name="hasta">Indica apartir hasta que valor se obtendran los datos ejemplo: hasta 10</param>
        /// <returns>Lista de negocio PedidoBeneficioRespuesta</returns>
        public List<PedidoBeneficioRespuesta> ObtenerPedidosAceptados(int desde, int hasta)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerPedidosAceptados con los parámetros: desde: {0}, hasta: {1}", desde, hasta));

            DAPedido dAPedidos = new DAPedido();

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<PedidoBeneficioRespuesta> pedidosBeneficioRespuestas = null;

            try
            {
                pedidosBeneficioRespuestas = dAPedidos.ObtenerPedidosAceptados(desde, hasta);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return pedidosBeneficioRespuestas;
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los pedidos en estado abierto
        /// </summary>
        /// <returns>El conteo de los pedidos en estado abierto</returns>
        public int ObtenerConteoTodosPedidosAbiertos()
        {
            logger.Info($"Entró al método ObtenerConteoTodosPedidosAbiertos");

            DAPedido dAPedidos = new DAPedido();

            int nRegistros = 0;

            try
            {
                object result = dAPedidos.ObtenerConteoTodosPedidosAbiertos();

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene el conteo de todos los pedidos en estado aceptado y aceptado parcial
        /// </summary>
        /// <returns>El conteo de los pedidos en estado aceptado y aceptado parcial</returns>
        public int ObtenerConteoTodosPedidosAceptados()
        {
            logger.Info($"Entró al método ObtenerConteoTodosPedidosAceptados");

            DAPedido dAPedidos = new DAPedido();

            int nRegistros = 0;

            try
            {
                object result = dAPedidos.ObtenerConteoTodosPedidosAceptados();

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Método de validación de parámetros cuando se ejecute la consulta de canales con sus archivos cargados en la BD
        /// </summary>
        /// <param name="filtroArchivo"></param>
        private void ValidarParametrosFiltroArchivos(FiltroArchivo filtroArchivo)
        {
            if (filtroArchivo == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);
                logger.Error(e);
                throw e;
            }
            logger.Info(string.Format("Entró al método ObtenerTodosArchivosxFiltro con los parámetros {0}", JsonConvert.SerializeObject(filtroArchivo)));
            //if (string.IsNullOrEmpty(filtroArchivo.NombreArchivo))
            //{
            //    EVOException e = new EVOException(errores.errArchivoCargaNoInformado);
            //    logger.Error(e);
            //    throw e;
            //}

            if (filtroArchivo.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);
                logger.Error(e);
                throw e;
            }

            if (filtroArchivo.Hasta < filtroArchivo.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);
                logger.Error(e);
                throw e;
            }
        }
               
        /// <summary>
        /// Este método se encarga de validar que los parámeros para cargar un archivo plano de canales sean válidos para el procesamiento
        /// </summary>
        /// <param name="bOArchivoRequest">Instancia del objeto de carga de archivo request</param>
        /// <returns>true/false</returns>
        private void ValidarParametrosCargaArchivos(BOCargarArchivoRequest bOArchivoRequest)
        {
            if (bOArchivoRequest == null)
            {
                EVOException e = new EVOException(errores.errArchivoCargaNoInformado);

                logger.Error(e);

                throw e;
            }
            logger.Info($"Entró al método CargarArchivoCanales en BLPedido con los parámetros = {JsonConvert.SerializeObject(bOArchivoRequest)}");

            if (string.IsNullOrEmpty(bOArchivoRequest.Base64))
            {
                EVOException e = new EVOException(errores.errBase64NoInformado);

                logger.Error(e);

                throw e;
            }
            bool extensionNoValida = true;

            foreach (string extension in Enum.GetNames(typeof(TiposArchivoEnum)))
            {
                if (bOArchivoRequest.NombreArchivo.ToUpper().Contains(extension.ToUpper()))
                {
                    extensionNoValida = false;
                    break;
                }
            }

            if (extensionNoValida)
            {
                EVOException e = new EVOException(errores.errExtensionArchivoNoValida);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOArchivoRequest.NombreArchivo))
            {
                EVOException e = new EVOException(errores.errNombreArchivoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (bOArchivoRequest.NombreArchivo.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                EVOException e = new EVOException(errores.errNombreArchivoNoValido);

                logger.Error(e);

                throw e;
            }

        }

        /// <summary>
        /// Este método se encarga de validar que los parámeros para eliminar un archivo plano de canales sean válidos para la eliminación
        /// </summary>
        /// <param name="bOArchivoRequest">Instancia del objeto de carga de archivo request</param>
        /// <returns>true/false</returns>
        private void ValidarParametrosEliminarArchivos(BOCargarArchivoRequest bOArchivoRequest)
        {
            if (bOArchivoRequest == null)
            {
                EVOException e = new EVOException(errores.errArchivoCargaNoInformado);

                logger.Error(e);

                throw e;
            }
            logger.Info($"Entró al método Eliminar Archivos Canales en BLPedido con los parámetros = {JsonConvert.SerializeObject(bOArchivoRequest)}");

            
            bool extensionNoValida = true;

            foreach (string extension in Enum.GetNames(typeof(TiposArchivoEnum)))
            {
                if (bOArchivoRequest.NombreArchivo.ToUpper().Contains(extension.ToUpper()))
                {
                    extensionNoValida = false;
                    break;
                }
            }

            if (extensionNoValida)
            {
                EVOException e = new EVOException(errores.errExtensionArchivoNoValida);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOArchivoRequest.NombreArchivo))
            {
                EVOException e = new EVOException(errores.errNombreArchivoNoInformado);

                logger.Error(e);

                throw e;
            }

            if (bOArchivoRequest.NombreArchivo.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                EVOException e = new EVOException(errores.errNombreArchivoNoValido);

                logger.Error(e);

                throw e;
            }

        }


        /// <summary>
        /// Valida y copia el archivo en el directorio del servidor
        /// </summary>
        /// <param name="bOArchivoRequest"></param>
        /// <returns></returns>
        private string ValidarArchivo(BOCargarArchivoRequest bOArchivoRequest)
        {
            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();
            string formateoNombreArchivo = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.FORMATO_NOMBREARCHIVO);
            formateoNombreArchivo = formateoNombreArchivo + DateTime.Now.ToString("MMddyyyy") + "_" + DateTime.Now.ToString("HHmmss") + ".xlsx";

            string rutaDirectorioArchivoCanales = string.Empty;
            string rutaCompleta = string.Empty;

            try
            {
                rutaDirectorioArchivoCanales = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.RUTA_ARCHIVOCANALES);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (!Directory.Exists(rutaDirectorioArchivoCanales))
            {
                try
                {
                    Directory.CreateDirectory(rutaDirectorioArchivoCanales);
                }
                catch (Exception e)
                {
                    logger.Error(e);
                    throw;
                }
            }

            DirectoryInfo directoryInfo = null;

            try
            {
                directoryInfo = new DirectoryInfo(rutaDirectorioArchivoCanales);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            try
            {
                //byte[] data = Encoding.UTF8.GetBytes(bOArchivoRequest.Base64);
                //string b64 = Convert.ToBase64String(data);
                File.WriteAllBytes(rutaDirectorioArchivoCanales + "/" + formateoNombreArchivo, Convert.FromBase64String(bOArchivoRequest.Base64));
                

            }
            catch (Exception e)
            {
                Directory.Delete(rutaDirectorioArchivoCanales, true);
                logger.Error(e);
                throw;
            }
            
            rutaCompleta = rutaDirectorioArchivoCanales + "/" + formateoNombreArchivo;

            return rutaCompleta;
        }

       

        /// <summary>
        /// Este método se encarga de serializar una instancia de un objeto Pedido a un archivo XML que entiende el integrador SAP
        /// </summary>
        /// <param name="pedido">Instancia del objeto de pedido</param>
        /// <returns>Archivo XML con el contrato de datos para el integrador SAP</returns>
        private string SerializarPedido(Pedido pedido)
        {
            string pedidoSerializado = null;

            XmlDocument doc = new XmlDocument();
            XmlElement SAPBOElement, SAPElement;

            doc = this.CrearEncabezdoDocumento(out SAPBOElement, out SAPElement);

            this.CrearSAPElement(pedido, doc, SAPElement);

            SAPBOElement.AppendChild(SAPElement);

            //Se encarga de quitar la estructura de configuracion del XML
            using (StringWriter stringWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    OmitXmlDeclaration = true,
                    IndentChars = "  ",
                    NewLineChars = "\n",
                    NewLineHandling = NewLineHandling.Replace
                };

                using (XmlWriter xmlTextWriter = XmlWriter.Create(stringWriter, settings))
                {
                    doc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    pedidoSerializado = stringWriter.GetStringBuilder().ToString();
                }
            }

            return pedidoSerializado;
        }

        /// <summary>
        /// Se crean los elementos XML exigidos por la integración con SAP
        /// </summary>
        /// <param name="pedido">Datos del objeto de negocio de Pedido</param>
        /// <param name="doc">Documento XML que contiene la estructura de integración</param>
        /// <param name="SAPElement">Elemento SAP que se va a completar con las propiedades del pedido</param>
        private void CrearSAPElement(Pedido pedido, XmlDocument doc, XmlElement SAPElement)
        {
            //AppConfiguration appConfig = new AppConfiguration();
            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            //Esta es la base de datos de sap
            //BaseDatosAttr.Value = appConfig.AppSettings["BaseDeDatos"];

            string tabla = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TABLA_ASIGNAR_PEDIDO_SAP);

            //Encabezado del XML 
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, tabla, "Series", pedido.Series.ToString()));
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, tabla, "U_NumPorcipos", pedido.NumeroDocumento.ToString()));
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, tabla, "ReqName", pedido.NombreUsuario.ToString()));
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, tabla, "Email", pedido.EmailBodega.ToString()));
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, tabla, "ReqDate", pedido.FechaEntrega.Value.ToString("dd/MM/yyyy")));
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, tabla, "DocDate", pedido.FechaPedido.ToString("dd/MM/yyyy")));
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, tabla, "TaxDate", pedido.FechaPedido.ToString("dd/MM/yyyy")));
            SAPElement.AppendChild(CrearPropiedadEncabezado(doc, tabla, "DocDueDate", pedido.FechaPedido.ToString("dd/MM/yyyy")));

            // Variable NumeroLinea, Se encarga de contar uno a uno cada articulo y este valor lo asigna al numero de linea del XML
            int NumeroLinea = 0;

            // Variable LineasAfectadas, Se encarga de contar cuantos articulos hay en total y este valor lo asigna  a las lineas afectadas del XML
            int LineasAfectadas = pedido.Detalles.Count;

            tabla = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.DETALLE_TABLA_ASIGNAR_PEDIDO_SAP);

            ////Detalle del XML 
            foreach (var detalle in pedido.Detalles)
            {
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, tabla, "ItemCode", detalle.ItemCode, LineasAfectadas, NumeroLinea));
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, tabla, "LineVendor", string.Empty, LineasAfectadas, NumeroLinea)); //Proveedor ?
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, tabla, "Quantity", detalle.Cantidad.ToString(), LineasAfectadas, NumeroLinea));
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, tabla, "WhsCode", pedido.WhsCode, LineasAfectadas, NumeroLinea)); //cuando es de tipo Compra ?
                SAPElement.AppendChild(CrearPropiedadDetalle(doc, tabla, "OcrCode2", "2502", LineasAfectadas, NumeroLinea));

                NumeroLinea++;
            }
        }

        private XmlNode CrearPropiedadEncabezado(XmlDocument doc, string tabla, string v, object p)
        {
            throw new NotImplementedException();
        }

        // <summary>
        // Crea las estructuras del encabezado del documento XML que se envía a SAP
        // </summary>
        // <param name = "SAPBOElement" > Elemento SAPBO requerido por la integración con SAP.Parámetro pasado por referencia.</param>
        // <param name = "SAPElement" > Elemento SAP requerido por la integración con SAP.Parámetro pasado por referencia.</param>
        // <returns>Documento XML con los encabezados recién agregados</returns>
        private XmlDocument CrearEncabezdoDocumento(out XmlElement SAPBOElement, out XmlElement SAPElement)
        {
            XmlDocument doc = new XmlDocument();

            XmlElement ObjetosIntegracionElement = doc.CreateElement(string.Empty, "ObjetosIntegracion", string.Empty);

            XmlAttribute BaseDatosAttr = doc.CreateAttribute("BaseDatos");

            //AppConfiguration appConfig = new AppConfiguration();

            BLParametroGeneral bLParametroGeneral = new BLParametroGeneral();

            //Esta es la base de datos de sap
            //BaseDatosAttr.Value = appConfig.AppSettings["BaseDeDatos"];

            BaseDatosAttr.Value = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.BASE_DATOS_SAP);

            ObjetosIntegracionElement.Attributes.Append(BaseDatosAttr);

            doc.AppendChild(ObjetosIntegracionElement);

            SAPBOElement = doc.CreateElement(string.Empty, "SAPBO", string.Empty);
            ObjetosIntegracionElement.AppendChild(SAPBOElement);

            SAPElement = doc.CreateElement(string.Empty, "SAP", string.Empty);
            XmlAttribute ObjetoAttr = doc.CreateAttribute("Objeto");

            //Este Valor es la tabla  de sap que tiene los campos del xml 
            //ObjetoAttr.Value = appConfig.AppSettings["Tabla"];
            ObjetoAttr.Value = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TABLA_ASIGNAR_PEDIDO_SAP);

            SAPElement.Attributes.Append(ObjetoAttr);

            XmlAttribute LlaveprimariaAttr = doc.CreateAttribute("Llaveprimaria");

            //Este Valor es la llave primaria de la tabla
            LlaveprimariaAttr.Value = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.LLAVE_PRIMARIA_ASIGNAR_PEDIDO_SAP_NOMBRE);

            SAPElement.Attributes.Append(LlaveprimariaAttr);

            XmlAttribute ValorLlavePrimariaAttr = doc.CreateAttribute("ValorLlavePrimaria");

            //Este es el valor de la llave primaria
            ValorLlavePrimariaAttr.Value = bLParametroGeneral.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.LLAVE_PRIMARIA_ASIGNAR_PEDIDO_SAP_VALOR);

            SAPElement.Attributes.Append(ValorLlavePrimariaAttr);

            XmlAttribute OperacionAttr = doc.CreateAttribute("Operacion");

            //Este valor es la accion que hace el xml que es agregar 
            OperacionAttr.Value = "Add";

            SAPElement.Attributes.Append(OperacionAttr);

            return doc;
        }


        private XmlElement CrearPropiedadEncabezado(XmlDocument doc, string nombreTabla, string nombreColumna, string valor)
        {
            XmlElement Propiedad_EncabezadoElement = doc.CreateElement(string.Empty, "Propiedad_Encabezado", string.Empty);
            // Propiedad del encabezado Nombre de la tabla 
            XmlAttribute NombreTablaAttr = doc.CreateAttribute("NombreTabla");

            NombreTablaAttr.Value = nombreTabla;

            Propiedad_EncabezadoElement.Attributes.Append(NombreTablaAttr);
            // Propiedad del encabezado Nombre de la columna 
            XmlElement NombreColumnaElement = doc.CreateElement(string.Empty, "NombreColumna", string.Empty);

            NombreColumnaElement.InnerText = nombreColumna;

            Propiedad_EncabezadoElement.AppendChild(NombreColumnaElement);
            // Propiedad del encabezado se asigna el valor de la columna 
            XmlElement ValorColumnaElement = doc.CreateElement(string.Empty, "ValorColumna", string.Empty);

            ValorColumnaElement.InnerText = valor;

            Propiedad_EncabezadoElement.AppendChild(ValorColumnaElement);

            return Propiedad_EncabezadoElement;
        }

        private XmlElement CrearPropiedadDetalle(XmlDocument doc, string nombreTablaDetalle, string nombreColumnaDetalle, string valor, int lineas, int numero)
        {
            //Propiedad de detalle Nombre de tabla 
            XmlElement Propiedad_DetalleElement = doc.CreateElement(string.Empty, "Propiedad_Detalle", string.Empty);

            XmlAttribute NombreTablaADetallettr = doc.CreateAttribute("NombreTabla");

            NombreTablaADetallettr.Value = nombreTablaDetalle;

            Propiedad_DetalleElement.Attributes.Append(NombreTablaADetallettr);

            //Nombre de los campos 
            XmlElement NombreColumnaDetalleElement = doc.CreateElement(string.Empty, "NombreColumna", string.Empty);

            NombreColumnaDetalleElement.InnerText = nombreColumnaDetalle;

            Propiedad_DetalleElement.AppendChild(NombreColumnaDetalleElement);

            // Valor del campo 
            XmlElement ValorColumnaElement = doc.CreateElement(string.Empty, "ValorColumna", string.Empty);

            ValorColumnaElement.InnerText = valor;

            Propiedad_DetalleElement.AppendChild(ValorColumnaElement);

            //Lineas afectadas XML
            XmlElement LineasAfectadasElement = doc.CreateElement(string.Empty, "LineasAfectadas", string.Empty);

            LineasAfectadasElement.InnerText = lineas.ToString();

            Propiedad_DetalleElement.AppendChild(LineasAfectadasElement);

            //Numero de linea XML
            XmlElement NumeroLineaElement = doc.CreateElement(string.Empty, "NumeroLinea", string.Empty);

            NumeroLineaElement.InnerText = numero.ToString();

            Propiedad_DetalleElement.AppendChild(NumeroLineaElement);

            return Propiedad_DetalleElement;
        }

        #endregion
    }
}