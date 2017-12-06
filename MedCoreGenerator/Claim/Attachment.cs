namespace MedCore.Claim
{
    public class Attachment : ICreatesCSV
    {
        private const string _type = "A";

        public string FileName { get; set; }
        public int FileSize { get; set; }

        public string GetCSV()
        {
            return $"{_type}|{FileName}|{FileSize}|";
        }
    }
}
