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
            sb.AppendLine(Header.ToString());
            sb.AppendLine(ServiceProvider.ToString());
            sb.AppendLine(Member.ToString());
            sb.AppendLine(Footer.ToString());

            return sb.ToString();
        }
    }
}
