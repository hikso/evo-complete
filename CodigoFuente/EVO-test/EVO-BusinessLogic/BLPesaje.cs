using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_BusinessLogic
{
    public class BLPesaje
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene la entrega asociada al pesaje
        /// </summary>
        /// <param name="pesajeEntregaId">Indica el id de la entrega del pesaje</param>      
        /// <response>BOPesajeEntrega</response>
        public BOPesajeEntrega ObtenerPesajeEntrega(int pesajeEntregaId)
        {
            if (pesajeEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerPesajeEntrega en BlPesaje con el parámetro pesajeEntregaId = {pesajeEntregaId}");

            DAPesaje dAPesaje = new DAPesaje();

            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = dAPesaje.ObtenerPesajeEntrega(pesajeEntregaId);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            if (bOPesajeEntrega == null)
            {
                EVOException e = new EVOException(errores.errPesajeEntregaNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return bOPesajeEntrega;

        }


        /// <summary>
        /// Obtiene el objeto a pesar
        /// </summary>
        /// <param name="pesajeArticuloId">Indica el id del artículo en pesaje</param>      
        /// <response>BOPesajeArticulo</response>
        public BOPesajeArticulo ObtenerPesajeArticulo(int pesajeArticuloId)
        {
            if (pesajeArticuloId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeArticuloIdNoInformado);

                logger.Error(e);

                throw e;
            }           

            logger.Info($"Entró al método ObtenerPesajeArticulo en BlPesaje con el parámetro pesajeArticuloId = {pesajeArticuloId}");

            DAPesaje dAPesaje = new DAPesaje();

            BOPesajeArticulo bOPesajeArticulo = null;

            try
            {
                bOPesajeArticulo = dAPesaje.ObtenerPesajeArticulo(pesajeArticuloId);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            if (bOPesajeArticulo==null)
            {
                EVOException e = new EVOException(errores.errPesajeArticuloNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return bOPesajeArticulo;

        }

        /// <summary>
        /// Obtiene todos los pesajes de la entrega en un estado en concreto
        /// </summary>
        /// <param name="entregaId">Indica el id de la entrega</param>
        /// <param name="estadoEntregaId">Indica el id del estado de la entrega</param>
        /// <response>BOPesajeEntrega</response>
        public BOPesajeEntrega ObtenerPesajeEntrega(int entregaId, int estadoEntregaId)
        {
            if (entregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (estadoEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEstadoEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerPesajeEntrega en BlPesaje con el parámetro entregaId = {entregaId} , estadoEntregaId = {estadoEntregaId}");

            DAPesaje dAPesaje = new DAPesaje();

            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = dAPesaje.ObtenerPesajeEntrega(entregaId, estadoEntregaId);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            return bOPesajeEntrega;

        }

        /// <summary>
        /// Obtiene el pesaje por id
        /// </summary>
        /// <param name="pesajeId">1</param>
        /// <response>BOPesajeEntrega</response>
        public BOPesaje ObtenerPesaje(int pesajeId)
        {
            if (pesajeId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeIdNoInformado);

                logger.Error(e);

                throw e;
            }           

            logger.Info($"Entró al método ObtenerPesaje en BlPesaje con el parámetro pesajeId = {pesajeId}");

            DAPesaje dAPesaje = new DAPesaje();

            BOPesaje bOPesaje = null;

            try
            {
                bOPesaje = dAPesaje.ObtenerPesaje(pesajeId);
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            if (bOPesaje==null)
            {
                EVOException e = new EVOException(errores.errPesajeNORegistrado);

                logger.Error(e);

                throw e;
            }

            return bOPesaje;

        }

        /// <summary>
        /// Registra un pesaje en recepción
        /// </summary>
        /// <param name="body">Solicitud para el registro del pesaje</param>
        /// <response>PesajeArticuloId</response>
        public int AsignarPesajeRecepcion(BOPesajeRequest bOPesajeRequest)
        {
            if (bOPesajeRequest == null)
            {
                EVOException e = new EVOException(errores.errPesajeRequestNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método AsignarPesajeRecepcion en BLPesaje con los parámetros {JsonConvert.SerializeObject(bOPesajeRequest)}");

            if (string.IsNullOrEmpty(bOPesajeRequest.CodigoArticulo))
            {
                EVOException e = new EVOException(errores.errCodigoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            BLArticulo bLArticulo = new BLArticulo();

            BOArticulo bOArticulo = null;

            try
            {
                bOArticulo = bLArticulo.ObtenerArticuloxCodigo(bOPesajeRequest.CodigoArticulo);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOArticulo.SalUnitMsr == UnidadesMedidaEnum.UND.ToString())
            {
                EVOException e = new EVOException(errores.errMedidaUnidadNoPesable);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOPesajeRequest.Usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = bOPesajeRequest.Usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                bOPesajeRequest.Usuario = bOPesajeRequest.Usuario.Substring(nBackSlash + 1, bOPesajeRequest.Usuario.Length - nBackSlash - 1);
            }

            BLUsuario bLUsuarios = new BLUsuario();

            Usuario usuario = null;

            try
            {
                usuario = bLUsuarios.ObtenerUsuarioPorUsuario(bOPesajeRequest.Usuario);
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

            bOPesajeRequest.UsuarioId = usuario.UsuarioId;

            if (bOPesajeRequest.EntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (bOPesajeRequest.DetalleEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errDetalleEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (bOPesajeRequest.PesoArticulo <= 0)
            {
                EVOException e = new EVOException(errores.errPesoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            if (bOPesajeRequest.PesoArticulo > bOPesajeRequest.PesoBascula)
            {
                EVOException e = new EVOException(errores.errPesoArticuloSuperiorBascula);

                logger.Error(e);

                throw e;
            }

            if (bOPesajeRequest.PesoBascula < 0)
            {
                EVOException e = new EVOException(errores.errPesoBasculaNoInformado);

                logger.Error(e);

                throw e;
            }

            BLContenedor blContenedor = new BLContenedor();

            //BOTipoContenedorRespuesta bOTipoContenedorRespuesta = null;

            //try
            //{
            //    bOTipoContenedorRespuesta = blContenedor.ObtenerTipoContenedorxNombre(TiposContenedorEnum.Base);
            //}
            //catch (EVOException e)
            //{
            //    throw e;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}

            //if (bOPesajeRequest.Contenedores.Where(c => c.TipoContenedorId == bOTipoContenedorRespuesta.TipoContenedorId)
            //    .Count() == 0)
            //{
            //    EVOException e = new EVOException(errores.errContenedorBaseNoInformado);

            //    logger.Error(e);

            //    throw e;
            //}

            //if (bOPesajeRequest.Contenedores.Count==1)
            //{
            //    EVOException e = new EVOException(errores.errContenedoresNoBaseNoInformados);

            //    logger.Error(e);

            //    throw e;
            //}            
            
            if (bOPesajeRequest.PesajeAl==PesajeAlEnum.Cinco && bOPesajeRequest.Contenedores.Count > 6)
            {
                Exception e = new Exception(errores.errPesajeAlCinco);

                logger.Error(e);

                throw e;
            }

            if (bOPesajeRequest.PesajeAl == PesajeAlEnum.Ocho && bOPesajeRequest.Contenedores.Count > 9)
            {
                Exception e = new Exception(errores.errPesajeALOcho);

                logger.Error(e);

                throw e;
            }

            List<BOTipoContenedorRespuesta> bOTiposContenedorRespuestas = null;

            try
            {
                bOTiposContenedorRespuestas = blContenedor.ObtenerTipoContenedores();
            }
            catch (Exception e)
            {
                throw e;
            }

            decimal pesoContenedores = 0;

            foreach (BOContenedorRequest bOContenedorRequest in bOPesajeRequest.Contenedores)
            {
                if (bOContenedorRequest.TipoContenedorId <= 0)
                {
                    EVOException e = new EVOException(errores.errTipoContenedorNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (bOContenedorRequest.Cantidad <= 0)
                {
                    EVOException e = new EVOException(errores.errCantidadContenedoresNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (bOPesajeRequest.Contenedores
                    .Where(c => c.TipoContenedorId == bOContenedorRequest.TipoContenedorId).Count() >= 2)
                {
                    EVOException e = new EVOException(errores.errTipoContenedorIdDuplicado);

                    logger.Error(e);

                    throw e;
                }

                pesoContenedores += (bOContenedorRequest.Cantidad *
                    bOTiposContenedorRespuestas.FirstOrDefault(c => c.TipoContenedorId == bOContenedorRequest.TipoContenedorId).Peso);

            }

            decimal pesoMenosContenedores = decimal.Parse(string.Format("{0:#,0.000}", bOPesajeRequest.PesoBascula - pesoContenedores));

            //TODO:Válidar luego si se ingresa una ingresando tolerancia pesaje back y front
            
            //if ((pesoMenosContenedores) != bOPesajeRequest.PesoArticulo)
            //{
            //    EVOException e = new EVOException(errores.errPesoArticuloMalCalculado);

            //    logger.Error(e);

            //    throw e;
            //}

            //try
            //{
            //    bOTipoContenedorRespuesta = blContenedor.ObtenerTipoContenedorxNombre(TiposContenedorEnum.Bin);
            //}
            //catch (EVOException e)
            //{
            //    throw e;
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}

            //if (bOPesajeRequest.Contenedores.Where(c => c.TipoContenedorId == bOTipoContenedorRespuesta.TipoContenedorId)
            //   .Count() == 1)
            //{               
            //    if (bOPesajeRequest.Contenedores.Count() >= 3)
            //    {
            //        EVOException e = new EVOException(errores.errBaseBinSoloLosdos);

            //        logger.Error(e);

            //        throw e;
            //    }

            //}           

            BLEntrega bLEntrega = new BLEntrega();
            BOEstadoEntrega bOEstadoEntrega = null;

            try
            {
                bOEstadoEntrega = bLEntrega.ObtenerEstadoEntregaxNombre(EstadosEntregasEnum.En_Tránsito);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = ObtenerPesajeEntrega(bOPesajeRequest.EntregaId,bOEstadoEntrega.EstadoEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BlBascula blBascula = new BlBascula();
            BOTipoBascula bOTipoBascula = null;
            
            try
            {
                bOTipoBascula = blBascula.ObtenerTipoBasculaxNombre(TiposBasculaEnum.Piso);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            bOPesajeRequest.TipoBasculaId = bOTipoBascula.TipoBasculaId;

            DAPesaje dAPesaje = new DAPesaje();
            
            if (bOPesajeEntrega==null)
            {
                try
                {
                    AsignarPesajeEntrega(bOPesajeRequest.EntregaId, bOEstadoEntrega.EstadoEntregaId);
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
                    bOPesajeEntrega = ObtenerPesajeEntrega(bOPesajeRequest.EntregaId, bOEstadoEntrega.EstadoEntregaId);
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
                    AsignarPesajeArticulo(bOPesajeEntrega.PesajeEntregaId,bOPesajeRequest.DetalleEntregaId, bOPesajeRequest.PesoArticulo, bOPesajeRequest.UsuarioId);
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
                    bOPesajeEntrega = ObtenerPesajeEntrega(bOPesajeRequest.EntregaId, bOEstadoEntrega.EstadoEntregaId);
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
            else if (bOPesajeEntrega.PesajesArticulo.Where(pa => pa.DetalleEntregaId == bOPesajeRequest.DetalleEntregaId).Count() == 0)
            {              
                 try
                 {
                     AsignarPesajeArticulo(bOPesajeEntrega.PesajeEntregaId, bOPesajeRequest.DetalleEntregaId, bOPesajeRequest.PesoArticulo, bOPesajeRequest.UsuarioId);
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
                     bOPesajeEntrega = ObtenerPesajeEntrega(bOPesajeRequest.EntregaId, bOEstadoEntrega.EstadoEntregaId);
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

            bOPesajeRequest.PesajeArticuloId = bOPesajeEntrega.PesajesArticulo.FirstOrDefault(pa=>pa.DetalleEntregaId == bOPesajeRequest.DetalleEntregaId).PesajeArticuloId;

            bOPesajeRequest.FechaPesaje = DateTime.Now;

            try
            {
                 dAPesaje.AsignarPesajeRecepcion(bOPesajeRequest);
            }
            catch (Exception e)
            {
                throw e;
            }          

            return bOPesajeRequest.PesajeArticuloId;

        }

        /// <summary>
        /// Obtiene los pesajes de un artículo en recepción
        /// </summary>
        /// <param name="pesajeArticuloId">Indica el id del artículo en el pesaje</param>
        /// <response >List<BOPesaje></response>
        public List<BOPesaje> ObtenerPesajesRecepcion(int pesajeArticuloId)
        {
            if (pesajeArticuloId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeArticuloIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerPesajesRecepcion con el parámetro: pesajeArticuloId: {pesajeArticuloId}");

            BOPesajeArticulo bOPesajeArticulo = null;

            try
            {
                bOPesajeArticulo = ObtenerPesajeArticulo(pesajeArticuloId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            return bOPesajeArticulo.Pesajes;


        }

        /// <summary>
        /// Registra la cantidad recibida en recepción de artículos de unidad de medida tipo unidad.
        /// </summary>
        /// <param name="bOCantidadRecibidaRequest">BOCantidadRecibidaRequest</param>       
        /// <response >bool</response>
        public bool AsignarCantidadRecibida(BOCantidadRecibidaRequest bOCantidadRecibidaRequest)
        {
            if (bOCantidadRecibidaRequest==null)
            {
                EVOException e = new EVOException(errores.errbOCantidadRecibidaRequestNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método AsignarCantidadRecibida en BlPesaje con los parámetros {bOCantidadRecibidaRequest}");

            if (bOCantidadRecibidaRequest.EntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (bOCantidadRecibidaRequest.DetalleEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errDetalleEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }          

            if (bOCantidadRecibidaRequest.CantidadRecibida <= 0)
            {
                EVOException e = new EVOException(errores.errCantidadRecibidaNoInformada);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(bOCantidadRecibidaRequest.Usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = bOCantidadRecibidaRequest.Usuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                bOCantidadRecibidaRequest.Usuario = bOCantidadRecibidaRequest.Usuario.Substring(nBackSlash + 1, bOCantidadRecibidaRequest.Usuario.Length - nBackSlash - 1);
            }

            BLUsuario bLUsuarios = new BLUsuario();

            Usuario usuario = null;

            try
            {
                usuario = bLUsuarios.ObtenerUsuarioPorUsuario(bOCantidadRecibidaRequest.Usuario);
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

            bOCantidadRecibidaRequest.UsuarioId = usuario.UsuarioId;           

            if (string.IsNullOrEmpty(bOCantidadRecibidaRequest.CodigoArticulo))
            {
                EVOException e = new EVOException(errores.codigoArticuloNoInformado);

                logger.Error(e);

                throw e;
            }

            BLArticulo bLArticulo = new BLArticulo();
            BOArticulo bOArticulo = null;

            try
            {
                bOArticulo = bLArticulo.ObtenerArticuloxCodigo(bOCantidadRecibidaRequest.CodigoArticulo);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }           

            if (bOArticulo.SalUnitMsr != UnidadesMedidaEnum.UND.ToString())
            {
                EVOException e = new EVOException(errores.errSoloUnidadMedidaUnidad);

                logger.Error(e);

                throw e;
            }

            BLEntrega bLEntrega = new BLEntrega();
            BOEstadoEntrega bOEstadoEntrega = null;

            try
            {
                bOEstadoEntrega = bLEntrega.ObtenerEstadoEntregaxNombre(EstadosEntregasEnum.En_Tránsito);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = ObtenerPesajeEntrega(bOCantidadRecibidaRequest.EntregaId, bOEstadoEntrega.EstadoEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (bOPesajeEntrega == null)
            {
                try
                {
                    AsignarPesajeEntrega(bOCantidadRecibidaRequest.EntregaId, bOEstadoEntrega.EstadoEntregaId);
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
                    bOPesajeEntrega = ObtenerPesajeEntrega(bOCantidadRecibidaRequest.EntregaId, bOEstadoEntrega.EstadoEntregaId);
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
                    AsignarPesajeArticulo(bOPesajeEntrega.PesajeEntregaId, bOCantidadRecibidaRequest.DetalleEntregaId, bOCantidadRecibidaRequest.CantidadRecibida, bOCantidadRecibidaRequest.UsuarioId);
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
            else
            {                
                try
                {
                    AsignarPesajeArticulo(bOPesajeEntrega.PesajeEntregaId, bOCantidadRecibidaRequest.DetalleEntregaId, bOCantidadRecibidaRequest.CantidadRecibida, bOCantidadRecibidaRequest.UsuarioId);
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

            return true;

        }

        /// <summary>
        /// Registra un pesaje artículo
        /// </summary>
        /// <param name="pesajeEntregaId">Id del pesaje entrega</param>
        /// <param name="detalleEntregaId">Id del detalle de la entrega</param>
        /// <response>bool</response>
        private bool AsignarPesajeArticulo(int pesajeEntregaId, int detalleEntregaId,decimal cantidadRecibida,int usuarioId)
        {
            logger.Info($"Entró al método AsignarPesajeArticulo en BLPesaje con los parámetros pesajeEntregaId = {pesajeEntregaId} , detalleEntregaId = {detalleEntregaId} , cantidadRecibida = {cantidadRecibida}");

            if (pesajeEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BOPesajeEntrega bOPesajeEntrega = null;

            try
            {
                bOPesajeEntrega = ObtenerPesajeEntrega(pesajeEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (detalleEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errDetalleEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BLEntrega bLEntrega = new BLEntrega();
            DetalleEntrega detalleEntrega = null;

            try
            {
                detalleEntrega = bLEntrega.ObtenerDetalleEntregaxId(detalleEntregaId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (cantidadRecibida < 0)
            {
                EVOException e = new EVOException(errores.errCantidadRecibidaNoInformada);

                logger.Error(e);

                throw e;
            }

            if (usuarioId <= 0)
            {
                EVOException e = new EVOException(errores.errUsuarioIdNoInformado);

                logger.Error(e);

                throw e;
            }

            //TODO: Validar usuario por ID

            DAPesaje dAPesaje = new DAPesaje();

            bool respuesta = false;

            try
            {
                respuesta = dAPesaje.AsignarPesajeArticulo(pesajeEntregaId,detalleEntregaId,cantidadRecibida, usuarioId);
            }
            catch (Exception e)
            {
                throw e;
            }

            return respuesta;
        }

        /// <summary>
        /// Registra un pesaje entrega
        /// </summary>
        /// <param name="entregaId">Id de la entrega</param>
        /// <param name="estadoEntregaId">Id del estado de la entrega</param>
        /// <response>bool</response>
        public bool AsignarPesajeEntrega(int entregaId,int estadoEntregaId)
        {
            logger.Info($"Entró al método AsignarPesajeEntrega en BLPesaje con los parámetros entregaId = {entregaId} , estadoEntregaId = {estadoEntregaId}");

            if (entregaId < 0)
            {
                EVOException e = new EVOException(errores.errEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            if (estadoEntregaId < 0)
            {
                EVOException e = new EVOException(errores.errEstadoEntregaIdNoInformado);

                logger.Error(e);

                throw e;
            }

            DAPesaje dAPesaje = new DAPesaje();

            bool respuesta = false;

            try
            {
              respuesta= dAPesaje.AsignarPesajeEntrega(entregaId, estadoEntregaId);
            }
            catch (Exception e)
            {
                throw e;
            }

            return respuesta;

        }

        /// <summary>
        /// Actualiza un pesaje artículo con la inconsistencia
        /// </summary>
        /// <param name="pesajeArticuloId">id del artículo asociado al pesaje</param>
        /// <param name="inconsistencia">indica si existe inconsistencia en el pesaje</param>
        /// <response>bool</response>
        public bool ActualizarInconsistenciaCodigoBarras(int pesajeArticuloId,bool inconsistencia)
        {           

            logger.Info($"Entró al método ActualizarPesajeArticulo en BLPesaje con los parámetros pesajeArticuloId = {pesajeArticuloId} , inconsistencia = {inconsistencia} ");

            if (pesajeArticuloId <= 0)
            {
                EVOException e = new EVOException(errores.errPesajeArticuloIdNoInformado);

                logger.Error(e);

                throw e;
            }

            BOPesajeArticulo bOPesajeArticuloEncontar = null;

            try
            {
                bOPesajeArticuloEncontar = ObtenerPesajeArticulo(pesajeArticuloId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }          

            DAPesaje dAPesaje = new DAPesaje();

            bool respuesta = false;

            try
            {
                respuesta = dAPesaje.ActualizarInconsistenciaCodigoBarras(pesajeArticuloId, inconsistencia);
            }
            catch (Exception e)
            {
                throw e;
            }

            return respuesta;
        }

        #endregion
    }
}
