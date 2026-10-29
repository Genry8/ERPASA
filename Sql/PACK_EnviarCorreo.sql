/* ============================================================================
   Módulo "Configurar correo" (PACK_EnviarCorreo).
   Procedimientos usados por CapaDatos\cd_packing.cs

   La tabla no tiene columna Estado: la baja es lógica y se marca llenando
   UseElim. El listado devuelve una columna Estado calculada a partir de eso,
   igual que el resto de los maestros, para que el formulario pinte en rojo
   los anulados y no deje editarlos.
   ============================================================================ */


IF OBJECT_ID('dbo.SP_GUARDAR_PACK_ENVIAR_CORREO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_PACK_ENVIAR_CORREO
GO

CREATE PROCEDURE dbo.SP_GUARDAR_PACK_ENVIAR_CORREO
    @Fecha       datetime2(7),
    @DesEmp      varchar(80),
    @DesSed      varchar(80),
    @Gerencia    varchar(180),
    @Area        varchar(180),
    @Responsable varchar(180),
    @Formulario  varchar(180),
    @TipoCorreo  varchar(180),
    @De          varchar(max),
    @Para        varchar(max),
    @CC          varchar(max),
    @Asunto      varchar(max),
    @Cuerpo      varchar(max),
    @UUID        varchar(1000),
    @FecCre      datetime2(7),
    @UseReg      int,
    @Hostname    varchar(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.PACK_EnviarCorreo
        (Fecha, DesEmp, DesSed, Gerencia, Area, Responsable, Formulario,
         TipoCorreo, De, Para, CC, Asunto, Cuerpo, UUID,
         FecCre, UseReg, Hostname)
    VALUES
        (@Fecha, @DesEmp, @DesSed, @Gerencia, @Area, @Responsable, @Formulario,
         @TipoCorreo, @De, @Para, @CC, @Asunto, @Cuerpo, @UUID,
         @FecCre, @UseReg, @Hostname);
END
GO


IF OBJECT_ID('dbo.SP_ACTUALIZAR_PACK_ENVIAR_CORREO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ACTUALIZAR_PACK_ENVIAR_CORREO
GO

/* FecCre, UseReg y Hostname no se tocan: son del alta. */
CREATE PROCEDURE dbo.SP_ACTUALIZAR_PACK_ENVIAR_CORREO
    @Id          int,
    @Fecha       datetime2(7),
    @DesEmp      varchar(80),
    @DesSed      varchar(80),
    @Gerencia    varchar(180),
    @Area        varchar(180),
    @Responsable varchar(180),
    @Formulario  varchar(180),
    @TipoCorreo  varchar(180),
    @De          varchar(max),
    @Para        varchar(max),
    @CC          varchar(max),
    @Asunto      varchar(max),
    @Cuerpo      varchar(max),
    @UUID        varchar(1000),
    @FecEdit     datetime2(7),
    @UseEdit     int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.PACK_EnviarCorreo
       SET Fecha       = @Fecha,
           DesEmp      = @DesEmp,
           DesSed      = @DesSed,
           Gerencia    = @Gerencia,
           Area        = @Area,
           Responsable = @Responsable,
           Formulario  = @Formulario,
           TipoCorreo  = @TipoCorreo,
           De          = @De,
           Para        = @Para,
           CC          = @CC,
           Asunto      = @Asunto,
           Cuerpo      = @Cuerpo,
           UUID        = @UUID,
           FecEdit     = @FecEdit,
           UseEdit     = @UseEdit
     WHERE Id = @Id;
END
GO


IF OBJECT_ID('dbo.SP_ELIMINAR_PACK_ENVIAR_CORREO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ELIMINAR_PACK_ENVIAR_CORREO
GO

/* Baja lógica: la fila queda con UseElim y ya no se puede editar. */
CREATE PROCEDURE dbo.SP_ELIMINAR_PACK_ENVIAR_CORREO
    @Id      int,
    @FecEdit datetime2(7),
    @UseElim int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.PACK_EnviarCorreo
       SET UseElim = @UseElim,
           FecEdit = @FecEdit
     WHERE Id = @Id;
END
GO


IF OBJECT_ID('dbo.SP_MOSTRAR_PACK_ENVIAR_CORREO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_MOSTRAR_PACK_ENVIAR_CORREO
GO

/* Devuelve activos y anulados.

   El orden de columnas importa: el formulario lee la fila por posición para
   pasarla a la ventana de edición.
     0 Id   1 Fecha   2 DesEmp   3 DesSed   4 Gerencia   5 Area
     6 Responsable   7 Formulario   8 TipoCorreo   9 De
     10 Para   11 CC   12 Asunto   13 Cuerpo   14 UUID   15 Estado */
CREATE PROCEDURE dbo.SP_MOSTRAR_PACK_ENVIAR_CORREO
    @Emp varchar(80),
    @Sed varchar(80)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT  Id,
            Fecha,
            ISNULL(DesEmp, '')      AS DesEmp,
            ISNULL(DesSed, '')      AS DesSed,
            ISNULL(Gerencia, '')    AS Gerencia,
            ISNULL(Area, '')        AS Area,
            ISNULL(Responsable, '') AS Responsable,
            ISNULL(Formulario, '')  AS Formulario,
            ISNULL(TipoCorreo, '')  AS TipoCorreo,
            ISNULL(De, '')          AS De,
            ISNULL(Para, '')        AS Para,
            ISNULL(CC, '')          AS CC,
            ISNULL(Asunto, '')      AS Asunto,
            ISNULL(Cuerpo, '')      AS Cuerpo,
            ISNULL(UUID, '')        AS UUID,
            CASE WHEN UseElim IS NULL OR UseElim = 0
                 THEN 'ACTIVO' ELSE 'ANULADO' END AS Estado
      FROM  dbo.PACK_EnviarCorreo
     WHERE  ISNULL(DesEmp, '') LIKE @Emp
       AND  ISNULL(DesSed, '') LIKE @Sed
     ORDER  BY DesEmp, DesSed, Formulario, TipoCorreo;
END
GO


IF OBJECT_ID('dbo.SP_CODIGO_PACK_ENVIAR_CORREO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_CODIGO_PACK_ENVIAR_CORREO
GO

/* Evita repetir el mismo formulario y tipo de correo para la misma empresa y
   sede. Se ignoran los anulados y, al editar, el propio registro. */
CREATE PROCEDURE dbo.SP_CODIGO_PACK_ENVIAR_CORREO
    @DesEmp     varchar(80),
    @DesSed     varchar(80),
    @Formulario varchar(180),
    @TipoCorreo varchar(180),
    @Id         int = 0
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id
      FROM dbo.PACK_EnviarCorreo
     WHERE DesEmp     = @DesEmp
       AND DesSed     = @DesSed
       AND Formulario = @Formulario
       AND TipoCorreo = @TipoCorreo
       AND (UseElim IS NULL OR UseElim = 0)
       AND Id <> @Id;
END
GO
