using EVO_BusinessObjects;
using EVO_Proxy.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WSServiceSincronizacion;


namespace EVO_Proxy
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 28-Ago/2020
    /// Descripción      : Esta clase implementa los métodos de integración de artículo entre EVO y SAP.
    /// </summary>
    public class ArticuloProxy
    {
        /// <summary>
        /// Este método se encarga de enviar un pedido a SAP
        /// </summary>
        /// <param name="pedido">Datos del pedido</param>
        /// <Response>BOArticuloBodegaSAP</Response>
        public BOArticuloBodegaSAP ObtenerArticuloxBodegaSAP(string codigoArticulo, string codigoBodega)
        {
            WSSincronizacionClient clienteSAP = new WSSincronizacionClient();

            string respuesta = string.Empty;

            AppConfiguration appConfig = new AppConfiguration();

            string xml = appConfig.AppSettings["XmlArticulosSAP"];

            string baseDatos = appConfig.AppSettings["BaseDatos"];

            string Objeto = appConfig.AppSettings["ObjetoArticulosSAP"];

            string Operacion = appConfig.AppSettings["OperacionLectura"];

            xml = string.Format(xml, baseDatos, Objeto, Operacion, codigoArticulo, codigoBodega);

            try
            {
                respuesta = clienteSAP.ConsultarDatosSAPAsync(xml).Result;
            }
            catch (Exception e)
            {
                throw e;
            }

            clienteSAP.CloseAsync();

            if (respuesta == "Se ha generado una excepción genèrica controlada por la aplicación")
            {
                return null;
            }

            List<Dictionary<string, string>> lstRespuesta = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(respuesta);

            if (lstRespuesta.Count == 0)
            {
                return null;
            }

            return new BOArticuloBodegaSAP()
            {
                Stock = Convert.ToDecimal(lstRespuesta[0]["Stock"])
            };

        }

        /// <summary>
        /// Obtiene las ordenes de compra generadas en SAP
        /// </summary>      
        // <param >
        /// <response>List<BOGestionCompra></response>
        public async Task<List<BOGestionCompra>> ObtenerOrdenesCompraSAP(string documento)
        {
            WSSincronizacionClient clienteSAP = new WSSincronizacionClient();

            string respuesta = string.Empty;

            List<BOGestionCompra> ordenesCompra = null;

            try
            {
                clienteSAP = new WSSincronizacionClient();

                AppConfiguration appConfig = new AppConfiguration();

                string xml = appConfig.AppSettings["XmlOrdenesSAP"];

                string baseDatos = appConfig.AppSettings["BaseDatos"];

                string Objeto = appConfig.AppSettings["ObjetoOrdenesSAP"];

                string Operacion = appConfig.AppSettings["OperacionLectura"];

                xml = string.Format(xml, baseDatos, Objeto, Operacion, documento);

                respuesta = clienteSAP.ConsultarDatosSAPAsync(xml).Result;

                await clienteSAP.CloseAsync();

                List<Dictionary<string, string>> lstRespuesta = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(respuesta);

                if (lstRespuesta.Count == 0)
                {
                    return ordenesCompra;
                }

                ordenesCompra = new List<BOGestionCompra>();

                foreach (var gestionCompra in lstRespuesta)
                {
                    ordenesCompra.Add(
                        new BOGestionCompra()
                        {
                            OrdenCompra = gestionCompra["DocNum"],
                            CodigoArticulo = gestionCompra["OrdenCompra"]
                        }
                        );
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return ordenesCompra;

        }

        /// <summary>
        /// Obtiene los artículos creados o modificados un día atrás desde SAP
        /// </summary>      
        /// <response>List<ArticuloSAP></response>
        public async Task<List<ArticuloSAP>> ObtenerIntegracionArticulosSAP()
        {
            WSSincronizacionClient clienteSAP = new WSSincronizacionClient();

            string respuesta = string.Empty;

            List<ArticuloSAP> articulosSAP = new List<ArticuloSAP>();

            try
            {
                clienteSAP = new WSSincronizacionClient();

                AppConfiguration appConfig = new AppConfiguration();

                string xml = appConfig.AppSettings["XmlIntegracionArticulosSAP"];

                string baseDatos = appConfig.AppSettings["BaseDatos"];

                string Objeto = appConfig.AppSettings["ObjetoIntegracionArticulosSAP"];

                string Operacion = appConfig.AppSettings["OperacionLectura"];

                xml = string.Format(xml, baseDatos, Objeto, Operacion);

                respuesta = clienteSAP.ConsultarDatosSAPAsync(xml).Result;

                await clienteSAP.CloseAsync();

                List<Dictionary<string, string>> lstRespuesta = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(respuesta);

                if (lstRespuesta.Count == 0)
                {
                    return articulosSAP;
                }

                foreach (var articuloSAP in lstRespuesta)
                {
                    articulosSAP.Add(
                        new ArticuloSAP()
                        {
                            ItemCode = articuloSAP["ItemCode"],
                            ItemName = articuloSAP["ItemName"],
                            SalUnitMsr = articuloSAP["SalUnitMsr"]
                        }
                        );
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return articulosSAP;

        }

        /// <summary>
        /// Obtiene los artículos asociados a las bodegas un día atrás desde SAP
        /// </summary>      
        /// <response>List<ArticuloBodegaSAP></response>
        public async Task<List<ArticuloBodegaSAP>> ObtenerIntegracionArticulosBodegasSAP()
        {
            WSSincronizacionClient clienteSAP = new WSSincronizacionClient();

            string respuesta = string.Empty;

            List<ArticuloBodegaSAP> articulosBodegasSAP = null;

            try
            {
                clienteSAP = new WSSincronizacionClient();

                AppConfiguration appConfig = new AppConfiguration();

                string xml = appConfig.AppSettings["XmlIntegracionArticulosBodegasSAP"];

                string baseDatos = appConfig.AppSettings["BaseDatos"];

                string Objeto = appConfig.AppSettings["ObjetoIntegracionArticulosBodegasSAP"];

                string Operacion = appConfig.AppSettings["OperacionLectura"];

                xml = string.Format(xml, baseDatos, Objeto, Operacion);

                respuesta = clienteSAP.ConsultarDatosSAPAsync(xml).Result;

                await clienteSAP.CloseAsync();

                List<Dictionary<string, string>> lstRespuesta = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(respuesta);

                if (lstRespuesta.Count == 0)
                {
                    return articulosBodegasSAP;
                }

                articulosBodegasSAP = new List<ArticuloBodegaSAP>();

                foreach (var articuloBodegaSAP in lstRespuesta)
                {
                    articulosBodegasSAP.Add(
                        new ArticuloBodegaSAP()
                        {
                            ArticuloSAP = new ArticuloSAP() { ItemCode = articuloBodegaSAP["ItemCode"] },
                            BodegaSAP = new BodegaSAP() { WhsCode = articuloBodegaSAP["WhsCode"] },
                            OnHand = articuloBodegaSAP["OnHand"],
                            MinStock = articuloBodegaSAP["MinStock"],
                            MaxStock = articuloBodegaSAP["MaxStock"]
                        }
                        );
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return articulosBodegasSAP;

        }
    }
}
