using MedCore.Enums;
using System;
using System.Text;

namespace MedCore.Claim
{
    public class Patient : EnumParser, ICreatesCSV
    {
        private const string TYPE = "P";
        public string DependantCode { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public PatientRelationCode PatientRelationCode { get; set; }
        public long? IdNumber { get; set; }
        public DateTime? RecallDate { get; set; }
        public string COID { get; set; }
        public DateTime? InjuryDate { get; set; }
        public string EmployerName { get; set; }
        public string EmployerRegistrationNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public string InsuranceNumber { get; set; }
        public string AuthorizationNumber { get; set; }
        public string ConfirmationNumber { get; set; }
        public string PMANumber { get; set; }
        public PatientType PatientType { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string PMAClaimReferenceNumber { get; set; }
        public bool PadDecimals { get; set; }

        private string _recallDate;
        private string _injuryDate;
        private string _gender;
        private string _patientRelationCode;
        private string _patientType;
        private string _height;
        private string _weight;
        public string GetCSV()
        {
            DoRefactoring();

            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{DependantCode}|");
            sb.Append($"{Surname}|");
            sb.Append($"{Initials}|");
            sb.Append($"{FullName}|");
            sb.Append($"{DOB:yyyyMMdd}|");
            sb.Append($"{_gender}|");
            sb.Append($"{_patientRelationCode}|");
            sb.Append($"{IdNumber}|");
            sb.Append($"{_recallDate}|");
            sb.Append($"{COID}|");
            sb.Append($"{_injuryDate}|");
            sb.Append($"{EmployerName}|");
            sb.Append($"{EmployerRegistrationNumber}|");
            sb.Append($"{EmployeeNumber}|");
            sb.Append($"{InsuranceNumber}|");
            sb.Append($"{AuthorizationNumber}|");
            sb.Append($"{ConfirmationNumber}|");
            sb.Append($"{PMANumber}|");
            sb.Append($"{_patientType}|");
            sb.Append($"{_height}|");
            sb.Append($"{_weight}|");
            sb.Append($"{PMAClaimReferenceNumber}|");

            return sb.ToString();
        }

        private void DoRefactoring()
        {
            if (RecallDate != null)
            {
                var rDate = (DateTime)RecallDate;
                _recallDate = (rDate == DateTime.MinValue) ? string.Empty : rDate.ToString("yyyyMMddHHmm");
            }
            
            if (InjuryDate != null)
            {
                var iDate = (DateTime)InjuryDate;
                _injuryDate = (iDate == DateTime.MinValue) ? string.Empty : iDate.ToString("yyyyMMdd");
            }

            _gender = Gender.ToString().Substring(0, 1);
            _patientRelationCode = (PatientRelationCode == PatientRelationCode.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)PatientRelationCode);
            _patientType = (PatientType == PatientType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)PatientType);

            _height = string.Empty;
            _weight = string.Empty;

            if (PadDecimals && Height != null && Weight != null)
            {
                _height = (Height > 0) ? $"0{Height.ToString()}" : string.Empty;
                _weight = (Weight > 0) ? $"0{Weight.ToString()}" : string.Empty;
            }
            else if (Height != null && Weight != null)
            {
                _height = (Height > 0) ? Height.ToString() : string.Empty;
                _weight = (Weight > 0) ? Weight.ToString() : string.Empty;
            }
        }
    }
}