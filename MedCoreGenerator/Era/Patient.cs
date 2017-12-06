using System;

namespace MedCore.Era
{
    public class Patient
    {
        private const string TYPE = "P";
        public string DependantCode { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string FullNames { get; set; }
        public DateTime DOB { get; set; }
        public int IdNumber { get; set; }
        public string PmaAccountNumber { get; set; }

        public override string ToString()
        {
            var dob = DOB.ToString("yyyyMMdd");
            return $"{TYPE}|{DependantCode}|{Surname}|{Initials}|{FullNames}|{dob}|{IdNumber}|{PmaAccountNumber}|";
        }
    }
}
