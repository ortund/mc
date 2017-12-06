using MedCore.Claim;
using System.Collections.Generic;
using System.Text;

namespace MedCore
{
    public class Anaesthetist : ClaimBase
    {
        public Header Header { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Member Member { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public List<Treatment> Treatments { get; set; }
        public ClaimFinancialRecord ClaimFinancialRecord { get; set; }
        public Footer Footer { get; set; }

        public string GenerateClaim()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Header.ToString());
            sb.AppendLine(ServiceProvider.ToString());
            sb.AppendLine(Member.ToString());
            sb.AppendLine(Patient.ToString());
            sb.AppendLine(Doctor.ToString());

            foreach (var treatment in Treatments)
            {
                sb.AppendLine(treatment.ToString());
                sb.AppendLine(treatment.Doctor.ToString());

                foreach (var diagnosis in treatment.Diagnoses)
                {
                    sb.AppendLine(diagnosis.ToString());
                }

                sb.AppendLine(treatment.FinancialRecord.ToString());
            }

            sb.AppendLine(ClaimFinancialRecord.ToString());
            sb.AppendLine(Footer.ToString());

            return sb.ToString();
        }
    }
}
