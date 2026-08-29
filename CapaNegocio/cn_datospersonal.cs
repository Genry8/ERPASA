using CapaDatos;
using System;
using System.Data;

namespace CapaNegocio
{
    public class cn_datospersonal
    {
        //metodo para buscar ultimo usuario registrado
        public static bool BuscUltimoUser()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.UltimoUsuario();
        }

        //metodo para listar es estado general
        public static DataTable ListEst()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaEstado();
        }

        //metodo para listar es estado civil del 
        public static DataTable ListEstCivil()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaEstadoCivil();
        }

        //metodo para listar es estado civil del 
        public static DataTable ListTipProfesion()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaTipoProfesional();
        }

        //metodo para listar el grupo profesional
        public static DataTable ListGrupoProfesion()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaGrupoProfesional();
        }

        //metodo para listar la sede
        public static DataTable ListSede()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaSede();
        }

        //metodo para listar ubigeo
        public static DataTable ListUbigeo()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaUbigeo();
        }

        //metodo para listar el área laboral
        public static DataTable ListAreaLab()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaAreaLaboral();
        }

        //metodo para listar la carga laboral
        public static DataTable ListCargaLab()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaCargaLaboral();
        }

        //metodo para listar condicion laboral
        public static DataTable ListConLab()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaCondLaboral();
        }

        //metodo para listar Jefe inmediato laboral
        public static DataTable ListJefInmed()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaJefeInmediato();
        }

        //metodo para listar deposito salarial
        public static DataTable ListDepSalario()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaDepositoSalarial();
        }

        //metodo para listar regimen laboral
        public static DataTable ListRegLaboral()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaRegimenLaboral();
        }

        //metodo para listar fondo pensiones
        public static DataTable ListFondoPens()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaFondoPensiones();
        }

        //metodo para listar ecolaridad
        public static DataTable ListEscolaridad()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaEscolaridad();
        }

        //metodo para listar almacenes
        public static DataTable ListAlmcen()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaAlmacenes();
        }

        //metodo para guardar usuario para almacen
        public static DataTable GuardarAlmacenUser(int usuario, string codalm, Boolean acceso)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.GuardarAlmacenesUsuario(usuario, codalm, acceso);
        }

        //metodo para guardar actualizar usuario para almacen
        public static DataTable ActualizarAlmacenUser(int usuario, string codalm, Boolean acceso)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ActualizarAlmacenesUsuario(usuario, codalm, acceso);
        }

        //metodo para guardar actualizar usuario para almacen
        public static DataTable EliminarAlmacenUser(int usuario)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.EliminarAlmacenesUsuario(usuario);
        }

        //metodo para guardar actualizar usuario para almacen
        public static DataTable ListAlmPersonCkeck(int usuario)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListPersonalCheck(usuario);
        }

        //metodo para listar ecolaridad
        public static DataTable ListEntidad()
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ListaEntidad();
        }

        //BUSCAR SI EXISTE EL PERSONAL
        public bool BuscaPersExist(int dni)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.BuscarPersonalExistente(dni);
        }

        //BUSCAR SI EXISTE FOTO FOTOSHECK
        public bool BuscaPersExistFotoFotosheck(string dni)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.BuscarExistenteFotoFotosheck(dni);
        }

        //BUSCAR PERSONAL PARA EDITAR DATPOS
        public bool BuscaPersDni(int dni)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.BuscarPersonalDni(dni);
        }

        //BUSCAR PERSONAL PARA EDITAR DATPOS
        public bool BuscaFotoFotosheck(string dni)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.BuscarFotoFotosheck(dni);
        }

        //metodo para listar formacion academica del personal
        public static DataTable BuscarPersForAcadem(int dni)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.BuscarPersonalFormAcademica(dni);
        }

        //metodo para guardar escolaridad del personal
        public static DataTable GuardPersonalEsco(int usecod, int siscod, string userusr, string desesc, DateTime fec_fin, string obsesc,
            string entesc, string estado, DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg,
            string hostname, string ip_pc, int usedoc)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.GuardarPersonalEscolaridad(usecod, siscod, userusr, desesc, fec_fin, obsesc,
             entesc, estado, fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc, usedoc);
        }

        //metodo para actualizar formacion academica personal
        public static DataTable ActuaFormAcademPersonal(int usecod, int siscod, string userusr,
            string desesc, DateTime fec_fin, string obsesc, string entesc, string estado, DateTime fec_mov, int usedoc)
        {
            cd_datospersonal datos = new cd_datospersonal();
            return datos.ActualizarPersonalForAcademica(usecod, siscod, userusr,
             desesc, fec_fin, obsesc, entesc, estado, fec_mov, usedoc);
        }

        //metodo para guardar personal
        public void GuardPersonal(int usecod, int siscod, string usepas, string usenam, string userusr,
            string useobs, string grupro, string grucod, string estado, DateTime fec_cre, DateTime fec_mov, int usereg, string usenamreg,
            string hostname, string ip_pc, string usetel, int usedoc, Byte[] imagen)
        {
            cd_datospersonal datos = new cd_datospersonal();
            datos.GuardarPersonal(usecod, siscod, usepas, usenam, userusr, useobs, grupro, grucod, estado,
                fec_cre, fec_mov, usereg, usenamreg, hostname, ip_pc, usetel, usedoc, imagen);
        }


        //metodo para guardar foto fotosheck
        public void GuardarFotoFotosheck(string dni,
            string apellidos, string nombres, Byte[] imagen)
        {
            cd_datospersonal datos = new cd_datospersonal();
            datos.GuardarFotoFotosheck(dni,
            apellidos, nombres, imagen);
        }


        //metodo para guardar personal detalle
        public void GuardPersonalDetalle(int usecod, int siscod, string useappat, string useapmat, string usenam, string userusr, string usersex,
            string useestciv, string usedom, string usemail, string useobs, DateTime fec_cre, DateTime fec_nac, string tipdoc, int usedoc, string grupro,
            string grucod, string usetel, string estado, string codarea, string codcar, string codcon, string codjef, string codformdep, DateTime fec_cece,
            string comt, string reglab, string fondpen, string codfondpen, int hrscontr, DateTime hr_ing, DateTime hr_sal, int hrtol, DateTime vac_ini,
            DateTime vac_fin, int usereg, string usenamreg, string hostname, string ip_pc)
        {
            cd_datospersonal datos = new cd_datospersonal();
            datos.GuardarPersonalDetalle(usecod, siscod, useappat, useapmat, usenam, userusr, usersex,
             useestciv, usedom, usemail, useobs, fec_cre, fec_nac, tipdoc, usedoc, grupro,
             grucod, usetel, estado, codarea, codcar, codcon, codjef, codformdep, fec_cece,
             comt, reglab, fondpen, codfondpen, hrscontr, hr_ing, hr_sal, hrtol, vac_ini,
             vac_fin, usereg, usenamreg, hostname, ip_pc);
        }

        //ELIMINAR PERSONAL
        public void EliminarPerson(int dni)
        {
            cd_datospersonal datos = new cd_datospersonal();
            datos.EliminarPersonal(dni);
        }

        //ELIMINAR PERSONAL
        public void EliminarPersonFormAcademica(int dni)
        {
            cd_datospersonal datos = new cd_datospersonal();
            datos.EliminarFormAcademicaPersonal(dni);
        }

        //metodo para actualizar personal
        public void ActuaPersonal(int usecod, int siscod, string usepas, string usenam, string userusr,
            string useobs, string grupro, string grucod, string estado, DateTime fec_mov,
            string usetel, int usedoc, Byte[] imagen)
        {
            cd_datospersonal datos = new cd_datospersonal();
            datos.ActualizarPersonal(usecod, siscod, usepas, usenam, userusr,
             useobs, grupro, grucod, estado, fec_mov,
             usetel, usedoc, imagen);
        }

        //metodo para actualizar personal
        public void ActuaFotoFotosheck(string dni,
            string apellidos, string nombres, Byte[] imagen)
        {
            cd_datospersonal datos = new cd_datospersonal();
            datos.ActualizarFotoFotosheck(dni,
            apellidos, nombres, imagen);
        }

        //metodo par
        //metodo para actualizar personal detalle
        public void ActuaPersonalDetalle(int usecod, int siscod, string useappat, string useapmat, string usenam, string userusr, string usersex,
            string useestciv, string usedom, string usemail, string useobs, DateTime fec_nac, string tipdoc, int usedoc, string grupro,
            string grucod, string usetel, string estado, string codarea, string codcar, string codcon, string codjef, string codformdep, DateTime fec_cece,
            string comt, string reglab, string fondpen, string codfondpen, int hrscontr, DateTime hr_ing, DateTime hr_sal, int hrtol, DateTime vac_ini,
            DateTime vac_fin)
        {
            cd_datospersonal datos = new cd_datospersonal();
            datos.ActualizarPersonalDetalle(usecod, siscod, useappat, useapmat, usenam, userusr, usersex,
             useestciv, usedom, usemail, useobs, fec_nac, tipdoc, usedoc, grupro,
             grucod, usetel, estado, codarea, codcar, codcon, codjef, codformdep, fec_cece,
             comt, reglab, fondpen, codfondpen, hrscontr, hr_ing, hr_sal, hrtol, vac_ini,
             vac_fin);
        }


    }
}
