using MedCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class Procedure : EnumParser, ICreatesCSV
    {
        private string TYPE = "PR";
        public string Code { get; set; }
        [Display(Name = "Code Type")]
        public ProcedureCodeType CodeType { get; set; }
        public string Description { get; set; }

        public string GetCSV()
        {
            var procedureCodeType = GetStringFromEnumValue((int)CodeType);
            return $"{TYPE}|{Code}|{procedureCodeType}|{Description}|";
        }
    }
}
