using MedCore.Claim;
using System.Collections.Generic;
using System.Text;

namespace MedCore
{
    public class Dentist
    {
        public Header Header { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Member Member { get; set; }
        public Patient Patient { get; set; }
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

            foreach (var treatment in Treatments)
            {
                sb.AppendLine(treatment.ToString());
                sb.AppendLine(treatment.Doctor.ToString());

                foreach (var diagnosis in treatment.Diagnoses)
                {
                    sb.AppendLine(diagnosis.ToString());
                }

                if (treatment.Teeth.Count >= 1)
                {
                    foreach (var tooth in treatment.Teeth)
                    {
                        sb.AppendLine(tooth.ToString());
                    }
                }

                sb.AppendLine(treatment.FinancialRecord.ToString());
            }

            sb.AppendLine(ClaimFinancialRecord.ToString());
            sb.AppendLine(Footer.ToString());

            return sb.ToString();
        }
    }
}
