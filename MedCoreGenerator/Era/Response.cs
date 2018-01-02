using System.Text;

namespace MedCore.Era
{
    public class Response
    {
        private const string TYPE = "R";
        public string Code { get; set; }
        public string Description { get; set; }

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{Code}|");
            sb.Append($"{Description}|");

            return sb.ToString();
        }
    }
}
