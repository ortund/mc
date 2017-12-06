using MedCore.Enums;

namespace MedCore.Claim
{
    public class DoctorDiagnosis : EnumParser, ICreatesCSV
    {
        private const string TYPE = "D";
        public DoctorType DoctorType { get; set; }
        public DiagnosisCodeType DiagnosisCodeType { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }

        public Treatment Treatment { get; set; }
        public ExtendedDiagnosis ExtendedDiagnosis { get; set; }
        
        public string GetCSV()
        {
            var doctorType = GetStringFromEnumValue((int)DoctorType);
            var diagnosisCodeType = GetStringFromEnumValue((int)DiagnosisCodeType);
            var extendedDiagnosis = GetStringFromEnumValue((int)ExtendedDiagnosis);

            return $"{TYPE}|{doctorType}|{diagnosisCodeType}|{Diagnosis}|{Description}|{extendedDiagnosis}|";
        }
    }
}
