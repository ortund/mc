namespace MedCore.Claim
{
    public class ItemFinancialRecord : ICreatesCSV
    {
        private const string TYPE = "Y";
        public decimal NetPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal DispensingFee { get; set; }
        public decimal ContainerFee { get; set; }
        public decimal ExcessTimeFee { get; set; }
        public decimal ItemContractFee { get; set; }
        public decimal ClaimedAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PatientLevyAmount { get; set; }
        public decimal MMAPSurchargeAmount { get; set; }
        public decimal CoPaymentAmount { get; set; }
        public decimal PatientLiableAmount { get; set; }
        public decimal MedicalFundLiableAmount { get; set; }
        public decimal MemberReimbursementAmount { get; set; }

        public string GetCSV()
        {
            return $"{TYPE}|{NetPrice}|{GrossPrice}|{DispensingFee}|{ContainerFee}|{ExcessTimeFee}|{ItemContractFee}|{ClaimedAmount}|{DiscountAmount}|{PatientLevyAmount}|{MMAPSurchargeAmount}|{CoPaymentAmount}|{PatientLiableAmount}|{MedicalFundLiableAmount}|{MemberReimbursementAmount}|";
        }
    }
}
