using EVO_PV.Models.AuditApi;
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Utilities;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV.Services
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 27-Oct/2020
    /// Descripción      : Esta clase implementa el llamado a los endpoints de la auditoria
    /// </summary>
    class AuditService : Mapper
    {
        #region Atributos
        private AppConfiguration appConfiguration = null;
        #endregion

        #region Constructores

        public AuditService()
        {
            appConfiguration = new AppConfiguration();
        }
        #endregion

        #region Métodos
        public async Task<bool> SetAuditAsync(BOAudit bOAudit)
        {
            string response = null;

            try
            {
                string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();

                Uri url = new Uri(domain + "auditoria");

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;
                    RegistroAuditoriaRequest registroAuditoriaRequest = this.mapper.Map<BOAudit, RegistroAuditoriaRequest>(bOAudit);

                    string json = JsonConvert.SerializeObject(registroAuditoriaRequest);

                    response = client.UploadString(url.AbsoluteUri, "POST", json);

                    await Task.Delay(1);
                }

                return true;
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

        public bool SetAudit(BOAudit bOAudit)
        {
            string response = null;

            try
            {
                string domain = appConfiguration.AppSettings["API_EVO_PV"].ToString();

                Uri url = new Uri(domain + "auditoria");

                using (var client = new WebClient())
                {
                    client.UseDefaultCredentials = true;

                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");

                    client.Encoding = Encoding.UTF8;
                    RegistroAuditoriaRequest registroAuditoriaRequest = this.mapper.Map<BOAudit, RegistroAuditoriaRequest>(bOAudit);

                    string json = JsonConvert.SerializeObject(registroAuditoriaRequest);

                    response = client.UploadString(url.AbsoluteUri, "POST", json);
                   
                }

                return true;
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
