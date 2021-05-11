using EVO_PV_BusinessObjects;
using EVO_PV_BusinessObjects.Exceptions;
using EVO_PV_Proxy;
using System;
using System.Threading.Tasks;

namespace EVO_PV_BusinessLogic
{
    public class UsuarioBL
    {
        UsuarioProxy articuloProxy;

        public UsuarioBL()
        {
            this.articuloProxy = new UsuarioProxy();
        }

        /// <summary>
        /// Devuelve el usuario de EVO
        /// </summary>
        /// <returns>Usuario</returns>
        public async Task<Usuario> ObtenerUsuario()
        {
            try
            {
                Usuario usuario = await articuloProxy.ObtenerUsuario();

                return usuario;
            }
            catch (EVOException e)
            {
                throw e;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /// <summary>
        /// Llama al proxy de usuario, metodo obtener nombre usuario string
        /// </summary>
        /// <returns></returns>
        public async Task<string> ObtenerNombreUsuarioString()
        {
            return await articuloProxy.ObtenerNombreUsuarioString();
        }

    }
}
