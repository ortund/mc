using MedCore.Claim;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedCore
{
    public class Gp2Claim : ClaimBase, ICreatesCSV
    {
        public Header Header { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Member Member { get; set; }
        public Patient Patient { get; set; }
        public List<Treatment> Treatments { get; set; }
        public List<DispensedMedicine> DispensedMedicines { get; set; }
        public ClaimFinancialRecord ClaimFinancialRecord { get; set; }
        public Footer Footer { get; set; }

        public string GetCSV()
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
                foreach (var medicine in DispensedMedicines.Where(x => x.Treatment == treatment))
                {
                    sb.AppendLine(medicine.GetCSV());
                    sb.AppendLine(medicine.FinancialRecord.GetCSV());
                }

                sb.AppendLine(treatment.FinancialRecord.GetCSV());
            }
            
            sb.AppendLine(ClaimFinancialRecord.GetCSV());
            sb.AppendLine(Footer.GetCSV());

            return sb.ToString();
        }
    }
}
