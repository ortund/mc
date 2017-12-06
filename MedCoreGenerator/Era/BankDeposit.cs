using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            var paymentDate = PaymentDate.ToString("yyyyMMddHHmm");
            return $"{TYPE}|{AccountNumber}|{BranchCode}|{BankName}|{paymentDate}|{PaymentMethod}|{Amount}|{DepositReference}|";
        }
    }
}
