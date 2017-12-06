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
        public long IdNumber { get; set; }
        public DateTime RecallDate { get; set; }
        public string COID { get; set; }
        public DateTime InjuryDate { get; set; }
        public string EmployerName { get; set; }
        public string EmployerRegistrationNumber { get; set; }
        public string EmployeeNumber { get; set; }
        public string InsuranceNumber { get; set; }
        public string AuthorizationNumber { get; set; }
        public string ConfirmationNumber { get; set; }
        public string PMANumber { get; set; }
        public PatientType PatientType { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string PMAClaimReferenceNumber { get; set; }
        
        public string GetCSV()
        {
            var dob = DOB.ToString("yyyyMMdd");
            var recallDate = (RecallDate == DateTime.MinValue) ? string.Empty : RecallDate.ToString("yyyyMMddHHmm");
            var injuryDate = (InjuryDate == DateTime.MinValue) ? string.Empty : InjuryDate.ToString("yyyyMMdd");

            var gender = Gender.ToString().Substring(0, 1);
            var patientRelationCode = GetStringFromEnumValue((int)PatientRelationCode);
            var patientType = (PatientType == PatientType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)PatientType);
            var height = (Height > 0) ? Height.ToString() : string.Empty;
            var weight = (Weight > 0) ? Weight.ToString() : string.Empty;

            return $"{TYPE}|{DependantCode}|{Surname}|{Initials}|{FullName}|{dob}|{gender}|{patientRelationCode}|{IdNumber}|{recallDate}|{COID}|{injuryDate}|{EmployerName}|{EmployerRegistrationNumber}|{EmployeeNumber}|{InsuranceNumber}|{AuthorizationNumber}|{ConfirmationNumber}|{PMANumber}|{patientType}|{height}|{weight}|{PMAClaimReferenceNumber}|";
        }
    }
}