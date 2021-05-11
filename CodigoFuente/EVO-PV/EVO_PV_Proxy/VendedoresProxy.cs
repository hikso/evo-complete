using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Utils;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;

namespace EVO_PV_Proxy
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 28-Abr/2020
    /// Descripción      : Esta clase implementa los métodos proxy de Vendedores
    /// </summary>
    public class VendedoresProxy
    {
        public List<VendedorResponseBO> ObtenerVendedoresxPuntoVenta(string codigoPuntoVenta)
        {
            try
            {
                IHttpContextAccessor ctx = new HttpContextAccessor();

                WindowsIdentity currentUser = (WindowsIdentity)ctx.HttpContext.User.Identity;

                var HtmlResult = string.Empty;

                WindowsIdentity.RunImpersonated(currentUser.AccessToken, () =>
                {
                    using (WebClient client = new WebClient())
                    {
                        CredentialCache cc = new CredentialCache();

                        AppConfiguration appConfig = new AppConfiguration();

                        Uri url = new Uri(appConfig.AppSettings["API_EVO"] + $"vendedores/puntoventa?codigo={codigoPuntoVenta}");

                        client.UseDefaultCredentials = true;

                        HtmlResult =  client.DownloadString(url.AbsoluteUri);
                    }
                });

                return JsonConvert.DeserializeObject<List<VendedorResponseBO>>(HtmlResult);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
