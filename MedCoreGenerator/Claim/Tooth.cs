using MedCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
