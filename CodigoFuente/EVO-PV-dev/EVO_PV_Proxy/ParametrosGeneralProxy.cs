using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using EVO_PV_Proxy.Models.ConfigApi;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV_Proxy
{
    public class ParametrosGeneralProxy : Automapper
    {

        /// <summary>
        /// Obtiene parametros generales
        /// </summary>
        /// <returns>BOParametroGeneral</returns>

        public async Task<ParametroGeneral> ObtenerParametroGeneralXNombre(string nombre)
        {
            string parametroGeneral = "";

            ParametroGeneralResponse respuesta = null;

            using (WebClient client = new WebClient())
            {
                AppConfiguration appConfig = new AppConfiguration();

                Uri url = new Uri(appConfig.AppSettings["API_EVO"] + $"/parametrosgenerales/obtenerxnombre/{nombre}");


                client.UseDefaultCredentials = true;

               
                client.Encoding = Encoding.UTF8;

                IHttpContextAccessor ctx = new HttpContextAccessor();

                WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

                await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
                {
                    parametroGeneral = await client.DownloadStringTaskAsync(url);
                });

            }
            respuesta = JsonConvert.DeserializeObject<ParametroGeneralResponse>(parametroGeneral);
            return this.iMapper.Map<ParametroGeneralResponse, ParametroGeneral>(respuesta);
        }
    }
}
