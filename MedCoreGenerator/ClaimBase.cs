using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MedCore
{
    public abstract class ClaimBase
    {
        public async Task SaveClaimToFileAsync(string path, string claim)
        {
            using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                var bytes = Encoding.UTF8.GetBytes(claim);
                await fs.WriteAsync(bytes, 0, bytes.Length);
            }
        }

        public void SaveClaimToFile(string path, string claim)
        {
            using (var fs = new FileStream(path, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                var bytes = Encoding.UTF8.GetBytes(claim);
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}
