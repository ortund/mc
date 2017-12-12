using MedCore.Enums;
using System;

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
        
        public string GetCSV()
        {
            var dob = DOB.ToString("yyyyMMdd");

            var recallDate = string.Empty;
            if (RecallDate != null)
            {
                var rDate = (DateTime)RecallDate;
                recallDate = (rDate == DateTime.MinValue) ? string.Empty : rDate.ToString("yyyyMMddHHmm");
            }

            var injuryDate = string.Empty;
            if (InjuryDate != null)
            {
                var iDate = (DateTime)InjuryDate;
                injuryDate = (iDate == DateTime.MinValue) ? string.Empty : iDate.ToString("yyyyMMdd");
            }

            var gender = Gender.ToString().Substring(0, 1);
            var patientRelationCode = (PatientRelationCode == PatientRelationCode.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)PatientRelationCode);
            var patientType = (PatientType == PatientType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)PatientType);

            var height = string.Empty;
            var weight = string.Empty;

            if (PadDecimals && Height != null && Weight != null)
            {
                height = (Height > 0) ? $"0{Height.ToString()}" : string.Empty;
                weight = (Weight > 0) ? $"0{Weight.ToString()}" : string.Empty;
            }
            else if (Height != null && Weight != null)
            {
                height = (Height > 0) ? Height.ToString() : string.Empty;
                weight = (Weight > 0) ? Weight.ToString() : string.Empty;
            }

            return $"{TYPE}|{DependantCode}|{Surname}|{Initials}|{FullName}|{dob}|{gender}|{patientRelationCode}|{IdNumber}|{recallDate}|{COID}|{injuryDate}|{EmployerName}|{EmployerRegistrationNumber}|{EmployeeNumber}|{InsuranceNumber}|{AuthorizationNumber}|{ConfirmationNumber}|{PMANumber}|{patientType}|{height}|{weight}|{PMAClaimReferenceNumber}|";
        }
    }
}