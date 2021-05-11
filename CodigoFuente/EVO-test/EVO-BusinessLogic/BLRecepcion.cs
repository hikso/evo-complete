using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 19-Mar/2020
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de Recepción
    /// </summary>
    public class BLRecepcion
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        public RecepcionEncabezadoRespuesta ObtenerEncabezadoRecepcion(int entregaId)
        {
            logger.Info($"Entró al método ObtenerEncabezadoRecepcion con el parámetro entregaId = {entregaId}");

            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLEntrega bLEntregas = new BLEntrega();

            BOEntrega bOEntrega = null;

            try
            {
                bOEntrega = bLEntregas.ObtenerEntregaxEntregaId(entregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BOEstadoEntrega bOEstadoEntrega = null;

            try
            {
                bOEstadoEntrega = bLEntregas.ObtenerEstadoEntregaxNombre(EstadosEntregasEnum.En_Tránsito);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            RecepcionEncabezadoRespuesta recepcionEncabezadoRespuesta = new RecepcionEncabezadoRespuesta()
            {
                FechaActual = DateTime.Now.ToString("dd/MM/yyyy"),
                FechaEntrega = bOEntrega.Pedido.FechaEntrega.Value.ToString("dd/MM/yyyy")
            };

            string nombreCliente = string.Empty;

            if (bOEntrega.Pedido.WhsCode.Substring(0, 2) == TiposPrefijoEnum.PV.ToString())
            {
                //Puntos de venta
                BLBodega bLBodegas = new BLBodega();
                BOBodega bodega = null;

                try
                {
                    bodega = bLBodegas.ObtenerBodegaPorCodigo(bOEntrega.Pedido.WhsCode);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

                nombreCliente = bodega.WhsName;

            }
            else
            {
                //Clientes externos
            }

            recepcionEncabezadoRespuesta.NombreCliente = nombreCliente;

            BLPesaje bLPesaje = new BLPesaje();
            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = bLPesaje.ObtenerPesajeEntrega(entregaId, bOEstadoEntrega.EstadoEntregaId);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            recepcionEncabezadoRespuesta.Consecutivo = 0;
            recepcionEncabezadoRespuesta.PesajeEntregaId = null;

            BLClientesParametrizacion bLClientesParametrizacion = new BLClientesParametrizacion();
            BOParametrizacionResponse bOParametrizacionResponse = null;

            try
            {
                bOParametrizacionResponse = bLClientesParametrizacion.ObtenerPatrametrizacionesxCliente(bOEntrega.Pedido.WhsCode);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOParametrizacionResponse.RecepcionPesajeCodigoBarras == null)
            {
                EVOException e = new EVOException(errores.errRecepcionPesajeCodigoBarrasNoInformado);

                logger.Error(e);

                throw e;
            }

            recepcionEncabezadoRespuesta.RealizarPesajeCodigoBarras = bOParametrizacionResponse.RecepcionPesajeCodigoBarras;

            if (bOPesajeEntrega != null)
            {
                recepcionEncabezadoRespuesta.Consecutivo = bOPesajeEntrega.Consecutivo;
                recepcionEncabezadoRespuesta.Finalizado = bOPesajeEntrega.Finalizado;
                recepcionEncabezadoRespuesta.InconsistenciaCodigoBarras = null;
                recepcionEncabezadoRespuesta.Documentos = null;
                recepcionEncabezadoRespuesta.PesajeEntregaId = bOPesajeEntrega.PesajeEntregaId;                

                if (recepcionEncabezadoRespuesta.Finalizado != null && recepcionEncabezadoRespuesta.Finalizado.Value)
                {
                    recepcionEncabezadoRespuesta.InconsistenciaCodigoBarras = bOPesajeEntrega.PesajesArticulo
                        .Where(pa => pa.InconsistenciaCodigoBarras != null && pa.InconsistenciaCodigoBarras.Value)
                        .Count() > 0;

                    recepcionEncabezadoRespuesta.Documentos = bOPesajeEntrega.PesajesArticulo
                        .Select(pa => new BOArticuloDocumentoResponse()
                        {
                            documentoId = pa.DocumentoId.Value,
                            nombreDocumento = pa.Documento.Documento
                        }).Distinct(new BOArticuloDocumentoResponseEqualityComparer()).ToList();
                }

                if (recepcionEncabezadoRespuesta.Documentos!=null)
                {
                    recepcionEncabezadoRespuesta.Documentos =
                    recepcionEncabezadoRespuesta.Documentos
                    .Where(d => d.nombreDocumento != DocumentosEnum.Entrada_de_Mercancía.ToString()
                    .Replace("_", " ")).ToList();
                }             

            }

            return recepcionEncabezadoRespuesta;

        }

        /// <summary>
        /// Confirma que se recibió la mercancia
        /// </summary>
        /// <param name="entregaId">Indica el id de la entrega</param>
        /// <response >BORecepcionResponse</response>
        public BORecepcionResponse AsignarConfirmacion(int entregaId, string userName)
        {
            logger.Info($"Entró al método AsignarConfirmacion con el parámetro entregaId = {entregaId}");

            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(userName))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = userName.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                userName = userName.Substring(nBackSlash + 1, userName.Length - nBackSlash - 1);
            }

            BLUsuario bLUsuarios = new BLUsuario();

            Usuario usuario = null;

            try
            {
                usuario = bLUsuarios.ObtenerUsuarioPorUsuario(userName);
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

            BLEntrega bLEntregas = new BLEntrega();

            BOEntrega bOEntrega = null;

            try
            {
                bOEntrega = bLEntregas.ObtenerEntregaxEntregaId(entregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLClientesParametrizacion bLClientesParametrizacion = new BLClientesParametrizacion();
            BOParametrizacionResponse bOParametrizacionResponse = null;

            try
            {
                bOParametrizacionResponse = bLClientesParametrizacion.ObtenerPatrametrizacionesxCliente(bOEntrega.Pedido.WhsCode);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOParametrizacionResponse.RecepcionPesajeCodigoBarras == null)
            {
                EVOException e = new EVOException(errores.errRecepcionPesajeCodigoBarrasNoInformado);

                logger.Error(e);

                throw e;
            }

            BOEstadoEntrega bOEstadoEntrega = null;

            try
            {
                bOEstadoEntrega = bLEntregas.ObtenerEstadoEntregaxNombre(EstadosEntregasEnum.En_Tránsito);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BLPesaje bLPesaje = new BLPesaje();
            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = bLPesaje.ObtenerPesajeEntrega(entregaId, bOEstadoEntrega.EstadoEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOPesajeEntrega.Finalizado != null && bOPesajeEntrega.Finalizado.Value)
            {
                EVOException e = new EVOException(errores.errRecepcionFinalizada);

                logger.Error(e);

                throw e;
            }

            if (bOPesajeEntrega == null)
            {
                EVOException e = new EVOException(errores.errPesajeEntregaNoRegistrado);

                logger.Error(e);

                throw e;
            }

            List<BODocumentoRecepcionArticulo> documentosRecepcion = new List<BODocumentoRecepcionArticulo>();
            BODocumentoRecepcionArticulo documentoRecepcion = null;

            string respuesta = string.Empty;

            BLDocumento bLDocumento = new BLDocumento();
            BODocumento bODocumento = null;

            List<BOArticuloDocumentoResponse> articulosDocumentosResponse = new List<BOArticuloDocumentoResponse>();
            BOArticuloDocumentoResponse articuloDocumentoResponse = null;

            foreach (BODetalleEntrega bODetalleEntrega in bOEntrega.Detalles)
            {
                documentoRecepcion = new BODocumentoRecepcionArticulo()
                {
                    DetalleEntregaId = bODetalleEntrega.DetalleEntregaId
                };

                articuloDocumentoResponse = new BOArticuloDocumentoResponse();

                BOPesajeArticulo bOPesajeArticulo = bOPesajeEntrega.PesajesArticulo.FirstOrDefault(pa => pa.DetalleEntregaId == bODetalleEntrega.DetalleEntregaId);

                if (bOPesajeArticulo == null)
                {
                    try
                    {
                        bODocumento = bLDocumento.ObtenerDocumentoxNombre(DocumentosEnum.Salida_de_Mercancia_no_Entregada);
                    }
                    catch (EVOException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    articuloDocumentoResponse.documentoId = bODocumento.DocumentoId;
                    articuloDocumentoResponse.nombreDocumento = bODocumento.Documento;
                    articulosDocumentosResponse.Add(articuloDocumentoResponse);

                    documentoRecepcion.DocumentoId = bODocumento.DocumentoId;
                    documentosRecepcion.Add(documentoRecepcion);

                }
                else if (bOPesajeArticulo.CantidadRecibida < bODetalleEntrega.DetallePedido.CantidadAprobada.Value)
                {
                    //TODO: Luego será la cantidad que sale en despacho , por el momento es cantidad aprobada
                    try
                    {
                        bODocumento = bLDocumento.ObtenerDocumentoxNombre(DocumentosEnum.Salida_de_Mercancia_no_Entregada);
                    }
                    catch (EVOException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    articuloDocumentoResponse.documentoId = bODocumento.DocumentoId;
                    articuloDocumentoResponse.nombreDocumento = bODocumento.Documento;
                    articulosDocumentosResponse.Add(articuloDocumentoResponse);

                    documentoRecepcion.DocumentoId = bODocumento.DocumentoId;
                    documentosRecepcion.Add(documentoRecepcion);

                }
                else if (bOPesajeArticulo.CantidadRecibida > bODetalleEntrega.DetallePedido.CantidadAprobada.Value)
                {

                    try
                    {
                        bODocumento = bLDocumento.ObtenerDocumentoxNombre(DocumentosEnum.Entrada_de_Mercancia_en_Exceso);
                    }
                    catch (EVOException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    articuloDocumentoResponse.documentoId = bODocumento.DocumentoId;
                    articuloDocumentoResponse.nombreDocumento = bODocumento.Documento;
                    articulosDocumentosResponse.Add(articuloDocumentoResponse);

                    documentoRecepcion.DocumentoId = bODocumento.DocumentoId;
                    documentosRecepcion.Add(documentoRecepcion);

                }
                else
                {
                    try
                    {
                        bODocumento = bLDocumento.ObtenerDocumentoxNombre(DocumentosEnum.Entrada_de_Mercancía);
                    }
                    catch (EVOException e)
                    {
                        throw e;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }

                    documentoRecepcion.DocumentoId = bODocumento.DocumentoId;
                    documentosRecepcion.Add(documentoRecepcion);

                }

            }

            DARecepcion dARecepcion = new DARecepcion();

            BORecepcionResponse bORecepcionResponse = new BORecepcionResponse()
            {
                InconsistenciaCodigoBarras = bOPesajeEntrega.PesajesArticulo.Where(pa => pa.InconsistenciaCodigoBarras != null && pa.InconsistenciaCodigoBarras.Value).Count() > 0,
                Documentos = articulosDocumentosResponse.Distinct(new BOArticuloDocumentoResponseEqualityComparer()).ToList()
            };

            BLContenedor bLContenedor = new BLContenedor();
            BOTipoContenedorRespuesta tipoBase = null;

            try
            {
                tipoBase = bLContenedor.ObtenerTipoContenedorxNombre(TiposContenedorEnum.Base);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOParametrizacionResponse.RecepcionPesajeCodigoBarras.Value == false)
            {
                try
                {
                    dARecepcion.AsignarConfirmacion(bOPesajeEntrega.PesajeEntregaId, documentosRecepcion, usuario.UsuarioId);
                }
                catch (Exception e)
                {
                    throw e;
                }

                return bORecepcionResponse;
            }

            foreach (BOPesajeArticulo pesajeArticulo in bOPesajeEntrega.PesajesArticulo)
            {
                if (pesajeArticulo.Pesajes == null)
                {
                    continue;
                }

                foreach (BOPesaje pesaje in pesajeArticulo.Pesajes)
                {
                    int cantidadCodigosBarras = pesaje.PesajesCodigoBarras.Count;

                    if (cantidadCodigosBarras > 0)
                    {
                        int cantidadContenedores = pesaje.PesajeContenedor
                            .Where(pc => pc.TipoContenedorId != tipoBase.TipoContenedorId)
                            .Select(pc => pc.Cantidad).Sum();

                        if (cantidadCodigosBarras < cantidadContenedores)
                        {
                            bORecepcionResponse.InconsistenciaCodigoBarras = true;

                            try
                            {
                                bLPesaje.ActualizarInconsistenciaCodigoBarras(pesaje.PesajeArticuloId, true);
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
                    }
                    else
                    {
                        try
                        {
                            bLPesaje.ActualizarInconsistenciaCodigoBarras(pesaje.PesajeArticuloId, true);
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
                }
            }

            try
            {
                dARecepcion.AsignarConfirmacion(bOPesajeEntrega.PesajeEntregaId, documentosRecepcion, usuario.UsuarioId);
            }
            catch (Exception e)
            {
                throw e;
            }

            BLInventario bLInventario = new BLInventario();
         
            bLInventario.AsignarEntradaRecepcion(bOPesajeEntrega.PesajesArticulo.Select(pa=>pa.PesajeArticuloId).ToList());

            //TODO:aumentar los stock en el punto de venta           

            return bORecepcionResponse;

        }

        #endregion
    }
}
