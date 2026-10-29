/* ============================================================================
   Reporte de visitas (PV_Visitas).
   Procedimiento usado por CapaDatos\cd_rrhh.cs

   Mismo esquema que SP_MOSTRAR_LISTA_CONTROL_MANTENIMIENTO: rango de fechas,
   empresa y sede, y Estado como texto para que el formulario pinte en rojo
   los eliminados.
   ============================================================================ */

IF OBJECT_ID('dbo.SP_MOSTRAR_LISTA_VISITAS_PV', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_LISTA_VISITAS_PV
GO

/* Los campos bit se devuelven como SI / NO para que el reporte y el Excel se
   lean igual que en pantalla. */
CREATE PROCEDURE dbo.SP_MOSTRAR_LISTA_VISITAS_PV
    @FecIni date,
    @FecFin date,
    @Emp    varchar(80),
    @Sed    varchar(80)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  IdVist,
            ISNULL(CodVist, '')  AS CodVist,
            Item,
            ISNULL(DesEmp, '')   AS DesEmp,
            ISNULL(DesSed, '')   AS DesSed,
            ISNULL(DesArea, '')  AS DesArea,
            FecVisita,
            ISNULL(Hr_Ing, '')   AS Hr_Ing,
            ISNULL(Hr_Sal, '')   AS Hr_Sal,
            ISNULL(DesTDoc, '')      AS DesTDoc,
            ISNULL(Num_Ident, '')    AS Num_Ident,
            ISNULL(Ape, '')          AS Ape,
            ISNULL(Sexo, '')         AS Sexo,
            ISNULL(Nacionalidad, '') AS Nacionalidad,
            ISNULL(Compañia, '')       AS Compañia,
            ISNULL(Motivo_Visita, '')  AS Motivo_Visita,
            ISNULL(DesTVist, '')       AS DesTVist,
            ISNULL(DesFtsh, '')        AS DesFtsh,
            ISNULL(NumGuia, '')  AS NumGuia,
            ISNULL(Licencia, '') AS Licencia,
            ISNULL(TipVehi, '')  AS TipVehi,
            ISNULL(Placa, '')    AS Placa,
            ISNULL(Placa2, '')   AS Placa2,
            CASE WHEN FtshEnt         = 1 THEN 'SI' ELSE 'NO' END AS FtshEnt,
            CASE WHEN FtshDev         = 1 THEN 'SI' ELSE 'NO' END AS FtshDev,
            CASE WHEN HombreNuevo     = 1 THEN 'SI' ELSE 'NO' END AS HombreNuevo,
            CASE WHEN TrabajoAltura   = 1 THEN 'SI' ELSE 'NO' END AS TrabajoAltura,
            CASE WHEN TrabajoCaliente = 1 THEN 'SI' ELSE 'NO' END AS TrabajoCaliente,
            CASE WHEN ZanjaExcavacion = 1 THEN 'SI' ELSE 'NO' END AS ZanjaExcavacion,
            CASE WHEN Ritran          = 1 THEN 'SI' ELSE 'NO' END AS Ritran,
            ISNULL(FirmaVisita, '')    AS FirmaVisita,
            ISNULL(FirmSell_Resp, '')  AS FirmSell_Resp,
            CASE WHEN ISNULL(Estado, 'S') = 'S' THEN 'ACTIVO' ELSE 'ELIMINADO' END AS Estado,
            FecCre,
            UseReg,
            ISNULL(Hostname, '') AS Hostname
      FROM  dbo.PV_Visitas
     WHERE  FecVisita BETWEEN @FecIni AND @FecFin
       AND  ISNULL(DesEmp, '') LIKE @Emp
       AND  ISNULL(DesSed, '') LIKE @Sed
     ORDER  BY FecVisita DESC, IdVist DESC;
END
GO
