using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Exceptions;
using EVO_PV_Proxy.Models.UsuariosApi;
using EVO_PV_BusinessObjects.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EVO_PV_Proxy
{
    public class UsuarioProxy : Automapper
    {
        public async Task<Usuario> ObtenerUsuario()
        {
            try
            {
                Usuario usuario = null;

                AppConfiguration appConfig = new AppConfiguration();

                Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "usuarios/obtenerusuario");

                IHttpContextAccessor ctx = new HttpContextAccessor();

                WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

                await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () => 
                {
                    using (var client = new WebClient { UseDefaultCredentials = true, Encoding = Encoding.UTF8 })
                    {
                        var HtmlResult = await client.DownloadStringTaskAsync(url.AbsoluteUri);

                        UsuarioResponse response = JsonConvert.DeserializeObject<UsuarioResponse>(HtmlResult);

                        usuario = this.iMapper.Map<UsuarioResponse, Usuario>(response);
                    }
                });

                return usuario;

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
        /// Obtiene el dominio con el usuario
        /// </summary>
        /// <returns>Dominio-Usuario (ANTIOQUENA/Krestrepo)</returns>
        public async Task<string> ObtenerNombreUsuarioString()
        {
            string nombreUsuario = "";

            using (WebClient client = new WebClient())
            {
                AppConfiguration appConfig = new AppConfiguration();

                Uri url = new Uri(appConfig.AppSettings["API_EVO"] + "usuarios/obtenerUsuarioString");

                client.UseDefaultCredentials = true;

                IHttpContextAccessor ctx = new HttpContextAccessor();

                WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

                await WindowsIdentity.RunImpersonated(currentUser.AccessToken, async () =>
                {
                    nombreUsuario = await client.DownloadStringTaskAsync(url);
                });

            }
            return nombreUsuario;
        }
    }
}
