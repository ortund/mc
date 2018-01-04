using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class ItemFinancialRecord : ICreatesCSV
    {
        private const string TYPE = "Y";
        [Display(Name = "Net Price")]
        public decimal NetPrice { get; set; }
        [Display(Name = "Gross Price")]
        public decimal GrossPrice { get; set; }
        [Display(Name = "Dispensing Fee")]
        public decimal DispensingFee { get; set; }
        [Display(Name = "Container Fee")]
        public decimal ContainerFee { get; set; }
        [Display(Name = "Excess Time Fee")]
        public decimal ExcessTimeFee { get; set; }
        [Display(Name = "Item Contract Fee")]
        public decimal ItemContractFee { get; set; }
        [Display(Name = "Claimed Amount")]
        public decimal ClaimedAmount { get; set; }
        [Display(Name = "Discount Amount")]
        public decimal DiscountAmount { get; set; }
        [Display(Name = "Patient Levy Amount")]
        public decimal PatientLevyAmount { get; set; }
        [Display(Name = "MMAP Surcharge Amount")]
        public decimal MMAPSurchargeAmount { get; set; }
        [Display(Name = "Co-payment Amount")]
        public decimal CoPaymentAmount { get; set; }
        [Display(Name = "Patient Liable Amount")]
        public decimal PatientLiableAmount { get; set; }
        [Display(Name = "Medical Fund Liable Amount")]
        public decimal MedicalFundLiableAmount { get; set; }
        [Display(Name = "Member Reimbursement Amount")]
        public decimal MemberReimbursementAmount { get; set; }

        public string GetCSV()
        {
            return $"{TYPE}|{NetPrice}|{GrossPrice}|{DispensingFee}|{ContainerFee}|{ExcessTimeFee}|{ItemContractFee}|{ClaimedAmount}|{DiscountAmount}|{PatientLevyAmount}|{MMAPSurchargeAmount}|{CoPaymentAmount}|{PatientLiableAmount}|{MedicalFundLiableAmount}|{MemberReimbursementAmount}|";
        }
    }
}
