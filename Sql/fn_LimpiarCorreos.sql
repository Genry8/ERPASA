/* ============================================================================
   dbo.fn_LimpiarCorreos

   Normaliza una lista de correos: quita espacios, descarta los vacios y los
   repetidos, y devuelve todo separado por punto y coma.

   El problema que corrige: al recortar el punto y coma final se hacia
   LEFT(@lista, LEN(@lista) - 1). Cuando la lista llegaba vacia (por ejemplo un
   CC sin llenar) ese LEN valia 0, la longitud quedaba en -1 y SQL Server
   abortaba con el error 537 "Se paso un parametro de longitud no valido a la
   funcion LEFT o SUBSTRING". Aqui el recorte solo ocurre si quedo algo que
   recortar, asi que una lista vacia simplemente devuelve ''.

   Acepta ; , y saltos de linea como separadores, porque los correos pegados
   desde Outlook vienen con cualquiera de los tres.
   ============================================================================ */

IF OBJECT_ID('dbo.fn_LimpiarCorreos', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_LimpiarCorreos
GO

CREATE FUNCTION dbo.fn_LimpiarCorreos (@lista varchar(max))
RETURNS varchar(max)
AS
BEGIN
    IF @lista IS NULL
        RETURN '';

    -- Todos los separadores se unifican en punto y coma.
    DECLARE @resto varchar(max) =
        REPLACE(REPLACE(REPLACE(@lista, ',', ';'), CHAR(13), ';'), CHAR(10), ';');

    -- La tabla guarda los que ya se aceptaron, para no repetirlos. Se compara
    -- con = y no con LIKE: un correo con guion bajo rompia la comparacion.
    DECLARE @vistos TABLE (correo varchar(320) PRIMARY KEY);

    DECLARE @salida varchar(max) = '';
    DECLARE @correo varchar(320);
    DECLARE @corte  int;

    WHILE LEN(@resto) > 0
    BEGIN
        SET @corte = CHARINDEX(';', @resto);

        IF @corte = 0
        BEGIN
            SET @correo = LEFT(@resto, 320);
            SET @resto  = '';
        END
        ELSE
        BEGIN
            SET @correo = LEFT(LEFT(@resto, @corte - 1), 320);
            SET @resto  = SUBSTRING(@resto, @corte + 1, LEN(@resto));
        END

        SET @correo = LTRIM(RTRIM(@correo));

        IF @correo <> '' AND NOT EXISTS (SELECT 1 FROM @vistos WHERE correo = @correo)
        BEGIN
            INSERT INTO @vistos (correo) VALUES (@correo);
            SET @salida = @salida + @correo + ';';
        END
    END

    -- Aqui estaba la falla: solo se recorta si de verdad hay algo.
    IF LEN(@salida) > 0
        SET @salida = LEFT(@salida, LEN(@salida) - 1);

    RETURN @salida;
END
GO


/* ---------------------------------------------------------------- pruebas
   Las cuatro primeras son los casos que antes tumbaban el envio.

SELECT  '(vacio)'      AS caso, '[' + dbo.fn_LimpiarCorreos('')     + ']' AS resultado
UNION ALL SELECT '(nulo)',      '[' + dbo.fn_LimpiarCorreos(NULL)   + ']'
UNION ALL SELECT '(espacios)',  '[' + dbo.fn_LimpiarCorreos('   ')  + ']'
UNION ALL SELECT '(solo ;)',    '[' + dbo.fn_LimpiarCorreos(';;;')  + ']'
UNION ALL SELECT 'repetidos',   '[' + dbo.fn_LimpiarCorreos('a@x.com; a@x.com ;b@x.com') + ']'
UNION ALL SELECT 'guion bajo',  '[' + dbo.fn_LimpiarCorreos('a_b@x.com;axb@x.com') + ']'
UNION ALL SELECT 'con comas',   '[' + dbo.fn_LimpiarCorreos('a@x.com, b@x.com') + ']';

   Esperado:
     (vacio)      []
     (nulo)       []
     (espacios)   []
     (solo ;)     []
     repetidos    [a@x.com;b@x.com]
     guion bajo   [a_b@x.com;axb@x.com]
     con comas    [a@x.com;b@x.com]
--------------------------------------------------------------------------- */
