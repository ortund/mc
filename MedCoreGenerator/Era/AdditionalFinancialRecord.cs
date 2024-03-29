﻿namespace MedCore.Era
{
    public class AdditionalFinancialRecord
    {
        private const string TYPE = "AF";

        public string ColumnName { get; set; }
        public string ColumnSequence { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{ColumnName}|{ColumnSequence}|{Amount}|";
        }
    }
}
