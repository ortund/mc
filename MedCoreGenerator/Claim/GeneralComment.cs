using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Claim
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
