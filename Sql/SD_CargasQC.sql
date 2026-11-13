/* ============================================================================
   Cargas QC de seleccion y desarrollo:
     - SD_EficienciaQC          (Frm_CargarEficienciaQC)
     - SD_CoberturaProgramadoQC (Frm_CoberturaProgramadoQC)
   Procedimientos usados por CapaDatos\cd_selecdesarrollo.cs

   Cada carga tiene dos procedimientos:

   SP_CONTAR_...     Cuantos registros tiene ya ese año y semana. El formulario
                     lo consulta antes de guardar para avisar que va a reemplazar.

   SP_GUARDAR_REEMPLAZAR_...
                     El formulario sube toda la hoja con SqlBulkCopy a una tabla
                     temporal (#EficienciaQC / #CoberturaProgramadoQC) y llama a
                     este procedimiento. Los dos pasos van sobre la MISMA conexion:
                     la temporal solo existe mientras esa conexion siga abierta.
                     Borra de la tabla real lo que ya hubiera de ese año y semana
                     e inserta la hoja completa, todo dentro de una transaccion:
                     si el INSERT falla, el DELETE se deshace y la semana conserva
                     lo que tenia.

   El borrado es fisico, no una baja logica (Estado = 'N'): lo mismo que se hace
   con la carga de Netzun. Si prefiere que lo anterior quede marcado en vez de
   borrado, se cambia el DELETE por un UPDATE de Estado.
   ============================================================================ */


/* ------------------------------------------------------------- EFICIENCIA QC */

IF OBJECT_ID('dbo.SP_CONTAR_SD_EFICIENCIAQC', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_CONTAR_SD_EFICIENCIAQC
GO

CREATE PROCEDURE dbo.SP_CONTAR_SD_EFICIENCIAQC
    @Anio   varchar(80),
    @Semana int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS Cantidad
      FROM dbo.SD_EficienciaQC
     WHERE [Año]  = @Anio
       AND Semana = @Semana;
END
GO


IF OBJECT_ID('dbo.SP_GUARDAR_REEMPLAZAR_SD_EFICIENCIAQC', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_REEMPLAZAR_SD_EFICIENCIAQC
GO

CREATE PROCEDURE dbo.SP_GUARDAR_REEMPLAZAR_SD_EFICIENCIAQC
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    /* Si no llego nada util no se borra nada: evita vaciar una semana por una
       carga en blanco. */
    IF NOT EXISTS (SELECT 1 FROM #EficienciaQC WHERE [Año] IS NOT NULL AND Semana IS NOT NULL)
        RETURN;

    BEGIN TRANSACTION;

        /* Fuera lo que ya hubiera de los años y semanas que trae el archivo.
           Normalmente es uno solo: el que se eligio en el formulario. */
        DELETE d
          FROM dbo.SD_EficienciaQC AS d
         WHERE EXISTS (SELECT 1
                         FROM #EficienciaQC AS t
                        WHERE t.[Año]  = d.[Año]
                          AND t.Semana = d.Semana);

        /* Y entra la hoja completa. */
        INSERT INTO dbo.SD_EficienciaQC
            (IdReq, Semana, [Año], Posicion, Sede, Planta, EstadoProceso,
             SemProy, FechaProy, SemAjuste, FechaReq, TiempoProceso, TipoPersonal,
             FechaTerna, FechaRpta, Dias, FechaEntrevista,
             FechaCierreProc, FechaIng, DiasDuracion, Vencimiento,
             Inspector, Incidencia, Obs, Hoja, Estado,
             FecCre, UseReg, Hostname, FecEdit, UseEdit)
        SELECT
             t.IdReq, t.Semana, t.[Año], t.Posicion, t.Sede, t.Planta, t.EstadoProceso,
             t.SemProy, t.FechaProy, t.SemAjuste, t.FechaReq, t.TiempoProceso, t.TipoPersonal,
             t.FechaTerna, t.FechaRpta, t.Dias, t.FechaEntrevista,
             t.FechaCierreProc, t.FechaIng, t.DiasDuracion, t.Vencimiento,
             LTRIM(t.Inspector),            -- la hoja trae espacios al inicio
             t.Incidencia, t.Obs, t.Hoja, t.Estado,
             t.FecCre, t.UseReg, t.Hostname, t.FecEdit, t.UseEdit
          FROM #EficienciaQC AS t
         WHERE t.[Año] IS NOT NULL
           AND t.Semana IS NOT NULL;

    COMMIT TRANSACTION;
END
GO


/* ------------------------------------------------- COBERTURA PROGRAMADO QC */

IF OBJECT_ID('dbo.SP_CONTAR_SD_COBERTURAPROGRAMADOQC', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_CONTAR_SD_COBERTURAPROGRAMADOQC
GO

CREATE PROCEDURE dbo.SP_CONTAR_SD_COBERTURAPROGRAMADOQC
    @Anio   varchar(80),
    @Semana int
AS
BEGIN
    SET NOCOUNT ON;

    SELECT COUNT(*) AS Cantidad
      FROM dbo.SD_CoberturaProgramadoQC
     WHERE [Año]  = @Anio
       AND Semana = @Semana;
END
GO


IF OBJECT_ID('dbo.SP_GUARDAR_REEMPLAZAR_SD_COBERTURAPROGRAMADOQC', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_REEMPLAZAR_SD_COBERTURAPROGRAMADOQC
GO

CREATE PROCEDURE dbo.SP_GUARDAR_REEMPLAZAR_SD_COBERTURAPROGRAMADOQC
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM #CoberturaProgramadoQC WHERE [Año] IS NOT NULL AND Semana IS NOT NULL)
        RETURN;

    BEGIN TRANSACTION;

        DELETE d
          FROM dbo.SD_CoberturaProgramadoQC AS d
         WHERE EXISTS (SELECT 1
                         FROM #CoberturaProgramadoQC AS t
                        WHERE t.[Año]  = d.[Año]
                          AND t.Semana = d.Semana);

        INSERT INTO dbo.SD_CoberturaProgramadoQC
            (Empresa, Sede, [Año], Semana, Zona, Planta, Fecha, CantProy,
             CantProyAjust, Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit)
        SELECT
             t.Empresa, t.Sede, t.[Año], t.Semana, t.Zona, t.Planta, t.Fecha, t.CantProy,
             t.CantProyAjust, t.Estado, t.FecCre, t.UseReg, t.Hostname, t.FecEdit, t.UseEdit
          FROM #CoberturaProgramadoQC AS t
         WHERE t.[Año] IS NOT NULL
           AND t.Semana IS NOT NULL;

    COMMIT TRANSACTION;
END
GO
