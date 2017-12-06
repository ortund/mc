using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Era
{
    public class ItemAllocation
    {
        private const string TYPE = "EA";

        public decimal PaidAmount { get; set; }
        public string Reference { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{PaidAmount}|{Reference}|";
        }
    }
}
