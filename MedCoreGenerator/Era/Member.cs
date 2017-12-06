using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Era
{
    public class Member
    {
        private const string TYPE = "M";
        public string Surname { get; set; }
        public string FirstNames { get; set; }
        public string MembershipNumber { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{Surname}|{FirstNames}|{MembershipNumber}|";
        }
    }
}
