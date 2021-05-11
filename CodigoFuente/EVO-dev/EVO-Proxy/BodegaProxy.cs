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
    /// Fecha de Creación: 05-Ene/2021
    /// Descripción      : Esta clase implementa los métodos de integración de bodegas entre EVO y SAP.
    /// </summary>
    public class BodegaProxy
    {
        /// <summary>
        /// Obtiene los artículos creados o modificados un día atrás desde SAP
        /// </summary>      
        /// <response>List<BodegaSAP></response>
        public async Task<List<BodegaSAP>> ObtenerIntegracionBodegasSAP()
        {
            WSSincronizacionClient clienteSAP = new WSSincronizacionClient();

            string respuesta = string.Empty;

            List<BodegaSAP> bodegasSAP = new List<BodegaSAP>();

            try
            {
                clienteSAP = new WSSincronizacionClient();

                AppConfiguration appConfig = new AppConfiguration();

                string xml = appConfig.AppSettings["XmlIntegracionBodegasSAP"];

                string baseDatos = appConfig.AppSettings["BaseDatos"];

                string Objeto = appConfig.AppSettings["ObjetoIntegracionBodegasSAP"];

                string Operacion = appConfig.AppSettings["OperacionLectura"];

                xml = string.Format(xml, baseDatos, Objeto, Operacion);

                respuesta = clienteSAP.ConsultarDatosSAPAsync(xml).Result;

                await clienteSAP.CloseAsync();

                List<Dictionary<string, string>> lstRespuesta = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(respuesta);

                if (lstRespuesta.Count == 0)
                {
                   return bodegasSAP;
                }
                
                foreach (var bodegaSAP in lstRespuesta)
                {
                    bodegasSAP.Add(
                        new BodegaSAP()
                        {
                            WhsCode = bodegaSAP["WhsCode"],
                            WhsName = bodegaSAP["WhsName"]
                        }
                        );
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return bodegasSAP;

        }
    }
}
