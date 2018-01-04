using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedCore.Claim
{
    public class TreatmentFinancialRecord : ICreatesCSV
    {
        private const string TYPE = "Z";
        [Display(Name = "Net Amount")]
        public decimal NetAmount { get; set; }
        [Display(Name = "Gross Amount")]
        public decimal GrossAmount { get; set; }
        [Display(Name = "Dispensing Fee")]
        public decimal DispensingFee { get; set; }
        [Display(Name = "Container Fee")]
        public decimal ContainerFee { get; set; }
        [Display(Name = "Excess Time Fee")]
        public decimal ExcessTimeFee { get; set; }
        [Display(Name = "Prescription Callout Fee")]
        public decimal PrescriptionCalloutFee { get; set; }
        [Display(Name = "Prescription Copy Fee")]
        public decimal PrescriptionCopyFee { get; set; }
        [Display(Name = "Prescription Delivery Fee")]
        public decimal PrescriptionDeliveryFee { get; set; }
        [Display(Name = "Contract Fee")]
        public decimal ContractFee { get; set; }
        [Display(Name = "Prescription Claimed Amount")]
        public decimal PrescriptionClaimedAmount { get; set; }
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

        /// <summary>
        /// If true, the Gross Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Gross Amount")]
        public bool OmitGrossAmount { get; set; }
        /// <summary>
        /// If true, the Dispensing Fee field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Dispensing Fee")]
        public bool OmitDispensingFee { get; set; }
        /// <summary>
        /// If true, the Container Fee field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Container Fee")]
        public bool OmitContainerFee { get; set; }
        /// <summary>
        /// If true, the Excess Time Fee field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Excess Time Fee")]
        public bool OmitExcessTimeFee { get; set; }
        /// <summary>
        /// If true, the Prescription Callout Fee field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Prescription Callout Fee")]
        public bool OmitPrescriptionCalloutFee { get; set; }
        /// <summary>
        /// If true, the Prescription Copy Fee field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Prescription Copy Fee")]
        public bool OmitPrescriptionCopyFee { get; set; }
        /// <summary>
        /// If true, the Prescription Delivery Fee field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Prescription Delivery Fee")]
        public bool OmitPrescriptionDeliveryFee { get; set; }
        /// <summary>
        /// If true, the Contract Fee field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Contract Fee")]
        public bool OmitContractFee { get; set; }
        /// <summary>
        /// If true, the Prescription Claimed Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Prescription Claimed Amount")]
        public bool OmitPrescriptionClaimedAmount { get; set; }
        /// <summary>
        /// If true, the Discount Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Discount Amount")]
        public bool OmitDiscountAmount { get; set; }
        /// <summary>
        /// If true, the Patient Levy Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Patient Levy Amount")]
        public bool OmitPatientLevyAmount { get; set; }
        /// <summary>
        /// If true, the MMAP Surcharge Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit MMAP Surcharge Amount")]
        public bool OmitMMAPSurchargeAmount { get; set; }
        /// <summary>
        /// If true, the Co-payment Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Co-payment Amount")]
        public bool OmitCoPaymentAmount { get; set; }
        /// <summary>
        /// If true, the Patient Liable Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Patient Liable Amount")]
        public bool OmitPatientLiableAmount { get; set; }
        /// <summary>
        /// If true, the Medical Fund Liable Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Medical Fund Liable Amount")]
        public bool OmitMedicalFundLiableAmount { get; set; }
        /// <summary>
        /// If true, the Member Reimbursement Amount field will be completely omitted from the output of the GetCSV method. Default value is false.
        /// </summary>
        [Display(Name = "Omit Member Reimbursement Amount")]
        public bool OmitMemberReimbursementAmount { get; set; }

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|{NetAmount}|");

            if (!OmitGrossAmount) sb.Append($"{GrossAmount}|");
            if (!OmitDispensingFee) sb.Append($"{DispensingFee}|");
            if (!OmitContainerFee) sb.Append($"{ContainerFee}|");
            if (!OmitExcessTimeFee) sb.Append($"{ExcessTimeFee}|");
            if (!OmitPrescriptionCalloutFee) sb.Append($"{PrescriptionCalloutFee}|");
            if (!OmitPrescriptionCopyFee) sb.Append($"{PrescriptionCopyFee}|");
            if (!OmitPrescriptionDeliveryFee) sb.Append($"{PrescriptionDeliveryFee}|");
            if (!OmitContractFee) sb.Append($"{ContractFee}|");
            if (!OmitPrescriptionClaimedAmount) sb.Append($"{PrescriptionClaimedAmount}|");
            if (!OmitDiscountAmount) sb.Append($"{DiscountAmount}|");
            if (!OmitPatientLevyAmount) sb.Append($"{PatientLevyAmount}|");
            if (!OmitMMAPSurchargeAmount) sb.Append($"{MMAPSurchargeAmount}|");
            if (!OmitCoPaymentAmount) sb.Append($"{CoPaymentAmount}|");
            if (!OmitPatientLiableAmount) sb.Append($"{PatientLiableAmount}|");
            if (!OmitMedicalFundLiableAmount) sb.Append($"{MedicalFundLiableAmount}|");
            if (!OmitMemberReimbursementAmount) sb.Append($"{MemberReimbursementAmount}|");

            return sb.ToString();
        }
    }
}
