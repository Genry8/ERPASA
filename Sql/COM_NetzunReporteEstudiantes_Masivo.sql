/* ============================================================================
   Carga masiva del reporte de estudiantes de Netzun
   (COM_NetzunReporteEstudiantes).
   Procedimiento usado por CapaDatos\cd_comunicacion.cs

   El formulario sube toda la tanda con SqlBulkCopy a la tabla temporal
   #NetzunEstudiantes y luego llama a este procedimiento. Los dos pasos van
   sobre la MISMA conexion: la tabla temporal solo existe mientras esa
   conexion siga abierta.

   La carga reemplaza por fecha: se borra de la tabla todo lo que ya exista
   con las fechas de reporte que trae el archivo y se inserta el archivo
   completo. Asi una fecha queda siempre tal cual el ultimo Excel cargado,
   sin arrastrar filas viejas que ya no vengan en el.

   Las dos operaciones van dentro de una transaccion: si el INSERT falla, el
   DELETE se deshace y la fecha conserva los datos que ya tenia.
   ============================================================================ */

IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_ESTUDIANTES_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_ESTUDIANTES_MASIVO
GO

CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_COM_NETZUN_ESTUDIANTES_MASIVO
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    /* Si no llego nada util no se borra nada: evita vaciar una fecha por una
       carga en blanco. */
    IF NOT EXISTS (SELECT 1 FROM #NetzunEstudiantes WHERE FecReporte IS NOT NULL)
        RETURN;

    BEGIN TRANSACTION;

        /* Las fechas de reporte que trae el archivo. Normalmente es una sola,
           la que el usuario elige en el formulario. */
        DECLARE @fechas TABLE (FecReporte date PRIMARY KEY);

        INSERT INTO @fechas (FecReporte)
        SELECT DISTINCT FecReporte
          FROM #NetzunEstudiantes
         WHERE FecReporte IS NOT NULL;

        /* Fuera lo que ya hubiera de esas fechas. */
        DELETE d
          FROM dbo.COM_NetzunReporteEstudiantes AS d
         INNER JOIN @fechas AS f ON f.FecReporte = d.FecReporte;

        /* Y entra el archivo completo. */
        INSERT INTO dbo.COM_NetzunReporteEstudiantes (
                IdNetzun, NombresApellidos, Email, Funcion, EstadoUsuario,
                InicioSesion, Rol, Curso, FecPrimeraMatricula, EstadoCurso,
                IntentosDesaprobados, Capsulas, PorcentajeProgreso,
                DuracionCurso, AvanceHoras, NotaExamen, FecAprobacionExamen,
                FecUltimaLeccion, HoraUltimaLeccion, FecDeadline, Nivel1,
                CodigoInterno, CursoAsignadoLibre, Cargo, NumeroDocumento,
                CursoNetzunPropio, FecCertificacion, FecInscripcionCurso,
                RutaAprendizaje, FecInscripcionUsuario,
                FecDesactivacionUsuario, Especializaciones,
                FecFinEspecializacion, FecFinRuta, HoraFinRuta,
                FecUltimaMatricula, Empresa, Gerencia, TipoTrabajador, Dni,
                FecReporte,
                Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit)
        SELECT
                t.IdNetzun, t.NombresApellidos, t.Email, t.Funcion,
                t.EstadoUsuario, t.InicioSesion, t.Rol, t.Curso,
                t.FecPrimeraMatricula, t.EstadoCurso,
                t.IntentosDesaprobados, t.Capsulas, t.PorcentajeProgreso,
                t.DuracionCurso, t.AvanceHoras, t.NotaExamen,
                t.FecAprobacionExamen, t.FecUltimaLeccion,
                t.HoraUltimaLeccion, t.FecDeadline, t.Nivel1,
                t.CodigoInterno, t.CursoAsignadoLibre, t.Cargo,
                t.NumeroDocumento, t.CursoNetzunPropio, t.FecCertificacion,
                t.FecInscripcionCurso, t.RutaAprendizaje,
                t.FecInscripcionUsuario, t.FecDesactivacionUsuario,
                t.Especializaciones, t.FecFinEspecializacion, t.FecFinRuta,
                t.HoraFinRuta, t.FecUltimaMatricula, t.Empresa, t.Gerencia,
                t.TipoTrabajador, t.Dni, t.FecReporte,
                'S', t.FecCre, t.UseReg, t.Hostname, t.FecEdit, t.UseEdit
          FROM #NetzunEstudiantes AS t
         WHERE t.FecReporte IS NOT NULL;

    COMMIT TRANSACTION;
END
GO
