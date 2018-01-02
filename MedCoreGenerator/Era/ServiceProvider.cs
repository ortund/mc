namespace MedCore.Era
{
    public class ServiceProvider
    {
        private const string TYPE = "S";
        public string PCNSNumber { get; set; }
        public string Name { get; set; }

        public string GetCSV()
        {
            return $"{TYPE}|{PCNSNumber}|{Name}|";
        }
    }
}
