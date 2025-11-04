using System;

namespace Ahorcado
{
    public static class FabricaJuegos
    {
        public static JuegoBase CrearJuego(string palabra, ModoDificultad modo)
        {
            if (modo.EsConTiempo)
            {
                bool esExtremo = modo is ModoExtremo;
                return new JuegoConTiempo(palabra, esExtremo, modo.TiempoLimite);
            }
            else
            {
                bool esDificil = modo is ModoDificil || modo is ModoExtremo;
                return new JuegoAhorcado(palabra, esDificil);
            }
        }

        public static DibujadorBase CrearDibujador(bool animado)
        {
            if (animado)
            {
                return new DibujadorAnimado();
            }
            else
            {
                return new DibujadorAhorcado();
            }
        }
    }
}