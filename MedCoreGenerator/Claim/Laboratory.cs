using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class Laboratory : ICreatesCSV
    {
        private const string TYPE = "L";
        [Display(Name = "Item Number")]
        public string ItemNumber { get; set; }
        [Display(Name = "Lab Item Tariff Code")]
        public string LabItemTariffCode { get; set; }
        [Display(Name = "Lab Tariff Description")]
        public string LabTariffDescription { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "PMA Line Item")]
        public string PmaLineItem { get; set; }

        public string GetCSV()
        {
            return $"{TYPE}|{ItemNumber}|{LabItemTariffCode}|{LabTariffDescription}|{Quantity}|{PmaLineItem}|";
        }
    }
}
