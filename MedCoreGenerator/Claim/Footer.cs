namespace MedCore.Claim
{
    public class Footer
    {
        private const string TYPE = "E";
        public string TransmissionNumber { get; set; }
        public int NumberOfClaims { get; set; }
        public decimal ValueOfClaims { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{TransmissionNumber}|{NumberOfClaims}|{ValueOfClaims}|";
        }
    }
}
