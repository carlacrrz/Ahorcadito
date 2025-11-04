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
            this.txtPalabra = new TextBox();
            this.checkTiempo = new CheckBox();
            this.checkDificil = new CheckBox();
            this.btnSiguiente = new Button();
            this.lblInstruccion = new Label();

            // lblInstruccion
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Location = new System.Drawing.Point(50, 50);
            this.lblInstruccion.Text = "Jugador 1 - Ingresa la palabra:";

            // txtPalabra
            this.txtPalabra.Location = new System.Drawing.Point(50, 80);
            this.txtPalabra.Size = new System.Drawing.Size(200, 20);

            // checkTiempo
            this.checkTiempo.AutoSize = true;
            this.checkTiempo.Location = new System.Drawing.Point(50, 120);
            this.checkTiempo.Text = "Modo con Tiempo";

            // checkDificil
            this.checkDificil.AutoSize = true;
            this.checkDificil.Location = new System.Drawing.Point(50, 150);
            this.checkDificil.Text = "Modo Difícil";

            // btnSiguiente
            this.btnSiguiente.Location = new System.Drawing.Point(50, 200);
            this.btnSiguiente.Size = new System.Drawing.Size(100, 30);
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.Click += new EventHandler(this.btnSiguiente_Click);

            // Form2
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lblInstruccion);
            this.Controls.Add(this.txtPalabra);
            this.Controls.Add(this.checkTiempo);
            this.Controls.Add(this.checkDificil);
            this.Controls.Add(this.btnSiguiente);
            this.Name = "Form2";
            this.Text = "Configuración del Juego";
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