using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClaseNegocio
    {
        ClaseDatos objd = new ClaseDatos();
        #region Usuarios
        public DataTable N_ListaUsuarios()
        {
            return objd.D_ListaUsuarios();
        }

        public DataTable N_BuscarUsuario(ClaseEntidad obje)
        {
            return objd.D_BuscarUsuario(obje);
        }

        public string N_OpcionesUsuarios(ClaseEntidad obje)
        {
            return objd.D_OpcionesUsuarios(obje);
        }
        #endregion

        #region Pacientes
        public DataTable N_ListaPacientes()
        {
            return objd.D_ListaPacientes();
        }

        public DataTable N_BuscarPaciente(ClaseEntidad obje)
        {
            return objd.D_BuscarPaciente(obje);
        }

        public string N_OpcionesPacientes(ClaseEntidad obje)
        {
            return objd.D_OpcionesPacientes(obje);
        }
        #endregion

        #region Citas
        public DataTable N_ListaCita()
        {
            return objd.D_ListaCita();
        }

        public DataTable N_BuscarCitaN(ClaseEntidad obje)
        {
            return objd.D_BuscarCitaN(obje);
        }

        public DataTable N_BuscarCitaF(ClaseEntidad obje)
        {
            return objd.D_BuscarCitaF(obje);
        }


        public string N_OpcionesCitas(ClaseEntidad obje)
        {
            return objd.D_OpcionesCitas(obje);
        }
        #endregion
    }
}
