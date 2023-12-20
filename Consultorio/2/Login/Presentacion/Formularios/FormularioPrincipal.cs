using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comun.Cache;
using System.Runtime.InteropServices;

namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            customizeDesing();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #region iniciar con los submenus ocultos
        private void customizeDesing()//Metodo para comenzar con los submenus ocultos
        {
            panelPacSubMen.Visible = false;
            panelCitSubMen.Visible = false;
            panelHisSubMen.Visible = false;
            panelRecSubMen.Visible = false;
        }
        #endregion
        #region ocultar submenus
        private void hidesubmenu()//Metodo para ocultar un submenu al abrir otro
        {
            if (panelPacSubMen.Visible == true)//Pacientes
            {
                panelPacSubMen.Visible = false;
            }
            if (panelCitSubMen.Visible == true)//Citas
            {
                panelCitSubMen.Visible = false;
            }
            if (panelHisSubMen.Visible == true)//Historial
            {
                panelHisSubMen.Visible = false;
            }
            if (panelRecSubMen.Visible == true)//Recetas
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
        #endregion
        #region Botones para mostar el submenu
        private void btnPacientes_Click(object sender, EventArgs e)
        {
            showSubMenu(panelPacSubMen);//Mostrar el submenu de los pacientes
        }
    
        private void btnCitas_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCitSubMen);//Mostrar el submenu de las citas
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHisSubMen);//Mostrar el submenu del historial
        }

        private void btnRecetas_Click(object sender, EventArgs e)
        {
            Forms(new Recetas());
            //showSubMenu(panelRecSubMen);//Mostrar el submenu de recetas
        }
#endregion
        #region Usuarios
        private void btnAnadirUsuario_Click(object sender, EventArgs e)
        {
            Forms(new Formularios.Usuarios());
            hidesubmenu();//Ocultar SubMenu
        }
#endregion
        #region SubMenuPacientes
        private void btnVerPacientes_Click(object sender, EventArgs e)
        {
            Forms(new Pacientes());
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }

        private void btnAñadirPacientes_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }
#endregion
        #region SubMenuCitas
        private void btnVerCitas_Click(object sender, EventArgs e)
        {
            Forms(new Citas());
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }

        private void btnAnadirCita_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }

        private void btnEliminarCita_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }
#endregion
        #region SubMenuHistorial
        private void btnVerHistoriales_Click(object sender, EventArgs e)
        {
            Forms(new Historial());
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }

        private void btnAnadirHistorial_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }

        private void btnEliminarHistorial_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }
#endregion
        #region BotonesSubmenuRecetas
        private void btnVerRecetas_Click(object sender, EventArgs e)
        {
            Forms(new Recetas());
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }

        private void btnAnadirReceta_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }

        private void btnEliminarReceta_Click(object sender, EventArgs e)
        {
            /*Codigo
             * 
             **/
            hidesubmenu();//Ocultar SubMenu
        }
        #endregion
        #region Formularios de los submenus
        private Form activeForm = null;
        private void Forms(Form FormSubMenu)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = FormSubMenu;
            FormSubMenu.TopLevel = false;
            FormSubMenu.FormBorderStyle = FormBorderStyle.None;
            FormSubMenu.Dock = DockStyle.Fill;
            panelFijo.Controls.Add(FormSubMenu);
            panelFijo.Tag = FormSubMenu;
            FormSubMenu.BringToFront();
            FormSubMenu.Show();
        }
        #endregion
        #region Cerrar Sesion
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar su sesion?", "Advertencia",
           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        #endregion
        #region CargarDatosCache
        private void FormPrincipal_Load_1(object sender, EventArgs e)
        {
            //invocacion de metodos
            LoadUserData();
            ManagePermissions();

        }

        private void LoadUserData()//Metodo para cargar los datos de los usuarios
        {
            lblRango.Text = UserLoginCache.Rango;
            lblNombre.Text = UserLoginCache.NombreUsuario;
            lblCelular.Text = UserLoginCache.CelularUsuario;
        }

        private void ManagePermissions()//Metodo encargado de los permisos
        {
            #region Imagenes
            if(UserLoginCache.Sesion=="CAIR")
            {
                pictureBox3.Visible = true;//Este se elimina nomas ando jugando con las fotos
            }
            if (UserLoginCache.Sesion == "MOIS")
            {
                pictureBox4.Visible = true;//Este se elimina nomas ando jugando con las fotos
            }
            if (UserLoginCache.Sesion == "DANI")
            {
 
            }
            #endregion
            if (UserLoginCache.Rango == Permisos.Administrador)//Seleccionar los permisos para el administrador
            {
                
            }
            if (UserLoginCache.Rango == Permisos.Doctor)//Seleccionar los permisos para el doctor
            {
                btnAnadirUsuario.Visible = false;//Ocultar boton
            }
            if (UserLoginCache.Rango == Permisos.Recepcionista)//Seleccionar los permisos para el recepcionista
            {
                //Ocultar botones
                btnAnadirUsuario.Visible = false;
                btnHistorial.Visible = false;
                btnEliminarReceta.Visible = false;
                btnAnadirReceta.Visible = false;
            }
        }
        #endregion
        #region barra
        private void btnMinimizarMenu_Click(object sender, EventArgs e)//Metodo para minimizar la aplicacion
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int Lx, Ly, Sw, Sh;//Vartiables para guardar la pósicion de la pantalla y poder restaurarla

        private void btnMaximizarMenu_Click(object sender, EventArgs e)//Metodo para maximizar la aplicacion
        {
            Lx = this.Location.X;
            Ly = this.Location.Y;
            Sw = this.Size.Width;
            Sh = this.Size.Height;
            btnMaximizarMenu.Visible = false;
            btnMin.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //this.WindowState = FormWindowState.Maximized;<--Esta funcion no se usara ya que genera que se guarde la posicion maximizada
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            btnMaximizarMenu.Visible = true;
            btnMin.Visible = false;
            this.Size = new Size(Sw,Sh);
            this.Location = new Point(Lx, Ly);
        }

        private void btnCerrarMenu_Click(object sender, EventArgs e)//Metodo para salir de la aplicacion
        {
            if (MessageBox.Show("Realmente quieres cerrar la aplicaion?", "Advertencia",
           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)//Lanzar cuadro de dialogo antes de cerrar
                Application.Exit();
        }

        private void panelMenu_MouseDown(object sender, MouseEventArgs e)//Metodo para darle movimiento al formulario
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        
    }
}