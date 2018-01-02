using MedCore.Claim;
using MedCore.Enums;
using System;
using System.Text;

namespace MedCore.Era
{
    public class ClaimItem : EnumParser, ICreatesCSV
    {
        private const string TYPE = "I";

        public string PmaIdentifier { get; set; }
        public string PmaClaimLineNumber { get; set; }
        public string PmaClaimNumber { get; set; }
        public string LabReferenceNumber { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime? TreatmentStartDate { get; set; }
        public DateTime? TreatmentEndDate { get; set; }
        public string ModifierCode { get; set; }
        public string NAPPICode { get; set; }
        public string TariffDescription { get; set; }
        public ResponseResultCode ResponseResultCode { get; set; }
        /// <summary>
        /// Overrides the ResponseResultCode property.
        /// If this value is not null or empty, it will be used in place of whatever value is set on the ResponseResultCode property.
        /// </summary>
        public string ResponseResultCodeOverride { get; set; }


        private string _treatmentStartDate;
        private string _treatmentEndDate;
        private string _responseResultCode;
        public string GetCSV()
        {
            DoRefactoring();

            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{PmaIdentifier}|");
            sb.Append($"{PmaClaimLineNumber}|");
            sb.Append($"{PmaClaimNumber}|");
            sb.Append($"{LabReferenceNumber}|");
            sb.Append($"{TrackingNumber}|");
            sb.Append($"{_treatmentStartDate}|");
            sb.Append($"{_treatmentEndDate}|");
            sb.Append($"{ModifierCode}|");
            sb.Append($"{NAPPICode}|");
            sb.Append($"{TariffDescription}|");
            sb.Append($"{_responseResultCode}|");

            return sb.ToString();
        }

        private void DoRefactoring()
        {
            if (TreatmentStartDate != null)
            {
                var startDate = (DateTime)TreatmentStartDate;
                _treatmentStartDate = startDate.ToString("yyyyMMdd");
            }

            if (TreatmentEndDate != null)
            {
                var endDate = (DateTime)TreatmentEndDate;
                _treatmentEndDate = endDate.ToString("yyyyMMdd");
            }

            if (!String.IsNullOrEmpty(ResponseResultCodeOverride))
            {
                _responseResultCode = ResponseResultCodeOverride;
            }
            else
            {
                _responseResultCode = GetStringFromEnumValue((int)ResponseResultCode);
            }
        }
    }
}
