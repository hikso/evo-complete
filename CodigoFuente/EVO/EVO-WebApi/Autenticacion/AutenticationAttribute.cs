using EVO_BusinessLogic;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace EVO_WebApi.Autenticacion
{/// <summary>
/// 
/// </summary>
    public class AutenticationAttribute : ActionFilterAttribute
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="filterContext"></param>
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Response.StatusCode == (int)401)
            {
                Microsoft.AspNetCore.Mvc.OkObjectResult result = new Microsoft.AspNetCore.Mvc.OkObjectResult(filterContext.HttpContext.Response);
                result.StatusCode = 401;
                filterContext.Result = result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string token = "";
            foreach (var item in filterContext.HttpContext.Request.Headers)
            {
                if (item.Key.ToString().Equals("Authorizations"))
                {
                    foreach (var item2 in item.Value)
                    {
                        token = item2;
                    }
                }
            }
            if (token == "")
            {
                //Set the response status code to 500
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }

            string IP = filterContext.HttpContext.Connection.RemoteIpAddress.ToString();
            // Este comportamiento ocurre cuándo el RemoteIpAddress es el mismo equipo(localhost), por lo tanto se debe cambiar a 127.0.0.1, para que no fallen las validaciones sobre la estructura de la dirección IP
            if (IP.Equals("::1"))
            {
                IP = "127.0.0.1";
            }

            ValidarSesionSolicitud validarSession = new ValidarSesionSolicitud();
            validarSession.IP = IP;
            //validarSession.Token = token;
            validarSession.Token = token;

            try
            {
                BLAutenticacion bLAutenticacion = new BLAutenticacion();
                var result = bLAutenticacion.ValidarSesion(validarSession);

                if (!result.sesionValida)
                {
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
            }
            catch (EVOException ex)
            {
                throw ex;
            }
        }
        // Por describir algunos métodos heredados de ActionFilterAttribute
    }
}
