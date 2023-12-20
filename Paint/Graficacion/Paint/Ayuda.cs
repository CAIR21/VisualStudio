using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Paint
{
    public partial class Ayuda : Form
    {
        string Opcion;
        Demostracion FormDemostracion = new Demostracion();
        public Ayuda()
        {
            InitializeComponent();             
        }
        #region Botones
        private void PtbLogo_Click(object sender, EventArgs e)
        {
            PtbImagen.BringToFront();
        }
        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            PnlOpciones.BringToFront();
        }
        private void BtnHerramientas_Click(object sender, EventArgs e)
        {
            PnlHerramientas.BringToFront();
        }
        private void BtnAtajos_Click(object sender, EventArgs e)
        {
            PnlAtajos.BringToFront();
        }
        #endregion
        #region Estetica, aqui esta el codigo para poder usar la barra personalizada
        #region Movimiento de la barra
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion
        #region Barra, Codigo para la barra personalizada
        private void BtnCerrar_Click(object sender, EventArgs e)//Click para cerrar la ventana
        {
            this.Close();//Cerrar la ventana y no toda la app
        }
        private void Barra_MouseDown(object sender, MouseEventArgs e)//Poder mover la app desde la barra personalizada
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        #endregion
        #region Asignar el ejemplo a mostar
        private void LblPixel_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Pixel";
            Acortar();
        }
        private void LblRecta_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Recta";
            Acortar();
        }
        private void LblIrregulares_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Irregular";
            Acortar();
        }
        private void LblRegulares_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Regular";
            Acortar();
        }
        private void LblCircunferencia_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Circunferencia";
            Acortar();
        }
        private void LblElipse_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Elipse";
            Acortar();
        }
        private void LblTrasladar_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Trasladar";
            Acortar();
        }
        private void LblRotacion_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Rotacion";
            Acortar();
        }
        private void LblEscalamiento_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Escalar";
            Acortar();
        }
        private void LblUnir_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Unir";
            Acortar();
        }
        private void LblFondo_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Fondo";
            Acortar();
        }
        private void LblLimpiar_MouseClick(object sender, MouseEventArgs e)
        {
            Opcion = "Limpiar";
            Acortar();
        }
        public void Acortar()
        {
            if (FormDemostracion == null)
            {
                FormDemostracion.Show();
            }
            else
            {
                FormDemostracion.Close();
                FormDemostracion = new Demostracion();
                FormDemostracion.TxtOpcion.Text = Opcion;
                FormDemostracion.Show();
            }
        }
        #endregion        
    }
}