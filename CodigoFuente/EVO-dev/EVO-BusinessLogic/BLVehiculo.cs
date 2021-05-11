using EVO_BusinessObjects;
using EVO_BusinessObjects.Exceptions;
using EVO_DataAccess.DataAccess;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;

namespace EVO_BusinessLogic
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 18-Dic/2019
    /// Descripción      : Esta clase implementa los métodos de lógica de vehiculos
    /// </summary>
    public class BLVehiculo
    {
        #region Campos Privados
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Actualizar el encabezado del viaje asociados en enrutamiento
        /// </summary>
        /// <param name="edicionVehiculoEnrutamiento">Solicitud de actualización de vehículo en enrutamiento</param>
        /// <response code="200">Devuelve boolenao con operación realizada con éxito</response>
        public object ActualizarVehiculoEnrutamiento(ActualizarVehiculoEnrutamiento edicionVehiculoEnrutamiento)
        {
            logger.Info($"Entró al método ActualizarVehiculoEnrutamiento en blVehiculos con los parámetros {JsonConvert.SerializeObject(edicionVehiculoEnrutamiento)}");

            if (edicionVehiculoEnrutamiento == null)
            {
                EVOException e = new EVOException(errores.errActualizarVehiculoNoInformada);
                logger.Error(e);
                throw e;
            }
            BLVehiculo bLVehiculos = new BLVehiculo();
            if (edicionVehiculoEnrutamiento.AuxiliarId <= 0)
            {
                EVOException e = new EVOException(errores.errAuxiliarIdNoInformada);
                logger.Error(e);
                throw e;
            }
            if (edicionVehiculoEnrutamiento.MuelleId <= 0)
            {
                EVOException e = new EVOException(errores.errMuelleIdIdNoInformado);
                logger.Error(e);
                throw e;
            }
            Empleado auxiliar = null;
            Empleado conductor = null;
            try
            {
                auxiliar = bLVehiculos.ObtenerConductorAuxiliarxId(edicionVehiculoEnrutamiento.AuxiliarId);
            }
            catch (EVOException e)
            {
                logger.Error(e);
                throw e;
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
            if (auxiliar == null)
            {
                EVOException e = new EVOException(errores.errAuxiliarNoRegistrado);
                logger.Error(e);
                throw e;
            }

            if (edicionVehiculoEnrutamiento.ConductorId <= 0)
            {
                EVOException e = new EVOException(errores.errConductorIdNoInformada);
                logger.Error(e);
                throw e;
            }

            if (edicionVehiculoEnrutamiento.ConductorId == edicionVehiculoEnrutamiento.AuxiliarId)
            {
                EVOException e = new EVOException(errores.errConductorAuxiliarIgual);
                logger.Error(e);
                throw e;
            }
            try
            {
                conductor = bLVehiculos.ObtenerConductorAuxiliarxId(edicionVehiculoEnrutamiento.ConductorId);
            }
            catch (EVOException e)
            {
                logger.Error(e);
                throw e;
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }

            if (conductor == null)
            {
                EVOException e = new EVOException(errores.errConductorNoRegistrado);
                logger.Error(e);
                throw e;
            }

            if (conductor.Cargo == auxiliar.Cargo)
            {
                EVOException e = new EVOException(errores.errEmpleadosMismoCargo);
                logger.Error(e);
                throw e;
            }

            if (string.IsNullOrEmpty(edicionVehiculoEnrutamiento.Usuario))
            {
                EVOException e = new EVOException(errores.errUsuarioNoInformado);
                logger.Error(e);
                throw e;
            }

            int nBackSlash = edicionVehiculoEnrutamiento.Usuario.IndexOf(@"\");
            //Si el usuario viene en formato DOMINIO\USUARIO, se debe dejar solo el USUARIO
            if (nBackSlash > 0)
            {
                edicionVehiculoEnrutamiento.Usuario = edicionVehiculoEnrutamiento.Usuario.Substring(nBackSlash + 1, edicionVehiculoEnrutamiento.Usuario.Length - nBackSlash - 1);
            }
            BLUsuario bLUsuarios = new BLUsuario();
            Usuario usuario = null;
            try
            {
                usuario = bLUsuarios.ObtenerUsuarioPorUsuario(edicionVehiculoEnrutamiento.Usuario);
            }
            catch (EVOException e)
            {
                logger.Error(e);
                throw e;
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
            edicionVehiculoEnrutamiento.UsuarioId = usuario.UsuarioId;
            if (edicionVehiculoEnrutamiento.VehiculoId <= 0)
            {
                EVOException e = new EVOException(errores.errVehiculoIdNoInformado);
                logger.Error(e);
                throw e;
            }
            VehiculoRespuesta vehiculo = bLVehiculos.ObtenerVehiculoxId(edicionVehiculoEnrutamiento.VehiculoId);
            if (vehiculo == null)
            {
                EVOException e = new EVOException(errores.errVehiculoNoRegistrado);
                logger.Error(e);
                throw e;
            }

            DAVehiculo dAVehiculos = new DAVehiculo();
            edicionVehiculoEnrutamiento.FechaRegistro = DateTime.Now;
            bool respuesta = false;
            try
            {
                respuesta = dAVehiculos.ActualizarVehiculoEnrutamiento(edicionVehiculoEnrutamiento);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }
            return true;
        }

        /// <summary>
        /// Obtiene una lista de muelles 
        /// </summary>  
        /// <returns>Lista de Muelles</returns>
        public List<MuelleRespuesta> ObtenerMuelles()
        {
            logger.Info($"Entró al método ObtenerMuelles en blMuelles.");
            DAVehiculo daMuelles = new DAVehiculo();
            List<MuelleRespuesta> muelles = new List<MuelleRespuesta>();
            try
            {
                muelles = daMuelles.ObtenerMuelles();
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw e;
            }
            return muelles;
        }

        /// <summary>
        /// Este método obtiene todos los tipos de vehiculos
        /// </summary>
        /// <returns>Lista de TipoVehiculoRespuesta</returns>
        public List<TipoVehiculoRespuesta> ObtenerTipoVehiculo()
        {
            logger.Info("Entró al método ObtenerTipoVehiculo en BO Vehiculos");

            DAVehiculo dAVehiculos = new DAVehiculo();

            List<TipoVehiculoRespuesta> tiposVehiculo = null;

            try
            {
                tiposVehiculo = dAVehiculos.ObtenerTipoVehiculo();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return tiposVehiculo;
        }

        /// <summary>
        /// Obtiene los tipos de vehiculos capaces de llevar la entrega
        /// </summary>
        /// <param name="cantidad">599095</param>
        /// <response>Lista de negocio de tipo TipoVehiculoRespuesta </response>
        public List<TipoVehiculoRespuesta> ObtenerTiposVehiculosFiltrados(decimal cantidad)
        {
            logger.Info($"Entró al método ObtenerTiposVehiculosFiltrados en BO Vehiculos con el parámetro cantidad = {cantidad}");

            if (cantidad <= 0)
            {
                EVOException e = new EVOException(errores.errCantidadEntregaCeroNegativa);

                logger.Error(e);

                throw e;
            }

            DAVehiculo dAVehiculos = new DAVehiculo();

            List<TipoVehiculoRespuesta> tiposVehiculo = null;

            try
            {
                tiposVehiculo = dAVehiculos.ObtenerTiposVehiculosFiltrados(cantidad);
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return tiposVehiculo;
        }

        /// <summary>
        /// Obtiene los vehiculos por tipo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista de tipo VehiculoRespuesta</returns>
        public List<VehiculoRespuesta> ObtenerVehiculosxTipo(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errVehiculoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerVehiculoxTipo en BLVehiculos con el parámetro: id: {id}");

            DAVehiculo dAVehiculos = new DAVehiculo();

            List<VehiculoRespuesta> vehiculos;

            try
            {
                vehiculos = dAVehiculos.ObtenerVehiculosxTipo(id);

            }
            catch (Exception e)
            {
                throw e;
            }

            return vehiculos;
        }

        /// <summary>
        /// Este método obtiene todos los empleados tipo Conductores o Auxiliares
        /// </summary>
        /// <returns>Lista de TipoVehiculoRespuesta</returns>
        public List<Empleado> ObtenerConductoresAuxiliares()
        {
            logger.Info("Entró al método ObtenerConductoresAuxiliares en BO Vehiculos");

            DAVehiculo dAVehiculos = new DAVehiculo();

            List<Empleado> empleados = null;

            try
            {
                empleados = dAVehiculos.ObtenerConductoresAuxiliares();
            }
            catch (Exception e)
            {
                logger.Error(e);

                throw e;
            }

            return empleados;
        }


        /// <summary>
        /// Obtiene un vehiculo por el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto de tipo VehiculoRespuesta</returns>
        public VehiculoRespuesta ObtenerVehiculoxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errVehiculoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerVehiculoxId en BLVehiculos con el parámetro: id: {id}");

            DAVehiculo dAVehiculos = new DAVehiculo();

            VehiculoRespuesta vehiculo;

            try
            {
                vehiculo = dAVehiculos.ObtenerVehiculoxId(id);

            }
            catch (Exception e)
            {
                throw e;
            }

            return vehiculo;
        }


        /// <summary>
        /// Obtiene un condutor o un auxiliar por el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto de tipo Empleado</returns>
        public Empleado ObtenerConductorAuxiliarxId(int id)
        {
            if (id <= 0)
            {
                EVOException e = new EVOException(errores.errEmpleadoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerVehiculoxId en BLVehiculos con el parámetro: id: {id}");

            DAVehiculo dAVehiculos = new DAVehiculo();

            Empleado empleado;

            try
            {
                empleado = dAVehiculos.ObtenerConductorAuxiliarxid(id);

            }
            catch (Exception e)
            {
                throw e;
            }

            return empleado;
        }

        ///<summary>
        ///Obtiene el estado actual del vehiculo, conductor, auxiliar y muelle en enrutamiento
        ///</summary>
        ///<param name = "vehiculoEntregaId">Indica el id del viaje</param>
        ///<response >List<VehiculoEnrutamientoRespuesta></response>
        public List<VehiculoEnrutamientoRespuesta> ObtenerVehiculoEnrutamiento(int vehiculoEntregaId)
        {
            if (vehiculoEntregaId <= 0)
            {
                EVOException e = new EVOException(errores.errVehiculoIdNoInformado);

                logger.Error(e);

                throw e;
            }

            logger.Info($"Entró al método ObtenerVehiculoEnrutamiento en BLVehiculos con el parámetro: id: {vehiculoEntregaId}");


            DAVehiculo dAVehiculos = new DAVehiculo();

            return dAVehiculos.ObtenerVehiculoEnrutamiento(vehiculoEntregaId);
        }




        #endregion
    }
}
