using System.Drawing;

namespace Ahorcado
{
    public class DibujadorAnimado : DibujadorBase
    {
        public DibujadorAnimado() : base(Color.DarkRed, 2) { }

        public override Bitmap Dibujar(int errores, int ancho, int alto)
        {
            Bitmap bitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.LightYellow);
                Pen lapiz = new Pen(colorLinea, grosorLinea);

                for (int i = 1; i <= errores; i++)
                {
                    if (i <= 10)
                    {
                        DibujarParte(g, lapiz, i);
                    }
                }

                if (errores >= 10)
                {
                    DibujarCaraTriste(g);
                }
            }
            return bitmap;
        }

        protected override void DibujarParte(Graphics g, Pen lapiz, int parte)
        {
            switch (parte)
            {
                case 1: DibujarBaseAnimada(g, lapiz); break;
                case 2: DibujarPosteAnimado(g, lapiz); break;
                case 3: DibujarTravesañoAnimado(g, lapiz); break;
                case 4: DibujarSogaAnimada(g, lapiz); break;
                case 5: DibujarCabezaAnimada(g, lapiz); break;
                case 6: DibujarCuerpoAnimado(g, lapiz); break;
                case 7: DibujarBrazoIzquierdoAnimado(g, lapiz); break;
                case 8: DibujarBrazoDerechoAnimado(g, lapiz); break;
                case 9: DibujarPiernaIzquierdaAnimada(g, lapiz); break;
                case 10: DibujarPiernaDerechaAnimada(g, lapiz); break;
            }
        }

        private void DibujarBaseAnimada(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 40, 210, 160, 210);
            g.DrawLine(lapiz, 45, 215, 155, 215);
        }

        private void DibujarPosteAnimado(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 95, 210, 95, 45);
            g.DrawLine(lapiz, 105, 210, 105, 45);
        }

        private void DibujarTravesañoAnimado(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 95, 45, 205, 45);
            g.DrawLine(lapiz, 95, 55, 205, 55);
        }

        private void DibujarSogaAnimada(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 45, 200, 85);
        }

        private void DibujarCabezaAnimada(Graphics g, Pen lapiz)
        {
            g.DrawEllipse(lapiz, 185, 85, 30, 30);
        }

        private void DibujarCuerpoAnimado(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 115, 200, 155);
        }

        private void DibujarBrazoIzquierdoAnimado(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 125, 175, 145);
        }

        private void DibujarBrazoDerechoAnimado(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 125, 225, 145);
        }

        private void DibujarPiernaIzquierdaAnimada(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 155, 175, 185);
        }

        private void DibujarPiernaDerechaAnimada(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 155, 225, 185);
        }

        private void DibujarCaraTriste(Graphics g)
        {
            Pen lapizOjos = new Pen(Color.Black, 2);
            g.DrawArc(lapizOjos, 192, 95, 5, 5, 0, 360);
            g.DrawArc(lapizOjos, 203, 95, 5, 5, 0, 360);

            Pen lapizBoca = new Pen(Color.Black, 2);
            g.DrawArc(lapizBoca, 192, 105, 16, 10, 0, 180);
        }
    }
}