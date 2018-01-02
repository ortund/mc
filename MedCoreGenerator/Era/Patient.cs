using System;
using System.Text;

namespace MedCore.Era
{
    public class Patient
    {
        private const string TYPE = "P";
        public string DependantCode { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string FullNames { get; set; }
        public DateTime DOB { get; set; }
        public int IdNumber { get; set; }
        public string PmaAccountNumber { get; set; }

        public bool OmitIdNumber { get; set; }

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{DependantCode}|");
            sb.Append($"{Surname}|");
            sb.Append($"{Initials}|");
            sb.Append($"{FullNames}|");
            sb.Append($"{DOB:yyyyMMdd}|");
            sb.Append((OmitIdNumber) ? $"{string.Empty}|" : $"{IdNumber}");
            sb.Append($"{PmaAccountNumber}|");

            return sb.ToString();
        }
    }
}
