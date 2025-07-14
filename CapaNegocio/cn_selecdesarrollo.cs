using CapaDatos;
using System;

namespace CapaNegocio
{
    public class cn_selecdesarrollo : cd_conexion
    {

        //metodo para buscar si existe codigo de usuario
        public static bool BuscExisteTrabajadorActivo(string cod, DateTime fecha)
        {
            cd_selecdesarrollo datos = new cd_selecdesarrollo();
            return datos.BuscExisteTrabajadorActivo(cod, fecha);
        }


        //GUARDAR TRANSPORTE VIAJES
        public void GuardarTrabActivo(string Sec, string Dni, string ApeNom, string FecPost, string HoraPost
            , string StatusPost, string Condicion, string Huella, string StatusFirma, string UserFirma

            , string FechaFirma, string StatusTrab, DateTime FecIngreso, string Empresa, string Sede
            , string Cargo, string FecNac, string Genero, string IniContrato, string FinContrato

            , string FecCese, string Telefono, string Correo, string Pais, string Departamento
            , string ProvinciaDni, string DistritoDni, string DireccionDNI, string CambioDireccion, string DepartamentoActual

            , string ProvinciaActual, string DistritoActual, string DireccionActual, string LugarProcedencia, string Localidad
            , string ModeloContrato, string Area, string SubArea, string Gerencia, string FecImpContrato

            , string HoraImpContrato, string TipoTrabajador, string TipoDocumento, string TipoPersonal, string ExamenMedico
            , string ResultExaMedico, string LlegadaPostulante, string DniJalador, string NombreJalador, string Discapacidad

            , string NroCarneDiscapacidad, string TipoDiscapacidad, string PlacaTransporte, string RegimenLaboral, decimal Sueldo
            , string EstadoCivil, string TipoCuentaBanc, string Banco, string NroCuenta, string NroCuentaCCI

            , string CatPensionista, string GradoInstruccion, string CatOcupacional, string PeriodoPago, string TipoPago
            , string Situacion, string TrabHorNocturno, string JornTrabMax, string RegimenAtipico, string CodPlanilla

            , string CodTipTrabajo, string CodSucursal, string GrupoProvision, string LeyLaboral, string hoja
            , DateTime fec_cre, int usereg, string hostname, DateTime fec_mov, int usedit)
        {
            cd_selecdesarrollo datos = new cd_selecdesarrollo();
            datos.GuardarTrabActivo(Sec, Dni, ApeNom, FecPost, HoraPost
            , StatusPost, Condicion, Huella, StatusFirma, UserFirma, FechaFirma
            , StatusTrab, FecIngreso, Empresa, Sede, Cargo, FecNac
            , Genero, IniContrato, FinContrato, FecCese, Telefono, Correo, Pais
            , Departamento, ProvinciaDni, DistritoDni, DireccionDNI, CambioDireccion, DepartamentoActual
            , ProvinciaActual, DistritoActual, DireccionActual, LugarProcedencia, Localidad
            , ModeloContrato, Area, SubArea, Gerencia, FecImpContrato
            , HoraImpContrato, TipoTrabajador, TipoDocumento, TipoPersonal, ExamenMedico
            , ResultExaMedico, LlegadaPostulante, DniJalador, NombreJalador, Discapacidad
            , NroCarneDiscapacidad, TipoDiscapacidad, PlacaTransporte
            , RegimenLaboral, Sueldo, EstadoCivil, TipoCuentaBanc
            , Banco, NroCuenta, NroCuentaCCI, CatPensionista, GradoInstruccion
            , CatOcupacional, PeriodoPago, TipoPago, Situacion, TrabHorNocturno
            , JornTrabMax, RegimenAtipico, CodPlanilla, CodTipTrabajo
            , CodSucursal, GrupoProvision, LeyLaboral
            , hoja, fec_cre, usereg, hostname
            , fec_mov, usedit);
        }



        //ACTUALIZAR TRANSPORTE VIAJES
        public void ActualizarTrabActivo(string Sec, string Dni, string ApeNom, string FecPost, string HoraPost
            , string StatusPost, string Condicion, string Huella, string StatusFirma, string UserFirma

            , string FechaFirma, string StatusTrab, DateTime FecIngreso, string Empresa, string Sede
            , string Cargo, string FecNac, string Genero, string IniContrato, string FinContrato

            , string FecCese, string Telefono, string Correo, string Pais, string Departamento
            , string ProvinciaDni, string DistritoDni, string DireccionDNI, string CambioDireccion, string DepartamentoActual

            , string ProvinciaActual, string DistritoActual, string DireccionActual, string LugarProcedencia, string Localidad
            , string ModeloContrato, string Area, string SubArea, string Gerencia, string FecImpContrato

            , string HoraImpContrato, string TipoTrabajador, string TipoDocumento, string TipoPersonal, string ExamenMedico
            , string ResultExaMedico, string LlegadaPostulante, string DniJalador, string NombreJalador, string Discapacidad

            , string NroCarneDiscapacidad, string TipoDiscapacidad, string PlacaTransporte, string RegimenLaboral, decimal Sueldo
            , string EstadoCivil, string TipoCuentaBanc, string Banco, string NroCuenta, string NroCuentaCCI

            , string CatPensionista, string GradoInstruccion, string CatOcupacional, string PeriodoPago, string TipoPago
            , string Situacion, string TrabHorNocturno, string JornTrabMax, string RegimenAtipico, string CodPlanilla

            , string CodTipTrabajo, string CodSucursal, string GrupoProvision, string LeyLaboral, string hoja
            , DateTime fec_mov, int usedit)
        {
            cd_selecdesarrollo datos = new cd_selecdesarrollo();
            datos.ActualizarTrabActivo(Sec, Dni, ApeNom, FecPost, HoraPost
            , StatusPost, Condicion, Huella, StatusFirma, UserFirma, FechaFirma
            , StatusTrab, FecIngreso, Empresa, Sede, Cargo, FecNac
            , Genero, IniContrato, FinContrato, FecCese, Telefono, Correo, Pais
            , Departamento, ProvinciaDni, DistritoDni, DireccionDNI, CambioDireccion, DepartamentoActual
            , ProvinciaActual, DistritoActual, DireccionActual, LugarProcedencia, Localidad
            , ModeloContrato, Area, SubArea, Gerencia, FecImpContrato
            , HoraImpContrato, TipoTrabajador, TipoDocumento, TipoPersonal, ExamenMedico
            , ResultExaMedico, LlegadaPostulante, DniJalador, NombreJalador, Discapacidad
            , NroCarneDiscapacidad, TipoDiscapacidad, PlacaTransporte
            , RegimenLaboral, Sueldo, EstadoCivil, TipoCuentaBanc
            , Banco, NroCuenta, NroCuentaCCI, CatPensionista, GradoInstruccion
            , CatOcupacional, PeriodoPago, TipoPago, Situacion, TrabHorNocturno
            , JornTrabMax, RegimenAtipico, CodPlanilla, CodTipTrabajo
            , CodSucursal, GrupoProvision, LeyLaboral
            , hoja, fec_mov, usedit);
        }

    }

}