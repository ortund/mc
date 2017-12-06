﻿namespace MedCore.Era
{
    public class ItemFinancialRecord
    {
        private const string TYPE = "EY";

        public decimal ClaimedAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal AmountPaidToMember { get; set; }
        public decimal PatientLiableAmount { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{ClaimedAmount}|{PaidAmount}|{AmountPaidToMember}|{PatientLiableAmount}|";
        }
    }
}
