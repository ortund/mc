namespace MedCore.Era
{
    public class PatientFinancialRecord
    {
        private const string TYPE = "EZ";

        public decimal ClaimedAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal TotalPaidToMember { get; set; }
        public decimal PatientLiableAmount { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{ClaimedAmount}|{PaidAmount}|{TotalPaidToMember}|{PatientLiableAmount}|";
        }
    }
}
