using MedCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Claim
{
    public abstract class EnumParser
    {
        /// <summary>
        /// Writes the specified enum value as a string which is padded with a leading 0
        /// if the specified value is less than 10.
        /// </summary>
        /// <param name="selectedEnumValue">The index of the selected enum value.</param>
        /// <returns></returns>
        public string GetStringFromEnumValue(int selectedEnumValue)
        {
            // Less than 10 outputs "04"
            // Greater than 10 outputs "12"
            return String.Format("{0:00}", selectedEnumValue + 1);
        }
    }
}
