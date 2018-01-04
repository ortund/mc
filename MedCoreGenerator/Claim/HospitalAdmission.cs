using MedCore.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class HospitalAdmission : EnumParser, ICreatesCSV
    {
        private const string TYPE = "HA"; // HA
        public DateTime AdmissionDate { get; set; }
        [Display(Name = "Service Type")]
        public ServiceType ServiceType { get; set; }

        public string GetCSV()
        {
            var admissionDate = AdmissionDate.ToString("yyyyMMddHHmm");
            var serviceType = GetStringFromEnumValue((int)ServiceType);

            return $"{TYPE}|{admissionDate}|{serviceType}|";
        }
    }
}
