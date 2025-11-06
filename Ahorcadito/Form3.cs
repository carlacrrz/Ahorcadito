using Ahorcado;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Ahorcadito
{
    public partial class Form3 : Form
    {
        private JuegoAhorcado juego;
        private Timer temporizador;
        private int tiempoRestante = 60;
        private bool conTiempo;
        private bool dificil;

        public Form3(string palabra, bool conTiempo, bool dificil)
        {
            InitializeComponent();

            btnJugarDeNuevo.Visible = false;
            btnJugarDeNuevo.Enabled = false;

            HacerBotonRedondeado(btnJugarDeNuevo, 25);
            this.conTiempo = conTiempo;
            this.dificil = dificil;
            juego = new JuegoAhorcado(palabra, dificil);
            InicializarTeclado();
            ActualizarInterfaz();

            if (conTiempo)
            {
                InicializarTemporizador();
            }
        }

        private void InicializarTeclado()
        {
            int x = 50;
            int y = 480;
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (char letra in letras)
            {
                Button btnLetra = new Button();
                btnLetra.Text = letra.ToString();
                btnLetra.Size = new Size(50, 50);
                btnLetra.Location = new Point(x, y);
                btnLetra.BackColor = Color.Orange;
                btnLetra.ForeColor = Color.White;
                btnLetra.Font = new Font("Comic Sans MS", 20F, FontStyle.Bold);
                btnLetra.Click += (s, e) => ProcesarLetra(letra);
                this.Controls.Add(btnLetra);

                x += 60;
                if (x > 600)
                {
                    x = 50;
                    y += 55;
                }
            }
        }

        private void InicializarTemporizador()
        {
            temporizador = new Timer();
            temporizador.Interval = 1000;
            temporizador.Tick += Temporizador_Tick;
            temporizador.Start();
            lblTiempo.Visible = true;
            ActualizarTiempo();
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            tiempoRestante--;
            ActualizarTiempo();

            if (tiempoRestante <= 0)
            {
                temporizador.Stop();
                MostrarResultado(false);
            }
        }

        private void ActualizarTiempo()
        {
            lblTiempo.Text = $"Tiempo: {tiempoRestante}s";
        }

        private void ProcesarLetra(char letra)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Text == letra.ToString() && btn != btnJugarDeNuevo)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.Red;
                    break;
                }
            }

            juego.ProcesarIntento(letra);
            ActualizarInterfaz();

            if (juego.JuegoTerminado)
            {
                if (temporizador != null)
                    temporizador.Stop();
                MostrarResultado(juego.JuegoGanado);
            }
        }

        private void ActualizarInterfaz()
        {
            if (juego != null)
            {
                lblPalabra.Text = juego.PalabraOculta;

                int intentosMaximos = dificil ? 5 : 8;
                int intentosRestantes = juego.IntentosRestantes;
                lblIntentos.Text = $"Intentos: {intentosRestantes}/{intentosMaximos}";

                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (juego == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen lapiz = new Pen(Color.SaddleBrown, 6))
            using (Brush relleno = new SolidBrush(Color.SaddleBrown))
            {
                int errores = juego.ErroresCometidos;

                int cabezaX = 350, cabezaY = 130;
                int tamanoCabeza = 70;
                int radioCabeza = tamanoCabeza / 2;

                int cuerpoYInicio = 200,
                    cuerpoYFin = 300;
                int brazosY = 230, piernasY = 300;

                int centroCabezaX = cabezaX;
                int centroCabezaY = cabezaY + radioCabeza; 
                int separacionOjos = 10;
                int tamanoOjo = 10; 
                int alturaOjos = 10; 

                if (dificil)
                {
                    if (errores >= 1)
                        g.DrawEllipse(lapiz, cabezaX - radioCabeza, cabezaY, tamanoCabeza, tamanoCabeza);

                    if (errores >= 2)
                        g.DrawLine(lapiz, cabezaX, cuerpoYInicio, cabezaX, cuerpoYFin);

                    if (errores >= 3)
                    {
                        g.DrawLine(lapiz, cabezaX, brazosY, cabezaX - 45, brazosY + 13);
                        g.DrawLine(lapiz, cabezaX, brazosY, cabezaX + 45, brazosY + 13);
                    }

                    if (errores >= 4)
                    {
                        g.DrawLine(lapiz, cabezaX, piernasY, cabezaX - 40, piernasY + 80);
                        g.DrawLine(lapiz, cabezaX, piernasY, cabezaX + 40, piernasY + 80);
                    }

                    if (errores >= 5)
                    {
                        g.FillEllipse(relleno, centroCabezaX - separacionOjos - tamanoOjo / 2, centroCabezaY - alturaOjos, tamanoOjo, tamanoOjo);
                        g.FillEllipse(relleno, centroCabezaX + separacionOjos - tamanoOjo / 2, centroCabezaY - alturaOjos, tamanoOjo, tamanoOjo);
                    }
                }
                else
                {
                    if (errores >= 1)
                        g.DrawEllipse(lapiz, cabezaX - radioCabeza, cabezaY, tamanoCabeza, tamanoCabeza);

                    if (errores >= 2)
                        g.DrawLine(lapiz, cabezaX, cuerpoYInicio, cabezaX, cuerpoYFin);

                    if (errores >= 3)
                        g.DrawLine(lapiz, cabezaX, brazosY, cabezaX - 45, brazosY + 13);

                    if (errores >= 4)
                        g.DrawLine(lapiz, cabezaX, brazosY, cabezaX + 45, brazosY + 13);

                    if (errores >= 5)
                        g.DrawLine(lapiz, cabezaX, piernasY, cabezaX - 40, piernasY + 80);

                    if (errores >= 6)
                        g.DrawLine(lapiz, cabezaX, piernasY, cabezaX + 40, piernasY + 80);

                    if (errores >= 7)
                        g.FillEllipse(relleno, centroCabezaX - separacionOjos - tamanoOjo / 2, centroCabezaY - alturaOjos, tamanoOjo, tamanoOjo);

                    if (errores >= 8)
                        g.FillEllipse(relleno, centroCabezaX + separacionOjos - tamanoOjo / 2, centroCabezaY - alturaOjos, tamanoOjo, tamanoOjo);
                }
            }
        }

        private void MostrarResultado(bool ganado)
        {
            string mensaje = ganado ? "¡Felicidades! Has ganado." : "¡Game Over! Has perdido.";


            string palabraSecreta = "No disponible";
            if (juego != null && juego.PalabraSecreta != null)
            {
                palabraSecreta = juego.PalabraSecreta;
            }

            MessageBox.Show(mensaje + $"\nLa palabra era: {palabraSecreta}", "Resultado del Juego");

            btnJugarDeNuevo.Visible = true;
            btnJugarDeNuevo.Enabled = true;
            btnJugarDeNuevo.BringToFront();

            DeshabilitarTeclado();
        }

        private void DeshabilitarTeclado()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Text.Length == 1)
                {
                    btn.Enabled = false;
                    btn.BackColor = Color.PaleGoldenrod;
                }
            }
        }

        

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (temporizador != null)
            {
                temporizador.Stop();
                temporizador.Dispose();
            }
        }

        private void btnJugarDeNuevo_Click(object sender, EventArgs e)
        {
            Form2 inicio = new Form2();
            inicio.Show();
            this.Hide(); 

            inicio.FormClosed += (s, args) => this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
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
