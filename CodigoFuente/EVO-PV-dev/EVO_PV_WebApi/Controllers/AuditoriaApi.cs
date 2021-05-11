using AutoMapper;
using EVO_PV_BusinessLogic;
using EVO_PV_BusinessObjects;
using EVO_PV_WebApi.Models;
using EVO_PV_WebApi.Models.AuditoriaApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVO_PV_WebApi.Controllers
{
    /// <summary>
    /// Autor            : Kevin Restrepo
    /// Fecha de Creación: 24-Oct/2019
    /// Descrición       : API de registros de auditoria
    /// </summary>
    /// 
    [Authorize]
    public class AuditoriaController : BaseController
    {
        /// <summary>
        /// Crea un registro de Auditoria
        /// </summary>
        /// <param name="body">Solicitud de creación de un registro de Auditoria</param>
        /// <response code="200">Operación realizada con éxito</response>
        [HttpPost]
        [Route("api/auditoria")]
        public virtual void CrearRegistro([FromBody]RegistroAuditoriaRequest body)
        {

            AuditoriaBL logicaAuditoria = new AuditoriaBL();

            Auditoria auditoria = this.mapper.Map<RegistroAuditoriaRequest, Auditoria>(body);

            logicaAuditoria.CrearRegistroAuditoria(auditoria);
        }
    }
}