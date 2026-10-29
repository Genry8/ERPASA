/* ============================================================================
   Reportes de taller: control de limpieza y control de mantenimiento.
   Procedimientos usados por CapaDatos\cd_taller.cs

   Mismo esquema que SP_MOSTRAR_LISTA_ORDEN_TRABAJO: se filtra por rango de
   fechas, empresa y sede, y se devuelve Estado como texto para que el
   formulario pinte en rojo los eliminados.
   ============================================================================ */


IF OBJECT_ID('dbo.SP_MOSTRAR_LISTA_CONTROL_LIMPIEZA', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_LISTA_CONTROL_LIMPIEZA
GO

/* Las cinco primeras marcas son bit y las cinco siguientes varchar(1); todas
   se devuelven como SI / NO para que el Excel salga legible. */
CREATE PROCEDURE dbo.SP_MOSTRAR_LISTA_CONTROL_LIMPIEZA
    @FecIni date,
    @FecFin date,
    @Emp    varchar(80),
    @Sed    varchar(80)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  Id,
            ISNULL(Empresa, '') AS Empresa,
            ISNULL(Sede, '')    AS Sede,
            Fecha,
            ISNULL(Cabezal, '') AS Cabezal,
            ISNULL(Valvula, '') AS Valvula,
            ISNULL(NroBano, '') AS NroBano,
            CASE WHEN JabonNeutro    = 1 THEN 'SI' ELSE 'NO' END AS JabonNeutro,
            CASE WHEN PapelHigienico = 1 THEN 'SI' ELSE 'NO' END AS PapelHigienico,
            CASE WHEN PapelToalla    = 1 THEN 'SI' ELSE 'NO' END AS PapelToalla,
            CASE WHEN Cal            = 1 THEN 'SI' ELSE 'NO' END AS Cal,
            CASE WHEN Inodoro        = 1 THEN 'SI' ELSE 'NO' END AS Inodoro,
            CASE WHEN Lavadero    = 'S' THEN 'SI' ELSE 'NO' END AS Lavadero,
            CASE WHEN Cano        = 'S' THEN 'SI' ELSE 'NO' END AS Cano,
            CASE WHEN TanqueAgua  = 'S' THEN 'SI' ELSE 'NO' END AS TanqueAgua,
            CASE WHEN PozaCal     = 'S' THEN 'SI' ELSE 'NO' END AS PozaCal,
            CASE WHEN PozoSeptico = 'S' THEN 'SI' ELSE 'NO' END AS PozoSeptico,
            ISNULL(Obs, '')  AS Obs,
            ISNULL(Foto, '') AS Foto,
            CASE WHEN ISNULL(Estado, 'S') = 'S' THEN 'ACTIVO' ELSE 'ELIMINADO' END AS Estado,
            FecCre,
            UseReg,
            ISNULL(Hostname, '') AS Hostname
      FROM  dbo.TALL_ControlLimpieza
     WHERE  Fecha BETWEEN @FecIni AND @FecFin
       AND  ISNULL(Empresa, '') LIKE @Emp
       AND  ISNULL(Sede, '')    LIKE @Sed
     ORDER  BY Fecha DESC, Id DESC;
END
GO


IF OBJECT_ID('dbo.SP_MOSTRAR_LISTA_CONTROL_MANTENIMIENTO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_LISTA_CONTROL_MANTENIMIENTO
GO

/* El filtro de fechas usa Fecha (la del registro), no FechaIngreso ni
   FechaSalida, para que coincida con el rango que elige el usuario. */
CREATE PROCEDURE dbo.SP_MOSTRAR_LISTA_CONTROL_MANTENIMIENTO
    @FecIni date,
    @FecFin date,
    @Emp    varchar(80),
    @Sed    varchar(80)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  Id,
            ISNULL(Empresa, '') AS Empresa,
            ISNULL(Sede, '')    AS Sede,
            Fecha,
            ISNULL(Placa, '')            AS Placa,
            ISNULL(Vehiculo, '')         AS Vehiculo,
            ISNULL(Area, '')             AS Area,
            ISNULL(TipoUnidad, '')       AS TipoUnidad,
            ISNULL(GrupoUnidad, '')      AS GrupoUnidad,
            ISNULL(kilometraje, 0)       AS Kilometraje,
            ISNULL(TipoIntervencion, '') AS TipoIntervencion,
            FechaIngreso,
            FechaSalida,
            ISNULL(Actividad, '') AS Actividad,
            ISNULL(Insumo, '')    AS Insumo,
            ISNULL(Cantidad, 0)   AS Cantidad,
            ISNULL(Obs, '')       AS Obs,
            ISNULL(Foto, '')      AS Foto,
            CASE WHEN ISNULL(Estado, 'S') = 'S' THEN 'ACTIVO' ELSE 'ELIMINADO' END AS Estado,
            FecCre,
            UseReg,
            ISNULL(Hostname, '') AS Hostname
      FROM  dbo.TALL_ControlMantenimiento
     WHERE  Fecha BETWEEN @FecIni AND @FecFin
       AND  ISNULL(Empresa, '') LIKE @Emp
       AND  ISNULL(Sede, '')    LIKE @Sed
     ORDER  BY Fecha DESC, Id DESC;
END
GO
