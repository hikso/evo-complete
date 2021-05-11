using AutoMapper;
using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 21-Sep/2019
    /// Descripción      : Implementa el acceso a datos de los artículos
    /// </summary>
    public class DAMotivo : DABase
    {
      
        public List<MotivoRespuesta> ObtenerMotivos(int procesoId)
        {
            List<EFMotivo> eFMotivos = null;

            using (Contexto contexto = new Contexto())
            {
                eFMotivos = contexto.Motivos.Where(m => m.Activo && m.ProcesoId==procesoId).ToList();
            }

            List<MotivoRespuesta> motivos = null;

            if (eFMotivos.Count > 0)
            {
                motivos = this.mapper.Map<List<EFMotivo>,List<MotivoRespuesta>>(eFMotivos);
            }

            return motivos;
        }


        public MotivoRespuesta ObtenerMotivoxId(int id)
        {
            EFMotivo eFMotivo = null;

            using (Contexto contexto = new Contexto())
            {
                eFMotivo = contexto.Motivos.FirstOrDefault(m => m.Activo && m.MotivoId == id);
            }

            MotivoRespuesta motivo = null;

            if (eFMotivo != null)
            {
                motivo = this.mapper.Map<EFMotivo, MotivoRespuesta>(eFMotivo);
            }

            return motivo;
        }
    }
}
