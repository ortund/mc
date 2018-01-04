using MedCore.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedCore.Claim
{
    public class Patient : EnumParser, ICreatesCSV
    {
        private const string TYPE = "P";
        [Display(Name = "Dependant Code")]
        public string DependantCode { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        [Display(Name = "Full Names")]
        public string FullName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Patient Relation Code")]
        public PatientRelationCode PatientRelationCode { get; set; }
        [Display(Name = "ID Number")]
        public long? IdNumber { get; set; }
        [Display(Name = "Recall Date")]
        public DateTime? RecallDate { get; set; }
        public string COID { get; set; }
        [Display(Name = "Injury Date")]
        public DateTime? InjuryDate { get; set; }
        [Display(Name = "Employer Name")]
        public string EmployerName { get; set; }
        [Display(Name = "Employer Registration Number")]
        public string EmployerRegistrationNumber { get; set; }
        [Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }
        [Display(Name = "Insurance Number")]
        public string InsuranceNumber { get; set; }
        [Display(Name = "Authorization Number")]
        public string AuthorizationNumber { get; set; }
        [Display(Name = "Confirmation Number")]
        public string ConfirmationNumber { get; set; }
        [Display(Name = "PMA Number")]
        public string PMANumber { get; set; }
        [Display(Name = "Patient Type")]
        public PatientType PatientType { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        [Display(Name = "PMA Claim Reference Number")]
        public string PMAClaimReferenceNumber { get; set; }

        /// <summary>
        /// If true, height and weight values will be left padded with a 0.
        /// </summary>
        /// 
        [Display(Name = "Pad Decimals")]
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