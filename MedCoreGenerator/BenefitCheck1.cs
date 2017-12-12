using MedCore.Claim;
using System.Collections.Generic;
using System.Text;

namespace MedCore
{
    public class BenefitCheck1 : ClaimBase
    {
        public Header Header { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Member Member { get; set; }
        public List<Patient> Patients { get; set; }
        public Doctor Doctor { get; set; }
        public Treatment Treatment { get; set; }
        public DoctorDiagnosis Diagnosis { get; set; }
        public ClaimFinancialRecord ClaimFinancialRecord { get; set; }
        public Footer Footer { get; set; }

        public string GenerateClaim()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Header.GetCSV());
            sb.AppendLine(ServiceProvider.GetCSV());
            sb.AppendLine(Member.GetCSV());

            foreach (var patient in Patients)
            {
                sb.AppendLine(patient.GetCSV());
            }

            sb.AppendLine(Diagnosis.GetCSV());
            sb.AppendLine(Treatment.GetCSV());
            sb.AppendLine(Doctor.GetCSV());
            sb.AppendLine(Treatment.FinancialRecord.GetCSV());
            sb.AppendLine(ClaimFinancialRecord.GetCSV());
            sb.AppendLine(Footer.GetCSV());

            return sb.ToString();
        }
    }
}
