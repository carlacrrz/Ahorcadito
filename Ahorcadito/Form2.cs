using Ahorcadito;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form2 : Form
    {
        private TextBox txtPalabra;
        private CheckBox checkTiempo;
        private CheckBox checkDificil;
        private Button btnSiguiente;

        public Form2()
        {
            InitializeComponent();
            HacerBotonRedondeado(btnSiguiente, 25);
        }

        private void InitializeComponent()
        {
            this.txtPalabra = new System.Windows.Forms.TextBox();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.checkTiempo = new System.Windows.Forms.CheckBox();
            this.checkDificil = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtPalabra
            // 
            this.txtPalabra.Font = new System.Drawing.Font("Comic Sans MS", 28.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPalabra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txtPalabra.Location = new System.Drawing.Point(44, 192);
            this.txtPalabra.Margin = new System.Windows.Forms.Padding(6);
            this.txtPalabra.Name = "txtPalabra";
            this.txtPalabra.Size = new System.Drawing.Size(396, 112);
            this.txtPalabra.TabIndex = 1;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.Orange;
            this.btnSiguiente.FlatAppearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.btnSiguiente.FlatAppearance.BorderSize = 2;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSiguiente.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSiguiente.Location = new System.Drawing.Point(432, 585);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(6);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(200, 58);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // checkTiempo
            // 
            this.checkTiempo.AutoSize = true;
            this.checkTiempo.BackColor = System.Drawing.Color.Transparent;
            this.checkTiempo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkTiempo.Location = new System.Drawing.Point(59, 348);
            this.checkTiempo.Name = "checkTiempo";
            this.checkTiempo.Size = new System.Drawing.Size(28, 27);
            this.checkTiempo.TabIndex = 5;
            this.checkTiempo.UseVisualStyleBackColor = false;
            // 
            // checkDificil
            // 
            this.checkDificil.BackColor = System.Drawing.Color.Transparent;
            this.checkDificil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkDificil.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDificil.Location = new System.Drawing.Point(59, 413);
            this.checkDificil.Name = "checkDificil";
            this.checkDificil.Size = new System.Drawing.Size(42, 30);
            this.checkDificil.TabIndex = 6;
            this.checkDificil.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::Ahorcadito.Properties.Resources.AHORCADO_3;
            this.ClientSize = new System.Drawing.Size(672, 670);
            this.Controls.Add(this.checkDificil);
            this.Controls.Add(this.checkTiempo);
            this.Controls.Add(this.txtPalabra);
            this.Controls.Add(this.btnSiguiente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form2";
            this.Text = "Ahorcado";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPalabra.Text))
            {
                MessageBox.Show("Ingrese una palabra");
                return;
            }

            bool conTiempo = checkTiempo.Checked;
            bool dificil = checkDificil.Checked;
            string palabra = txtPalabra.Text.ToUpper();

            Form3 juego = new Form3(palabra, conTiempo, dificil);
            juego.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void HacerBotonRedondeado(Button boton, int borderRadius = 25)
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