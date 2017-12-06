using MedCore.Enums;
using System;
using System.Collections.Generic;

namespace MedCore.Claim
{
    public class Treatment : EnumParser, ICreatesCSV, IComparable, IComparable<Treatment>
    {
        public Doctor Doctor { get; set; }
        public List<DoctorDiagnosis> Diagnoses { get; set; }
        public List<Tooth> Teeth { get; set; }
        public TreatmentFinancialRecord FinancialRecord { get; set; }

        private const string _type = "T";

        public string Number { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AuthorizationNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string ClaimLineNumber { get; set; }
        public TreatmentType Type { get; set; }
        public int UnitQuantity { get; set; }
        public UnitType UnitType { get; set; }
        public string ProcedureModifierCode { get; set; }
        public TariffCodeType TariffCode { get; set; }
        public TreatmentModifierType ModifierType { get; set; }
        public string NAPPICode { get; set; }
        public ServiceTariff ServiceTariff { get; set; }
        public string Description { get; set; }
        public bool PMBCondition { get; set; }
        public DateTime ScriptWrittenDate { get; set; }
        public BenefitType BenefitType { get; set; }
        public HospitalTariffType HospitalTariff { get; set; }
        public string LabPCNS { get; set; }
        public string LabReferenceNumber { get; set; }
        public string LabName { get; set; }
        public ResubmissionReason ResubmissionReason { get; set; }
        public string ClaimNumber { get; set; }
        public DateTime ClaimDate { get; set; }
        public string PHISCPlaceOfService { get; set; }
        public bool IsPmbConditionEmpty { get; set; }
        public bool IncludeTimeOnDates { get; set; }
        
        public string GetCSV()
        {
            // ToString any properties who's types are not already strings
            var startDate = (IncludeTimeOnDates) ? StartDate.ToString("yyyyMMddHHmm") : StartDate.ToString("yyyyMMdd");
            var endDate = (IncludeTimeOnDates) ? EndDate.ToString("yyyyMMddHHmm") : EndDate.ToString("yyyyMMdd");
            var scriptWrittenDate = (ScriptWrittenDate == DateTime.MinValue) ? string.Empty : ScriptWrittenDate.ToString("yyyyMMdd");
            var claimDate = (ClaimDate == DateTime.MinValue) ? string.Empty : ClaimDate.ToString("yyyyMMddHHmm");

            var pmbCondition = (PMBCondition) ? "Y" : "N";
            if (IsPmbConditionEmpty)
            {
                pmbCondition = string.Empty;
            }

            var type = GetStringFromEnumValue((int)Type);
            var unitType = GetStringFromEnumValue((int)UnitType);
            var tariffCode = GetStringFromEnumValue((int)TariffCode);
            var modifierType = (ModifierType == TreatmentModifierType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)ModifierType);
            var serviceTariff = (ServiceTariff == ServiceTariff.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)ServiceTariff);
            var benefitType = (BenefitType == BenefitType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)BenefitType);
            var hospitalTariff = (HospitalTariff == HospitalTariffType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)HospitalTariff);
            var resubmissionReason = (ResubmissionReason == ResubmissionReason.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)ResubmissionReason);

            return $"{_type}|{Number}|{startDate}|{endDate}|{AuthorizationNumber}|{InvoiceNumber}|{ClaimLineNumber}|{type}|{UnitQuantity}|{unitType}|{ProcedureModifierCode}|{tariffCode}|{modifierType}|{NAPPICode}|{serviceTariff}|{Description}|{pmbCondition}|{scriptWrittenDate}|{benefitType}|{hospitalTariff}|{LabPCNS}|{LabReferenceNumber}|{LabName}|{resubmissionReason}|{ClaimNumber}|{claimDate}|{PHISCPlaceOfService}|";
        }

        public bool Equals(Treatment other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Number.Equals(Number);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(Treatment) && Equals((Treatment)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Number.GetHashCode();
            }
        }
        
        public static bool operator ==(Treatment x, Treatment y)
        {
            var xIsNull = ReferenceEquals(null, x);
            var yIsNull = ReferenceEquals(null, y);

            if (xIsNull ^ yIsNull) return false; // One is null and one isn't (XOR)
            return xIsNull || x.Equals(y);
        }

        public static bool operator !=(Treatment x, Treatment y)
        {
            return !(x == y);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            if (!(obj is Treatment))
            {
                throw new ArgumentException("Argument must be money");
            }
            return CompareTo((Treatment)obj);
        }

        public int CompareTo(Treatment other)
        {
            if (int.Parse(Number) < int.Parse(other.Number))
                return -1;

            return int.Parse(Number) > int.Parse(other.Number) ? 1 : 0;
        }

        public override string ToString()
        {
            return Number;
        }

    }
}
