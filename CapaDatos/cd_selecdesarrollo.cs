
using CapaEntidad;
using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class cd_selecdesarrollo : cd_conexion
    {



        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void GuardarTrabActivo(string Sec, string Dni, string ApeNom, string FecPost, string HoraPost
            , string StatusPost, string Condicion, string Huella, string StatusFirma, string UserFirma, string FechaFirma
            , string StatusTrab, DateTime FecIngreso, string Empresa, string Sede, string Cargo, string FecNac
            , string Genero, string IniContrato, string FinContrato, string FecCese, string Telefono, string Correo, string Pais
            , string Departamento, string ProvinciaDni, string DistritoDni, string DireccionDNI, string CambioDireccion, string DepartamentoActual
            , string ProvinciaActual, string DistritoActual, string DireccionActual, string LugarProcedencia, string Localidad
            , string ModeloContrato, string Area, string SubArea, string Gerencia, string FecImpContrato
            , string HoraImpContrato, string TipoTrabajador, string TipoDocumento, string TipoPersonal, string ExamenMedico
            , string ResultExaMedico, string LlegadaPostulante, string DniJalador, string NombreJalador, string Discapacidad
            , string NroCarneDiscapacidad, string TipoDiscapacidad, string PlacaTransporte
            , string RegimenLaboral, decimal Sueldo, string EstadoCivil, string TipoCuentaBanc
            , string Banco, string NroCuenta, string NroCuentaCCI, string CatPensionista, string GradoInstruccion
            , string CatOcupacional, string PeriodoPago, string TipoPago, string Situacion, string TrabHorNocturno
            , string JornTrabMax, string RegimenAtipico, string CodPlanilla, string CodTipTrabajo
            , string CodSucursal, string GrupoProvision, string LeyLaboral
            , string hoja, DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_GUARDAR_TRABAJADOR_ACTIVO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sec", SqlDbType.Date).Value = Sec;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = ApeNom;
                    comando.Parameters.AddWithValue("@FecPost", SqlDbType.VarChar).Value = FecPost;
                    comando.Parameters.AddWithValue("@HoraPost", SqlDbType.VarChar).Value = HoraPost;
                    comando.Parameters.AddWithValue("@StatusPost", SqlDbType.VarChar).Value = StatusPost;
                    comando.Parameters.AddWithValue("@Condicion", SqlDbType.VarChar).Value = Condicion;
                    comando.Parameters.AddWithValue("@Huella", SqlDbType.VarChar).Value = Huella;
                    comando.Parameters.AddWithValue("@StatusFirma", SqlDbType.VarChar).Value = StatusFirma;
                    comando.Parameters.AddWithValue("@UserFirma", SqlDbType.VarChar).Value = UserFirma;


                    comando.Parameters.AddWithValue("@FechaFirma", SqlDbType.VarChar).Value = FechaFirma;
                    comando.Parameters.AddWithValue("@StatusTrab", SqlDbType.VarChar).Value = StatusTrab;
                    comando.Parameters.AddWithValue("@FecIngreso", SqlDbType.DateTime).Value = FecIngreso;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;
                    comando.Parameters.AddWithValue("@FecNac", SqlDbType.VarChar).Value = FecNac;
                    comando.Parameters.AddWithValue("@Genero", SqlDbType.VarChar).Value = Genero;
                    comando.Parameters.AddWithValue("@IniContrato", SqlDbType.VarChar).Value = IniContrato;
                    comando.Parameters.AddWithValue("@FinContrato", SqlDbType.VarChar).Value = FinContrato;

                    comando.Parameters.AddWithValue("@FecCese", SqlDbType.VarChar).Value = FecCese;
                    comando.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = Telefono;
                    comando.Parameters.AddWithValue("@Correo", SqlDbType.VarChar).Value = Correo;
                    comando.Parameters.AddWithValue("@Pais", SqlDbType.VarChar).Value = Pais;
                    comando.Parameters.AddWithValue("@Departamento", SqlDbType.VarChar).Value = Departamento;
                    comando.Parameters.AddWithValue("@ProvinciaDni", SqlDbType.VarChar).Value = ProvinciaDni;
                    comando.Parameters.AddWithValue("@DistritoDni", SqlDbType.VarChar).Value = DistritoDni;
                    comando.Parameters.AddWithValue("@DireccionDNI", SqlDbType.VarChar).Value = DireccionDNI;
                    comando.Parameters.AddWithValue("@CambioDireccion", SqlDbType.VarChar).Value = CambioDireccion;
                    comando.Parameters.AddWithValue("@DepartamentoActual", SqlDbType.VarChar).Value = DepartamentoActual;

                    comando.Parameters.AddWithValue("@ProvinciaActual", SqlDbType.VarChar).Value = ProvinciaActual;
                    comando.Parameters.AddWithValue("@DistritoActual", SqlDbType.VarChar).Value = DistritoActual;
                    comando.Parameters.AddWithValue("@DireccionActual", SqlDbType.VarChar).Value = DireccionActual;
                    comando.Parameters.AddWithValue("@LugarProcedencia", SqlDbType.VarChar).Value = LugarProcedencia;
                    comando.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = Localidad;
                    comando.Parameters.AddWithValue("@ModeloContrato", SqlDbType.VarChar).Value = ModeloContrato;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@SubArea", SqlDbType.VarChar).Value = SubArea;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = Gerencia;
                    comando.Parameters.AddWithValue("@FecImpContrato", SqlDbType.VarChar).Value = FecImpContrato;

                    comando.Parameters.AddWithValue("@HoraImpContrato", SqlDbType.VarChar).Value = HoraImpContrato;
                    comando.Parameters.AddWithValue("@TipoTrabajador", SqlDbType.VarChar).Value = TipoTrabajador;
                    comando.Parameters.AddWithValue("@TipoDocumento", SqlDbType.VarChar).Value = TipoDocumento;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = TipoPersonal;
                    comando.Parameters.AddWithValue("@ExamenMedico", SqlDbType.VarChar).Value = ExamenMedico;
                    comando.Parameters.AddWithValue("@ResultExaMedico", SqlDbType.VarChar).Value = ResultExaMedico;
                    comando.Parameters.AddWithValue("@LlegadaPostulante", SqlDbType.VarChar).Value = LlegadaPostulante;
                    comando.Parameters.AddWithValue("@DniJalador", SqlDbType.VarChar).Value = DniJalador;
                    comando.Parameters.AddWithValue("@NombreJalador", SqlDbType.VarChar).Value = NombreJalador;
                    comando.Parameters.AddWithValue("@Discapacidad", SqlDbType.VarChar).Value = Discapacidad;

                    comando.Parameters.AddWithValue("@NroCarneDiscapacidad", SqlDbType.VarChar).Value = NroCarneDiscapacidad;
                    comando.Parameters.AddWithValue("@TipoDiscapacidad", SqlDbType.VarChar).Value = TipoDiscapacidad;
                    comando.Parameters.AddWithValue("@PlacaTransporte", SqlDbType.VarChar).Value = PlacaTransporte;
                    comando.Parameters.AddWithValue("@RegimenLaboral", SqlDbType.VarChar).Value = RegimenLaboral;
                    comando.Parameters.AddWithValue("@Sueldo", SqlDbType.Decimal).Value = Sueldo;
                    comando.Parameters.AddWithValue("@EstadoCivil", SqlDbType.VarChar).Value = EstadoCivil;
                    comando.Parameters.AddWithValue("@TipoCuentaBanc", SqlDbType.VarChar).Value = TipoCuentaBanc;
                    comando.Parameters.AddWithValue("@Banco", SqlDbType.VarChar).Value = Banco;
                    comando.Parameters.AddWithValue("@NroCuenta", SqlDbType.VarChar).Value = NroCuenta;
                    comando.Parameters.AddWithValue("@NroCuentaCCI", SqlDbType.VarChar).Value = NroCuentaCCI;

                    comando.Parameters.AddWithValue("@CatPensionista", SqlDbType.VarChar).Value = CatPensionista;
                    comando.Parameters.AddWithValue("@GradoInstruccion", SqlDbType.VarChar).Value = GradoInstruccion;
                    comando.Parameters.AddWithValue("@CatOcupacional", SqlDbType.VarChar).Value = CatOcupacional;
                    comando.Parameters.AddWithValue("@PeriodoPago", SqlDbType.VarChar).Value = PeriodoPago;
                    comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar).Value = TipoPago;
                    comando.Parameters.AddWithValue("@Situacion", SqlDbType.VarChar).Value = Situacion;
                    comando.Parameters.AddWithValue("@TrabHorNocturno", SqlDbType.VarChar).Value = TrabHorNocturno;
                    comando.Parameters.AddWithValue("@JornTrabMax", SqlDbType.VarChar).Value = JornTrabMax;
                    comando.Parameters.AddWithValue("@RegimenAtipico", SqlDbType.VarChar).Value = RegimenAtipico;
                    comando.Parameters.AddWithValue("@CodPlanilla", SqlDbType.VarChar).Value = CodPlanilla;

                    comando.Parameters.AddWithValue("@CodTipTrabajo", SqlDbType.VarChar).Value = CodTipTrabajo;
                    comando.Parameters.AddWithValue("@CodSucursal", SqlDbType.VarChar).Value = CodSucursal;
                    comando.Parameters.AddWithValue("@GrupoProvision", SqlDbType.VarChar).Value = GrupoProvision;
                    comando.Parameters.AddWithValue("@LeyLaboral", SqlDbType.VarChar).Value = LeyLaboral;
                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    comando.ExecuteNonQuery();

                }
            }

        }

        // METODO PARA GUARDAR VIAJE TRANSPORTE
        public void ActualizarTrabActivo(string Sec, string Dni, string ApeNom, string FecPost, string HoraPost
            , string StatusPost, string Condicion, string Huella, string StatusFirma, string UserFirma, string FechaFirma
            , string StatusTrab, DateTime FecIngreso, string Empresa, string Sede, string Cargo, string FecNac
            , string Genero, string IniContrato, string FinContrato, string FecCese, string Telefono, string Correo, string Pais
            , string Departamento, string ProvinciaDni, string DistritoDni, string DireccionDNI, string CambioDireccion, string DepartamentoActual
            , string ProvinciaActual, string DistritoActual, string DireccionActual, string LugarProcedencia, string Localidad
            , string ModeloContrato, string Area, string SubArea, string Gerencia, string FecImpContrato
            , string HoraImpContrato, string TipoTrabajador, string TipoDocumento, string TipoPersonal, string ExamenMedico
            , string ResultExaMedico, string LlegadaPostulante, string DniJalador, string NombreJalador, string Discapacidad
            , string NroCarneDiscapacidad, string TipoDiscapacidad, string PlacaTransporte
            , string RegimenLaboral, decimal Sueldo, string EstadoCivil, string TipoCuentaBanc
            , string Banco, string NroCuenta, string NroCuentaCCI, string CatPensionista, string GradoInstruccion
            , string CatOcupacional, string PeriodoPago, string TipoPago, string Situacion, string TrabHorNocturno
            , string JornTrabMax, string RegimenAtipico, string CodPlanilla, string CodTipTrabajo
            , string CodSucursal, string GrupoProvision, string LeyLaboral
            , string hoja, DateTime fec_mov, int usedit)
        {
            using (var conexion = leerconexion())
            {

                using (var comando = new SqlCommand("SP_ACTUALIZAR_TRABAJADOR_ACTIVO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Sec", SqlDbType.Date).Value = Sec;
                    comando.Parameters.AddWithValue("@Dni", SqlDbType.VarChar).Value = Dni;
                    comando.Parameters.AddWithValue("@ApeNom", SqlDbType.VarChar).Value = ApeNom;
                    comando.Parameters.AddWithValue("@FecPost", SqlDbType.VarChar).Value = FecPost;
                    comando.Parameters.AddWithValue("@HoraPost", SqlDbType.VarChar).Value = HoraPost;
                    comando.Parameters.AddWithValue("@StatusPost", SqlDbType.VarChar).Value = StatusPost;
                    comando.Parameters.AddWithValue("@Condicion", SqlDbType.VarChar).Value = Condicion;
                    comando.Parameters.AddWithValue("@Huella", SqlDbType.VarChar).Value = Huella;
                    comando.Parameters.AddWithValue("@StatusFirma", SqlDbType.VarChar).Value = StatusFirma;
                    comando.Parameters.AddWithValue("@UserFirma", SqlDbType.VarChar).Value = UserFirma;


                    comando.Parameters.AddWithValue("@FechaFirma", SqlDbType.VarChar).Value = FechaFirma;
                    comando.Parameters.AddWithValue("@StatusTrab", SqlDbType.VarChar).Value = StatusTrab;
                    comando.Parameters.AddWithValue("@FecIngreso", SqlDbType.DateTime).Value = FecIngreso;
                    comando.Parameters.AddWithValue("@Empresa", SqlDbType.VarChar).Value = Empresa;
                    comando.Parameters.AddWithValue("@Sede", SqlDbType.VarChar).Value = Sede;
                    comando.Parameters.AddWithValue("@Cargo", SqlDbType.VarChar).Value = Cargo;
                    comando.Parameters.AddWithValue("@FecNac", SqlDbType.VarChar).Value = FecNac;
                    comando.Parameters.AddWithValue("@Genero", SqlDbType.VarChar).Value = Genero;
                    comando.Parameters.AddWithValue("@IniContrato", SqlDbType.VarChar).Value = IniContrato;
                    comando.Parameters.AddWithValue("@FinContrato", SqlDbType.VarChar).Value = FinContrato;

                    comando.Parameters.AddWithValue("@FecCese", SqlDbType.VarChar).Value = FecCese;
                    comando.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = Telefono;
                    comando.Parameters.AddWithValue("@Correo", SqlDbType.VarChar).Value = Correo;
                    comando.Parameters.AddWithValue("@Pais", SqlDbType.VarChar).Value = Pais;
                    comando.Parameters.AddWithValue("@Departamento", SqlDbType.VarChar).Value = Departamento;
                    comando.Parameters.AddWithValue("@ProvinciaDni", SqlDbType.VarChar).Value = ProvinciaDni;
                    comando.Parameters.AddWithValue("@DistritoDni", SqlDbType.VarChar).Value = DistritoDni;
                    comando.Parameters.AddWithValue("@DireccionDNI", SqlDbType.VarChar).Value = DireccionDNI;
                    comando.Parameters.AddWithValue("@CambioDireccion", SqlDbType.VarChar).Value = CambioDireccion;
                    comando.Parameters.AddWithValue("@DepartamentoActual", SqlDbType.VarChar).Value = DepartamentoActual;

                    comando.Parameters.AddWithValue("@ProvinciaActual", SqlDbType.VarChar).Value = ProvinciaActual;
                    comando.Parameters.AddWithValue("@DistritoActual", SqlDbType.VarChar).Value = DistritoActual;
                    comando.Parameters.AddWithValue("@DireccionActual", SqlDbType.VarChar).Value = DireccionActual;
                    comando.Parameters.AddWithValue("@LugarProcedencia", SqlDbType.VarChar).Value = LugarProcedencia;
                    comando.Parameters.AddWithValue("@Localidad", SqlDbType.VarChar).Value = Localidad;
                    comando.Parameters.AddWithValue("@ModeloContrato", SqlDbType.VarChar).Value = ModeloContrato;
                    comando.Parameters.AddWithValue("@Area", SqlDbType.VarChar).Value = Area;
                    comando.Parameters.AddWithValue("@SubArea", SqlDbType.VarChar).Value = SubArea;
                    comando.Parameters.AddWithValue("@Gerencia", SqlDbType.VarChar).Value = Gerencia;
                    comando.Parameters.AddWithValue("@FecImpContrato", SqlDbType.VarChar).Value = FecImpContrato;

                    comando.Parameters.AddWithValue("@HoraImpContrato", SqlDbType.VarChar).Value = HoraImpContrato;
                    comando.Parameters.AddWithValue("@TipoTrabajador", SqlDbType.VarChar).Value = TipoTrabajador;
                    comando.Parameters.AddWithValue("@TipoDocumento", SqlDbType.VarChar).Value = TipoDocumento;
                    comando.Parameters.AddWithValue("@TipoPersonal", SqlDbType.VarChar).Value = TipoPersonal;
                    comando.Parameters.AddWithValue("@ExamenMedico", SqlDbType.VarChar).Value = ExamenMedico;
                    comando.Parameters.AddWithValue("@ResultExaMedico", SqlDbType.VarChar).Value = ResultExaMedico;
                    comando.Parameters.AddWithValue("@LlegadaPostulante", SqlDbType.VarChar).Value = LlegadaPostulante;
                    comando.Parameters.AddWithValue("@DniJalador", SqlDbType.VarChar).Value = DniJalador;
                    comando.Parameters.AddWithValue("@NombreJalador", SqlDbType.VarChar).Value = NombreJalador;
                    comando.Parameters.AddWithValue("@Discapacidad", SqlDbType.VarChar).Value = Discapacidad;

                    comando.Parameters.AddWithValue("@NroCarneDiscapacidad", SqlDbType.VarChar).Value = NroCarneDiscapacidad;
                    comando.Parameters.AddWithValue("@TipoDiscapacidad", SqlDbType.VarChar).Value = TipoDiscapacidad;
                    comando.Parameters.AddWithValue("@PlacaTransporte", SqlDbType.VarChar).Value = PlacaTransporte;
                    comando.Parameters.AddWithValue("@RegimenLaboral", SqlDbType.VarChar).Value = RegimenLaboral;
                    comando.Parameters.AddWithValue("@Sueldo", SqlDbType.Decimal).Value = Sueldo;
                    comando.Parameters.AddWithValue("@EstadoCivil", SqlDbType.VarChar).Value = EstadoCivil;
                    comando.Parameters.AddWithValue("@TipoCuentaBanc", SqlDbType.VarChar).Value = TipoCuentaBanc;
                    comando.Parameters.AddWithValue("@Banco", SqlDbType.VarChar).Value = Banco;
                    comando.Parameters.AddWithValue("@NroCuenta", SqlDbType.VarChar).Value = NroCuenta;
                    comando.Parameters.AddWithValue("@NroCuentaCCI", SqlDbType.VarChar).Value = NroCuentaCCI;

                    comando.Parameters.AddWithValue("@CatPensionista", SqlDbType.VarChar).Value = CatPensionista;
                    comando.Parameters.AddWithValue("@GradoInstruccion", SqlDbType.VarChar).Value = GradoInstruccion;
                    comando.Parameters.AddWithValue("@CatOcupacional", SqlDbType.VarChar).Value = CatOcupacional;
                    comando.Parameters.AddWithValue("@PeriodoPago", SqlDbType.VarChar).Value = PeriodoPago;
                    comando.Parameters.AddWithValue("@TipoPago", SqlDbType.VarChar).Value = TipoPago;
                    comando.Parameters.AddWithValue("@Situacion", SqlDbType.VarChar).Value = Situacion;
                    comando.Parameters.AddWithValue("@TrabHorNocturno", SqlDbType.VarChar).Value = TrabHorNocturno;
                    comando.Parameters.AddWithValue("@JornTrabMax", SqlDbType.VarChar).Value = JornTrabMax;
                    comando.Parameters.AddWithValue("@RegimenAtipico", SqlDbType.VarChar).Value = RegimenAtipico;
                    comando.Parameters.AddWithValue("@CodPlanilla", SqlDbType.VarChar).Value = CodPlanilla;

                    comando.Parameters.AddWithValue("@CodTipTrabajo", SqlDbType.VarChar).Value = CodTipTrabajo;
                    comando.Parameters.AddWithValue("@CodSucursal", SqlDbType.VarChar).Value = CodSucursal;
                    comando.Parameters.AddWithValue("@GrupoProvision", SqlDbType.VarChar).Value = GrupoProvision;
                    comando.Parameters.AddWithValue("@LeyLaboral", SqlDbType.VarChar).Value = LeyLaboral;

                    comando.Parameters.AddWithValue("@Hoja", SqlDbType.VarChar).Value = hoja;
                    //comando.Parameters.AddWithValue("@FecCre", SqlDbType.DateTime).Value = fec_cre;
                    //comando.Parameters.AddWithValue("@UseReg", SqlDbType.Int).Value = usereg;
                    //comando.Parameters.AddWithValue("@Hostname", SqlDbType.VarChar).Value = hostname;
                    comando.Parameters.AddWithValue("@FecEdit", SqlDbType.DateTime).Value = fec_mov;
                    comando.Parameters.AddWithValue("@UseEdit", SqlDbType.Int).Value = usedit;
                    //comando.Parameters.AddWithValue("@UseElim", SqlDbType.Int).Value = useelim;
                    comando.ExecuteNonQuery();

                }
            }

        }




        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteTrabajadorActivo(string cod, DateTime fecha)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_TRABAJADOR_ACTIVO"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Cod", SqlDbType.VarChar).Value = cod;
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ce_selecdesarrollo.codigo = reader.GetString(0);
                            ce_selecdesarrollo.FechaInicio = reader.GetDateTime(1);
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



        // METODO PARA LLAMAR SI EXISTE EL CODIGO DE USUARIO PB
        public bool BuscExisteEficienciaMaquinaria(DateTime fecha
            , string maquinaria, string turno, string operador, string cabezal)
        {
            using (var conexion = cd_conexion.CrearInstancia().leerconexion())
            {
                using (var comando = new SqlCommand("SP_CODIGO_DE_EFICIENCIA_MAQUINARIA"))
                {
                    comando.Connection = conexion;
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@Fecha", SqlDbType.Date).Value = fecha;
                    comando.Parameters.AddWithValue("@Maquinaria", SqlDbType.VarChar).Value = maquinaria;
                    comando.Parameters.AddWithValue("@Turno", SqlDbType.VarChar).Value = turno;
                    comando.Parameters.AddWithValue("@Operador", SqlDbType.VarChar).Value = operador;
                    comando.Parameters.AddWithValue("@Cabezal", SqlDbType.VarChar).Value = cabezal;
                    comando.ExecuteNonQuery();
                    SqlDataReader reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //ce_selecdesarrollo.codigo = reader.GetString(0);
                            //ce_selecdesarrollo.FechaInicio = reader.GetDateTime(1);
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



        public void GuardarCoberturaProgBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SD_CoberturaProgramado"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }

        public void GuardarEficienciaBulk(DataTable dt)
        {
            // Usamos la conexión ya abierta desde la clase base
            var connection = leerconexion(); // Suponiendo que leerconexion devuelve la conexión

            // Verifica que la conexión esté abierta
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();  // Abrimos la conexión si no está abierta
            }

            try
            {
                // Usamos la conexión ya abierta para la inserción masiva
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    // Establecer la tabla de destino en la base de datos
                    bulkCopy.DestinationTableName = "SD_Eficiencia"; // Cambia el nombre a la tabla que estás usando

                    // Configuraciones adicionales de SqlBulkCopy
                    bulkCopy.BatchSize = 1000; // Número de registros a enviar en cada lote
                    bulkCopy.NotifyAfter = 1000; // Notificar después de insertar 1000 registros
                    bulkCopy.BulkCopyTimeout = 300; // Tiempo máximo en segundos para completar la operación

                    try
                    {
                        // Realizar la inserción masiva de las filas del DataTable
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (SqlException sqlEx)
                    {
                        // Manejo de errores específicos de SQL
                        throw new Exception("Error al insertar datos en la base de datos (SQL Error)", sqlEx);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores generales
                        throw new Exception("Error al insertar datos en la base de datos", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al abrir la conexión o en la operación bulkCopy
                throw new Exception("Error al abrir la conexión o realizar la operación masiva", ex);
            }
            finally
            {
                // Asegurarse de que la conexión se cierre si fue abierta en este método
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();  // Cerramos la conexión
                }
            }
        }


        public void GuardarProductividadMergeT(DataTable dt)
        {
            var connection = leerconexion();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    string mergeQuery = @"
MERGE INTO SD_Productividad AS target
USING @ProductividadSource AS source
ON target.Dni = source.Dni AND target.Fecha = source.Fecha
and target.TipoProd = source.TipoProd 
WHEN MATCHED THEN
    UPDATE SET 
        target.Empresa = source.Empresa,
        target.Sede = source.Sede,
        target.Nombres = source.Nombres,
        target.Cabezal = source.Cabezal,
        target.Variedad = source.Variedad,
        target.Presentacion = source.Presentacion,
        target.Grupo_Labor = source.Grupo_Labor,
        target.Labor = source.Labor,
        target.Avance = source.Avance,
        target.Meta = source.Meta,
        target.TipoProd = source.TipoProd,
        target.Obs = source.Obs,
        target.Hoja = source.Hoja,
        target.Estado = source.Estado,
        target.FecCre = source.FecCre,
        target.UseReg = source.UseReg,
        target.Hostname = source.Hostname,
        target.FecEdit = source.FecEdit,
        target.UseEdit = source.UseEdit,
        target.UseElim = source.UseElim
WHEN NOT MATCHED THEN
    INSERT (Empresa, Sede, Fecha, Dni, Nombres, Cabezal, Variedad, Presentacion, Grupo_Labor, Labor, Avance, Meta, TipoProd, Obs, Hoja, Estado, FecCre, UseReg, Hostname, FecEdit, UseEdit, UseElim)
    VALUES (source.Empresa, source.Sede, source.Fecha, source.Dni, source.Nombres, source.Cabezal, source.Variedad, source.Presentacion, source.Grupo_Labor, source.Labor, source.Avance, source.Meta, source.TipoProd, source.Obs, source.Hoja, source.Estado, source.FecCre, source.UseReg, source.Hostname, source.FecEdit, source.UseEdit, source.UseElim);
";

                    command.CommandText = mergeQuery;

                    SqlParameter param = new SqlParameter("@ProductividadSource", SqlDbType.Structured)
                    {
                        TypeName = "dbo.ProductividadType",
                        Value = dt
                    };

                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar el MERGE en SD_Productividad", ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void GuardarProductividadMerge(DataTable dt)
        {
            var connection = leerconexion();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Transaction = transaction;

                    string query = @"

-- Eliminar registros coincidentes
DELETE target
FROM SD_Productividad target
INNER JOIN
(
    SELECT DISTINCT
        Fecha,
        TipoProd,
        Sede
    FROM @ProductividadSource
) source
    ON target.Fecha = source.Fecha
    AND target.TipoProd = source.TipoProd
    AND target.Sede = source.Sede;

-- Insertar nuevamente
INSERT INTO SD_Productividad
(
    Empresa,
    Sede,
    Fecha,
    Dni,
    Nombres,
    Cabezal,
    Variedad,
    Presentacion,
    Grupo_Labor,
    Labor,
    Avance,
    Meta,
    TipoProd,
    Obs,
    Hoja,
    Estado,
    FecCre,
    UseReg,
    Hostname,
    FecEdit,
    UseEdit,
    UseElim
)
SELECT
    Empresa,
    Sede,
    Fecha,
    Dni,
    Nombres,
    Cabezal,
    Variedad,
    Presentacion,
    Grupo_Labor,
    Labor,
    Avance,
    Meta,
    TipoProd,
    Obs,
    Hoja,
    Estado,
    FecCre,
    UseReg,
    Hostname,
    FecEdit,
    UseEdit,
    UseElim
FROM @ProductividadSource;

";

                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@ProductividadSource", SqlDbType.Structured)
                    {
                        TypeName = "dbo.ProductividadType",
                        Value = dt
                    };

                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error al guardar en SD_Productividad", ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void GuardarKilosProyectadoMerge(DataTable dt)
        {
            var connection = leerconexion();

            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.Transaction = transaction;

                    string query = @"
-- Eliminar coincidencias
DELETE target
FROM CONT_KilosProyectado target
INNER JOIN @KilosSource source
    ON target.Fecha = source.Fecha
    AND target.Empresa = source.Empresa
    AND target.Sucursal = source.Sucursal
    AND target.Cultivo = source.Cultivo;

-- Insertar nuevos registros
INSERT INTO CONT_KilosProyectado
(Fecha, Empresa, Sucursal, Cultivo, Etapa, KilosCosecha, KilosExpo, Mes, Año, Hoja, FecCre, UseReg, Hostname, FecEdit, UseEdit)
SELECT 
    Fecha, Empresa, Sucursal, Cultivo, Etapa, KilosCosecha, KilosExpo, Mes, Año, Hoja, FecCre, UseReg, Hostname, FecEdit, UseEdit
FROM @KilosSource;
";

                    command.CommandText = query;

                    SqlParameter param = new SqlParameter("@KilosSource", SqlDbType.Structured)
                    {
                        TypeName = "dbo.KilosProyectadoType", // asegúrate que exista este TYPE
                        Value = dt
                    };

                    command.Parameters.Add(param);

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Error al guardar en CONT_KilosProyectado", ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }




        // SD_EficienciaQC: reemplaza el año y la semana completos (ver el SP).
        public void GuardarEficienciaQC(DataTable datos)
        {
            CargaMasiva(datos, "#EficienciaQC", @"CREATE TABLE #EficienciaQC(
                        IdReq              int,
                        Semana             int,
                        [Año]              varchar(80),
                        Posicion           varchar(180),
                        Sede               varchar(80),
                        Planta             varchar(180),
                        EstadoProceso      varchar(80),
                        SemProy            int,
                        FechaProy          date,
                        SemAjuste          int,
                        FechaReq           date,
                        TiempoProceso      int,
                        TipoPersonal       varchar(80),
                        FechaTerna         date,
                        FechaRpta          date,
                        Dias               int,
                        FechaEntrevista    date,
                        FechaCierreProc    date,
                        FechaIng           date,
                        DiasDuracion       int,
                        Vencimiento        int,
                        Inspector          varchar(180),
                        Incidencia         varchar(480),
                        Obs                varchar(480),
                        Hoja               varchar(180),
                        Estado             varchar(10),
                        FecCre             datetime,
                        UseReg             int,
                        Hostname           varchar(180),
                        FecEdit            datetime,
                        UseEdit            int)", "SP_GUARDAR_REEMPLAZAR_SD_EFICIENCIAQC");
        }

        // Cuantos registros tiene ya ese año y semana en SD_EficienciaQC.
        public int ContarEficienciaQC(string anio, int semana)
        {
            using (var conexion = leerconexion())
            using (var comando = new SqlCommand("SP_CONTAR_SD_EFICIENCIAQC", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Anio", SqlDbType.VarChar, 80).Value = anio;
                comando.Parameters.Add("@Semana", SqlDbType.Int).Value = semana;

                conexion.Open();
                object resultado = comando.ExecuteScalar();
                return resultado == null || resultado == DBNull.Value ? 0 : Convert.ToInt32(resultado);
            }
        }


        // SD_CoberturaProgramadoQC: reemplaza el año y la semana completos (ver el SP).
        public void GuardarCoberturaProgramadoQC(DataTable datos)
        {
            CargaMasiva(datos, "#CoberturaProgramadoQC", @"CREATE TABLE #CoberturaProgramadoQC(
                        Empresa          varchar(80),
                        Sede             varchar(80),
                        [Año]            varchar(80),
                        Semana           int,
                        Zona             varchar(180),
                        Planta           varchar(180),
                        Fecha            date,
                        CantProy         int,
                        CantProyAjust    int,
                        Estado           varchar(10),
                        FecCre           datetime,
                        UseReg           int,
                        Hostname         varchar(180),
                        FecEdit          datetime,
                        UseEdit          int)", "SP_GUARDAR_REEMPLAZAR_SD_COBERTURAPROGRAMADOQC");
        }

        // Cuantos registros tiene ya ese año y semana en SD_CoberturaProgramadoQC.
        public int ContarCoberturaProgramadoQC(string anio, int semana)
        {
            using (var conexion = leerconexion())
            using (var comando = new SqlCommand("SP_CONTAR_SD_COBERTURAPROGRAMADOQC", conexion))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Anio", SqlDbType.VarChar, 80).Value = anio;
                comando.Parameters.Add("@Semana", SqlDbType.Int).Value = semana;

                conexion.Open();
                object resultado = comando.ExecuteScalar();
                return resultado == null || resultado == DBNull.Value ? 0 : Convert.ToInt32(resultado);
            }
        }

    }
}
