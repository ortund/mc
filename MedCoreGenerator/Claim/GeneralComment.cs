namespace MedCore.Claim
{
    public class GeneralComment: ICreatesCSV
    {
        private const string _type = "G";

        public string Comments { get; set; }

        public string GetCSV()
        {
            return $"{_type}|{Comments}|";
        }
    }
}
