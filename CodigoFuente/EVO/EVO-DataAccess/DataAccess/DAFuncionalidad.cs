using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 08-Ago/2019
    /// Descripción      : Acceso a datos de Funcionalidad
    /// </summary>
    public class DAFuncionalidad : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este metodo trae las funcionalidades asignadas a un Id
        /// </summary>
        /// <param name="funcionalidadId">Id de funcionalidad a buscar de tipo funcionalidad</param>
        /// <returns>Instancia de tipo Funcionalidad</returns>
        public Funcionalidad ObtenerFuncionalidadxId(int funcionalidadId)
        {
            Funcionalidad funcionalidad = null;

            using (var contexto = new Contexto())
            {
                EFFuncionalidad efFuncionalidad = (from f in contexto.Funcionalidades
                                                   where (f.FuncionalidadId == funcionalidadId)
                                                   select f).FirstOrDefault();

                funcionalidad = this.mapper.Map<EFFuncionalidad, Funcionalidad>(efFuncionalidad);
            }

            return funcionalidad;
        }

        /// <summary>
        /// Este metodo trae las funcionalidades asignadas a un Modulo
        /// </summary>
        /// <param name="moduloId">Id de el modulo de tipo funcionalidad</param>
        /// <returns>Lista de funcionalidades por el id del modulo</returns>
        public List<Funcionalidad> ObtenerFuncionalidadxModuloId(int moduloId)
        {
            List<Funcionalidad> funcionalidades = null;
            List<EFFuncionalidad> efFuncionalidades = null;

            using (var contexto = new Contexto())
            {
                 efFuncionalidades = (from f in contexto.Funcionalidades
                                       where (f.ModuloId == moduloId && f.Activo)
                                       select f).ToList();               
            }

            if (efFuncionalidades != null)
            {
                funcionalidades = this.mapper.Map<List<EFFuncionalidad>, List<Funcionalidad>>(efFuncionalidades);
            }

            return funcionalidades;
        }
        #endregion
    }
}