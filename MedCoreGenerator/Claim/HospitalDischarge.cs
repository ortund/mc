using MedCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Claim
{
    public class HospitalDischarge : EnumParser
    {
        private const string TYPE = "HD";
        public DateTime DischargeDate { get; set; }
        public HospitalDischargeCode DischargeCode { get; set; }

        public override string ToString()
        {
            var dischargeDate = DischargeDate.ToString("yyyyMMddHHmm");
            var dischargeCode = GetStringFromEnumValue((int)DischargeCode);

            return $"{TYPE}|{dischargeDate}|{dischargeCode}|";
        }
    }
}