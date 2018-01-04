using MedCore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Authorization Number")]
        public string AuthorizationNumber { get; set; }
        [Display(Name = "Invoice Number")]
        public string InvoiceNumber { get; set; }
        [Display(Name = "Claim Line Number")]
        public string ClaimLineNumber { get; set; }
        public TreatmentType Type { get; set; }
        [Display(Name = "Unit Quantity")]
        public int UnitQuantity { get; set; }
        [Display(Name = "Unit Type")]
        public UnitType UnitType { get; set; }
        [Display(Name = "Procedure Modifier Code")]
        public string ProcedureModifierCode { get; set; }
        [Display(Name = "Tariff Code")]
        public TariffCodeType TariffCode { get; set; }
        [Display(Name = "Modifier Type")]
        public TreatmentModifierType ModifierType { get; set; }
        [Display(Name = "NAPPI Code")]
        public string NAPPICode { get; set; }
        [Display(Name = "Service Tariff")]
        public ServiceTariff ServiceTariff { get; set; }
        public string Description { get; set; }
        [Display(Name = "PMB Condition")]
        public bool PMBCondition { get; set; }
        [Display(Name = "Script Written Date")]
        public DateTime ScriptWrittenDate { get; set; }
        [Display(Name = "Benefit Type")]
        public BenefitType BenefitType { get; set; }
        [Display(Name = "Hospital Tariff")]
        public HospitalTariffType HospitalTariff { get; set; }
        [Display(Name = "Lab PCNS")]
        public string LabPCNS { get; set; }
        [Display(Name = "Lab Reference Number")]
        public string LabReferenceNumber { get; set; }
        [Display(Name = "Lab Name")]
        public string LabName { get; set; }
        [Display(Name = "Resubmission Reason")]
        public ResubmissionReason ResubmissionReason { get; set; }
        [Display(Name = "Claim NUmber")]
        public string ClaimNumber { get; set; }
        [Display(Name = "Claim Date")]
        public DateTime? ClaimDate { get; set; }
        [Display(Name = "PHISC Place of Service")]
        public string PHISCPlaceOfService { get; set; }

        /// <summary>
        /// If true, the PMB Condition value will be output as an empty string.
        /// </summary>
        [Display(Name = "Is PMB Condition Empty")]
        public bool IsPmbConditionEmpty { get; set; }

        /// <summary>
        /// If true, start and end date values will have the time of day included on them.
        /// </summary>
        [Display(Name = "Include Time On Dates")]
        public bool IncludeTimeOnDates { get; set; }
        
        public string GetCSV()
        {
            DateTime eDate = DateTime.MinValue;
            if (EndDate != null)
            {
                eDate = (DateTime)EndDate;
            }

            // ToString any properties who's types are not already strings
            var startDate = (IncludeTimeOnDates) ? StartDate.ToString("yyyyMMddHHmm") : StartDate.ToString("yyyyMMdd");
            var endDate = (IncludeTimeOnDates) ? eDate.ToString("yyyyMMddHHmm") : eDate.ToString("yyyyMMdd");
            var scriptWrittenDate = (ScriptWrittenDate == DateTime.MinValue) ? string.Empty : ScriptWrittenDate.ToString("yyyyMMdd");

            var claimDate = string.Empty;
            if (ClaimDate != null)
            {
                var cDate = (DateTime)ClaimDate;
                claimDate = (cDate == DateTime.MinValue) ? string.Empty : cDate.ToString("yyyyMMddHHmm");
            }
            var pmbCondition = (PMBCondition) ? "Y" : "N";
            if (IsPmbConditionEmpty)
            {
                pmbCondition = string.Empty;
            }

            if (EndDate == DateTime.MinValue || EndDate == null)
            {
                endDate = string.Empty;
            }

            var type = GetStringFromEnumValue((int)Type);
            var unitType = GetStringFromEnumValue((int)UnitType);
            var tariffCode = (TariffCode == TariffCodeType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)TariffCode);
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
