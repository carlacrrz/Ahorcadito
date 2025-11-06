using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form1 : Form
    {
        private Button btnJugar;
        //private Button button1;
        //private Button button2;
        //private Label label1;

        public Form1()
        {
            InitializeComponent();
            HacerBotonRedondeado(btnJugar, 25);
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
            this.Load += new System.EventHandler(this.Form1_Load_1);
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void HacerBotonRedondeado(Button boton, int borderRadius = 30)
        {
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;

            boton.Paint += (s, e) =>
            {
                Button btn = s as Button;

                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(btn.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(btn.Width - borderRadius, btn.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, btn.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseFigure();

                btn.Region = new Region(path);

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.Clear(btn.BackColor);

                // Dibujar fondo
                using (Brush brush = new SolidBrush(btn.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font,
                    new Rectangle(0, 0, btn.Width, btn.Height),
                    btn.ForeColor, btn.BackColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                path.Dispose();
            };
        }
    }
}