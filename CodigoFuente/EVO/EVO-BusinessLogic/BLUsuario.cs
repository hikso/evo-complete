using EVO_BusinessObjects;
using EVO_BusinessObjects.Enum;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using NLog;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 02-Ago/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de negocios de Usuarios
    /// </summary>
    /// 
    public class BLUsuario
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Este mètodo indica si el usuario existe en el sistema
        /// </summary>
        /// <param name="nombreUsuario">Nombre de Usuario</param>
        /// <returns>Verdadero si el usuario existe, falso de lo contrario</returns>
        public bool ExisteUsuario(string nombreUsuario)
        {
            if (string.IsNullOrEmpty(nombreUsuario))
            {//Hola

                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ExisteUsuario con el parámetro: nombreUsuario = {0}",
             nombreUsuario));

            var DaUsuario = new DAUsuario();

            var obtenerUsuario = DaUsuario.ObtenerUsuarioPorUsuario(nombreUsuario);

            return (obtenerUsuario != null);
        }

        /// <summary>
        /// Este método retorna una instancia de un Usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre de Usuario</param>
        /// <returns>Instancia de objeto de tipo Usuario</returns>
        public Usuario ObtenerUsuarioPorUsuario(string nombreUsuario)
        {
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerUsuarioPorUsuario con el parámetro: nombreUsuario = {0}",
             nombreUsuario));

            var DaUsuario = new DAUsuario();

            var obtenerUsuario = DaUsuario.ObtenerUsuarioPorUsuario(nombreUsuario);

            if (obtenerUsuario == null)
            {
                EVOException e = new EVOException(errores.errUsuarioNoRegistrado);

                logger.Error(e);

                throw e;
            }

            return obtenerUsuario;
        }

        /// <summary>
        /// Verifica si el usuario puede entrar al punto de venta
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="iP">IP</param>
        /// <response>boolean</response>
        private bool AccesoPuntoVenta(int usuarioId, string iP)
        {

            if (usuarioId == 0)
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(iP))
            {
                EVOException e = new EVOException(errores.errIPNoInformada);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al metodo AccesoPuntoVenta en EVO_WevApi - EVO_BusinessLogic con los parametros : usuarioId={usuarioId} , iP={iP}");

            BLBodega bLBodega = new BLBodega();

            List<BOBodega> bodegasPV = bLBodega.ObtenerBodegasPuntosVentaPorUsuarioId(usuarioId);

            if (bodegasPV.Count == 0)
            {
                return false;
            }

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string codigoPuntoVentaComercial = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.CODIGO_PUNTO_VENTA_COMERCIAL);
            
            if (bodegasPV.FirstOrDefault(b => b.WhsCode == codigoPuntoVentaComercial) != null)
            {
                return true;
            }

            BLCajas bLCajas = new BLCajas();

            foreach (BOBodega bodegaPV in bodegasPV)
            {
                BOCaja caja = bLCajas.ObtenerCaja(bodegaPV.WhsCode, iP);

                if (caja!=null)
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Retorna el usuario si tiene accesso al punto de venta en el cual está registrado(caso especial punto de venta comercial) .
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="iP">IP</param>
        /// <respons>Objeto de negogico de tipo Usuario</response>
        public Usuario ObtenerUsuarioPuntoVenta(string userName, string iP)
        {
            logger.Info($"Entró al metodo ObtenerUsuarioPuntoVenta en EVO_WevApi - EVO_BusinessLogic con los parametros : username={userName} , ip={iP}");

            if (string.IsNullOrEmpty(userName))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);

                logger.Error(e);

                throw e;
            }

            if (string.IsNullOrEmpty(iP))
            {
                EVOException e = new EVOException(errores.errIPNoInformada);

                logger.Error(e);

                throw e;
            }

            int nBackSlash = userName.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                userName = userName.Substring(nBackSlash + 1, userName.Length - nBackSlash - 1);
            }

            var DaUsuario = new DAUsuario();

            Usuario obtenerUsuario;

            try
            {
                obtenerUsuario = DaUsuario.ObtenerUsuarioPorUsuario(userName);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (obtenerUsuario == null)
            {
                EVOException e = new EVOException(errores.errUsuarioNoEVO);

                logger.Error(e);

                throw e;
            }

            BLRol bLRoles = new BLRol();

            List<Rol> roles = new List<Rol>();            

            if (AccesoPuntoVenta(obtenerUsuario.UsuarioId,iP))
            {
                try
                {
                    roles = bLRoles.ObtenerRolesxUsuarioId(obtenerUsuario.UsuarioId);
                }
                catch (EVOException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    throw e;
                }

                if (roles.Count == 0)
                {
                    EVOException e = new EVOException(errores.errUsuarioNoRoles);

                    logger.Error(e);

                    throw e;
                }

                obtenerUsuario.Cargos = roles.Select(r => r.Nombre).ToList();
            }
            else
            {
                obtenerUsuario = null;
            }           

            return obtenerUsuario;
        }

        /// <summary>
        /// Este método retorna una instancia de un Usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre de Usuario</param>
        /// <returns>Instancia de objeto de tipo Usuario</returns>
        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoDirectorio);

                logger.Error(e);

                throw e;
            }

            logger.Info(string.Format("Entró al método ObtenerUsuario con el parámetro: nombreUsuario = {0}",
             nombreUsuario));

            int nBackSlash = nombreUsuario.IndexOf(@"\");

            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                nombreUsuario = nombreUsuario.Substring(nBackSlash + 1, nombreUsuario.Length - nBackSlash - 1);
            }

            var DaUsuario = new DAUsuario();

            Usuario obtenerUsuario;

            try
            {
                obtenerUsuario = DaUsuario.ObtenerUsuarioPorUsuario(nombreUsuario);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            if (obtenerUsuario == null)
            {
                EVOException e = new EVOException(errores.errUsuarioNoEVO);

                logger.Error(e);

                throw e;
            }

            BLRol bLRoles = new BLRol();

            List<Rol> roles = new List<Rol>();

            try
            {
                roles = bLRoles.ObtenerRolesxUsuarioId(obtenerUsuario.UsuarioId);
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }

            if (roles.Count == 0)
            {
                EVOException e = new EVOException(errores.errUsuarioNoRoles);

                logger.Error(e);

                throw e;
            }

            obtenerUsuario.Cargos = roles.Select(r => r.Nombre).ToList();

            return obtenerUsuario;

        }

        /// <summary>
        /// Busca los usuarios de un grupo especifico del dominio menos los usuarios de dicho rol
        /// </summary>        
        /// <returns>Retorna una colección de usuarios de un grupo del dominio menos usuario de un rol</returns>
        public List<Usuario> ObtenerTodosUsuariosGrupoDominioMenosRol(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errRolIdInValido);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerTodosUsuariosGrupoDominioMenosRol con el parámetro id = {id}");

            BLRol blRoles = new BLRol();

            Rol rolEncontrado = blRoles.ObtenerRolxId(id);

            if (rolEncontrado == null)
            {
                EVOException e = new EVOException(errores.errRolNoExiste);

                logger.Error(e);

                throw e;
            }

            List<Usuario> usuariosGrupoDominio = ObtenerTodosUsuariosDominio();
            List<Usuario> usuariosRol = rolEncontrado.Usuarios;
            List<Usuario> usuariosGruposDominioMenosRol = new List<Usuario>();

            DAUsuario dAUsuarios = new DAUsuario();

            List<Usuario> usuariosInactivos = dAUsuarios.ObtenerTodosUsuarios().Where(u => !u.Activo).ToList();

            foreach (Usuario usuarioInactivo in usuariosInactivos)
            {
                usuariosGrupoDominio.RemoveAll(u => u.NombreUsuario == usuarioInactivo.NombreUsuario);
            }

            foreach (var usuarioGrupoDominio in usuariosGrupoDominio)
            {
                if (usuariosRol.FirstOrDefault(x => x.NombreUsuario == usuarioGrupoDominio.NombreUsuario) == null)
                {
                    usuariosGruposDominioMenosRol.Add(usuarioGrupoDominio);
                }
            }
            return usuariosGruposDominioMenosRol;
        }

        /// <summary>
        /// Busca los usuarios de un grupo especifico del dominio
        /// </summary>        
        /// <returns>Retorna una colección de usuarios de un grupo del dominio</returns>
        public List<Usuario> ObtenerTodosUsuariosDominio()
        {
            logger.Info("Entró al método ObtenerTodosUsuariosDominio sin parámetros");

            BLParametroGeneral blParametrosGenerales = new BLParametroGeneral();

            string nombreDominio = string.Empty;
            string nombreGrupoDominio = string.Empty;

            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                nombreDominio = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.NOMBRE_DOMINIO);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            try
            {
                nombreGrupoDominio = blParametrosGenerales.ObtenerValorPorNombre(NombresParametrosGeneralesEnum.NOMBRE_GRUPO_DOMINIO);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry($"LDAP://DC={nombreDominio},DC=local");
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
                directorySearcher.Filter = "(&(objectClass=user)(objectCategory=person))";

                directorySearcher.PropertiesToLoad.Add("samaccountname");
                directorySearcher.PropertiesToLoad.Add("displayname");

                SearchResultCollection searchResultCollection = directorySearcher.FindAll();

                if (searchResultCollection != null)
                {
                    for (int i = 0; i < searchResultCollection.Count; i++)
                    {
                        SearchResult searchResult = searchResultCollection[i];

                        if (searchResult.Properties.Contains("samaccountname") && searchResult.Properties.Contains("displayname"))
                        {
                            Usuario usuario = new Usuario()
                            {
                                NombreUsuario = (string)searchResult.Properties["samaccountname"][0],
                                Nombre = (string)searchResult.Properties["displayname"][0]
                            };

                            usuarios.Add(usuario);

                        }
                    }
                }

                directorySearcher.Dispose();
                searchResultCollection.Dispose();

                return usuarios;
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
        }
        #endregion
    }
}
