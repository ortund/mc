using System;
using System.Text;

namespace MedCore.Era
{
    public class Header
    {
        private const string TYPE = "H";
        public string SchemeName { get; set; }
        public string SchemeAdminName { get; set; }
        public string SchemeRegistrationNumber { get; set; }
        public string SwitchDestinationCode { get; set; }
        public string SchemeContactDetails { get; set; }
        public string SchemeTelephoneNumber { get; set; }
        public string SchemeFaxNumber { get; set; }
        public string SchemeEmailAddress { get; set; }
        public string RaReferenceNumber { get; set; }
        public DateTime RaIssueDate { get; set; }
        public decimal RaOpeningBalance { get; set; }
        public decimal RaClosingBalance { get; set; }

        public bool OpeningBalanceOmitted { get; set; }
        public bool ClosingBalanceOmitted { get; set; }

        private string _openingBalance;
        private string _closingBalance;
        public string GetCSV()
        {
            DoRefactoring();

            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{SchemeName}|");
            sb.Append($"{SchemeAdminName}|");
            sb.Append($"{SchemeRegistrationNumber}|");
            sb.Append($"{SwitchDestinationCode}|");
            sb.Append($"{SchemeContactDetails}|");
            sb.Append($"{SchemeTelephoneNumber}|");
            sb.Append($"{SchemeFaxNumber}|");
            sb.Append($"{SchemeEmailAddress}|");
            sb.Append($"{RaReferenceNumber}|");
            sb.Append($"{RaIssueDate:yyyyMMdd}|");
            sb.Append($"{_openingBalance}|");
            sb.Append($"{_closingBalance}|");

            return sb.ToString();
        }

        private void DoRefactoring()
        {
            _openingBalance = (OpeningBalanceOmitted) ? string.Empty : RaOpeningBalance.ToString();
            _closingBalance = (ClosingBalanceOmitted) ? string.Empty : RaClosingBalance.ToString();
        }
    }
}
