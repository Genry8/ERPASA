/* ============================================================================
   Baja de los SP de una fila de Comunicación que reemplazaron las cargas
   masivas (Sql\COM_Comunicacion_Masivo.sql).

   Verificado: ningún formulario de la solución los llama. Lo único que quedaba
   apuntándoles eran los métodos puente de CapaNegocio, que también quedan sin
   uso.

   >>> ANTES DE EJECUTAR: corra el bloque de verificación del final de este
   archivo. Si devuelve filas, algún objeto de la base todavía los usa.
   ============================================================================ */


/* --- Cosechando Ganadores --------------------------------------------------
   OJO: NO se borra SP_CODIGO_COM_COSECHANDOGANADORES: pese al nombre, ese es
   el que hace el DELETE previo y el formulario lo sigue llamando. */
DROP PROCEDURE IF EXISTS dbo.SP_GUARDAR_COM_COSECHANDOGANADORES
DROP PROCEDURE IF EXISTS dbo.SP_ACTUALIZAR_COM_COSECHANDOGANADORES
GO


/* --- Potenciando Líderes ---------------------------------------------------
   OJO: NO se borra SP_CODIGO_COM_POTENCIANDOLIDERES, también hace el DELETE. */
DROP PROCEDURE IF EXISTS dbo.SP_GUARDAR_COM_POTENCIANDOLIDERES
DROP PROCEDURE IF EXISTS dbo.SP_ACTUALIZAR_COM_POTENCIANDOLIDERES
GO


/* --- Líderes en Acción  ->  SP_GUARDAR_ACTUALIZAR_COM_LIDERESACCION_MASIVO
   Acá SP_CODIGO_COM_LIDERESACCION sí se va: era una consulta de existencia de
   verdad, y el MERGE la reemplaza. */
DROP PROCEDURE IF EXISTS dbo.SP_GUARDAR_COM_LIDERESACCION
DROP PROCEDURE IF EXISTS dbo.SP_ACTUALIZAR_COM_LIDERESACCION
DROP PROCEDURE IF EXISTS dbo.SP_CODIGO_COM_LIDERESACCION
GO


/* --- Encuesta Clima --------------------------------------------------------
   OJO: NO se borra SP_ELIMINAR_COM_ENCUESTACLIMA, el formulario lo llama antes
   de insertar.
   SP_ACTUALIZAR_COM_ENCUESTACLIMA ya estaba sin uso desde antes de este
   cambio: ningún formulario lo llamaba. */
DROP PROCEDURE IF EXISTS dbo.SP_GUARDAR_COM_ENCUESTACLIMA
DROP PROCEDURE IF EXISTS dbo.SP_ACTUALIZAR_COM_ENCUESTACLIMA
GO


/* --- Encuesta Participación ------------------------------------------------
   OJO: NO se borra SP_ELIMINAR_COM_PARTICIPACION_CLIMA. */
DROP PROCEDURE IF EXISTS dbo.SP_GUARDAR_ACTUALIZAR_PARTICIPACION_ENCUESTA
GO


/* --- Movimiento Canje ------------------------------------------------------
   OJO: NO se borra SP_ELIMINAR_COM_MOVIMIENTO_CANJE. */
DROP PROCEDURE IF EXISTS dbo.SP_GUARDAR_ACTUALIZAR_MOVIMIENTO_CANJE
GO


/* --- Puntos Planilla  ->  SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla_MASIVO */
DROP PROCEDURE IF EXISTS dbo.SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla
GO


/* --- Saldo Puntos  ->  SP_GUARDAR_ACTUALIZAR_SALDO_MASIVO */
DROP PROCEDURE IF EXISTS dbo.SP_GUARDAR_ACTUALIZAR_SALDO
GO


/* ============================================================================
   VERIFICACIÓN 1 — correr ANTES de los DROP.
   Si devuelve filas, esos objetos de la base llaman a alguno de estos SP.
   ============================================================================ */
SELECT DISTINCT o.name AS llamador, d.referenced_entity_name AS sp_llamado
FROM sys.sql_expression_dependencies d
JOIN sys.objects o ON o.object_id = d.referencing_id
WHERE d.referenced_entity_name IN (
    'SP_GUARDAR_COM_COSECHANDOGANADORES','SP_ACTUALIZAR_COM_COSECHANDOGANADORES',
    'SP_GUARDAR_COM_POTENCIANDOLIDERES','SP_ACTUALIZAR_COM_POTENCIANDOLIDERES',
    'SP_GUARDAR_COM_LIDERESACCION','SP_ACTUALIZAR_COM_LIDERESACCION','SP_CODIGO_COM_LIDERESACCION',
    'SP_GUARDAR_COM_ENCUESTACLIMA','SP_ACTUALIZAR_COM_ENCUESTACLIMA',
    'SP_GUARDAR_ACTUALIZAR_PARTICIPACION_ENCUESTA',
    'SP_GUARDAR_ACTUALIZAR_MOVIMIENTO_CANJE',
    'SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla',
    'SP_GUARDAR_ACTUALIZAR_SALDO')
GO


/* ============================================================================
   VERIFICACIÓN 2 — correr DESPUÉS de los DROP. No debería devolver filas.
   ============================================================================ */
SELECT name
FROM sys.objects
WHERE type = 'P'
  AND name IN (
    'SP_GUARDAR_COM_COSECHANDOGANADORES','SP_ACTUALIZAR_COM_COSECHANDOGANADORES',
    'SP_GUARDAR_COM_POTENCIANDOLIDERES','SP_ACTUALIZAR_COM_POTENCIANDOLIDERES',
    'SP_GUARDAR_COM_LIDERESACCION','SP_ACTUALIZAR_COM_LIDERESACCION','SP_CODIGO_COM_LIDERESACCION',
    'SP_GUARDAR_COM_ENCUESTACLIMA','SP_ACTUALIZAR_COM_ENCUESTACLIMA',
    'SP_GUARDAR_ACTUALIZAR_PARTICIPACION_ENCUESTA',
    'SP_GUARDAR_ACTUALIZAR_MOVIMIENTO_CANJE',
    'SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla',
    'SP_GUARDAR_ACTUALIZAR_SALDO')
GO


/* ============================================================================
   NO TOCAR — estos siguen en uso, el formulario los llama antes de insertar:

     SP_CODIGO_COM_COSECHANDOGANADORES   (DELETE, pese al nombre)
     SP_CODIGO_COM_POTENCIANDOLIDERES    (DELETE, pese al nombre)
     SP_ELIMINAR_COM_ENCUESTACLIMA
     SP_ELIMINAR_COM_PARTICIPACION_CLIMA
     SP_ELIMINAR_COM_MOVIMIENTO_CANJE
   ============================================================================ */
