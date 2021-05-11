using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Enum;
using EVO_PV_Proxy.Models.ConfigApi;
using EVO_PV_BusinessObjects.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace EVO_PV_Proxy
{
    public class ConfigProxy : Automapper
    {

        /// <summary>
        /// Obtiene la version actual de la aplicacion
        /// </summary>
        /// <returns>Version de la APP</returns>
        public ObtenerVersion ObtenerVersionActual()
        {
            ObtenerVersion version = null ;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

            var HtmlResult = string.Empty;

             WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
            {
                using (WebClient client = new WebClient())
                {
                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "config/obtenerversionactual");

                    client.UseDefaultCredentials = true;

                    HtmlResult = client.DownloadString(url.AbsoluteUri);

                    version = JsonConvert.DeserializeObject<ObtenerVersion>(HtmlResult);
                   
                }
            });

            return version;

        }


        /// <summary>
        /// Llama al proxy de configuración, método obtener el máximo tamaño de paginación
        /// </summary>
        /// <returns>ParametroGeneral</returns>
        public ParametroGeneral ObtenerParametroGeneralxNombre(string nombre)
        {
            ParametroGeneral parametroGeneral = null;

            IHttpContextAccessor ctx = new HttpContextAccessor();

            WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

             WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
            {
                using (WebClient client = new WebClient())
                {
                    CredentialCache cc = new CredentialCache();

                    AppConfiguration appConfig = new AppConfiguration();

                    Uri url = new Uri(appConfig.AppSettings["API_EVO"] + $"parametrosgenerales/obtenerxnombre/{EnumConstanst.TAMANHO_PAGINACION_WEBAPI.ToString()}");
                    client.UseDefaultCredentials = true;
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url.AbsoluteUri);
                    var response = JsonConvert.DeserializeObject<ParametroGeneralResponse>(HtmlResult);
                    parametroGeneral = this.iMapper.Map<ParametroGeneralResponse, ParametroGeneral>(response);
                }
            });            

            return parametroGeneral;
        }
    }
}
