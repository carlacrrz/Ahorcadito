using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahorcado
{
    public abstract class ModoDificultad
    {
        public abstract int IntentosMaximos { get; }
        public abstract string Nombre { get; }
        public abstract bool EsConTiempo { get; }
        public abstract int TiempoLimite { get; }
    }

    public class ModoNormal : ModoDificultad
    {
        public override int IntentosMaximos => 10;
        public override string Nombre => "Normal";
        public override bool EsConTiempo => false;
        public override int TiempoLimite => 0;
    }

    public class ModoDificil : ModoDificultad
    {
        public override int IntentosMaximos => 6;
        public override string Nombre => "Difícil";
        public override bool EsConTiempo => false;
        public override int TiempoLimite => 0;
    }

    public class ModoContraReloj : ModoDificultad
    {
        public override int IntentosMaximos => 10;
        public override string Nombre => "Contra Reloj";
        public override bool EsConTiempo => true;
        public override int TiempoLimite => 60;
    }

    public class ModoExtremo : ModoDificultad
    {
        public override int IntentosMaximos => 6;
        public override string Nombre => "Extremo";
        public override bool EsConTiempo => true;
        public override int TiempoLimite => 45;
    }
}