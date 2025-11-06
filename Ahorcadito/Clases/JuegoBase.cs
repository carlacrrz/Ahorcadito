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
        private string[] caracteres;

        public string PalabraSecreta
        {
            get { return palabraSecreta; }
            protected set { palabraSecreta = value; }

        }
        public string PalabraOculta
        {
            get
            {
                if (string.IsNullOrEmpty(palabraSecreta))
                    return "";

                var caracteresOcultos = new List<char>();

                for (int i = 0; i < palabraSecreta.Length; i++)
                {
                    char letra = palabraSecreta[i];
                    if (letrasAdivinadas.Contains(letra))
                        caracteresOcultos.Add(letra);
                    else
                        caracteresOcultos.Add('_');

                    if (i < palabraSecreta.Length - 1)
                        caracteresOcultos.Add(' ');
                }

                return new string(caracteresOcultos.ToArray());
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