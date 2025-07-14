using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_nisira : cd_conexionNisira
    {
        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteCodigoUsuario(string cod)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_USUARIOREG_EXISTENTE"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_nisira.CodUsuarioExiste = reader.GetString(0);
                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }
        }


        // PONER LISTA DE LOTE
        public DataTable ListaLoteNisira(string id)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("select DISTINCT idconsumidor from LOTE", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }


        // PONER LISTA DE CULTIVO
        public DataTable ListaCultivoNisira(string id)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("select DISTINCT descripcion from CULTIVOS", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }



        // PONER LISTA DE CULTIVO
        public DataTable ListaVariedadNisira(string id)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("select DISTINCT vc.descripcion from VARIEDADES_CULTIVOS vc join" +
                    " CULTIVOS c on vc.IDCULTIVO=c.IDCULTIVO where c.DESCRIPCION like '%" + id + "%'", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }


        // PONER LISTA DE PERSONAL EN ANULADO
        public DataTable ListaPersonalUpdate()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexion.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("UPDATE AC_Usuario Set Estado='N' Where Email !='TERCEROS'", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }

        // MOSTRAR LISTA DE PERSONAL POR DNI
        public DataTable ListaPersonalNisira()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand(" select * from (select distinct *,ROW_NUMBER() OVER(PARTITION BY DNI ORDER BY FECHA_INGRESO DESC) AS Num from ( " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,'CE001' AS Empresa,'CS003'as Sede,'CA005'as Area,FECHA_NACIMIENTO, EMAIL,CP.DESCRIPCION as Cargo, ISNULL((SELECT distinct 'S' FROM SANTAAZUL2018.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'N')as Estado,pe.FECHA_INGRESO from SANTAAZUL2018.dbo.PERSONAL_GENERAL PG LEFT JOIN SANTAAZUL2018.dbo.PERSONAL_EMPRESA PE ON PE.IDCODIGOGENERAL = PG.IDCODIGOGENERAL    LEFT JOIN SANTAAZUL2018.dbo.PERSONAL P ON P.IDEMPRESA = PE.IDEMPRESA AND P.IDCODIGOGENERAL = PE.IDCODIGOGENERAL    LEFT JOIN SANTAAZUL2018.dbo.CARGOS_PERSONAL CP ON CP.IDEMPRESA = P.IDEMPRESA AND CP.IDCARGO = P.IDCARGO WHERE  PG.ESTADO = 1 AND PE.FECHA_CESE IS NULL  " +
                    " union all " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,'CE001' AS Empresa,'CS003'as Sede,'CA005'as Area,FECHA_NACIMIENTO, EMAIL,CP.DESCRIPCION as Cargo, ISNULL((SELECT distinct 'S' FROM INTERANDINA.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'N')as Estado,pe.FECHA_INGRESO from INTERANDINA.dbo.PERSONAL_GENERAL PG LEFT JOIN INTERANDINA.dbo.PERSONAL_EMPRESA PE ON PE.IDCODIGOGENERAL = PG.IDCODIGOGENERAL    LEFT JOIN INTERANDINA.dbo.PERSONAL P ON P.IDEMPRESA = PE.IDEMPRESA AND P.IDCODIGOGENERAL = PE.IDCODIGOGENERAL    LEFT JOIN INTERANDINA.dbo.CARGOS_PERSONAL CP ON CP.IDEMPRESA = P.IDEMPRESA AND CP.IDCARGO = P.IDCARGO WHERE  PG.ESTADO = 1 AND PE.FECHA_CESE IS NULL " +
                    " ) as t1 )as t2 where Estado ='S' and Num=1", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }

        public DataTable ListaPersonalNisiraDni(string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("select DISTINCT top 20  *from ( " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_ZONA,ISNULL((SELECT TOP 1 'ACTIVADO' FROM SANTAAZUL2018.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'ANULADO')as Estado from SANTAAZUL2018.dbo.PERSONAL_GENERAL PG " +
                    " union all " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_ZONA ,ISNULL((SELECT TOP 1 'ACTIVADO' FROM INTERANDINA.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'ANULADO')as Estado from INTERANDINA.dbo.PERSONAL_GENERAL PG " +
                    " ) as t1  where DNI like '%" + dni + "%'", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }

        // METODO PARA LLAMAR SI EXISTE EL EMPLEADOR
        public bool BuscExisteDniEmpleador(string codempl)
        {
            using (var conexion = leerconexion())
            {
                using (var comando = new SqlCommand("select DISTINCT top 20  *from ( " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_ZONA,ISNULL((SELECT TOP 1 'ACTIVADO' FROM SANTAAZUL2018.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'ANULADO')as Estado from SANTAAZUL2018.dbo.PERSONAL_GENERAL PG " +
                    " union all " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_ZONA ,ISNULL((SELECT TOP 1 'ACTIVADO' FROM INTERANDINA.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'ANULADO')as Estado from INTERANDINA.dbo.PERSONAL_GENERAL PG " +
                    " ) as t1  where DNI like '%dni%'"))
                {
                    comando.Connection = conexion;
                    //comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@dni", SqlDbType.VarChar).Value = codempl;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_equipoti.CodTrabajadorExist = reader.GetString(0);
                            ce_equipoti.EmpleadorExist = reader.GetString(1);
                        }
                        conexion.Dispose();
                        conexion.Close();

                        return true;

                    }
                    else

                        return false;
                }
            }
        }



        public DataTable ListaPersonalNisiraApellido(string apellido)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("select DISTINCT top 20  *from ( " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_ZONA,ISNULL((SELECT TOP 1 'ACTIVADO' FROM SANTAAZUL2018.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'ANULADO')as Estado from SANTAAZUL2018.dbo.PERSONAL_GENERAL PG " +
                    " union all " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_ZONA ,ISNULL((SELECT TOP 1 'ACTIVADO' FROM INTERANDINA.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'ANULADO')as Estado from INTERANDINA.dbo.PERSONAL_GENERAL PG " +
                    " ) as t1  where Apellidos like '%" + apellido + "%'", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }

        public DataTable ListaPersonalNisiraNombre(string nombre)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("select DISTINCT top 20  *from ( " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_ZONA,ISNULL((SELECT TOP 1 'ACTIVADO' FROM SANTAAZUL2018.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'ANULADO')as Estado from SANTAAZUL2018.dbo.PERSONAL_GENERAL PG " +
                    " union all " +
                    " select NRODOCUMENTO as DNI,CONCAT(A_PATERNO,' ',A_MATERNO) AS Apellidos,NOMBRES as Nombres,case when SEXO='F' then 'FE' else 'MA' end as Sexo,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_ZONA ,ISNULL((SELECT TOP 1 'ACTIVADO' FROM INTERANDINA.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'ANULADO')as Estado from INTERANDINA.dbo.PERSONAL_GENERAL PG " +
                    " ) as t1  where Nombres like '%" + nombre + "%'", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }

        /// <summary>
        /// BUSCAR LISTA PARTIDAS EN NISIRA
        /// </summary>
        /// <returns></returns>
        public DataTable ListaPartidasNisira()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("select Empresa,Idrubro,Partida from ( " +
                    " select ROW_NUMBER() OVER(PARTITION BY PARTIDA ORDER BY PARTIDA ASC)num " +
                    ",Empresa,Idrubro,Partida from (select distinct 'AGRICOLA SANTA AZUL S.R.L' Empresa,upper(trim(d.idrubro)) as idrubro, " +
                    "upper(trim(d.descripcion)) as PARTIDA from SANTAAZUL2018.dbo.DPLANTILLAPSTCONTROL d " +
                    " union all " +
                    " select distinct 'AGRICOLA INTERANDINA S.A.C' Empresa, upper(trim(d.idrubro)) as idrubro,upper(trim(d.descripcion)) as PARTIDA " +
                    " from INTERANDINA.dbo.DPLANTILLAPSTCONTROL d )t1 ) t2 where num=1 and Partida <> '' ", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }



        // MOSTRAR LISTA VARIEDAD
        public DataTable ListaVariedad()
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand(" select 'SELECCIONE' id,'SELECCIONE' DesVar,''Cultivo " +
                    " union all" +
                    " SELECT " +
                    " DISTINCT case when IDVARIEDAD='B10' THEN 'BB10' else IDVARIEDAD end as IDVARIEDAD " +
                    " ,DESCRIPCION,'ARANDANO' Cultivo from SANTAAZUL2018.dbo.VARIEDADES_CULTIVOS " +
                    " WHERE IDCULTIVO='ARAN'  and IDVARIEDAD != '001' " +
                    " UNION ALL " +
                    " SELECT DISTINCT  IDVARIEDAD " +
                    " ,DESCRIPCION,'UVA' Cultivo from INTERANDINA.dbo.VARIEDADES_CULTIVOS " +
                    " WHERE IDCULTIVO='UVA' ", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }

        // MOSTRAR LISTA VARIEDAD CULTIVO
        public DataTable ListaVariedadCultivo(string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand(" select 'SELECCIONE' id,'SELECCIONE' DesVar,'SELECCIONE'Cultivo " +
                    " union all" +
                    " select * from (  SELECT " +
                    " DISTINCT case when IDVARIEDAD='B10' THEN 'BB10' else IDVARIEDAD end as IDVARIEDAD " +
                    " ,DESCRIPCION,'ARANDANO' Cultivo from SANTAAZUL2018.dbo.VARIEDADES_CULTIVOS " +
                    " WHERE IDCULTIVO='ARAN'  and IDVARIEDAD != '001' " +
                    " UNION ALL " +
                    " SELECT DISTINCT  IDVARIEDAD " +
                    " ,DESCRIPCION,'UVA' Cultivo from INTERANDINA.dbo.VARIEDADES_CULTIVOS " +
                    " WHERE IDCULTIVO='UVA' ) t1 where Cultivo like '%" + cultivo+"%'", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }


        // MOSTRAR LISTA VARIEDAD
        public DataTable ListaPresentacion(string cultivo)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand(" select * from ( select " +
                    " distinct concat(pre.idpresentacion,pre.nombre_corto) cod, " +
                    " pre.idpresentacion,pre.nombre_corto Presentacion,'ARANDANO'Cultivo,0 Cajas  " +
                    " FROM SANTAAZUL2018.dbo.PRODUCTOS p " +
                    " join SANTAAZUL2018.dbo.PRESENTACIONES pre on p.idpresentacion=pre.idpresentacion " +
                    " where p.tipo_proceso='P' " +
                    " union all " +
                    " select concat(idinsumo,descripcion)cod, " +
                    " idinsumo,descripcion,'UVA' Cultivo,CANTIDAD " +
                    " from INTERANDINA.dbo.tipo_insumos " +
                    " where trim(idcultivo)='UVA' and ESTADO=1 and tipo='E' ) T1 where Cultivo='" + cultivo + "' order by presentacion asc", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }


        /*
         public DataTable ListaPersonalNisiraDni(string dni)
        {
            SqlDataReader resultado; //permite leer las filas
            DataTable tabla = new DataTable();
            SqlConnection conex = new SqlConnection();

            try
            {
                conex = cd_conexionNisira.CrearInstancia().leerconexion();
                conex.Open();
                SqlCommand comando = new SqlCommand("select DISTINCT top 20  *from ( " +
                    " select CONCAT(A_PATERNO,' ',A_MATERNO,' ',NOMBRES) as Nombres,case when SEXO='F' then 'FE' else 'MA' end as sexo,case when IDDOCIDENTIDAD='01' then 'DNI' else 'CARNET EXT'end as TipoDoc,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad ,NRODOCUMENTO,ISNULL((SELECT TOP 1 'ACTIVADO' FROM SANTAAZUL2018.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'RETIRADO')as Estado,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_VIA, DESCRIPCION_ZONA from SANTAAZUL2018.dbo.PERSONAL_GENERAL PG " +
                    " union all " +
                    " select CONCAT(A_PATERNO,' ',A_MATERNO,' ',NOMBRES)as Nombres,case when SEXO='F' then 'FE' else 'MA' end as sexo,case when IDDOCIDENTIDAD='01' then 'DNI' else 'CARNET EXT'end as TipoDoc,case when IDNACIONALIDAD='PER' then 'PERUANO' else 'EXTRANJERO'end as Nacionalidad ,NRODOCUMENTO,ISNULL((SELECT TOP 1 'ACTIVADO' FROM INTERANDINA.dbo.V_PERSONAL_ACTIVO VP where PG.NRODOCUMENTO=VP.NRODOCUMENTO),'RETIRADO')as Estado,FECHA_NACIMIENTO, CELULAR, EMAIL, DESCRIPCION_VIA, DESCRIPCION_ZONA from INTERANDINA.dbo.PERSONAL_GENERAL PG " +
                    " ) as t1  where NRODOCUMENTO like '%"+dni+"%'", conex);
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }

            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                if (conex.State == ConnectionState.Open) conex.Close(); // CERRAMOS LA CONEXION
            }

        }
         */


    }
}
