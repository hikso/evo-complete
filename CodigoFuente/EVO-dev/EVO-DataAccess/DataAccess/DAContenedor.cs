using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    public class DAContenedor : DABase
    {
        /// <summary>
        /// Obtiene todos los tipos de contenedores
        /// </summary>
        /// <response>List<TipoContenedorRespuesta></response>
        public List<BOTipoContenedorRespuesta> ObtenerTipoContenedores()
        {
            List<BOTipoContenedorRespuesta> tipoContenedores = new List<BOTipoContenedorRespuesta>();

            List<EFTipoContenedor> eFTipoContenedores = null;

            using (Contexto contexto = new Contexto())
            {
                eFTipoContenedores = contexto.TiposContenedor.Where(tb => tb.Activo).ToList();
            }

            if (eFTipoContenedores.Count >= 0)
            {
                tipoContenedores = this.mapper.Map<List<EFTipoContenedor>, List<BOTipoContenedorRespuesta>>(eFTipoContenedores);
            }

            return tipoContenedores;
        }

        /// <summary>
        /// Obtiene un objeto de negocio tipo de contenedor por el id
        /// </summary>
        /// <param name="tipoContenedorId">5</param>
        /// <returns>TipoContenedorRespuesta</returns>
        public BOTipoContenedorRespuesta ObtenerTipoContenedorxId(int tipoContenedorId)
        {
            BOTipoContenedorRespuesta tipoContenedor = null;
            EFTipoContenedor eFTipoContenedor = null;

            using (Contexto contexto = new Contexto())
            {
                eFTipoContenedor = contexto.TiposContenedor.FirstOrDefault(d => d.TipoContenedorId == tipoContenedorId);
            }

            if (eFTipoContenedor != null)
            {
                tipoContenedor = this.mapper.Map<EFTipoContenedor,BOTipoContenedorRespuesta>(eFTipoContenedor);
            }

            return tipoContenedor;
        }

        /// <summary>
        /// Obtiene un objeto de negocio tipo de contenedor por el nombre
        /// </summary>
        /// <param name="tipoContenedorNombre">Nombre 1</param>
        /// <returns>TipoContenedorRespuesta</returns>
        public BOTipoContenedorRespuesta ObtenerTipoContenedorxNombre(TiposContenedorEnum tiposContenedorEnum)
        {
            BOTipoContenedorRespuesta tipoContenedor = null;
            EFTipoContenedor eFTipoContenedor = null;

            using (Contexto contexto = new Contexto())
            {
                eFTipoContenedor = contexto.TiposContenedor.FirstOrDefault(d => d.Nombre == tiposContenedorEnum.ToString());
            }

            if (eFTipoContenedor != null)
            {
                tipoContenedor = this.mapper.Map<EFTipoContenedor, BOTipoContenedorRespuesta>(eFTipoContenedor);
            }

            return tipoContenedor;
        }

        /// <summary>
        /// Registra el código de barras y obtiene los datos del código de barras
        /// </summary>
        /// <param name="pesajeId">Indica el id del pesaje</param>
        /// <param name="usuarioId">Indica el id del usuario</param>    
        /// <param name="bOCodigoBarras">Representa el código de barras</param>    
        /// <response>bool</response>
        public bool AsignarCodigoBarras(int pesajeId,int usuarioId, BOCodigoBarras bOCodigoBarras)
        {
            EFPesajeCodigoBarras eFPesajeCodigoBarras = this.mapper.Map<BOCodigoBarras,EFPesajeCodigoBarras>(bOCodigoBarras);

            eFPesajeCodigoBarras.PesajeId = pesajeId;
            eFPesajeCodigoBarras.UsuarioId = usuarioId;

            using (Contexto contexto=new Contexto())
            {
                using (var tran=contexto.Database.BeginTransaction())
                {
                    try
                    {
                        contexto.PesajesCodigoBarras.Add(eFPesajeCodigoBarras);

                        EFPesaje eFPesaje = contexto.Pesajes.FirstOrDefault(p => p.PesajeId == pesajeId);
                        eFPesaje.PesoCodigosBarras = eFPesaje.PesoCodigosBarras!=null ? eFPesaje.PesoCodigosBarras.Value + bOCodigoBarras.Peso: bOCodigoBarras.Peso;
                        contexto.Update(eFPesaje);
                        contexto.SaveChanges();

                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }

                }
            }

            return true;
        }

        /// <summary>
        /// Obtiene todos los contenedores usados en el pesaje
        /// </summary>
        /// <param name="pesajeId">Indica el id del pesaje</param>
        /// <response>List<BOPesajeContenedorResponse></response>

        public List<BOPesajeContenedorResponse> ObtenerContenedoresPesaje(int pesajeId)
        {
            List<BOPesajeContenedorResponse> bOPesajeContenedoresResponse = null;
            List<EFPesajeContenedor> eFPesajeContenedores = null;

            using (Contexto contexto = new Contexto())
            {
                eFPesajeContenedores = contexto.PesajesContenedor
                    .Include(i=>i.TipoContenedor).Where(pc => pc.PesajeId == pesajeId).ToList();
            }

            if (eFPesajeContenedores!=null)
            {
                bOPesajeContenedoresResponse = this.mapper.Map<List<EFPesajeContenedor>,List<BOPesajeContenedorResponse>>(eFPesajeContenedores);
            }

            return bOPesajeContenedoresResponse;

        }

        /// <summary>
        /// Obtiene todos los codigos de barras contenedores usados en el pesaje
        /// </summary>        
        /// <param name="pesajeId">Indica el id del pesaje</param>
        /// <response >List<BOCodigoBarrasResponse></response>
        public List<BOCodigoBarrasResponse> ObtenerContenedoresCodigoBarras(int pesajeId)
        {
            List<BOCodigoBarrasResponse> bOCodigosBarrasResponses = null;
            List<EFPesajeCodigoBarras> eFPesajesCodigoBarras = null;

            using (Contexto contexto = new Contexto())
            {
                eFPesajesCodigoBarras = contexto.PesajesCodigoBarras
                    .Where(pc => pc.PesajeId == pesajeId).ToList();
            }

            if (eFPesajesCodigoBarras != null)
            {
                bOCodigosBarrasResponses = this.mapper.Map<List<EFPesajeCodigoBarras>,List<BOCodigoBarrasResponse>>(eFPesajesCodigoBarras);
            }

            return bOCodigosBarrasResponses;
        }
    }
}
