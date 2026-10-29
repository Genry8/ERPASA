/* ============================================================================
   Correo de destajo de uva: fila Id = 6 de dbo.PACK_EnviarCorreo.

   El formulario Frm_Reporte_PT lo busca por ce_correo.codCorreo = 6, asi que
   el Id tiene que ser exactamente 6. Como la columna es IDENTITY, se habilita
   IDENTITY_INSERT solo para esta insercion.

   Los destinatarios salen del correo que hoy se envia a mano
   ("REPORTE UVA / PaletasProceso_Uva25 - 2da Etapa").
   ============================================================================ */

IF EXISTS (SELECT 1 FROM dbo.PACK_EnviarCorreo WHERE Id = 6)
BEGIN
    PRINT 'Ya existe la fila Id = 6; no se inserta nada. Revise antes de continuar.';
END
ELSE
BEGIN
    SET IDENTITY_INSERT dbo.PACK_EnviarCorreo ON;

    INSERT INTO dbo.PACK_EnviarCorreo
        (Id, Fecha, DesEmp, DesSed, Gerencia, Area, Responsable,
         Formulario, TipoCorreo, De, Para, CC, Asunto, Cuerpo, UUID,
         FecCre, UseReg, Hostname)
    VALUES
    (
        6,
        '2026-10-26 08:00:00.0000000',
        'AGRICOLA SANTA AZUL S.R.L',
        'Fundo Santa Azul',
        'GERENCIA DE OPERACIONES',
        'PACKING',
        'EDWIN CARBAJAL',
        'Correo automatico de destajo de uva',
        'DESTAJO UVA',
        'administradorti@agsantaazul.com',

        -- PARA
        'paul.jimenez@agsantaazul.com;abraham.haro@agsantaazul.com;' +
        'alexandra.monja@agsantaazul.com;katerine.noriega@agsantaazul.com;' +
        'erickson.icanaque@agsantaazul.com',

        -- CC
        'alejandro.mujica@agsantaazul.com;lucero.walde@agsantaazul.com;' +
        'junior.quinones@agsantaazul.com;genry.alberto@agsantaazul.com;' +
        'julissa.vilcapuma@agsantaazul.com',

        'REPORTE UVA / PaletasProceso_Uva25 - 2da Etapa',

        'Estimados Buenos Dias, Se adjunta detalle de cajas producidas Cosecha y Proceso.',

        NEWID(),
        SYSDATETIME(),
        1,
        HOST_NAME()
    );

    SET IDENTITY_INSERT dbo.PACK_EnviarCorreo OFF;

    PRINT 'Insertada la configuracion de correo de destajo (Id = 6).';
END
GO

/* Comprobacion:

   SELECT Id, Formulario, TipoCorreo, Asunto, Para, CC
     FROM dbo.PACK_EnviarCorreo
    WHERE Id = 6;
*/
