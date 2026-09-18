/* ============================================================================
   ERP_AppOpciones — opciones habilitadas por cada aplicación móvil.
   Procedimientos usados por CapaDatos\cd_rolesuser.cs
   ============================================================================ */

/* Ya no se usa: el guardado pasó a ser masivo. */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_APP_OPCIONES', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_APP_OPCIONES
GO


IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_APP_OPCIONES_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_APP_OPCIONES_MASIVO
GO

/* No recibe parámetros: C# sube las filas con SqlBulkCopy a la tabla temporal
   #AppOpciones sobre la MISMA conexión y después ejecuta este procedimiento,
   que resuelve altas y actualizaciones en un solo MERGE.

   La tabla temporal debe existir con estas columnas:
   IdAppOpc, IdApp, Nombre, Comentario, Obs, Estado, EstadoP,
   FecCre, UseReg, Hostname, FecEdit, UseEdit, UseElim

   FecCre / UseReg / Hostname solo se graban en el alta: en la edición se
   conservan los originales y se mueven FecEdit / UseEdit. */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_APP_OPCIONES_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    /* Si llegara repetido el IdAppOpc, MERGE aborta con error.
       Se queda una sola fila por clave. */
    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (PARTITION BY IdAppOpc ORDER BY (SELECT 0)) AS rn
          FROM #AppOpciones
    )
    MERGE dbo.ERP_AppOpciones AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.IdAppOpc = o.IdAppOpc

    WHEN MATCHED THEN
        UPDATE SET destino.IdApp      = o.IdApp,
                   destino.Nombre     = o.Nombre,
                   destino.Comentario = o.Comentario,
                   destino.Obs        = o.Obs,
                   destino.Estado     = o.Estado,
                   destino.EstadoP    = o.EstadoP,
                   destino.FecEdit    = o.FecEdit,
                   destino.UseEdit    = o.UseEdit,
                   destino.UseElim    = o.UseElim

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (IdAppOpc, IdApp, Nombre, Comentario, Obs, Estado, EstadoP,
                FecCre, UseReg, Hostname, FecEdit, UseEdit, UseElim)
        VALUES (o.IdAppOpc, o.IdApp, o.Nombre, o.Comentario, o.Obs, o.Estado, o.EstadoP,
                o.FecCre, o.UseReg, o.Hostname, o.FecEdit, o.UseEdit, o.UseElim);
END
GO


IF OBJECT_ID('dbo.SP_MOSTRAR_OPCION_APP', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_OPCION_APP
GO

/* Opciones de una app, en el orden de las columnas que espera dataGridView4:
   IdAppOpc, Nombre, Comentario. */
CREATE PROCEDURE dbo.SP_MOSTRAR_OPCION_APP
    @Cod int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  IdAppOpc,
            Nombre,
            Comentario
      FROM  dbo.ERP_AppOpciones
     WHERE  IdApp = @Cod
       AND  ISNULL(Estado, 'S') = 'S'
     ORDER  BY IdAppOpc;
END
GO
