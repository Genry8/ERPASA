/* ============================================================================
   Procedimientos de los maestros de packing (tablas PACK_*).

   GENERADO desde el catalogo de CapaEntidad\ce_maestropacking.cs. Si agrega o
   cambia un maestro ahi, vuelva a generar este archivo en vez de editarlo a
   mano: los nombres y los parametros tienen que coincidir con lo que envia
   CapaDatos\cd_packing.cs.

   Por cada tabla se crean cinco:
     SP_MOSTRAR_<TABLA>      listado completo, con EstadoReg = ACTIVO/ANULADO
     SP_GUARDAR_<TABLA>      alta
     SP_ACTUALIZAR_<TABLA>   edicion
     SP_ELIMINAR_<TABLA>     baja logica
     SP_CODIGO_<TABLA>       verificacion de duplicados por la clave
   ============================================================================ */

/* -------------------------------------------------------------- PACK_Cultivo */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CULTIVO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CULTIVO
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CULTIVO
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Cultivo], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Cultivo]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CULTIVO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CULTIVO
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CULTIVO
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Cultivo] ([Cultivo], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Cultivo, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CULTIVO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CULTIVO
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CULTIVO
    @Id int,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Cultivo]
       SET
           [Cultivo] = @Cultivo,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CULTIVO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CULTIVO
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CULTIVO
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Cultivo]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CULTIVO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CULTIVO
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CULTIVO
    @Cultivo varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Cultivo]
     WHERE [Cultivo] = @Cultivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Campana */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CAMPANA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CAMPANA
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CAMPANA
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Campana], [Descripcion], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Campana]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CAMPANA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CAMPANA
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CAMPANA
    @Campana varchar(80) = NULL,
    @Descripcion varchar(280) = NULL,
    @Obs varchar(400) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Campana] ([Campana], [Descripcion], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Campana, @Descripcion, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CAMPANA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMPANA
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMPANA
    @Id int,
    @Campana varchar(80) = NULL,
    @Descripcion varchar(280) = NULL,
    @Obs varchar(400) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Campana]
       SET
           [Campana] = @Campana,
           [Descripcion] = @Descripcion,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CAMPANA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CAMPANA
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CAMPANA
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Campana]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CAMPANA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CAMPANA
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CAMPANA
    @Campana varchar(80) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Campana]
     WHERE [Campana] = @Campana
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Categoria */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CATEGORIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CATEGORIA
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CATEGORIA
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Categoria], [Cultivo], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Categoria]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CATEGORIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CATEGORIA
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CATEGORIA
    @Categoria varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Categoria] ([Categoria], [Cultivo], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Categoria, @Cultivo, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CATEGORIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CATEGORIA
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CATEGORIA
    @Id int,
    @Categoria varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Categoria]
       SET
           [Categoria] = @Categoria,
           [Cultivo] = @Cultivo,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CATEGORIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CATEGORIA
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CATEGORIA
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Categoria]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CATEGORIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CATEGORIA
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CATEGORIA
    @Categoria varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Categoria]
     WHERE [Categoria] = @Categoria
       AND [Cultivo] = @Cultivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Calibre */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CALIBRE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CALIBRE
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CALIBRE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [CodCalibre], [Calibre], [Cultivo], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Calibre]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CALIBRE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CALIBRE
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CALIBRE
    @CodCalibre varchar(50) = NULL,
    @Calibre varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Calibre] ([CodCalibre], [Calibre], [Cultivo], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@CodCalibre, @Calibre, @Cultivo, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CALIBRE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CALIBRE
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CALIBRE
    @Id int,
    @CodCalibre varchar(50) = NULL,
    @Calibre varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Calibre]
       SET
           [CodCalibre] = @CodCalibre,
           [Calibre] = @Calibre,
           [Cultivo] = @Cultivo,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CALIBRE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CALIBRE
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CALIBRE
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Calibre]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CALIBRE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CALIBRE
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CALIBRE
    @Calibre varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Calibre]
     WHERE [Calibre] = @Calibre
       AND [Cultivo] = @Cultivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Cabezal */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CABEZAL', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CABEZAL
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CABEZAL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Cabezal], [Cultivo], [Sede], [NCorto], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Cabezal]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CABEZAL', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CABEZAL
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CABEZAL
    @Cabezal varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @NCorto varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Cabezal] ([Cabezal], [Cultivo], [Sede], [NCorto], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Cabezal, @Cultivo, @Sede, @NCorto, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CABEZAL', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CABEZAL
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CABEZAL
    @Id int,
    @Cabezal varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @NCorto varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Cabezal]
       SET
           [Cabezal] = @Cabezal,
           [Cultivo] = @Cultivo,
           [Sede] = @Sede,
           [NCorto] = @NCorto,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CABEZAL', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CABEZAL
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CABEZAL
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Cabezal]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CABEZAL', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CABEZAL
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CABEZAL
    @Cabezal varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Cabezal]
     WHERE [Cabezal] = @Cabezal
       AND [Cultivo] = @Cultivo
       AND [Sede] = @Sede
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_CabezalPT */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CABEZALPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CABEZALPT
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CABEZALPT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [CodCab], [Cabezal], [Cultivo], [Sede], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_CabezalPT]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CABEZALPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CABEZALPT
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CABEZALPT
    @CodCab varchar(50) = NULL,
    @Cabezal varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @Obs varchar(50) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_CabezalPT] ([CodCab], [Cabezal], [Cultivo], [Sede], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@CodCab, @Cabezal, @Cultivo, @Sede, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CABEZALPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CABEZALPT
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CABEZALPT
    @Id int,
    @CodCab varchar(50) = NULL,
    @Cabezal varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @Obs varchar(50) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_CabezalPT]
       SET
           [CodCab] = @CodCab,
           [Cabezal] = @Cabezal,
           [Cultivo] = @Cultivo,
           [Sede] = @Sede,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CABEZALPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CABEZALPT
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CABEZALPT
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_CabezalPT]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CABEZALPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CABEZALPT
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CABEZALPT
    @Cabezal varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_CabezalPT]
     WHERE [Cabezal] = @Cabezal
       AND [Cultivo] = @Cultivo
       AND [Sede] = @Sede
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Camara */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CAMARA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CAMARA
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CAMARA
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Camara], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Camara]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CAMARA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CAMARA
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CAMARA
    @Camara varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Camara] ([Camara], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Camara, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CAMARA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMARA
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMARA
    @Id int,
    @Camara varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Camara]
       SET
           [Camara] = @Camara,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CAMARA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CAMARA
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CAMARA
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Camara]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CAMARA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CAMARA
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CAMARA
    @Camara varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Camara]
     WHERE [Camara] = @Camara
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_CamaraFrio */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CAMARAFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CAMARAFRIO
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CAMARAFRIO
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [CamaraFrio], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_CamaraFrio]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CAMARAFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CAMARAFRIO
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CAMARAFRIO
    @CamaraFrio varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_CamaraFrio] ([CamaraFrio], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@CamaraFrio, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CAMARAFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMARAFRIO
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMARAFRIO
    @Id int,
    @CamaraFrio varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_CamaraFrio]
       SET
           [CamaraFrio] = @CamaraFrio,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CAMARAFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CAMARAFRIO
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CAMARAFRIO
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_CamaraFrio]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CAMARAFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CAMARAFRIO
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CAMARAFRIO
    @CamaraFrio varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_CamaraFrio]
     WHERE [CamaraFrio] = @CamaraFrio
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_CamaraPreFrio */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CAMARAPREFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CAMARAPREFRIO
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CAMARAPREFRIO
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [CamaraPreFrio], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_CamaraPreFrio]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CAMARAPREFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CAMARAPREFRIO
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CAMARAPREFRIO
    @CamaraPreFrio varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_CamaraPreFrio] ([CamaraPreFrio], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@CamaraPreFrio, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CAMARAPREFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMARAPREFRIO
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMARAPREFRIO
    @Id int,
    @CamaraPreFrio varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_CamaraPreFrio]
       SET
           [CamaraPreFrio] = @CamaraPreFrio,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CAMARAPREFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CAMARAPREFRIO
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CAMARAPREFRIO
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_CamaraPreFrio]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CAMARAPREFRIO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CAMARAPREFRIO
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CAMARAPREFRIO
    @CamaraPreFrio varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_CamaraPreFrio]
     WHERE [CamaraPreFrio] = @CamaraPreFrio
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_CamaraGasificado */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_CAMARAGASIFICADO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_CAMARAGASIFICADO
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_CAMARAGASIFICADO
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [CamaraGasificado], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_CamaraGasificado]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_CAMARAGASIFICADO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_CAMARAGASIFICADO
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_CAMARAGASIFICADO
    @CamaraGasificado varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_CamaraGasificado] ([CamaraGasificado], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@CamaraGasificado, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_CAMARAGASIFICADO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMARAGASIFICADO
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_CAMARAGASIFICADO
    @Id int,
    @CamaraGasificado varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_CamaraGasificado]
       SET
           [CamaraGasificado] = @CamaraGasificado,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_CAMARAGASIFICADO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_CAMARAGASIFICADO
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_CAMARAGASIFICADO
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_CamaraGasificado]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_CAMARAGASIFICADO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_CAMARAGASIFICADO
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_CAMARAGASIFICADO
    @CamaraGasificado varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_CamaraGasificado]
     WHERE [CamaraGasificado] = @CamaraGasificado
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Maquinaria */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_MAQUINARIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_MAQUINARIA
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_MAQUINARIA
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Maquina], [Cultivo], [MaqCorto], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Maquinaria]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_MAQUINARIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_MAQUINARIA
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_MAQUINARIA
    @Maquina varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @MaqCorto varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Maquinaria] ([Maquina], [Cultivo], [MaqCorto], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Maquina, @Cultivo, @MaqCorto, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_MAQUINARIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_MAQUINARIA
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_MAQUINARIA
    @Id int,
    @Maquina varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @MaqCorto varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Maquinaria]
       SET
           [Maquina] = @Maquina,
           [Cultivo] = @Cultivo,
           [MaqCorto] = @MaqCorto,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_MAQUINARIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_MAQUINARIA
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_MAQUINARIA
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Maquinaria]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_MAQUINARIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_MAQUINARIA
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_MAQUINARIA
    @Maquina varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Maquinaria]
     WHERE [Maquina] = @Maquina
       AND [Cultivo] = @Cultivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_FilerMaquina */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_FILERMAQUINA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_FILERMAQUINA
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_FILERMAQUINA
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Maquina], [Filer], [Cultivo], [Ord], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_FilerMaquina]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_FILERMAQUINA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_FILERMAQUINA
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_FILERMAQUINA
    @Maquina varchar(50) = NULL,
    @Filer varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Ord int = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_FilerMaquina] ([Maquina], [Filer], [Cultivo], [Ord], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Maquina, @Filer, @Cultivo, @Ord, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_FILERMAQUINA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_FILERMAQUINA
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_FILERMAQUINA
    @Id int,
    @Maquina varchar(50) = NULL,
    @Filer varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Ord int = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_FilerMaquina]
       SET
           [Maquina] = @Maquina,
           [Filer] = @Filer,
           [Cultivo] = @Cultivo,
           [Ord] = @Ord,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_FILERMAQUINA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_FILERMAQUINA
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_FILERMAQUINA
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_FilerMaquina]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_FILERMAQUINA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_FILERMAQUINA
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_FILERMAQUINA
    @Maquina varchar(50) = NULL,
    @Filer varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_FilerMaquina]
     WHERE [Maquina] = @Maquina
       AND [Filer] = @Filer
       AND [Cultivo] = @Cultivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Estilos */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_ESTILOS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_ESTILOS
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_ESTILOS
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Style], [Presentacion], [Cultivo], [Sede], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Estilos]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_ESTILOS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_ESTILOS
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_ESTILOS
    @Style varchar(50) = NULL,
    @Presentacion varchar(180) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Estilos] ([Style], [Presentacion], [Cultivo], [Sede], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Style, @Presentacion, @Cultivo, @Sede, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_ESTILOS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_ESTILOS
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_ESTILOS
    @Id int,
    @Style varchar(50) = NULL,
    @Presentacion varchar(180) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Estilos]
       SET
           [Style] = @Style,
           [Presentacion] = @Presentacion,
           [Cultivo] = @Cultivo,
           [Sede] = @Sede,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_ESTILOS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_ESTILOS
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_ESTILOS
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Estilos]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_ESTILOS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_ESTILOS
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_ESTILOS
    @Style varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Sede varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Estilos]
     WHERE [Style] = @Style
       AND [Cultivo] = @Cultivo
       AND [Sede] = @Sede
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_EmpaqueProceso */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_EMPAQUEPROCESO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_EMPAQUEPROCESO
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_EMPAQUEPROCESO
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Empaque_Proceso], [Empresa], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_EmpaqueProceso]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_EMPAQUEPROCESO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_EMPAQUEPROCESO
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_EMPAQUEPROCESO
    @Empaque_Proceso varchar(50) = NULL,
    @Empresa varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_EmpaqueProceso] ([Empaque_Proceso], [Empresa], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Empaque_Proceso, @Empresa, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_EMPAQUEPROCESO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_EMPAQUEPROCESO
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_EMPAQUEPROCESO
    @Id int,
    @Empaque_Proceso varchar(50) = NULL,
    @Empresa varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_EmpaqueProceso]
       SET
           [Empaque_Proceso] = @Empaque_Proceso,
           [Empresa] = @Empresa,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_EMPAQUEPROCESO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_EMPAQUEPROCESO
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_EMPAQUEPROCESO
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_EmpaqueProceso]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_EMPAQUEPROCESO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_EMPAQUEPROCESO
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_EMPAQUEPROCESO
    @Empaque_Proceso varchar(50) = NULL,
    @Empresa varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_EmpaqueProceso]
     WHERE [Empaque_Proceso] = @Empaque_Proceso
       AND [Empresa] = @Empresa
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_TipoParihuela */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_TIPOPARIHUELA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOPARIHUELA
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOPARIHUELA
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Parihuela], [Cultivo], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_TipoParihuela]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_TIPOPARIHUELA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_TIPOPARIHUELA
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_TIPOPARIHUELA
    @Parihuela varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_TipoParihuela] ([Parihuela], [Cultivo], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Parihuela, @Cultivo, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_TIPOPARIHUELA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOPARIHUELA
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOPARIHUELA
    @Id int,
    @Parihuela varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoParihuela]
       SET
           [Parihuela] = @Parihuela,
           [Cultivo] = @Cultivo,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_TIPOPARIHUELA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOPARIHUELA
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOPARIHUELA
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoParihuela]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_TIPOPARIHUELA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_TIPOPARIHUELA
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_TIPOPARIHUELA
    @Parihuela varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_TipoParihuela]
     WHERE [Parihuela] = @Parihuela
       AND [Cultivo] = @Cultivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_TipoPaLlet */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_TIPOPALLET', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOPALLET
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOPALLET
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [TipoPalet], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_TipoPaLlet]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_TIPOPALLET', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_TIPOPALLET
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_TIPOPALLET
    @TipoPalet varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_TipoPaLlet] ([TipoPalet], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@TipoPalet, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_TIPOPALLET', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOPALLET
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOPALLET
    @Id int,
    @TipoPalet varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoPaLlet]
       SET
           [TipoPalet] = @TipoPalet,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_TIPOPALLET', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOPALLET
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOPALLET
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoPaLlet]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_TIPOPALLET', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_TIPOPALLET
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_TIPOPALLET
    @TipoPalet varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_TipoPaLlet]
     WHERE [TipoPalet] = @TipoPalet
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_TipoMateria */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_TIPOMATERIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOMATERIA
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOMATERIA
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [TipoMateria], [GrupoMateria], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_TipoMateria]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_TIPOMATERIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_TIPOMATERIA
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_TIPOMATERIA
    @TipoMateria varchar(50) = NULL,
    @GrupoMateria varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_TipoMateria] ([TipoMateria], [GrupoMateria], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@TipoMateria, @GrupoMateria, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_TIPOMATERIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOMATERIA
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOMATERIA
    @Id int,
    @TipoMateria varchar(50) = NULL,
    @GrupoMateria varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoMateria]
       SET
           [TipoMateria] = @TipoMateria,
           [GrupoMateria] = @GrupoMateria,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_TIPOMATERIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOMATERIA
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOMATERIA
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoMateria]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_TIPOMATERIA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_TIPOMATERIA
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_TIPOMATERIA
    @TipoMateria varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_TipoMateria]
     WHERE [TipoMateria] = @TipoMateria
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_TipoCosecha */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_TIPOCOSECHA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOCOSECHA
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOCOSECHA
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [TipoCosecha], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_TipoCosecha]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_TIPOCOSECHA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_TIPOCOSECHA
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_TIPOCOSECHA
    @TipoCosecha varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_TipoCosecha] ([TipoCosecha], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@TipoCosecha, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_TIPOCOSECHA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOCOSECHA
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOCOSECHA
    @Id int,
    @TipoCosecha varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoCosecha]
       SET
           [TipoCosecha] = @TipoCosecha,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_TIPOCOSECHA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOCOSECHA
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOCOSECHA
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoCosecha]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_TIPOCOSECHA', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_TIPOCOSECHA
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_TIPOCOSECHA
    @TipoCosecha varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_TipoCosecha]
     WHERE [TipoCosecha] = @TipoCosecha
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_TipoDefecto */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_TIPODEFECTO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_TIPODEFECTO
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_TIPODEFECTO
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [TipoDefecto], [Cultivo], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_TipoDefecto]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_TIPODEFECTO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_TIPODEFECTO
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_TIPODEFECTO
    @TipoDefecto varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_TipoDefecto] ([TipoDefecto], [Cultivo], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@TipoDefecto, @Cultivo, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_TIPODEFECTO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPODEFECTO
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPODEFECTO
    @Id int,
    @TipoDefecto varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoDefecto]
       SET
           [TipoDefecto] = @TipoDefecto,
           [Cultivo] = @Cultivo,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_TIPODEFECTO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_TIPODEFECTO
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_TIPODEFECTO
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoDefecto]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_TIPODEFECTO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_TIPODEFECTO
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_TIPODEFECTO
    @TipoDefecto varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_TipoDefecto]
     WHERE [TipoDefecto] = @TipoDefecto
       AND [Cultivo] = @Cultivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_TipoCausaError */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_TIPOCAUSAERROR', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOCAUSAERROR
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_TIPOCAUSAERROR
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [CausaError], [Cultivo], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_TipoCausaError]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_TIPOCAUSAERROR', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_TIPOCAUSAERROR
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_TIPOCAUSAERROR
    @CausaError varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_TipoCausaError] ([CausaError], [Cultivo], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@CausaError, @Cultivo, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_TIPOCAUSAERROR', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOCAUSAERROR
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_TIPOCAUSAERROR
    @Id int,
    @CausaError varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoCausaError]
       SET
           [CausaError] = @CausaError,
           [Cultivo] = @Cultivo,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_TIPOCAUSAERROR', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOCAUSAERROR
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_TIPOCAUSAERROR
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_TipoCausaError]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_TIPOCAUSAERROR', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_TIPOCAUSAERROR
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_TIPOCAUSAERROR
    @CausaError varchar(50) = NULL,
    @Cultivo varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_TipoCausaError]
     WHERE [CausaError] = @CausaError
       AND [Cultivo] = @Cultivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_MotivoParadas */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_MOTIVOPARADAS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_MOTIVOPARADAS
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_MOTIVOPARADAS
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [CodGrup], [Grupo], [Motivo], [Cultivo], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_MotivoParadas]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_MOTIVOPARADAS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_MOTIVOPARADAS
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_MOTIVOPARADAS
    @CodGrup varchar(80) = NULL,
    @Grupo varchar(280) = NULL,
    @Motivo varchar(4000) = NULL,
    @Cultivo varchar(4000) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_MotivoParadas] ([CodGrup], [Grupo], [Motivo], [Cultivo], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@CodGrup, @Grupo, @Motivo, @Cultivo, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_MOTIVOPARADAS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_MOTIVOPARADAS
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_MOTIVOPARADAS
    @Id int,
    @CodGrup varchar(80) = NULL,
    @Grupo varchar(280) = NULL,
    @Motivo varchar(4000) = NULL,
    @Cultivo varchar(4000) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_MotivoParadas]
       SET
           [CodGrup] = @CodGrup,
           [Grupo] = @Grupo,
           [Motivo] = @Motivo,
           [Cultivo] = @Cultivo,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_MOTIVOPARADAS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_MOTIVOPARADAS
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_MOTIVOPARADAS
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_MotivoParadas]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_MOTIVOPARADAS', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_MOTIVOPARADAS
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_MOTIVOPARADAS
    @Motivo varchar(4000) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_MotivoParadas]
     WHERE [Motivo] = @Motivo
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Turno */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_TURNO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_TURNO
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_TURNO
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Turno], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Turno]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_TURNO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_TURNO
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_TURNO
    @Turno varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Turno] ([Turno], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Turno, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_TURNO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_TURNO
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_TURNO
    @Id int,
    @Turno varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Turno]
       SET
           [Turno] = @Turno,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_TURNO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_TURNO
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_TURNO
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Turno]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_TURNO', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_TURNO
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_TURNO
    @Turno varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Turno]
     WHERE [Turno] = @Turno
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_Transporte */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_TRANSPORTE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_TRANSPORTE
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_TRANSPORTE
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Transporte], [Obs],
           CASE WHEN [Estado] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_Transporte]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_TRANSPORTE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_TRANSPORTE
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_TRANSPORTE
    @Transporte varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_Transporte] ([Transporte], [Obs], [Estado], FecCre, UseReg, Hostname)
    VALUES (@Transporte, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_TRANSPORTE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_TRANSPORTE
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_TRANSPORTE
    @Id int,
    @Transporte varchar(50) = NULL,
    @Obs varchar(1000) = NULL,
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Transporte]
       SET
           [Transporte] = @Transporte,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_TRANSPORTE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_TRANSPORTE
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_TRANSPORTE
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_Transporte]
       SET [Estado] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_TRANSPORTE', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_TRANSPORTE
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_TRANSPORTE
    @Transporte varchar(50) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_Transporte]
     WHERE [Transporte] = @Transporte
       AND ISNULL([Estado], 'S') = 'S'
       AND Id <> @Id;
END
GO

/* -------------------------------------------------------------- PACK_EstadoPT */
IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_ESTADOPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_MOSTRAR_PACK_ESTADOPT
GO
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_ESTADOPT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, [Cod], [Estado], [Obs],
           CASE WHEN [Activo] = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS EstadoReg
      FROM dbo.[PACK_EstadoPT]
     ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.SP_GUARDAR_PACK_ESTADOPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_GUARDAR_PACK_ESTADOPT
GO
CREATE PROCEDURE dbo.SP_GUARDAR_PACK_ESTADOPT
    @Cod varchar(20) = NULL,
    @Estado varchar(50) = NULL,
    @Obs varchar(250) = NULL,
    @FecCre   datetime2(7),
    @UseReg   varchar(50),
    @Hostname varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.[PACK_EstadoPT] ([Cod], [Estado], [Obs], [Activo], FecCre, UseReg, Hostname)
    VALUES (@Cod, @Estado, @Obs, 'S', @FecCre, @UseReg, @Hostname);
END
GO

IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_ESTADOPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_ESTADOPT
GO
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_ESTADOPT
    @Id int,
    @Cod varchar(20) = NULL,
    @Estado varchar(50) = NULL,
    @Obs varchar(250) = NULL,
    @FecEdit datetime2(7),
    @UseEdit varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_EstadoPT]
       SET
           [Cod] = @Cod,
           [Estado] = @Estado,
           [Obs] = @Obs,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_ESTADOPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_ELIMINAR_PACK_ESTADOPT
GO
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_ESTADOPT
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.[PACK_EstadoPT]
       SET [Activo] = 'N',
           FecEdit      = @FecEdit,
           UseElim      = @UseElim
     WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.SP_CODIGO_PACK_ESTADOPT', 'P') IS NOT NULL DROP PROCEDURE dbo.SP_CODIGO_PACK_ESTADOPT
GO
CREATE PROCEDURE dbo.SP_CODIGO_PACK_ESTADOPT
    @Cod varchar(20) = NULL,
    @Id int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 1 Id
      FROM dbo.[PACK_EstadoPT]
     WHERE [Cod] = @Cod
       AND ISNULL([Activo], 'S') = 'S'
       AND Id <> @Id;
END
GO

