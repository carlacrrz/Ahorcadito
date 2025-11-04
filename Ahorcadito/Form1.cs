using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form1 : Form
    {
        private Button btnJugar;
        private Label lblTitulo;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnJugar = new Button();
            this.lblTitulo = new Label();

            // btnJugar
            this.btnJugar.Location = new Point(300, 200);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new Size(200, 50);
            this.btnJugar.Text = "JUGAR";
            this.btnJugar.Click += new EventHandler(this.btnJugar_Click);

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Arial", 24F, FontStyle.Bold);
            this.lblTitulo.Location = new Point(250, 100);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(300, 37);
            this.lblTitulo.Text = "JUEGO DEL AHORCADO";

            // Form1
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.btnJugar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Form1";
            this.Text = "Ahorcado - Inicio";
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            Form2 configuracion = new Form2();
            configuracion.Show();
            this.Hide();
        }
    }
}