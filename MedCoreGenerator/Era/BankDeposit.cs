using System;
using System.Text;

namespace MedCore.Era
{
    public class BankDeposit
    {
        private const string TYPE = "EB";
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public string BankName { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public string ReferenceNumber { get; set; }
        public decimal Amount { get; set; }
        public string DepositReference { get; set; }

        public bool IsDepositReferenceBlank { get; set; }

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{AccountNumber}|");
            sb.Append($"{BranchCode}|");
            sb.Append($"{BankName}|");
            sb.Append($"{PaymentDate:yyyyMMdd}|");
            sb.Append($"{PaymentMethod}|");
            sb.Append($"{ReferenceNumber}|");
            sb.Append($"{Amount}|");

            if (!IsDepositReferenceBlank)
            {
                sb.Append($"{DepositReference}|");
            }
            return sb.ToString();
        }
    }
}
