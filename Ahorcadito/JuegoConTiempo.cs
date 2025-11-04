using System;

namespace Ahorcado
{
    public class JuegoConTiempo : JuegoAhorcado
    {
        private int tiempoLimite;
        private int tiempoTranscurrido;

        public int TiempoRestante => tiempoLimite - tiempoTranscurrido;
        public bool TiempoAgotado => tiempoTranscurrido >= tiempoLimite;

        public JuegoConTiempo(string palabra, bool dificil, int tiempoLimiteSegundos)
            : base(palabra, dificil)
        {
            tiempoLimite = tiempoLimiteSegundos;
            tiempoTranscurrido = 0;
        }

        public void IncrementarTiempo(int segundos)
        {
            tiempoTranscurrido += segundos;
        }

        public override bool JuegoTerminado => base.JuegoTerminado || TiempoAgotado;

        public override void ReiniciarJuego(string nuevaPalabra)
        {
            base.ReiniciarJuego(nuevaPalabra);
            tiempoTranscurrido = 0;
        }
    }
}