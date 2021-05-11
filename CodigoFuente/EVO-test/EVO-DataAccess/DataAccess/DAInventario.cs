using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga
    /// Fecha de Creación: 21-May/2019
    /// Descripción      : Esta clase implementa los métodos de acceso a datos de inventario
    /// </summary>
    public class DAInventario : DABase
    {
        /// <summary>
        /// Obtiene el tipo de inventario por nombre
        /// </summary>
        /// <param name="tipoInventarioEnum">Enumerador del tipo de inventario</param>       
        /// <response>TipoInventarioBO</response>
        public TipoInventarioBO ObtenerTipoInventarioxNombre(TiposInventarioEnum tipoInventarioEnum)
        {
            TipoInventarioBO tipoInventarioBO = new TipoInventarioBO();
            EFTipoInventario eFTipoInventario = null;

            using (Contexto contexto = new Contexto())
            {
                eFTipoInventario = contexto.TiposInventario
                    .FirstOrDefault(ti => ti.Nombre == tipoInventarioEnum.ToString() && ti.Activo);
            }

            if (eFTipoInventario != null)
            {
                tipoInventarioBO = this.mapper.Map<EFTipoInventario, TipoInventarioBO>(eFTipoInventario);
            }

            return tipoInventarioBO;

        }

        /// <summary>
        /// Asigna entradas o salidas al inventario
        /// </summary>
        /// <param name="inventarios">Entrada de inventarios</param>       
        /// <response>bool</response>
        public bool Asignar(List<InventarioBO> inventarios)
        {
            List<EFInventario> efInventarios = this.mapper.Map<List<InventarioBO>, List<EFInventario>>(inventarios);

            using (Contexto contexto = new Contexto())
            {
                contexto.Inventarios.AddRange(efInventarios);
                contexto.SaveChanges();
            }

            return true;
        }
    }
}
