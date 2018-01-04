using MedCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class DispensedMedicine : EnumParser, ICreatesCSV
    {
        private const string _type = "C";

        /// <summary>
        /// The Treatment object for which this medicine was dispensed.
        /// </summary>
        public Treatment Treatment { get; set; }
        /// <summary>
        /// The ItemFinancialRecord object for this medicine. Represents the financial concerns of dispensing medicine.
        /// </summary>
        public ItemFinancialRecord FinancialRecord { get; set; }

        [Display(Name = "Mixture Indicator")]
        public bool MixtureIndicator { get; set; }
        [Display(Name = "Mixture Ingredient")]
        public string MixtureIngredient { get; set; }
        [Display(Name = "Medicine Cost")]
        public decimal MedicineCost { get; set; }
        public MedicineType Type { get; set; }
        [Display(Name = "NAPPI Code")]
        public string NappiCode { get; set; }
        [Display(Name = "EAN Code")]
        public string EanCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        /// <summary>
        /// Number of days of supply.
        /// </summary>
        [Display(Name = "Duration (in days)")]
        public int Length { get; set; }
        /// <summary>
        /// Basis on which the Length was calculated.
        /// </summary>
        [Display(Name = "Basis for Duration")]
        public string LengthBasis { get; set; }
        public int Repeats { get; set; }
        [Display(Name = "Authorized Repeats")]
        public int AuthorizedRepeats { get; set; }
        [Display(Name = "Original Prescription Number")]
        public string OriginalPrescriptionNumber { get; set; }
        public Daw Daw { get; set; }
        [Display(Name = "Benefit Type")]
        public BenefitType BenefitType { get; set; }
        [Display(Name = "Authorization Number")]
        public string AuthorizationNumber { get; set; }
        [Display(Name = "Price Basis")]
        public PriceBasis PriceBasis { get; set; }
        [Display(Name = "PMA Medicine Item Line Number")]
        public string PMAMedicineItemLineNumber { get; set; }
        [Display(Name = "Resubmission Reason")]
        public ResubmissionReason ResubmissionReason { get; set; }
        
        public string GetCSV()
        {
            var mixtureIndicator = (MixtureIndicator) ? "Y" : "N";
            var medicineType = (Type == MedicineType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)Type);
            var repeats = (Repeats == 0) ? string.Empty : Repeats.ToString();
            var authorizedRepeats = (AuthorizedRepeats == 0) ? string.Empty : AuthorizedRepeats.ToString();
            var daw = GetStringFromEnumValue((int)Daw);
            var benefitType = GetStringFromEnumValue((int)BenefitType);
            var priceBasis = GetStringFromEnumValue((int)PriceBasis);
            var resubmissionReason = (ResubmissionReason == ResubmissionReason.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)ResubmissionReason);

            return $"{_type}|{mixtureIndicator}|{MixtureIngredient}|{MedicineCost}|{medicineType}|{NappiCode}|{EanCode}|{Description}|{Quantity}|{Dosage}|{Length}|{LengthBasis}|{repeats}|{authorizedRepeats}|{OriginalPrescriptionNumber}|{daw}|{benefitType}|{AuthorizationNumber}|{priceBasis}|{PMAMedicineItemLineNumber}|{resubmissionReason}|";
        }
    }
}
