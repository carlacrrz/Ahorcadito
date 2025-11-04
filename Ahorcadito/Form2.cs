using System;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form2 : Form
    {
        private TextBox txtPalabra;
        private CheckBox checkTiempo;
        private CheckBox checkDificil;
        private Button btnSiguiente;
        private Label lblInstruccion;

        public Form2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtPalabra = new System.Windows.Forms.TextBox();
            this.checkTiempo = new System.Windows.Forms.CheckBox();
            this.checkDificil = new System.Windows.Forms.CheckBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPalabra
            // 
            this.txtPalabra.Location = new System.Drawing.Point(100, 154);
            this.txtPalabra.Margin = new System.Windows.Forms.Padding(6);
            this.txtPalabra.Name = "txtPalabra";
            this.txtPalabra.Size = new System.Drawing.Size(396, 31);
            this.txtPalabra.TabIndex = 1;
            // 
            // checkTiempo
            // 
            this.checkTiempo.AutoSize = true;
            this.checkTiempo.Location = new System.Drawing.Point(100, 231);
            this.checkTiempo.Margin = new System.Windows.Forms.Padding(6);
            this.checkTiempo.Name = "checkTiempo";
            this.checkTiempo.Size = new System.Drawing.Size(216, 29);
            this.checkTiempo.TabIndex = 2;
            this.checkTiempo.Text = "Modo con Tiempo";
            // 
            // checkDificil
            // 
            this.checkDificil.AutoSize = true;
            this.checkDificil.Location = new System.Drawing.Point(100, 288);
            this.checkDificil.Margin = new System.Windows.Forms.Padding(6);
            this.checkDificil.Name = "checkDificil";
            this.checkDificil.Size = new System.Drawing.Size(156, 29);
            this.checkDificil.TabIndex = 3;
            this.checkDificil.Text = "Modo Difícil";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(100, 385);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(6);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(200, 58);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Location = new System.Drawing.Point(100, 96);
            this.lblInstruccion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(305, 25);
            this.lblInstruccion.TabIndex = 0;
            this.lblInstruccion.Text = "Jugador 1 - Ingresa la palabra:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ahorcadito.Properties.Resources.IMG_7230_31;
            this.ClientSize = new System.Drawing.Size(724, 679);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.txtPalabra);
            this.Controls.Add(this.checkTiempo);
            this.Controls.Add(this.checkDificil);
            this.Controls.Add(this.btnSiguiente);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form2";
            this.Text = "Configuración del Juego";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPalabra.Text))
            {
                MessageBox.Show("Por favor ingresa una palabra");
                return;
            }

            bool conTiempo = checkTiempo.Checked;
            bool dificil = checkDificil.Checked;
            string palabra = txtPalabra.Text.ToUpper();

            Form3 juego = new Form3(palabra, conTiempo, dificil);
            juego.Show();
            this.Hide();
        }
    }
}