using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Paint : Form
    {
        #region Variables, Aqui se encuentran todas las variables usadas
        Color Micolor,Seleccion,BTras,Relleno,Linea;//Establecer el color/Seleccionar el color de el objeto seleccionado/Eliminar la figura al trasladar/Aux para relleno/aux para linea
        Bitmap Lienzo;//Establecer la zona de pintado
        int Tamaño, Contador, Lados, Radio,Rx,Ry, Xc,Yc,Tx,Ty,Angulo,Auxiliar;//Establecer los tamaños del pincel/ Contador para los estilos/Radio/RadiosX y Y/Xc y Yc guardan centro de la figura/Tx y Ty cuanto se va a trasladar a cada lado/Guardar angulo de rotacion/Manipular los radios dentro del elipse
        List<Point> Puntos, Aux, Aux2,Aux3,Aux4,PuntosTG,PuntosT;//Establecer una lista para guardar los puntos/Auxiliares para los metodos/Guarda la informacion de la figura a trasladar/Nueva figura(Ya trasladada)
        string Opcion, Estilo, Id, Fill;//Establecer los cambios de botones de menu
        float Sx, Sy;//Variables para incrementar o decrementar el tamaño
        Form FormAyuda;//Establecer el formulario para el menu de ayuda
        #endregion
        #region Inicializar variables, aqui se encuentran las variables ya inicializadas
        public Paint()
        {
            InitializeComponent();
            Micolor = Color.Black;//Color por defecto negro
            Seleccion = Color.YellowGreen;//Cambiar el color del boton seleccionado de forma global y no uno por uno
            BTras = Color.FromArgb(0, 0, 0, 0);//Borrar las figuras despues de trasladarlas
            Lienzo = new Bitmap(PtbLienzo.Width, PtbLienzo.Height);//Tamaño del lienzo por defecto
            Id = "Pixel";//Sirve para inicializarlo sin ningun id y que no marque variable sin utilizar
            Opcion = "Pixel";//Colocar pixeles por defecto
            Estilo = "Continua";//Colocar lineas continuas al seleccionar la recta
            Tamaño = 0;//Tamaño inicial del pincel
            Radio = 100;//Tamaño que tendran los poligonos
            Rx = 150;//Radio X del elipse
            Ry = 100; //Radio Y del elipse
            Angulo = 45;//Grados que rotara la figura en la opcion de rotacion
            Puntos = new List<Point>();//Lista de los puntos
            Aux = new List<Point>();//Auxiliar para el metodo de poligono irregular
            Aux2 = new List<Point>();//Auxiliar para el metodo de poligono regular
            Aux3 = new List<Point>();//Auxiliar para unir los puntos
            Aux4 = new List<Point>();//Auxiliar para rotar
            PuntosTG = new List<Point>();
            PuntosT = new List<Point>();
            FormAyuda = new Ayuda();//Inicilizar el formulario de ayuda 
        }
        #endregion
        #region Botones, aqui se encuentran todos los codigos relacionados a los botones
        #region Colores, aqui se encuentra el codigo de los botones para seleccionar un color
        private void BtnBlack_Click(object sender, EventArgs e)//Click sobre el boton de color negro
        {
            Micolor = Color.Black; ; //Seleccionar color del boton presionado para colorear
            Colores(Micolor);//Llamar al metodo para asignarle el mismo color al resto
        }
        private void BtnWhite_Click(object sender, EventArgs e)//Click sobre el boton de color blanco
        {
            Micolor = Color.White; //Seleccionar color del boton presionado para colorear
            Colores(Micolor);
        }
        private void BtnGray_Click(object sender, EventArgs e)//Click sobre el boton de color gris
        {
            Micolor = Color.Gray; //Seleccionar color del boton presionado para colorear
            Colores(Micolor);
        }
        private void BtnYellow_Click(object sender, EventArgs e)//Click sobre el boton de color amarillo
        {
            Micolor = Color.Yellow; //Seleccionar color del boton presionado para colorear
            Colores(Micolor);
        }
        private void BtnRed_Click(object sender, EventArgs e)//Click sobre el boton de color rojo
        {
            Micolor = Color.Red; //Seleccionar color del boton presionado para colorear
            Colores(Micolor);
        }
        private void BtnBlue_Click(object sender, EventArgs e)//Click sobre el boton de color azul
        {
            Micolor = Color.Blue; //Seleccionar color del boton presionado para colorear
            Colores(Micolor);
        }
        private void BtnPurple_Click(object sender, EventArgs e)//Click sobre el boton de color morado
        {
            Micolor = Color.Purple; //Seleccionar color del boton presionado para colorear
            Colores(Micolor);
        }
        private void BtnGreen_Click(object sender, EventArgs e)//Click sobre el boton de color verde
        {
            Micolor = Color.Green; //Seleccionar color del boton presionado para colorear
            Colores(Micolor);

        }
        private void BtnPaleta_Click(object sender, EventArgs e) //Click sobre el boton para despegar la paleta de colores
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK) //Condicional para cambiar el color si fue seleccionado o dejar el mismo en caso contrario
            {
                Micolor = colorDialog1.Color; //Seleccionar como color para pintar, el color seleccionado en la paleta
                Colores(Micolor);
            }
        }
        #endregion
        #region Estilos, aqui se encuentra el codigo de los botones para seleccionar el tipo de linea
        private void BtnContinua_Click(object sender, EventArgs e)//Click sobre el boton de linea continua
        {
            Estilo = "Continua";//Seleccionar el tipo de recta a dibujar
        }
        private void BtnPunteada_Click(object sender, EventArgs e)//Click sobre el boton de linea punteada
        {
            Estilo = "Punteada";
        }
        private void BtnSegmentada_Click(object sender, EventArgs e)//Click sobre el boton de linea segmentada
        {
            Estilo = "Segmentada";
        }
        #endregion
        #region Menu, aqui se encuentra el codigo del menustrip para seleccionar la herramienta a usar
        private void PixelToolStripMenuItem_Click(object sender, EventArgs e)//Click para seleccionar el pixel como herramienta
        {
            Opcion = "Pixel";//Seleccionar la herramienta a utilizar
            SeleccionC();
            PixelToolStripMenuItem.BackColor = Seleccion;//Cambiar fondo al seleccionarlo
            Fill = "";
        }
        private void RectaToolStripMenuItem_Click(object sender, EventArgs e)//Click para seleccionar la recta como herramienta
        {
            Opcion = "Recta";
            SeleccionC();
            RectaToolStripMenuItem.BackColor = Seleccion;
            Fill = "";
        }
        private void IrregularesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Poligono Irregular";
            SeleccionC();
            ToolStripTxbNumeroL.Text = "";//Limpiar el textbox al volver a seleccionarla
            PoligonosToolStripMenuItem.BackColor = Seleccion;
            IrregularesToolStripMenuItem.BackColor = Seleccion;
            Fill = "";
        }
        private void ToolStripTxbNumeroL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || (e.KeyChar >= 58 && e.KeyChar <= 255)))//Prohibir el ingrese de caracteres que no sean numeros al textbox
            {
                MessageBox.Show("Favor de ingresar numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); //Para tirar una advertencia de no introducir letras
                e.Handled = true;
                return;
            }
        }
        private void RegularesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Poligono Regular";
            SeleccionC();
            NumeroLRToolStrip.Text = "";
            Lados = 0;//Reinicar los lados para que no se quede guardada otra figura si se selecciona la textbox y queda vacia
            PoligonosToolStripMenuItem.BackColor = Seleccion;
            RegularesToolStripMenuItem.BackColor = Seleccion;
            Fill = "";
        }
        private void NumeroLRToolStrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47 || (e.KeyChar >= 58 && e.KeyChar <= 255)))//Prohibir el ingrese de caracteres que no sean numeros al textbox 
            {
                MessageBox.Show("Favor de ingresar numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); //Para tirar una advertencia de no introducir letras
                e.Handled = true;
                return;
            }
        }
        #region Poligonos regulares
        private void TrianguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lados = 3;//Lados a dibujar dentro de la circunferencia
        }
        private void CuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lados = 4;
        }
        private void PentagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lados = 5;
        }
        private void HexagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lados = 6;
        }
        private void HeptagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lados = 7;
        }
        private void OctagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lados = 8;
        }
        private void EneagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lados = 9;
        }
        private void DecagonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lados = 10;
        }
        #endregion
        private void CircunferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Circunferencia";
            SeleccionC();
            CircunferenciaToolStripMenuItem.BackColor = Seleccion;
            Fill = "";
        }
        private void ElipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Elipse";
            SeleccionC();
            ElipseToolStripMenuItem.BackColor = Seleccion;
            Fill = "";
        }
        private void TrasladarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Trasladar";
            SeleccionC();
            TrasladarToolStripMenuItem.BackColor = Seleccion;
        }
        private void RotacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Rotar";
            SeleccionC();
            RotacionToolStripMenuItem.BackColor = Seleccion;
        }
        private void IncrementarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Escalar";
            Sx = 1.1F;
            Sy = 1.1F;
            SeleccionC();
            escalarToolStripMenuItem.BackColor = Seleccion;
            IncrementarToolStripMenuItem.BackColor = Seleccion;
        }
        private void DecrementarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Escalar";
            Sx = 0.9F;
            Sy = 0.9F;
            SeleccionC();
            escalarToolStripMenuItem.BackColor = Seleccion;
            DecrementarToolStripMenuItem.BackColor = Seleccion;
        }
        private void FondoToolStripMenuItem_Click(object sender, EventArgs e)//Click para pintar el fondo
        {
            PtbLienzo.BackColor = Micolor;//Poner de fondo del lienzo el mismo que se usa para dibujar
        }
        private void LimpiarToolStripMenuItem_Click(object sender, EventArgs e)//Click para limpiar el lienzo
        {
            if (MessageBox.Show("¿Realmente desea limpiar?", "Advertencia",//Mensaje en caso de que la condicional sea verdadera
           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)//Lanzar cuadro de dialogo antes de cerrar
                Lienzo = new Bitmap(PtbLienzo.Width, PtbLienzo.Height);
                PtbLienzo.Image = Lienzo;
                PtbLienzo.BackColor = Color.White;//Restaurar el color por defecto del lienzo en caso de haber sido cambiado
        }
        private void AyudaToolStripMenuItem_Click(object sender, EventArgs e)//Abrir el menu de ayuda evitando que se puedan abrir muchas pestañas
        {
            if (FormAyuda == null)
            {
                FormAyuda.Show();
            }
            else
            {
                FormAyuda.Close();
                FormAyuda = new Ayuda();
                FormAyuda.Show();
            }
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog Guardar = new SaveFileDialog();
            Guardar.Filter = "JPEG(*.jpg)|*.jpg|PNG(*.png)|*.png|BMP(*.bmp)|*.bmp";
            if(Guardar.FileName=="JPEG")
            {
                Rellenar(300,300 , Color.Green);
            }
            Image Imagen = PtbLienzo.Image;
            if (Guardar.ShowDialog() == DialogResult.OK)
            {
                Imagen.Save(Guardar.FileName);
            }
        }
        private void BtnRellenar_Click(object sender, EventArgs e)
        {
            Opcion = "Relleno";
            SeleccionC();
            BtnRellenar.BackColor = Seleccion;
            Fill = "Cy";
        }
        private void BtnBorrar_Click_1(object sender, EventArgs e)
        {
            SeleccionC();
            Micolor = Color.Transparent;
            BtnBorrar.BackColor = Seleccion;
        }
        #endregion
        #region Tamaños, aqui se encuentra el codigo de los botones para seleccionar el tamaño del pixel
        private void BtnTNormal_Click(object sender, EventArgs e)//Click para seleccionar el tamaño normal
        {
            Tamaño = 0;//Tamaño del pixel a dibujar
        }
        private void BtnTMediano_Click(object sender, EventArgs e)//Click para seleccionar el tamaño mediano
        {
            Tamaño = 1;
        }
        private void BtnTGrande_Click(object sender, EventArgs e)//Click para seleccionar el tamaño grande
        {
            Tamaño = 2;
        }
        private void BtnTExtraG_Click(object sender, EventArgs e)//Click para seleccionar el tamaño Extra grande
        {
            Tamaño = 3;
        }
        #endregion
        #region Boton seleccionado, aqui se le asigna un color al boton que fue clickeado
        private void BtnContinua_MouseClick(object sender, MouseEventArgs e)
        {
            BtnContinua.BackColor = Seleccion;//Asignar el color al boton pulsado
            BtnPunteada.BackColor = Micolor;//poner color por defecto
            BtnSegmentada.BackColor = Micolor;//poner color por defect
        }
        private void BtnPunteada_MouseClick(object sender, MouseEventArgs e)
        {
            BtnContinua.BackColor = Micolor;
            BtnPunteada.BackColor = Seleccion;
            BtnSegmentada.BackColor = Micolor;
        }
        private void BtnSegmentada_MouseClick(object sender, MouseEventArgs e)
        {
            BtnContinua.BackColor = Micolor;
            BtnPunteada.BackColor = Micolor;
            BtnSegmentada.BackColor = Seleccion;
        }
        private void BtnTNormal_MouseClick(object sender, MouseEventArgs e)
        {
            BtnTNormal.BackColor = Seleccion;
            BtnTMediano.BackColor = Micolor;
            BtnTGrande.BackColor = Micolor;
            BtnTExtraG.BackColor = Micolor;
        }
        private void BtnTMediano_MouseClick(object sender, MouseEventArgs e)
        {
            BtnTNormal.BackColor = Micolor;
            BtnTMediano.BackColor = Seleccion;
            BtnTGrande.BackColor = Micolor;
            BtnTExtraG.BackColor = Micolor;
        }
        private void BtnTGrande_MouseClick(object sender, MouseEventArgs e)
        {
            BtnTNormal.BackColor = Micolor;
            BtnTMediano.BackColor = Micolor;
            BtnTGrande.BackColor = Seleccion;
            BtnTExtraG.BackColor = Micolor;
        }       
        private void BtnTExtraG_MouseClick(object sender, MouseEventArgs e)
        {
            BtnTNormal.BackColor = Micolor;
            BtnTMediano.BackColor = Micolor;
            BtnTGrande.BackColor = Micolor;
            BtnTExtraG.BackColor = Seleccion;

        }
        #endregion
        #endregion
        #region MouseClick, aqui se encuentra el codigo para poner los pixeles
        private void PtbLienzo_MouseClick(object sender, MouseEventArgs e)//Poner pixel sobre el lienzo
        {
            switch (Opcion)//Seleccionar los distintos tipos de opciones para dibujar
            {
                case "Pixel"://Caso para hacer pixeles
                    Pixeles(e.X, e.Y, Micolor);
                    break;
                case "Recta"://Caso para hacer rectas
                    Linea = Micolor;//Auxiliar que al transformar la figura no cambie su borde de color
                    Pixeles(e.X, e.Y, Micolor);
                    Puntos.Add(new Point(e.X, e.Y));
                    if (Puntos.Count == 2)
                    {
                        Recta(Puntos, Micolor);
                        Id = "Recta";
                        Xc = (Puntos[0].X + Puntos[1].X) / 2;
                        Yc = (Puntos[0].Y + Puntos[1].Y) / 2;
                        PuntosTG = new List<Point>(Puntos);
                        Puntos.Clear();
                    }
                    break;
                case "Poligono Irregular"://Caso para hacer los poligonos con los lados definidos por el usuario
                    if(ToolStripTxbNumeroL.Text=="")//Evitar que crashee la app si el usuario deja el texbox en blanco
                    {
                        MessageBox.Show("Favor de introducir la cantidad de lados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if(Convert.ToInt32(ToolStripTxbNumeroL.Text)<3)//if para prohibirle al usuario ingresar numeros menores a 3
                    {
                        MessageBox.Show("Favor de ingresar un numero mayor a 2", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Linea = Micolor;
                    Pixeles(e.X, e.Y, Micolor);
                    Puntos.Add(new Point(e.X, e.Y));
                    if (Puntos.Count == Convert.ToInt32(ToolStripTxbNumeroL.Text))
                    {
                        PoligonoIrregular(Puntos, Micolor);
                        Id = "Poligono Irregular";
                        Xc = (Puntos.Min(Point => Point.X) + Puntos.Max(Point => Point.X))/2;
                        Yc = (Puntos.Min(Point => Point.Y) + Puntos.Max(Point => Point.Y))/2;
                        PuntosTG = new List<Point>(Puntos);
                        Puntos.Clear();
                    }
                    break;
                case "Poligono Regular"://Caso para hacer triangulos, cuadrados, etc
                    if (NumeroLRToolStrip.Text!="")
                    {
                        if(Convert.ToInt32(NumeroLRToolStrip.Text)<10)
                        {
                            MessageBox.Show("Favor de ingresar un numero mayor a 10", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            Lados = Convert.ToInt32(NumeroLRToolStrip.Text);
                        }
                    }
                    Linea = Micolor;
                    Puntos.Add(new Point(e.X, e.Y));
                    PoligonoRegular(Puntos, Micolor);
                    Id = "Poligono Regular";
                    Xc = e.X;
                    Yc = e.Y;
                    PuntosTG = new List<Point>(Puntos);
                    Puntos.Clear();
                    break;
                case "Circunferencia":
                    Linea = Micolor;
                    Puntos.Add(new Point(e.X, e.Y));
                    Circunferencia(Puntos, Micolor);
                    Id = "Circunferencia";
                    Xc = e.X;
                    Yc = e.Y;
                    PuntosTG = new List<Point>(Puntos);
                    Puntos.Clear();
                    break;
                case "Elipse":
                    Linea = Micolor;
                    Puntos.Add(new Point(e.X, e.Y));
                    Elipse(Puntos, Micolor);
                    Id = "Elipse";
                    Xc = e.X;
                    Yc = e.Y;
                    PuntosTG = new List<Point>(Puntos);
                    Puntos.Clear();
                    break;
                case "Trasladar":
                    Tx = e.X - Xc;//Click del usuario y centro
                    Ty = e.Y - Yc;
                    Trasladar(PuntosTG, Tx, Ty, Micolor);//Invocacion
                    Xc = e.X;//Actualizar el centro
                    Yc = e.Y;
                    Puntos.Clear();
                    break;
                case "Rotar":
                    Rotar(PuntosTG, Angulo, Micolor);
                    break;
                case "Escalar":
                    Escalar(PuntosTG, Sx, Sy, Micolor);
                    break;
                case "Unir":
                    if (NumeroLRToolStrip.Text != "")
                    {
                        if (Convert.ToInt32(NumeroLRToolStrip.Text) < 10)
                        {
                            MessageBox.Show("Favor de ingresar un numero mayor a 10", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {
                            Lados = Convert.ToInt32(NumeroLRToolStrip.Text);
                        }
                    }
                    Puntos.Add(new Point(e.X, e.Y));
                    PoligonoRegular(Puntos, Micolor);
                    if (Puntos.Count == 2)
                    {
                        Unir(Puntos, Micolor);
                    }
                    break;
                case "Relleno":
                    Relleno = Micolor;//Auxiliar que al transformar la figura no cambie su borde de color
                    Rellenar(e.X, e.Y, Micolor);
                    break;
            }
            PtbLienzo.Image = Lienzo;//Aparecer el pixel
        }
        #endregion
        #region Metodos, aqui se encuentra el codigo de los metodos utilizados
        public void Pixeles(int X, int Y, Color Micolor)//metodo para los pixeles
        {
            for (int i = -Tamaño; i <= Tamaño; i++)
            {
                for (int j = -Tamaño; j <= Tamaño; j++)
                {
                    if (X + i > 0 && X + i < PtbLienzo.Width && Y + j > 0 && Y + j < PtbLienzo.Height)
                    {
                        Lienzo.SetPixel(X + i, Y + j, Micolor);
                    }
                }
            }
        }
        public void Recta(List<Point> Puntos, Color Micolor)//Metodo para hacer las rectas
        {
            int DX, DY, X, Y, IncX, IncY, e;
            DX = Puntos[1].X - Puntos[0].X;
            DY = Puntos[1].Y - Puntos[0].Y;
            if (DX < 0)
            {
                IncX = -1;
                DX = -DX;
            }
            else
            {
                IncX = 1;
            }
            if (DY < 0)
            {
                IncY = -1;
                DY = -DY;
            }
            else
            {
                IncY = 1;
            }
            X = Puntos[0].X;
            Y = Puntos[0].Y;
            Pixeles(X, Y, Micolor);
            if (DX >= DY)
            {
                e = 2 * DY - DX;
                Contador = 0;
                while (X != Puntos[1].X)
                {
                    X = X + IncX;
                    if (e < 0)
                    {
                        e = e + 2 * DY;
                    }
                    else
                    {
                        Y = Y + IncY;
                        e = e + 2 * (DY - DX);
                    }
                    switch (Estilo)
                    {
                        case "Continua":
                            Pixeles(X, Y, Micolor);
                            break;
                        case "Punteada":
                            if (Contador % (4 * Tamaño + 2) == 0)
                            {
                                Pixeles(X, Y, Micolor);
                            }
                            break;
                        case "Segmentada":
                            if (Tamaño == 0 && Contador % 5 != 0)
                            {
                                Pixeles(X, Y, Micolor);
                            }
                            if (Tamaño != 0 && Contador % 10 == Contador % 20)
                            {
                                Pixeles(X, Y, Micolor);
                            }
                            break;
                    }
                    Contador++;

                }
            }
            else
            {
                e = 2 * DX - DY;
                Contador = 0;
                while (Y != Puntos[1].Y)
                {
                    Y = Y + IncY;
                    if (e < 0)
                    {
                        e = e + 2 * DX;
                    }
                    else
                    {
                        X = X + IncX;
                        e = e + 2 * (DX - DY);
                    }
                    switch (Estilo)
                    {
                        case "Continua":
                            Pixeles(X, Y, Micolor);
                            break;
                        case "Punteada":
                            if (Contador % (4 * Tamaño + 2) == 0)
                            {
                                Pixeles(X, Y, Micolor);
                            }
                            break;
                        case "Segmentada":
                            if (Tamaño == 0 && Contador % 5 != 0)
                            {
                                Pixeles(X, Y, Micolor);
                            }
                            if (Tamaño != 0 && Contador % 10 == Contador % 20)
                            {
                                Pixeles(X, Y, Micolor);
                            }
                            break;
                    }
                    Contador++;
                }
            }
        }   
        public void PoligonoIrregular(List<Point> Puntos, Color Micolor)//Metodo del poligono irregular
        {
            for (int i=0; i< Puntos.Count -1;i++)
            {
                Aux.Add(new Point(Puntos[i].X, Puntos[i].Y));
                Aux.Add(new Point(Puntos[i + 1].X, Puntos[i + 1].Y));
                Recta(Aux, Micolor);
                Aux.Clear();
            }
            Aux.Add(new Point(Puntos[0].X, Puntos[0].Y));
            Aux.Add(new Point(Puntos[Puntos.Count - 1].X, Puntos[Puntos.Count - 1].Y));
            Recta(Aux, Micolor);
            Aux.Clear();
        }
        public void PoligonoRegular(List<Point> Pixeles, Color Micolor)//Metodo del poligono regular
        {
            Double angulo, X, Y, i;
            if (Lados != 0)//if para validar que el textbox para introducir el numero de lados no quede vacio y crashee
            {
                angulo = 360 / Lados;
                for (i = 0; i < 360; i = i + angulo)
                {
                    X = Pixeles[0].X + Radio * Math.Cos((i + 90 * (Lados - 2) / Lados) * Math.PI / 180);
                    Y = Pixeles[0].Y + Radio * Math.Sin((i + 90 * (Lados - 2) / Lados) * Math.PI / 180);
                    Aux2.Add(new Point(Convert.ToInt32(X), Convert.ToInt32(Y)));
                }
                PoligonoIrregular(Aux2, Micolor);
                Aux4 = new List<Point>(Aux2);
                Aux2.Clear();
            }
            else//Lanzar el mensaje de que no debe de quedar vacio el textbox
            {
                MessageBox.Show("Favor de introducir la cantidad de lados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        public void Circunferencia(List<Point> Puntos, Color Micolor)//Metodo para dibujar las circunferencias
        {
            int x, y, e;
            x = Radio; y = 0; e = 0; Contador=0;
            while (y <= x)
            {
                switch (Estilo)
                {
                    case "Continua":
                        Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                        Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                        Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                        Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        Pixeles(Puntos[0].X + y, Puntos[0].Y + x, Micolor);
                        Pixeles(Puntos[0].X - y, Puntos[0].Y + x, Micolor);
                        Pixeles(Puntos[0].X + y, Puntos[0].Y - x, Micolor);
                        Pixeles(Puntos[0].X - y, Puntos[0].Y - x, Micolor);
                        break;
                    case "Punteada":
                        if (Contador % (4 * Tamaño + 2) == 0)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X + y, Puntos[0].Y + x, Micolor);
                            Pixeles(Puntos[0].X - y, Puntos[0].Y + x, Micolor);
                            Pixeles(Puntos[0].X + y, Puntos[0].Y - x, Micolor);
                            Pixeles(Puntos[0].X - y, Puntos[0].Y - x, Micolor);
                        }
                        break;
                    case "Segmentada":
                        if (Tamaño == 0 && Contador % 5 != 0)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X + y, Puntos[0].Y + x, Micolor);
                            Pixeles(Puntos[0].X - y, Puntos[0].Y + x, Micolor);
                            Pixeles(Puntos[0].X + y, Puntos[0].Y - x, Micolor);
                            Pixeles(Puntos[0].X - y, Puntos[0].Y - x, Micolor);
                        }
                        if (Tamaño != 0 && Contador % 10 == Contador % 20)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X + y, Puntos[0].Y + x, Micolor);
                            Pixeles(Puntos[0].X - y, Puntos[0].Y + x, Micolor);
                            Pixeles(Puntos[0].X + y, Puntos[0].Y - x, Micolor);
                            Pixeles(Puntos[0].X - y, Puntos[0].Y - x, Micolor);
                        }
                        break;
                }
                Contador++;
                e = e + 2 * y + 1;
                y = y + 1;
                if (2 * e > 2 * x - 1)
{
                    x = x - 1;
                    e = e - 2 * x + 1;
                }
            }
        }     
        public void Elipse(List<Point> Puntos, Color Micolor)//Metodo para dibujar elipses
        {
            int x, y, e;
            x = 0;
            y = Ry;
            int Contador = 0;
            e = 2 * Ry * Ry + (1 - 2 * Ry) * (Rx * Rx);
            while (Ry * Ry * x <= Rx * Rx * y)
            {
                switch (Estilo)
                {
                    case "Continua":
                        Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                        Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                        Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                        Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        break;
                    case "Punteada":
                        if (Contador % (4 * Tamaño + 2) == 0)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        }
                        break;
                    case "Segmentada":
                        if (Tamaño == 0 && Contador % 5 != 0)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        }
                        if (Tamaño != 0 && Contador % 10 == Contador % 20)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        }
                        break;
                }
                Contador++;
                x = x + 1;
                if (e >= 0)
                {
                    e = e + 4 * Rx * Rx * (1 - y);
                    y = y - 1;
                }
                e = e + Ry * Ry * (4 * x + 6);
            }
            y = 0;
            x = Rx;
            e = 2 * Rx * Rx + (1 - 2 * Rx) * (Ry * Ry);
            while (Rx * Rx * y <= Ry * Ry * x)
            {
                switch (Estilo)
                {
                    case "Continua":
                        Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                        Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                        Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                        Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        break;
                    case "Punteada":
                        if (Contador % (4 * Tamaño + 2) == 0)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        }
                        break;
                    case "Segmentada":
                        if (Tamaño == 0 && Contador % 5 != 0)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        }
                        if (Tamaño != 0 && Contador % 10 == Contador % 20)
                        {
                            Pixeles(Puntos[0].X + x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X + x, Puntos[0].Y - y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y + y, Micolor);
                            Pixeles(Puntos[0].X - x, Puntos[0].Y - y, Micolor);
                        }
                        break;
                }
                Contador++;
                y = y + 1;
                if (e >= 0)
                {
                    e = e + 4 * Ry * Ry * (1 - x);
                    x = x - 1;
                }
                e = e + Rx * Rx * (4 * y + 6);
            }
        }
        public void Trasladar (List<Point> PuntosTG, int Tx, int Ty, Color Micolor)//Metodo para cambiar las formas de lugar
        {
            if (Id == "Poligono Regular")
            {
                PuntosTG = new List<Point>(Aux4);
            }
            for (int i=0;i<PuntosTG.Count;i++)
            {
                PuntosT.Add(new Point(PuntosTG[i].X + Tx, PuntosTG[i].Y + Ty));
            }
            switch(Id)
            {
                case "Recta":
                    Recta(PuntosTG, BTras);
                    Recta(PuntosT, Linea);
                    break;
                case "Poligono Irregular":
                    RellenadoCon();
                    PoligonoIrregular(PuntosTG, BTras);
                    PoligonoIrregular(PuntosT, Linea);
                    RellenadoTras();
                    break;
                case "Poligono Regular":
                    RellenadoCon();
                    PoligonoIrregular(PuntosTG, BTras);
                    PoligonoIrregular(PuntosT, Linea);
                    RellenadoTras();
                    break;
                case "Circunferencia":
                    RellenadoCon();
                    Circunferencia(PuntosTG, BTras);
                    Circunferencia(PuntosT, Linea);
                    RellenadoTras();
                    break;
                case "Elipse":
                    RellenadoCon();
                    Elipse(PuntosTG, BTras);
                    Elipse(PuntosT, Linea);
                    RellenadoTras();
                    break;
            }
            for (int j=0;j<PuntosTG.Count;j++)
            {
                PuntosTG[j] = PuntosT[j];
            }
            Aux4 = new List<Point>(PuntosT);
            PuntosT.Clear();
        }
        public void Rotar(List<Point> PuntosTG, int Angulo, Color Micolor)//Metodo para hacer girar las figuras
        {
            if(Id=="Poligono Regular")
            {
                PuntosTG = new List<Point>(Aux4);
            }
            for (int i = 0; i < PuntosTG.Count; i++)
            {
                int Xr = Convert.ToInt32(Xc + (PuntosTG[i].X - Xc) * Math.Cos(Angulo * Math.PI / 180) - (PuntosTG[i].Y - Yc) * Math.Sin(Angulo * Math.PI / 180));
                int Yr = Convert.ToInt32(Yc + (PuntosTG[i].X - Xc) * Math.Sin(Angulo * Math.PI / 180) + (PuntosTG[i].Y - Yc) * Math.Cos(Angulo * Math.PI / 180));
                PuntosT.Add(new Point(Xr, Yr));
            }
            switch (Id)
            {
                case "Recta":
                    Recta(PuntosTG, BTras);
                    Recta(PuntosT, Linea);
                    break;
                case "Poligono Irregular":
                    RellenadoCon();
                    PoligonoIrregular(PuntosTG, BTras);
                    PoligonoIrregular(PuntosT, Linea);
                    RellenadoRot();
                    break;
                case "Poligono Regular":
                    RellenadoCon();
                    PoligonoIrregular(PuntosTG, BTras);
                    PoligonoIrregular(PuntosT, Linea);
                    RellenadoRot();
                    break;
                case "Elipse":
                    RellenadoCon();
                    Elipse(PuntosTG, BTras);
                    Auxiliar = Rx;
                    Rx = Ry;
                    Ry = Auxiliar;
                    Elipse(PuntosT, Linea);
                    RellenadoRot();
                    break;
            }
            for (int j = 0; j < PuntosTG.Count; j++)
            {
                PuntosTG[j] = PuntosT[j];
            }
            Aux4 = new List<Point>(PuntosT);
            PuntosT.Clear();
        }
        public void Escalar(List<Point> PuntosTG, float Sx, float Sy, Color Micolor)//Metodo para cambiar las formas de lugar
        {
            if (Id == "Poligono Regular")
            {
                PuntosTG = new List<Point>(Aux4);
            }
            for (int i = 0; i < PuntosTG.Count; i++)
            {
                int Xs = Convert.ToInt32(Xc + Sx * (PuntosTG[i].X - Xc));
                int Ys = Convert.ToInt32(Yc + Sy * (PuntosTG[i].Y - Yc));
                PuntosT.Add(new Point(Xs, Ys));
            }
            switch (Id)
            {
                case "Recta":
                    Recta(PuntosTG, BTras);
                    Recta(PuntosT, Linea);
                    break;
                case "Poligono Irregular":
                    RellenadoCon();
                    PoligonoIrregular(PuntosTG, BTras);
                    PoligonoIrregular(PuntosT, Linea);
                    RellenadoRot();
                    break;
                case "Poligono Regular":
                    RellenadoCon();
                    PoligonoIrregular(PuntosTG, BTras);
                    PoligonoIrregular(PuntosT, Linea);
                    RellenadoRot();
                    break;
                case "Circunferencia":
                    RellenadoCon();
                    Circunferencia(PuntosTG, BTras);
                    Radio = Convert.ToInt32(Sx * Radio);
                    Circunferencia(PuntosT, Linea);
                    RellenadoRot();
                    break;
                case "Elipse":
                    RellenadoCon();
                    Elipse(PuntosTG, BTras);
                    Rx = Convert.ToInt32(Sx * Rx);
                    Ry = Convert.ToInt32(Sy * Ry);
                    Elipse(PuntosT, Linea);
                    RellenadoRot();
                    break;
            }
            for (int j = 0; j < PuntosTG.Count; j++)
            {
                PuntosTG[j] = PuntosT[j];
            }
            Aux4 = new List<Point>(PuntosT);
            PuntosT.Clear();
        }
        public void Rellenar(int X, int Y, Color Relleno)//Metodo para rellenar las figuras por inundacion
        {
            Color ColorR = Lienzo.GetPixel(X, Y);
            Stack<Point> Vecinos = new Stack<Point>();
            Vecinos.Push(new Point(X, Y));
            while(Vecinos.Count !=0)
            {
                Point P = Vecinos.Pop();
                if (P.X > 0 && P.X < PtbLienzo.Width && P.Y > 0 && P.Y < PtbLienzo.Height)
                {
                    if (ColorR != Relleno && ColorR == Lienzo.GetPixel(P.X, P.Y))
                    {
                        Lienzo.SetPixel(P.X, P.Y, Relleno);
                        Vecinos.Push(new Point(P.X + 1, P.Y));
                        Vecinos.Push(new Point(P.X - 1, P.Y));
                        Vecinos.Push(new Point(P.X, P.Y + 1));
                        Vecinos.Push(new Point(P.X, P.Y - 1));
                    }
                }
            }
        }
        #region Mover figuras con relleno
        public void RellenadoTras()//Metodo para mover las figuras si fueron rellenadas
        {
            if (Fill == "Cy")
            {
                Rellenar(Xc, Yc, BTras);
                Rellenar(Xc + Tx, Yc + Ty, Relleno);
            }
        }
        public void RellenadoRot()//Metodo para mover las figuras si fueron rellenadas
        {
            if (Fill == "Cy")
            {
                Rellenar(Xc, Yc, BTras);
                Rellenar(Xc, Yc, Relleno);
            }
        }
        public void RellenadoCon()//Metodo para borrar el rastro anterior de color
        {
            if (Fill == "Cy")
            {
                Rellenar(Xc, Yc, BTras);
            }
        }
        #endregion
        public void Colores(Color Micolor)//Metodo para poner el color seleccionado en los botones
        {
            PtbActual.BackColor = Micolor; //Cambiar el color del boton actual por el seleccionado
            if (BtnTNormal.BackColor != Seleccion)//Condicional utilizada para que al cambiar de color siga indicando cual es la seleccionada
            {
                BtnTNormal.BackColor = Micolor;//Cambiar color de boton de tamaño
            }
            if (BtnTMediano.BackColor != Seleccion)
            {
                BtnTMediano.BackColor = Micolor;//Cambiar color de boton de tamaño
            }
            if (BtnTGrande.BackColor != Seleccion)
            {
                BtnTGrande.BackColor = Micolor;//Cambiar color de boton de tamaño
            }
            if (BtnTExtraG.BackColor != Seleccion)
            {
                BtnTExtraG.BackColor = Micolor;//Cambiar color de boton de tamaño
            }
            if (BtnContinua.BackColor != Seleccion)
            {
                BtnContinua.BackColor = Micolor;//Cambiar el color de la linea continua
            }
            if (BtnPunteada.BackColor != Seleccion)
            {
                BtnPunteada.BackColor = Micolor;//Cambiar el color de la linea punteada
            }
            if (BtnSegmentada.BackColor != Seleccion)
            {
                BtnSegmentada.BackColor = Micolor;//Cambiar el color de la linea segmentada
            }
            if (BtnRellenar.BackColor != Seleccion)
            {
                BtnRellenar.BackColor = Micolor;//Cambiar el color de la linea segmentada
            }
        }
        public void SeleccionC()//Metodo para marcar el boton seleccionado del menu
        {
            PixelToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption; ;//Cambiar fondo al seleccionarlo
            RectaToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;//Restaurar color
            PoligonosToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;//Restaurar color
            CircunferenciaToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            IrregularesToolStripMenuItem.BackColor = SystemColors.Control;//Restaurar color
            RegularesToolStripMenuItem.BackColor = SystemColors.Control;//Restaurar color
            ElipseToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;//Restaurar color
            TrasladarToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;//Restaurar color
            RotacionToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            UnirPuntos.BackColor = SystemColors.GradientInactiveCaption;
            BtnRellenar.BackColor = Micolor;
            BtnBorrar.BackColor = SystemColors.GradientInactiveCaption;
            escalarToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            IncrementarToolStripMenuItem.BackColor = SystemColors.Control;
            DecrementarToolStripMenuItem.BackColor = SystemColors.Control;
        }
        #endregion
        #region Estetica, aqui esta el codigo para poder usar la barra personalizada
        private void BtnCerrarMenu_Click_1(object sender, EventArgs e) //click para cerrar la app
        {
            if (MessageBox.Show("¿Realmente desea cerrar la aplicacion?", "Advertencia",//Mensaje en caso de que la condicional sea verdadera
           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)//Lanzar cuadro de dialogo antes de cerrar
                Application.Exit();//Cerrar
        }
        private void Paint_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;<--//Se maximiza la aplicacion ocultando la barra de tareas
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;//Maximizar la app sin ocultar la barra de tareas
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;//Maximizar la app sin ocultar la barra de tareas
            Lienzo = new Bitmap(PtbLienzo.Width, PtbLienzo.Height);//Tamaño del lienzo por defecto
        }
        private void BtnMinimizarMenu_Click(object sender, EventArgs e) //Click para ocultar la app
        {
            this.WindowState = FormWindowState.Minimized;//se minimiza la aplicacion
        }
        #endregion
        #region Examen 2
        private void examenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opcion = "Examen";
        }
        public void Unir(List<Point> Pixeles, Color Micolor)
        {
            Double angulo, X, Y, i;
            if (Lados != 0)//if para validar que el textbox para introducir el numero de lados no quede vacio y crashee
            {
                angulo = 360 / Lados;

                for (i = 0; i< 360; i =  i + angulo)
                {
                    X = Pixeles[0].X + Radio * Math.Cos((i + 90 * (Lados - 2) / Lados) * Math.PI / 180);
                    Y = Pixeles[0].Y + Radio * Math.Sin((i + 90 * (Lados - 2) / Lados) * Math.PI / 180);
                    Aux2.Add(new Point(Convert.ToInt32(X), Convert.ToInt32(Y)));
                }
                for ( int j= 0; j < Aux2.Count; j++)
                {
                    Aux3.Add(new Point(Puntos[1].X, Puntos[1].Y));
                    Aux3.Add(new Point(Aux2[j].X, Aux2[j].Y));
                    Recta(Aux3, Micolor);
                    Aux3.Clear();
                }
                PoligonoIrregular(Aux2, Micolor);
                Puntos.Clear();
                Aux.Clear();
                Aux2.Clear();
                Aux3.Clear();
            }
        }
        private void UnirPuntos_Click(object sender, EventArgs e)
        {
            Opcion = "Unir";
            UnirPuntos.BackColor = Seleccion;
            PoligonosToolStripMenuItem.BackColor = Seleccion;
            RegularesToolStripMenuItem.BackColor = Seleccion;
            PixelToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption; ;//Cambiar fondo al seleccionarlo
            RectaToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;//Restaurar color
            CircunferenciaToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            IrregularesToolStripMenuItem.BackColor = SystemColors.Control;//Restaurar color
            ElipseToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;//Restaurar color
            TrasladarToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;//Restaurar color
            RotacionToolStripMenuItem.BackColor = SystemColors.GradientInactiveCaption;
            BtnRellenar.BackColor = Micolor;
        }
        #endregion
    }
}