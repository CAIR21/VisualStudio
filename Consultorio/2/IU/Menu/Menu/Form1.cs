using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            customizeDesing();
        }
        private void customizeDesing()
        {
            panelPacSubMen.Visible = false;
            panelCitSubMen.Visible = false;
            panelHisSubMen.Visible = false;
            panelRecSubMen.Visible = false;
        }
        private void hidesubmenu()
        {
            if (panelPacSubMen.Visible == true)
            {
                panelPacSubMen.Visible = false;
            }
            if (panelCitSubMen.Visible == true)
            {
                panelCitSubMen.Visible = false;
            }
            if (panelHisSubMen.Visible == true)
            {
                panelHisSubMen.Visible = false;
            }
            if (panelRecSubMen.Visible == true)
            {
                panelRecSubMen.Visible = false;
            }
        }
        private void showSubMenu(Panel SubMen)
        {
            if (SubMen.Visible == false)
            {
                customizeDesing();
                SubMen.Visible = true;
            }
            else
                SubMen.Visible = false;
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPacSubMen);
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCitSubMen);
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHisSubMen);
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelRecSubMen);
        }

        private void btnVerPacientes_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Form2());
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void btnAñadirPacientes_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Form3());
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();
        }
        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFijo.Controls.Add(childForm);
            panelFijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
