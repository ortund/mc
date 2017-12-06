namespace MedCore.Claim
{
    public class Laboratory : ICreatesCSV
    {
        private const string TYPE = "L";
        public string ItemNumber { get; set; }
        public string LabItemTariffCode { get; set; }
        public string LabTariffDescription { get; set; }
        public int Quantity { get; set; }
        public string PmaLineItem { get; set; }

        public string GetCSV()
        {
            return $"{TYPE}|{ItemNumber}|{LabItemTariffCode}|{LabTariffDescription}|{Quantity}|{PmaLineItem}|";
        }
    }
}
