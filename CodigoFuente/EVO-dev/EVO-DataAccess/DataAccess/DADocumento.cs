using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 2-Abr/2020
    /// Descripción      : Implementa el acceso a datos de documento
    /// </summary>
    public class DADocumento:DABase
    {
        /// <summary>
        /// Obtiene documento por nombre
        /// </summary>
        /// <param name="documento">Indica nombre del documento</param>
        /// <returns>BODocumento</returns>
        public BODocumento ObtenerDocumentoxNombre(DocumentosEnum documento)
        {
            BODocumento bODocumento = null;
            EFDocumento eFDocumento = null;

            using (Contexto contexto = new Contexto())
            {
                eFDocumento = contexto.Documentos.FirstOrDefault(d =>d.Activo && d.Documento == documento.ToString().Replace("_"," "));
            }

            if (eFDocumento != null)
            {
                bODocumento = this.mapper.Map<EFDocumento,BODocumento>(eFDocumento);
            }

            return bODocumento;

        }

        /// <summary>
        /// Obtiene los documentos
        /// </summary>
        /// <returns>List<BODocumento></returns>
        public List<BODocumento> ObtenerDocumentos()
        {
            List<BODocumento> bODocumentos = null;
            List<EFDocumento> eFDocumentos = null;

            using (Contexto contexto = new Contexto())
            {
                eFDocumentos = contexto.Documentos.Where(d => d.Activo).ToList();
            }

            if (eFDocumentos != null)
            {
                bODocumentos = this.mapper.Map<List<EFDocumento>,List<BODocumento>>(eFDocumentos);
            }

            return bODocumentos;

        }
       
    }
}
