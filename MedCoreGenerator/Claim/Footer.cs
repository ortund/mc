using System.Text;

namespace MedCore.Claim
{
    public class Footer : ICreatesCSV
    {
        private const string _type = "E";

        public string TransmissionNumber { get; set; }
        public int NumberOfClaims { get; set; }
        public decimal ValueOfClaims { get; set; }

        public bool OmitNumberOfClaims { get; set; }
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
