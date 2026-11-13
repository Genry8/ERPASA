/* ============================================================================
   Maestro IDENTIFICADOR (PACK_Identificador).
   Procedimientos usados por CapaDatos\cd_packing.cs

   Mismo esquema que los demas maestros de packing: alta, edicion, baja
   logica (Estado = 'N') y listado de activos y anulados.
   ============================================================================ */


IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_IDENTIFICADOR', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_PACK_IDENTIFICADOR
GO

/* Devuelve activos y anulados: el formulario pinta los anulados en rojo y no
   deja editarlos.

   El orden de columnas importa: el formulario lee la fila por posicion para
   pasarla a la ventana de edicion.
     0 Id   1 Identificador   2 Cultivo   3 Obs   4 EstadoReg */
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_IDENTIFICADOR
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  Id,
            ISNULL(Identificador, '') AS Identificador,
            ISNULL(Cultivo, '')       AS Cultivo,
            ISNULL(Obs, '')           AS Obs,
            CASE WHEN ISNULL(Estado, 'S') = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM  dbo.PACK_Identificador
     ORDER  BY Cultivo, Identificador;
END
GO


IF OBJECT_ID('dbo.SP_GUARDAR_PACK_IDENTIFICADOR', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_PACK_IDENTIFICADOR
GO

CREATE PROCEDURE dbo.SP_GUARDAR_PACK_IDENTIFICADOR
    @Identificador varchar(50),
    @Cultivo       varchar(50),
    @Obs           varchar(1000),
    @FecCre        datetime2(7),
    @UseReg        int,
    @Hostname      varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.PACK_Identificador
        (Identificador, Cultivo, Obs, Estado, FecCre, UseReg, Hostname)
    VALUES
        (@Identificador, @Cultivo, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO


IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_IDENTIFICADOR', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_IDENTIFICADOR
GO

/* FecCre, UseReg y Hostname no se tocan: son del alta. */
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_IDENTIFICADOR
    @Id            int,
    @Identificador varchar(50),
    @Cultivo       varchar(50),
    @Obs           varchar(1000),
    @FecEdit       datetime2(7),
    @UseEdit       int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.PACK_Identificador
       SET Identificador = @Identificador,
           Cultivo       = @Cultivo,
           Obs           = @Obs,
           FecEdit       = @FecEdit,
           UseEdit       = @UseEdit
     WHERE Id = @Id;
END
GO


IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_IDENTIFICADOR', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ELIMINAR_PACK_IDENTIFICADOR
GO

/* Baja logica: queda con Estado = 'N' y se registra quien lo anulo. */
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_IDENTIFICADOR
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.PACK_Identificador
       SET Estado  = 'N',
           FecEdit = @FecEdit,
           UseElim = @UseElim
     WHERE Id = @Id;
END
GO


IF OBJECT_ID('dbo.SP_CODIGO_PACK_IDENTIFICADOR', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_CODIGO_PACK_IDENTIFICADOR
GO

/* Evita repetir el mismo identificador dentro del mismo cultivo. Se ignoran
   los anulados y, al editar, el propio registro. */
CREATE PROCEDURE dbo.SP_CODIGO_PACK_IDENTIFICADOR
    @Identificador varchar(50),
    @Cultivo       varchar(50),
    @Id            int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id
      FROM dbo.PACK_Identificador
     WHERE Identificador = @Identificador
       AND Cultivo       = @Cultivo
       AND ISNULL(Estado, 'S') = 'S'
       AND Id <> @Id;
END
GO
