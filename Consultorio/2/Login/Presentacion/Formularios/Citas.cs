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

namespace Presentacion
{
    public partial class Citas : Form
    {
        ClaseEntidad objent = new ClaseEntidad();
        ClaseNegocio objneg = new ClaseNegocio();
        public Citas()
        {
            InitializeComponent();
        }

        void Limpiar()
        {
            txtCitaID.Text = "";
            txtNombrePaciente.Text = "";
            txtHora.Text = "";
            txtFechaCita.Text = "";
            txtMotivo.Text = "";
            txtConsultorio.Text = "";
            DgvCitas.DataSource = objneg.N_ListaCita();
        }

        private void Citas_Load(object sender, EventArgs e)
        {
            DgvCitas.DataSource = objneg.N_ListaCita();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        void Opciones(string Accion)
        {
            objent.CitaID = txtCitaID.Text;
            objent.NombrePaciente = txtNombrePaciente.Text;
            objent.Hora = txtHora.Text;
            objent.Dia= txtFechaCita.Text;
            objent.Motivo= txtMotivo.Text;
            objent.ConsultorioPreferencia= txtConsultorio.Text;
            objent.Accion = Accion;
            string Opc = objneg.N_OpcionesCitas(objent);
            MessageBox.Show(Opc, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (txtCitaID.Text != "")
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
           
            
                if (txtCitaID.Text != "")
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

            if (txtCitaID.Text != "")
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
                dt = objneg.N_BuscarCitaN(objent);
                DgvCitas.DataSource = dt;
            }
            else
            {
                DgvCitas.DataSource = objneg.N_ListaCita();
            }
        }

        private void txtBuscarFecha_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarFecha.Text != "")
            {
                objent.Dia = txtBuscarFecha.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_BuscarCitaF(objent);
                DgvCitas.DataSource = dt;
            }
            else
            {
                DgvCitas.DataSource = objneg.N_ListaCita();
            }
        }

        private void DgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Fila = DgvCitas.CurrentCell.RowIndex;

            txtCitaID.Text = DgvCitas[0, Fila].Value.ToString();
            txtHora.Text = DgvCitas[1, Fila].Value.ToString();
            txtFechaCita.Text = DgvCitas[2, Fila].Value.ToString();
            txtNombrePaciente.Text = DgvCitas[3, Fila].Value.ToString();
            txtMotivo.Text = DgvCitas[4, Fila].Value.ToString();
            txtConsultorio.Text = DgvCitas[5, Fila].Value.ToString();
        }
    }
}

