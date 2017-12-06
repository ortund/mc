using MedCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
