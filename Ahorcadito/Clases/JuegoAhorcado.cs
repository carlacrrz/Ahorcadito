using System;
using System.Collections.Generic;
using System.Linq;

namespace Ahorcado
{
    public class JuegoAhorcado : JuegoBase
    {

        public JuegoAhorcado(string palabra, bool dificil)
        {

            palabraSecreta = palabra?.ToUpper() ?? "DEFAULT";
            letrasAdivinadas = new HashSet<char>();
            ConfigurarDificultad(dificil);
        }

        public override void ProcesarIntento(char letra)
        {
            letra = char.ToUpper(letra);

            if (letrasAdivinadas.Contains(letra))
                return;

            letrasAdivinadas.Add(letra);

            if (!palabraSecreta.Contains(letra))
            {
                intentosRestantes--;
            }
        }

        public override void ConfigurarDificultad(bool dificil)
        {
            intentosMaximos = dificil ? 5 : 8;
            intentosRestantes = intentosMaximos;
        }

        public override void ReiniciarJuego(string nuevaPalabra)
        {
            palabraSecreta = nuevaPalabra.ToUpper();
            letrasAdivinadas.Clear();
            intentosRestantes = intentosMaximos;
        }
    }
}