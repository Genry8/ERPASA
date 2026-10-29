/* ============================================================================
   Módulo "Ubicación de baños" (TALL_UbicacionBaños).
   Procedimientos usados por CapaDatos\cd_taller.cs

   Sigue el mismo esquema que los de vehículos: alta, edición, baja lógica
   (Estado = 'N') y listado filtrado por empresa y sede.
   ============================================================================ */


IF OBJECT_ID('dbo.SP_GUARDAR_TALL_UBICACION_BANOS', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_TALL_UBICACION_BANOS
GO

CREATE PROCEDURE dbo.SP_GUARDAR_TALL_UBICACION_BANOS
    @Empresa  varchar(80),
    @Sede     varchar(80),
    @Cabezal  varchar(80),
    @Valvula  varchar(80),
    @NroBano  varchar(20),
    @Genero   varchar(1),
    @Obs      varchar(max),
    @Foto     varchar(200),
    @Estado   varchar(1),
    @FecCre   datetime2(7),
    @UseReg   int,
    @Hostname varchar(50),
    @FecEdit  datetime2(7),
    @UseEdit  int,
    @UseElim  int
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.TALL_UbicacionBaños
        (Empresa, Sede, Cabezal, Valvula, NroBano, Genero, Obs, Foto,
         Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit, UseElim)
    VALUES
        (@Empresa, @Sede, @Cabezal, @Valvula, @NroBano, @Genero, @Obs, @Foto,
         @Estado, @FecCre, @UseReg, @Hostname, @FecEdit, @UseEdit, @UseElim);
END
GO


IF OBJECT_ID('dbo.SP_ACTUALIZAR_TALL_UBICACION_BANOS', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ACTUALIZAR_TALL_UBICACION_BANOS
GO

/* FecCre, UseReg y Hostname no se tocan: son del alta. */
CREATE PROCEDURE dbo.SP_ACTUALIZAR_TALL_UBICACION_BANOS
    @Id      int,
    @Empresa varchar(80),
    @Sede    varchar(80),
    @Cabezal varchar(80),
    @Valvula varchar(80),
    @NroBano varchar(20),
    @Genero  varchar(1),
    @Obs     varchar(max),
    @Foto    varchar(200),
    @FecEdit datetime2(7),
    @UseEdit int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.TALL_UbicacionBaños
       SET Empresa = @Empresa,
           Sede    = @Sede,
           Cabezal = @Cabezal,
           Valvula = @Valvula,
           NroBano = @NroBano,
           Genero  = @Genero,
           Obs     = @Obs,
           Foto    = @Foto,
           FecEdit = @FecEdit,
           UseEdit = @UseEdit
     WHERE Id = @Id;
END
GO


IF OBJECT_ID('dbo.SP_ELIMINAR_TALL_UBICACION_BANOS', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ELIMINAR_TALL_UBICACION_BANOS
GO

/* Baja lógica: el registro queda con Estado = 'N' y se guarda quién lo anuló. */
CREATE PROCEDURE dbo.SP_ELIMINAR_TALL_UBICACION_BANOS
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.TALL_UbicacionBaños
       SET Estado  = 'N',
           FecEdit = @FecEdit,
           UseElim = @UseElim
     WHERE Id = @Id;
END
GO


IF OBJECT_ID('dbo.SP_MOSTRAR_TALL_UBICACION_BANOS', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_TALL_UBICACION_BANOS
GO

/* Devuelve activos y anulados: el formulario pinta los anulados en rojo y no
   deja editarlos, igual que en el registro de vehículos.

   El orden de columnas importa: el formulario lee la fila por posición para
   pasarla a la ventana de edición.
     0 Id   1 Empresa   2 Sede   3 Cabezal   4 Valvula
     5 NroBano   6 Genero   7 Obs   8 Foto   9 Estado */
CREATE PROCEDURE dbo.SP_MOSTRAR_TALL_UBICACION_BANOS
    @Emp varchar(80),
    @Sed varchar(80)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  Id,
            Empresa,
            Sede,
            Cabezal,
            Valvula,
            NroBano,
            Genero,
            ISNULL(Obs, '')  AS Obs,
            ISNULL(Foto, '') AS Foto,
            CASE WHEN Estado = 'S' THEN 'ACTIVO' ELSE 'ANULADO' END AS Estado
      FROM  dbo.TALL_UbicacionBaños
     WHERE  Empresa LIKE @Emp
       AND  Sede    LIKE @Sed
     ORDER  BY Empresa, Sede, Cabezal, Valvula, NroBano;
END
GO


IF OBJECT_ID('dbo.SP_CODIGO_TALL_UBICACION_BANOS', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_CODIGO_TALL_UBICACION_BANOS
GO

/* Evita duplicar el mismo baño: misma empresa, sede, cabezal, válvula y
   número. Se ignoran los anulados y, al editar, el propio registro. */
CREATE PROCEDURE dbo.SP_CODIGO_TALL_UBICACION_BANOS
    @Empresa varchar(80),
    @Sede    varchar(80),
    @Cabezal varchar(80),
    @Valvula varchar(80),
    @NroBano varchar(20),
    @Id      int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id
      FROM dbo.TALL_UbicacionBaños
     WHERE Empresa = @Empresa
       AND Sede    = @Sede
       AND Cabezal = @Cabezal
       AND Valvula = @Valvula
       AND NroBano = @NroBano
       AND ISNULL(Estado, 'S') = 'S'
       AND Id <> @Id;
END
GO
