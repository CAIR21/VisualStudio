using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;

namespace CapaDatos
{
    public class ClaseDatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        #region SpUsuarios
        public DataTable D_ListaUsuarios()
        {
            SqlCommand cmd = new SqlCommand("SP_ListaUsuarios", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_BuscarUsuario(ClaseEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("SP_BuscarUsuario", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", obje.NombreUsuario);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public string D_OpcionesUsuarios(ClaseEntidad obje)
        {
            string Accion = "";
            SqlCommand cmd = new SqlCommand("SP_OpcionesUsuarios", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuarioID", obje.UsuarioID);
            cmd.Parameters.AddWithValue("@Sesion", obje.Sesion);
            cmd.Parameters.AddWithValue("@Contra", obje.Contra);
            cmd.Parameters.AddWithValue("@NombreUsuario", obje.NombreUsuario);
            cmd.Parameters.AddWithValue("@Rango", obje.Rango);
            cmd.Parameters.AddWithValue("@CelularUsuario", obje.CelularUsuario);
            cmd.Parameters.Add("@Accion", SqlDbType.VarChar, 50).Value = obje.Accion;
            cmd.Parameters["@Accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            Accion = cmd.Parameters["@Accion"].Value.ToString();
            cn.Close();
            return Accion;
        }
        #endregion

        #region SpPacientes
        public DataTable D_ListaPacientes()
        {
            SqlCommand cmd = new SqlCommand("SP_ListaPacientes", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_BuscarPaciente(ClaseEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("SP_BuscarPaciente", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", obje.NombrePaciente);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public string D_OpcionesPacientes(ClaseEntidad obje)
        {
            string Accion = "";
            SqlCommand cmd = new SqlCommand("SP_OpcionesPacientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PacienteID", obje.PacienteID);
            cmd.Parameters.AddWithValue("@NombrePaciente", obje.NombrePaciente);
            cmd.Parameters.AddWithValue("@Edad", obje.Edad);
            cmd.Parameters.AddWithValue("@TipoSangre", obje.TipoSangre);
            cmd.Parameters.AddWithValue("@Direccion", obje.Direccion);
            cmd.Parameters.AddWithValue("@PolizaSeguro", obje.PolizaSeguro);
            cmd.Parameters.AddWithValue("@CorreoPaciente", obje.CorreoPaciente);
            cmd.Parameters.AddWithValue("@CelularPaciente", obje.CelularPaciente);
            cmd.Parameters.Add("@Accion", SqlDbType.VarChar, 50).Value = obje.Accion;
            cmd.Parameters["@Accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            Accion = cmd.Parameters["@Accion"].Value.ToString();
            cn.Close();
            return Accion;
        }
        #endregion

        #region SpCitas
        public DataTable D_ListaCita()
        {
            SqlCommand cmd = new SqlCommand("SP_ListaCita", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable D_BuscarCitaN(ClaseEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("SP_BuscarCitaN", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", obje.NombreUsuario);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public DataTable D_BuscarCitaF(ClaseEntidad obje)
        {
            SqlCommand cmd = new SqlCommand("SP_BuscarCitaF", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fecha", obje.Dia);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        public string D_OpcionesCitas(ClaseEntidad obje)
        {
            string Accion = "";
            SqlCommand cmd = new SqlCommand("SP_OpcionesCitas", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CitaID", obje.CitaID);
            cmd.Parameters.AddWithValue("@NombrePaciente", obje.NombrePaciente);
            cmd.Parameters.AddWithValue("@Hora", obje.Hora);
            cmd.Parameters.AddWithValue("@Dia", obje.Dia);
            cmd.Parameters.AddWithValue("@Motivo", obje.Motivo);
            cmd.Parameters.AddWithValue("@Consultorio", obje.ConsultorioPreferencia);
            cmd.Parameters.Add("@Accion", SqlDbType.VarChar, 50).Value = obje.Accion;
            cmd.Parameters["@Accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            Accion = cmd.Parameters["@Accion"].Value.ToString();
            cn.Close();
            return Accion;
        }
        #endregion
    }
}
