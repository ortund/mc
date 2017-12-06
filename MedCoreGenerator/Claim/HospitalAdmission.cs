using MedCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Claim
{
    public class HospitalAdmission : EnumParser
    {
        private const string TYPE = "HA"; // HA
        public DateTime AdmissionDate { get; set; }
        public ServiceType ServiceType { get; set; }

        public override string ToString()
        {
            var admissionDate = AdmissionDate.ToString("yyyyMMddHHmm");
            var serviceType = GetStringFromEnumValue((int)ServiceType);

            return $"{TYPE}|{admissionDate}|{serviceType}|";
        }
    }
}
