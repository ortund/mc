using MedCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Claim
{
    public class DoctorDiagnosis : EnumParser
    {
        private const string TYPE = "D";
        public DoctorType DoctorType { get; set; }
        public DiagnosisCodeType DiagnosisCodeType { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }

        public Treatment Treatment { get; set; }
        public ExtendedDiagnosis ExtendedDiagnosis { get; set; }

        public override string ToString()
        {
            var doctorType = GetStringFromEnumValue((int)DoctorType);
            var diagnosisCodeType = GetStringFromEnumValue((int)DiagnosisCodeType);
            var extendedDiagnosis = GetStringFromEnumValue((int)ExtendedDiagnosis);

            return $"{TYPE}|{doctorType}|{diagnosisCodeType}|{Diagnosis}|{Description}|{extendedDiagnosis}|";
        }
    }
}
