/* ============================================================================
   Módulo "Peso por presentación" (PACK_PesoPresentacion).
   Procedimientos usados por CapaDatos\cd_packing.cs

   Mismo esquema que el resto de los maestros: alta, edición, baja lógica
   (Estado = 'N') y listado filtrado por empresa, sede y cultivo.
   ============================================================================ */


IF OBJECT_ID('dbo.SP_GUARDAR_PACK_PESO_PRESENTACION', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_PACK_PESO_PRESENTACION
GO

CREATE PROCEDURE dbo.SP_GUARDAR_PACK_PESO_PRESENTACION
    @DesEmp        varchar(80),
    @DesSed        varchar(80),
    @Cultivo       varchar(50),
    @Presentacion  varchar(80),
    @Peso          decimal(20,4),
    @PorcentajeMin decimal(20,4),
    @Porcentaje    decimal(20,4),
    @Obs           varchar(1000),
    @Estado        varchar(1),
    @FecCre        datetime2(7),
    @UseReg        int,
    @Hostname      varchar(50),
    @FecEdit       datetime2(7),
    @UseEdit       int,
    @UseElim       int
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.PACK_PesoPresentacion
        (DesEmp, DesSed, Cultivo, Presentacion, Peso, PorcentajeMin, Porcentaje,
         Obs, Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit, UseElim)
    VALUES
        (@DesEmp, @DesSed, @Cultivo, @Presentacion, @Peso, @PorcentajeMin, @Porcentaje,
         @Obs, @Estado, @FecCre, @UseReg, @Hostname, @FecEdit, @UseEdit, @UseElim);
END
GO


IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_PESO_PRESENTACION', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_PESO_PRESENTACION
GO

/* FecCre, UseReg y Hostname no se tocan: son del alta. */
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_PESO_PRESENTACION
    @Id            int,
    @DesEmp        varchar(80),
    @DesSed        varchar(80),
    @Cultivo       varchar(50),
    @Presentacion  varchar(80),
    @Peso          decimal(20,4),
    @PorcentajeMin decimal(20,4),
    @Porcentaje    decimal(20,4),
    @Obs           varchar(1000),
    @FecEdit       datetime2(7),
    @UseEdit       int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.PACK_PesoPresentacion
       SET DesEmp        = @DesEmp,
           DesSed        = @DesSed,
           Cultivo       = @Cultivo,
           Presentacion  = @Presentacion,
           Peso          = @Peso,
           PorcentajeMin = @PorcentajeMin,
           Porcentaje    = @Porcentaje,
           Obs           = @Obs,
           FecEdit       = @FecEdit,
           UseEdit       = @UseEdit
     WHERE Id = @Id;
END
GO


IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_PESO_PRESENTACION', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ELIMINAR_PACK_PESO_PRESENTACION
GO

/* Baja lógica: queda con Estado = 'N' y se registra quién lo anuló. */
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_PESO_PRESENTACION
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.PACK_PesoPresentacion
       SET Estado  = 'N',
           FecEdit = @FecEdit,
           UseElim = @UseElim
     WHERE Id = @Id;
END
GO


IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_PESO_PRESENTACION', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_PACK_PESO_PRESENTACION
GO

/* Devuelve activos y anulados: el formulario pinta los anulados en rojo y no
   deja editarlos.

   El orden de columnas importa: el formulario lee la fila por posición para
   pasarla a la ventana de edición.
     0 Id   1 DesEmp   2 DesSed   3 Cultivo   4 Presentacion
     5 Peso   6 PorcentajeMin   7 Porcentaje   8 Obs   9 Estado */
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_PESO_PRESENTACION
    @Emp     varchar(80),
    @Sed     varchar(80),
    @Cultivo varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  Id,
            DesEmp,
            DesSed,
            Cultivo,
            Presentacion,
            Peso,
            PorcentajeMin,
            Porcentaje,
            ISNULL(Obs, '') AS Obs,
            CASE WHEN Estado = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS Estado
      FROM  dbo.PACK_PesoPresentacion
     WHERE  DesEmp  LIKE @Emp
       AND  DesSed  LIKE @Sed
       AND  Cultivo LIKE @Cultivo
     ORDER  BY DesEmp, DesSed, Cultivo, Presentacion;
END
GO


IF OBJECT_ID('dbo.SP_CODIGO_PACK_PESO_PRESENTACION', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_CODIGO_PACK_PESO_PRESENTACION
GO

/* Evita duplicar la misma presentación para la misma empresa, sede y cultivo.
   Se ignoran los anulados y, al editar, el propio registro. */
CREATE PROCEDURE dbo.SP_CODIGO_PACK_PESO_PRESENTACION
    @DesEmp       varchar(80),
    @DesSed       varchar(80),
    @Cultivo      varchar(50),
    @Presentacion varchar(80),
    @Id           int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id
      FROM dbo.PACK_PesoPresentacion
     WHERE DesEmp       = @DesEmp
       AND DesSed       = @DesSed
       AND Cultivo      = @Cultivo
       AND Presentacion = @Presentacion
       AND ISNULL(Estado, 'S') = 'S'
       AND Id <> @Id;
END
GO
