using MedCore.Enums;

namespace MedCore.Claim
{
    public class DispensedMedicine : EnumParser
    {
        public Treatment Treatment { get; set; }
        public ItemFinancialRecord FinancialRecord { get; set; }

        private const string TYPE = "C";
        public bool MixtureIndicator { get; set; }
        public string MixtureIngredient { get; set; }
        public decimal MedicineCost { get; set; }
        public MedicineType Type { get; set; }
        public string NappiCode { get; set; }
        public string EanCode { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public int Length { get; set; }
        public string LengthBasis { get; set; }
        public int Repeats { get; set; }
        public int AuthorizedRepeats { get; set; }
        public string OriginalPrescriptionNumber { get; set; }
        public Daw Daw { get; set; }
        public BenefitType BenefitType { get; set; }
        public string AuthorizationNumber { get; set; }
        public PriceBasis PriceBasis { get; set; }
        public string PMAMedicineItemLineNumber { get; set; }
        public ResubmissionReason ResubmissionReason { get; set; }

        public override string ToString()
        {
            var mixtureIndicator = (MixtureIndicator) ? "Y" : "N";
            var medicineType = (Type == MedicineType.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)Type);
            var repeats = (Repeats == 0) ? string.Empty : Repeats.ToString();
            var authorizedRepeats = (AuthorizedRepeats == 0) ? string.Empty : AuthorizedRepeats.ToString();
            var daw = GetStringFromEnumValue((int)Daw);
            var benefitType = GetStringFromEnumValue((int)BenefitType);
            var priceBasis = GetStringFromEnumValue((int)PriceBasis);
            var resubmissionReason = (ResubmissionReason == ResubmissionReason.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)ResubmissionReason);

            return $"{TYPE}|{mixtureIndicator}|{MixtureIngredient}|{MedicineCost}|{medicineType}|{NappiCode}|{EanCode}|{Description}|{Quantity}|{Dosage}|{Length}|{LengthBasis}|{repeats}|{authorizedRepeats}|{OriginalPrescriptionNumber}|{daw}|{benefitType}|{AuthorizationNumber}|{priceBasis}|{PMAMedicineItemLineNumber}|{resubmissionReason}|";
        }
    }
}
