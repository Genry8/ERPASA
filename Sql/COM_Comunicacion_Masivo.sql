/* ============================================================================
   Cargas masivas de los formularios de Comunicación.

   De las 8 pantallas, 5 borran y vuelven a insertar todo: esas ya no necesitan
   procedimiento, C# inserta directo con SqlBulkCopy contra la tabla real
   (el SP de borrado que ya existe se sigue ejecutando antes, sin cambios).

     Cosechando Ganadores   -> COM_CosechandoGanadores
     Potenciando Líderes    -> COM_PotenciandoLideres
     Encuesta Clima         -> COM_EncuestaClima
     Encuesta Participación -> COM_ParticipacionEncuesta
     Movimiento Canje       -> COM_MovimientoCanje

   Las 3 que sí hacen alta o actualización son las de este script. En todas,
   C# sube las filas con SqlBulkCopy a una tabla temporal sobre la MISMA
   conexión y después ejecuta el procedimiento, que resuelve todo en un MERGE.
   ============================================================================ */


/* ------------------------------------------------------ COM_LideresEnAccion */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_COM_LIDERESACCION_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_COM_LIDERESACCION_MASIVO
GO

/* Tabla temporal #LideresEnAccion. Clave: Empresa + Sede + Fecha + Item,
   la misma que usaba el WHERE de SP_ACTUALIZAR_COM_LIDERESACCION.

   El alta deja UseEdit en 0 y la edición lo pone en el usuario, tal como
   hacían las dos llamadas separadas del formulario. */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_COM_LIDERESACCION_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (
                    PARTITION BY Empresa, Sede, Fecha, Item
                    ORDER BY (SELECT 0)) AS rn
          FROM #LideresEnAccion
    )
    MERGE dbo.COM_LideresEnAccion AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.Empresa = o.Empresa
      AND destino.Sede    = o.Sede
      AND destino.Fecha   = o.Fecha
      AND destino.Item    = o.Item

    WHEN MATCHED THEN
        UPDATE SET destino.Ape_Nom   = o.Ape_Nom,
                   destino.Dni       = o.Dni,
                   destino.Area      = o.Area,
                   destino.Labor     = o.Labor,
                   destino.Jefe      = o.Jefe,
                   destino.Puntaje   = o.Puntaje,
                   destino.Categoria = o.Categoria,
                   destino.Estrellas = o.Estrellas,
                   destino.Premio    = o.Premio,
                   destino.Hoja      = o.Hoja,
                   destino.Estado    = o.Estado,
                   destino.FecEdit   = o.FecEdit,
                   destino.UseEdit   = o.UseEdit

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (Item, Fecha, Ape_Nom, Dni, Empresa, Sede, Area, Labor, Jefe,
                Puntaje, Categoria, Estrellas, Premio, Hoja, Estado,
                FecCre, UseReg, Hostname, FecEdit, UseEdit)
        VALUES (o.Item, o.Fecha, o.Ape_Nom, o.Dni, o.Empresa, o.Sede, o.Area,
                o.Labor, o.Jefe, o.Puntaje, o.Categoria, o.Estrellas, o.Premio,
                o.Hoja, o.Estado, o.FecCre, o.UseReg, o.Hostname, o.FecEdit, 0);
END
GO


/* ---------------------------------------------- COM_MovimientoCanjePlanilla */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla_MASIVO
GO

/* Tabla temporal #MovCanjePlanilla. Clave: dni + Fecha_entrega.

   >>> OJO: el SP anterior tenía en su UPDATE la línea
       [codigo_producto] = @puntos
   es decir, al actualizar pisaba el código de producto con el puntaje. Acá
   quedó corregido a o.codigo_producto. Si por alguna razón dependían de ese
   comportamiento, avise y lo revierto.

   id es IDENTITY, así que el INSERT va con lista de columnas explícita.
   FecEdit, UseEdit y UseElim quedan nulos en el alta, igual que antes. */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (
                    PARTITION BY dni, Fecha_entrega
                    ORDER BY (SELECT 0)) AS rn
          FROM #MovCanjePlanilla
    )
    MERGE dbo.COM_MovimientoCanjePlanilla AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.dni           = o.dni
      AND destino.Fecha_entrega = o.Fecha_entrega

    WHEN MATCHED THEN
        UPDATE SET destino.nombre_completo      = o.nombre_completo,
                   destino.puntos               = o.puntos,
                   destino.codigo_producto      = o.codigo_producto,
                   destino.descripcion_producto = o.descripcion_producto,
                   destino.monto_planilla       = o.monto_planilla,
                   destino.IGV                  = o.IGV,
                   destino.Total                = o.Total,
                   destino.estado_canje         = o.estado_canje,
                   destino.FecEdit              = o.FecEdit,
                   destino.UseEdit              = o.UseEdit

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (empresa, dni, nombre_completo, puntos, codigo_producto,
                descripcion_producto, monto_planilla, IGV, Total, estado_canje,
                Fecha_entrega, Hoja, FecCre, UseReg, Hostname,
                FecEdit, UseEdit, UseElim)
        VALUES (o.empresa, o.dni, o.nombre_completo, o.puntos, o.codigo_producto,
                o.descripcion_producto, o.monto_planilla, o.IGV, o.Total, o.estado_canje,
                o.Fecha_entrega, o.Hoja, o.FecCre, o.UseReg, o.Hostname,
                NULL, NULL, NULL);
END
GO


/* ---------------------------------------------------------------- COM_Saldo */
IF OBJECT_ID('dbo.SP_GUARDAR_ACTUALIZAR_SALDO_MASIVO', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_SALDO_MASIVO
GO

/* Tabla temporal #Saldo. Clave: dni + Sede + fecha.

   >>> OJO: el SP anterior preguntaba por dni + Sede + fecha pero su UPDATE
   filtraba solo por dni + fecha, sin sede: con un mismo DNI en dos sedes en la
   misma fecha, actualizaba las dos filas. Acá el MERGE usa las tres columnas
   de forma consistente.

   Id es IDENTITY, así que el INSERT va con lista de columnas explícita.
   FecEdit, UseEdit y UseElim quedan nulos en el alta, igual que antes. */
CREATE PROCEDURE dbo.SP_GUARDAR_ACTUALIZAR_SALDO_MASIVO
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH origen AS (
        SELECT *, ROW_NUMBER() OVER (
                    PARTITION BY dni, Sede, fecha
                    ORDER BY (SELECT 0)) AS rn
          FROM #Saldo
    )
    MERGE dbo.COM_Saldo AS destino
    USING (SELECT * FROM origen WHERE rn = 1) AS o
       ON destino.dni   = o.dni
      AND destino.Sede  = o.Sede
      AND destino.fecha = o.fecha

    WHEN MATCHED THEN
        UPDATE SET destino.correo           = o.correo,
                   destino.telefono         = o.telefono,
                   destino.saldo            = o.saldo,
                   destino.activo           = o.activo,
                   destino.estado_plantilla = o.estado_plantilla,
                   destino.acceso           = o.acceso,
                   destino.Semana           = o.Semana,
                   destino.Año              = o.Año,
                   destino.FecEdit          = o.FecEdit,
                   destino.UseEdit          = o.UseEdit

    WHEN NOT MATCHED BY TARGET THEN
        INSERT (fecha, empresa, Sede, nombres, dni, correo, telefono, saldo,
                activo, estado_plantilla, acceso, Semana, Año, Obs, Hoja, Estado,
                FecCre, UseReg, Hostname, FecEdit, UseEdit, UseElim)
        VALUES (o.fecha, o.empresa, o.Sede, o.nombres, o.dni, o.correo, o.telefono,
                o.saldo, o.activo, o.estado_plantilla, o.acceso, o.Semana, o.Año,
                o.Obs, o.Hoja, o.Estado, o.FecCre, o.UseReg, o.Hostname,
                NULL, NULL, NULL);
END
GO


/* ============================================================================
   Los SP de una fila ya no los llama ningún formulario. No los borro acá
   porque aún no verifiqué si otra pantalla o la API los usa:

     SP_GUARDAR_COM_COSECHANDOGANADORES   SP_ACTUALIZAR_COM_COSECHANDOGANADORES
     SP_GUARDAR_COM_POTENCIANDOLIDERES    SP_ACTUALIZAR_COM_POTENCIANDOLIDERES
     SP_GUARDAR_COM_LIDERESACCION         SP_ACTUALIZAR_COM_LIDERESACCION
     SP_GUARDAR_COM_ENCUESTACLIMA         SP_GUARDAR_ACTUALIZAR_PARTICIPACION_ENCUESTA
     SP_GUARDAR_ACTUALIZAR_MOVIMIENTO_CANJE
     SP_GUARDAR_ACTUALIZAR_MovCanjePlanilla
     SP_GUARDAR_ACTUALIZAR_SALDO
     SP_CODIGO_COM_LIDERESACCION

   Los de borrado SÍ siguen en uso, no los toque:
     SP_CODIGO_COM_COSECHANDOGANADORES    SP_CODIGO_COM_POTENCIANDOLIDERES
     SP_ELIMINAR_COM_ENCUESTACLIMA        SP_ELIMINAR_COM_PARTICIPACION_CLIMA
     SP_ELIMINAR_COM_MOVIMIENTO_CANJE
   ============================================================================ */
