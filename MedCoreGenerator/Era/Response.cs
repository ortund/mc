namespace MedCore.Era
{
    public class Response
    {
        private const string TYPE = "R";
        public string Code { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{Code}|{Description}|";
        }
    }
}
