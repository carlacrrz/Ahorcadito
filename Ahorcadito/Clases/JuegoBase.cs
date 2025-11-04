using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public abstract class JuegoBase
    {
        protected string palabraSecreta;
        protected HashSet<char> letrasAdivinadas;
        protected int intentosMaximos;
        protected int intentosRestantes;

        public string PalabraOculta
        {
            get
            {
                return new string(palabraSecreta.Select(letra =>
                    letrasAdivinadas.Contains(letra) ? letra : '_').ToArray());
            }
        }

        public int IntentosRestantes => intentosRestantes;
        public int ErroresCometidos => intentosMaximos - intentosRestantes;
        public virtual bool JuegoTerminado => JuegoGanado || intentosRestantes <= 0;
        public bool JuegoGanado => palabraSecreta.All(letra => letrasAdivinadas.Contains(letra));

        public abstract void ProcesarIntento(char letra);
        public abstract void ConfigurarDificultad(bool dificil);
        public abstract void ReiniciarJuego(string nuevaPalabra);
    }
}