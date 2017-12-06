using MedCore.Claim;
using System.Text;

namespace MedCore
{
    public class BenefitCheck1 : ClaimBase
    {
        public Header Header { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Member Member { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Treatment Treatment { get; set; }
        public DoctorDiagnosis Diagnosis { get; set; }
        public ClaimFinancialRecord ClaimFinancialRecord { get; set; }
        public Footer Footer { get; set; }

        public string GenerateClaim()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Header.ToString());
            sb.AppendLine(ServiceProvider.ToString());
            sb.AppendLine(Member.ToString());
            sb.AppendLine(Patient.ToString());
            sb.AppendLine(Diagnosis.ToString());
            sb.AppendLine(Treatment.ToString());
            sb.AppendLine(Doctor.ToString());
            sb.AppendLine(Treatment.FinancialRecord.ToString());
            sb.AppendLine(ClaimFinancialRecord.ToString());
            sb.AppendLine(Footer.ToString());

            return sb.ToString();
        }
    }
}
