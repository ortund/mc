using MedCore.Claim;
using System.Text;

namespace MedCore
{
    public class MSV : ClaimBase
    {
        #region Properties
        public Header Header { get; set; }
        public ServiceProvider ServiceProvider { get; set; }
        public Member Member { get; set; }
        public Footer Footer { get; set; }
        #endregion

        public string GenerateClaim()
        {
            var sb = new StringBuilder();
            sb.AppendLine(Header.GetCSV());
            sb.AppendLine(ServiceProvider.GetCSV());
            sb.AppendLine(Member.GetCSV());
            sb.AppendLine(Footer.GetCSV());

            return sb.ToString();
        }
    }
}
