using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 12-Abr/2020
    /// Descripción      : Se crea la clase de acceso a datos de Cajas
    /// </summary>
    public class DAProcesos : DABase
    {
        /// <summary>
        /// Obtiene el proceso por nombre
        /// </summary>
        /// <param name="procesoEnum">Enumerador del proceso</param>       
        /// <response>ProcesoBO</response>
        public ProcesoBO ObtenerProcesoxNombre(ProcesosEnum procesoEnum)
        {
            ProcesoBO procesoBO = null;
            EFProceso eFProceso = null;

            using (Contexto contexto=new Contexto())
            {
                eFProceso = contexto.Procesos.FirstOrDefault(p => p.Proceso == procesoEnum.ToString() && p.Activo);
            }

            if (eFProceso!=null)
            {
                procesoBO = this.mapper.Map<EFProceso,ProcesoBO>(eFProceso);
            }

            return procesoBO;

        }
    }
}
