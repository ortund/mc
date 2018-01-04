using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class Attachment : ICreatesCSV
    {
        private const string _type = "A";

        [Display(Name = "File Name")]
        public string FileName { get; set; }
        [Display(Name = "File Size")]
        public int FileSize { get; set; }

        /// <summary>
        /// Outputs the object values to a pipe character delimited text string.
        /// </summary>
        /// <returns></returns>
        public string GetCSV()
        {
            return $"{_type}|{FileName}|{FileSize}|";
        }
    }
}
