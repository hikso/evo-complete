
using EVO_PB.Models.BusinessObjects;
using EVO_PB.Models.BusinessObjects.Exceptions;
using EVO_PB.Utilities;
using EVO_WebApi_New.Models.UsuariosApi;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Text;

namespace EVO_PB.Services
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 07-Ene/2020
    /// Descripción      : Esta clase implementa el llamado a las apis de usuarios
    /// </summary>
    public class UserService : Mapper
    {
        /// <summary>
        /// Obtiene el usuario de EVO
        /// </summary>       
        /// <returns>Usuario</returns>
        public BOUser GetUser()
        {
            BOUser bOUser = null;

            using (WebClient wc = new WebClient())
            {
                try
                {
                    CredentialCache cc = new CredentialCache();
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO"] + "usuarios/obtenerusuario");
                    wc.UseDefaultCredentials = true;
                    wc.Encoding = Encoding.UTF8;
                    var HtmlResult = wc.DownloadString(url);
                    UsuarioResponse usuarioResponse = JsonConvert.DeserializeObject<UsuarioResponse>(HtmlResult);
                    bOUser = this.mapper.Map<UsuarioResponse, BOUser>(usuarioResponse);
                }
                catch(EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return bOUser;
        }
    }
}
