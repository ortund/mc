using MedCore.Claim;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedCore
{
    public class Gp2Claim : ClaimBase
    {
        public Header Header { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Member Member { get; set; }
        public Patient Patient { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<DispensedMedicine> DispensedMedicines { get; set; }
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
                foreach (var medicine in DispensedMedicines.Where(x => x.Treatment == treatment))
                { 
                    sb.AppendLine(medicine.ToString());
                    sb.AppendLine(medicine.FinancialRecord.ToString());
                }

                sb.AppendLine(treatment.FinancialRecord.ToString());
            }
            
            sb.AppendLine(ClaimFinancialRecord.ToString());
            sb.AppendLine(Footer.ToString());

            return sb.ToString();
        }
    }
}
