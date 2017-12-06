namespace MedCore.Claim
{
    public class Footer : ICreatesCSV
    {
        private const string _type = "E";

        public string TransmissionNumber { get; set; }
        public int NumberOfClaims { get; set; }
        public decimal ValueOfClaims { get; set; }
        
        public string GetCSV()
        {
            return $"{_type}|{TransmissionNumber}|{NumberOfClaims}|{ValueOfClaims}|";
        }
    }
}
