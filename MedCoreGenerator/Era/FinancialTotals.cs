using System.Text;

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

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{TotalClaimedAmount}|");
            sb.Append($"{TotalPaidAmount}|");
            sb.Append($"{TotalJournalAmount}|");
            sb.Append($"{TotalPaidToMember}|");
            sb.Append($"{TotalPatientLiableAmount}|");

            return sb.ToString();
        }
    }
}
