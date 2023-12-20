using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace Presentacion.Formularios
{
    public partial class Usuarios : Form
    {
        ClaseEntidad objent = new ClaseEntidad();
        ClaseNegocio objneg = new ClaseNegocio();
        public Usuarios()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtUsuarioID.Text = "";
            txtSesion.Text = "";
            txtContra.Text = "";
            txtNombreUsuario.Text = "";
            txtRango.Text = "";
            txtCelularUsuario.Text = "";
            txtBuscar.Text = "";
            DgvUsuarios.DataSource = objneg.N_ListaUsuarios();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            DgvUsuarios.DataSource = objneg.N_ListaUsuarios();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        void Opciones (string Accion)
        {
            objent.UsuarioID = txtUsuarioID.Text;
            objent.Sesion = txtSesion.Text;
            objent.Contra = txtContra.Text;
            objent.NombreUsuario = txtNombreUsuario.Text;
            objent.Rango = txtRango.Text;
            objent.CelularUsuario = txtCelularUsuario.Text;
            objent.Accion = Accion;
            string Opc = objneg.N_OpcionesUsuarios(objent);
            MessageBox.Show(Opc, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtRango.Text == "Administrador"|| txtRango.Text == "Doctor"|| txtRango.Text == "Recepcionista")
            { 
                if (txtUsuarioID.Text != "")
                {
                    if (MessageBox.Show("¿Quiere registrar a " + txtNombreUsuario.Text + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Opciones("1");
                        Limpiar();
                    }
                }
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtRango.Text == "Administrador" || txtRango.Text == "Doctor" || txtRango.Text == "Recepcionista")
            {
                if (txtUsuarioID.Text != "")
                {
                    if (MessageBox.Show("¿Quiere modificar a " + txtNombreUsuario.Text + "?", "Mensaje",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Opciones("2");
                        Limpiar();
                    }
                }
            }
            
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (txtUsuarioID.Text != "")
            {
                if (MessageBox.Show("¿Quiere eliminar a " + txtNombreUsuario.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Opciones("3");
                    Limpiar();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if(txtBuscar.Text !="")
            {
                objent.NombreUsuario = txtBuscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_BuscarUsuario(objent);
                DgvUsuarios.DataSource = dt;
            }
            else
            {
                DgvUsuarios.DataSource = objneg.N_ListaUsuarios();
            }
        }

        private void DgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Fila = DgvUsuarios.CurrentCell.RowIndex;

            txtUsuarioID.Text = DgvUsuarios[0, Fila].Value.ToString();
            txtSesion.Text = DgvUsuarios[1, Fila].Value.ToString();
            txtContra.Text = DgvUsuarios[2, Fila].Value.ToString();
            txtNombreUsuario.Text = DgvUsuarios[3, Fila].Value.ToString();
            txtRango.Text = DgvUsuarios[4, Fila].Value.ToString();
            txtCelularUsuario.Text = DgvUsuarios[5, Fila].Value.ToString();
        }
    }
}
