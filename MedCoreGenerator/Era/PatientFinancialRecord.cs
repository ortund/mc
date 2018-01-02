using System.Text;

namespace MedCore.Era
{
    public class PatientFinancialRecord
    {
        private const string TYPE = "EZ";

        public decimal ClaimedAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal TotalPaidToMember { get; set; }
        public decimal PatientLiableAmount { get; set; }

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{ClaimedAmount}|");
            sb.Append($"{PaidAmount}|");
            sb.Append($"{TotalPaidToMember}|");
            sb.Append($"{PatientLiableAmount}|");

            return sb.ToString();
        }
    }
}
