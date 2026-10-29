/* ============================================================================
   dbo.V_COM_NetzunRepGeneral

   Cambio: se agrega la columna [MetaAvance] al costado de [%Avance de curso].
   Sale de dbo.COM_NetzunCursosMeta cruzando por numero de semana y por la
   validacion del curso (NUEVO / POTENCIANDO / ASIGNADO).

   Para poder cruzar hizo falta mover tres expresiones que antes vivian en el
   SELECT final a un CTE nuevo (Final): el numero de semana, la validacion del
   curso y el avance. En T-SQL no se puede reusar el alias de una columna
   dentro del mismo SELECT, y la meta necesita dos de esos valores.

   La meta se trae con una subconsulta y MAX en vez de un JOIN: si algun dia
   hubiera dos metas para la misma semana y validacion, un JOIN duplicaria las
   filas del reporte, y asi se toma una sola.
   ============================================================================ */

CREATE OR ALTER VIEW dbo.V_COM_NetzunRepGeneral
AS
WITH Base AS (
    SELECT r.IdNetzun, r.NombresApellidos, r.Email, r.Curso, r.EstadoCurso, r.PorcentajeProgreso,
           r.DuracionCurso, r.AvanceHoras, r.FecUltimaLeccion, r.Nivel1, r.Cargo, r.FecInscripcionCurso, r.FecInscripcionUsuario,
           r.Especializaciones, r.Empresa, r.Gerencia, r.TipoTrabajador, r.FecReporte, r.CursoNetzunPropio,
           CASE WHEN LEN(LTRIM(RTRIM(r.Dni))) < 8
                THEN RIGHT('00000000' + LTRIM(RTRIM(r.Dni)), 8)
                ELSE LTRIM(RTRIM(r.Dni)) END AS DocIdentidad
    FROM dbo.COM_NetzunReporteEstudiantes AS r
    WHERE ISNULL(r.Estado, 'S') = 'S'
),
Activos AS (
    SELECT p.DniNorm, p.TipoTrabajador, p.Sede,
           ROW_NUMBER() OVER (PARTITION BY p.DniNorm ORDER BY p.Sec) AS rn
    FROM (SELECT s.Sec, s.TipoTrabajador, s.Sede, s.StatusTrab,
                 CASE WHEN LEN(LTRIM(RTRIM(s.Dni))) < 8
                      THEN RIGHT('00000000' + LTRIM(RTRIM(s.Dni)), 8)
                      ELSE LTRIM(RTRIM(s.Dni)) END AS DniNorm
          FROM dbo.SD_Personal AS s) AS p
    WHERE UPPER(LTRIM(RTRIM(p.StatusTrab))) = 'ACTIVO'
),
Calc AS (
    SELECT b.*,
           CASE WHEN b.AvanceHoras IS NULL THEN NULL
                ELSE DATEPART(HOUR, b.AvanceHoras) + DATEPART(MINUTE, b.AvanceHoras) / 60E0 END AS AvanceEnHoras,
           CASE WHEN b.DuracionCurso IS NULL THEN NULL
                ELSE DATEPART(HOUR, b.DuracionCurso) + DATEPART(MINUTE, b.DuracionCurso) / 60E0 END AS HorasTotalesCurso,
           CASE WHEN a.DniNorm IS NULL THEN 'INACTIVO' ELSE 'ACTIVO' END AS StatusTrabajador,
           a.TipoTrabajador AS TipoTrabajadorMaestro,
           a.Sede AS SedeTrabajador
    FROM Base AS b
    LEFT JOIN Activos AS a ON a.DniNorm = b.DocIdentidad AND a.rn = 1
),
Final AS (
    /* Las tres columnas que el SELECT de abajo necesita reusar: la semana y la
       validacion para buscar la meta, y el avance porque se muestra al lado. */
    SELECT c.*,
           DATEPART(ISO_WEEK, c.FecReporte) AS NroSemana,
           CASE WHEN EXISTS (SELECT 1
                             FROM dbo.COM_NetzunCursosNuevos AS cn
                             WHERE ISNULL(cn.Estado, 'S') = 'S'
                               AND cn.Combinada = ISNULL(c.NombresApellidos, '') + ISNULL(c.Especializaciones, '') + ISNULL(c.Curso, ''))
                THEN 'NUEVO'
                WHEN c.CursoNetzunPropio = 'Curso Propio' THEN 'POTENCIANDO'
                ELSE 'ASIGNADO' END AS ValidacionCurso,
           CASE WHEN c.HorasTotalesCurso IS NULL OR c.AvanceEnHoras IS NULL OR c.HorasTotalesCurso = 0 THEN NULL
                WHEN c.AvanceEnHoras / c.HorasTotalesCurso <= 1 THEN c.AvanceEnHoras / c.HorasTotalesCurso
                ELSE 1 END AS AvanceDeCurso
    FROM Calc AS c
)
SELECT
    f.IdNetzun                                    AS [ID],
    f.NombresApellidos                            AS [Nombres y Apellidos],
    f.Email                                       AS [Email],
    f.Curso                                       AS [Curso],
    f.EstadoCurso                                 AS [Estado de curso],
    f.PorcentajeProgreso                          AS [Porcentaje de Progreso (cápsulas completadas)],
    f.FecUltimaLeccion                            AS [Fecha última lección],
    f.Nivel1                                      AS [Area],
    f.Cargo                                       AS [Cargo],
    f.FecInscripcionCurso                         AS [Inscripción del curso en la compañia],
    f.FecInscripcionUsuario                       AS [Inscripcion del usuario en la compañia],
    f.Especializaciones                           AS [Especializaciones],
    f.Empresa                                     AS [EMPRESA],
    REPLACE(f.Gerencia, 'GERENCIA DE FUNDO', 'GERENCIA FUNDO')  AS [GERENCIA],
    REPLACE(f.TipoTrabajador, 'EMPLEADOS', 'EMPLEADO')          AS [Tipo de trabajador],
    f.FecReporte                                  AS [FECHA DE REPORTE],
    f.NroSemana                                   AS [N° Semana],
    f.DocIdentidad                                AS [Doc. Identidad],
    f.AvanceEnHoras                               AS [Avance en horas],
    f.HorasTotalesCurso                           AS [Horas totales del curso],
    f.AvanceDeCurso                               AS [%Avance de curso],
    /* La meta de la semana para ese tipo de validacion. */
    (SELECT MAX(m.Meta)
       FROM dbo.COM_NetzunCursosMeta AS m
      WHERE ISNULL(m.Estado, 'S') = 'S'
        AND m.Semana = f.NroSemana
        AND m.ValidacionCursos = f.ValidacionCurso) AS [MetaAvance],
    f.ValidacionCurso                             AS [Validacion de curso],
    f.StatusTrabajador                            AS [trabajadores.Status Trabajador],
    f.TipoTrabajadorMaestro                       AS [trabajadores.Tipo Trabajador],
    f.SedeTrabajador                              AS [trabajadores.Sede],
    CONCAT(f.IdNetzun, f.Curso, DAY(f.FecReporte), '/',
           RIGHT('0' + CAST(MONTH(f.FecReporte) AS VARCHAR(2)), 2), '/', YEAR(f.FecReporte)) AS [Combinada],
    f.CursoNetzunPropio                           AS [Curso Netzun/Propio],
    CASE WHEN f.EstadoCurso = 'No Iniciado' THEN f.FecInscripcionCurso
         ELSE f.FecUltimaLeccion END              AS [Fecha ranking]
FROM Final AS f;
GO


/* ---------------------------------------------------------------- pruebas

   1) Que la meta este llegando y no salga toda en NULL:

      SELECT TOP 20 [N° Semana], [Validacion de curso], [%Avance de curso], [MetaAvance]
        FROM dbo.V_COM_NetzunRepGeneral
       ORDER BY [N° Semana];

   2) Que la vista no haya cambiado de cantidad de filas al agregar la meta
      (tiene que dar el mismo numero que antes del cambio):

      SELECT COUNT(*) FROM dbo.V_COM_NetzunRepGeneral;

   3) Semanas del reporte que todavia no tienen meta cargada:

      SELECT DISTINCT [N° Semana], [Validacion de curso]
        FROM dbo.V_COM_NetzunRepGeneral
       WHERE [MetaAvance] IS NULL
       ORDER BY [N° Semana];
--------------------------------------------------------------------------- */
