using MedCore.Enums;

namespace MedCore.Claim
{
    public class Tooth : EnumParser
    {
        private const string TYPE = "N";

        public int Number { get; set; }
        public ToothSurface Surface { get; set; }
        public string SuperNumaryToothIndicator { get; set; }

        public override string ToString()
        {
            var tootSurface = GetStringFromEnumValue((int)Surface);
            return $"{TYPE}|{Number}|{tootSurface}|{SuperNumaryToothIndicator}|";
        }
    }
}
