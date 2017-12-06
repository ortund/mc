﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Era
{
    public class Disclaimer
    {
        private const string TYPE = "DS";
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{Text}|";
        }
    }
}
