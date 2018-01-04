using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedCore.Claim
{
    public class ClaimFinancialRecord : ICreatesCSV
    {
        private const string TYPE = "F";
        [Display(Name = "Net Amount")]
        public decimal NetAmount { get; set; }
        [Display(Name = "Gross Amount")]
        public decimal GrossAmount { get; set; }
        [Display(Name = "Total Claimed Amount")]
        public decimal TotalClaimedAmount { get; set; }
        [Display(Name = "Claim Discount Amount")]
        public decimal ClaimDiscountAmount { get; set; }
        [Display(Name = "Claim Deductible Amount")]
        public decimal ClaimDeductibleAmount { get; set; }
        [Display(Name = "MMAP Surcharge Amount")]
        public decimal MMAPSurchargeAmount { get; set; }
        [Display(Name = "Co-payment Amount")]
        public decimal CoPaymentAmount { get; set; }
        [Display(Name = "Receipt Number")]
        public string ReceiptNumber { get; set; }
        [Display(Name = "Patient Liable Amount")]
        public decimal PatientLiableAmount { get; set; }
        [Display(Name = "Medical Fund Liable Amount")]
        public decimal MedicalFundLiableAmount { get; set; }
        [Display(Name = "Member Reimbursement Amount")]
        public decimal MemberReimbursementAmount { get; set; }

        #region bools
        /// <summary>
        /// If true, the Gross Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Gross Amount")]
        public bool OmitGrossAmount { get; set; }

        /// <summary>
        /// If true, the Total Claimed Amount field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Total Claimed Amount")]
        public bool OmitTotalClaimedAmount { get; set; }

        /// <summary>
        /// If true, the Total Claim Discount field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Claim Discount Amount")]
        public bool OmitClaimDiscountAmount { get; set; }

        /// <summary>
        /// If true, the Claim Deductible Amount field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Claim Deductible Amount")]
        public bool OmitClaimDeductibleAmount { get; set; }

        /// <summary>
        /// If true, the MAP Surcharge Amount field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit MMAP Surcharge Amount")]
        public bool OmitMMAPSurchargeAmount { get; set; }

        /// <summary>
        /// If true, the Co-payment Amount field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Co-payment Amount")]
        public bool OmitCoPaymentAmount { get; set; }

        /// <summary>
        /// If true, the Receipt Number field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Receipt Number")]
        public bool OmitReceiptNumber { get; set; }

        /// <summary>
        /// If true, the Patient Liable Amount field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Patient Liable Amount")]
        public bool OmitPatientLiableAmount { get; set; }

        /// <summary>
        /// If true, the Medical Fund Liable Amount field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Medical Fund Liable Amount")]
        public bool OmitMedicalFundLiableAmount { get; set; }

        /// <summary>
        /// If true, the Member Reimbursement Amount field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Member Reimbursement Amount")]
        public bool OmitMemberReimbursementAmount { get; set; }

        /// <summary>
        /// If true, the Receipt Number will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Receipt Number Blank")]
        public bool IsReceiptNumberBlank { get; set; }
        #endregion
        
        /// <summary>
        /// Outputs the object values to a pipe character delimited text string.
        /// </summary>
        /// <returns></returns>
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
