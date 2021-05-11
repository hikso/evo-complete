//using EVO_BusinessObjects;
//using System;
//using WSServiceSincronizacion;

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
    /// Fecha de Creación: 14-Sep/2020
    /// Descripción      : Esta clase implementa los métodos de integración de pedido entre EVO y SAP.
    /// </summary>
    public class PedidoProxy
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método se encarga de enviar un pedido a SAP
        /// </summary>
        /// <param name="xml">Xml del pedido</param>
        public string EnviarPedido(string xml)
        {
            try { 
            WSSincronizacionClient clienteSAP = new WSSincronizacionClient();
            var respuesta = clienteSAP.EnviarDatosSAPAsync(xml).Result;
            return respuesta;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Este método se encarga de enviar un pedido a SAP
        /// </summary>
        /// <param name="baseDatos">Nombre base datos</param>
        /// <param name="nombreMetodo">Nombre del método</param>
        public List<SerieRespuesta> ObtenerSeriesSAP()
        {
            WSSincronizacionClient clienteSAP = null;

            List<SerieRespuesta> series = null;

            string respuesta = string.Empty;

            try
            {
                clienteSAP = new WSSincronizacionClient();

                AppConfiguration appConfig = new AppConfiguration();

                string xml = appConfig.AppSettings["XmlSeriesSAP"];

                string baseDatos = appConfig.AppSettings["BaseDatos"];

                string Objeto = appConfig.AppSettings["ObjetoSeriesSAP"];

                string Operacion = appConfig.AppSettings["OperacionLectura"];

                xml = string.Format(xml, baseDatos, Objeto, Operacion);

                respuesta = clienteSAP.ConsultarDatosSAPAsync(xml).Result;

                clienteSAP.CloseAsync();

                if (respuesta.Contains("No se puede ejecutar la consulta"))
                {
                    return series;
                }

                List<Dictionary<string, string>> lstRespuesta = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(respuesta);

                if (lstRespuesta.Count == 0)
                {
                    return series;
                }

                series = new List<SerieRespuesta>();

                foreach (var serie in lstRespuesta)
                {
                    series.Add(
                        new SerieRespuesta()
                        {
                            Series = serie["Series"],
                            SeriesName = serie["SeriesName"],
                            InitialNum = serie["InitialNum"],
                            NextNumber = serie["NextNumber"],
                            LastNum = serie["LastNum"],
                            Activo = true
                        }
                        );
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return series;

        }
        #endregion
    }
}
