/* ============================================================================
   Columnas nuevas de los 3 reportes de campamento.

   IMPORTANTE — por qué el orden importa y por qué no sirve un ALTER TABLE ADD:

   El guardado usa SqlBulkCopy SIN ColumnMappings (cd_administracion.cs), así
   que la correspondencia entre el DataTable y la tabla es por POSICIÓN, no por
   nombre. Y ALTER TABLE ADD siempre agrega la columna AL FINAL: no existe en
   SQL Server una forma de insertarla en el medio.

   Por eso cada tabla se vuelve a crear con las columnas en el orden correcto,
   se copian los datos existentes y recién ahí se reemplaza la original. Es lo
   mismo que hace el diseñador de tablas de SSMS por dentro.

   Ejecute cada bloque completo, de a uno, y revise el conteo que imprime al
   final antes de pasar al siguiente.
   ============================================================================ */


/* ==========================================================================
   1) SPER_StatusCampamento
      Nuevas: Programado y Fecha_Programada (entre Situacion y Dni)
              Vigencia y Motivo             (entre Nombre_Completo y Empresa_Trabajador)
   ========================================================================== */
BEGIN TRANSACTION;

CREATE TABLE dbo.SPER_StatusCampamento_NEW(
    [Empresa]            [varchar](150) NULL,
    [Sede]               [varchar](150) NULL,
    [Cod_Campamento]     [int]          NULL,
    [Campamento]         [varchar](450) NULL,
    [Estado_Campamento]  [varchar](50)  NULL,
    [Cod_Carpa]          [int]          NULL,
    [Carpa]              [varchar](100) NULL,
    [Tipo_Ocupante]      [varchar](500) NULL,
    [Estado_Carpa]       [varchar](500) NULL,
    [Cod_Espacio]        [int]          NULL,
    [Espacio]            [varchar](100) NULL,
    [Estado_Espacio]     [varchar](50)  NULL,
    [Situacion]          [varchar](500) NULL,
    [Programado]         [varchar](100) NULL,   -- NUEVA  (col 14 del Excel)
    [Fecha_Programada]   [date]         NULL,   -- NUEVA  (col 15 del Excel)
    [Dni]                [varchar](150) NULL,
    [Nombre_Completo]    [varchar](600) NULL,
    [Vigencia]           [varchar](100) NULL,   -- NUEVA  (col 18 del Excel)
    [Motivo]             [varchar](500) NULL,   -- NUEVA  (col 19 del Excel)
    [Empresa_Trabajador] [varchar](150) NULL,
    [Gerencia]           [varchar](150) NULL,
    [Area]               [varchar](150) NULL,
    [Fecha_Asignacion]   [date]         NULL,
    [Ano]                [int]          NULL,
    [Semana]             [int]          NULL,
    [Hoja]               [varchar](50)  NULL,
    [Estado]             [varchar](20)  NULL,
    [FecCre]             [datetime]     NULL,
    [UseReg]             [int]          NULL,
    [Hostname]           [varchar](80)  NULL,
    [FecEdit]            [datetime]     NULL,
    [UseEdit]            [int]          NULL
) ON [PRIMARY];

INSERT INTO dbo.SPER_StatusCampamento_NEW
    (Empresa, Sede, Cod_Campamento, Campamento, Estado_Campamento,
     Cod_Carpa, Carpa, Tipo_Ocupante, Estado_Carpa,
     Cod_Espacio, Espacio, Estado_Espacio, Situacion,
     Dni, Nombre_Completo, Empresa_Trabajador, Gerencia, Area,
     Fecha_Asignacion, Ano, Semana, Hoja, Estado,
     FecCre, UseReg, Hostname, FecEdit, UseEdit)
SELECT
     Empresa, Sede, Cod_Campamento, Campamento, Estado_Campamento,
     Cod_Carpa, Carpa, Tipo_Ocupante, Estado_Carpa,
     Cod_Espacio, Espacio, Estado_Espacio, Situacion,
     Dni, Nombre_Completo, Empresa_Trabajador, Gerencia, Area,
     Fecha_Asignacion, Ano, Semana, Hoja, Estado,
     FecCre, UseReg, Hostname, FecEdit, UseEdit
FROM dbo.SPER_StatusCampamento;

DROP TABLE dbo.SPER_StatusCampamento;
EXEC sp_rename 'dbo.SPER_StatusCampamento_NEW', 'SPER_StatusCampamento';

COMMIT;
GO

SELECT 'SPER_StatusCampamento' AS tabla, COUNT(*) AS filas FROM dbo.SPER_StatusCampamento;
GO


/* ==========================================================================
   2) SPER_MarcacionesCampamento
      Nuevas: Resultado y Motivo (entre TipoMarcacion y Marcador)
   ========================================================================== */
BEGIN TRANSACTION;

CREATE TABLE dbo.SPER_MarcacionesCampamento_NEW(
    [FechaMarcacion]    [date]         NULL,
    [HoraMarca]         [time](7)      NULL,
    [TipoMarcacion]     [varchar](180) NULL,
    [Resultado]         [varchar](180) NULL,   -- NUEVA  (col 4 del Excel)
    [Motivo]            [varchar](500) NULL,   -- NUEVA  (col 5 del Excel)
    [Marcador]          [varchar](180) NULL,
    [Empresa]           [varchar](180) NULL,
    [Sede]              [varchar](180) NULL,
    [CodCampamento]     [varchar](180) NULL,
    [Campamento]        [varchar](180) NULL,
    [CodCarpa]          [varchar](180) NULL,
    [Carpa]             [varchar](180) NULL,
    [CodEspacio]        [varchar](180) NULL,
    [Espacio]           [varchar](180) NULL,
    [DNI]               [varchar](20)  NULL,
    [NombreCompleto]    [varchar](180) NULL,
    [EmpresaTrabajador] [varchar](180) NULL,
    [Gerencia]          [varchar](180) NULL,
    [Area]              [varchar](180) NULL,
    [Ano]               [int]          NULL,
    [Semana]            [int]          NULL,
    [Hoja]              [varchar](50)  NULL,
    [Estado]            [varchar](20)  NULL,
    [FecCre]            [datetime]     NULL,
    [UseReg]            [int]          NULL,
    [Hostname]          [varchar](80)  NULL,
    [FecEdit]           [datetime]     NULL,
    [UseEdit]           [int]          NULL
) ON [PRIMARY];

INSERT INTO dbo.SPER_MarcacionesCampamento_NEW
    (FechaMarcacion, HoraMarca, TipoMarcacion, Marcador,
     Empresa, Sede, CodCampamento, Campamento, CodCarpa, Carpa,
     CodEspacio, Espacio, DNI, NombreCompleto, EmpresaTrabajador,
     Gerencia, Area, Ano, Semana, Hoja, Estado,
     FecCre, UseReg, Hostname, FecEdit, UseEdit)
SELECT
     FechaMarcacion, HoraMarca, TipoMarcacion, Marcador,
     Empresa, Sede, CodCampamento, Campamento, CodCarpa, Carpa,
     CodEspacio, Espacio, DNI, NombreCompleto, EmpresaTrabajador,
     Gerencia, Area, Ano, Semana, Hoja, Estado,
     FecCre, UseReg, Hostname, FecEdit, UseEdit
FROM dbo.SPER_MarcacionesCampamento;

DROP TABLE dbo.SPER_MarcacionesCampamento;
EXEC sp_rename 'dbo.SPER_MarcacionesCampamento_NEW', 'SPER_MarcacionesCampamento';

COMMIT;
GO

SELECT 'SPER_MarcacionesCampamento' AS tabla, COUNT(*) AS filas FROM dbo.SPER_MarcacionesCampamento;
GO


/* ==========================================================================
   3) SPER_MovimientoCampamento
      Nuevas: Detalle y Estado_Movimiento        (entre Tipo_Movimiento y Origen)
              Modificado_Anulado_Por y
              Fecha_Modificacion                 (después de Fecha_Hora_Registro)

      OJO con el nombre: la columna 4 del Excel se llama "Estado", pero la
      tabla ya tiene una columna Estado (la de auditoría, que vale 'S'). Por eso
      la nueva se llama Estado_Movimiento.
   ========================================================================== */
BEGIN TRANSACTION;

CREATE TABLE dbo.SPER_MovimientoCampamento_NEW(
    [Fecha_Movimiento]       [date]         NULL,
    [Tipo_Movimiento]        [varchar](20)  NULL,
    [Detalle]                [varchar](500) NULL,   -- NUEVA  (col 3 del Excel)
    [Estado_Movimiento]      [varchar](50)  NULL,   -- NUEVA  (col 4 del Excel)
    [Origen]                 [varchar](100) NULL,
    [Empresa]                [varchar](150) NULL,
    [Sede]                   [varchar](50)  NULL,
    [Cod_Campamento]         [int]          NULL,
    [Campamento]             [varchar](150) NULL,
    [Cod_Carpa]              [int]          NULL,
    [Carpa]                  [varchar](100) NULL,
    [Tipo_Ocupante]          [varchar](50)  NULL,
    [Cod_Espacio]            [int]          NULL,
    [Espacio]                [varchar](100) NULL,
    [Dni]                    [varchar](15)  NULL,
    [Nombre_Completo]        [varchar](200) NULL,
    [Empresa_Trabajador]     [varchar](150) NULL,
    [Gerencia]               [varchar](150) NULL,
    [Area]                   [varchar](150) NULL,
    [Bono_Alimentacion]      [varchar](5)   NULL,
    [Fecha_Posible_Salida]   [date]         NULL,
    [Usuario]                [varchar](150) NULL,
    [Fecha_Hora_Registro]    [datetime]     NULL,
    [Modificado_Anulado_Por] [varchar](200) NULL,   -- NUEVA  (col 24 del Excel)
    [Fecha_Modificacion]     [datetime]     NULL,   -- NUEVA  (col 25 del Excel)
    [Ano]                    [int]          NULL,
    [Semana]                 [int]          NULL,
    [Hoja]                   [varchar](50)  NULL,
    [Estado]                 [varchar](20)  NULL,
    [FecCre]                 [datetime]     NULL,
    [UseReg]                 [int]          NULL,
    [Hostname]               [varchar](80)  NULL,
    [FecEdit]                [datetime]     NULL,
    [UseEdit]                [int]          NULL
) ON [PRIMARY];

INSERT INTO dbo.SPER_MovimientoCampamento_NEW
    (Fecha_Movimiento, Tipo_Movimiento, Origen, Empresa, Sede,
     Cod_Campamento, Campamento, Cod_Carpa, Carpa, Tipo_Ocupante,
     Cod_Espacio, Espacio, Dni, Nombre_Completo, Empresa_Trabajador,
     Gerencia, Area, Bono_Alimentacion, Fecha_Posible_Salida,
     Usuario, Fecha_Hora_Registro, Ano, Semana, Hoja, Estado,
     FecCre, UseReg, Hostname, FecEdit, UseEdit)
SELECT
     Fecha_Movimiento, Tipo_Movimiento, Origen, Empresa, Sede,
     Cod_Campamento, Campamento, Cod_Carpa, Carpa, Tipo_Ocupante,
     Cod_Espacio, Espacio, Dni, Nombre_Completo, Empresa_Trabajador,
     Gerencia, Area, Bono_Alimentacion, Fecha_Posible_Salida,
     Usuario, Fecha_Hora_Registro, Ano, Semana, Hoja, Estado,
     FecCre, UseReg, Hostname, FecEdit, UseEdit
FROM dbo.SPER_MovimientoCampamento;

DROP TABLE dbo.SPER_MovimientoCampamento;
EXEC sp_rename 'dbo.SPER_MovimientoCampamento_NEW', 'SPER_MovimientoCampamento';

COMMIT;
GO

SELECT 'SPER_MovimientoCampamento' AS tabla, COUNT(*) AS filas FROM dbo.SPER_MovimientoCampamento;
GO


/* ============================================================================
   COMPROBACIÓN FINAL — el orden de columnas debe quedar exactamente así:

   SPER_StatusCampamento      (32)
     Empresa, Sede, Cod_Campamento, Campamento, Estado_Campamento, Cod_Carpa,
     Carpa, Tipo_Ocupante, Estado_Carpa, Cod_Espacio, Espacio, Estado_Espacio,
     Situacion, Programado, Fecha_Programada, Dni, Nombre_Completo, Vigencia,
     Motivo, Empresa_Trabajador, Gerencia, Area, Fecha_Asignacion, Ano, Semana,
     Hoja, Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit

   SPER_MarcacionesCampamento (28)
     FechaMarcacion, HoraMarca, TipoMarcacion, Resultado, Motivo, Marcador,
     Empresa, Sede, CodCampamento, Campamento, CodCarpa, Carpa, CodEspacio,
     Espacio, DNI, NombreCompleto, EmpresaTrabajador, Gerencia, Area, Ano,
     Semana, Hoja, Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit

   SPER_MovimientoCampamento  (34)
     Fecha_Movimiento, Tipo_Movimiento, Detalle, Estado_Movimiento, Origen,
     Empresa, Sede, Cod_Campamento, Campamento, Cod_Carpa, Carpa,
     Tipo_Ocupante, Cod_Espacio, Espacio, Dni, Nombre_Completo,
     Empresa_Trabajador, Gerencia, Area, Bono_Alimentacion,
     Fecha_Posible_Salida, Usuario, Fecha_Hora_Registro,
     Modificado_Anulado_Por, Fecha_Modificacion, Ano, Semana, Hoja, Estado,
     FecCre, UseReg, Hostname, FecEdit, UseEdit
   ============================================================================ */
SELECT TABLE_NAME, ORDINAL_POSITION, COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME IN ('SPER_StatusCampamento',
                     'SPER_MarcacionesCampamento',
                     'SPER_MovimientoCampamento')
ORDER BY TABLE_NAME, ORDINAL_POSITION;
GO
