using MedCore.Enums;

namespace MedCore.Claim
{
    public class Doctor : EnumParser, ICreatesCSV
    {
        public const string TYPE = "DR";

        public string PCNSNumber { get; set; }
        public string Name { get; set; }
        public DoctorType DoctorType { get; set; }
        public string CMSRegistrationNumber { get; set; }
        public SchemeTypes CMSType { get; set; }
        public string LicenseNumber { get; set; }
        public bool DesignatedProvider { get; set; }
        public string TrackingNumber { get; set; }
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
