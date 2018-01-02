using MedCore.Era;
using System.Text;

namespace MedCore
{
    public class ERA : ClaimBase
    {
        public Header Header { get; set; }
        public ServiceProvider ServiceProvider { get; set; }

        public BankDeposit ERABankDeposit { get; set; }

        public Member Member { get; set; }
        public Patient Patient { get; set; }
        public ClaimItem ERAClaimItem { get; set; }
        public Response ERAResponse { get; set; }
        public ItemFinancialRecord ERAItemFinancialRecord { get; set; }
        public PatientFinancialRecord ERAPatientFinancialRecord
        { get; set; }
        public FinancialTotals ERAFinancialTotals { get; set; }

        public string GenerateClaim()
        {
            var sb = new StringBuilder();

            sb.AppendLine(Header.GetCSV());
            sb.AppendLine(ServiceProvider.GetCSV());
            sb.AppendLine(ERABankDeposit.GetCSV());
            sb.AppendLine(Member.GetCSV());
            sb.AppendLine(Patient.GetCSV());
            sb.AppendLine(ERAClaimItem.GetCSV());
            sb.AppendLine(ERAResponse.GetCSV());
            sb.AppendLine(ERAItemFinancialRecord.GetCSV());
            sb.AppendLine(ERAPatientFinancialRecord.GetCSV());
            sb.AppendLine(ERAFinancialTotals.GetCSV());

            return sb.ToString();
        }
    }
}
