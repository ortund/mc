using System;

namespace MedCore.Era
{
    public class Journal
    {
        private const string TYPE = "EJ";

        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            var date = Date.ToString("yyyyMMdd");
            return $"{TYPE}|{Amount}|{Description}|{date}|";
        }
    }
}
