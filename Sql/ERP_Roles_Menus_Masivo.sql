/* ============================================================================
   Cargas masivas del formulario ROLES USUARIO (Frm_RolesUser).

   Ninguno recibe parámetros: C# sube las filas con SqlBulkCopy a una tabla
   temporal sobre la MISMA conexión y después ejecuta el procedimiento, que
   resuelve altas y actualizaciones en un solo MERGE.

   Reemplazan al ciclo que hacía una consulta de existencia (SP_CODIGO_*) más
   un INSERT o un UPDATE por cada fila de la grilla.
   ============================================================================ */


/* ---------------------------------------------------------------- ERP_Rol  */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_ROL_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_ROL_MASIVO
GO

/* Tabla temporal #Rol(IdRol, Nombre) */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_ROL_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY IdRol ORDER BY (SELECT 0)) AS rn
          FROM #Rol
    )
    MERGE dbo.ERP_Rol AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.IdRol = o.IdRol
    WHEN MATCHED THEN
        UPDATE SET destino.Nombre = o.Nombre
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (IdRol, Nombre) VALUES (o.IdRol, o.Nombre);
END
GO


/* --------------------------------------------------------------- ERP_Menu  */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_MENU_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_MASIVO
GO

/* Tabla temporal #Menu(IdMenu, Nombre, Icono, IdApp, App) */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY IdMenu ORDER BY (SELECT 0)) AS rn
          FROM #Menu
    )
    MERGE dbo.ERP_Menu AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.IdMenu = o.IdMenu
    WHEN MATCHED THEN
        UPDATE SET destino.Nombre = o.Nombre,
                   destino.Icono  = o.Icono,
                   destino.IdApp  = o.IdApp,
                   destino.App    = o.App
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (IdMenu, Nombre, Icono, IdApp, App)
        VALUES (o.IdMenu, o.Nombre, o.Icono, o.IdApp, o.App);
END
GO


/* ------------------------------------------------------------ ERP_SubMenu  */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_MENU_SUBMENU_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_SUBMENU_MASIVO
GO

/* Tabla temporal #SubMenu(IdSubMenu, IdMenu, Nombre, NombreFormulario).
   La clave es el par IdSubMenu + IdMenu, igual que el WHERE del SP anterior. */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_SUBMENU_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY IdSubMenu, IdMenu ORDER BY (SELECT 0)) AS rn
          FROM #SubMenu
    )
    MERGE dbo.ERP_SubMenu AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.IdSubMenu = o.IdSubMenu
      AND destino.IdMenu    = o.IdMenu
    WHEN MATCHED THEN
        UPDATE SET destino.Nombre           = o.Nombre,
                   destino.NombreFormulario = o.NombreFormulario
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (IdSubMenu, IdMenu, Nombre, NombreFormulario)
        VALUES (o.IdSubMenu, o.IdMenu, o.Nombre, o.NombreFormulario);
END
GO


/* ------------------------------------------------------------ ERP_Permiso  */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_MENU_SUBMENU_ROL_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_SUBMENU_ROL_MASIVO
GO

/* Tabla temporal #PermisoRol(IdRol, IdSubMenu, Activo) */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_SUBMENU_ROL_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY IdRol, IdSubMenu ORDER BY (SELECT 0)) AS rn
          FROM #PermisoRol
    )
    MERGE dbo.ERP_Permiso AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.IdRol     = o.IdRol
      AND destino.IdSubMenu = o.IdSubMenu
    WHEN MATCHED THEN
        UPDATE SET destino.Activo = o.Activo
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (IdRol, IdSubMenu, Activo)
        VALUES (o.IdRol, o.IdSubMenu, o.Activo);
END
GO


/* ----------------------------------------------------------- ERP_Menu_APP  */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_MENU_APP_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_APP_MASIVO
GO

/* Tabla temporal #MenuApp(Id_APP, Nombre, Icono).

   >>> Id_APP es IDENTITY(1,1): una app nueva NO puede llevar el código que se
   escriba en la grilla, lo asigna SQL Server. Por eso el INSERT va sin Id_APP.
   El SP_GUARDAR_MENU_APP anterior insertaba con VALUES(@Cod,@Des,@Icono) sin
   lista de columnas: al saltearse la identidad, el código terminaba guardado
   en Nombre, el nombre en Icono y el icono en VersionAnterior. Si prefiere
   seguir fijando el Id a mano, hay que quitarle el IDENTITY a la columna. */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_APP_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY Id_APP ORDER BY (SELECT 0)) AS rn
          FROM #MenuApp
    )
    MERGE dbo.ERP_Menu_APP AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.Id_APP = o.Id_APP
    WHEN MATCHED THEN
        UPDATE SET destino.Nombre = o.Nombre,
                   destino.Icono  = o.Icono
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Nombre, Icono)
        VALUES (o.Nombre, o.Icono);
END
GO


/* -------------------------------------------------------- ERP_Permiso_APP  */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_MENU_USUARIO_APP_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_USUARIO_APP_MASIVO
GO

/* Tabla temporal #PermisoApp(Id_APP, Id_User, Activo) */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MENU_USUARIO_APP_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY Id_APP, Id_User ORDER BY (SELECT 0)) AS rn
          FROM #PermisoApp
    )
    MERGE dbo.ERP_Permiso_APP AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.Id_APP  = o.Id_APP
      AND destino.Id_User = o.Id_User
    WHEN MATCHED THEN
        UPDATE SET destino.Activo = o.Activo
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Id_APP, Id_User, Activo)
        VALUES (o.Id_APP, o.Id_User, o.Activo);
END
GO


/* ============================================================================
   Los SP de una fila que estos reemplazan se dan de baja en
   Sql\ERP_Drop_SP_Antiguos.sql
   ============================================================================ */
