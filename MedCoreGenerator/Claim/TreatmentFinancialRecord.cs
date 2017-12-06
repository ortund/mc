using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Claim
{
    public class TreatmentFinancialRecord
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

        public override string ToString()
        {
            return $"{TYPE}|{NetAmount}|{GrossAmount}|{DispensingFee}|{ContainerFee}|{ExcessTimeFee}|{PrescriptionCalloutFee}|{PrescriptionCopyFee}|{PrescriptionDeliveryFee}|{ContractFee}|{PrescriptionClaimedAmount}|{DiscountAmount}|{PatientLevyAmount}|{MMAPSurchargeAmount}|{CoPaymentAmount}|{PatientLiableAmount}|{MedicalFundLiableAmount}|{MemberReimbursementAmount}|";
        }
    }
}
