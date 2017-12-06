using System;

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
        public decimal RaClosingBalance { get; set; }

        public override string ToString()
        {
            var raIssueDate = RaIssueDate.ToString("yyyyMMddHHmm");

            return $"{TYPE}|{SchemeName}|{SchemeAdminName}|{SchemeRegistrationNumber}|{SwitchDestinationCode}|{SchemeContactDetails}|{SchemeTelephoneNumber}|{SchemeFaxNumber}|{SchemeEmailAddress}|{RaReferenceNumber}|{raIssueDate}|{RaClosingBalance}|";
        }
    }
}
