using Microsoft.EntityFrameworkCore.Migrations;

namespace EVO_DataAccess.Migrations
{
    public partial class _2_crear_procedimientos_almacenados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosRegistrosAuditoria] (
  @desde INT,
  @hasta INT
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT PaginatedTable.RegistroAuditoriaId, PaginatedTable.Fecha,
         PaginatedTable.UsuarioId, PaginatedTable.Usuario, PaginatedTable.Accion,
         PaginatedTable.Parametros, PaginatedTable.IP
  FROM (
        SELECT RegistrosAuditoria.RegistroAuditoriaId,
               CONVERT(VARCHAR(10), RegistrosAuditoria.Fecha, 103) + ' '  + convert(VARCHAR(8), RegistrosAuditoria.Fecha, 14) AS Fecha,
               RegistrosAuditoria.UsuarioId, Usuarios.Usuario, RegistrosAuditoria.Accion,
               RegistrosAuditoria.Parametros, RegistrosAuditoria.IP, ROW_NUMBER() OVER (ORDER BY RegistrosAuditoria.RegistroAuditoriaId) AS RowNum
        FROM RegistrosAuditoria
        INNER JOIN Usuarios ON RegistrosAuditoria.UsuarioId = Usuarios.UsuarioId
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.RowNum DESC;
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosRegistrosAuditoria]

AS
BEGIN
  SET NOCOUNT ON;

  SELECT COUNT(1) AS nRegistros
  FROM RegistrosAuditoria
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosRegistrosAuditoriaxFiltro]
(
    @Desde INT,
    @Hasta INT,
    @filtroAccion NVARCHAR(255) = NULL,
    @filtroParametros NVARCHAR(MAX) = NULL,
    @filtroFecha NVARCHAR(10) = NULL,
    @filtroUsuario NVARCHAR(255) = NULL,
    @filtroIP NVARCHAR(255) = NULL
)

AS
BEGIN
    SET NOCOUNT ON;

    SELECT PaginatedTable.RegistroAuditoriaId, PaginatedTable.Fecha,
           PaginatedTable.UsuarioId, PaginatedTable.Usuario, PaginatedTable.Accion,
           PaginatedTable.Parametros, PaginatedTable.IP
    FROM (
          SELECT TablePlainDates.RegistroAuditoriaId, TablePlainDates.Fecha,
                 TablePlainDates.UsuarioId, TablePlainDates.Usuario, TablePlainDates.Accion, TablePlainDates.Parametros,
                 TablePlainDates.IP, ROW_NUMBER() OVER (ORDER BY TablePlainDates.RegistroAuditoriaId) AS RowNum
          FROM (
                SELECT RegistrosAuditoria.RegistroAuditoriaId,
                       CONVERT(VARCHAR(10), RegistrosAuditoria.Fecha, 103) + ' '  + convert(VARCHAR(8), RegistrosAuditoria.Fecha, 14) AS Fecha,
                       RegistrosAuditoria.UsuarioId, Usuarios.Usuario, RegistrosAuditoria.Accion,
                       RegistrosAuditoria.Parametros, RegistrosAuditoria.IP
                FROM RegistrosAuditoria
                INNER JOIN Usuarios ON RegistrosAuditoria.UsuarioId = Usuarios.UsuarioId
              ) TablePlainDates
          WHERE ((TablePlainDates.Accion LIKE '%' + @filtroAccion + '%') OR (@filtroAccion IS NULL))
            AND ((TablePlainDates.Parametros LIKE '%' + @filtroParametros + '%') OR (@filtroParametros IS NULL))
            AND ((TablePlainDates.Fecha LIKE '%' + @filtroFecha + '%') OR (@filtroFecha IS NULL))
            AND ((TablePlainDates.Usuario LIKE '%' + @filtroUsuario + '%') OR (@filtroUsuario IS NULL))
            AND ((TablePlainDates.IP LIKE '%' + @filtroIP + '%') OR (@filtroIP IS NULL))
         ) PaginatedTable
    WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta);
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosRolesxFiltro]
(            
  @desde INT,            
  @hasta INT,            
  @filtroNombre NVARCHAR(255) = NULL            
)

AS

BEGIN
  SET NOCOUNT ON;            

  SELECT PaginatedTable.RolId, PaginatedTable.Nombre, PaginatedTable.Activo
  FROM (
        SELECT Roles.RolId, Roles.Nombre, Roles.Activo, ROW_NUMBER() OVER (ORDER BY Roles.RolId) AS RowNum
        FROM Roles
        WHERE (Roles.Nombre like '%' + @filtroNombre + '%')
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta);
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosRegistrosAuditoriaxFiltro]
(
  @filtroAccion NVARCHAR(MAX) = NULL,
  @filtroFecha NVARCHAR(10) = NULL,
  @filtroUsuario NVARCHAR(255) = NULL,
  @filtroIP NVARCHAR(MAX) = NULL,
  @filtroParametros NVARCHAR(MAX) = NULL
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT COUNT(1) AS nRegistros
  FROM (
        SELECT TablePlainDates.RegistroAuditoriaId, TablePlainDates.Fecha,
               TablePlainDates.UsuarioId, TablePlainDates.Usuario, TablePlainDates.Accion,
               TablePlainDates.IP, ROW_NUMBER() OVER (ORDER BY TablePlainDates.RegistroAuditoriaId) AS RowNum
        FROM (
              SELECT RegistrosAuditoria.RegistroAuditoriaId,
                     CONVERT(VARCHAR(10), RegistrosAuditoria.Fecha, 103) + ' '  + convert(VARCHAR(8), RegistrosAuditoria.Fecha, 14) AS Fecha,
                     RegistrosAuditoria.UsuarioId, Usuarios.Usuario, RegistrosAuditoria.Accion,
                     RegistrosAuditoria.IP,RegistrosAuditoria.Parametros
              FROM RegistrosAuditoria
              INNER JOIN Usuarios ON RegistrosAuditoria.UsuarioId = Usuarios.UsuarioId
             ) TablePlainDates
        WHERE ((TablePlainDates.Accion LIKE '%' + @filtroAccion + '%') OR (@filtroAccion IS NULL))
          AND ((TablePlainDates.Parametros LIKE '%' + @filtroParametros + '%') OR (@filtroParametros IS NULL))
          AND ((TablePlainDates.Fecha LIKE '%' + @filtroFecha + '%') OR (@filtroFecha IS NULL))
          AND ((TablePlainDates.Usuario LIKE '%' + @filtroUsuario + '%') OR (@filtroUsuario IS NULL))
          AND ((TablePlainDates.IP LIKE '%' + @filtroIP + '%' ) OR (@filtroIP IS NULL))
       ) PaginatedTable;
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosRolesxFiltro]
(
    @filtroNombre NVARCHAR(255) = NULL
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT COUNT(1) AS nRegistros
  FROM (
        SELECT Roles.RolId, Roles.Nombre, Roles.Activo, ROW_NUMBER() OVER (ORDER BY Roles.RolId) AS RowNum
        FROM Roles
        WHERE (Roles.Nombre like '%' + @filtroNombre + '%')
       ) PaginatedTable;
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE ObtenerTodosModulos
(
  @desde INT,
  @hasta INT
)
AS
BEGIN
  SELECT PaginatedTable.ModuloID, PaginatedTable.Nombre, PaginatedTable.Activo
  FROM (
        SELECT Modulos.ModuloID, Modulos.Nombre, Modulos.Activo,
               ROW_NUMBER() OVER(ORDER BY Modulos.ModuloID) AS RowNum
        FROM Modulos
        WHERE (Modulos.Activo = 1)
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.RowNum DESC;
END
";


            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosParametrosGenerales]
(
  @desde INT,
  @hasta INT
)
AS
BEGIN
  SELECT PaginatedTable.ParametroGeneralId, PaginatedTable.Nombre, PaginatedTable.Valor ,PaginatedTable.Activo
  FROM (
        SELECT ParametrosGenerales.ParametroGeneralId, ParametrosGenerales.Nombre, ParametrosGenerales.Valor,ParametrosGenerales.Activo,
               ROW_NUMBER() OVER(ORDER BY ParametrosGenerales.ParametroGeneralId) AS RowNum
        FROM ParametrosGenerales
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.RowNum DESC;
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosRoles]
(
    @desde INT,
    @hasta INT
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT PaginatedTable.RolId, PaginatedTable.Nombre, PaginatedTable.Activo
  FROM (
        SELECT Roles.RolId, Roles.Nombre, Roles.Activo, ROW_NUMBER() OVER (ORDER BY Roles.RolId) AS RowNum
        FROM Roles
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.RowNum DESC;
END
";

            migrationBuilder.Sql(sp);
            sp = @"
CREATE PROCEDURE ObtenerUsuariosxRol
(
  @desde INT,
  @hasta INT,
  @idRol INT
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT PaginatedTable.UsuarioId,
		 PaginatedTable.Usuario as NombreUsuario,
		 PaginatedTable.Nombre,
		 PaginatedTable.RowNum
  FROM (
        SELECT u.UsuarioId as Usuarioid, u.Usuario, u.Nombre, ur.RolId, ROW_NUMBER() OVER (ORDER BY u.usuarioId) AS RowNum
        FROM usuarios u
        INNER JOIN UsuariosxRol ur ON u.Usuarioid = ur.UsuarioId
        WHERE u.Activo = 1
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) AND PaginatedTable.RolId = @idRol
  ORDER BY PaginatedTable.RowNum DESC;
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosUsuariosxRol]
	@RolId INT
AS
BEGIN
  SET NOCOUNT ON;

  SELECT COUNT(1) AS nRegistros
  FROM UsuariosxRol INNER JOIN Usuarios
  ON UsuariosxRol.UsuarioId=Usuarios.UsuarioId
  WHERE RolId = @RolId AND Usuarios.Activo = 1
END";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosUsuariosxRolxFiltro]
(
    @Desde INT,
    @Hasta INT,
    @Usuario NVARCHAR(255) = NULL,
	@Nombre NVARCHAR (155) = NULL,
	@RolId INT
)

AS
BEGIN
    SET NOCOUNT ON;

    SELECT PaginatedTable.UsuarioId,
		   PaginatedTable.Usuario as NombreUsuario,
		   PaginatedTable.Nombre,
		   PaginatedTable.RowNum
    FROM (
          SELECT TablePlainDates.UsuarioId as Usuarioid, TablePlainDates.Usuario, TablePlainDates.Nombre, TablePlainDates.RolId, ROW_NUMBER() OVER (ORDER BY TablePlainDates.usuarioId) AS RowNum
          FROM (
                 SELECT u.UsuarioId as Usuarioid, u.Usuario, u.Nombre, ur.RolId, ROW_NUMBER() OVER (ORDER BY u.usuarioId) AS RowNum
				 FROM usuarios u
				 INNER JOIN UsuariosxRol ur ON u.Usuarioid = ur.UsuarioId
                 WHERE u.Activo = 1 
              ) TablePlainDates
          WHERE ((TablePlainDates.Usuario LIKE '%' + @Usuario + '%') OR (@Usuario IS NULL))
				AND ((TablePlainDates.Nombre LIKE '%' + @Nombre + '%') OR (@Nombre IS NULL))
				AND ((TablePlainDates.RolId = @RolId ) OR (@RolId IS NULL))
         ) PaginatedTable
    WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta);
END";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosUsuariosxRolxFiltro]
(
    @Usuario NVARCHAR(255) = NULL,
	@Nombre NVARCHAR (155) = NULL,
	@RolId INT
)

AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(1) AS nRegistros
    FROM (
          SELECT TablePlainDates.UsuarioId as Usuarioid, TablePlainDates.Usuario, TablePlainDates.Nombre, TablePlainDates.RolId, ROW_NUMBER() OVER (ORDER BY TablePlainDates.usuarioId) AS RowNum
			FROM (
                 SELECT u.UsuarioId as Usuarioid, u.Usuario, u.Nombre, ur.RolId, ROW_NUMBER() OVER (ORDER BY u.usuarioId) AS RowNum
					 FROM usuarios u
					 INNER JOIN UsuariosxRol ur ON u.Usuarioid = ur.UsuarioId
                     WHERE u.Activo = 1 
              ) TablePlainDates
			WHERE ((TablePlainDates.Usuario LIKE '%' + @Usuario + '%') OR (@Usuario IS NULL))
				AND ((TablePlainDates.Nombre LIKE '%' + @Nombre + '%') OR (@Nombre IS NULL))
				AND ((TablePlainDates.RolId = @RolId ) OR (@RolId IS NULL))
         ) PaginatedTable;
END";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosSesiones]
(
  @desde INT,
  @hasta INT
)
AS
BEGIN
  SELECT PaginatedTable.SesionId, PaginatedTable.Token, PaginatedTable.IP,PaginatedTable.Usuario,PaginatedTable.FechaInicio,PaginatedTable.FechaExpiracion
  FROM (
       SELECT Sesiones.SesionId, Sesiones.Token, Sesiones.IP, Usuarios.Usuario, Sesiones.FechaInicio, Sesiones.FechaExpiracion,
  ROW_NUMBER() OVER(ORDER BY Sesiones.SesionId) AS RowNum
FROM Sesiones INNER JOIN Usuarios ON Sesiones.UsuarioId = Usuarios.UsuarioId
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.RowNum DESC;
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosSesiones]
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM Sesiones
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosSesionesxFiltro]
(
    @Desde INT,
    @Hasta INT,
	@filtroSesionId NVARCHAR(MAX) = NULL, 
    @filtroToken NVARCHAR(68) = NULL, 
    @filtroFechaInicio NVARCHAR(10) = NULL,
	@filtroFechaExpiracion NVARCHAR(10) = NULL,
    @filtroUsuario NVARCHAR(255) = NULL,
    @filtroIP NVARCHAR(15) = NULL
)

AS
BEGIN
    SET NOCOUNT ON;

    SELECT PaginatedTable.FechaInicio, PaginatedTable.FechaExpiracion,
           PaginatedTable.SesionId, PaginatedTable.Usuario, PaginatedTable.Token,
           PaginatedTable.IP
    FROM (
          SELECT TablePlainDates.FechaInicio, TablePlainDates.FechaExpiracion,
                 TablePlainDates.SesionId, TablePlainDates.Usuario, TablePlainDates.Token, TablePlainDates.IP,
                ROW_NUMBER() OVER (ORDER BY TablePlainDates.SesionId) AS RowNum
          FROM (
                SELECT s.SesionId,
                       CONVERT(VARCHAR(10), s.FechaInicio, 103) + ' '  + convert(VARCHAR(8), s.FechaInicio, 14) AS FechaInicio,
					   CONVERT(VARCHAR(10), s.FechaExpiracion, 103) + ' '  + convert(VARCHAR(8), s.FechaExpiracion, 14) AS FechaExpiracion,
                       s.IP, s.Token , u.Usuario
                FROM Sesiones s
                INNER JOIN Usuarios u ON s.UsuarioId = u.UsuarioId
              ) TablePlainDates
          WHERE ((TablePlainDates.FechaInicio LIKE '%' + @filtroFechaInicio + '%') OR (@filtroFechaInicio IS NULL))
            AND ((TablePlainDates.FechaExpiracion LIKE '%' + @filtroFechaExpiracion + '%') OR (@filtroFechaExpiracion IS NULL))
            AND ((TablePlainDates.SesionId LIKE '%' + @filtroSesionId + '%') OR (@filtroSesionId IS NULL))
            AND ((TablePlainDates.Usuario LIKE '%' + @filtroUsuario + '%') OR (@filtroUsuario IS NULL))
			AND ((TablePlainDates.Token LIKE '%' + @filtroToken + '%') OR (@filtroToken IS NULL))
            AND ((TablePlainDates.IP LIKE '%' + @filtroIP + '%') OR (@filtroIP IS NULL))

         ) PaginatedTable
    WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta);
END";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosRegistrosSesionesxFiltro]
(
    @Desde INT,
    @Hasta INT,
	@filtroSesionId NVARCHAR(MAX) = NULL, 
    @filtroToken NVARCHAR(68) = NULL, 
    @filtroFechaInicio NVARCHAR(10) = NULL,
	@filtroFechaExpiracion NVARCHAR(10) = NULL,
    @filtroUsuario NVARCHAR(255) = NULL,
    @filtroIP NVARCHAR(15) = NULL
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT COUNT(1) AS nRegistros
  FROM (
          SELECT TablePlainDates.FechaInicio, TablePlainDates.FechaExpiracion,
                 TablePlainDates.SesionId, TablePlainDates.Usuario, TablePlainDates.Token, TablePlainDates.IP,
                ROW_NUMBER() OVER (ORDER BY TablePlainDates.SesionId) AS RowNum
          FROM (
                SELECT s.SesionId,
                       CONVERT(VARCHAR(10), s.FechaInicio, 103) + ' '  + convert(VARCHAR(8), s.FechaInicio, 14) AS FechaInicio,
					   CONVERT(VARCHAR(10), s.FechaExpiracion, 103) + ' '  + convert(VARCHAR(8), s.FechaExpiracion, 14) AS FechaExpiracion,
                       s.IP, s.Token , u.Usuario
                FROM Sesiones s
                INNER JOIN Usuarios u ON s.UsuarioId = u.UsuarioId
              ) TablePlainDates
          WHERE ((TablePlainDates.FechaInicio LIKE '%' + @filtroFechaInicio + '%') OR (@filtroFechaInicio IS NULL))
            AND ((TablePlainDates.FechaExpiracion LIKE '%' + @filtroFechaExpiracion + '%') OR (@filtroFechaExpiracion IS NULL))
            AND ((TablePlainDates.SesionId LIKE '%' + @filtroSesionId + '%') OR (@filtroSesionId IS NULL))
            AND ((TablePlainDates.Usuario LIKE '%' + @filtroUsuario + '%') OR (@filtroUsuario IS NULL))
			AND ((TablePlainDates.Token LIKE '%' + @filtroToken + '%') OR (@filtroToken IS NULL))
            AND ((TablePlainDates.IP LIKE '%' + @filtroIP + '%') OR (@filtroIP IS NULL))

         ) PaginatedTable
    WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta);
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosLogsIntegracion]
(
  @desde INT,
  @hasta INT,  
  @jobId uniqueidentifier
)
AS
BEGIN        
  SELECT 
   (select top 1 run_status FROM msdb.dbo.sysjobhistory where instance_id>=PaginatedTable.InstanceId and job_id=@jobId and step_id=0) AS Estado,
  (select top 1 message FROM msdb.dbo.sysjobhistory where instance_id>=PaginatedTable.InstanceId and job_id=@jobId and step_id=0) AS LogJob,
  (SELECT  msdb.dbo.agent_datetime(run_date, run_time) FROM msdb.dbo.sysjobhistory WHERE instance_id= PaginatedTable.InstanceId) AS FechaInicio ,
  (SELECT DATEADD (ss, run_duration , CONVERT( DATETIME,  msdb.dbo.agent_datetime(run_date, run_time) ) )  FROM msdb.dbo.sysjobhistory WHERE instance_id= PaginatedTable.InstanceId)
  AS FechaFin, 
  (SELECT STRING_AGG([message], CHAR(999999999)) FROM [EVO].[dbo].[sysssislog] WHERE executionid= PaginatedTable.Executionid) LogIntegracion  
  FROM (
        SELECT InstanceId,JobId,ExecutionId,
		Row_Number() OVER(ORDER BY LogIntegracionId) AS RowNum
        FROM LogsIntegracion 
		WHERE jobId = @jobId	
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosConteoLogsIntegracion]
(
 @jobId uniqueidentifier
)
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) FROM LogsIntegracion 
  WHERE jobId = @jobId
END";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosArticulosxBodega] (
  @desde INT,
  @hasta INT,
  @whsCodePuntoVenta NVARCHAR(8),
  @whsCodePlanta NVARCHAR(8)
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT 
    PaginatedTable.CodigoArticulo,
    PaginatedTable.NombreArticulo,
	PaginatedTable.UnidadMedida,
    PaginatedTable.Stock,
    PaginatedTable.Minimo,
    PaginatedTable.Maximo,
	PaginatedTable.EstadoId,
	PaginatedTable.EmpaqueId
  FROM (
        SELECT 
			ab.ItemCode AS CodigoArticulo,
			a.ItemName AS NombreArticulo,
			a.SalUnitMsr AS UnidadMedida,
			ab.OnHand AS Stock,
			ab.MinStock AS Minimo,
			ab.MaxStock AS Maximo,
			ROW_NUMBER() OVER (ORDER BY ab.ItemCode) AS RowNum,
			a.EstadoId,
			a.EmpaqueId
		    FROM ArticulosXBodega ab , Articulos a 
		    WHERE ab.ItemCode=a.ItemCode 
			AND UPPER(ab.ItemCode) LIKE UPPER(SUBSTRING(@whsCodePlanta,charindex('-',@whsCodePlanta)+1,LEN(@whsCodePlanta)))+'-%' 
		    AND UPPER(ab.WhsCode) = UPPER(@whsCodePuntoVenta)	  
       ) PaginatedTable
  --WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.RowNum DESC;
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosArticulosxBodega] ( 
  @whsCode NVARCHAR(8),
  @whsCodePlanta NVARCHAR(8)
)
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM ArticulosXBodega where WhsCode=@whsCode
  AND UPPER(ItemCode) LIKE UPPER(SUBSTRING(@whsCodePlanta,charindex('-',@whsCodePlanta)+1,LEN(@whsCodePlanta)))+'-%'
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosArticulosBodegaxFiltro]
(
    @desde INT,
    @hasta INT,
	@codigoBodega NVARCHAR(8) = NULL,
    @codigoArticulo NVARCHAR(255) = NULL,
    @nombreArticulo NVARCHAR(100) = NULL,
    @stock NVARCHAR(20) = NULL,
    @minimo NVARCHAR(20) = NULL,
    @maximo NVARCHAR(20) = NULL,
	@unidadMedida NVARCHAR(100) = NULL
)

AS
BEGIN
    SET NOCOUNT ON;

    SELECT PaginatedTable.CodigoArticulo, PaginatedTable.NombreArticulo,PaginatedTable.UnidadMedida,
           PaginatedTable.Stock, PaginatedTable.Minimo, PaginatedTable.Maximo
    FROM (
          SELECT TablePlainDates.CodigoArticulo, TablePlainDates.NombreArticulo,TablePlainDates.UnidadMedida,
                 TablePlainDates.Stock, TablePlainDates.Minimo, TablePlainDates.Maximo,
                 ROW_NUMBER() OVER (ORDER BY TablePlainDates.CodigoArticulo) AS RowNum
          FROM (
                SELECT 
					ab.ItemCode AS CodigoArticulo,
					A.ItemName AS NombreArticulo,
					A.SalUnitMsr AS UnidadMedida,
					ab.OnHand AS Stock,
					ab.MinStock AS Minimo,
					ab.MaxStock AS Maximo,
					ROW_NUMBER() OVER (ORDER BY ab.ItemCode) AS RowNum
		            FROM ArticulosXBodega ab , Articulos a 
		            WHERE ab.ItemCode=a.ItemCode AND UPPER(ab.ItemCode) LIKE '%'+UPPER(@codigoBodega)+'%' 
		            AND UPPER(ab.WhsCode) LIKE '%' + @codigoBodega	  
              ) TablePlainDates
           WHERE ((TablePlainDates.CodigoArticulo LIKE '%' + @codigoArticulo + '%') OR (@codigoArticulo IS NULL))
            AND ((TablePlainDates.NombreArticulo LIKE '%' + @nombreArticulo + '%') OR (@nombreArticulo IS NULL))
			AND ((TablePlainDates.UnidadMedida LIKE '%' + @unidadMedida + '%') OR (@unidadMedida IS NULL))
            AND ((TablePlainDates.Stock LIKE '%' + @stock + '%') OR (@stock IS NULL))
            AND ((TablePlainDates.Minimo LIKE '%' + @minimo + '%') OR (@minimo IS NULL))
            AND ((TablePlainDates.Maximo LIKE '%' + @maximo + '%') OR (@maximo IS NULL))
         ) PaginatedTable
    WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta);
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosArticulosBodegaxFiltro]
(  
	@codigoBodega NVARCHAR(8) = NULL,
    @codigoArticulo NVARCHAR(255) = NULL,
    @nombreArticulo NVARCHAR(100) = NULL,
    @stock NVARCHAR(20) = NULL,
    @minimo NVARCHAR(20) = NULL,
    @maximo NVARCHAR(20) = NULL,
	@unidadMedida NVARCHAR(100) = NULL
)

AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(1) AS nRegistros
    FROM (
          SELECT TablePlainDates.CodigoArticulo, TablePlainDates.NombreArticulo,TablePlainDates.UnidadMedida,
                 TablePlainDates.Stock, TablePlainDates.Minimo, TablePlainDates.Maximo,
                 ROW_NUMBER() OVER (ORDER BY TablePlainDates.CodigoArticulo) AS RowNum
          FROM (
                SELECT 
					ab.ItemCode AS CodigoArticulo,
					a.ItemName AS NombreArticulo,
					a.SalUnitMsr AS UnidadMedida,
					ab.OnHand AS Stock,
					ab.MinStock AS Minimo,
					ab.MaxStock AS Maximo,
					ROW_NUMBER() OVER (ORDER BY ab.ItemCode) AS RowNum
		        FROM ArticulosXBodega ab , Articulos a 
		            WHERE ab.ItemCode=a.ItemCode AND UPPER(ab.ItemCode) LIKE '%'+UPPER(@codigoBodega)+'%' 
		            AND UPPER(ab.WhsCode) LIKE '%' + @codigoBodega	  
              ) TablePlainDates
           WHERE ((TablePlainDates.CodigoArticulo LIKE '%' + @codigoArticulo + '%') OR (@codigoArticulo IS NULL))
            AND ((TablePlainDates.NombreArticulo LIKE '%' + @nombreArticulo + '%') OR (@nombreArticulo IS NULL))
			AND ((TablePlainDates.UnidadMedida LIKE '%' + @unidadMedida + '%') OR (@unidadMedida IS NULL))
            AND ((TablePlainDates.Stock LIKE '%' + @stock + '%') OR (@stock IS NULL))
            AND ((TablePlainDates.Minimo LIKE '%' + @minimo + '%') OR (@minimo IS NULL))
            AND ((TablePlainDates.Maximo LIKE '%' + @maximo + '%') OR (@maximo IS NULL))
         ) PaginatedTable   
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosPedidos]
(  
  @whsCode VARCHAR(8)
)
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM Pedidos p 
  INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
  WHERE P.WhsCode=@whsCode AND ep.Nombre!='Borrador'
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidos]
(
  @desde INT,
  @hasta INT,
  @whsCode VARCHAR(8)
)
AS
BEGIN
  SELECT 
  PaginatedTable.NumeroPedido,
  PaginatedTable.FechaSolicitud,
  PaginatedTable.FechaEntrega,
  PaginatedTable.Estado,
  PaginatedTable.Planta,
  PaginatedTable.WhsCode,
  PaginatedTable.PedidoId,
  PaginatedTable.CodigoSolicitudA,
  PaginatedTable.Editar,
  PaginatedTable.TipoSolicitud
  FROM (
        SELECT 		
		ROW_NUMBER() OVER(ORDER BY p.PedidoId) AS RowNum,
		p.NumeroPedido,
		Convert(varchar(10),CONVERT(date,p.FechaPedido,106),103) AS FechaSolicitud,
	    Convert(varchar(10),CONVERT(date,p.FechaEntrega,106),103) AS FechaEntrega,
		p.WhsCode,
		ep.Nombre AS Estado,
		(select WhsName from Bodegas where WhsCode=p.SolicitudPara) AS Planta,
		p.PedidoId,
		(select WhsCode from Bodegas where WhsCode=p.SolicitudPara) AS CodigoSolicitudA,
		ep.EditarPedido AS Editar,
		ts.TipoSolicitudNombre AS TipoSolicitud		
        FROM Pedidos p
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
		INNER JOIN TiposSolicitud ts on p.TipoSolicitudId=ts.TipoSolicitudId
        WHERE P.WhsCode=@whsCode AND ep.Nombre!='Borrador'
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.RowNum DESC;
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosxFiltro]
(
  @desde INT, 
  @hasta INT,
  @codigoBodega  NVARCHAR(8),
  @plantaBeneficio  NVARCHAR(8) ,
  @plantaDerivados  NVARCHAR(8) ,
  @estado INT ,
  @fechaDesde  NVARCHAR(10) ,
  @fechaHasta  NVARCHAR(10) ,
  @pendientes NVARCHAR(1) ,
  @numeropedido NVARCHAR(255)
)
AS
BEGIN
IF @numeropedido = ''
BEGIN
    IF @pendientes = '1' 
BEGIN

    IF @plantaBeneficio = '' AND @plantaDerivados= ''

	BEGIN
	 SET NOCOUNT ON;
	SELECT 
	PaginatedTable.PedidoId ,
	PaginatedTable.NumeroPedido,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaPedido, 103)) FechaSolicitud,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaEntrega, 103)) FechaEntrega,		
	PaginatedTable.Nombre Estado,
	UPPER(LEFT(PaginatedTable.WhsName, 1)) + LOWER(SUBSTRING(PaginatedTable.WhsName, 2, LEN(PaginatedTable.WhsName))) Planta,
	PaginatedTable.WhsCode
  FROM (
        SELECT 
		
		PaginatedTable.PedidoId, PaginatedTable.WhsCode, PaginatedTable.SolicitudPara, 
				PaginatedTable.UsuarioId, PaginatedTable.FechaPedido,PaginatedTable.Nombre,PaginatedTable.WhsName,
				PaginatedTable.FechaEntrega, PaginatedTable.NumeroPedido,PaginatedTable.EstadoPedidoId,
				ROW_NUMBER() OVER(ORDER BY PaginatedTable.PedidoId) AS RowNum		
		FROM (
		   
		   SELECT
				p.PedidoId,
				p.FechaPedido,
				p.FechaEntrega,
				b.WhsCode,
				p.SolicitudPara,
				p.UsuarioId,
				ep.Nombre,
				p.NumeroPedido,
				P.EstadoPedidoId,
				b.WhsName
				FROM Pedidos p 
				INNER JOIN Bodegas b on  p.WhsCode = b.WhsCode	
				INNER JOIN Bodegas bb on  p.SolicitudPara = bb.WhsCode	
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId  

       ) PaginatedTable
    WHERE (

	PaginatedTable.WhsCode = @codigoBodega 	
	 AND (PaginatedTable.Nombre <> 'Cerrado') 
	 )

   ) PaginatedTable
 WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
AND (CONVERT(DATETIME, PaginatedTable.FechaPedido, 103) BETWEEN CONVERT(datetime, @fechaDesde, 103) AND DATEADD(DAY,1, CONVERT(datetime, @fechaHasta, 103) ));
	END
	ELSE
	BEGIN
	 SET NOCOUNT ON;
	SELECT 
	PaginatedTable.PedidoId ,
	PaginatedTable.NumeroPedido,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaPedido, 103)) FechaSolicitud,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaEntrega, 103)) FechaEntrega,		
	PaginatedTable.Nombre Estado,
	UPPER(LEFT(PaginatedTable.WhsName, 1)) + LOWER(SUBSTRING(PaginatedTable.WhsName, 2, LEN(PaginatedTable.WhsName))) Planta,
	PaginatedTable.WhsCode
  FROM (
        SELECT 
		
		PaginatedTable.PedidoId, PaginatedTable.WhsCode, PaginatedTable.SolicitudPara, 
				PaginatedTable.UsuarioId, PaginatedTable.FechaPedido,PaginatedTable.Nombre,PaginatedTable.WhsName,
				PaginatedTable.FechaEntrega, PaginatedTable.NumeroPedido,PaginatedTable.EstadoPedidoId,
				ROW_NUMBER() OVER(ORDER BY PaginatedTable.PedidoId) AS RowNum		
		FROM (
		   
		   SELECT
						 p.PedidoId,
						 p.FechaPedido,
						 p.FechaEntrega,
						 b.WhsCode,
						 p.SolicitudPara,
						 p.UsuarioId,
						 ep.Nombre,
						 p.NumeroPedido,
						 P.EstadoPedidoId,
						 b.WhsName
					  FROM Pedidos p 
				INNER JOIN Bodegas b on  p.WhsCode = b.WhsCode	
				INNER JOIN Bodegas bb on  p.SolicitudPara = bb.WhsCode	
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId  

       ) PaginatedTable
    WHERE (

	PaginatedTable.WhsCode = @codigoBodega 
	 AND PaginatedTable.SolicitudPara IN (@plantaBeneficio,@plantaDerivados)	
	 AND (PaginatedTable.Nombre <> 'Cerrado') 
	 )

   ) PaginatedTable
 WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
AND (CONVERT(DATETIME, PaginatedTable.FechaPedido, 103) BETWEEN CONVERT(datetime, @fechaDesde, 103) AND DATEADD(DAY,1, CONVERT(datetime, @fechaHasta, 103) ));
	END

   
END
 ELSE

BEGIN
       IF @plantaBeneficio='' AND @plantaDerivados=''
	   BEGIN
	     SET NOCOUNT ON;
	SELECT 
	PaginatedTable.PedidoId ,
	PaginatedTable.NumeroPedido,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaPedido, 103)) FechaSolicitud,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaEntrega, 103)) FechaEntrega,		
	PaginatedTable.Nombre Estado,
	UPPER(LEFT(PaginatedTable.WhsName, 1)) + LOWER(SUBSTRING(PaginatedTable.WhsName, 2, LEN(PaginatedTable.WhsName))) Planta,
	PaginatedTable.WhsCode
  FROM (
        SELECT 
		
		PaginatedTable.PedidoId, PaginatedTable.WhsCode, PaginatedTable.SolicitudPara, 
				PaginatedTable.UsuarioId, PaginatedTable.FechaPedido,PaginatedTable.Nombre,PaginatedTable.WhsName,
				PaginatedTable.FechaEntrega, PaginatedTable.NumeroPedido,PaginatedTable.EstadoPedidoId,
				ROW_NUMBER() OVER(ORDER BY PaginatedTable.PedidoId) AS RowNum		
		FROM (
		      
			  SELECT
				 p.PedidoId,
				 p.FechaPedido,
				 p.FechaEntrega,
				 b.WhsCode,
				 p.SolicitudPara,
				 p.UsuarioId,
				 ep.Nombre,
				 p.NumeroPedido,
				 P.EstadoPedidoId,
				 b.WhsName
			  FROM Pedidos p 
		INNER JOIN Bodegas b on  p.WhsCode = b.WhsCode	
		INNER JOIN Bodegas bb on  p.SolicitudPara = bb.WhsCode	
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId  
       ) PaginatedTable
    WHERE (
	PaginatedTable.WhsCode = @codigoBodega
	
	 AND (PaginatedTable.EstadoPedidoId = @estado) 
	 )

   ) PaginatedTable
 WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
  AND (CONVERT(DATETIME, PaginatedTable.FechaPedido, 103) BETWEEN CONVERT(datetime, @fechaDesde, 103) AND DATEADD(DAY,1, CONVERT(datetime, @fechaHasta, 103) ));
	   END
	   ELSE
	   BEGIN
	     SET NOCOUNT ON;
	SELECT 
	PaginatedTable.PedidoId ,
	PaginatedTable.NumeroPedido,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaPedido, 103)) FechaSolicitud,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaEntrega, 103)) FechaEntrega,		
	PaginatedTable.Nombre Estado,
	UPPER(LEFT(PaginatedTable.WhsName, 1)) + LOWER(SUBSTRING(PaginatedTable.WhsName, 2, LEN(PaginatedTable.WhsName))) Planta,
	PaginatedTable.WhsCode
  FROM (
        SELECT 
		
		PaginatedTable.PedidoId, PaginatedTable.WhsCode, PaginatedTable.SolicitudPara, 
				PaginatedTable.UsuarioId, PaginatedTable.FechaPedido,PaginatedTable.Nombre,PaginatedTable.WhsName,
				PaginatedTable.FechaEntrega, PaginatedTable.NumeroPedido,PaginatedTable.EstadoPedidoId,
				ROW_NUMBER() OVER(ORDER BY PaginatedTable.PedidoId) AS RowNum		
		FROM (
		      
			  SELECT
				 p.PedidoId,
				 p.FechaPedido,
				 p.FechaEntrega,
				 b.WhsCode,
				 p.SolicitudPara,
				 p.UsuarioId,
				 ep.Nombre,
				 p.NumeroPedido,
				 P.EstadoPedidoId,
				 b.WhsName
			  FROM Pedidos p 
		INNER JOIN Bodegas b on  p.WhsCode = b.WhsCode	
		INNER JOIN Bodegas bb on  p.SolicitudPara = bb.WhsCode	
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId  
       ) PaginatedTable
    WHERE (
	PaginatedTable.WhsCode = @codigoBodega
	 AND PaginatedTable.SolicitudPara IN (@plantaBeneficio,@plantaDerivados)	
	 AND (PaginatedTable.EstadoPedidoId = @estado) 
	 )

   ) PaginatedTable
 WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
  AND (CONVERT(DATETIME, PaginatedTable.FechaPedido, 103) BETWEEN CONVERT(datetime, @fechaDesde, 103) AND DATEADD(DAY,1, CONVERT(datetime, @fechaHasta, 103) ));
	   END

  
 
END	
		
END

ELSE
BEGIN
    IF @pendientes = '1' 
BEGIN

    IF @plantaBeneficio = '' AND @plantaDerivados= ''

	BEGIN
	 SET NOCOUNT ON;
	SELECT 
	PaginatedTable.PedidoId ,
	PaginatedTable.NumeroPedido,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaPedido, 103)) FechaSolicitud,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaEntrega, 103)) FechaEntrega,		
	PaginatedTable.Nombre Estado,
	UPPER(LEFT(PaginatedTable.WhsName, 1)) + LOWER(SUBSTRING(PaginatedTable.WhsName, 2, LEN(PaginatedTable.WhsName))) Planta,
	PaginatedTable.WhsCode
  FROM (
        SELECT 
		
		PaginatedTable.PedidoId, PaginatedTable.WhsCode, PaginatedTable.SolicitudPara, 
				PaginatedTable.UsuarioId, PaginatedTable.FechaPedido,PaginatedTable.Nombre,PaginatedTable.WhsName,
				PaginatedTable.FechaEntrega, PaginatedTable.NumeroPedido,PaginatedTable.EstadoPedidoId,
				ROW_NUMBER() OVER(ORDER BY PaginatedTable.PedidoId) AS RowNum		
		FROM (
		   
		   SELECT
				p.PedidoId,
				p.FechaPedido,
				p.FechaEntrega,
				b.WhsCode,
				p.SolicitudPara,
				p.UsuarioId,
				ep.Nombre,
				p.NumeroPedido,
				P.EstadoPedidoId,
				bb.WhsName
				FROM Pedidos p 
				INNER JOIN Bodegas b on  p.WhsCode = b.WhsCode	
				INNER JOIN Bodegas bb on  p.SolicitudPara = bb.WhsCode	
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId  

       ) PaginatedTable
    WHERE (

	PaginatedTable.WhsCode = @codigoBodega 	
	AND CONCAT(SUBSTRING(WhsCode,CHARINDEX('-', WhsCode)+1,LEN(WhsCode)-CHARINDEX('-', WhsCode)),'-',NumeroPedido) = @numeropedido
	 AND (PaginatedTable.Nombre <> 'Cerrado') 
	 )

   ) PaginatedTable
 WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
AND (CONVERT(DATETIME, PaginatedTable.FechaPedido, 103) BETWEEN CONVERT(datetime, @fechaDesde, 103) AND DATEADD(DAY,1, CONVERT(datetime, @fechaHasta, 103) ));
	END
	ELSE
	BEGIN
	 SET NOCOUNT ON;
	SELECT 
	PaginatedTable.PedidoId ,
	PaginatedTable.NumeroPedido,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaPedido, 103)) FechaSolicitud,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaEntrega, 103)) FechaEntrega,		
	PaginatedTable.Nombre Estado,
	UPPER(LEFT(PaginatedTable.WhsName, 1)) + LOWER(SUBSTRING(PaginatedTable.WhsName, 2, LEN(PaginatedTable.WhsName))) Planta,
	PaginatedTable.WhsCode
  FROM (
        SELECT 
		
		PaginatedTable.PedidoId, PaginatedTable.WhsCode, PaginatedTable.SolicitudPara, 
				PaginatedTable.UsuarioId, PaginatedTable.FechaPedido,PaginatedTable.Nombre,PaginatedTable.WhsName,
				PaginatedTable.FechaEntrega, PaginatedTable.NumeroPedido,PaginatedTable.EstadoPedidoId,
				ROW_NUMBER() OVER(ORDER BY PaginatedTable.PedidoId) AS RowNum		
		FROM (
		   
		   SELECT
						 p.PedidoId,
						 p.FechaPedido,
						 p.FechaEntrega,
						 b.WhsCode,
						 p.SolicitudPara,
						 p.UsuarioId,
						 ep.Nombre,
						 p.NumeroPedido,
						 P.EstadoPedidoId,
						 bb.WhsName
					  FROM Pedidos p 
				INNER JOIN Bodegas b on  p.WhsCode = b.WhsCode	
				INNER JOIN Bodegas bb on  p.SolicitudPara = bb.WhsCode	
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId  

       ) PaginatedTable
    WHERE (

	PaginatedTable.WhsCode = @codigoBodega 
	 AND PaginatedTable.SolicitudPara IN (@plantaBeneficio,@plantaDerivados)	
	 AND CONCAT(SUBSTRING(WhsCode,CHARINDEX('-', WhsCode)+1,LEN(WhsCode)-CHARINDEX('-', WhsCode)),'-',NumeroPedido) = @numeropedido
	 AND (PaginatedTable.Nombre <> 'Cerrado') 
	 )

   ) PaginatedTable
 WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
AND (CONVERT(DATETIME, PaginatedTable.FechaPedido, 103) BETWEEN CONVERT(datetime, @fechaDesde, 103) AND DATEADD(DAY,1, CONVERT(datetime, @fechaHasta, 103) ));
	END
   
END
 ELSE

BEGIN
       IF @plantaBeneficio='' AND @plantaDerivados=''
	   BEGIN
	     SET NOCOUNT ON;
	SELECT 
	PaginatedTable.PedidoId ,
	PaginatedTable.NumeroPedido,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaPedido, 103)) FechaSolicitud,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaEntrega, 103)) FechaEntrega,		
	PaginatedTable.Nombre Estado,
	UPPER(LEFT(PaginatedTable.WhsName, 1)) + LOWER(SUBSTRING(PaginatedTable.WhsName, 2, LEN(PaginatedTable.WhsName))) Planta,
	PaginatedTable.WhsCode
  FROM (
        SELECT 
		
		PaginatedTable.PedidoId, PaginatedTable.WhsCode, PaginatedTable.SolicitudPara, 
				PaginatedTable.UsuarioId, PaginatedTable.FechaPedido,PaginatedTable.Nombre,PaginatedTable.WhsName,
				PaginatedTable.FechaEntrega, PaginatedTable.NumeroPedido,PaginatedTable.EstadoPedidoId,
				ROW_NUMBER() OVER(ORDER BY PaginatedTable.PedidoId) AS RowNum		
		FROM (
		      
			  SELECT
				 p.PedidoId,
				 p.FechaPedido,
				 p.FechaEntrega,
				 b.WhsCode,
				 p.SolicitudPara,
				 p.UsuarioId,
				 ep.Nombre,
				 p.NumeroPedido,
				 P.EstadoPedidoId,
				 bb.WhsName
			  FROM Pedidos p 
		INNER JOIN Bodegas b on  p.WhsCode = b.WhsCode	
		INNER JOIN Bodegas bb on  p.SolicitudPara = bb.WhsCode	
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId  
       ) PaginatedTable
    WHERE (
	PaginatedTable.WhsCode = @codigoBodega
	AND CONCAT(SUBSTRING(WhsCode,CHARINDEX('-', WhsCode)+1,LEN(WhsCode)-CHARINDEX('-', WhsCode)),'-',NumeroPedido) = @numeropedido	
	 AND (PaginatedTable.EstadoPedidoId = @estado) 
	 )

   ) PaginatedTable
 WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
  AND (CONVERT(DATETIME, PaginatedTable.FechaPedido, 103) BETWEEN CONVERT(datetime, @fechaDesde, 103) AND DATEADD(DAY,1, CONVERT(datetime, @fechaHasta, 103) ));
	   END
	   ELSE
	   BEGIN
	     SET NOCOUNT ON;
	SELECT 
	PaginatedTable.PedidoId ,
	PaginatedTable.NumeroPedido,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaPedido, 103)) FechaSolicitud,
	(CONVERT(VARCHAR(10), PaginatedTable.FechaEntrega, 103)) FechaEntrega,		
	PaginatedTable.Nombre Estado,
	UPPER(LEFT(PaginatedTable.WhsName, 1)) + LOWER(SUBSTRING(PaginatedTable.WhsName, 2, LEN(PaginatedTable.WhsName))) Planta,
	PaginatedTable.WhsCode
  FROM (
        SELECT 
		
		PaginatedTable.PedidoId, PaginatedTable.WhsCode, PaginatedTable.SolicitudPara, 
				PaginatedTable.UsuarioId, PaginatedTable.FechaPedido,PaginatedTable.Nombre,PaginatedTable.WhsName,
				PaginatedTable.FechaEntrega, PaginatedTable.NumeroPedido,PaginatedTable.EstadoPedidoId,
				ROW_NUMBER() OVER(ORDER BY PaginatedTable.PedidoId) AS RowNum		
		FROM (
		      
			  SELECT
				 p.PedidoId,
				 p.FechaPedido,
				 p.FechaEntrega,
				 b.WhsCode,
				 p.SolicitudPara,
				 p.UsuarioId,
				 ep.Nombre,
				 p.NumeroPedido,
				 P.EstadoPedidoId,
				 bb.WhsName
			  FROM Pedidos p 
		INNER JOIN Bodegas b on  p.WhsCode = b.WhsCode	
		INNER JOIN Bodegas bb on  p.SolicitudPara = bb.WhsCode	
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId  
       ) PaginatedTable
    WHERE (
	PaginatedTable.WhsCode = @codigoBodega
	 AND PaginatedTable.SolicitudPara IN (@plantaBeneficio,@plantaDerivados)	
	 AND (PaginatedTable.EstadoPedidoId = @estado) 
	 AND CONCAT(SUBSTRING(WhsCode,CHARINDEX('-', WhsCode)+1,LEN(WhsCode)-CHARINDEX('-', WhsCode)),'-',NumeroPedido) = @numeropedido
	 )

   ) PaginatedTable
 WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
  AND (CONVERT(DATETIME, PaginatedTable.FechaPedido, 103) BETWEEN CONVERT(datetime, @fechaDesde, 103) AND DATEADD(DAY,1, CONVERT(datetime, @fechaHasta, 103) ));
	   END	    
 
END	
		
END
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosABeneficio]
(
  @desde INT,
  @hasta INT
)
AS
BEGIN
  SELECT 
  PaginatedTable.PedidoId, 
  PaginatedTable.CodigoPedido,
  Convert(varchar(10),CONVERT(date,PaginatedTable.FechaPedido,103),103) FechaSolicitud,
  Convert(varchar(10),CONVERT(date,PaginatedTable.FechaEntrega,103),103) AS FechaEntrega ,
  PaginatedTable.Estado,  
  PaginatedTable.Cliente,
  CONVERT(VARCHAR(9),DATEDIFF(DAY,CONVERT(DATETIME, PaginatedTable.FechaPedido,103),CONVERT(DATETIME,PaginatedTable.FechaEntrega,103))) DiasEntrega,
  PaginatedTable.Zona
  FROM (
        SELECT 		
		ROW_NUMBER() OVER(ORDER BY p.PedidoId) AS RowNum,
		p.PedidoId,		
		P.FechaPedido,
	    P.FechaEntrega,
		ep.Nombre AS Estado,		
		b.WhsName Cliente,
		CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,
		b.Zona
        FROM Pedidos p
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
		INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
        WHERE P.SolicitudPara='PB-PT' AND ep.Nombre != 'Borrador'
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta) 
   ORDER BY PaginatedTable.Estado , PaginatedTable.FechaPedido ASC;
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosADistribucion]
(
  @desde INT,
  @hasta INT
)
AS
BEGIN
  SELECT 
  PaginatedTable.PedidoId,
  PaginatedTable.CodigoPedido,
   ' ' OrdenCompra,
  PaginatedTable.FechaSolicitud,
  PaginatedTable.Estado,  
  PaginatedTable.Cliente,
  PaginatedTable.Entregas,
  PaginatedTable.Zona
  FROM (
        SELECT 		
		ROW_NUMBER() OVER(ORDER BY p.PedidoId) AS RowNum,
		p.PedidoId,
		CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,
		Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) AS FechaSolicitud,
		ep.Nombre AS Estado,
		b.WhsName AS Cliente,
		p.FechaAprobacionPlanta,
		p.FechaPedido,
		b.Zona,
		Convert(varchar(10),(select count(1) from Entregas where PedidoId=p.PedidoId)) Entregas
        FROM Pedidos p
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId
		INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
        WHERE ep.Nombre in ('Distribución')
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.FechaAprobacionPlanta ASC;
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosPedidosABeneficio]
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM Pedidos p INNER JOIN EstadosPedido e on p.EstadoPedidoId=e.EstadoPedidoId
  WHERE P.SolicitudPara='PB-PT' AND e.Nombre != 'Borrador'
END
";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosPedidosADistribucion]
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM Pedidos p INNER JOIN EstadosPedido e on p.EstadoPedidoId=e.EstadoPedidoId
  WHERE e.Nombre in ('Distribución')
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ActualizarPedidoPuntoVenta]
(
  @PedidoId INT,
  @WhsCode NVARCHAR(16),
  @SolicitudPara NVARCHAR(16),
  @UsuarioId INT,
  @EstadoPedidoId INT,
  @FechaPedido DATETIME2,
  @FechaEntrega DATETIME2 = NULL,  
  @NumeroPedido INT = NULL,
  @TipoSolicitudId INT ,
  @Detalles NVARCHAR(MAX)
)
AS

IF NOT EXISTS(SELECT 1 FROM Pedidos WHERE (PedidoId = @PedidoId))
  BEGIN  
    ;THROW 51000, 'Id del Pedido no existe', 1; 
  END

BEGIN TRANSACTION;

BEGIN TRY

  UPDATE Pedidos
  SET WhsCode = @WhsCode,
      SolicitudPara = @SolicitudPara,
      UsuarioId = @UsuarioId,
      EstadoPedidoId = @EstadoPedidoId,
      FechaPedido = @FechaPedido,
      FechaEntrega = @FechaEntrega,     
      NumeroPedido = @NumeroPedido,
	  TipoSolicitudId = @TipoSolicitudId
  WHERE (PedidoId = @PedidoId);
 
  DECLARE @tblNuevoDetallePedidos TABLE
  (
    DetallePedidoId INT NULL,
    ItemCode NVARCHAR(100),
    EstadoArticuloId INT,
    Cantidad NUMERIC(16, 6),
	Observacion NVARCHAR(4000),
	EmpaqueId INT 
  );
 
  INSERT INTO @tblNuevoDetallePedidos (DetallePedidoId, ItemCode, EstadoArticuloId, Cantidad, Observacion,EmpaqueId)
  SELECT DetallePedidoId, ItemCode, EstadoArticuloId, Cantidad , Observacion ,EmpaqueId
  FROM OPENJSON(@Detalles)
  WITH (
        DetallePedidoId INT '$.DetallePedidoId',
        ItemCode NVARCHAR(100) 'strict $.ItemCode',
        EstadoArticuloId INT 'strict $.EstadoArticuloId',
        Cantidad NUMERIC(16, 6) 'strict $.Cantidad',
		Observacion NVARCHAR(4000) 'strict $.Observacion',
		EmpaqueId INT '$.EmpaqueId'
       );
  
  UPDATE DetallePedidos
  SET DetallePedidos.Cantidad = tblNuevoDetallePedidos.Cantidad,
      DetallePedidos.EstadoArticuloId = tblNuevoDetallePedidos.EstadoArticuloId,
	  DetallePedidos.Observacion=tblNuevoDetallePedidos.Observacion,
	  DetallePedidos.EmpaqueId = tblNuevoDetallePedidos.EmpaqueId
  FROM DetallePedidos
  INNER JOIN @tblNuevoDetallePedidos AS tblNuevoDetallePedidos ON tblNuevoDetallePedidos.DetallePedidoId = DetallePedidos.DetallePedidoId
  WHERE (DetallePedidos.PedidoId = @PedidoId);  

  DELETE FROM DetallePedidos
  WHERE (DetallePedidos.PedidoId = @PedidoId)
    AND (DetallePedidos.DetallePedidoId NOT IN (
                                                 SELECT DetallePedidoId
                                                 FROM @tblNuevoDetallePedidos
                                                )
        );   

  INSERT INTO DetallePedidos (PedidoId, ItemCode, EstadoArticuloId, Cantidad,Observacion,EmpaqueId)
  SELECT @PedidoId, tblNuevoDetallePedidos.ItemCode, tblNuevoDetallePedidos.EstadoArticuloId, tblNuevoDetallePedidos.Cantidad,tblNuevoDetallePedidos.Observacion,tblNuevoDetallePedidos.EmpaqueId
  FROM @tblNuevoDetallePedidos AS tblNuevoDetallePedidos
  WHERE (tblNuevoDetallePedidos.DetallePedidoId = 0);
END TRY
BEGIN CATCH
  ROLLBACK TRANSACTION;

  THROW;
END CATCH;

COMMIT TRANSACTION;
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosABeneficioxFiltro]
( 
  @Desde INT,
  @Hasta INT,
  @Zona NVARCHAR(MAX) = NULL,
  @Estado NVARCHAR(MAX) = NULL,  
  @Cliente NVARCHAR(MAX) = NULL,  
  @CodigoPedido NVARCHAR(MAX) = NULL,
  @DiasEntrega NVARCHAR(MAX) = NULL,
  @FechaEntrega NVARCHAR(MAX) = NULL,
  @FechaSolicitud NVARCHAR(MAX) = NULL
)
AS  
  BEGIN
	SELECT 
	    Paginacion.PedidoId, 
		Paginacion.CodigoPedido,
		Paginacion.FechaSolicitud,
		Paginacion.FechaEntrega,
		Paginacion.Estado,  
		Paginacion.Cliente,
		Paginacion.DiasEntrega,
		Paginacion.Zona
	FROM
	   (
	      SELECT 
	        ROW_NUMBER() OVER(ORDER BY Registros.PedidoId) Fila,
			Registros.PedidoId, 
			Registros.CodigoPedido,
			Registros.FechaSolicitud,
			Registros.FechaEntrega,
			Registros.Estado,  
			Registros.Cliente,
			Registros.DiasEntrega,
			Registros.Zona
	      FROM
	         (
                SELECT				
				p.PedidoId,		
				Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) FechaSolicitud,
				Convert(varchar(10),CONVERT(date,p.FechaEntrega,103),103) FechaEntrega,
				ep.Nombre Estado,		
				b.WhsName Cliente,
				CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,
				p.WhsCode,
				p.EstadoPedidoId,
				b.Zona,
				CONVERT(VARCHAR(9),DATEDIFF(DAY,CONVERT(DATETIME, FechaPedido,103),CONVERT(DATETIME,FechaEntrega,103))) DiasEntrega
				FROM Pedidos p
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
				INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
				WHERE P.SolicitudPara='PB-PT' AND ep.Nombre != 'Borrador'
	        ) Registros 
	        WHERE 
			    ((Registros.Zona LIKE '%' + @Zona + '%') OR (@Zona IS NULL))
            AND ((Registros.Estado LIKE '%' + @Estado + '%') OR (@Estado IS NULL))
            AND ((Registros.Cliente LIKE '%' + @Cliente + '%') OR (@Cliente IS NULL))
            AND ((Registros.CodigoPedido LIKE '%' + @CodigoPedido + '%') OR (@CodigoPedido IS NULL))
			AND ((Registros.DiasEntrega LIKE '%' + @DiasEntrega + '%') OR (@DiasEntrega IS NULL))
            AND ((Registros.FechaEntrega LIKE '%' + @FechaEntrega + '%') OR (@FechaEntrega IS NULL))
			AND ((Registros.FechaSolicitud LIKE '%' + @FechaSolicitud + '%') OR (@FechaSolicitud IS NULL))
			
		) Paginacion
        WHERE (Paginacion.Fila BETWEEN @desde AND @hasta)
	    ORDER BY Paginacion.Estado , Paginacion.FechaSolicitud ASC;
  END
                ";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosADistribucionxFiltro]
( 
  @Desde INT,
  @Hasta INT,
  @Zona NVARCHAR(MAX) = NULL,
  @Estado NVARCHAR(MAX) = NULL,  
  @Cliente NVARCHAR(MAX) = NULL,  
  @CodigoPedido NVARCHAR(MAX) = NULL, 
  @FechaSolicitud NVARCHAR(MAX) = NULL,
  @Entregas NVARCHAR(MAX) = NULL
)
AS  
  BEGIN
	SELECT 
	    Paginacion.PedidoId, 
		Paginacion.CodigoPedido,
		Paginacion.FechaSolicitud,		
		Paginacion.Estado,  
		Paginacion.Cliente,		
		Paginacion.Zona,
        Paginacion.Entregas
	FROM
	   (
	      SELECT 
	        ROW_NUMBER() OVER(ORDER BY Registros.PedidoId) Fila,
			Registros.PedidoId, 
			Registros.CodigoPedido,
			Registros.FechaSolicitud,			
			Registros.Estado,  
			Registros.Cliente,			
			Registros.Zona,
            Registros.Entregas
	      FROM
	         (
                SELECT				
				p.PedidoId,		
				Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) FechaSolicitud,				
				ep.Nombre Estado,		
				b.WhsName Cliente,
				CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,
				p.WhsCode,
				p.EstadoPedidoId,
				b.Zona,
		        Convert(varchar(10),(select count(1) from Entregas where PedidoId=p.PedidoId)) Entregas
				FROM Pedidos p
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
				INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
				WHERE ep.Nombre in ('Distribución')
	        ) Registros 
	        WHERE 
			    ((Registros.Zona LIKE '%' + @Zona + '%') OR (@Zona IS NULL))
            AND ((Registros.Estado LIKE '%' + @Estado + '%') OR (@Estado IS NULL))
            AND ((Registros.Cliente LIKE '%' + @Cliente + '%') OR (@Cliente IS NULL))
            AND ((Registros.CodigoPedido LIKE '%' + @CodigoPedido + '%') OR (@CodigoPedido IS NULL))			
			AND ((Registros.FechaSolicitud LIKE '%' + @FechaSolicitud + '%') OR (@FechaSolicitud IS NULL))
            AND ((Registros.Entregas LIKE '%' + @Entregas + '%') OR (@Entregas IS NULL))
			
		) Paginacion
        WHERE (Paginacion.Fila BETWEEN @desde AND @hasta)
	    ORDER BY Paginacion.Estado , Paginacion.FechaSolicitud ASC;
  END
                ";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosEntregasEnrutamiento]
(
  @desde INT,
  @hasta INT
)
AS
BEGIN
  SELECT 
  PaginatedTable.EntregaId,
  PaginatedTable.Cliente, 
  PaginatedTable.CodigoPedido, 
  PaginatedTable.FechaEntrega,  
  PaginatedTable.HoraEntrega,
  PaginatedTable.Peso,
  CONVERT(varchar(10),PaginatedTable.RowNum) NumeroEntrega,
  PaginatedTable.Zona
  FROM (
        SELECT	
		ROW_NUMBER() OVER(ORDER BY e.EntregaId) RowNum,
		e.EntregaId,
		b.WhsName Cliente,
		CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,		
		CONVERT(varchar(10),CONVERT(date,e.FechaEntrega,103),103) FechaEntrega,
		CONVERT(varchar(5),e.FechaEntrega,8) HoraEntrega,
		(SELECT SUM(Cantidad) FROM DetalleEntregas WHERE EntregaId=e.EntregaId) Peso,
		b.Zona,
		e.FechaRegistro
        FROM Entregas e
		INNER JOIN Pedidos p on e.PedidoId=p.PedidoId
		INNER JOIN Bodegas b on p.WhsCode=b.WhsCode
		INNER JOIN EstadosPedido ep on e.EstadoEntregaId=ep.EstadoPedidoId		
        WHERE ep.Nombre in ('Programado') AND e.FechaEntrega >=	GETDATE()			
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.FechaRegistro ASC;
END";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosEntregasEnrutamiento]
AS
BEGIN
   SELECT COUNT(1) AS nRegistros
   FROM Entregas e 
   INNER JOIN Pedidos p ON e.PedidoId=p.PedidoId
   INNER JOIN EstadosPedido ep on e.EstadoEntregaId=ep.EstadoPedidoId
   WHERE ep.Nombre in ('Programado') AND e.FechaEntrega >= GETDATE()
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosAbiertos]
(
  @desde INT,
  @hasta INT
)
AS
BEGIN
  SELECT 
  PaginatedTable.PedidoId,
  PaginatedTable.CodigoPedido,
   ' ' OrdenCompra,
  PaginatedTable.FechaSolicitud,
  PaginatedTable.Estado,  
  PaginatedTable.Cliente,
  PaginatedTable.Entregas,
  PaginatedTable.Zona,
  PaginatedTable.FE,
  PaginatedTable.DiasEntrega,
  PaginatedTable.FechaEntrega,
  PaginatedTable.SolicitudA,
  PaginatedTable.CodigoSolicitudA
  FROM (
        SELECT 		
		ROW_NUMBER() OVER(ORDER BY p.PedidoId) AS RowNum,
		p.PedidoId,
		CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,
		Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) AS FechaSolicitud,
		ep.Nombre AS Estado,
		b.WhsName AS Cliente,
		p.FechaAprobacionPlanta,
		p.FechaPedido,
		b.Zona,
		Convert(varchar(10),(select count(1) from Entregas where PedidoId=p.PedidoId)) Entregas,
		p.FechaEntrega FE,
		CONVERT(varchar(max),DATEDIFF(day,GETDATE(),p.FechaEntrega)) DiasEntrega,
		Convert(varchar(10),CONVERT(date,p.FechaEntrega,103),103) AS FechaEntrega,
		bb.WhsName SolicitudA,
		bb.WhsCode CodigoSolicitudA
        FROM Pedidos p
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId
		INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
		INNER JOIN TiposSolicitud ts on p.TipoSolicitudId=ts.TipoSolicitudId
		INNER JOIN Bodegas bb on bb.WhsCode=p.SolicitudPara
        WHERE ep.Nombre in ('Abierto') and ts.TipoSolicitudNombre='Traslado'
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.FE ASC;
END
                ";

            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosAceptados]
(
  @desde INT,
  @hasta INT
)
AS
BEGIN
  SELECT 
  PaginatedTable.PedidoId,
  PaginatedTable.CodigoPedido,
   ' ' OrdenCompra,
  PaginatedTable.FechaSolicitud,
  PaginatedTable.Estado,  
  PaginatedTable.Cliente,
  PaginatedTable.Entregas,
  PaginatedTable.Zona,
  PaginatedTable.FE,
  PaginatedTable.DiasEntrega,
  PaginatedTable.FechaEntrega
  FROM (
        SELECT 		
		ROW_NUMBER() OVER(ORDER BY p.PedidoId) AS RowNum,
		p.PedidoId,
		CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,
		Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) AS FechaSolicitud,
		ep.Nombre AS Estado,
		b.WhsName AS Cliente,
		p.FechaAprobacionPlanta,
		p.FechaPedido,
		b.Zona,
		Convert(varchar(10),(select count(1) from Entregas where PedidoId=p.PedidoId)) Entregas,
		p.FechaEntrega FE,
		CONVERT(varchar(max),DATEDIFF(day,GETDATE(),p.FechaEntrega)) DiasEntrega,
		Convert(varchar(10),CONVERT(date,p.FechaEntrega,103),103) AS FechaEntrega
        FROM Pedidos p
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId
		INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
        WHERE ep.Nombre in ('Aprobación Parcial','Aprobación Completa')
       ) PaginatedTable
  WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.FE ASC;
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosAceptadosxFiltro]
( 
  @Desde INT,
  @Hasta INT,
  @Zona NVARCHAR(MAX) = NULL,
  @Estado NVARCHAR(MAX) = NULL,  
  @Cliente NVARCHAR(MAX) = NULL,  
  @CodigoPedido NVARCHAR(MAX) = NULL,
  @DiasEntrega NVARCHAR(MAX) = NULL,
  @FechaEntrega NVARCHAR(MAX) = NULL,
  @FechaSolicitud NVARCHAR(MAX) = NULL
)
AS  
  BEGIN
	SELECT 
	    Paginacion.PedidoId, 
		Paginacion.CodigoPedido,
		Paginacion.FechaSolicitud,
		Paginacion.FechaEntrega,
		Paginacion.Estado,  
		Paginacion.Cliente,
		Paginacion.DiasEntrega,
		Paginacion.Zona
	FROM
	   (
	      SELECT 
	        ROW_NUMBER() OVER(ORDER BY Registros.PedidoId) Fila,
			Registros.PedidoId, 
			Registros.CodigoPedido,
			Registros.FechaSolicitud,
			Registros.FechaEntrega,
			Registros.Estado,  
			Registros.Cliente,
			Registros.DiasEntrega,
			Registros.Zona
	      FROM
	         (
                SELECT				
				p.PedidoId,		
				Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) FechaSolicitud,
				Convert(varchar(10),CONVERT(date,p.FechaEntrega,103),103) FechaEntrega,
				ep.Nombre Estado,		
				b.WhsName Cliente,
				CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,
				p.WhsCode,
				p.EstadoPedidoId,
				b.Zona,
				CONVERT(VARCHAR(MAX),DATEDIFF(DAY,CONVERT(DATETIME, GETDATE(),103),CONVERT(DATETIME,FechaEntrega,103))) DiasEntrega
				FROM Pedidos p
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
				INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
				WHERE ep.Nombre IN ('Aprobación Parcial','Aprobación Completa')
	        ) Registros 
	        WHERE 
			    ((Registros.Zona LIKE '%' + @Zona + '%') OR (@Zona IS NULL))
            AND ((Registros.Estado LIKE '%' + @Estado + '%') OR (@Estado IS NULL))
            AND ((Registros.Cliente LIKE '%' + @Cliente + '%') OR (@Cliente IS NULL))
            AND ((Registros.CodigoPedido LIKE '%' + @CodigoPedido + '%') OR (@CodigoPedido IS NULL))
			AND ((Registros.DiasEntrega LIKE '%' + @DiasEntrega + '%') OR (@DiasEntrega IS NULL))
            AND ((Registros.FechaEntrega LIKE '%' + @FechaEntrega + '%') OR (@FechaEntrega IS NULL))
			AND ((Registros.FechaSolicitud LIKE '%' + @FechaSolicitud + '%') OR (@FechaSolicitud IS NULL))
			
		) Paginacion
        WHERE (Paginacion.Fila BETWEEN @desde AND @hasta)
	    ORDER BY Paginacion.Estado , Paginacion.FechaEntrega ASC;
  END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerTodosPedidosAbiertosxFiltro]
( 
  @Desde INT,
  @Hasta INT,
  @Zona NVARCHAR(MAX) = NULL,
  @Estado NVARCHAR(MAX) = NULL,  
  @Cliente NVARCHAR(MAX) = NULL,  
  @CodigoPedido NVARCHAR(MAX) = NULL,
  @DiasEntrega NVARCHAR(MAX) = NULL,
  @FechaEntrega NVARCHAR(MAX) = NULL,
  @FechaSolicitud NVARCHAR(MAX) = NULL
)
AS  
  BEGIN
	SELECT 
	    Paginacion.PedidoId, 
		Paginacion.CodigoPedido,
		Paginacion.FechaSolicitud,
		Paginacion.FechaEntrega,
		Paginacion.Estado,  
		Paginacion.Cliente,
		Paginacion.DiasEntrega,
		Paginacion.Zona,
		Paginacion.SolicitudA,
		Paginacion.CodigoSolicitudA
	FROM
	   (
	      SELECT 
	        ROW_NUMBER() OVER(ORDER BY Registros.PedidoId) Fila,
			Registros.PedidoId, 
			Registros.CodigoPedido,
			Registros.FechaSolicitud,
			Registros.FechaEntrega,
			Registros.Estado,  
			Registros.Cliente,
			Registros.DiasEntrega,
			Registros.Zona,
			Registros.SolicitudA,
		    Registros.CodigoSolicitudA
	      FROM
	         (
                SELECT				
				p.PedidoId,		
				Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) FechaSolicitud,
				Convert(varchar(10),CONVERT(date,p.FechaEntrega,103),103) FechaEntrega,
				ep.Nombre Estado,		
				b.WhsName Cliente,
				CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) CodigoPedido,
				p.WhsCode,
				p.EstadoPedidoId,
				b.Zona,
				CONVERT(VARCHAR(MAX),DATEDIFF(DAY,CONVERT(DATETIME, GETDATE(),103),CONVERT(DATETIME,FechaEntrega,103))) DiasEntrega,
				bb.WhsName SolicitudA,
				bb.WhsCode CodigoSolicitudA
				FROM Pedidos p
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
				INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
				INNER JOIN Bodegas bb on bb.WhsCode=p.SolicitudPara
				INNER JOIN TiposSolicitud ts on p.TipoSolicitudId=ts.TipoSolicitudId
				WHERE ep.Nombre in ('Abierto') and ts.TipoSolicitudNombre='Traslado'
	        ) Registros 
	        WHERE 
			    ((Registros.Zona LIKE '%' + @Zona + '%') OR (@Zona IS NULL))
            AND ((Registros.Estado LIKE '%' + @Estado + '%') OR (@Estado IS NULL))
            AND ((Registros.Cliente LIKE '%' + @Cliente + '%') OR (@Cliente IS NULL))
            AND ((Registros.CodigoPedido LIKE '%' + @CodigoPedido + '%') OR (@CodigoPedido IS NULL))
			AND ((Registros.DiasEntrega LIKE '%' + @DiasEntrega + '%') OR (@DiasEntrega IS NULL))
            AND ((Registros.FechaEntrega LIKE '%' + @FechaEntrega + '%') OR (@FechaEntrega IS NULL))
			AND ((Registros.FechaSolicitud LIKE '%' + @FechaSolicitud + '%') OR (@FechaSolicitud IS NULL))
			
		) Paginacion
        WHERE (Paginacion.Fila BETWEEN @desde AND @hasta)
	    ORDER BY Paginacion.Estado , Paginacion.FechaEntrega ASC;
  END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosPedidosAbiertos]

AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM Pedidos p
  INNER JOIN EstadosPedido ep ON p.EstadoPedidoId=ep.EstadoPedidoId
  WHERE ep.Nombre='Abierto'
END
";
            migrationBuilder.Sql(sp);

            sp = @"
CREATE PROCEDURE [dbo].[ObtenerConteoTodosPedidosAceptados]

AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM Pedidos p
  INNER JOIN EstadosPedido ep ON p.EstadoPedidoId=ep.EstadoPedidoId
  WHERE ep.Nombre in ('Aprobación Parcial','Aprobación Completa')
END
";

            migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [dbo].[ObtenerTodosEvidencias]
AS
BEGIN
SELECT 		
		ev.EvidenciaId,
		p.PedidoId,
		(SELECT WhsName FROM Bodegas WHERE WhsCode=P.WhsCode) PuntoVenta,
		CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) NumeroPedido,
		CONVERT(varchar(10),CONVERT(date,ev.FechaEvidencia,103),101) FechaEvidencia,
		en.FechaEntrega		
        FROM Evidencias ev
		INNER JOIN PesajesEntrega pe on ev.PesajeEntregaId=pe.PesajeEntregaId
		INNER JOIN Entregas en on pe.EntregaId=en.EntregaId
		INNER JOIN Pedidos P on en.PedidoId=p.PedidoId	
        ORDER BY ev.FechaEvidencia DESC
END";

            migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [dbo].[ObtenerTodosEvidenciasxFiltro]
( 
  @puntoVenta NVARCHAR(MAX) = NULL,
  @fechaInicio NVARCHAR(MAX) = NULL,
  @fechaFin NVARCHAR(MAX) = NULL
)
AS
BEGIN
SELECT 		
		ev.EvidenciaId,
		p.PedidoId,
		(SELECT WhsName FROM Bodegas WHERE WhsCode=P.WhsCode) PuntoVenta,
		CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) NumeroPedido,
		CONVERT(varchar(10),CONVERT(date,ev.FechaEvidencia,103),101) FechaEvidencia,
		en.FechaEntrega		
        FROM Evidencias ev
		INNER JOIN PesajesEntrega pe on ev.PesajeEntregaId=pe.PesajeEntregaId
		INNER JOIN Entregas en on pe.EntregaId=en.EntregaId
		INNER JOIN Pedidos P on en.PedidoId=p.PedidoId
		WHERE 
		 (CONVERT(date,ev.FechaEvidencia,103) BETWEEN CONVERT(date,@fechaInicio,103) AND CONVERT(date,@fechaFin,103))
          	 AND
		 (p.WhsCode = @puntoVenta ) OR (@puntoVenta IS NULL)
        ORDER BY ev.FechaEvidencia DESC
END";
            migrationBuilder.Sql(sp);
        

            sp = @"CREATE PROCEDURE [dbo].[ObtenerSociosNegocio]
AS
BEGIN
SELECT 		
		Identificacion,
        Nombre
        FROM SociosNegocio		
END";

            migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [dbo].[ObtenerSociosNegocioxFiltro]
( 
  @identificacion NVARCHAR(15) = NULL,
  @nombre NVARCHAR(100) = NULL
)
AS
BEGIN
SELECT 		
		Identificacion,
        Nombre
        FROM SociosNegocio
        WHERE 
		((Identificacion LIKE '%' + @identificacion + '%') OR (@identificacion IS NULL))
        AND ((Nombre LIKE '%' + @nombre + '%') OR (@nombre IS NULL))            
END";
            migrationBuilder.Sql(sp);

			sp = @"CREATE PROCEDURE [dbo].[ObtenerTodosPedidosBorrador]
( 
  @solicitudDe VARCHAR(8)
)
AS
BEGIN 
        SELECT 		
		p.PedidoId,		
		Convert(varchar(10),CONVERT(date,p.FechaPedido,106),103) AS FechaSolicitud,
	    Convert(varchar(10),CONVERT(date,p.FechaEntrega,106),103) AS FechaLimiteSolicitud,		
		ep.Nombre AS EstadoPedido,
		(select WhsName from Bodegas where WhsCode=p.SolicitudPara) AS SolicitudA,
		Convert(varchar(10),DATEDIFF(DAY,p.FechaPedido,p.FechaEntrega)) DiasEntrega,		
		ts.TipoSolicitudNombre AS TipoSolicitudNombre	
        FROM Pedidos p
		INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
		INNER JOIN TiposSolicitud ts on p.TipoSolicitudId=ts.TipoSolicitudId
        WHERE P.WhsCode=@solicitudDe and ep.Nombre='Borrador'
		Order By p.FechaPedido asc
END";

			migrationBuilder.Sql(sp);

			sp = @"CREATE PROCEDURE [dbo].[ObtenerTodosArticulosxBodegaPlantas] (
  @whsCodePuntoVenta NVARCHAR(8) 
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT 
    PaginatedTable.CodigoArticulo,
    PaginatedTable.NombreArticulo,
	PaginatedTable.UnidadMedida,
    PaginatedTable.Stock,
    PaginatedTable.Minimo,
    PaginatedTable.Maximo,
	PaginatedTable.EstadoId,
	PaginatedTable.EmpaqueId
  FROM (
        SELECT 
			ab.ItemCode AS CodigoArticulo,
			a.ItemName AS NombreArticulo,
			a.SalUnitMsr AS UnidadMedida,
			ab.OnHand AS Stock,
			ab.MinStock AS Minimo,
			ab.MaxStock AS Maximo,
			a.EstadoId,
			a.EmpaqueId,
			ROW_NUMBER() OVER (ORDER BY ab.ItemCode) AS RowNum
		    FROM ArticulosXBodega ab , Articulos a 
		    WHERE ab.ItemCode=a.ItemCode 
			AND UPPER(ab.ItemCode) LIKE 'PT%'			
		    AND UPPER(ab.WhsCode) = UPPER(@whsCodePuntoVenta)	  
       ) PaginatedTable
 
  ORDER BY PaginatedTable.RowNum DESC;
END";
			migrationBuilder.Sql(sp);

			sp = @"CREATE PROCEDURE [dbo].[ObtenerConteoTodosArticulosxBodegaPlantas] ( 
  @whsCode NVARCHAR(8)
)
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM ArticulosXBodega where WhsCode=@whsCode
  AND UPPER(ItemCode) LIKE 'PT%'	
END";
			migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [dbo].[ObtenerTodosArticulosxBodegaCompras] (
  @desde INT,
  @hasta INT,
  @whsCodePuntoVenta NVARCHAR(8),
  @whsCodePlanta NVARCHAR(8)
)

AS
BEGIN
  SET NOCOUNT ON;

  SELECT 
    PaginatedTable.CodigoArticulo,
    PaginatedTable.NombreArticulo,
	PaginatedTable.UnidadMedida,
    PaginatedTable.Stock,
    PaginatedTable.Minimo,
    PaginatedTable.Maximo,
	PaginatedTable.EstadoId,
	PaginatedTable.EmpaqueId
  FROM (
        	 SELECT 
			ab.ItemCode AS CodigoArticulo,
			a.ItemName AS NombreArticulo,
			a.SalUnitMsr AS UnidadMedida,
			ab.OnHand AS Stock,
			ab.MinStock AS Minimo,
			ab.MaxStock AS Maximo,
			ROW_NUMBER() OVER (ORDER BY ab.ItemCode) AS RowNum,
			a.EstadoId,
			a.EmpaqueId
		    FROM ArticulosXBodega ab , Articulos a 
		    WHERE ab.ItemCode=a.ItemCode 
            and a.ArticuloCompraPV is null
			AND UPPER(ab.WhsCode) = UPPER(@whsCodePuntoVenta)
			AND  SUBSTRING(ab.ItemCode, 0, CHARINDEX('-', ab.ItemCode))
			IN ('ASEO','CAF','CAL','DOT','ETI','HC','ING','MA','ME','MTO','PAP')
       ) PaginatedTable
  --WHERE (PaginatedTable.RowNum BETWEEN @desde AND @hasta)
  ORDER BY PaginatedTable.RowNum DESC;
END";

            migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [dbo].[ObtenerConteoTodosArticulosxBodegaCompras] ( 
  @whsCode NVARCHAR(8)
)
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM ArticulosXBodega where WhsCode=@whsCode
      AND ((UPPER(ItemCode) NOT LIKE UPPER('PT%')) 
			      AND (UPPER(ItemCode) NOT LIKE UPPER('PV%'))
				) 	
END";
            migrationBuilder.Sql(sp);

			sp = @"CREATE PROCEDURE [dbo].[ObtenerConteoPedidosCompraAbiertoxFiltro]
( 
  @Desde INT,
  @Hasta INT,
  @Cliente NVARCHAR(MAX) = NULL,
  @DiasEntrega NVARCHAR(MAX) = NULL,  
  @EstadoPedido NVARCHAR(MAX) = NULL,  
  @FechaLimiteSugerida NVARCHAR(MAX) = NULL,
  @FechaSolicitud NVARCHAR(MAX) = NULL,
  @NumeroPedido NVARCHAR(MAX) = NULL
)
AS  
  BEGIN
	SELECT 
	    COUNT(1) AS nRegistros
	FROM
	   (
	      SELECT 
	        ROW_NUMBER() OVER(ORDER BY Registros.PedidoId) Fila,
			Registros.PedidoId, 
			Registros.Cliente,
			Registros.DiasEntrega,
			Registros.FechaSolicitud,
			Registros.FechaLimiteSugerida,  
			Registros.EstadoPedido,
			Registros.NumeroPedido
	      FROM
	         (
                SELECT				
				p.PedidoId,	
				b.WhsName Cliente,
				CONVERT(VARCHAR(9),DATEDIFF(DAY,CONVERT(DATETIME, FechaPedido,103),CONVERT(DATETIME,FechaEntrega,103))) DiasEntrega,
				Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) FechaSolicitud,
				Convert(varchar(10),CONVERT(date,p.FechaEntrega,103),103) FechaLimiteSugerida,
				ep.Nombre EstadoPedido,				
				CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) NumeroPedido
				FROM Pedidos p
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
				INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
				INNER JOIN TiposSolicitud ts on p.TipoSolicitudId=ts.TipoSolicitudId
				WHERE ts.TipoSolicitudNombre='Compras' AND ep.Nombre <> 'Borrador'
	        ) Registros 
	        WHERE 
			    ((Registros.Cliente LIKE '%' + @Cliente + '%') OR (@Cliente IS NULL))
            AND ((Registros.DiasEntrega LIKE '%' + @DiasEntrega + '%') OR (@DiasEntrega IS NULL))            
            AND ((Registros.FechaSolicitud LIKE '%' + @FechaSolicitud + '%') OR (@FechaSolicitud IS NULL))
			AND ((Registros.FechaLimiteSugerida LIKE '%' + @FechaLimiteSugerida + '%') OR (@FechaLimiteSugerida IS NULL))
            AND ((Registros.EstadoPedido LIKE '%' + @EstadoPedido + '%') OR (@EstadoPedido IS NULL))
			AND ((Registros.NumeroPedido LIKE '%' + @NumeroPedido + '%') OR (@NumeroPedido IS NULL))
			
		) Paginacion
        WHERE (Paginacion.Fila BETWEEN @desde AND @hasta);
  END";
			migrationBuilder.Sql(sp);

			sp = @"CREATE PROCEDURE [dbo].[ObtenerConteoPedidosCompraAbierto]
AS
BEGIN
  SET NOCOUNT ON;
  SELECT COUNT(1) AS nRegistros
  FROM Pedidos p
  INNER JOIN EstadosPedido ep ON p.EstadoPedidoId=ep.EstadoPedidoId
  INNER JOIN TiposSolicitud ts on p.TipoSolicitudId=ts.TipoSolicitudId
  WHERE ts.TipoSolicitudNombre='Compras' AND ep.Nombre <> 'Borrador'
END";
			migrationBuilder.Sql(sp);

			sp = @"CREATE PROCEDURE [dbo].[ObtenerPedidosCompraAbierto]
( 
  @Desde INT,
  @Hasta INT  
)
AS  
  BEGIN
	SELECT 
	    Paginacion.PedidoId, 
		Paginacion.Cliente,
		Paginacion.DiasEntrega,
		Paginacion.FechaSolicitud,
		Paginacion.FechaLimiteSugerida,  
		Paginacion.Estado,
		Paginacion.NumeroPedido
	FROM
	   (
	      SELECT 
	        ROW_NUMBER() OVER(ORDER BY Registros.PedidoId) Fila,
			Registros.PedidoId, 
			Registros.Cliente,
			Registros.DiasEntrega,
			Registros.FechaSolicitud,
			Registros.FechaLimiteSugerida,  
			Registros.Estado,
			Registros.NumeroPedido
	      FROM
	         (
                SELECT				
				p.PedidoId,	
				b.WhsName Cliente,
				CONVERT(VARCHAR(9),DATEDIFF(DAY,CONVERT(DATETIME, FechaPedido,103),CONVERT(DATETIME,FechaEntrega,103))) DiasEntrega,
				Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) FechaSolicitud,
				Convert(varchar(10),CONVERT(date,p.FechaEntrega,103),103) FechaLimiteSugerida,
				ep.Nombre Estado,				
				CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) NumeroPedido
				FROM Pedidos p
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
				INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
				INNER JOIN TiposSolicitud ts on p.TipoSolicitudId=ts.TipoSolicitudId
				WHERE ts.TipoSolicitudNombre='Compras' AND ep.Nombre <> 'Borrador'
	        ) Registros 		
		) Paginacion
        WHERE (Paginacion.Fila BETWEEN @desde AND @hasta)
	    ORDER BY Paginacion.FechaLimiteSugerida ASC;
  END";
			migrationBuilder.Sql(sp);

			sp = @"CREATE PROCEDURE [dbo].[ObtenerPedidosCompraAbiertoxFiltro]
( 
  @Desde INT,
  @Hasta INT,
  @Cliente NVARCHAR(MAX) = NULL,
  @DiasEntrega NVARCHAR(MAX) = NULL,  
  @EstadoPedido NVARCHAR(MAX) = NULL,  
  @FechaLimiteSugerida NVARCHAR(MAX) = NULL,
  @FechaSolicitud NVARCHAR(MAX) = NULL,
  @NumeroPedido NVARCHAR(MAX) = NULL
)
AS  
  BEGIN
	SELECT 
	    Paginacion.PedidoId, 
		Paginacion.Cliente,
		Paginacion.DiasEntrega,
		Paginacion.FechaSolicitud,
		Paginacion.FechaLimiteSugerida,  
		Paginacion.Estado,
		Paginacion.NumeroPedido
	FROM
	   (
	      SELECT 
	        ROW_NUMBER() OVER(ORDER BY Registros.PedidoId) Fila,
			Registros.PedidoId, 
			Registros.Cliente,
			Registros.DiasEntrega,
			Registros.FechaSolicitud,
			Registros.FechaLimiteSugerida,  
			Registros.Estado,
			Registros.NumeroPedido
	      FROM
	         (
                SELECT				
				p.PedidoId,	
				b.WhsName Cliente,
				CONVERT(VARCHAR(9),DATEDIFF(DAY,CONVERT(DATETIME, FechaPedido,103),CONVERT(DATETIME,FechaEntrega,103))) DiasEntrega,
				Convert(varchar(10),CONVERT(date,p.FechaPedido,103),103) FechaSolicitud,
				Convert(varchar(10),CONVERT(date,p.FechaEntrega,103),103) FechaLimiteSugerida,
				ep.Nombre Estado,				
				CONCAT(SUBSTRING(P.WhsCode,CHARINDEX('-',P.WhsCode)+1,LEN(P.WhsCode) - CHARINDEX('-',P.WhsCode)),'-',P.NumeroPedido) NumeroPedido
				FROM Pedidos p
				INNER JOIN EstadosPedido ep on p.EstadoPedidoId=ep.EstadoPedidoId 
				INNER JOIN Bodegas b on b.WhsCode=p.WhsCode
				INNER JOIN TiposSolicitud ts on p.TipoSolicitudId=ts.TipoSolicitudId
				WHERE ts.TipoSolicitudNombre='Compras' AND ep.Nombre <> 'Borrador'
	        ) Registros 
	        WHERE 
			    ((Registros.Cliente LIKE '%' + @Cliente + '%') OR (@Cliente IS NULL))
            AND ((Registros.DiasEntrega LIKE '%' + @DiasEntrega + '%') OR (@DiasEntrega IS NULL))            
            AND ((Registros.FechaSolicitud LIKE '%' + @FechaSolicitud + '%') OR (@FechaSolicitud IS NULL))
			AND ((Registros.FechaLimiteSugerida LIKE '%' + @FechaLimiteSugerida + '%') OR (@FechaLimiteSugerida IS NULL))
            AND ((Registros.Estado = @EstadoPedido ) OR (@EstadoPedido IS NULL))
			AND ((Registros.NumeroPedido LIKE '%' + @NumeroPedido + '%') OR (@NumeroPedido IS NULL))
			
		) Paginacion
        WHERE (Paginacion.Fila BETWEEN @desde AND @hasta)
	    ORDER BY Paginacion.FechaLimiteSugerida ASC;
  END";
			migrationBuilder.Sql(sp);

            sp = @"CREATE PROCEDURE [dbo].[ObtenerTodosArchivosxFiltro]
( 
  @desde INT,
  @hasta INT,
  @nombreArchivo NVARCHAR(MAX) = NULL,
  @fechaCarga NVARCHAR(MAX) = NULL,
  @fechaInicial NVARCHAR(MAX) = NULL,
  @fechaFinal NVARCHAR(MAX) = NULL
)
AS  
  BEGIN
	SELECT 
	   	Paginacion.ArchivoID, 
		Paginacion.CodigoArticulo,
		Paginacion.Nombre,
		Paginacion.FechaCarga,
		Paginacion.FechaInicial,  
		Paginacion.FechaFinal,
		Paginacion.NumeroCanales,
		Paginacion.DiaUno,
		Paginacion.DiaDos,
		Paginacion.DiaTres,
		Paginacion.DiaCuatro,
		Paginacion.DiaCinco,
		Paginacion.DiaSeis,
		Paginacion.DiaSiete,
		Paginacion.PesoCaliente,
		Paginacion.PesoPromedioDia,
		Paginacion.PesoTotal,
		Paginacion.PesoDeshuesadoTotal,
		Paginacion.PesoPromedio,
		Paginacion.PorcentajeArticulo,
		Paginacion.SemanaCarga,
		Paginacion.NombreArchivo			
	FROM
	   (
	      SELECT 
	        ROW_NUMBER() OVER(ORDER BY Registros.ArchivoID) Fila,
			Registros.ArchivoID, 
			Registros.CodigoArticulo,
			Registros.Nombre,
			Registros.FechaCarga,
			Registros.FechaInicial,  
			Registros.FechaFinal,
			Registros.NumeroCanales,
			Registros.DiaUno,
			Registros.DiaDos,
			Registros.DiaTres,
			Registros.DiaCuatro,
			Registros.DiaCinco,
			Registros.DiaSeis,
			Registros.DiaSiete,
			Registros.PesoCaliente,
			Registros.PesoPromedioDia,
			Registros.PesoTotal,
			Registros.PesoDeshuesadoTotal,
			Registros.PesoPromedio,
			Registros.PorcentajeArticulo,
			Registros.SemanaCarga,
			Registros.NombreArchivo			
	      FROM
	         (
                SELECT				
				 p.ArchivoID,CodigoArticulo,Nombre,
				 Convert(varchar(10),CONVERT(date,p.FechaCarga,103),103) FechaCarga,
				 Convert(varchar(10),CONVERT(date,p.FechaInicial,103),103) FechaInicial,
				 Convert(varchar(10),CONVERT(date,p.FechaFinal,103),103) FechaFinal,
				 NumeroCanales ,DiaUno ,DiaDos ,DiaTres ,DiaCuatro ,DiaCinco,
				 DiaSeis ,DiaSiete,PesoCaliente,PesoPromedioDia,PesoTotal ,PesoDeshuesadoTotal,PesoPromedio,PorcentajeArticulo,SemanaCarga,NombreArchivo,ControlCarga
				FROM archivosPlano p		
	        ) Registros 
	        WHERE 
			    ((Registros.NombreArchivo LIKE '%' + @nombreArchivo + '%') OR (@nombreArchivo IS NULL))         
            AND ((Registros.FechaCarga LIKE '%' + @fechaCarga + '%') OR (@fechaCarga IS NULL))
			AND ((Registros.FechaInicial LIKE '%' + @fechaInicial + '%') OR (@fechaInicial IS NULL))
			AND ((Registros.FechaFinal LIKE '%' + @fechaFinal+ '%') OR (@fechaFinal IS NULL))
			
		) Paginacion
        WHERE (Paginacion.Fila BETWEEN @desde AND @hasta)
	    ORDER BY Paginacion.NombreArchivo , Paginacion.FechaCarga ASC;
  END";
            migrationBuilder.Sql(sp);

        }

		protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosRegistrosAuditoria;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosRegistrosAuditoriaxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosRolesxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosRoles;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosRegistrosAuditoriaxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosModulos;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosParametrosGenerales;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerUsuariosxRol;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosUsuariosxRolxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosUsuariosxRolxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosUsuariosxRol;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosSesiones;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosRegistrosSesionesxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosSesionesxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosLogsIntegracion;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosConteoLogsIntegracion;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosArticulosxBodega;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosArticulosxBodega;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosArticulosBodegaxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosArticulosBodegaxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosPedidos;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidos;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosABeneficio;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosABenficioxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosPedidosADistribucion;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosADistribucionxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosEntregasDistribucion;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosEntregasDistribucion;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosAbiertos;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosAceptados;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosAbiertosxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosAceptadosxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosEvidencias;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosEvidenciasxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerSociosNegocio;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerSociosNegocioxFiltro;");
			migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosPedidosBorrador;");
			migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosArticulosxBodegaPlantas;");
			migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosArticulosxBodegaPlantas;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosArticulosxBodegaCompras;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoTodosArticulosxBodegaCompras;");
			migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoPedidosCompraAbiertoxFiltro;");
			migrationBuilder.Sql("DROP PROCEDURE ObtenerConteoPedidosCompraAbierto;");
			migrationBuilder.Sql("DROP PROCEDURE ObtenerPedidosCompraAbierto;");
			migrationBuilder.Sql("DROP PROCEDURE ObtenerPedidosCompraAbiertoxFiltro;");
            migrationBuilder.Sql("DROP PROCEDURE ObtenerTodosArchivosxFiltro;");
		}
    }
}