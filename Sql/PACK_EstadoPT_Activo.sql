/* ============================================================================
   PACK_EstadoPT: columna para la baja lógica.

   En las otras 23 tablas maestras de packing la columna Estado marca si el
   registro está vigente ('S') o anulado ('N'). En esta, Estado guarda el dato
   del negocio — el nombre del estado del producto terminado —, así que no se
   puede usar para lo mismo.

   Se agrega Activo, que cumple ese papel. Sin esto, eliminar un registro de
   ese maestro borraba la fila de verdad.
   ============================================================================ */

IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID('dbo.PACK_EstadoPT')
                 AND name = 'Activo')
BEGIN
    ALTER TABLE dbo.PACK_EstadoPT ADD Activo varchar(1) NULL;
END
GO

/* Lo que ya existe queda vigente. */
UPDATE dbo.PACK_EstadoPT
   SET Activo = 'S'
 WHERE Activo IS NULL;
GO


/* Comprobación: las 4 filas deberían quedar en 'S'. */
SELECT Id, Cod, Estado, Activo
FROM dbo.PACK_EstadoPT
ORDER BY Id;
GO
