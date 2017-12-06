using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Era
{
    public class ServiceProvider
    {
        private const string TYPE = "S";
        public string PCNSNumber { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{PCNSNumber}|{Name}|";
        }
    }
}
