using MedCore.Enums;

namespace MedCore.Claim
{
    public class Tooth : EnumParser, ICreatesCSV
    {
        private const string TYPE = "N";

        public int Number { get; set; }
        public ToothSurface Surface { get; set; }
        public string SuperNumaryToothIndicator { get; set; }

        public string GetCSV()
        {
            var tootSurface = (Surface == ToothSurface.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)Surface);
            return $"{TYPE}|{Number}|{tootSurface}|{SuperNumaryToothIndicator}|";
        }
    }
}
