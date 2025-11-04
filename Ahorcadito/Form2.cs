using System;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form2 : Form
    {
        private TextBox txtPalabra;
        private Button btnSiguiente;

        public Form2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtPalabra = new System.Windows.Forms.TextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPalabra
            // 
            this.txtPalabra.Location = new System.Drawing.Point(97, 228);
            this.txtPalabra.Margin = new System.Windows.Forms.Padding(6);
            this.txtPalabra.Name = "txtPalabra";
            this.txtPalabra.Size = new System.Drawing.Size(396, 31);
            this.txtPalabra.TabIndex = 1;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(450, 548);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(6);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(200, 58);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ahorcadito.Properties.Resources.AHORCADO_2;
            this.ClientSize = new System.Drawing.Size(724, 679);
            this.Controls.Add(this.txtPalabra);
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