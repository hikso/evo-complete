using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 02-Ago/2019
    /// Descripción      : Acceso a datos de roles
    /// </summary>
    public class DARol : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método obtiene todos los roles por usuarioId
        /// </summary>
        /// <param name="UsuarioId">Id del usuario</param>
        /// <returns>Colección de instacias de negocio de Roles</returns>
        public List<Rol> ObtenerRolesxUsuarioId(int usuarioId)
        {
            List<Rol> roles = null;
            List<EFRol> efRoles = null;

            using (Contexto contexto=new Contexto())
            {
                efRoles = contexto.UsuariosxRol
                    .Include(d => d.Rol)
                    .Where(x => x.UsuarioId == usuarioId && x.Rol.Activo)
                    .Select(r=>r.Rol).ToList();
            }

            roles = new List<Rol>();

            if (efRoles!=null)
            {
                roles = this.mapper.Map<List<EFRol>,List<Rol>>(efRoles);
            }

            return roles;

        }

        /// <summary>
        /// Este método desasocia un usuario a un rol
        /// </summary>
        /// <param name="desasociarUsuariosARol">Objeto que contiene el id del rol y ids de los usuarios</param>
        /// <returns>Retorna verdadero si se pudo desasociar de lo contrario false</returns>
        public bool DesasociarUsuarioARol(DesasociarUsuariosARol desasociarUsuariosARol)
        {
            List<EFUsuariosxRol> efUsuariosXRol = null;

            using (var contexto = new Contexto())
            {
                efUsuariosXRol = contexto.UsuariosxRol.Where(x => x.RolId == desasociarUsuariosARol.RolId &&
                   desasociarUsuariosARol.UsuariosIds.Contains(x.UsuarioId)).ToList();

                if (efUsuariosXRol != null)
                {
                    contexto.RemoveRange(efUsuariosXRol);

                    contexto.SaveChanges();
                }
            }

            return efUsuariosXRol != null;
        }

        /// <summary>
        /// Este método asocia un usuario a un rol
        /// </summary>
        /// <param name="asociarUsuariosARol">Objeto que incluye el id del rol y el usuario , nombre del Usuario</param>
        /// <returns>Retorna verdadero si se pudo asociar</returns>
        public bool AsociarUsuariosARol(AsociarUsuariosARol asociarUsuariosARol)
        {
            List<EFUsuariosxRol> efUsuariosXRol = new List<EFUsuariosxRol>();

            using (var contexto = new Contexto())
            {
                foreach (var usuario in asociarUsuariosARol.Usuarios)
                {
                    EFUsuariosxRol efUsuarioXRol = new EFUsuariosxRol()
                    {
                        RolId = asociarUsuariosARol.RolId,
                        UsuarioId = usuario.UsuarioId
                    };

                    efUsuariosXRol.Add(efUsuarioXRol);
                }

                contexto.AddRange(efUsuariosXRol);

                contexto.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Este método desasocia todos los usuarios a un rol
        /// </summary>
        /// <param name="id">Objeto que incluye el id del rol</param>
        /// <returns>Retorna verdadero si se pudo desasociar todos los usuarios a un rol de lo contrario false</returns>
        public bool DesasociarTodosUsuariosARol(int id)
        {
            List<EFUsuariosxRol> usuariosxRol = null;

            using (var contexto = new Contexto())
            {
                usuariosxRol = contexto.UsuariosxRol.Where(u => u.RolId == id).ToList();

                if (usuariosxRol != null)
                {
                    contexto.RemoveRange(usuariosxRol);

                    contexto.SaveChanges();
                }
            }

            return usuariosxRol != null;
        }

        /// <summary>
        /// Verifica si el usuario ya está asociado a este rol
        /// </summary>
        /// <param name="asociarUsuarioARol">Objeto que contiene el usuario , nombre del Usuario</param>
        /// <param name="rolId">Id del rol</param>
        /// <returns>Retorna true si el usuario está asociado al rol de lo contrario false</returns>
        public bool ObtenerUsuarioEstaAsociadoARol(Usuario asociarUsuarioARol, int rolId)
        {
            EFUsuariosxRol efUsuariosxRol = null;

            using (var contexto = new Contexto())
            {
                efUsuariosxRol = contexto.UsuariosxRol.Include(x => x.Usuario).
                     FirstOrDefault(x => x.RolId == rolId &&
                     x.Usuario.Usuario == asociarUsuarioARol.NombreUsuario);
            }

            return efUsuariosxRol != null;
        }

        /// <summary>
        /// Verifica si el usuario ya está desasociado a este rol
        /// </summary>
        /// <param name="rolId">Id del rol</param>
        /// <param name="usuarioId">Id del usuario</param>
        /// <returns>Retorna true si el usuario está desasociado al rol de lo contrario false</returns>
        public bool ObtenerUsuarioEstaDesasociadoARol(int rolId,int usuarioId)
        {
            EFUsuariosxRol efUsuariosxRol = null;

            using (var contexto = new Contexto())
            {
                efUsuariosxRol = contexto.UsuariosxRol.FirstOrDefault(x => x.RolId == rolId &&
                     x.UsuarioId == usuarioId);
            }

            return efUsuariosxRol == null;
        }

        /// <summary>
        /// Este método obtiene todos los usuarios de un rol
        /// </summary>
        /// <param name="desde">Indica el nùmero de registro desde el cuàl se quiere obtener los registros de auditoria</param>
        /// <param name="hasta">Indica el nùmero de registro hasta el cuàl se quiere obtener los registros de auditoria</param>
        /// <param name="rolId">Indica el id del Rol</param>
        /// <returns>Si esta dentro de el numero de registros permitidos, devuelve una lista de usuarios.</returns>
        public List<Usuario> ObtenerTodosUsuariosxRol(int desde, int hasta, int idRol)
        {
            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@desde",
                    Value = desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@hasta",
                    Value = hasta
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@idRol",
                    Value = idRol
                });

                List<Usuario> usauriosRol = contexto.LoadSPAutoMapper<Usuario>("ObtenerUsuariosxRol", dbParameters);

                return usauriosRol;
            }
        }

        /// <summary>
        /// Este método obtiene todos los usuarios por el rol con su respectivo filtro
        /// </summary>
        /// <param name="desde">Indica desde que parametro se le aplica el filtro ejemplo: desde 1</param>
        /// <param name="hasta">Indica hasta que parametro se le aplica el filtro ejemplo: hasta 10</param>
        /// <param name="idRol">Indica el id del Rol</param>
        /// <returns></returns>
        public List<Usuario> ObtenerTodosUsuariosxRolxFiltro(FiltroUsuario filtroUsuario)
        {
            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@desde",
                    Value = filtroUsuario.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@hasta",
                    Value = filtroUsuario.Hasta
                });

                if (!string.IsNullOrWhiteSpace(filtroUsuario.Usuario))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@usuario",
                        Value = filtroUsuario.Usuario
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtroUsuario.Nombre))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@nombre",
                        Value = filtroUsuario.Nombre
                    });
                }

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@rolId",
                    Value = filtroUsuario.rolId
                });

                List<Usuario> usuariosxrol = contexto.LoadSPAutoMapper<Usuario>("ObtenerTodosUsuariosxRolxFiltro", dbParameters);

                return usuariosxrol;
            }
        }

        /// <summary>
        /// Este método actualiza las funcionalidades asociadas a un rol
        /// </summary>
        /// <param name="rolAActualizar">Rol a actualizar de tipo Rol</param>
        /// <returns>Verdadero si el rol se pudo actualizar</returns>
        public bool ActualizarFuncionalidadesARol(Rol rolAActualizar)
        {
            using (var contexto = new Contexto())
            {
                var EFRolAActualizar = (from r in contexto.Roles
                                        .Include(rf => rf.FuncionalidadesxRol)
                                        where (r.RolId == rolAActualizar.RolId)
                                        select r).FirstOrDefault();

                // Primero se eliminan TODAS las funcionalidades asociadas al rol
                foreach (var funcionalidadAEliminar in EFRolAActualizar.FuncionalidadesxRol)
                {
                    contexto.FuncionalidadesxRol.Remove(funcionalidadAEliminar);
                }

                // Luego se crean las nuevas funcionalidades a asociar
                foreach (var nuevaFuncionalidad in rolAActualizar.Funcionalidades)
                {
                    EFRolAActualizar.FuncionalidadesxRol.Add(new EFFuncionalidadesxRol()
                    {
                        FuncionalidadId = nuevaFuncionalidad.FuncionalidadId,
                        RolId = EFRolAActualizar.RolId
                    });
                }

                contexto.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Este método permite actualizar un rol en el sistema
        /// </summary>
        /// <param name="rolAActualizar">Rol a actualizar de tipo Rol</param>
        /// <returns>Verdadero si el rol se pudo actualizar</returns>
        public bool ActualizarRol(Rol rolAActualizar)
        {
            using (var contexto = new Contexto())
            {
                var rol = (from r in contexto.Roles
                           where (r.RolId == rolAActualizar.RolId)
                           select r).FirstOrDefault();

                rol.Nombre = rolAActualizar.Nombre;
                rol.PlantaBeneficio = rolAActualizar.PlantaBeneficio;
                rol.PlantaDerivadosCarnicos = rolAActualizar.PlantaDerivadosCarnicos;
                rol.PuntosVenta = rolAActualizar.PuntosVenta;
                rol.Administracion = rolAActualizar.Administracion;

                contexto.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Crear un nuevo rol en el sistema
        /// </summary>
        /// <param name="nuevoRol">Rol a crear</param>
        /// <returns>Verdadero si el rol se pudó crear en el sistema</returns>
        public bool CrearRol(Rol nuevoRol)
        {
            using (var contexto = new Contexto())
            {
                EFRol nuevoEFRol = this.mapper.Map<Rol, EFRol>(nuevoRol);

                contexto.Add(nuevoEFRol);

                contexto.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Este metodo actualiza los usuarios asignados al rol
        /// </summary>
        /// <param name="rolAActualizar">Rol a actualizar de tipo Rol</param>
        /// <returns>Verdadero si el rol se pudo actualizar</returns>
        public bool DesasociarUsuarios(Rol rolAActualizar)
        {
            using (var contexto = new Contexto())
            {
                var EFRolAActualizar = (from r in contexto.Roles.Include(x => x.UsuariosxRol)
                                        where (r.RolId == rolAActualizar.RolId)
                                        select r).FirstOrDefault();

                // Primero se eliminan TODOS los usuarios asociados al rol
                foreach (var usuariosAEliminar in EFRolAActualizar.UsuariosxRol)
                {
                    contexto.UsuariosxRol.Remove(usuariosAEliminar);
                }

                // Luego se crean los nuevos usuarios a asociar
                foreach (var nuevoUsuario in rolAActualizar.Usuarios)
                {
                    EFRolAActualizar.UsuariosxRol.Add(new EFUsuariosxRol()
                    {
                        RolId = EFRolAActualizar.RolId,
                        UsuarioId = nuevoUsuario.UsuarioId
                    });
                }

                contexto.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Este método permite Activar / Inactivar un rol en el sistema
        /// </summary>
        /// <param name="rolAActivar">Rol a activar / inactivar</param>
        /// <returns>Verdadero si el rol se pudó activar / inactivar</returns>
        public bool ActivarRol(Rol rolAActivar)
        {
            using (var contexto = new Contexto())
            {
                var EFRolAInactivar = (from r in contexto.Roles
                                       where (r.RolId == rolAActivar.RolId)
                                       select r).FirstOrDefault();

                //Se debe asignar el valor del objeto de negocio inactivo, ya que desde la vista, se puede solicitar inactivar / reactivar el rol
                EFRolAInactivar.Activo = rolAActivar.Activo;

                contexto.SaveChanges();

                return true;
            }
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de los filtros generados para la consulta
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda sobre la Auditoria</param>
        /// <returns>Número de Registros retornados en el filtro</returns>
        public int ObtenerConteoTodosRolesxFiltro(FiltroRol filtro)
        {
            using (var contexto = new Contexto())
            {
                int nRegistros = 0;

                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                if (!string.IsNullOrWhiteSpace(filtro.Nombre))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroNombre",
                        Value = filtro.Nombre
                    });
                }

                object result = contexto.LoadSPScalar("ObtenerConteoTodosRolesxFiltro", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }

                return nRegistros;
            }
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de los filtros generados para la consulta
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda sobre los usuarios</param>
        /// <returns>Número de Registros retornados en el filtro</returns>
        public int ObtenerConteoTodosUsuariosxRolxFiltro(FiltroUsuario filtro)
        {
            using (var contexto = new Contexto())
            {
                int nRegistros = 0;

                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                if (!string.IsNullOrWhiteSpace(filtro.Nombre))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@nombre",
                        Value = filtro.Nombre
                    });
                }

                if (!string.IsNullOrWhiteSpace(filtro.Usuario))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@usuario",
                        Value = filtro.Usuario
                    });
                }

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@RolId",
                    Value = filtro.rolId
                });

                object result = contexto.LoadSPScalar("[ObtenerConteoTodosUsuariosxRolxFiltro]", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }

                return nRegistros;
            }
        }

        /// <summary>
        /// Este método obtiene el número total de registros de la tabla de Roles
        /// </summary>
        /// <returns>Número total de registros</returns>
        public int ObtenerNumeroTotalRegistros()
        {
            int numeroTotalRegistros = 0;

            using (var contexto = new Contexto())
            {
                numeroTotalRegistros = (from a in contexto.Roles
                                        select a).Count();
            }

            return numeroTotalRegistros;
        }


        /// <summary>
        /// Este método obtiene un rol por su id
        /// </summary>
        /// <param name="RolId">Id del Rol a obtener</param>
        /// <returns>Instancia de objeto de un Rol de tipo Rol</returns>
        public Rol ObtenerRolxId(int RolId)
        {
            Rol rol = null;

            using (var contexto = new Contexto())
            {
                if (contexto.Roles.FirstOrDefault(x => x.RolId == RolId) == null)
                {
                    return null;
                }

                EFRol efRol = (from r in contexto.Roles
                               where (r.RolId == RolId)
                               select r).FirstOrDefault();

                rol = this.mapper.Map<EFRol, Rol>(efRol);

                // Cargar las funcionalidades asociadas al rol
                var funcionalidades = (from fxr in contexto.FuncionalidadesxRol
                                       join f in contexto.Funcionalidades on fxr.FuncionalidadId equals f.FuncionalidadId
                                       where (fxr.RolId == RolId) && (f.Activo)
                                       select f).ToList();

                if (funcionalidades != null)
                {
                    rol.Funcionalidades = this.mapper.Map<List<EFFuncionalidad>, List<Funcionalidad>>(funcionalidades);
                }

                // Cargar los usuarios asociados al rol
                var usuarios = (from uxr in contexto.UsuariosxRol
                                join u in contexto.Usuarios on uxr.UsuarioId equals u.UsuarioId
                                where (uxr.RolId == RolId) && (u.Activo)
                                select u).ToList();

                if (usuarios != null)
                {
                    rol.Usuarios = this.mapper.Map<List<EFUsuario>, List<Usuario>>(usuarios);
                }
            }

            return rol;
        }

        /// <summary>
        /// Este método obtiene un rol por su Nombre
        /// </summary>
        /// <param name="nombre">Nombre del Rol a obtener</param>
        /// <returns>Instancia de objeto de un Rol de tipo Rol</returns>
        public Rol ObtenerRolxNombre(string nombre)
        {
            Rol rol = null;

            using (var contexto = new Contexto())
            {
                if (contexto.Roles.FirstOrDefault(x => x.Nombre == nombre) == null)
                {
                    return null;
                }

                EFRol efRol = (from r in contexto.Roles
                               where (r.Nombre.ToLower().Trim() == nombre.ToLower().Trim())
                               select r).FirstOrDefault();

                rol = this.mapper.Map<EFRol, Rol>(efRol);

                if (rol != null)
                {
                    int rolId = rol.RolId;

                    // Cargar las funcionalidades asociadas al rol
                    var funcionalidades = (from fxr in contexto.FuncionalidadesxRol
                                           join f in contexto.Funcionalidades on fxr.FuncionalidadId equals f.FuncionalidadId
                                           where (fxr.RolId == rolId) && (f.Activo)
                                           select f).ToList();

                    if (funcionalidades != null)
                    {
                        rol.Funcionalidades = this.mapper.Map<List<EFFuncionalidad>, List<Funcionalidad>>(funcionalidades);
                    }

                    // Cargar los usuarios asociados al rol
                    var usuarios = (from uxr in contexto.UsuariosxRol
                                    join u in contexto.Usuarios on uxr.UsuarioId equals u.UsuarioId
                                    where (uxr.RolId == rolId) && (u.Activo)
                                    select u).ToList();

                    if (usuarios != null)
                    {
                        rol.Usuarios = this.mapper.Map<List<EFUsuario>, List<Usuario>>(usuarios);
                    }
                }
            }

            return rol;
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan de la consulta
        /// </summary>
        /// <returns>Número de registros</returns>
        public object ObtenerNumeroTotalRegistrosUsuariosXRol(int rolId)
        {
            int nRegistros = 0;

            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@rolId",
                    Value = rolId
                });

                object result = contexto.LoadSPScalar("ObtenerConteoTodosUsuariosxRol", dbParameters);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene los roles creados en el sistema
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se deben cargar los registros</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se deben cargar los registros</param>
        /// <returns>Lista de roles de tipo Rol</returns>
        public List<Rol> ObtenerTodosRoles(int desde, int hasta)
        {
            List<Rol> listaRoles = null;

            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = hasta
                });

                listaRoles = contexto.LoadSPCustomMapper<Rol>("ObtenerTodosRoles", dbParameters, mapeadorRegistroRol);
            }

            return listaRoles;
        }

        /// <summary>
        /// Este metodo obtiene todos los Roles aplicando un filtro de búsqueda
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda sobre los Roles</param>
        /// <returns>Lista de Roles</returns>
        public List<Rol> ObtenerTodosRolesxFiltro(FiltroRol filtro)
        {
            using (var contexto = new Contexto())
            {
                // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
                List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Desde",
                    Value = filtro.Desde
                });

                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@Hasta",
                    Value = filtro.Hasta
                });

                if (!string.IsNullOrWhiteSpace(filtro.Nombre))
                {
                    dbParameters.Add(new EFCoreExtensionParameter()
                    {
                        ParameterName = "@filtroNombre",
                        Value = filtro.Nombre
                    });
                }

                List<Rol> listaRoles = contexto.LoadSPCustomMapper<Rol>("ObtenerTodosRolesxFiltro", dbParameters, mapeadorRegistroRol);

                return listaRoles;
            }
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Mapea un objeto DbDataReader a un objeto de tipo Rol
        /// </summary>
        /// <param name="reader">DbDataReader</param>
        /// <returns>Instancia de objeto de tipo Rol</returns>
        private Rol mapeadorRegistroRol(DbDataReader reader)
        {
            Rol r = null;

            if (reader != null)
            {
                r = new Rol()
                {
                    RolId = int.Parse(reader["RolId"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Activo = bool.Parse(reader["Activo"].ToString())
                };
            }

            return r;
        }       
        #endregion
    }
}