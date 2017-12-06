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
        
        public string GetCSV()
        {
            return $"{TYPE}|{NetAmount}|{GrossAmount}|{TotalClaimedAmount}|{ClaimDiscountAmount}|{ClaimDeductibleAmount}|{MMAPSurchargeAmount}|{CoPaymentAmount}|{ReceiptNumber}|{PatientLiableAmount}|{MedicalFundLiableAmount}|{MemberReimbursementAmount}|";
        }
    }
}
