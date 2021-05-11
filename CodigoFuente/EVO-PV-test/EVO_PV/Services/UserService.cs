
using EVO_PV.Models.BusinessObjects;
using EVO_PV.Models.BusinessObjects.Exceptions;
using EVO_PV.Utilities;
using EVO_PV.Models.UsuariosApi;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Text;

namespace EVO_PV.Services
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

            using (WebClient client = new WebClient())
            {
                try
                {                    
                    Uri url = new Uri(ConfigurationManager.AppSettings["API_EVO_PV"] + "usuarios/obtenerusuario");
                    client.UseDefaultCredentials = true;                    
                    client.Encoding = Encoding.UTF8;
                    var HtmlResult = client.DownloadString(url);
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
