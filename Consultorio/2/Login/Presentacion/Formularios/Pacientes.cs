using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using CapaEntidad;
using CapaNegocio;

namespace Presentacion
{
    public partial class Pacientes : Form
    {
        ClaseEntidad objent = new ClaseEntidad();
        ClaseNegocio objneg = new ClaseNegocio();
        public Pacientes()
        {
            InitializeComponent();
        }

        void Opciones(string Accion)
        {
            objent.PacienteID = txtPacienteID.Text;
            objent.NombrePaciente = txtNombrePaciente.Text;
            objent.Edad = Convert.ToInt32(txtEdad.Text);
            objent.TipoSangre = txtTipoSangre.Text;
            objent.Direccion = txtDireccion.Text;
            objent.PolizaSeguro = txtPoliza.Text;
            objent.CorreoPaciente = txtCorreo.Text;
            objent.CelularPaciente = txtCelularPaciente.Text;
            objent.Accion = Accion;
            string Opc = objneg.N_OpcionesPacientes(objent);
            MessageBox.Show(Opc, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Limpiar()
        {
            txtPacienteID.Text = "";
            txtNombrePaciente.Text = "";
            txtEdad.Text = "";
            txtTipoSangre.Text = "";
            txtDireccion.Text = "";
            txtPoliza.Text = "";
            txtCorreo.Text = "";
            txtCelularPaciente.Text = "";
            txtBuscar.Text = "";
            DgvPacientes.DataSource = objneg.N_ListaPacientes();
        }
        //SqlConnection Conexion = new SqlConnection("Server = CAIR\\CAIR; DataBase= Consultorio; integrated security = true");

        /*private void VerPacientes_Click(object sender, EventArgs e)
         {
             SqlCommand Tabla = new SqlCommand("Select * From Usuarios",Conexion);
             SqlDataAdapter adaptador = new SqlDataAdapter();
             adaptador.SelectCommand = Tabla;
             DataTable coso = new DataTable();
             adaptador.Fill(coso);
             GvPacientes.DataSource = coso;
         }*/

        private void Pacientes_Load(object sender, EventArgs e)
        {

            DgvPacientes.DataSource = objneg.N_ListaPacientes();

            /*string Consulta = "Selec * From Pacientes";
            SqlDataAdapter Adaptador = new SqlDataAdapter(Consulta, Conexion);
            DataTable Dt = new DataTable();
            Adaptador.Fill(Dt);
            GvPacientes.DataSource = Dt;*/
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtPacienteID.Text != "")
            {
                if (MessageBox.Show("¿Quiere registrar a " + txtNombrePaciente.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Opciones("1");
                    Limpiar();
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtPacienteID.Text != "")
            {
                if (MessageBox.Show("¿Quiere modificar a " + txtNombrePaciente.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Opciones("2");
                    Limpiar();
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtPacienteID.Text != "")
            {
                if (MessageBox.Show("¿Quiere eliminar a " + txtNombrePaciente.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Opciones("3");
                    Limpiar();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                objent.NombrePaciente = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_BuscarPaciente(objent);
                DgvPacientes.DataSource = dt;
            }
            else
            {
                DgvPacientes.DataSource = objneg.N_ListaPacientes();
            }
        }

        private void DgvPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Fila = DgvPacientes.CurrentCell.RowIndex;

            txtPacienteID.Text = DgvPacientes[0, Fila].Value.ToString();
            txtNombrePaciente.Text = DgvPacientes[1, Fila].Value.ToString();
            txtEdad.Text = DgvPacientes[2, Fila].Value.ToString();
            txtTipoSangre.Text = DgvPacientes[3, Fila].Value.ToString();
            txtDireccion.Text = DgvPacientes[4, Fila].Value.ToString();
            txtPoliza.Text = DgvPacientes[5, Fila].Value.ToString();
            txtCorreo.Text = DgvPacientes[6, Fila].Value.ToString();
            txtCelularPaciente.Text = DgvPacientes[7, Fila].Value.ToString();
        }
    }
}
