using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ahorcado
{
    public partial class Form3 : Form
    {
        private JuegoAhorcado juego;
        private Timer temporizador;
        private int tiempoRestante = 60;
        private PictureBox picAhorcado;
        private Label lblPalabra;
        private Label lblIntentos;
        private Label lblTiempo;
        private Button btnJugarDeNuevo;

        public Form3(string palabra, bool conTiempo, bool dificil)
        {
            juego = new JuegoAhorcado(palabra, dificil);
            InicializarFormulario();
            InicializarTeclado();
            ActualizarInterfaz();

            if (conTiempo)
            {
                InicializarTemporizador();
            }
        }

        private void InicializarFormulario()
        {
            this.Text = "Juego del Ahorcado";
            this.ClientSize = new Size(600, 450);
            this.StartPosition = FormStartPosition.CenterScreen;

            // PictureBox para el ahorcado
            picAhorcado = new PictureBox();
            picAhorcado.Location = new Point(50, 50);
            picAhorcado.Size = new Size(300, 200);
            picAhorcado.BackColor = Color.White;
            picAhorcado.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(picAhorcado);

            // Label para la palabra
            lblPalabra = new Label();
            lblPalabra.AutoSize = true;
            lblPalabra.Font = new Font("Courier New", 18F);
            lblPalabra.Location = new Point(50, 260);
            lblPalabra.Size = new Size(300, 27);
            this.Controls.Add(lblPalabra);

            // Label para intentos
            lblIntentos = new Label();
            lblIntentos.AutoSize = true;
            lblIntentos.Location = new Point(400, 50);
            lblIntentos.Size = new Size(150, 13);
            this.Controls.Add(lblIntentos);

            // Label para tiempo
            lblTiempo = new Label();
            lblTiempo.AutoSize = true;
            lblTiempo.Location = new Point(400, 80);
            lblTiempo.Size = new Size(150, 13);
            lblTiempo.Visible = false;
            this.Controls.Add(lblTiempo);

            // Botón jugar de nuevo
            btnJugarDeNuevo = new Button();
            btnJugarDeNuevo.Location = new Point(400, 350);
            btnJugarDeNuevo.Size = new Size(100, 30);
            btnJugarDeNuevo.Text = "Jugar de Nuevo";
            btnJugarDeNuevo.Click += new EventHandler(btnJugarDeNuevo_Click);
            btnJugarDeNuevo.Visible = false;
            this.Controls.Add(btnJugarDeNuevo);
        }

        private void InicializarTeclado()
        {
            int x = 50;
            int y = 300;
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            foreach (char letra in letras)
            {
                Button btnLetra = new Button();
                btnLetra.Text = letra.ToString();
                btnLetra.Size = new Size(30, 30);
                btnLetra.Location = new Point(x, y);
                btnLetra.Click += (s, e) => ProcesarLetra(letra);
                this.Controls.Add(btnLetra);

                x += 35;
                if (x > 400)
                {
                    x = 50;
                    y += 35;
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
            lblTiempo.Text = $"Tiempo: {tiempoRestante}s";
        }

        private void Temporizador_Tick(object sender, EventArgs e)
        {
            tiempoRestante--;
            lblTiempo.Text = $"Tiempo: {tiempoRestante}s";

            if (tiempoRestante <= 0)
            {
                temporizador.Stop();
                MostrarResultado(false);
            }
        }

        private void ProcesarLetra(char letra)
        {
            juego.ProcesarIntento(letra);
            ActualizarInterfaz();

            if (juego.JuegoTerminado)
            {
                if (temporizador != null) temporizador.Stop();
                MostrarResultado(juego.JuegoGanado);
            }
        }

        private void ActualizarInterfaz()
        {
            lblPalabra.Text = juego.PalabraOculta;
            lblIntentos.Text = $"Intentos restantes: {juego.IntentosRestantes}";
            DibujarAhorcado();
        }

        private void DibujarAhorcado()
        {
            Bitmap bitmap = new Bitmap(picAhorcado.Width, picAhorcado.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                Pen lapiz = new Pen(Color.Black, 2);

                int errores = juego.ErroresCometidos;

                if (errores >= 1) g.DrawLine(lapiz, 50, 200, 150, 200);
                if (errores >= 2) g.DrawLine(lapiz, 100, 200, 100, 50);
                if (errores >= 3) g.DrawLine(lapiz, 100, 50, 200, 50);
                if (errores >= 4) g.DrawLine(lapiz, 200, 50, 200, 80);
                if (errores >= 5) g.DrawEllipse(lapiz, 190, 80, 20, 20);
                if (errores >= 6) g.DrawLine(lapiz, 200, 100, 200, 140);
                if (errores >= 7) g.DrawLine(lapiz, 200, 110, 180, 130);
                if (errores >= 8) g.DrawLine(lapiz, 200, 110, 220, 130);
                if (errores >= 9) g.DrawLine(lapiz, 200, 140, 180, 170);
                if (errores >= 10) g.DrawLine(lapiz, 200, 140, 220, 170);
            }
            picAhorcado.Image = bitmap;
        }

        private void MostrarResultado(bool ganado)
        {
            string mensaje = ganado ? "¡Felicidades! Has ganado." : "¡Game Over! Has perdido.";
            MessageBox.Show(mensaje);

            btnJugarDeNuevo.Visible = true;
            DeshabilitarTeclado();
        }

        private void DeshabilitarTeclado()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button btn && btn.Text.Length == 1)
                {
                    btn.Enabled = false;
                }
            }
        }

        private void btnJugarDeNuevo_Click(object sender, EventArgs e)
        {
            Form1 inicio = new Form1();
            inicio.Show();
            this.Close();
        }
    }
}