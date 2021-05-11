using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EVO_DataAccess.Migrations
{
    public partial class _1_crear_tablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*************************************
             * Tablas
             ************************************/
                                

            migrationBuilder.CreateTable(
            name: "Series",
            columns: table => new
            {
                SerieID = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Series = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                SeriesName = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                InitialNum = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                NextNumber = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                LastNum = table.Column<string>(type: "NVARCHAR(255)", nullable: false),                
                Activo = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Series", x => x.SerieID);
            });


            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    ModuloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.ModuloID);
                });

            migrationBuilder.CreateTable(
                name: "ParametrosGenerales",
                columns: table => new
                {
                    ParametroGeneralId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Valor = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosGenerales", x => x.ParametroGeneralId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    PlantaBeneficio = table.Column<bool>(nullable: false, defaultValue: true),
                    PlantaDerivadosCarnicos = table.Column<bool>(nullable: false, defaultValue: true),
                    PuntosVenta = table.Column<bool>(nullable: false, defaultValue: true),
                    Administracion = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Usuario = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(255)", nullable: false),
                    Identificacion = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true),
                    NotificarEmail = table.Column<bool>(nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionalidades",
                columns: table => new
                {
                    FuncionalidadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ModuloId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionalidades", x => x.FuncionalidadId);
                    table.ForeignKey(
                        name: "FK_Funcionalidades_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "ModuloID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosAuditoria",
                columns: table => new
                {
                    RegistroAuditoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Accion = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Parametros = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    IP = table.Column<string>(type: "NVARCHAR(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosAuditoria", x => x.RegistroAuditoriaId);
                    table.ForeignKey(
                        name: "FK_RegistrosAuditoria_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosxRol",
                columns: table => new
                {
                    UsuariosxRolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RolId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosxRol", x => x.UsuariosxRolId);
                    table.ForeignKey(
                        name: "FK_UsuariosxRol_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosxRol_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionalidadesxRol",
                columns: table => new
                {
                    FuncionalidadesxRolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RolId = table.Column<int>(nullable: false),
                    FuncionalidadId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionalidadesxRol", x => x.FuncionalidadesxRolId);
                    table.ForeignKey(
                        name: "FK_FuncionalidadesxRol_Funcionalidades_FuncionalidadId",
                        column: x => x.FuncionalidadId,
                        principalTable: "Funcionalidades",
                        principalColumn: "FuncionalidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionalidadesxRol_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    SesionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(nullable: false),
                    Token = table.Column<string>(type: "NVARCHAR(68)", nullable: false),
                    IP = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaExpiracion = table.Column<DateTime>(nullable: false),

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.SesionId);
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
            name: "EstadosPedido",
            columns: table => new
            {
                EstadoPedidoId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    ,
                Nombre = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: true),
                EditarPedido = table.Column<bool>(nullable: false, defaultValue: true),
                CancelarPedido = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EstadoPedido", x => x.EstadoPedidoId);
            });

            migrationBuilder.CreateTable(
            name: "EstadosEntrega",
            columns: table => new
            {
                EstadoEntregaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    ,
                Nombre = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EstadosEntrega", x => x.EstadoEntregaId);
            });

            migrationBuilder.CreateTable(
            name: "Bodegas",
            columns: table => new
            {
                WhsCode = table.Column<string>(type: "NVARCHAR(8)"),
                WhsName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                Email = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                Zona = table.Column<string>(type: "NVARCHAR(8)", nullable: true),
                CantidadPedidosBorradorxBodega = table.Column<int>(nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bodega", x => x.WhsCode);
            });

            migrationBuilder.CreateTable(
            name: "TiposSolicitud",
            columns: table => new
            {
                TipoSolicitudId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    ,
                TipoSolicitudNombre = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TiposSolicitud", x => x.TipoSolicitudId);
            });

            migrationBuilder.CreateTable(
              name: "Pedidos",
              columns: table => new
              {
                  PedidoId = table.Column<int>(nullable: false)
                      .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                  WhsCode = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                  SolicitudPara = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                  UsuarioId = table.Column<int>(nullable: false),
                  EstadoPedidoId = table.Column<int>(nullable: false),
                  FechaPedido = table.Column<DateTime>(nullable: false),
                  FechaEntrega = table.Column<DateTime>(nullable: true),
                  FechaAprobacionPlanta = table.Column<DateTime>(nullable: true),
                  NumeroPedido = table.Column<int>(nullable: true),
                  TipoSolicitudId = table.Column<int>(nullable: false),
                  FechaGestionCompra = table.Column<DateTime>(nullable: true),
                  NumeroDocumento = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                  UsuarioAproboId = table.Column<int>(nullable: true)                 
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                  table.ForeignKey(
                       name: "FK_Pedidos_Usuarios_UsuarioId",
                       column: x => x.UsuarioId,
                       principalTable: "Usuarios",
                       principalColumn: "UsuarioId");
                  table.ForeignKey(
                       name: "FK_Pedidos_Bodegas_WhsCode",
                       column: x => x.WhsCode,
                       principalTable: "Bodegas",
                       principalColumn: "WhsCode");
                  table.ForeignKey(
                      name: "FK_Pedidos_Bodegas_SolicitudPara",
                      column: x => x.SolicitudPara,
                      principalTable: "Bodegas",
                      principalColumn: "WhsCode");
                  table.ForeignKey(
                    name: "FK_Pedidos_Bodegas_EstadoPedidoId",
                    column: x => x.EstadoPedidoId,
                    principalTable: "EstadosPedido",
                    principalColumn: "EstadoPedidoId");
                  table.ForeignKey(
                   name: "FK_Pedidos_TiposSolicitud_TipoSolicitudId",
                   column: x => x.TipoSolicitudId,
                   principalTable: "TiposSolicitud",
                   principalColumn: "TipoSolicitudId");
                  table.ForeignKey(
                       name: "FK_Pedidos_Usuarios_UsuarioAproboId",
                       column: x => x.UsuarioAproboId,
                       principalTable: "Usuarios",
                       principalColumn: "UsuarioId");
              });

            migrationBuilder.CreateTable(
            name: "EstadosArticulo",
            columns: table => new
            {
                EstadoArticuloId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EstadoArticulo", x => x.EstadoArticuloId);
            });

            migrationBuilder.CreateTable(
                 name: "ArticulosXBodega",
                 columns: table => new
                 {
                     ItemCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                     WhsCode = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                     OnHand = table.Column<decimal>(type: "Numeric(19,3)", nullable: true),
                     MinStock = table.Column<decimal>(type: "Numeric(19,3)", nullable: true),
                     MaxStock = table.Column<decimal>(type: "Numeric(19,3)", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ArticulosXBodega", x => new { x.ItemCode, x.WhsCode });
                 });

            migrationBuilder.CreateTable(
                name: "Impuestos",
                columns: table => new
                {
                    ImpuestoId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Valor = table.Column<decimal>(type: "Numeric(19,6)", nullable: false),
                    Activo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impuestos", x => x.ImpuestoId);
                });

            migrationBuilder.CreateTable(
              name: "TiposListaPrecio",
              columns: table => new
              {
                  TipoListaPrecioId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                  Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                  Activo = table.Column<bool>(nullable: false, defaultValue: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_TiposListaPrecio", x => x.TipoListaPrecioId);
              });

            migrationBuilder.CreateTable(
           name: "Empaques",
           columns: table => new
           {
               EmpaqueId = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                   ,
               EmpaqueNombre = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
               EmpaqueActivo = table.Column<bool>(nullable: false, defaultValue: true)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_Empaques", x => x.EmpaqueId);
           });

            migrationBuilder.CreateTable(
            name: "Articulos",
            columns: table => new
            {
                ItemCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                ItemName = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                SalUnitMsr = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                Price = table.Column<decimal>(type: "Numeric(19,6)", nullable: true),
                EstadoId = table.Column<int>(nullable: true),
                EmpaqueId = table.Column<int>(nullable: true),
                ArticuloCompraPV = table.Column<string>(type: "NVARCHAR(50)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Articulos", x => x.ItemCode);
                table.ForeignKey(
                  name: "FK_Articulos_EstadosArticulo_EstadoArticuloId",
                  column: x => x.EstadoId,
                  principalTable: "EstadosArticulo",
                  principalColumn: "EstadoArticuloId");
                table.ForeignKey(
                  name: "FK_Articulos_Empaques_EmpaqueId",
                  column: x => x.EmpaqueId,
                  principalTable: "Empaques",
                  principalColumn: "EmpaqueId");
            });

            migrationBuilder.CreateTable(
            name: "SociosNegocio",
            columns: table => new
            {
                Identificacion = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                Nombre = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                Activo = table.Column<bool>(defaultValue: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SociosNegocio", x => x.Identificacion);
            });

            migrationBuilder.CreateTable(
            name: "ListasPrecio",
            columns: table => new
            {
                ListaPrecioId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Identificacion = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                CodigoArticulo = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                TipoListaPrecioId = table.Column<int>(nullable: false),
                FechaInicio = table.Column<DateTime>(nullable: false),
                FechaFin = table.Column<DateTime>(nullable: false),
                PrecioUnitario = table.Column<decimal>(type: "Numeric(19,6)", nullable: false),
                CantidadMinima = table.Column<decimal>(type: "Numeric(19,6)", nullable: false)
            },
             constraints: table =>
             {
                 table.PrimaryKey("PK_ListasPrecio", x => x.ListaPrecioId);
                 table.ForeignKey(
                   name: "FK_ListasPrecio_SociosNegocio_Identificacion",
                   column: x => x.Identificacion,
                   principalTable: "SociosNegocio",
                   principalColumn: "Identificacion");
                 table.ForeignKey(
                   name: "FK_ListasPrecio_Articulos_CodigoArticulo",
                   column: x => x.CodigoArticulo,
                   principalTable: "Articulos",
                   principalColumn: "ItemCode");
                 table.ForeignKey(
                   name: "FK_ListasPrecio_TiposListaPrecio_TipoListaPrecioId",
                   column: x => x.TipoListaPrecioId,
                   principalTable: "TiposListaPrecio",
                   principalColumn: "TipoListaPrecioId");
             });

            migrationBuilder.CreateTable(
            name: "Transformaciones",
            columns: table => new
            {
                TransformacionId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                CodigoArticuloTransformado = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                NombreArticuloTransformado = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                CodigoArticulo = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                CantidadMinima = table.Column<decimal>(type: "Numeric(19,6)", nullable: false),
                Eliminar = table.Column<bool>(defaultValue: true, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Transformaciones", x => x.TransformacionId);
                table.ForeignKey(
                    name: "FK_Transformaciones_Articulos_CodigoArticulo",
                    column: x => x.CodigoArticulo,
                    principalTable: "Articulos",
                    principalColumn: "ItemCode");
            });

            migrationBuilder.CreateTable(
            name: "ImpuestosArticulo",
            columns: table => new
            {
                ImpuestoArticuloId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                CodigoArticulo = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                ImpuestoId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ImpuestosArticulo", x => x.ImpuestoArticuloId);
                table.ForeignKey(
                    name: "FK_ImpuestosArticulo_Articulos_CodigoArticulo",
                    column: x => x.CodigoArticulo,
                    principalTable: "Articulos",
                    principalColumn: "ItemCode");
                table.ForeignKey(
                    name: "FK_ImpuestosArticulo_Impuestos_ImpuestoId",
                    column: x => x.ImpuestoId,
                    principalTable: "Impuestos",
                    principalColumn: "ImpuestoId");
            });

            migrationBuilder.CreateTable(
           name: "ImpuestosSocioArticulo",
           columns: table => new
           {
               ImpuestoSocioArticuloId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
               Identificacion = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
               CodigoArticulo = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
               ImpuestoId = table.Column<int>(nullable: false)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_ImpuestosSocioArticulo", x => x.ImpuestoSocioArticuloId);
               table.ForeignKey(
                   name: "FK_ImpuestosSocioArticulo_SociosNegocio_Identificacion",
                   column: x => x.Identificacion,
                   principalTable: "SociosNegocio",
                   principalColumn: "Identificacion");
               table.ForeignKey(
                   name: "FK_ImpuestosSocioArticulo_Articulos_CodigoArticulo",
                   column: x => x.CodigoArticulo,
                   principalTable: "Articulos",
                   principalColumn: "ItemCode");
               table.ForeignKey(
                   name: "FK_ImpuestosSocioArticulo_Impuestos_ImpuestoId",
                   column: x => x.ImpuestoId,
                   principalTable: "Impuestos",
                   principalColumn: "ImpuestoId");
           });


            migrationBuilder.CreateTable(
            name: "Acciones",
            columns: table => new
            {
                AccionId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    ,
                Nombre = table.Column<string>(type: "NVARCHAR(100)", nullable: false)

            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Acciones", x => x.AccionId);
            });

            migrationBuilder.CreateTable(
            name: "DetallePedidos",
            columns: table => new
            {
                DetallePedidoId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                PedidoId = table.Column<int>(nullable: false),
                ItemCode = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                EstadoArticuloId = table.Column<int>(nullable: true),
                Cantidad = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                CantidadAprobada = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: true),
                Observacion = table.Column<string>(type: "NVARCHAR(4000)", nullable: true),
                EmpaqueId = table.Column<int>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DetallePedido", x => x.DetallePedidoId);
                table.ForeignKey(
                     name: "FK_DetallePedidos_Pedidos_PedidoId",
                     column: x => x.PedidoId,
                     principalTable: "Pedidos",
                     principalColumn: "PedidoId",
                     onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Pedidos_EstadosArticulo_EstadoArticuloId",
                    column: x => x.EstadoArticuloId,
                    principalTable: "EstadosArticulo",
                    principalColumn: "EstadoArticuloId");
                table.ForeignKey(
                    name: "FK_Pedidos_Empaques_EmpaqueId",
                    column: x => x.EmpaqueId,
                    principalTable: "Empaques",
                    principalColumn: "EmpaqueId");
                table.ForeignKey(
                    name: "FK_Pedidos_Articulos_ItemCode",
                    column: x => x.ItemCode,
                    principalTable: "Articulos",
                    principalColumn: "ItemCode");                
            });

           migrationBuilder.CreateTable(
           name: "GestionCompras",
           columns: table => new
           {
               GestionCompraId = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
               DetallePedidoId = table.Column<int>(nullable: false),              
               AccionId = table.Column<int>(nullable: false),
               Cantidad = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),              
               OrdenCompra = table.Column<string>(type: "NVARCHAR(255)", nullable: true)               
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_GestionCompras", x => x.GestionCompraId);
               table.ForeignKey(
                    name: "FK_GestionCompras_Acciones_DetallePedidoId",
                    column: x => x.DetallePedidoId,
                    principalTable: "DetallePedidos",
                    principalColumn: "DetallePedidoId");
               table.ForeignKey(
                    name: "FK_GestionCompras_Acciones_AccionId",
                    column: x => x.AccionId,
                    principalTable: "Acciones",
                    principalColumn: "AccionId");
           });

            migrationBuilder.CreateTable(
            name: "LogsIntegracion",
            columns: table => new
            {
                LogIntegracionId = table.Column<int>(nullable: false).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                InstanceId = table.Column<int>(nullable: false),
                JobId = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                ExecutionId = table.Column<string>(type: "NVARCHAR(255)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_LogsIntegracion", x => x.LogIntegracionId);
            });

            migrationBuilder.CreateTable(
            name: "ClientesExternos",
            columns: table => new
            {
                CodigoCliente = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Zona = table.Column<string>(type: "NVARCHAR(8)", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientesExternos", x => x.CodigoCliente);
            });

            migrationBuilder.CreateTable(
            name: "Procesos",
            columns: table => new
            {
                ProcesoId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Proceso = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProcesoId", x => x.ProcesoId);
            });

            migrationBuilder.CreateTable(
               name: "Motivos",
               columns: table => new
               {
                   MotivoId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   ProcesoId = table.Column<int>(nullable: false),
                   Motivo = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                   Activo = table.Column<bool>(nullable: false, defaultValue: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Motivos", x => x.MotivoId);
                   table.ForeignKey(
                    name: "FK_Motivos_ProcesoId_ProcesoId",
                    column: x => x.ProcesoId,
                    principalTable: "Procesos",
                    principalColumn: "ProcesoId");
               });


            migrationBuilder.CreateTable(
            name: "Muelles",
            columns: table => new
            {
                MuelleId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Muelle = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Muelles", x => x.MuelleId);
            });

            migrationBuilder.CreateTable(
            name: "TiposVehiculo",
            columns: table => new
            {
                TipoVehiculoId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                TipoVehiculo = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Capacidad = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                Canastas = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                Peso = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TiposVehiculo", x => x.TipoVehiculoId);
            });

            migrationBuilder.CreateTable(
             name: "Entregas",
             columns: table => new
             {
                 EntregaId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                 PedidoId = table.Column<int>(nullable: false),
                 UsuarioId = table.Column<int>(nullable: false),
                 TipoVehiculoId = table.Column<int>(nullable: false),
                 EstadoEntregaId = table.Column<int>(nullable: true),
                 FechaRegistro = table.Column<DateTime>(nullable: false),
                 FechaEntrega = table.Column<DateTime>(nullable: false),
                 FechaActualizo = table.Column<DateTime>(nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Entregas", x => x.EntregaId);
                 table.ForeignKey(
                      name: "FK_Entregas_Usuarios_UsuarioId",
                      column: x => x.UsuarioId,
                      principalTable: "Usuarios",
                      principalColumn: "UsuarioId");
                 table.ForeignKey(
                      name: "FK_Entregas_Pedidos_PedidoId",
                      column: x => x.PedidoId,
                      principalTable: "Pedidos",
                      principalColumn: "PedidoId");
                 table.ForeignKey(
                     name: "FK_Entregas_EstadosPedido_EstadoEntregaId",
                     column: x => x.EstadoEntregaId,
                     principalTable: "EstadosEntrega",
                     principalColumn: "EstadoEntregaId");
                 table.ForeignKey(
                     name: "FK_Entregas_TiposVehiculo_TipoVehiculoId",
                     column: x => x.TipoVehiculoId,
                     principalTable: "TiposVehiculo",
                     principalColumn: "TipoVehiculoId");
             });

            migrationBuilder.CreateTable(
             name: "DetalleEntregas",
             columns: table => new
             {
                 DetalleEntregaId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                 EntregaId = table.Column<int>(nullable: false),
                 DetallePedidoId = table.Column<int>(nullable: false),
                 Cantidad = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_DetalleEntregas", x => x.DetalleEntregaId);
                 table.ForeignKey(
                      name: "FK_DetalleEntregas_Entregas_EntregaId",
                      column: x => x.EntregaId,
                      principalTable: "Entregas",
                      principalColumn: "EntregaId");
                 table.ForeignKey(
                      name: "FK_DetalleEntregas_DetallePedidos_DetallePedidoId",
                      column: x => x.DetallePedidoId,
                      principalTable: "DetallePedidos",
                      principalColumn: "DetallePedidoId");
             });

            migrationBuilder.CreateTable(
                  name: "Vehiculos",
                  columns: table => new
                  {
                      VehiculoId = table.Column<int>(nullable: false)
                          .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                      TipoVehiculoId = table.Column<int>(nullable: false),
                      Placa = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                      Capacidad = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                      Activo = table.Column<bool>(nullable: false, defaultValue: false)
                  },
                  constraints: table =>
                  {
                      table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
                      table.ForeignKey(
                          name: "FK_Vehiculos_TiposVehiculo_VehiculoId",
                          column: x => x.TipoVehiculoId,
                          principalTable: "TiposVehiculo",
                          principalColumn: "TipoVehiculoId",
                          onDelete: ReferentialAction.Cascade);
                  });

            migrationBuilder.CreateTable(
               name: "Empleados",
               columns: table => new
               {
                   EmpleadoId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Nombres = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                   Apellidos = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                   Cedula = table.Column<decimal>(type: "NVARCHAR(20)", nullable: false),
                   Cargo = table.Column<decimal>(type: "NVARCHAR(255)", nullable: false),
                   Activo = table.Column<bool>(nullable: false, defaultValue: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
               });

            migrationBuilder.CreateTable(
              name: "VehiculoEntregas",
              columns: table => new
              {
                  VehiculoEntregaId = table.Column<int>(nullable: false)
                      .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                  UsuarioId = table.Column<int>(nullable: false),
                  MuelleId = table.Column<int>(nullable: false),
                  VehiculoId = table.Column<int>(nullable: false),
                  ConductorId = table.Column<int>(nullable: false),
                  AuxiliarId = table.Column<int>(nullable: false),
                  FechaRegistro = table.Column<DateTime>(nullable: false),
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_VehiculoEntregas", x => x.VehiculoEntregaId);
                  table.ForeignKey(
                      name: "FK_VehiculoEntregas_Usuarios_UsuarioId",
                      column: x => x.UsuarioId,
                      principalTable: "Usuarios",
                      principalColumn: "UsuarioId");
                  table.ForeignKey(
                      name: "FK_VehiculoEntregas_Vehiculos_VehiculoId",
                      column: x => x.VehiculoId,
                      principalTable: "Vehiculos",
                      principalColumn: "VehiculoId");
                  table.ForeignKey(
                      name: "FK_VehiculoEntregas_Empleados_ConductorId",
                      column: x => x.ConductorId,
                      principalTable: "Empleados",
                      principalColumn: "EmpleadoId");
                  table.ForeignKey(
                      name: "FK_VehiculoEntregas_Empleados_AuxiliarId",
                      column: x => x.AuxiliarId,
                      principalTable: "Empleados",
                      principalColumn: "EmpleadoId");
                  table.ForeignKey(
                  name: "FK_VehiculoEntrega__MuelleID",
                  column: x => x.MuelleId,
                  principalTable: "Muelles",
                  principalColumn: "MuelleId");
              });

            migrationBuilder.CreateTable(
            name: "VehiculoEntregasDetalles",
            columns: table => new
            {
                VehiculoEntregaDetalleId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                VehiculoEntregaId = table.Column<int>(nullable: false),
                EntregaId = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_v", x => x.VehiculoEntregaDetalleId);
                table.ForeignKey(
                    name: "FK_VehiculoEntregasDetalles_VehiculoEntregas_VehiculoEntregaId",
                    column: x => x.VehiculoEntregaId,
                    principalTable: "VehiculoEntregas",
                    principalColumn: "VehiculoEntregaId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_VehiculoEntregasDetalles_Entregas_EntregaId",
                    column: x => x.EntregaId,
                    principalTable: "Entregas",
                    principalColumn: "EntregaId",
                    onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable(
               name: "MotivosProcesos",
               columns: table => new
               {
                   MotivoProcesoId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   TablaId = table.Column<int>(nullable: false),
                   MotivoId = table.Column<int>(nullable: false),
                   NombreTabla = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                   FechaRegistro = table.Column<DateTime>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_MotivoProceso", x => x.MotivoProcesoId);
                   table.ForeignKey(
                       name: "FK_MotivosProcesos_Motivos_MotivoId",
                       column: x => x.MotivoId,
                       principalTable: "Motivos",
                       principalColumn: "MotivoId",
                       onDelete: ReferentialAction.Cascade);
               });

            migrationBuilder.CreateTable(
            name: "TiposBascula",
            columns: table => new
            {
                TipoBasculaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TiposBascula", x => x.TipoBasculaId);
            });

            migrationBuilder.CreateTable(
            name: "PesajesEntrega",
            columns: table => new
            {
                PesajeEntregaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Consecutivo = table.Column<int>(nullable: true),
                EstadoEntregaId = table.Column<int>(nullable: true),
                EntregaId = table.Column<int>(nullable: true),
                Finalizado = table.Column<bool>(nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PesajesEntrega", x => x.PesajeEntregaId);
                table.ForeignKey(
                     name: "FK_PesajesEntrega_EstadosEntrega_EstadoEntregaId",
                     column: x => x.EstadoEntregaId,
                     principalTable: "EstadosEntrega",
                     principalColumn: "EstadoEntregaId");
                table.ForeignKey(
                     name: "FK_PesajesEntrega_Entregas_EntregaId",
                     column: x => x.EntregaId,
                     principalTable: "Entregas",
                     principalColumn: "EntregaId");
            });

            migrationBuilder.CreateTable(
           name: "Documentos",
           columns: table => new
           {
               DocumentoId = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
               Documento = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
               Activo = table.Column<bool>(nullable: false, defaultValue: false)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_Documentos", x => x.DocumentoId);
           });

            migrationBuilder.CreateTable(
            name: "PesajesArticulo",
            columns: table => new
            {
                PesajeArticuloId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                PesajeEntregaId = table.Column<int>(nullable: false),
                DetalleEntregaId = table.Column<int>(nullable: false),
                UsuarioId = table.Column<int>(nullable: true),
                DocumentoId = table.Column<int>(nullable: true),
                PesajeFinalizado = table.Column<bool>(nullable: true),
                InconsistenciaCodigoBarras = table.Column<bool>(nullable: true),
                CantidadRecibida = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PesajesArticulo", x => x.PesajeArticuloId);
                table.ForeignKey(
                    name: "FK_PesajesArticulo_PesajesEntrega_PesajeEntregaId",
                    column: x => x.PesajeEntregaId,
                    principalTable: "PesajesEntrega",
                    principalColumn: "PesajeEntregaId");
                table.ForeignKey(
                    name: "FK_PesajesArticulo_DetalleEntregas_DetalleEntregaId",
                    column: x => x.DetalleEntregaId,
                    principalTable: "DetalleEntregas",
                    principalColumn: "DetalleEntregaId");
                table.ForeignKey(
                    name: "FK_PesajesArticulo_Usuarios_UsuarioId",
                    column: x => x.UsuarioId,
                    principalTable: "Usuarios",
                    principalColumn: "UsuarioId");
                table.ForeignKey(
                   name: "FK_PesajesArticulo_Documentos_DocumentoId",
                   column: x => x.DocumentoId,
                   principalTable: "Documentos",
                   principalColumn: "DocumentoId");
            });

            migrationBuilder.CreateTable(
            name: "Pesajes",
            columns: table => new
            {
                PesajeId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                FechaPesaje = table.Column<DateTime>(nullable: false),
                PesajeArticuloId = table.Column<int>(nullable: false),
                UsuarioId = table.Column<int>(nullable: false),
                TipoBasculaId = table.Column<int>(nullable: false),
                CodigoBodega = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
                PesoBascula = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                PesoBasculaArticulos = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                PesoCodigosBarras = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: true),
                PesajeAl = table.Column<string>(type: "NVARCHAR(5)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Pesajes", x => x.PesajeId);
                table.ForeignKey(
                    name: "FK_Pesajes_PesajesArticulo_PesajeArticuloId",
                    column: x => x.PesajeArticuloId,
                    principalTable: "PesajesArticulo",
                    principalColumn: "PesajeArticuloId");
                table.ForeignKey(
                    name: "FK_Pesajes_Usuarios_UsuarioId",
                    column: x => x.UsuarioId,
                    principalTable: "Usuarios",
                    principalColumn: "UsuarioId");
                table.ForeignKey(
                    name: "FK_Pesajes_TiposBascula_TipoBasculaId",
                    column: x => x.TipoBasculaId,
                    principalTable: "TiposBascula",
                    principalColumn: "TipoBasculaId");
            });

            migrationBuilder.CreateTable(
            name: "TiposContenedor",
            columns: table => new
            {
                TipoContenedorId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Peso = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                CodigoBarras = table.Column<bool>(nullable: false, defaultValue: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TiposContenedor", x => x.TipoContenedorId);
            });

            migrationBuilder.CreateTable(
            name: "PesajesContenedor",
            columns: table => new
            {
                PesajeContenedorId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                PesajeId = table.Column<int>(nullable: false),
                TipoContenedorId = table.Column<int>(nullable: false),
                Cantidad = table.Column<int>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PesajesContenedor", x => x.PesajeContenedorId);
                table.ForeignKey(
                    name: "FK_PesajesContenedor_Pesajes_PesajeId",
                    column: x => x.PesajeId,
                    principalTable: "Pesajes",
                    principalColumn: "PesajeId");
                table.ForeignKey(
                   name: "FK_PesajesContenedor_TiposContenedor_TipoContenedorId",
                   column: x => x.TipoContenedorId,
                   principalTable: "TiposContenedor",
                   principalColumn: "TipoContenedorId");
            });

            migrationBuilder.CreateTable(
              name: "PesajesCodigoBarras",
              columns: table => new
              {
                  PesajeCodigoBarrasId = table.Column<int>(nullable: false)
                      .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                  PesajeId = table.Column<int>(nullable: false),
                  UsuarioId = table.Column<int>(nullable: false),
                  CodigoBarras = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                  Lote = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                  FechaVencimiento = table.Column<DateTime>(nullable: false),
                  Unidades = table.Column<int>(nullable: false),
                  Peso = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_PesajesCodigoBarras", x => x.PesajeCodigoBarrasId);
                  table.ForeignKey(
                    name: "FK_PesajesCodigoBarras_Pesajes_PesajeId",
                    column: x => x.PesajeId,
                    principalTable: "Pesajes",
                    principalColumn: "PesajeId");
                  table.ForeignKey(
                    name: "FK_PesajesCodigoBarras_Usuarios_UsuarioId",
                    column: x => x.UsuarioId,
                    principalTable: "Usuarios",
                    principalColumn: "UsuarioId");
              });

            migrationBuilder.CreateTable(
            name: "ClientesParametrizacion",
            columns: table => new
            {
                ClienteParametrizacionId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                CodigoCliente = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                RecepcionToleranciaInferior = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: true),
                RecepcionToleranciaSuperior = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: true),
                RecepcionPesajeCodigoBarras = table.Column<bool>(nullable: true),
                FacturacionPorcentajeDescuento = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: true),
                DuplicarPedido = table.Column<bool>(nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientesParametrizacion", x => x.ClienteParametrizacionId);
            });

            migrationBuilder.CreateTable(
             name: "Evidencias",
             columns: table => new
             {
                 EvidenciaId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                 PesajeEntregaId = table.Column<int>(nullable: false),
                 UsuarioId = table.Column<int>(nullable: false),
                 GUID = table.Column<string>(type: "NVARCHAR(68)", nullable: false),
                 Observaciones = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                 FechaEvidencia = table.Column<DateTime>(nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Evidencias", x => x.EvidenciaId);
                 table.ForeignKey(
                   name: "FK_Evidencias_PesajesEntrega_PesajeEntregaId",
                   column: x => x.PesajeEntregaId,
                   principalTable: "PesajesEntrega",
                   principalColumn: "PesajeEntregaId");
                 table.ForeignKey(
                    name: "FK_Evidencias_Usuarios_UsuarioId",
                    column: x => x.UsuarioId,
                    principalTable: "Usuarios",
                    principalColumn: "UsuarioId");
             });

            migrationBuilder.CreateTable(
            name: "DetallesEvidencia",
            columns: table => new
            {
                DetalleEvidenciaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                EvidenciaId = table.Column<int>(nullable: false),
                NombreArchivo = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                ExtensionArchivo = table.Column<string>(type: "NVARCHAR(8)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DetallesEvidencia", x => x.DetalleEvidenciaId);
                table.ForeignKey(
                  name: "FK_DetallesEvidencia_Evidencias_EvidenciaId",
                  column: x => x.EvidenciaId,
                  principalTable: "Evidencias",
                  principalColumn: "EvidenciaId");
            });

            migrationBuilder.CreateTable(
            name: "Cajas",
            columns: table => new
            {
                CajaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                CodigoPuntoVenta = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                IP = table.Column<string>(type: "NVARCHAR(39)", nullable: false),
                ValorAsignado = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Cajas", x => x.CajaId);
            });

            migrationBuilder.CreateTable(
            name: "EstadosCuadreCaja",
            columns: table => new
            {
                EstadoCuadreCajaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EstadosCuadreCaja", x => x.EstadoCuadreCajaId);
            });

            migrationBuilder.CreateTable(
            name: "Inconsistencias",
            columns: table => new
            {
                InconsistenciaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Inconsistencias", x => x.InconsistenciaId);
            });

            migrationBuilder.CreateTable(
            name: "CuadresCaja",
            columns: table => new
            {
                CuadreCajaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                CajaId = table.Column<int>(nullable: false),
                EstadoCuadreCajaId = table.Column<int>(nullable: false),
                UsuarioId = table.Column<int>(nullable: false),
                InconsistenciaId = table.Column<int>(nullable: true),
                Consecutivo = table.Column<int>(nullable: false),
                FechaCuadre = table.Column<DateTime>(nullable: false),
                ValorAsignado = table.Column<decimal>(nullable: true, type: "NUMERIC(19,6)"),
                ValorApertura = table.Column<decimal>(nullable: true, type: "NUMERIC(19,6)"),
                ValorCierre = table.Column<decimal>(nullable: true, type: "NUMERIC(19,6)"),
                ValorFaltanteSobrante = table.Column<decimal>(nullable: true, type: "NUMERIC(19,6)")

            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CuadresCaja", x => x.CuadreCajaId);
                table.ForeignKey(
                   name: "FK_CuadresCaja_Cajas_CajaId",
                   column: x => x.CajaId,
                   principalTable: "Cajas",
                   principalColumn: "CajaId");
                table.ForeignKey(
                   name: "FK_CuadresCaja_EstadosCuadreCaja_EstadoCuadreCajaId",
                   column: x => x.EstadoCuadreCajaId,
                   principalTable: "EstadosCuadreCaja",
                   principalColumn: "EstadoCuadreCajaId");
                table.ForeignKey(
                  name: "FK_CuadresCaja_Usuarios_UsuarioId",
                  column: x => x.UsuarioId,
                  principalTable: "Usuarios",
                  principalColumn: "UsuarioId");
                table.ForeignKey(
                  name: "FK_CuadresCaja_Inconsistencias_InconsistenciaId",
                  column: x => x.InconsistenciaId,
                  principalTable: "Inconsistencias",
                  principalColumn: "InconsistenciaId");
            });

            migrationBuilder.CreateTable(
            name: "TiposInventario",
            columns: table => new
            {
                TipoInventarioId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TiposInventario", x => x.TipoInventarioId);
            });

            migrationBuilder.CreateTable(
               name: "TiposFactura",
               columns: table => new
               {
                   TipoFacturaId = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                   Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                   Activo = table.Column<bool>(nullable: false, defaultValue: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_TiposFactura", x => x.TipoFacturaId);
               });

            migrationBuilder.CreateTable(
            name: "Vendedores",
            columns: table => new
            {
                VendedorId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Nombres = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Apellidos = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Vendedores", x => x.VendedorId);
            });

            migrationBuilder.CreateTable(
            name: "Facturas",
            columns: table => new
            {
                FacturaId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                TipoFacturaId = table.Column<int>(nullable: false),
                CuadreCajaId = table.Column<int>(nullable: false),
                UsuarioId = table.Column<int>(nullable: false),
                VendedorId = table.Column<int>(nullable: false),
                Identificacion = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                TipoBasculaId = table.Column<int>(nullable: false),
                TotalSinDescuento = table.Column<int>(nullable: false),
                TotalConDescuento = table.Column<int>(nullable: true),
                CantidadBolsas = table.Column<int>(nullable: true),
                PorcentajeCobroBolsa = table.Column<decimal>(nullable: true, type: "NUMERIC(19,6)"),
                ValorBolsa = table.Column<int>(nullable: true),
                ImpuestoBolsas = table.Column<int>(nullable: true),
                TotalImpuestos = table.Column<int>(nullable: false),
                TotalDocumento = table.Column<int>(nullable: false),
                Devuelta = table.Column<int>(nullable: true),
                Consecutivo = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                FechaFactura = table.Column<DateTime>(nullable: false),
                Observaciones = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Facturas", x => x.FacturaId);
                table.ForeignKey(
                 name: "FK_Facturas_TiposFactura_TipoFacturaId",
                 column: x => x.TipoFacturaId,
                 principalTable: "TiposFactura",
                 principalColumn: "TipoFacturaId");
                table.ForeignKey(
                 name: "FK_Facturas_CuadresCaja_CuadreCajaId",
                 column: x => x.CuadreCajaId,
                 principalTable: "CuadresCaja",
                 principalColumn: "CuadreCajaId");
                table.ForeignKey(
                name: "FK_Facturas_Usuarios_UsuarioId",
                column: x => x.UsuarioId,
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
                table.ForeignKey(
                name: "FK_Facturas_SociosNegocio_Identificacion",
                column: x => x.Identificacion,
                principalTable: "SociosNegocio",
                principalColumn: "Identificacion");
                table.ForeignKey(
                name: "FK_Facturas_Vendedores_VendedorId",
                column: x => x.VendedorId,
                principalTable: "Vendedores",
                principalColumn: "VendedorId");
                table.ForeignKey(
                name: "FK_Facturas_TiposBascula_TipoBasculaId",
                column: x => x.TipoBasculaId,
                principalTable: "TiposBascula",
                principalColumn: "TipoBasculaId");
            });

            migrationBuilder.CreateTable(
            name: "DetallesFactura",
            columns: table => new
            {
                DetalleFacturaId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                FacturaId = table.Column<int>(nullable: false),
                CodigoArticulo = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                CodigoBodega = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                Cantidad = table.Column<decimal>(nullable: false, type: "NUMERIC(19,6)"),
                PrecioUnitario = table.Column<int>(nullable: false),
                PrecioUnitarioMasIVA = table.Column<int>(nullable: false),
                PorcentajeIVA = table.Column<decimal>(nullable: false, type: "NUMERIC(19,6)"),
                IVAId = table.Column<int>(nullable: false),
                Total = table.Column<int>(nullable: false),
                //PorMayor = table.Column<bool>(nullable: false, defaultValue: false),
                Eliminado = table.Column<bool>(nullable: false, defaultValue: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DetallesFactura", x => x.DetalleFacturaId);
                table.ForeignKey(
                 name: "FK_DetallesFactura_Facturas_FacturaId",
                 column: x => x.FacturaId,
                 principalTable: "Facturas",
                 principalColumn: "FacturaId");
                table.ForeignKey(
                 name: "FK_DetallesFactura_Articulos_CodigoArticulo",
                 column: x => x.CodigoArticulo,
                 principalTable: "Articulos",
                 principalColumn: "ItemCode");
                table.ForeignKey(
                 name: "FK_DetallesFactura_Bodegas_CodigoBodega",
                 column: x => x.CodigoBodega,
                 principalTable: "Bodegas",
                 principalColumn: "WhsCode");
                table.ForeignKey(
                 name: "FK_DetallesFactura_Impuestos_IVAId",
                 column: x => x.IVAId,
                 principalTable: "Impuestos",
                 principalColumn: "ImpuestoId");
            });

            migrationBuilder.CreateTable(
            name: "Bancos",
            columns: table => new
            {
                BancoId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                NIT = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Bancos", x => x.BancoId);
            });

            migrationBuilder.CreateTable(
            name: "FormasPago",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                Nombre = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                Activo = table.Column<bool>(nullable: false, defaultValue: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_FormasPago", x => x.Id);
            });

            migrationBuilder.CreateTable(
           name: "DetallesFacturaFormaPago",
           columns: table => new
           {
               DetalleFacturaFormaPagoId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
               FacturaId = table.Column<int>(nullable: false),
               BancoId = table.Column<int>(nullable: true),
               FormaPagoId = table.Column<int>(nullable: false),
               ValorPago = table.Column<int>(nullable: false),
               ConsecutivoBono = table.Column<string>(type: "NVARCHAR(255)", nullable: true),
               EmpleadoBono = table.Column<string>(type: "NVARCHAR(255)", nullable: true)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_DetallesFacturaFormaPago", x => x.DetalleFacturaFormaPagoId);
               table.ForeignKey(
                name: "FK_DetallesFacturaFormaPago_Facturas_FacturaId",
                column: x => x.FacturaId,
                principalTable: "Facturas",
                principalColumn: "FacturaId");
               table.ForeignKey(
               name: "FK_DetallesFacturaFormaPago_FormasPago_FormaPagoId",
               column: x => x.FormaPagoId,
               principalTable: "FormasPago",
               principalColumn: "Id");
               table.ForeignKey(
                name: "FK_DetallesFacturaFormaPago_Banco_BancoId",
                column: x => x.BancoId,
                principalTable: "Bancos",
                principalColumn: "BancoId");
           });


            migrationBuilder.CreateTable(
            name: "Inventarios",
            columns: table => new
            {
                InventarioId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                TipoInventarioId = table.Column<int>(nullable: false),
                ProcesoId = table.Column<int>(nullable: false),
                PesajeArticuloId = table.Column<int>(nullable: true),
                DetalleFacturaId = table.Column<int>(nullable: true),
                FechaRegistro = table.Column<DateTime>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Inventarios", x => x.InventarioId);
                table.ForeignKey(
                 name: "FK_Inventarios_TiposInventario_TipoInventarioId",
                 column: x => x.TipoInventarioId,
                 principalTable: "TiposInventario",
                 principalColumn: "TipoInventarioId");
                table.ForeignKey(
                name: "FK_Inventarios_Procesos_ProcesoId",
                column: x => x.ProcesoId,
                principalTable: "Procesos",
                principalColumn: "ProcesoId");
                table.ForeignKey(
                name: "FK_Inventarios_PesajesArticulo_PesajeArticuloId",
                column: x => x.PesajeArticuloId,
                principalTable: "PesajesArticulo",
                principalColumn: "PesajeArticuloId");
                table.ForeignKey(
                name: "FK_Inventarios_DetallesFactura_DetalleFacturaId",
                column: x => x.DetalleFacturaId,
                principalTable: "DetallesFactura",
                principalColumn: "DetalleFacturaId");
            });

            migrationBuilder.CreateTable(
            name: "VendedoresPuntoVenta",
            columns: table => new
            {
                VendedorPuntoVentaId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                VendedorId = table.Column<int>(nullable: false),
                CodigoPuntoVenta = table.Column<string>(type: "NVARCHAR(8)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_VendedoresPuntoVenta", x => x.VendedorPuntoVentaId);
                table.ForeignKey(
                 name: "FK_VendedoresPuntoVenta_Vendedores_VendedorId",
                 column: x => x.VendedorId,
                 principalTable: "Vendedores",
                 principalColumn: "VendedorId");
                table.ForeignKey(
                 name: "FK_VendedoresPuntoVenta_Bodegas_WhsCode",
                 column: x => x.CodigoPuntoVenta,
                 principalTable: "Bodegas",
                 principalColumn: "WhsCode");
            });

            migrationBuilder.CreateTable(
            name: "UsuariosBodega",
            columns: table => new
            {
                UsuarioBodegaId = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                UsuarioId = table.Column<int>(nullable: false),
                CodigoBodega = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_UsuariosBodega", x => x.UsuarioBodegaId);
                table.ForeignKey(
                 name: "FK_UsuariosBodega_Usuarios_UsuarioId",
                 column: x => x.UsuarioId,
                 principalTable: "Usuarios",
                 principalColumn: "UsuarioId");
                table.ForeignKey(
                name: "FK_UsuariosBodega_Bodegas_WhsCode",
                column: x => x.CodigoBodega,
                principalTable: "Bodegas",
                principalColumn: "WhsCode");
            });

            migrationBuilder.CreateTable(
           name: "TiposBodegasParametrizacion",
           columns: table => new
           {
               TipoBodegaParametrizacionId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
               PrefijoBodega = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
               CodigoBodega = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
               CantidadPedidosBorrador = table.Column<int>(nullable: false)
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_TiposBodegasParametrizacion", x => x.TipoBodegaParametrizacionId);
               table.ForeignKey(
                name: "FK_TiposBodegasParametrizacion_Bodegas_WhsCode",
                column: x => x.CodigoBodega,
                principalTable: "Bodegas",
                principalColumn: "WhsCode");             
           });


            migrationBuilder.CreateTable(
            name: "ArchivosPlano",
            columns: table => new
            {
                ArchivoID = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    ,
                CodigoArticulo = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                Nombre = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                FechaCarga = table.Column<DateTime>(nullable: false),
                FechaInicial = table.Column<DateTime>(nullable: false),
                FechaFinal = table.Column<DateTime>(nullable: false),
                NumeroCanales = table.Column<int>(nullable: false),
                DiaUno = table.Column<decimal>(nullable: false),
                DiaDos = table.Column<decimal>(nullable: false),
                DiaTres = table.Column<decimal>(nullable: false),
                DiaCuatro = table.Column<decimal>(nullable: false),
                DiaCinco = table.Column<decimal>(nullable: false),
                DiaSeis= table.Column<decimal>(nullable: false),
                DiaSiete= table.Column<decimal>(nullable: false),
                PesoCaliente = table.Column<decimal>(nullable: false),
                PesoPromedioDia = table.Column<decimal>(nullable: false),
                PesoTotal = table.Column<decimal>(nullable: false),
                PesoDeshuesadoTotal = table.Column<decimal>(nullable: false),
                PesoPromedio = table.Column<decimal>(nullable: false),
                PorcentajeArticulo = table.Column<string>(type: "NVARCHAR(10)", nullable: true),
                SemanaCarga = table.Column<int>(nullable: true),
                NombreArchivo = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                ControlCarga = table.Column<bool>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ArchivosPlano", x => x.ArchivoID);
            });

            migrationBuilder.CreateTable(
            name: "ProduccionSemanal",
            columns: table => new
            {
                ProduccionSemanalId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    ,
                Ano = table.Column<int>(nullable: true),
                Mes = table.Column<int>(nullable: true),
                Semana = table.Column<int>(nullable: true),
                PesoTotal = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                PesoDeshuesadoTotal = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                PorcentajeArticulo = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
                CodigoArticulo = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                NombreArchivo = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                FechaCarga = table.Column<DateTime>(nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ProduccionSemanalID", x => x.ProduccionSemanalId);
            });

          

          migrationBuilder.CreateTable(
          name: "ProduccionDiaria",
          columns: table => new
          {
              ProduccionDiariaId = table.Column<int>(nullable: false)
                  .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                  ,
              FechaProduccion = table.Column<DateTime>(nullable: false),
              NumeroCanales = table.Column<int>(nullable: false),
              PesoCaliente = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),
              PesoPromedioDia = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false)
             
          },
          constraints: table =>
          {
              table.PrimaryKey("PK_ProduccionDiariaId", x => x.ProduccionDiariaId);
          });



            migrationBuilder.CreateTable(
            name: "DetalleProduccionDiaria",
            columns: table => new
            {
                DetalleProduccionDiariaId = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                    ,
                CodigoArticulo = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                ProduccionDiaria = table.Column<decimal>(type: "NUMERIC(19,6)", nullable: false),                      
                ProduccionDiariaId = table.Column<int>(nullable: true),
                ProduccionSemanalId = table.Column<int>(nullable: true)

            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DetalleProduccionDiariaId", x => x.DetalleProduccionDiariaId);
                table.ForeignKey(
                    name: "FK_DetalleProduccionDiaria_ProduccionDiaria_ProduccionDiariaId",
                    column: x => x.ProduccionDiariaId,
                    principalTable: "ProduccionDiaria",
                    principalColumn: "ProduccionDiariaId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_DetalleProduccionDiaria_ProduccionSemanal_ProduccionSemanalId",
                    column: x => x.ProduccionSemanalId,
                    principalTable: "ProduccionSemanal",
                    principalColumn: "ProduccionSemanalId");
            });



            /*************************************
             * Indices: Llaves Primarias y Unicas
             ************************************/

            migrationBuilder.CreateIndex(table: "Bancos",
            column: "Nombre",
            unique: true,
            name: "UK_BancosNombre");

            migrationBuilder.CreateIndex(table: "TiposFactura",
            column: "Nombre",
            unique: true,
            name: "UK_TiposFacturaNombre");

            migrationBuilder.CreateIndex(table: "TiposListaPrecio",
             column: "Nombre",
             unique: true,
             name: "UK_TiposListaPrecioNombre");

            migrationBuilder.CreateIndex(table: "Impuestos",
              column: "Codigo",
              unique: true,
              name: "UK_ImpuestosNombre");

            migrationBuilder.CreateIndex(table: "Modulos",
                column: "Nombre",
                unique: true,
                name: "UK_ModulosNombre");

            migrationBuilder.CreateIndex(table: "ParametrosGenerales",
                column: "Nombre",
                unique: true,
                name: "UK_ParametrosGeneralesNombre");

            migrationBuilder.CreateIndex(table: "Roles",
                column: "Nombre",
                unique: true,
                name: "UK_RolesNombre");

            migrationBuilder.CreateIndex(table: "Usuarios",
                column: "Usuario",
                unique: true,
                name: "UK_UsuariosUsuario");

            migrationBuilder.CreateIndex(table: "Funcionalidades",
                column: "Nombre",
                unique: true,
                name: "UK_FuncionalidadesNombre");

            migrationBuilder.CreateIndex(table: "UsuariosxRol",
                columns: new[] { "RolId", "UsuarioId" },
                unique: true,
                name: "UK_UsuariosxRolRolId_UsuarioId");

            migrationBuilder.CreateIndex(table: "FuncionalidadesxRol",
                columns: new[] { "FuncionalidadId", "RolId" },
                unique: true,
                name: "UK_FuncionalidadesxRolFuncionalidadId_UsuarioId");

            migrationBuilder.CreateIndex(table: "Sesiones",
                column: "Token",
                unique: true,
                name: "UK_SesionesToken");

            migrationBuilder.CreateIndex(table: "Bodegas",
            column: "WhsName",
            name: "UK_Bodegas_WhsName");

            migrationBuilder.CreateIndex(table: "Bodegas",
            column: "Email",
            name: "UK_Bodegas_Email");

            migrationBuilder.CreateIndex(table: "EstadosPedido",
                column: "Nombre",
                unique: true,
                name: "UK_EstadosPedido_Nombre");

            migrationBuilder.CreateIndex(table: "Acciones",
              column: "Nombre",
              unique: true,
              name: "UK_Acciones_Nombre");

            migrationBuilder.CreateIndex(table: "EstadosEntrega",
                column: "Nombre",
                unique: true,
                name: "UK_EstadosEntrega_Nombre");

            migrationBuilder.CreateIndex(table: "EstadosArticulo",
            column: "Nombre",
            unique: true,
            name: "UK_EstadosArticulo_Nombre");

            migrationBuilder.CreateIndex(table: "TiposVehiculo",
              column: "TipoVehiculo",
              unique: true,
              name: "UK_TiposVehiculoTipoVehiculo");

            migrationBuilder.CreateIndex(table: "Empleados",
               column: "Cedula",
               unique: true,
               name: "UK_EmpleadosCedula");

            migrationBuilder.CreateIndex(table: "Procesos",
                column: "Proceso",
                unique: true,
                name: "UK_ProcesosProceso");

            migrationBuilder.CreateIndex(table: "Muelles",
            column: "Muelle",
            unique: true,
            name: "UK_Muelles_Muelle");

            migrationBuilder.CreateIndex(table: "TiposBascula",
               column: "Nombre",
               unique: true,
               name: "UK_TiposBasculaNombre");

            migrationBuilder.CreateIndex(table: "TiposContenedor",
             column: "Nombre",
             unique: true,
             name: "UK_TiposContenedorNombre");

            migrationBuilder.CreateIndex(table: "Evidencias",
               column: "GUID",
               unique: true,
               name: "UK_GUID");

            migrationBuilder.CreateIndex(table: "Documentos",
                column: "Documento",
                unique: true,
                name: "UK_DocumentosDocumento");

            migrationBuilder.CreateIndex(table: "Cajas",
              column: "IP",
              unique: true,
              name: "UK_CajasIP");

            migrationBuilder.CreateIndex(table: "Cajas",
             column: "CodigoPuntoVenta",
             unique: true,
             name: "UK_CajasCodigoPuntoVenta");

            migrationBuilder.CreateIndex(table: "EstadosCuadreCaja",
               column: "Nombre",
               unique: true,
               name: "UK_EstadosCuadreCajaNombre");

            migrationBuilder.CreateIndex(table: "Inconsistencias",
              column: "Nombre",
              unique: true,
              name: "UK_InconsistenciasNombre");

            migrationBuilder.CreateIndex(table: "FormasPago",
            column: "Nombre",
            unique: true,
            name: "UK_FormasPagoNombre");

            migrationBuilder.CreateIndex(table: "TiposSolicitud",
            column: "TipoSolicitudNombre",
            unique: true,
            name: "UK_TiposSolicitudNombre");

            migrationBuilder.CreateIndex(table: "Empaques",
            column: "EmpaqueNombre",
            unique: true,
            name: "UK_EmpaqueNombre");

            //migrationBuilder.CreateIndex(table: "ArchivosPlano",
            //column: "NombreArchivo",
            //unique: true,
            //name: "UK_ArchivosPlano_NombreArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionalidades_ModuloId",
                table: "Funcionalidades",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosAuditoria_UsuarioId",
                table: "RegistrosAuditoria",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionalidadesxRol_FuncionalidadId",
                table: "FuncionalidadesxRol",
                column: "FuncionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionalidadesxRol_RolId",
                table: "FuncionalidadesxRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosxRol_RolId",
                table: "UsuariosxRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosxRol_UsuarioId",
                table: "UsuariosxRol",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_UsuarioId",
                table: "Sesiones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
               name: "IX_Pedidos_WhsCode",
               table: "Pedidos",
               column: "WhsCode");

            migrationBuilder.CreateIndex(
             name: "IX_Pedidos_SolicitudPara",
             table: "Pedidos",
             column: "SolicitudPara");

            migrationBuilder.CreateIndex(
            name: "IX_Pedidos_UsuarioId",
            table: "Pedidos",
            column: "UsuarioId");

            migrationBuilder.CreateIndex(
            name: "IX_Pedidos_TipoSolicitudId",
            table: "TiposSolicitud",
            column: "TipoSolicitudId");

            migrationBuilder.CreateIndex(
            name: "IX_Pedidos_EstadoPedidoId",
            table: "Pedidos",
            column: "EstadoPedidoId");

            migrationBuilder.CreateIndex(
             name: "IX_DetallePedidos_PedidoId",
             table: "DetallePedidos",
             column: "PedidoId");

            migrationBuilder.CreateIndex(
            name: "IX_DetallePedidos_EstadoArticuloId",
            table: "DetallePedidos",
            column: "EstadoArticuloId");

            migrationBuilder.CreateIndex(
            name: "IX_DetallePedidos_EmpaqueId",
            table: "Empaques",
            column: "EmpaqueId");

            migrationBuilder.CreateIndex(
               name: "IX_LogsIntegracion_LogIntegracionId",
               table: "LogsIntegracion",
               column: "LogIntegracionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesExternos_ClienteExternoId",
                table: "ClientesExternos",
                column: "CodigoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_EntregaId",
                table: "Entregas",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
               name: "IX_DetalleEntregas_DetalleEntregaId",
               table: "DetalleEntregas",
               column: "DetalleEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Motivos_MotivoId",
                table: "Motivos",
                column: "MotivoId");

            migrationBuilder.CreateIndex(
              name: "IX_Muelles_MuelleID",
              table: "Muelles",
              column: "MuelleId");

            migrationBuilder.CreateIndex(
               name: "IX_TiposVehiculo_TipoVehiculoId",
               table: "TiposVehiculo",
               column: "TipoVehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EmpleadoId",
                table: "Empleados",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
               name: "IX_VehiculosEntregas_VehiculoEntregaId",
               table: "VehiculoEntregas",
               column: "VehiculoEntregaId");

            migrationBuilder.CreateIndex(
               name: "IX_VehiculosEntregasDetalles_VehiculoEntregaDetalleId",
               table: "VehiculoEntregasDetalles",
               column: "VehiculoEntregaDetalleId");

            migrationBuilder.CreateIndex(
               name: "IX_Procesos_Proceso",
               table: "Procesos",
               column: "ProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivosProcesos_MotivoProcesoId",
                table: "MotivosProcesos",
                column: "MotivoProcesoId");

            migrationBuilder.CreateIndex(
              name: "IX_TiposBascula_TipoBasculaId",
              table: "TiposBascula",
              column: "TipoBasculaId");

            migrationBuilder.CreateIndex(
              name: "IX_TiposContenedor_TipoContenedorId",
              table: "TiposContenedor",
              column: "TipoContenedorId");

            migrationBuilder.CreateIndex(
               name: "IX_PesajesEntrega_EstadoEntregaId",
               table: "EstadosEntrega",
               column: "EstadoEntregaId");

            migrationBuilder.CreateIndex(
             name: "IX_PesajesEntrega_EntregaId",
             table: "Entregas",
             column: "EntregaId");

            migrationBuilder.CreateIndex(
             name: "IX_PesajesArticulo_PesajeEntregaId",
             table: "PesajesEntrega",
             column: "PesajeEntregaId");

            migrationBuilder.CreateIndex(
            name: "IX_PesajesArticulo_DetalleEntregaId",
            table: "DetalleEntregas",
            column: "DetalleEntregaId");

            migrationBuilder.CreateIndex(
            name: "IX_PesajesArticulo_DocumentoId",
            table: "Documentos",
            column: "DocumentoId");

            migrationBuilder.CreateIndex(
            name: "IX_Pesajes_PesajeArticuloId",
            table: "PesajesArticulo",
            column: "PesajeArticuloId");

            migrationBuilder.CreateIndex(
            name: "IX_Pesajes_UsuarioId",
            table: "Usuarios",
            column: "UsuarioId");

            migrationBuilder.CreateIndex(
            name: "IX_Pesajes_TipoBasculaId",
            table: "TiposBascula",
            column: "TipoBasculaId");

            migrationBuilder.CreateIndex(
            name: "IX_PesajesCodigoBarras_PesajeId",
            table: "Pesajes",
            column: "PesajeId");

            migrationBuilder.CreateIndex(
            name: "IX_PesajesContenedor_PesajeId",
            table: "Pesajes",
            column: "PesajeId");

            migrationBuilder.CreateIndex(
            name: "IX_PesajesContenedor_TipoContenedorId",
            table: "TiposContenedor",
            column: "TipoContenedorId");

            migrationBuilder.CreateIndex(
            name: "IX_Evidencias_PesajeEntregaId",
            table: "PesajesEntrega",
            column: "PesajeEntregaId");

            migrationBuilder.CreateIndex(
            name: "IX_Evidencias_UsuarioId",
            table: "Usuarios",
            column: "UsuarioId");

            migrationBuilder.CreateIndex(
            name: "IX_DetallesEvidencia_EvidenciaId",
            table: "DetallesEvidencia",
            column: "EvidenciaId");

            migrationBuilder.CreateIndex(
            name: "IX_CuadresCaja_CajaId",
            table: "Cajas",
            column: "CajaId");

            migrationBuilder.CreateIndex(
            name: "IX_CuadresCaja_EstadoCuadreCajaId",
            table: "EstadosCuadreCaja",
            column: "EstadoCuadreCajaId");

            migrationBuilder.CreateIndex(
            name: "IX_CuadresCaja_UsuarioId",
            table: "Usuarios",
            column: "UsuarioId");

            migrationBuilder.CreateIndex(
            name: "IX_CuadresCaja_InconsistenciaId",
            table: "Inconsistencias",
            column: "InconsistenciaId");

            migrationBuilder.CreateIndex(
            name: "IX_ListasPrecio_Identificacion",
            table: "SociosNegocio",
            column: "Identificacion");

            migrationBuilder.CreateIndex(
            name: "IX_ListasPrecio_CodigoArticulo",
            table: "Articulos",
            column: "ItemCode");

            migrationBuilder.CreateIndex(
            name: "IX_ListasPrecio_ListaPrecioId",
            table: "TiposListaPrecio",
            column: "TipoListaPrecioId");

            migrationBuilder.CreateIndex(
            name: "IX_Inventarios_TiposInventario_TipoInventarioId",
            table: "TiposInventario",
            column: "TipoInventarioId");

            migrationBuilder.CreateIndex(
            name: "IX_Inventarios_Procesos_ProcesoId",
            table: "Procesos",
            column: "ProcesoId");

            migrationBuilder.CreateIndex(
            name: "IX_Inventarios_PesajesArticulo_PesajeArticuloId",
            table: "PesajesArticulo",
            column: "PesajeArticuloId");

            migrationBuilder.CreateIndex(
            name: "IX_Inventarios_DetallesFactura_DetalleFacturaId",
            table: "DetallesFactura",
            column: "DetalleFacturaId");

            migrationBuilder.CreateIndex(
            name: "IX_Facturas_TiposFactura_TipoFacturaId",
            table: "TiposFactura",
            column: "TipoFacturaId");

            migrationBuilder.CreateIndex(
            name: "IX_Facturas_CuadresCaja_CuadreCajaId",
            table: "CuadresCaja",
            column: "CuadreCajaId");

            migrationBuilder.CreateIndex(
            name: "IX_Facturas_Usuarios_UsuarioId",
            table: "Usuarios",
            column: "UsuarioId");

            migrationBuilder.CreateIndex(
            name: "IX_Facturas_SociosNegocio_Identificacion",
            table: "SociosNegocio",
            column: "Identificacion");

            migrationBuilder.CreateIndex(
            name: "IX_DetallesFactura_Facturas_FacturaId",
            table: "Facturas",
            column: "FacturaId");

            migrationBuilder.CreateIndex(
            name: "IX_DetallesFactura_Articulos_CodigoArticulo",
            table: "Articulos",
            column: "ItemCode");

            migrationBuilder.CreateIndex(
            name: "IX_DetallesFactura_Bodegas_CodigoBodega",
            table: "Bodegas",
            column: "WhsCode");

            migrationBuilder.CreateIndex(
            name: "IX_DetallesFactura_Impuestos_IVAId",
            table: "Impuestos",
            column: "ImpuestoId");

            migrationBuilder.CreateIndex(
            name: "IX_VendedoresPuntoVenta_CodigoPuntoVenta",
            table: "Bodegas",
            column: "WhsCode");

            migrationBuilder.CreateIndex(
            name: "IX_Transformaciones_Articulos_CodigoArticulo",
            table: "Articulos",
            column: "ItemCode");

            migrationBuilder.CreateIndex(
            name: "IX_ImpuestosArticulo_Articulos_CodigoArticulo",
            table: "Articulos",
            column: "ItemCode");

            migrationBuilder.CreateIndex(
            name: "IX_ImpuestosArticulo_Impuestos_ImpuestoId",
            table: "Impuestos",
            column: "ImpuestoId");

            migrationBuilder.CreateIndex(
            name: "IX_ImpuestosSocioArticulo_SociosNegocio_Identificacion",
            table: "SociosNegocio",
            column: "Identificacion");

            migrationBuilder.CreateIndex(
            name: "IX_ImpuestosSocioArticulo_Articulos_CodigoArticulo",
            table: "Articulos",
            column: "ItemCode");

            migrationBuilder.CreateIndex(
            name: "IX_ImpuestosSocioArticulo_Impuestos_ImpuestoId",
            table: "Impuestos",
            column: "ImpuestoId");

            migrationBuilder.CreateIndex(
            name: "IX_Facturas_TiposBascula_TipoBasculaId",
            table: "TiposBascula",
            column: "TipoBasculaId");

            migrationBuilder.CreateIndex(
            name: "IX_DetallesFacturaFormaPago_Facturas_FacturaId",
            table: "Facturas",
            column: "FacturaId");

            migrationBuilder.CreateIndex(
            name: "IX_DetallesFacturaFormaPago_FormasPago_FormaPagoId",
            table: "FormasPago",
            column: "Id");

            migrationBuilder.CreateIndex(
            name: "IX_DetallesFacturaFormaPago_Banco_BancoId",
            table: "Bancos",
            column: "BancoId");

            migrationBuilder.CreateIndex(
            name: "IX_UsuariosBodega_Usuarios_UsuarioId",
            table: "Usuarios",
            column: "UsuarioId");

            migrationBuilder.CreateIndex(
            name: "IX_UsuariosBodega_Bodegas_WhsCode",
            table: "Bodegas",
            column: "WhsCode");

            migrationBuilder.CreateIndex(
            name: "IX_TiposBodegasParametrizacion_Bodegas_WhsCode",
            table: "Bodegas",
            column: "WhsCode");

            migrationBuilder.CreateIndex(
           name: "IX_GestionCompras_Acciones_DetallePedidoId",
           table: "DetallePedidos",
           column: "DetallePedidoId");

            migrationBuilder.CreateIndex(
           name: "IX_GestionCompras_Acciones_AccionId",
           table: "Acciones",
           column: "AccionId");


            migrationBuilder.CreateIndex(
            name: "IX_Pedidos_Usuarios_UsuarioAproboId",
            table: "Usuarios",
            column: "UsuarioId");     



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*************************************
             * Indices: Llaves Primarias y Unicas
             ************************************/

            migrationBuilder.DropIndex(table: "TiposListaPrecio",
               name: "UK_TiposListaPrecioNombre");

            migrationBuilder.DropIndex(table: "Impuestos",
               name: "UK_ImpuestosNombre");

            migrationBuilder.DropIndex(table: "Funcionalidades",
                name: "UK_FuncionalidadesNombre");

            migrationBuilder.DropIndex(table: "Roles",
                name: "UK_RolesNombre");

            migrationBuilder.DropIndex(table: "Usuarios",
                name: "UK_UsuariosUsuario");

            migrationBuilder.DropIndex(table: "Modulos",
                name: "UK_ModulosNombre");

            migrationBuilder.DropIndex(table: "ParametrosGenerales",
                name: "UK_ParametrosGeneralesNombre");

            migrationBuilder.DropIndex(table: "UsuariosxRol",
                name: "UK_UsuariosxRolRolId_UsuarioId");

            migrationBuilder.DropIndex(table: "FuncionalidadesxRol",
                name: "UK_FuncionalidadesxRolFuncionalidadId_UsuarioId");

            migrationBuilder.DropIndex(table: "Sesiones",
                name: "UK_SesionesToken");

            migrationBuilder.DropIndex(table: "EstadosArticulo",
              name: "UK_EstadosArticulo_Nombre");

            migrationBuilder.DropIndex(table: "EstadosPedido",
            name: "UK_EstadosPedido_Nombre");

            migrationBuilder.DropIndex(table: "Acciones",
            name: "UK_Acciones_Nombre");

            migrationBuilder.DropIndex(table: "EstadosEntrega",
              name: "UK_EstadosEntrega_Nombre");

            migrationBuilder.DropIndex(table: "Bodegas",
            name: "UK_Bodegas_Email");

            migrationBuilder.DropIndex(table: "TiposVehiculo",
            name: "UK_TiposVehiculoTipoVehiculo");

            migrationBuilder.DropIndex(table: "Empleados",
            name: "UK_EmpleadosCedula");

            migrationBuilder.DropIndex(table: "Procesos",
            name: "UK_ProcesosProceso");

            migrationBuilder.DropIndex(table: "TiposBascula",
            name: "UK_TiposBasculaNombre");

            migrationBuilder.DropIndex(table: "TiposContenedor",
            name: "UK_TiposContenedorNombre");

            migrationBuilder.DropIndex(table: "Evidencias",
             name: "UK_GUID");

            migrationBuilder.DropIndex(table: "Documentos",
            name: "UK_DocumentosDocumento");

            migrationBuilder.DropIndex(table: "Cajas",
               name: "UK_CajasIP");

            migrationBuilder.DropIndex(table: "CuadresCaja",
               name: "UK_CuadresCajaNombre");

            migrationBuilder.DropIndex(table: "Inconsistencias",
               name: "UK_InconsistenciasNombre");

            migrationBuilder.DropIndex(table: "FormasPago",
              name: "UK_FormasPagoNombre");

            migrationBuilder.DropIndex(table: "Empaques",
             name: "UK_EmpaqueNombre");

            /*************************************
            * Tablas
            ************************************/

            migrationBuilder.DropTable(
            name: "TiposBodegasParametrizacion");

            migrationBuilder.DropTable(
            name: "UsuariosBodega");

            migrationBuilder.DropTable(
            name: "DetallesFacturaFormaPago");

            migrationBuilder.DropTable(
            name: "Bancos");

            migrationBuilder.DropTable(
            name: "FormasPago");

            migrationBuilder.DropTable(
            name: "DescuentosDetalleFactura");

            migrationBuilder.DropTable(
            name: "Inventarios");

            migrationBuilder.DropTable(
            name: "DetallesFactura");

            migrationBuilder.DropTable(
            name: "Facturas");

            migrationBuilder.DropTable(
            name: "VendedoresPuntoVenta");

            migrationBuilder.DropTable(
            name: "Vendedores");

            migrationBuilder.DropTable(
            name: "TiposFactura");

            migrationBuilder.DropTable(
            name: "ListasPrecio");

            migrationBuilder.DropTable(
            name: "TiposListaPrecio");

            migrationBuilder.DropTable(
            name: "MotivosProcesos");

            migrationBuilder.DropTable(
            name: "VehiculoEntregas");

            migrationBuilder.DropTable(
            name: "VehiculoEntregasDetalles");

            migrationBuilder.DropTable(
            name: "Empleados");

            migrationBuilder.DropTable(
            name: "ParametrosGenerales");

            migrationBuilder.DropTable(
            name: "RegistrosAuditoria");

            migrationBuilder.DropTable(
            name: "FuncionalidadesxRol");

            migrationBuilder.DropTable(
            name: "UsuariosxRol");

            migrationBuilder.DropTable(
            name: "Funcionalidades");

            migrationBuilder.DropTable(
            name: "Roles");

            migrationBuilder.DropTable(
            name: "Usuarios");

            migrationBuilder.DropTable(
            name: "Modulos");

            migrationBuilder.DropTable(
            name: "Sesiones");

            migrationBuilder.DropTable(
            name: "Bodegas");

            migrationBuilder.DropTable(
            name: "EstadosPedido");

            migrationBuilder.DropTable(
           name: "Acciones");

            migrationBuilder.DropTable(
            name: "EstadosEntrega");

            migrationBuilder.DropTable(
            name: "TiposContenedor");

            migrationBuilder.DropTable(
            name: "PesajesContenedor");

            migrationBuilder.DropTable(
            name: "Pesajes");

            migrationBuilder.DropTable(
            name: "PesajesCodidgoBarras");

            migrationBuilder.DropTable(
            name: "Pesajes");

            migrationBuilder.DropTable(
            name: "PesajesArticulo");

            migrationBuilder.DropTable(
            name: "PesajesEntrega");

            migrationBuilder.DropTable(
            name: "DetalleEntregas");

            migrationBuilder.DropTable(
            name: "Entregas");

            migrationBuilder.DropTable(
            name: "TiposSolicitud");

            migrationBuilder.DropTable(
            name: "Pedidos");

            migrationBuilder.DropTable(
            name: "EstadosArticulo");

            migrationBuilder.DropTable(
            name: "ArticulosXBodega");

            migrationBuilder.DropTable(
            name: "Articulos");

            migrationBuilder.DropTable(
            name: "GestionCompras");

            migrationBuilder.DropTable(
            name: "DetallePedidos");

            migrationBuilder.DropTable(
            name: "Empaques");

            migrationBuilder.DropTable(
            name: "LogsIntegracion");

            migrationBuilder.DropTable(
            name: "CostosTransportes");

            migrationBuilder.DropTable(
            name: "ClientesExternos");

            migrationBuilder.DropTable(
            name: "Motivos");

            migrationBuilder.DropTable(
            name: "Muelles");

            migrationBuilder.DropTable(
            name: "Procesos");

            migrationBuilder.DropTable(
            name: "TiposVehiculo");

            migrationBuilder.DropTable(
            name: "PesajesTolerancia");

            migrationBuilder.DropTable(
            name: "DetallesEvidencia");

            migrationBuilder.DropTable(
            name: "Evidencias");

            migrationBuilder.DropTable(
            name: "Documentos");

            migrationBuilder.DropTable(
            name: "CuadresCaja");

            migrationBuilder.DropTable(
            name: "Cajas");

            migrationBuilder.DropTable(
            name: "EstadosCuadreCaja");

            migrationBuilder.DropTable(
            name: "Inconsistencias");

            migrationBuilder.DropTable(
            name: "SociosNegocio");

            migrationBuilder.DropTable(
            name: "ImpuestosArticulo");

            migrationBuilder.DropTable(
            name: "ImpuestosSocioArticulo");

            migrationBuilder.DropTable(
            name: "Impuestos");

            migrationBuilder.DropTable(
            name: "Series");

            migrationBuilder.DropTable(
            name: "ProduccionSemanal");

            migrationBuilder.DropTable(
            name: "ProduccionDiaria");

            migrationBuilder.DropTable(
            name: "DetalleProduccionDiaria");

        }
    }
}
