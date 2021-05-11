using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Models.RecepcionApi;
using EVO_PV.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    public class InconsistenciesService : Mapper
    {

        #region Métodos Públicos

        /// <summary>
        /// Obtiene una lista de inconsistencia
        /// </summary>
        /// <returns>Objeto de negocio con la lista inconsistencia</returns>
        public async Task<List<BOInconsistence>> GetInconsistencies()
        {
            List<BOInconsistence> lstInconsistencies = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    Uri url = new Uri($"{ConfigurationManager.AppSettings["API_EVO"]}evidencia/evidencias");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<InconsistenciaResponse> response = JsonConvert.DeserializeObject<List<InconsistenciaResponse>>(HtmlResult);
                    lstInconsistencies = this.mapper.Map<List<InconsistenciaResponse>, List<BOInconsistence>>(response);

                    return lstInconsistencies;
                }
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

        /// <summary>
        /// Obtiene una lista de inconsistencia
        /// </summary>
        /// <returns>Objeto de negocio con la lista inconsistencia</returns>
        public async Task<List<BOInconsistence>> GetInconsistencies(string startDate, string endDate, string salePoint)
        {
            List<BOInconsistence> lstInconsistencies = null;
            try
            {
                using (WebClient client = new WebClient())
                {
                    Uri url = new Uri($"{ConfigurationManager.AppSettings["API_EVO"]}evidencia/evidencias/filtrar?fechaInicio={startDate}&fechaFin={endDate}&puntoVenta={salePoint}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    List<InconsistenciaResponse> response = JsonConvert.DeserializeObject<List<InconsistenciaResponse>>(HtmlResult);
                    lstInconsistencies = this.mapper.Map<List<InconsistenciaResponse>, List<BOInconsistence>>(response);

                    return lstInconsistencies;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene el detalle de una inconsistencia por id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Objeto de negocio Con el detalle de una inconsistencia</returns>
        public async Task<BOInconsistenceDetail> GetInconsistenceById(int id, string requestNumber)
        {
            BOInconsistenceDetail inconsistence = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    Uri url = new Uri($"{ConfigurationManager.AppSettings["API_EVO"]}evidencia/detalle?evidenciaId={id}&numeroEntrega={requestNumber}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    InconsistenciaDetailResponse response = JsonConvert.DeserializeObject<InconsistenciaDetailResponse>(HtmlResult);
                    inconsistence = this.mapper.Map<InconsistenciaDetailResponse, BOInconsistenceDetail>(response);

                    return inconsistence;
                }
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

        /// <summary>
        /// Obtiene un documento por Id de una inconsistencia
        /// </summary>
        /// <returns>Objeto de negocio con un documento</returns>
        public async Task<string> GetFile(string guid, string fileName, string extension)
        {
            BOInconsistenceFile file = null;

            try
            {
                using (WebClient client = new WebClient())
                {
                    Uri url = new Uri(
                        $"{ConfigurationManager.AppSettings["API_EVO"]}evidencia/archivo?GUID={guid}&nombreArchivo={fileName}&extensionArchivo={extension}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    string base64imageString = await client.DownloadStringTaskAsync(url.AbsoluteUri);
                    return base64imageString;
                }
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

        /// <summary>
        /// Obtiene un documento por Id de una inconsistencia
        /// </summary>
        /// <returns>Objeto de negocio con un documento</returns>
        public async Task<string> SendInconsistence(BOInconsistenceNew bOInconsistenceNew)
        {

            try
            {
                Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "evidencia/enviar");
                EvidenciaRequest buscarArticuloRequest = this.mapper.Map<BOInconsistenceNew, EvidenciaRequest>(bOInconsistenceNew);

                using (WebClient client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;

                    string json = JsonConvert.SerializeObject(buscarArticuloRequest);

                    return await client.UploadStringTaskAsync(url, "POST", json);
                }
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
        
        #endregion

    }
}
