using MedCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;

namespace MedCore.Claim
{
    public class Treatment : EnumParser
    {
        public Doctor Doctor { get; set; }
        public List<DoctorDiagnosis> Diagnoses { get; set; }
        public List<Tooth> Teeth { get; set; }
        public TreatmentFinancialRecord FinancialRecord { get; set; }

        private const string TYPE = "T";
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

        public override string ToString()
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

            return $"{TYPE}|{Number}|{startDate}|{endDate}|{AuthorizationNumber}|{InvoiceNumber}|{ClaimLineNumber}|{type}|{UnitQuantity}|{unitType}|{ProcedureModifierCode}|{tariffCode}|{modifierType}|{NAPPICode}|{serviceTariff}|{Description}|{pmbCondition}|{scriptWrittenDate}|{benefitType}|{hospitalTariff}|{LabPCNS}|{LabReferenceNumber}|{LabName}|{resubmissionReason}|{ClaimNumber}|{claimDate}|{PHISCPlaceOfService}|";
        }
    }
}
