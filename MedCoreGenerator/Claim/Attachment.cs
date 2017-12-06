using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Claim
{
    public class Attachment
    {
        private const string TYPE = "A";
        public string FileName { get; set; }
        public int FileSize { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{FileName}|{FileSize}|";
        }
    }
}
