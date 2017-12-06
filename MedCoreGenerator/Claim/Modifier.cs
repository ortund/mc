using MedCore.Enums;

namespace MedCore.Claim
{
    public class Modifier : EnumParser
    {
        public const string TYPE = "MD";
        public string Code { get; set; }
        public TreatmentModifierType Type { get; set; }

        public override string ToString()
        {
            var type = GetStringFromEnumValue((int)Type);
            return $"{TYPE}|{Code}|{type}|";
        }
    }
}
