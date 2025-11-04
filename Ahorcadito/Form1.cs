using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form1 : Form
    {
        private Button btnJugar;
        private Button button1;
        private Button button2;
        private Label label1;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnJugar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJugar
            // 
            this.btnJugar.BackColor = System.Drawing.Color.Orange;
            this.btnJugar.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnJugar.FlatAppearance.BorderSize = 2;
            this.btnJugar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJugar.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJugar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnJugar.Location = new System.Drawing.Point(197, 392);
            this.btnJugar.Name = "btnJugar";
            this.btnJugar.Size = new System.Drawing.Size(339, 116);
            this.btnJugar.TabIndex = 0;
            this.btnJugar.Text = "Jugar";
            this.btnJugar.UseVisualStyleBackColor = false;
            this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click_1);
            // 
            // Form1
            // 
            this.BackgroundImage = global::Ahorcadito.Properties.Resources.AHORCADO;
            this.ClientSize = new System.Drawing.Size(748, 745);
            this.Controls.Add(this.btnJugar);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnJugar_Click_1(object sender, EventArgs e)
        {
            Form2 configuracion = new Form2();
            configuracion.Show();
            this.Hide();
        }
    }
}