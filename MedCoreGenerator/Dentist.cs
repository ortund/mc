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

            sb.AppendLine(Header.GetCSV());
            sb.AppendLine(ServiceProvider.GetCSV());
            sb.AppendLine(Member.GetCSV());
            sb.AppendLine(Patient.GetCSV());

            foreach (var treatment in Treatments)
            {
                sb.AppendLine(treatment.GetCSV());
                sb.AppendLine(treatment.Doctor.GetCSV());

                foreach (var diagnosis in treatment.Diagnoses)
                {
                    sb.AppendLine(diagnosis.GetCSV());
                }

                if (treatment.Teeth != null)
                {
                    if (treatment.Teeth.Count >= 1)
                    {
                        foreach (var tooth in treatment.Teeth)
                        {
                            sb.AppendLine(tooth.GetCSV());
                        }
                    }
                }                

                sb.AppendLine(treatment.FinancialRecord.GetCSV());
            }

            sb.AppendLine(ClaimFinancialRecord.GetCSV());
            sb.AppendLine(Footer.GetCSV());

            return sb.ToString();
        }
    }
}
