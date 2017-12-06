namespace MedCore.Era
{
    public class GeneralComment
    {
        private const string TYPE = "G";

        public string Comments { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{Comments}|";
        }
    }
}
