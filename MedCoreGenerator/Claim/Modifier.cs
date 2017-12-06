using MedCore.Enums;

namespace MedCore.Claim
{
    public class Modifier : EnumParser, ICreatesCSV
    {
        public const string TYPE = "MD";
        public string Code { get; set; }
        public TreatmentModifierType Type { get; set; }

        public string GetCSV()
        {
            var type = GetStringFromEnumValue((int)Type);
            return $"{TYPE}|{Code}|{type}|";
        }
    }
}
