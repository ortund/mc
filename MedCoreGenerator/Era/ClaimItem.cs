using MedCore.Enums;
using System;

namespace MedCore.Era
{
    public class ClaimItem
    {
        private const string TYPE = "I";

        public string PmaIdentifier { get; set; }
        public string PmaClaimLineNumber { get; set; }
        public string PmaClaimNumber { get; set; }
        public string LabReferenceNumber { get; set; }
        public DateTime TreatmentStartDate { get; set; }
        public DateTime TreatmentEndDate { get; set; }
        public string ModifierCode { get; set; }
        public string NAPPICode { get; set; }
        public string TariffDescription { get; set; }
        public ResponseResultCode ResponseResultCode { get; set; }

        public override string ToString()
        {
            var startDate = TreatmentStartDate.ToString("yyyyMMdd");
            var endDate = TreatmentEndDate.ToString("yyyyMMdd");

            return $"{TYPE}|{PmaIdentifier}|{PmaClaimLineNumber}|{PmaClaimNumber}|{LabReferenceNumber}|{startDate}|{endDate}|{ModifierCode}|{NAPPICode}|{TariffDescription}|{ResponseResultCode}|";
        }
    }
}
