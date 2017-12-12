using System.Text;

namespace MedCore.Claim
{
    public class TreatmentFinancialRecord : ICreatesCSV
    {
        private const string TYPE = "Z";
        public decimal NetAmount { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal DispensingFee { get; set; }
        public decimal ContainerFee { get; set; }
        public decimal ExcessTimeFee { get; set; }
        public decimal PrescriptionCalloutFee { get; set; }
        public decimal PrescriptionCopyFee { get; set; }
        public decimal PrescriptionDeliveryFee { get; set; }
        public decimal ContractFee { get; set; }
        public decimal PrescriptionClaimedAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal PatientLevyAmount { get; set; }
        public decimal MMAPSurchargeAmount { get; set; }
        public decimal CoPaymentAmount { get; set; }
        public decimal PatientLiableAmount { get; set; }
        public decimal MedicalFundLiableAmount { get; set; }
        public decimal MemberReimbursementAmount { get; set; }

        public bool OmitGrossAmount { get; set; }
        public bool OmitDispensingFee { get; set; }
        public bool OmitContainerFee { get; set; }
        public bool OmitExcessTimeFee { get; set; }
        public bool OmitPrescriptionCalloutFee { get; set; }
        public bool OmitPrescriptionCopyFee { get; set; }
        public bool OmitPrescriptionDeliveryFee { get; set; }
        public bool OmitContractFee { get; set; }
        public bool OmitPrescriptionClaimedAmount { get; set; }
        public bool OmitDiscountAmount { get; set; }
        public bool OmitPatientLevyAmount { get; set; }
        public bool OmitMMAPSurchargeAmount { get; set; }
        public bool OmitCoPaymentAmount { get; set; }
        public bool OmitPatientLiableAmount { get; set; }
        public bool OmitMedicalFundLiableAmount { get; set; }
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
