namespace Menu
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.panelPacSubMen = new System.Windows.Forms.Panel();
            this.btnVerPacientes = new System.Windows.Forms.Button();
            this.btnAñadirPacientes = new System.Windows.Forms.Button();
            this.btnCitas = new System.Windows.Forms.Button();
            this.panelCitSubMen = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.panelHisSubMen = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnRecetas = new System.Windows.Forms.Button();
            this.panelRecSubMen = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelFijo = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelPacSubMen.SuspendLayout();
            this.panelCitSubMen.SuspendLayout();
            this.panelHisSubMen.SuspendLayout();
            this.panelRecSubMen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelFijo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.panelRecSubMen);
            this.panel1.Controls.Add(this.btnRecetas);
            this.panel1.Controls.Add(this.panelHisSubMen);
            this.panel1.Controls.Add(this.btnHistorial);
            this.panel1.Controls.Add(this.panelCitSubMen);
            this.panel1.Controls.Add(this.btnCitas);
            this.panel1.Controls.Add(this.panelPacSubMen);
            this.panel1.Controls.Add(this.btnPacientes);
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 426);
            this.panel1.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(216, 174);
            this.panelLogo.TabIndex = 0;
            // 
            // btnPacientes
            // 
            this.btnPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnPacientes.Location = new System.Drawing.Point(0, 174);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPacientes.Size = new System.Drawing.Size(216, 40);
            this.btnPacientes.TabIndex = 1;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // panelPacSubMen
            // 
            this.panelPacSubMen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelPacSubMen.Controls.Add(this.btnAñadirPacientes);
            this.panelPacSubMen.Controls.Add(this.btnVerPacientes);
            this.panelPacSubMen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPacSubMen.Location = new System.Drawing.Point(0, 214);
            this.panelPacSubMen.Name = "panelPacSubMen";
            this.panelPacSubMen.Size = new System.Drawing.Size(216, 79);
            this.panelPacSubMen.TabIndex = 2;
            // 
            // btnVerPacientes
            // 
            this.btnVerPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVerPacientes.FlatAppearance.BorderSize = 0;
            this.btnVerPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPacientes.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVerPacientes.Location = new System.Drawing.Point(0, 0);
            this.btnVerPacientes.Name = "btnVerPacientes";
            this.btnVerPacientes.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnVerPacientes.Size = new System.Drawing.Size(216, 40);
            this.btnVerPacientes.TabIndex = 0;
            this.btnVerPacientes.Text = "Ver pacientes";
            this.btnVerPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerPacientes.UseVisualStyleBackColor = true;
            this.btnVerPacientes.Click += new System.EventHandler(this.btnVerPacientes_Click);
            // 
            // btnAñadirPacientes
            // 
            this.btnAñadirPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAñadirPacientes.FlatAppearance.BorderSize = 0;
            this.btnAñadirPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadirPacientes.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAñadirPacientes.Location = new System.Drawing.Point(0, 40);
            this.btnAñadirPacientes.Name = "btnAñadirPacientes";
            this.btnAñadirPacientes.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.btnAñadirPacientes.Size = new System.Drawing.Size(216, 40);
            this.btnAñadirPacientes.TabIndex = 1;
            this.btnAñadirPacientes.Text = "Añadir paciente";
            this.btnAñadirPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAñadirPacientes.UseVisualStyleBackColor = true;
            this.btnAñadirPacientes.Click += new System.EventHandler(this.btnAñadirPacientes_Click);
            // 
            // btnCitas
            // 
            this.btnCitas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCitas.FlatAppearance.BorderSize = 0;
            this.btnCitas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCitas.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnCitas.Location = new System.Drawing.Point(0, 293);
            this.btnCitas.Name = "btnCitas";
            this.btnCitas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCitas.Size = new System.Drawing.Size(216, 40);
            this.btnCitas.TabIndex = 3;
            this.btnCitas.Text = "Citas";
            this.btnCitas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCitas.UseVisualStyleBackColor = true;
            this.btnCitas.Click += new System.EventHandler(this.btnCitas_Click);
            // 
            // panelCitSubMen
            // 
            this.panelCitSubMen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelCitSubMen.Controls.Add(this.button1);
            this.panelCitSubMen.Controls.Add(this.button2);
            this.panelCitSubMen.Controls.Add(this.button3);
            this.panelCitSubMen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCitSubMen.Location = new System.Drawing.Point(0, 333);
            this.panelCitSubMen.Name = "panelCitSubMen";
            this.panelCitSubMen.Size = new System.Drawing.Size(216, 124);
            this.panelCitSubMen.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(0, 40);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(216, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "Añadir cita";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(216, 40);
            this.button3.TabIndex = 0;
            this.button3.Text = "Ver citas";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistorial.FlatAppearance.BorderSize = 0;
            this.btnHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorial.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnHistorial.Location = new System.Drawing.Point(0, 457);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnHistorial.Size = new System.Drawing.Size(216, 40);
            this.btnHistorial.TabIndex = 5;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // panelHisSubMen
            // 
            this.panelHisSubMen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelHisSubMen.Controls.Add(this.button4);
            this.panelHisSubMen.Controls.Add(this.button5);
            this.panelHisSubMen.Controls.Add(this.button6);
            this.panelHisSubMen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHisSubMen.Location = new System.Drawing.Point(0, 497);
            this.panelHisSubMen.Name = "panelHisSubMen";
            this.panelHisSubMen.Size = new System.Drawing.Size(216, 119);
            this.panelHisSubMen.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.Control;
            this.button5.Location = new System.Drawing.Point(0, 40);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(216, 40);
            this.button5.TabIndex = 1;
            this.button5.Text = "Añadir historial";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.SystemColors.Control;
            this.button6.Location = new System.Drawing.Point(0, 0);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(216, 40);
            this.button6.TabIndex = 0;
            this.button6.Text = "Ver historiales";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnRecetas
            // 
            this.btnRecetas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecetas.FlatAppearance.BorderSize = 0;
            this.btnRecetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecetas.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnRecetas.Location = new System.Drawing.Point(0, 616);
            this.btnRecetas.Name = "btnRecetas";
            this.btnRecetas.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnRecetas.Size = new System.Drawing.Size(216, 40);
            this.btnRecetas.TabIndex = 7;
            this.btnRecetas.Text = "Recetas";
            this.btnRecetas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecetas.UseVisualStyleBackColor = true;
            this.btnRecetas.Click += new System.EventHandler(this.btnRecetas_Click);
            // 
            // panelRecSubMen
            // 
            this.panelRecSubMen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.panelRecSubMen.Controls.Add(this.button7);
            this.panelRecSubMen.Controls.Add(this.button8);
            this.panelRecSubMen.Controls.Add(this.button9);
            this.panelRecSubMen.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRecSubMen.Location = new System.Drawing.Point(0, 656);
            this.panelRecSubMen.Name = "panelRecSubMen";
            this.panelRecSubMen.Size = new System.Drawing.Size(216, 117);
            this.panelRecSubMen.TabIndex = 8;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Top;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.SystemColors.Control;
            this.button8.Location = new System.Drawing.Point(0, 40);
            this.button8.Name = "button8";
            this.button8.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button8.Size = new System.Drawing.Size(216, 40);
            this.button8.TabIndex = 1;
            this.button8.Text = "Añadir receta";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.ForeColor = System.Drawing.SystemColors.Control;
            this.button9.Location = new System.Drawing.Point(0, 0);
            this.button9.Name = "button9";
            this.button9.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button9.Size = new System.Drawing.Size(216, 40);
            this.button9.TabIndex = 0;
            this.button9.Text = "Ver recetas";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(0, 80);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(216, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Eliminar cita";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(0, 80);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(216, 40);
            this.button4.TabIndex = 2;
            this.button4.Text = "Eliminar historial";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.SystemColors.Control;
            this.button7.Location = new System.Drawing.Point(0, 80);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(40, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(216, 40);
            this.button7.TabIndex = 2;
            this.button7.Text = "Añadir receta";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 174);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelFijo
            // 
            this.panelFijo.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panelFijo.Controls.Add(this.pictureBox2);
            this.panelFijo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFijo.Location = new System.Drawing.Point(233, 0);
            this.panelFijo.Name = "panelFijo";
            this.panelFijo.Size = new System.Drawing.Size(566, 426);
            this.panelFijo.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(566, 426);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 426);
            this.Controls.Add(this.panelFijo);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(815, 465);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelPacSubMen.ResumeLayout(false);
            this.panelCitSubMen.ResumeLayout(false);
            this.panelHisSubMen.ResumeLayout(false);
            this.panelRecSubMen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelFijo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelRecSubMen;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnRecetas;
        private System.Windows.Forms.Panel panelHisSubMen;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Panel panelCitSubMen;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Panel panelPacSubMen;
        private System.Windows.Forms.Button btnAñadirPacientes;
        private System.Windows.Forms.Button btnVerPacientes;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelFijo;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

