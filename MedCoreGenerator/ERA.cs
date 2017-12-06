using MedCore.Era;
using System.Text;

namespace MedCore
{
    public class ERA : ClaimBase
    {
        public Claim.Header Header { get; set; }
        public Claim.ServiceProvider ServiceProvider { get; set; }

        public BankDeposit ERABankDeposit { get; set; }

        public Claim.Member Member { get; set; }
        public Claim.Patient Patient { get; set; }
        public ClaimItem ERAClaimItem { get; set; }
        public Response ERAResponse { get; set; }
        public Era.ItemFinancialRecord ERAItemFinancialRecord { get; set; }
        public PatientFinancialRecord ERAPatientFinancialRecord
        { get; set; }
        public FinancialTotals ERAFinancialTotals { get; set; }

        public string GenerateClaim()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Header.ToString());
            sb.AppendLine(ServiceProvider.ToString());
            sb.AppendLine(ERABankDeposit.ToString());
            sb.AppendLine(Member.ToString());
            sb.AppendLine(Patient.ToString());
            sb.AppendLine(ERAClaimItem.ToString());
            sb.AppendLine(ERAResponse.ToString());
            sb.AppendLine(ERAItemFinancialRecord.ToString());
            sb.AppendLine(ERAPatientFinancialRecord.ToString());
            sb.AppendLine(ERAFinancialTotals.ToString());

            return sb.ToString();
        }
    }
}
