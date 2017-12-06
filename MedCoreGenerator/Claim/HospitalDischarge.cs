using MedCore.Enums;
using System;

namespace MedCore.Claim
{
    public class HospitalDischarge : EnumParser, ICreatesCSV
    {
        private const string TYPE = "HD";
        public DateTime DischargeDate { get; set; }
        public HospitalDischargeCode DischargeCode { get; set; }

        public string GetCSV()
        {
            var dischargeDate = DischargeDate.ToString("yyyyMMddHHmm");
            var dischargeCode = GetStringFromEnumValue((int)DischargeCode);

            return $"{TYPE}|{dischargeDate}|{dischargeCode}|";
        }
    }
}