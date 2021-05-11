using EFCoreExtensions.ExtensionMethods;
using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 06-Ago/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de negocio de los roles
    /// </summary>
    public class BLRol
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Actualiza un Rol
        /// </summary>
        /// <param name="rolAActualizar">Rol a actualizar de tipo Rol</param>
        /// <returns>Verdadero si se pudo realizar la actualizacion</returns>
        public bool ActualizarRol(Rol rolAActualizar)
        {
            if (rolAActualizar == null)
            {
                EVOException e = new EVOException(errores.errRolVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ActualizarRol con los parámetros: {JsonConvert.SerializeObject(rolAActualizar)}");

            var DARol = new DARol();
            var blParametrosGenerales = new BLParametroGeneral();

            if (rolAActualizar.RolId <= 0)
            {
                EVOException e = new EVOException(errores.errNombreRolVacio);

                logger.Error(e);

                throw e;
            }

            int caracterMaximo = int.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_CARACTERES_NOMBRE_ROL));

            if (string.IsNullOrEmpty(rolAActualizar.Nombre))
            {
                EVOException e = new EVOException(errores.errNombreRolVacio);

                logger.Error(e);

                throw e;
            }

            if (rolAActualizar.Nombre.Length > caracterMaximo)
            {
                EVOException e = new EVOException(errores.errCaracteresExcedidos);

                logger.Error(e);

                throw e;
            }

            // Validar que existan las funcionalidades
            if (rolAActualizar.Funcionalidades != null)
            {
                if (rolAActualizar.Funcionalidades.Count > 0)
                {
                    DAFuncionalidad dataFuncionalidades = new DAFuncionalidad();

                    Funcionalidad funcionalidadExiste;

                    // Se valida de que existan las funcionalidades una a una
                    foreach (Funcionalidad f in rolAActualizar.Funcionalidades)
                    {
                        funcionalidadExiste = dataFuncionalidades.ObtenerFuncionalidadxId(f.FuncionalidadId);

                        if (funcionalidadExiste == null)
                        {
                            EVOException e = new EVOException(string.Format(errores.errIdFuncionalidadNoExiste, f.FuncionalidadId));

                            logger.Error(e);

                            throw e;
                        }
                    }
                }
            }

            // Se válida que el id exista para poder actualizar.
            var rolObtenido = DARol.ObtenerRolxId(rolAActualizar.RolId);

            if (rolObtenido == null)
            {
                EVOException e = new EVOException(errores.errRolNoExiste);

                logger.Error(e);

                throw e;
            }

            if (!rolObtenido.Activo)
            {
                EVOException e = new EVOException(errores.errRolInactivo);

                logger.Error(e);

                throw e;
            }

            // Se válida que no exista el nombre en otro Rol
            rolObtenido = DARol.ObtenerRolxNombre(rolAActualizar.Nombre);

            if (rolObtenido != null)
            {
                if (rolObtenido.RolId != rolAActualizar.RolId)
                {
                    EVOException e = new EVOException(errores.errRolYaExiste);

                    logger.Error(e);

                    throw e;
                }
            }

            if (rolAActualizar.PlantaBeneficio == false && rolAActualizar.PlantaDerivadosCarnicos == false && rolAActualizar.PuntosVenta == false && rolAActualizar.Administracion == false)
            {
                EVOException e = new EVOException(string.Format(errores.errSistemaVacio));

                logger.Error(e);

                throw e;
            }

            // Se actualiza el Rol
            DARol.ActualizarRol(rolAActualizar);

            if (rolAActualizar.Funcionalidades == null)
            {
                rolAActualizar.Funcionalidades = new List<Funcionalidad>();
            }
            DARol.ActualizarFuncionalidadesARol(rolAActualizar);

            return true;
        }

        /// <summary>
        /// Válida que el usuario se pueda asociar a un rol
        /// </summary>
        /// <param name="asociarUsuarioARol">Objeto que incluye el id del rol y el usuario , nombre del usuario</param>
        /// <returns>Retorna true si todo salió bien de lo contrario false</returns>
        public bool AsociarUsuariosARol(AsociarUsuariosARol asociarUsuariosARol)
        {
            if (asociarUsuariosARol == null)
            {
                EVOException e = new EVOException(errores.errUsuarioRolVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método AsociarUsuariosARol con los parámetros: {0}",
            JsonConvert.SerializeObject(asociarUsuariosARol)));

            if (asociarUsuariosARol.RolId <= 0)
            {
                EVOException e = new EVOException(errores.errRolIdInValido);

                logger.Error(e);

                throw e;
            }          

            if (asociarUsuariosARol.Usuarios == null)
            {
                EVOException e = new EVOException(errores.errUsuariosARol);

                logger.Error(e);

                throw e;
            }

            if (asociarUsuariosARol.Usuarios.Count == 0)
            {
                EVOException e = new EVOException(errores.errUsuariosARol);

                logger.Error(e);

                throw e;
            }

            DARol daRoles = new DARol();

            Rol rolEncontrado = daRoles.ObtenerRolxId(asociarUsuariosARol.RolId);

            if (rolEncontrado == null)
            {
                EVOException e = new EVOException(errores.errRolNoExiste);

                logger.Error(e);

                throw e;
            }

            if (!rolEncontrado.Activo)
            {
                EVOException e = new EVOException(errores.errRolInactivo);

                logger.Error(e);

                throw e;
            }

            DAUsuario daUsuarios = new DAUsuario();

            foreach (var usuario in asociarUsuariosARol.Usuarios)
            {
                if (string.IsNullOrEmpty(usuario.NombreUsuario))
                {
                    EVOException e = new EVOException(errores.errUsuarioNoInformado);

                    logger.Error(e);

                    throw e;
                }

                int nBackSlash = usuario.NombreUsuario.IndexOf(@"\");

                //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
                if (nBackSlash > 0)
                {
                    usuario.NombreUsuario = usuario.NombreUsuario.Substring(nBackSlash + 1, usuario.NombreUsuario.Length - nBackSlash - 1);
                }

                if (string.IsNullOrEmpty(usuario.Nombre))
                {
                    EVOException e = new EVOException(errores.errNombreNoInformado);

                    logger.Error(e);

                    throw e;
                }

                if (daRoles.ObtenerUsuarioEstaAsociadoARol(usuario, asociarUsuariosARol.RolId))
                {
                    EVOException e = new EVOException(String.Format(errores.errUsuarioAsociadoARol, $"{usuario.Nombre}({usuario.NombreUsuario})"));

                    logger.Error(e);

                    throw e;
                }

                Usuario usuarioEncontrado = daUsuarios.
                ObtenerUsuarioPorUsuario(usuario.NombreUsuario);

                if (usuarioEncontrado == null)
                {
                    daUsuarios.RegistrarUsuario(usuario);

                    usuarioEncontrado = daUsuarios.
                    ObtenerUsuarioPorUsuario(usuario.NombreUsuario);

                    usuario.UsuarioId = usuarioEncontrado.UsuarioId;

                }
                else
                {
                    usuario.UsuarioId = usuarioEncontrado.UsuarioId;
                }
            }

            daRoles.AsociarUsuariosARol(asociarUsuariosARol);

            return true;

        }

        /// <summary>
        /// Válida que el usuario se pueda desasociar de un rol
        /// </summary>
        /// <param name="desasociarUsuarioARol">Objeto que incluye el id del rol y el usuario</param>
        /// <returns>Retorna true si todo salió bien de lo contrario false</returns>
        public bool DesasociarUsuariosARol(DesasociarUsuariosARol desasociarUsuariosARol)
        {
            if (desasociarUsuariosARol == null)
            {
                EVOException e = new EVOException(errores.errUsuarioRolVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método DesasociarUsuariosARol con los parámetros: {0}",
            JsonConvert.SerializeObject(desasociarUsuariosARol)));

            if (desasociarUsuariosARol.RolId <= 0)
            {
                EVOException e = new EVOException(errores.errRolIdInValido);

                logger.Error(e);

                throw e;
            }

            DARol daRoles = new DARol();

            Rol rolEncontrado = daRoles.ObtenerRolxId(desasociarUsuariosARol.RolId);

            if (rolEncontrado == null)
            {
                EVOException e = new EVOException(errores.errRolVacio);

                logger.Error(e);

                throw e;
            }

            if (!rolEncontrado.Activo)
            {
                EVOException e = new EVOException(errores.errRolInactivo);

                logger.Error(e);

                throw e;
            }

            if (desasociarUsuariosARol.UsuariosIds.Count == 0)
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            DAUsuario daUsuarios = new DAUsuario();

            foreach (int usuarioId in desasociarUsuariosARol.UsuariosIds)
            {
                Usuario usuarioEncontrado = daUsuarios.
                ObtenerUsuarioPorId(usuarioId);

                if (usuarioEncontrado == null)
                {
                    EVOException e = new EVOException(errores.errUsuarioNoExiste);

                    logger.Error(e);

                    throw e;
                }

                if (daRoles.ObtenerUsuarioEstaDesasociadoARol(desasociarUsuariosARol.RolId, usuarioId))
                {
                    EVOException e = new EVOException(String.Format(errores.errUsuarioNoAsociadoARol, $"{usuarioEncontrado.Nombre}({usuarioEncontrado.NombreUsuario})"));

                    logger.Error(e);

                    throw e;
                }

            }           

            return daRoles.DesasociarUsuarioARol(desasociarUsuariosARol);
        }

        /// <summary>
        /// Este método desasocia todos los usuarios de un rol
        /// </summary>
        /// <param name="id">Indica el id del rol</param>       
        /// <returns>Un true o false si se desasocio el usario del rol</returns>
        public bool DesasociarTodosUsuariosARol(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errRolIdVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método DesasociarTodosUsuariosARol con el parámetro:  id = {id}");

            DARol daRoles = new DARol();          

            Rol rolEncontrado = daRoles.ObtenerRolxId(id);

            if (rolEncontrado == null)
            {
                EVOException e = new EVOException(errores.errRolNoExiste);

                logger.Error(e);

                throw e;
            }

            if (!rolEncontrado.Activo)
            {
                EVOException e = new EVOException(errores.errRolInactivo);

                logger.Error(e);

                throw e;
            }

            daRoles.DesasociarTodosUsuariosARol(id);

            return true;

        }       

        /// <summary>
        /// Crea un registro de rol
        /// </summary>
        /// <param name="nuevoRol">Nuevo Rol de tipo Rol</param>
        /// <returns>Verdadero si se pudo realizar la insercion</returns>
        public bool CrearRol(Rol nuevoRol)
        {
            try
            {
                if (nuevoRol == null)
                {
                    EVOException e = new EVOException(errores.errRolVacio);

                    logger.Error(e);

                    throw e;
                }

                var DARol = new DARol();
                var blParametrosGenerales = new BLParametroGeneral();

                logger.Info(string.Format("Entró al método CrearRol con los parámetros: {0}",
               JsonConvert.SerializeObject(nuevoRol)));

                if (string.IsNullOrEmpty(nuevoRol.Nombre))
                {
                    EVOException e = new EVOException(errores.errNombreRolVacio);

                    logger.Error(e);

                    throw e;
                }

                int caracterMaximo = 0;

                try
                {
                    caracterMaximo = int.Parse(blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.MAXIMO_CARACTERES_NOMBRE_ROL));
                }
                catch (Exception e)
                {
                    logger.Error(e);

                    throw e;
                }

                if (nuevoRol.Nombre.Length > caracterMaximo)
                {
                    EVOException e = new EVOException(errores.errCaracteresExcedidos);

                    logger.Error(e);

                    throw e;
                }

                // Validar que existan las funcionalidades
                if (nuevoRol.Funcionalidades != null)
                {
                    if (nuevoRol.Funcionalidades.Count > 0)
                    {
                        DAFuncionalidad dataFuncionalidades = new DAFuncionalidad();

                        Funcionalidad funcionalidadExiste;

                        // Se valida de que existan las funcionalidades una a una
                        foreach (Funcionalidad f in nuevoRol.Funcionalidades)
                        {
                            funcionalidadExiste = dataFuncionalidades.ObtenerFuncionalidadxId(f.FuncionalidadId);

                            if (funcionalidadExiste == null)
                            {
                                EVOException e = new EVOException(string.Format(errores.errIdFuncionalidadNoExiste, f.FuncionalidadId));

                                logger.Error(e);

                                throw e;
                            }
                        }
                    }
                }

                var rolObtenido = DARol.ObtenerRolxNombre(nuevoRol.Nombre);

                if (rolObtenido != null)
                {
                    EVOException e = new EVOException(errores.errRolYaExiste);

                    logger.Error(e);

                    throw e;
                }

                nuevoRol.Activo = true;
                // Se crea el Rol
                DARol.CrearRol(nuevoRol);

                // Si el Rol posee funcionalidades asociadas (previamente validadas de que existen en el sistema), se procede a crearlas
                if (nuevoRol.Funcionalidades != null)
                {
                    if (nuevoRol.Funcionalidades.Count > 0)
                    {
                        var rolCreado = DARol.ObtenerRolxNombre(nuevoRol.Nombre);

                        nuevoRol.RolId = rolCreado.RolId;

                        DARol.ActualizarFuncionalidadesARol(nuevoRol);
                    }
                }              

                return true;

            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }
        }

        /// <summary>
        /// Este método permite Activar / Inactivar un rol en el sistema
        /// </summary>
        /// <param name="rolAActivar">Rol a activar</param>
        /// <returns>Verdadero si el rol se pudó activar / inactivar</returns>
        public bool ActivarRol(Rol rolAActivar)
        {
            if (rolAActivar == null)
            {
                EVOException e = new EVOException(errores.errRolVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ActivarRol con los parámetros: {0}",
               JsonConvert.SerializeObject(rolAActivar)));

            if (rolAActivar.RolId <= 0)
            {
                EVOException e = new EVOException(errores.errRolIdVacio);

                logger.Error(e);

                throw e;
            }

            DARol dataRoles = new DARol();

            // Se válida que el id exista para poder actualizar.
            var rolObtenido = dataRoles.ObtenerRolxId(rolAActivar.RolId);

            if (rolObtenido == null)
            {
                EVOException e = new EVOException(errores.errRolVacio);

                logger.Error(e);

                throw e;
            }

            dataRoles.ActivarRol(rolAActivar);

            return true;
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de los filtros generados para la consulta
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda sobre los Roles</param>
        /// <returns>Número de Registros retornados en el filtro</returns>
        public int ObtenerConteoTodosRolesxFiltro(FiltroRol filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerConteoTodosRolesxFiltro con los parámetros: {0}",
              JsonConvert.SerializeObject(filtro)));

            DARol daRoles = new DARol();

            if (string.IsNullOrWhiteSpace(filtro.Nombre))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            int nRegistros = 0;

            try
            {
                object result = daRoles.ObtenerConteoTodosRolesxFiltro(filtro);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch
            {
                Exception e = new Exception(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;

            }

            return nRegistros;
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de los filtros generados para la consulta
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda sobre los Roles</param>
        /// <returns>Número de Registros retornados en el filtro</returns>
        public int ObtenerConteoTodosUsuariosxRolxFiltro(FiltroUsuario filtro)
        {

            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerConteoTodosUsuariosxRolxFiltro con los parámetros: {0}",
             JsonConvert.SerializeObject(filtro)));

            // Estos parámetros se definen dentro de la clase de métodos de extensión: EFCoreExtension
            List<EFCoreExtensionParameter> dbParameters = new List<EFCoreExtensionParameter>();           

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            if (filtro.rolId <= 0)
            {
                EVOException e = new EVOException(errores.errRolIdInValido);

                logger.Error(e);

                throw e;
            }


            DARol daRoles = new DARol();

            if (!string.IsNullOrWhiteSpace(filtro.Usuario))
            {
                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@usuario",
                    Value = filtro.Usuario
                });
            }

            if (!string.IsNullOrWhiteSpace(filtro.Nombre))
            {
                dbParameters.Add(new EFCoreExtensionParameter()
                {
                    ParameterName = "@nombre",
                    Value = filtro.Nombre
                });
            }

            int nRegistros = 0;

            try
            {
                object result = daRoles.ObtenerConteoTodosUsuariosxRolxFiltro(filtro);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch
            {
                Exception e = new Exception(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;

            }

            return nRegistros;
        }

        /// <summary>
        /// Este método permite saber cuántos registros se generan a partir de la consulta
        /// </summary>
        /// <param name="rolId">Filtro de búsqueda sobre los Roles</param>
        /// <returns>Cantidad de usuarios del rol</returns>
        public int ObtenerNumeroTotalRegistrosUsuariosXRol(int rolId)
        {
            if (rolId < 0)
            {
                EVOException e = new EVOException(errores.errRolIdInValido);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerNumeroTotalRegistrosUsuariosXRol con el parámetro rold = {0} ", rolId));

            DARol daRoles = new DARol();

            Rol rolBuscar = daRoles.ObtenerRolxId(rolId);

            if (rolBuscar == null)
            {
                EVOException e = new EVOException(errores.errRolNoExiste);

                logger.Error(e);

                throw e;
            }

            int nRegistros = 0;

            try
            {
                object result = daRoles.ObtenerNumeroTotalRegistrosUsuariosXRol(rolId);

                if (result != null)
                {
                    nRegistros = int.Parse(result.ToString());
                }
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return nRegistros;
        }

        /// <summary>
        /// Este método obtiene todos los Usuarios de un Rol
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se desea cargar los registros de Auditoria</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se desea cargar los registros de Auditoria</param>
        /// <param name="rolId">Indica el id del Rol</param>
        /// <returns>Lista de Registros de Auditoria</returns>
        public List<Usuario> ObtenerTodosUsuariosXRol(int desde, int hasta, int rolId)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            if (rolId <= 0)
            {
                EVOException e = new EVOException(errores.errRolIdInValido);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosUsuariosXRol con los parámetros: desde: {0}, hasta: {1}, roldId:{2}", desde, hasta, rolId));

            DARol daRoles = new DARol();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            Rol rolBuscar = daRoles.ObtenerRolxId(rolId);

            if (rolBuscar == null)
            {
                EVOException e = new EVOException(errores.errRolNoExiste);

                logger.Error(e);

                throw e;
            }

            //Se válida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception)
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<Usuario> usuariosRol = null;

            try
            {
                usuariosRol = daRoles.ObtenerTodosUsuariosxRol(desde, hasta, rolId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return usuariosRol;
        }

        /// <summary>
        /// Este método obtiene todos los Usuarios de un Rol
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se desea cargar los registros de Auditoria</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se desea cargar los registros de Auditoria</param>
        /// <param name="rolId">Indica el id del Rol</param>
        /// <returns>Lista de Registros de Auditoria</returns>
        public List<Usuario> ObtenerTodosUsuariosxRolxFiltro(FiltroUsuario filtroUsuario)
        {
            if (filtroUsuario == null)
            {
                EVOException e = new EVOException(errores.erroFiltroUsuarioVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosUsuariosxRolxFiltro con los parámetros: {0}", JsonConvert.SerializeObject(filtroUsuario)));

            if (filtroUsuario.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtroUsuario.Hasta <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtroUsuario.Hasta < filtroUsuario.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            if (filtroUsuario.rolId <= 0)
            {
                EVOException e = new EVOException(errores.errRolIdInValido);

                logger.Error(e);

                throw e;
            }


            DARol daRoles = new DARol();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se válida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch (Exception)
            {
                EVOException e = new EVOException(string.Format(errores.errParametroGeneralNoNumerico, NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI.ToString()));

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtroUsuario.Hasta - filtroUsuario.Desde) > maximoPaginacion)
            {
                EVOException e = new EVOException(string.Format(errores.errPaginacionSuperada, maximoPaginacion));

                logger.Error(e);

                throw e;
            }

            List<Usuario> usuariosRol = null;

            try
            {
                usuariosRol = daRoles.ObtenerTodosUsuariosxRolxFiltro(filtroUsuario);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return usuariosRol;
        }

        /// <summary>
        /// Este método obtiene el número total de registros de la tabla de Roles
        /// </summary>
        /// <returns>Número total de registros</returns>
        public int ObtenerNumeroTotalRegistros()
        {
            logger.Info("Entró al método ObtenerNumeroTotalRegistros de BLRoles sin parámetros");

            var daRoles = new DARol();

            int numeroTotalRegistros = 0;

            try
            {
                numeroTotalRegistros = daRoles.ObtenerNumeroTotalRegistros();
            }
            catch
            {
                Exception e = new Exception(errores.errObtenerTotalRegistros);

                logger.Error(e);

                throw e;
            }

            return numeroTotalRegistros;
        }

        /// <summary>
        /// Este método obtiene un rol por su Id
        /// </summary>
        /// <param name="RolId">Id del Rol</param>
        /// <returns>Instacia de Rol</returns>
        public Rol ObtenerRolxId(int RolId)
        {
            if (RolId <= 0)
            {
                EVOException e = new EVOException(errores.errIdNegativo);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerRolxId con el parámetro: RolId = {0}",
           RolId));

            DARol daRoles = new DARol();

            var rolObtenido = daRoles.ObtenerRolxId(RolId);

            if (rolObtenido == null)
            {
                EVOException e = new EVOException(errores.errRolNoExiste);

                logger.Error(e);

                throw e;
            }

            Rol rol = daRoles.ObtenerRolxId(RolId);

            return rol;
        }

        /// <summary>
        /// Este método obtiene un rol por su Nombre
        /// </summary>
        /// <param name="nombre">Nombre del Rol</param>
        /// <returns>Instacia de Rol</returns>
        public Rol ObtenerRolxNombre(string nombre)
        {         
            if (string.IsNullOrWhiteSpace(nombre))
            {
                EVOException e = new EVOException(errores.errNombreRolVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerRolxNombre con el parámetro: nombre = {0}", nombre));


            var DARoles = new DARol();

            Rol rol = DARoles.ObtenerRolxNombre(nombre);

            if (rol == null)
            {
                EVOException e = new EVOException(errores.errRolNoExiste);

                logger.Error(e);

                throw e;
            }

            return rol;
        }

        /// <summary>
        /// Este método obtiene los roles creados en el sistema
        /// </summary>
        /// <param name="desde">Indica el número de registro desde el cuál se deben cargar los registros</param>
        /// <param name="hasta">Indica el número de registro hasta el cuál se deben cargar los registros</param>
        /// <returns>Lista de roles de tipo Rol</returns>
        public List<Rol> ObtenerTodosRoles(int desde, int hasta)
        {
            if (desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }            

            if (hasta < desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosRoles con los parámetros: Desde: {0}, Hasta: {1}",
               desde, hasta));

            DARol DARoles = new DARol();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                Exception e = new Exception(errores.errObtenerValorPorNombre);

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((hasta - desde) > maximoPaginacion)
            {
                string errorPaginacionExcedida = string.Format(errores.errPaginacionSuperada, maximoPaginacion);

                EVOException e = new EVOException(errorPaginacionExcedida);

                logger.Error(e);

                throw e;
            }

            List<Rol> listaRoles = null;

            try
            {
                listaRoles = DARoles.ObtenerTodosRoles(desde, hasta);
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                throw ex;
            }

            return listaRoles;
        }

        /// <summary>
        /// Este metodo obtiene todos los registros de Roles aplicando un filtro de búsqueda
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda sobre los Roles</param>
        /// <returns>Lista de Roles</returns>
        public List<Rol> ObtenerTodosRolesxFiltro(FiltroRol filtro)
        {
            if (filtro == null)
            {
                EVOException e = new EVOException(errores.errFiltroVacio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerTodosRolesxFiltro con los parámetros: {0}",
               JsonConvert.SerializeObject(filtro)));

            if (filtro.Desde <= 0)
            {
                EVOException e = new EVOException(errores.errParamDesdeCero);

                logger.Error(e);

                throw e;
            }

            if (filtro.Hasta < filtro.Desde)
            {
                EVOException e = new EVOException(errores.errParamHastaMenorDesde);

                logger.Error(e);

                throw e;
            }

            DARol daRoles = new DARol();
            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            //Se valida que no se estén pidiendo más registros que los que se encuentren actualmente configurados en la tabla de parámetros generales
            string valorPaginacion = null;

            try
            {
                valorPaginacion = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.TAMANHO_PAGINACION_WEBAPI);
            }
            catch
            {
                EVOException e = new EVOException(errores.errObtenerValorPorNombre);

                logger.Error(e);

                throw e;
            }

            int maximoPaginacion = int.Parse(valorPaginacion);

            if ((filtro.Hasta - filtro.Desde) > maximoPaginacion)
            {
                string errorPaginacionExcedida = string.Format(errores.errPaginacionSuperada, maximoPaginacion);

                EVOException e = new EVOException(errorPaginacionExcedida);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrWhiteSpace(filtro.Nombre))
            {
                EVOException e = new EVOException(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;
            }

            List<Rol> listaRoles = null;

            try
            {
                listaRoles = daRoles.ObtenerTodosRolesxFiltro(filtro);
            }
            catch
            {
                Exception e = new Exception(errores.errParametrosFiltroVacios);

                logger.Error(e);

                throw e;

            }

            return listaRoles;
        }

        /// <summary>
        /// Este método obtiene todos los roles por usuarioId
        /// </summary>
        /// <param name="UsuarioId">Id del usuario</param>
        /// <returns>Colección de instacias de negocio de Roles</returns>
        public List<Rol> ObtenerRolesxUsuarioId(int UsuarioId)
        {
            if (UsuarioId <= 0)
            {
                EVOException e = new EVOException(errores.errUsuarioIdNoExiste);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerRolesxUsuarioId con el parámetro: UsuarioId = {0}",
            UsuarioId));

            DARol dARoles = new DARol();

            List<Rol> roles = new List<Rol>();

            try
            {
                roles = dARoles.ObtenerRolesxUsuarioId(UsuarioId);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }           

            return roles;
        }

    }
}