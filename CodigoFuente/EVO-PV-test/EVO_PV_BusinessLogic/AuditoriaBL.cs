using EVO_PV_BusinessObjects;
using EVO_PV_Proxy;
using System;

namespace EVO_PV_BusinessLogic
{
    /// <summary>
    /// Autor            : Kevin Restrepo
    /// Fecha de Creación: 24-Oct/2019
    /// Descrición       : Clase de Lógica de Negocio de registros de auditoria
    /// </summary>
    public class AuditoriaBL
    {
        #region Campos Privados
        AuditoriaProxy AuditoriaProxy = new AuditoriaProxy();
        #endregion

        #region Métodos Públicos      
        /// <summary>
        /// Este método permite crear un registro de auditoria
        /// </summary>
        /// <param name="auditoria">Datos del registro de auditoria</param>
        /// <returns></returns>
        public bool CrearRegistroAuditoria(Auditoria auditoria)
        {
            //TODO: Validar los datos del objeto de auditoria
            if (auditoria == null)
            {
                throw new Exception("");
            }

            if (string.IsNullOrWhiteSpace(auditoria.accion))
            {
                throw new Exception("");
            }

            bool respuesta = AuditoriaProxy.CrearRegistroAuditoria(auditoria);

            return respuesta;
        }
        #endregion
    }
}