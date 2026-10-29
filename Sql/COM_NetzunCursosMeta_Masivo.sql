/* ============================================================================
   Carga masiva de la meta semanal de cursos de Netzun (COM_NetzunCursosMeta).
   Procedimiento usado por CapaDatos\cd_comunicacion.cs

   El formulario sube toda la tanda con SqlBulkCopy a la tabla temporal
   #NetzunCursosMeta y luego llama a este procedimiento, que resuelve alta y
   actualizacion en un solo MERGE. Los dos pasos van sobre la MISMA conexion:
   la tabla temporal solo existe mientras esa conexion siga abierta.

   La clave es ValidacionCursos + Fecha: una meta por grupo de validacion y
   fecha, asi que volver a cargar el mismo archivo actualiza en vez de
   duplicar. Semana y Meta se actualizan.

   La tabla no trae un indice unico sobre esa pareja. Conviene crearlo para
   que la base misma impida los duplicados que hoy solo evita este MERGE:

     CREATE UNIQUE INDEX UX_COM_NetzunCursosMeta_Clave
         ON dbo.COM_NetzunCursosMeta (ValidacionCursos, Fecha);
   ============================================================================ */

IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_CURSOSMETA_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_CURSOSMETA_MASIVO
GO

CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_CURSOSMETA_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    /* Si el Excel trae la misma validacion y fecha mas de una vez, el MERGE
       fallaria por intentar tocar la misma fila dos veces. Se queda la ultima
       aparicion del archivo. */
    ;WITH origen AS
    (
        SELECT *,
               ROW_NUMBER() OVER (PARTITION BY ValidacionCursos, Fecha
                                  ORDER BY (SELECT NULL) DESC) AS rn
          FROM #NetzunCursosMeta
         WHERE ValidacionCursos IS NOT NULL
           AND LTRIM(RTRIM(ValidacionCursos)) <> ''
           AND Fecha IS NOT NULL
    )
    MERGE dbo.COM_NetzunCursosMeta AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS fuente
       ON  destino.ValidacionCursos = fuente.ValidacionCursos
       AND destino.Fecha            = fuente.Fecha

    WHEN MATCHED THEN
        UPDATE SET
            destino.Semana  = fuente.Semana,
            destino.Meta    = fuente.Meta,
            destino.FecEdit = fuente.FecEdit,
            destino.UseEdit = fuente.UseEdit

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (ValidacionCursos, Fecha, Semana, Meta,
                Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit)
        VALUES (fuente.ValidacionCursos, fuente.Fecha, fuente.Semana,
                fuente.Meta,
                'S', fuente.FecCre, fuente.UseReg, fuente.Hostname,
                fuente.FecEdit, fuente.UseEdit);
END
GO
