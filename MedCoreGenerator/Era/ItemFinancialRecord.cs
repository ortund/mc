using System.Text;

namespace MedCore.Era
{
    public class ItemFinancialRecord
    {
        private const string TYPE = "EY";

        public decimal ClaimedAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal AmountPaidToMember { get; set; }
        public decimal PatientLiableAmount { get; set; }

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{ClaimedAmount}|");
            sb.Append($"{PaidAmount}|");
            sb.Append($"{AmountPaidToMember}|");
            sb.Append($"{PatientLiableAmount}|");

            return sb.ToString();
        }
    }
}
