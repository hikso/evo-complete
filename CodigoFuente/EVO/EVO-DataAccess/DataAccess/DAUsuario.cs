using EVO_BusinessObjects;
using EVO_DataAccess.Context;
using EVO_DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EVO_DataAccess.DataAccess
{
    /// <summary>
    /// Autor            : Kevin Restrepo Giraldo
    /// Fecha de Creación: 02-Ago/2019
    /// Descripción      : Acceso a datos de Usuarios
    /// </summary>
    public class DAUsuario : DABase
    {
        #region Métodos Públicos
        /// <summary>
        /// Este método obtiene un Usuario por su id
        /// <param name="usuarioId">id del Usuario. Ej: 1</param>
        /// <returns>Instancia de un usuario</returns>
        public Usuario ObtenerUsuarioPorId(int usuarioId)
        {
            using (var contexto = new Contexto())
            {
                EFUsuario usuarioPorUsuario = contexto.Usuarios.FirstOrDefault(x => x.UsuarioId == usuarioId && x.Activo);

                if (usuarioPorUsuario != null)
                {
                    Usuario usuario = this.mapper.Map<EFUsuario, Usuario>(usuarioPorUsuario);

                    return usuario;
                }

                return null;
            }
        }

        /// <summary>
        /// Este método obtiene un usuario por su nombre de usuario
        /// </summary>
        /// <param name="Usuario">Nombre de usuario. Ej: KRestrepo</param>
        /// <returns>Instancia de un usuario</returns>
        public Usuario ObtenerUsuarioPorUsuario(string Usuario)
        {
            using (var contexto = new Contexto())
            {
                var usuarioPorUsuario = contexto.Usuarios.Where(x => x.Usuario == Usuario && x.Activo).FirstOrDefault();

                if (usuarioPorUsuario != null)
                {
                    Usuario usuario = this.mapper.Map<EFUsuario,Usuario>(usuarioPorUsuario);

                    return usuario;
                }

                return null;
            }
        }

        /// <summary>
        /// Este método registra un usuario
        /// </summary>
        /// <param name="Usuario">Instancia de usuario a registrar</param>
        /// <returns>Retorna true si todo salio bien de lo contrario false</returns>
        public bool RegistrarUsuario(Usuario usuario)
        {
            using (var contexto = new Contexto())
            {
                EFUsuario efUsuario = this.mapper.Map<Usuario, EFUsuario>(usuario);

                efUsuario.Activo = true;

                contexto.Add(efUsuario);

                contexto.SaveChanges();
            }

            return true;
        }

        /// <summary>
        /// Este método retorna todos los usuarios
        /// </summary>      
        /// <returns>Retorna una lista de objeto de negocio usuario</returns>
        public List<Usuario> ObtenerTodosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (Contexto contexto = new Contexto())
            {
                List<EFUsuario> efUsuarios = contexto.Usuarios.ToList();

                if (contexto.Usuarios.Count() == 0)
                {
                    return usuarios;
                }

                usuarios = this.mapper.Map<List<EFUsuario>, List<Usuario>>(efUsuarios);

                return usuarios;
            }
        }
        #endregion
    }
}