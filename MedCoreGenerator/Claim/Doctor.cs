using MedCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class Doctor : EnumParser, ICreatesCSV
    {
        public const string TYPE = "DR";
        [Display(Name = "PCNS Number")]
        public string PCNSNumber { get; set; }
        public string Name { get; set; }
        [Display(Name = "Type")]
        public DoctorType DoctorType { get; set; }
        [Display(Name = "CMS Registration Number")]
        public string CMSRegistrationNumber { get; set; }
        [Display(Name = "CMS Type")]
        public SchemeTypes CMSType { get; set; }
        [Display(Name = "License Number")]
        public string LicenseNumber { get; set; }
        [Display(Name = "Designated Provider")]
        public bool DesignatedProvider { get; set; }
        [Display(Name = "Tracking Number")]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// If true, the Designated Provider field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Designated Provider Omitted")]
        public bool DesignatedProviderOmitted { get; set; }
        
        public string GetCSV()
        {
            var doctorType = GetStringFromEnumValue((int)DoctorType);
            var cmsType = (CMSType == SchemeTypes.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)CMSType);
            var designatedProvider = (DesignatedProvider) ? "Y" : "N";
            if (DesignatedProviderOmitted)
            {
                designatedProvider = string.Empty;
            }

            return $"{TYPE}|{PCNSNumber}|{Name}|{doctorType}|{CMSRegistrationNumber}|{cmsType}|{LicenseNumber}|{designatedProvider}|{TrackingNumber}|";
        }
    }
}
