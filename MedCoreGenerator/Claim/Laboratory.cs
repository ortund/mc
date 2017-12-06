using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Claim
{
    public class Laboratory
    {
        private const string TYPE = "L";
        public string ItemNumber { get; set; }
        public string LabItemTariffCode { get; set; }
        public string LabTariffDescription { get; set; }
        public int Quantity { get; set; }
        public string PmaLineItem { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{ItemNumber}|{LabItemTariffCode}|{LabTariffDescription}|{Quantity}|{PmaLineItem}|";
        }
    }
}
