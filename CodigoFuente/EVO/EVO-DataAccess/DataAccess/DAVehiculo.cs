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
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 18-Dic/2019
    /// Descripción      : Implementa el acceso a datos de los Vehiculos
    /// </summary>
    public class DAVehiculo : DABase
    {
        #region Métodos Públicos


        /// <summary>
        /// Actualizar el encabezado del viaje asociados en enrutamiento
        /// </summary>
        /// <param name="edicionVehiculoEnrutamiento">Solicitud de actualización de vehículo en enrutamiento</param>
        /// <response code="200">Devuelve boolenao con operación realizada con éxito</response>
        public bool ActualizarVehiculoEnrutamiento(ActualizarVehiculoEnrutamiento edicionVehiculoEnrutamiento)
        {
            EFVehiculoEntrega eFVehiculoEntrega = null;
            using (Contexto contexto = new Contexto())
            {
                using (var tran = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        eFVehiculoEntrega = contexto.VehiculoEntregas                                               
                            .FirstOrDefault(ve => ve.VehiculoEntregaId == edicionVehiculoEnrutamiento.VehiculoEntregaId);

                        eFVehiculoEntrega.VehiculoId = edicionVehiculoEnrutamiento.VehiculoId;
                        eFVehiculoEntrega.UsuarioId = edicionVehiculoEnrutamiento.UsuarioId;
                        eFVehiculoEntrega.ConductorId = edicionVehiculoEnrutamiento.ConductorId;
                        eFVehiculoEntrega.AuxiliarId = edicionVehiculoEnrutamiento.AuxiliarId;
                        eFVehiculoEntrega.MuelleId = edicionVehiculoEnrutamiento.MuelleId;
                        eFVehiculoEntrega.FechaRegistro = edicionVehiculoEnrutamiento.FechaRegistro;
                        contexto.Update(eFVehiculoEntrega);
                        contexto.SaveChanges();
                        tran.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene una lista de muelles 
        /// </summary>  
        /// <returns>Lista de Muelles</returns>
        public List<MuelleRespuesta> ObtenerMuelles()
        {
            List<EFMuelle> eFMuelles = null;
            using (Contexto contexto = new Contexto())
            {
                eFMuelles = contexto.Muelles.Where(m => m.Activo).ToList();
            }
            List<MuelleRespuesta> muelles = null;
            if (eFMuelles.Count > 0)
            {
                muelles = this.mapper.Map<List<EFMuelle>, List<MuelleRespuesta>>(eFMuelles);
            }
            return muelles;
        }

        /// <summary>
        /// Este método obtiene tipos de vehiculos
        /// </summary>      
        /// <returns>Lista de tipo TipoVehiculoRespuesta</returns>
        /// 
        public List<TipoVehiculoRespuesta> ObtenerTipoVehiculo()
        {
            List<EFTipoVehiculo> eFTiposVehiculo = new List<EFTipoVehiculo>();

            using (Contexto contexto = new Contexto())
            {
                eFTiposVehiculo = contexto.TiposVehiculo.Where(t => t.Activo).ToList();
            }

            List<TipoVehiculoRespuesta> tiposVehiculo = this.mapper.Map<List<EFTipoVehiculo>, List<TipoVehiculoRespuesta>>(eFTiposVehiculo);

            return tiposVehiculo;

        }

        /// <summary>
        /// Obtiene los tipos de vehiculos capaces de llevar la entrega
        /// </summary>
        /// <param name="cantidad">599095</param>
        /// <response>Lista de negocio de tipo TipoVehiculoRespuesta </response>
        public List<TipoVehiculoRespuesta> ObtenerTiposVehiculosFiltrados(decimal cantidad)
        {
            List<EFTipoVehiculo> eFTiposVehiculo = new List<EFTipoVehiculo>();

            using (Contexto contexto = new Contexto())
            {
                eFTiposVehiculo = contexto.TiposVehiculo.Where(t => t.Activo && t.Capacidad>=cantidad).ToList();
            }

            List<TipoVehiculoRespuesta> tiposVehiculo = this.mapper.Map<List<EFTipoVehiculo>, List<TipoVehiculoRespuesta>>(eFTiposVehiculo);

            return tiposVehiculo;

        }

        /// <summary>
        /// Obtiene los vehiculos por tipo
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista de tipo VehiculoRespuesta</returns>
        public List<VehiculoRespuesta> ObtenerVehiculosxTipo(int id)
        {
            List<EFVehiculo> eFVehiculos = new List<EFVehiculo>();

            using (Contexto contexto = new Contexto())
            {
                eFVehiculos = contexto.Vehiculo.Where(v => v.Activo && v.TipoVehiculoId == id).ToList();
            }

            List<VehiculoRespuesta> vehiculos = this.mapper.Map<List<EFVehiculo>, List<VehiculoRespuesta>>(eFVehiculos);

            return vehiculos;
        }

        public List<Empleado> ObtenerConductoresAuxiliares()
        {
            List<EFEmpleado> eFEmpleados = new List<EFEmpleado>();

            using (Contexto contexto = new Contexto())
            {
                eFEmpleados = contexto.Empleados.Where(t => t.Activo && (t.Cargo == CargosEnum.Auxiliar.ToString() || t.Cargo == CargosEnum.Conductor.ToString())).ToList();
            }

            List<Empleado> empleados = this.mapper.Map<List<EFEmpleado>, List<Empleado>>(eFEmpleados);

            return empleados;
        }



        /// <summary>
        /// Obtiene un vehiculo por el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto de tipo VehiculoRespuesta</returns>
        public VehiculoRespuesta ObtenerVehiculoxId(int id)
        {
            EFVehiculo eFVehiculo = null;

            using (Contexto contexto = new Contexto())
            {
                eFVehiculo = contexto.Vehiculo.Include(d => d.TipoVehiculo).FirstOrDefault(v => v.VehiculoId == id);
            }

            VehiculoRespuesta vehiculo = null;

            if (eFVehiculo != null)
            {
                vehiculo = this.mapper.Map<EFVehiculo, VehiculoRespuesta>(eFVehiculo);
            }

            return vehiculo;

        }

        public Empleado ObtenerConductorAuxiliarxid(int id)
        {
            EFEmpleado eFEmpleado = null;

            using (Contexto contexto = new Contexto())
            {
                eFEmpleado = contexto.Empleados.FirstOrDefault(v => v.EmpleadoId == id);
            }

            Empleado empleado = null;

            if (eFEmpleado != null)
            {
                empleado = this.mapper.Map<EFEmpleado, Empleado>(eFEmpleado);
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
            List<VehiculoEnrutamientoRespuesta> vehiculosEnrutamientoRespuesta = new List<VehiculoEnrutamientoRespuesta>();

            using (Contexto contexto = new Contexto())
            {
                vehiculosEnrutamientoRespuesta = contexto.VehiculoEntregas.Include(v => v.Vehiculo.TipoVehiculo)
                    .Select(v => new VehiculoEnrutamientoRespuesta()
                    {
                        TipoVehiculoId = v.Vehiculo.TipoVehiculoId,
                        VehiculoId = v.VehiculoId,
                        MuelleId = v.MuelleId,
                        ConductorId = v.ConductorId,
                        AuxiliarId = v.AuxiliarId

                    }).ToList();
            }

            return vehiculosEnrutamientoRespuesta;
        }
        #endregion
    }
}
