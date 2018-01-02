namespace MedCore.Era
{
    public class Member
    {
        private const string TYPE = "M";
        public string Surname { get; set; }
        public string FirstNames { get; set; }
        public string MembershipNumber { get; set; }

        public string GetCSV()
        {
            return $"{TYPE}|{Surname}|{FirstNames}|{MembershipNumber}|";
        }
    }
}
