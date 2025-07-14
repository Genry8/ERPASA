
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






    }
}