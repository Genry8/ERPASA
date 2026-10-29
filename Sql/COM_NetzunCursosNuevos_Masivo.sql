/* ============================================================================
   Carga masiva del formato de cursos nuevos de Netzun
   (COM_NetzunCursosNuevos).
   Procedimiento usado por CapaDatos\cd_comunicacion.cs

   El formulario sube toda la tanda con SqlBulkCopy a la tabla temporal
   #NetzunCursosNuevos y luego llama a este procedimiento, que resuelve alta y
   actualizacion en un solo MERGE. Los dos pasos van sobre la MISMA conexion:
   la tabla temporal solo existe mientras esa conexion siga abierta.

   La clave es NombresApellidos + Curso + FecAsignacion, la misma del indice
   unico UX_COM_NetzunCursosNuevos_Clave, asi que volver a cargar el mismo
   archivo actualiza en vez de duplicar.
   ============================================================================ */

IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_CURSOSNUEVOS_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_CURSOSNUEVOS_MASIVO
GO

CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_CURSOSNUEVOS_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    /* Si el Excel trae la misma persona, curso y fecha mas de una vez, el
       MERGE fallaria por intentar tocar la misma fila dos veces. Se queda la
       ultima aparicion del archivo. */
    ;WITH origen AS
    (
        SELECT *,
               ROW_NUMBER() OVER (PARTITION BY NombresApellidos, Curso, FecAsignacion
                                  ORDER BY (SELECT NULL) DESC) AS rn
          FROM #NetzunCursosNuevos
         WHERE NombresApellidos IS NOT NULL
           AND Curso IS NOT NULL
           AND FecAsignacion IS NOT NULL
    )
    MERGE dbo.COM_NetzunCursosNuevos AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS fuente
       ON  destino.NombresApellidos = fuente.NombresApellidos
       AND destino.Curso            = fuente.Curso
       AND destino.FecAsignacion    = fuente.FecAsignacion

    WHEN MATCHED THEN
        UPDATE SET
            destino.Especializacion = fuente.Especializacion,
            destino.HorasTotales    = fuente.HorasTotales,
            destino.Combinada       = fuente.Combinada,
            destino.FecEdit         = fuente.FecEdit,
            destino.UseEdit         = fuente.UseEdit

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (NombresApellidos, Especializacion, Curso, FecAsignacion,
                HorasTotales, Combinada,
                Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit)
        VALUES (fuente.NombresApellidos, fuente.Especializacion, fuente.Curso,
                fuente.FecAsignacion, fuente.HorasTotales, fuente.Combinada,
                'S', fuente.FecCre, fuente.UseReg, fuente.Hostname,
                fuente.FecEdit, fuente.UseEdit);
END
GO
