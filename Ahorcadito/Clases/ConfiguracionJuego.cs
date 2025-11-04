namespace Ahorcado
{
    public class ConfiguracionJuego
    {
        public string Palabra { get; set; }
        public bool ConTiempo { get; set; }
        public bool ModoDificil { get; set; }
        public int TiempoLimite { get; set; } = 60;

        public ConfiguracionJuego(string palabra, bool conTiempo, bool modoDificil)
        {
            Palabra = palabra;
            ConTiempo = conTiempo;
            ModoDificil = modoDificil;
        }
    }
}