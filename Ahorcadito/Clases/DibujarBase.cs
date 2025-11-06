using System.Drawing;

namespace Ahorcado
{
    public abstract class DibujadorBase
    {
        protected Color colorLinea;
        protected int grosorLinea;

        public DibujadorBase(Color color, int grosor)
        {
            colorLinea = color;
            grosorLinea = grosor;
        }

        public abstract Bitmap Dibujar(int errores, int ancho, int alto);
        protected abstract void DibujarParte(Graphics g, Pen lapiz, int parte);
    }

    public class DibujadorAhorcado : DibujadorBase
    {
        public DibujadorAhorcado() : base(Color.Brown, 3) { }

        public override Bitmap Dibujar(int errores, int ancho, int alto)
        {
            Bitmap bitmap = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                Pen lapiz = new Pen(colorLinea, grosorLinea);

                for (int i = 1; i <= errores; i++)
                {
                    if (i <= 8)
                    {
                        DibujarParte(g, lapiz, i);
                    }
                }
            }
            return bitmap;
        }

        protected override void DibujarParte(Graphics g, Pen lapiz, int parte)
        {
            switch (parte)
            {
                case 1: DibujarBase(g, lapiz); break;
                case 2: DibujarPoste(g, lapiz); break;
                case 3: DibujarTravesaño(g, lapiz); break;
                case 4: DibujarSoga(g, lapiz); break;
                case 5: DibujarCabeza(g, lapiz); break;
                case 6: DibujarCuerpo(g, lapiz); break;
                case 7: DibujarBrazoIzquierdo(g, lapiz); break;
                case 8: DibujarBrazoDerecho(g, lapiz); break;
                case 9: DibujarPiernaIzquierda(g, lapiz); break;
                case 10: DibujarPiernaDerecha(g, lapiz); break;
            }
        }

        private void DibujarBase(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 50, 200, 150, 200);
        }

        private void DibujarPoste(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 100, 200, 100, 50);
        }

        private void DibujarTravesaño(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 100, 50, 200, 50);
        }

        private void DibujarSoga(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 50, 200, 80);
        }

        private void DibujarCabeza(Graphics g, Pen lapiz)
        {
            g.DrawEllipse(lapiz, 190, 80, 20, 20);
        }

        private void DibujarCuerpo(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 100, 200, 140);
        }

        private void DibujarBrazoIzquierdo(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 110, 180, 130);
        }

        private void DibujarBrazoDerecho(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 110, 220, 130);
        }

        private void DibujarPiernaIzquierda(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 140, 180, 170);
        }

        private void DibujarPiernaDerecha(Graphics g, Pen lapiz)
        {
            g.DrawLine(lapiz, 200, 140, 220, 170);
        }
    }
}