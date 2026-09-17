/* ============================================================================
   ERP_PermisoAppMovil — acceso de cada usuario a las opciones de la app móvil.
   Procedimientos usados por CapaDatos\cd_rolesuser.cs
   ============================================================================ */

/* Ya no se usa: el guardado pasó a ser masivo. */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_PERMISO_APP_MOVIL', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_PERMISO_APP_MOVIL
GO


IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_PERMISO_APP_MOVIL_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_PERMISO_APP_MOVIL_MASIVO
GO

/* Versión masiva. No recibe parámetros: C# sube las filas con SqlBulkCopy a la
   tabla temporal #PermisoAppMovil sobre la MISMA conexión y después ejecuta
   este procedimiento, que resuelve todo en un solo MERGE.

   La tabla temporal debe existir con estas columnas:
   IdUser, IdAppOpc, Activo, Obs, Estado, EstadoP,
   FecCre, UseReg, Hostname, FecEdit, UseEdit, UseElim  */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_PERMISO_APP_MOVIL_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    /* Si por lo que sea llegara repetido el par IdUser + IdAppOpc, MERGE
       aborta con error. Se queda una sola fila por par. */
    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY IdUser, IdAppOpc ORDER BY (SELECT 0)) AS rn
          FROM #PermisoAppMovil
    )
    MERGE dbo.ERP_PermisoAppMovil AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.IdUser   = o.IdUser
      AND destino.IdAppOpc = o.IdAppOpc

    WHEN MATCHED THEN
        UPDATE SET destino.Activo  = o.Activo,
                   destino.Obs     = o.Obs,
                   destino.Estado  = o.Estado,
                   destino.EstadoP = o.EstadoP,
                   destino.FecEdit = o.FecEdit,
                   destino.UseEdit = o.UseEdit,
                   destino.UseElim = o.UseElim

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (IdUser, IdAppOpc, Activo, Obs, Estado, EstadoP,
                FecCre, UseReg, Hostname, FecEdit, UseEdit, UseElim)
        VALUES (o.IdUser, o.IdAppOpc, o.Activo, o.Obs, o.Estado, o.EstadoP,
                o.FecCre, o.UseReg, o.Hostname, o.FecEdit, o.UseEdit, o.UseElim);
END
GO


IF OBJECT_ID('dbo.SP_MOSTRAR_APP_OPCIONES_USUARIO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_APP_OPCIONES_USUARIO
GO

/* Todas las opciones de app con el acceso del usuario indicado.
   Parte de ERP_AppOpciones (LEFT JOIN al permiso) para que el usuario vea
   también las opciones que todavía no tiene asignadas, con Acceso = 'NO'.

   Columnas en el orden que espera dataGridView6 (el formulario inserta la
   columna Check en la posición 0 y oculta Activo):
   Activo, IdApp, App, IdAppOpc, Nombre

   ERP_AppOpciones guarda IdApp pero no el nombre de la app: ese nombre sale
   del catálogo dbo.ERP_Menu_APP (Id_APP, Nombre), el mismo que alimenta a
   comboBox_app. El JOIN no filtra por Estado porque en ese catálogo la mayoría
   de las filas lo tiene en NULL. */
CREATE PROCEDURE dbo.SP_MOSTRAR_APP_OPCIONES_USUARIO
    @Cod int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  CAST(ISNULL(p.Activo, 0) AS bit)               AS Activo,
            o.IdApp                                        AS IdApp,
            a.Nombre                                       AS App,
            o.IdAppOpc                                     AS IdAppOpc,
            o.Nombre                                       AS Nombre
      FROM  dbo.ERP_AppOpciones o
            LEFT JOIN dbo.ERP_Menu_APP a
                   ON a.Id_APP = o.IdApp
            LEFT JOIN dbo.ERP_PermisoAppMovil p
                   ON p.IdAppOpc = o.IdAppOpc
                  AND p.IdUser   = @Cod
                  AND ISNULL(p.Estado, 'S') = 'S'
     WHERE  ISNULL(o.Estado, 'S') = 'S'
     ORDER  BY o.IdApp, o.IdAppOpc;
END
GO
