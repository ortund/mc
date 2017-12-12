using System.Text;

namespace MedCore.Claim
{
    public class ClaimFinancialRecord : ICreatesCSV
    {
        private const string TYPE = "F";
        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal TotalClaimedAmount { get; set; }
        public decimal ClaimDiscountAmount { get; set; }
        public decimal ClaimDeductibleAmount { get; set; }
        public decimal MMAPSurchargeAmount { get; set; }
        public decimal CoPaymentAmount { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal PatientLiableAmount { get; set; }
        public decimal MedicalFundLiableAmount { get; set; }
        public decimal MemberReimbursementAmount { get; set; }
        #region bools
        public bool OmitGrossAmount { get; set; }
        public bool OmitTotalClaimedAmount { get; set; }
        public bool OmitClaimDiscountAmount { get; set; }
        public bool OmitClaimDeductibleAmount { get; set; }
        public bool OmitMMAPSurchargeAmount { get; set; }
        public bool OmitCoPaymentAmount { get; set; }
        public bool OmitReceiptNumber { get; set; }
        public bool OmitPatientLiableAmount { get; set; }
        public bool OmitMedicalFundLiableAmount { get; set; }
        public bool OmitMemberReimbursementAmount { get; set; }

        public bool IsReceiptNumberBlank { get; set; }
        #endregion

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|{NetAmount}|");
            
            if (!OmitGrossAmount) sb.Append($"{GrossAmount}|");
            if (!OmitTotalClaimedAmount) sb.Append($"{TotalClaimedAmount}|");
            if (!OmitClaimDiscountAmount) sb.Append($"{ClaimDiscountAmount}|");
            if (!OmitClaimDeductibleAmount) sb.Append($"{ClaimDeductibleAmount}|");
            if (!OmitMMAPSurchargeAmount) sb.Append($"{MMAPSurchargeAmount}|");
            if (!OmitCoPaymentAmount) sb.Append($"{CoPaymentAmount}|");
            if (!OmitReceiptNumber)
            {
                sb.Append((IsReceiptNumberBlank) ? $"{string.Empty}|" : $"{ReceiptNumber}|");
            }

            if (!OmitPatientLiableAmount) sb.Append($"{PatientLiableAmount}|");
            if (!OmitMedicalFundLiableAmount) sb.Append($"{MedicalFundLiableAmount}|");
            if (!OmitMemberReimbursementAmount) sb.Append($"{MemberReimbursementAmount}|");

            return sb.ToString();
        }
    }
}
