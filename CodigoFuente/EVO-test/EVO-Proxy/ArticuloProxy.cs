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
        public BOArticuloBodegaSAP ObtenerArticuloxBodegaSAP(string codigoArticulo, string  codigoBodega)
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
    }
}
