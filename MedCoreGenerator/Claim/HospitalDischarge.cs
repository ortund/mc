using MedCore.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class HospitalDischarge : EnumParser, ICreatesCSV
    {
        private const string TYPE = "HD";
        [Display(Name = "Discharge Date")]
        public DateTime DischargeDate { get; set; }
        [Display(Name = "Discharge Code")]
        public HospitalDischargeCode DischargeCode { get; set; }

        public string GetCSV()
        {
            var dischargeDate = DischargeDate.ToString("yyyyMMddHHmm");
            var dischargeCode = GetStringFromEnumValue((int)DischargeCode);

            return $"{TYPE}|{dischargeDate}|{dischargeCode}|";
        }
    }
}