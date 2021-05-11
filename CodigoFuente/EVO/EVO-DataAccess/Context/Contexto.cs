using EVO_DataAccess.Entities;
using EVO_DataAccess.Utils;
using Microsoft.EntityFrameworkCore;

namespace EVO_DataAccess.Context
{
    /// <summary>
    /// Autor            : Juan Camilo Usuga Sepúlveda
    /// Fecha de Creación: 02-Ago/2019
    /// Descripción      : Se crea la clase que tendra el contexto de la BD
    /// </summary>
    public class Contexto : DbContext
    {
        #region Eventos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EFArticuloBodega>().HasKey(o => new { o.ItemCode, o.WhsCode });
        }
        /// <summary>
        /// Se realiza la conexion con la BD 
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppConfiguration appConfig = new AppConfiguration();

            //Se obtiene la cadena de conexión del archivo appSettings.json del proyecto EVO-WebApi
            string connectionStringEVO = appConfig.ConnectionString["EVO"];

            optionsBuilder.UseSqlServer(connectionStringEVO);
        }
        #endregion

        #region DbSets
        /// <summary>
        /// Tabla de Registros de Auditoria
        /// </summary>
        public virtual DbSet<EFRegistroAuditoria> RegistrosAuditoria { get; set; }

        /// <summary>
        /// Tabla de Parámetros Generales del Sistema
        /// </summary>
        public virtual DbSet<EFParametroGeneral> ParametrosGenerales { get; set; }

        /// <summary>
        /// Tabla de Usuarios del sistema
        /// </summary>
        public virtual DbSet<EFUsuario> Usuarios { get; set; }

        /// <summary>
        /// Tabla de relación entre Usuarios y Roles
        /// </summary>
        public virtual DbSet<EFUsuariosxRol> UsuariosxRol { get; set; }

        /// <summary>
        /// Tabla de Roles del sistema
        /// </summary>
        public virtual DbSet<EFRol> Roles { get; set; }

        /// <summary>
        /// Tabla de Módulos del sistema
        /// </summary>
        public virtual DbSet<EFModulo> Modulos { get; set; }

        /// <summary>
        /// Tabla de funcionalidades del sistema
        /// </summary>
        public virtual DbSet<EFFuncionalidad> Funcionalidades { get; set; }

        /// <summary>
        /// Tabla de las funcionalidades de los roles
        /// </summary>
        public virtual DbSet<EFFuncionalidadesxRol> FuncionalidadesxRol { get; set; }

        /// <summary>
        /// Tabla de las sesiones de los usuarios
        /// </summary>
        public virtual DbSet<EFSesion> Sesiones { get; set; }

        /// <summary>
        /// Tabla de las bodegas
        /// </summary>
        public virtual DbSet<EFBodega> Bodegas { get; set; }

        /// <summary>
        /// Tabla de los pedidos
        /// </summary>
        public virtual DbSet<EFPedido> Pedidos { get; set; }

        /// <summary>
        /// Tabla de los detalles pedidos
        /// </summary>
        public virtual DbSet<EFDetallePedido> DetallesPedido { get; set; }

        /// <summary>
        /// Tabla de los detalles pedidos
        /// </summary>
        public virtual DbSet<EFEstadoPedido> EstadosXPedido { get; set; }

        /// <summary>
        /// Tabla de los detalles pedidos
        /// </summary>
        public virtual DbSet<EFEstadoArticulo> EstadosArticulo { get; set; }

        /// <summary>
        /// Tabla de las unidades de medida
        /// </summary>
        public virtual DbSet<EFArticuloBodega> ArticulosXBodega { get; set; }

        /// <summary>
        /// Tabla de los artículos
        /// </summary>
        public virtual DbSet<EFArticulo> Articulos { get; set; }

        /// <summary>
        /// Tabla de los Log Integración
        /// </summary>
        public virtual DbSet<EFLogIntegracion> LogsIntegracion { get; set; }

        /// <summary>
        /// Tabla de Clientes Externos
        /// </summary>
        public virtual DbSet<EFClienteExterno> ClientesExternos { get; set; }

        /// <summary>
        /// Tabla de Entregas
        /// </summary>
        public virtual DbSet<EFEntrega> Entregas { get; set; }

        /// <summary>
        /// Tabla de Detalle Entregas
        /// </summary>
        public virtual DbSet<EFDetalleEntrega> DetalleEntregas { get; set; }

        /// <summary>
        /// Tabla de motivos de edición de entregas
        /// </summary>
        public virtual DbSet<EFMotivo> Motivos { get; set; }

        /// <summary>
        /// Tabla de tipos de vehiculos
        /// </summary>
        public virtual DbSet<EFTipoVehiculo> TiposVehiculo { get; set; }

        /// <summary>
        /// Tabla de vehiculos
        /// </summary>
        public virtual DbSet<EFVehiculo> Vehiculo { get; set; }

        /// <summary>
        /// Tabla de Conductores y Auxiliares
        /// </summary>
        public virtual DbSet<EFEmpleado> Empleados { get; set; }

        /// <summary>
        /// Tabla Vehiculo Entregas
        /// </summary>
        public virtual DbSet<EFVehiculoEntrega> VehiculoEntregas { get; set; }

        /// <summary>
        /// Tabla Vehiculo Entregas Detalles
        /// </summary>
        public virtual DbSet<EFVehiculoEntregaDetalle> VehiculoEntregasDetalles { get; set; }

        /// <summary>
        /// Tabla Procesos
        /// </summary>
        public virtual DbSet<EFProceso> Procesos { get; set; }

        /// <summary>
        /// Tabla Procesos
        /// </summary>
        public virtual DbSet<EFMotivoProceso> MotivosProcesos { get; set; }

        /// <summary>
        /// Tabla Muelles
        /// </summary>
        public virtual DbSet<EFMuelle> Muelles { get; set; }       

        /// <summary>
        /// Tabla TiposContenedor
        /// </summary>
        public virtual DbSet<EFTipoContenedor> TiposContenedor { get; set; }

        /// <summary>
        /// Tabla TiposBascula
        /// </summary>
        public virtual DbSet<EFTipoBascula> TiposBascula { get; set; }       

        /// <summary>
        /// Tabla EstadosEntrega
        /// </summary>
        public virtual DbSet<EFEstadoEntrega> EstadosEntrega { get; set; }

        /// <summary>
        /// Tabla PesajesTolerancia
        /// </summary>
        public virtual DbSet<EFClienteParametrizacion> ClientesParametrizacion { get; set; }

        /// <summary>
        /// Tabla PesajesEntrega
        /// </summary>
        public virtual DbSet<EFPesajeEntrega> PesajesEntrega { get; set; }

        /// <summary>
        /// Tabla PesajesArticulo
        /// </summary>
        public virtual DbSet<EFPesajeArticulo> PesajesArticulo { get; set; }

        /// <summary>
        /// Tabla Pesajes
        /// </summary>
        public virtual DbSet<EFPesaje> Pesajes { get; set; }

        /// <summary>
        /// Tabla PesajesContenedor 
        /// </summary>      
        public virtual DbSet<EFPesajeContenedor> PesajesContenedor { get; set; }

        /// <summary>
        /// Tabla PesajesCodigoBarras
        /// </summary>
        public virtual DbSet<EFPesajeCodigoBarras> PesajesCodigoBarras { get; set; }

        /// <summary>
        /// Tabla Evidencias
        /// </summary>
        public virtual DbSet<EFEvidencia> Evidencias { get; set; }

        /// <summary>
        /// Tabla Evidencias
        /// </summary>
        public virtual DbSet<EFDetalleEvidencia> DetallesEvidencia { get; set; }

        /// <summary>
        /// Tabla Documentos
        /// </summary>
        public virtual DbSet<EFDocumento> Documentos { get; set; }

        /// <summary>
        /// Tabla Cajas
        /// </summary>
        public virtual DbSet<EFCaja> Cajas { get; set; }

        /// <summary>
        /// Tabla Inconsistencias
        /// </summary>
        public virtual DbSet<EFInconsistencia> Inconsistencias { get; set; }

        /// <summary>
        /// Tabla EstadosCuadreCaja
        /// </summary>
        public virtual DbSet<EFEstadoCuadreCaja> EstadosCuadreCaja { get; set; }

        /// <summary>
        /// Tabla CuadresCaja
        /// </summary>
        public virtual DbSet<EFCuadreCaja> CuadresCaja { get; set; }

        /// <summary>
        /// Tabla SociosNegocio
        /// </summary>
        public virtual DbSet<EFSocioNegocio> SociosNegocio { get; set; }

        /// <summary>
        /// Tabla Impuestos
        /// </summary>
        public virtual DbSet<EFImpuesto> Impuestos { get; set; }

        /// <summary>
        /// Tabla TiposDescuentos
        /// </summary>
        public virtual DbSet<EFTipoListaPrecio> TiposDescuentos { get; set; }

        /// <summary>
        /// Tabla ComponentesArticulo
        /// </summary>
        public virtual DbSet<EFTransformacion> ComponentesArticulo { get; set; }

        /// <summary>
        /// Tabla DescuentosSocioArticulo
        /// </summary>
        public virtual DbSet<EFListaPrecio> DescuentosSocioArticulo { get; set; }

        /// <summary>
        /// Tabla Inventarios
        /// </summary>
        public virtual DbSet<EFInventario> Inventarios { get; set; }

        /// <summary>
        /// Tabla DetallesInventario
        /// </summary>
        public virtual DbSet<EFInventario> DetallesInventario { get; set; }

        /// <summary>
        /// Tabla TiposFactura
        /// </summary>
        public virtual DbSet<EFTipoFactura> TiposFactura { get; set; }

        /// <summary>
        /// Tabla Facturas
        /// </summary>
        public virtual DbSet<EFFactura> Facturas { get; set; }

        /// <summary>
        /// Tabla DetallesFactura
        /// </summary>
        public virtual DbSet<EFDetalleFactura> DetallesFactura { get; set; }
        
        /// <summary>
        /// Tabla TiposInventario
        /// </summary>
        public virtual DbSet<EFTipoInventario> TiposInventario { get; set; }

        /// <summary>
        /// Tabla Vendedores
        /// </summary>
        public virtual DbSet<EFVendedor> Vendedores { get; set; }

        /// <summary>
        /// Tabla VendedoresPuntoVenta
        /// </summary>
        public virtual DbSet<EFVendedorPuntoVenta> VendedoresPuntoVenta { get; set; }

        /// <summary>
        /// Tabla Transformaciones
        /// </summary>
        public virtual DbSet<EFTransformacion> Transformaciones { get; set; }

        /// <summary>
        /// Tabla FormasPago
        /// </summary>
        public virtual DbSet<EFFormaPago> FormasPago { get; set; }

        /// <summary>
        /// Tabla Bancos
        /// </summary>
        public virtual DbSet<EFBanco> Bancos { get; set; }

        /// <summary>
        /// Tabla UsuariosBodega
        /// </summary>
        public virtual DbSet<EFUsuarioBodega> UsuariosBodega { get; set; }

        /// <summary>
        /// Tabla TiposSolicitud
        /// </summary>
        public virtual DbSet<EFTipoSolicitud> TiposSolicitud { get; set; }

        /// <summary>
        /// Tabla Empaques
        /// </summary>
        public virtual DbSet<EFEmpaque> Empaques { get; set; }
        #endregion
    }
}