using MedCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class DoctorDiagnosis : EnumParser, ICreatesCSV
    {
        private const string TYPE = "D";
        [Display(Name = "Doctor Type")]
        public DoctorType DoctorType { get; set; }
        [Display(Name = "Diagnosis Code Type")]
        public DiagnosisCodeType DiagnosisCodeType { get; set; }
        public string Diagnosis { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// The Treatment object to which this diagnosis pertains.
        /// </summary>
        public Treatment Treatment { get; set; }
        [Display(Name = "Extended Diagnosis")]
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
