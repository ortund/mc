using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedCore.Claim
{
    public class Footer : ICreatesCSV
    {
        private const string _type = "E";

        [Display(Name = "Transmission Number")]
        public string TransmissionNumber { get; set; }
        [Display(Name = "Number of Claims")]
        public int NumberOfClaims { get; set; }
        [Display(Name = "Value of Claims")]
        public decimal ValueOfClaims { get; set; }

        [Display(Name = "Omit Number of Claims")]
        public bool OmitNumberOfClaims { get; set; }
        [Display(Name = "Omit Value of Claims")]
        public bool OmitValueOfClaims { get; set; }
        
        public string GetCSV()
        {
            var sb = new StringBuilder();
            sb.Append($"{_type}|{TransmissionNumber}|");

            if (!OmitNumberOfClaims) sb.Append($"{NumberOfClaims}|");
            if (!OmitValueOfClaims) sb.Append($"{ValueOfClaims}|");

            return sb.ToString();
        }
    }
}
