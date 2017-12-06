namespace MedCore.Era
{
    public class FinancialTotals
    {
        private const string TYPE = "EF";

        public decimal TotalClaimedAmount { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal TotalJournalAmount { get; set; }
        public decimal TotalPaidToMember { get; set; }
        public decimal TotalPatientLiableAmount { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{TotalClaimedAmount}|{TotalPaidAmount}|{TotalJournalAmount}|{TotalPaidToMember}|{TotalPatientLiableAmount}|";
        }
    }
}
