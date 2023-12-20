using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Demostracion : Form
    {
        public Demostracion()
        {
            InitializeComponent();
        }
        private void TxtOpcion_TextChanged(object sender, EventArgs e)
        {
            switch (TxtOpcion.Text)
            {
                case "Pixel":
                    PtbPixel.Visible = true;
                    break;
                case "Recta":
                    PtbRecta.Visible = true;
                    break;
                case "Irregular":
                    PtbIrregular.Visible = true;
                    break;
                case "Regular":
                    PtbRegular.Visible = true;
                    break;
                case "Circunferencia":
                    PtbCircunferencia.Visible = true;
                    break;
                case "Elipse":
                    PtbElipse.Visible = true;
                    break;
                case "Trasladar":
                    PtbTrasladar.Visible = true;
                    break;
                case "Rotacion":
                    PtbRotacion.Visible = true;
                    break;
                case "Escalar":
                    PtbEscalamiento.Visible = true;
                    break;
                case "Unir":
                    PtbUnir.Visible = true;
                    break;
                case "Fondo":
                    PtbFondo.Visible = true;
                    break;
                case "Limpiar":
                    PtbLimpiar.Visible = true;
                    break;
            }
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
