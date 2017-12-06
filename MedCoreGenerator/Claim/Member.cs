using MedCore.Enums;

namespace MedCore.Claim
{
    public class Member : EnumParser, ICreatesCSV
    {
        private const string TYPE = "M";
        /// <summary>
        /// ID/Passport number of the principal member.
        /// </summary>
        public long IdNumber { get; set; }
        /// <summary>
        /// The title of the principal
        /// </summary>
        public MemberTitle Title { get; set; }
        /// <summary>
        /// Initial(s) of the principal member.
        /// </summary>
        public string Initials { get; set; }
        /// <summary>
        /// Surname of the prinicipal member.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Fill name(s) of the prinicipal member.
        /// </summary>
        public string FullNames { get; set; }
        /// <summary>
        /// Medical Fund membership number of the principal member.
        /// </summary>
        public long MembershipNumber { get; set; }
        /// <summary>
        /// Indicator to show if the member information was retrieved by swiping a membership card.
        /// </summary>
        public bool CardSwipeIndicator { get; set; }
        /// <summary>
        /// member's account number in the Service Provier's PMA
        /// </summary>
        public string PMANumber { get; set; }
        /// <summary>
        /// Postal Address Line 1
        /// </summary>
        public string Address1 { get; set; }
        /// <summary>
        /// Postal Address Line 2
        /// </summary>
        public string Address2 { get; set; }
        /// <summary>
        /// Town/City.
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Postal Code.
        /// </summary>
        public string PostalCode { get; set; }
        /// <summary>
        /// Telephone/Cellphone number of the principal member.
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The plan/option name of the medical scheme.
        /// </summary>
        public string Plan { get; set; }
        /// <summary>
        /// The plan/option number of the medical scheme.
        /// </summary>
        public string SchemeRefNo { get; set; }
        /// <summary>
        /// The name of the medical scheme.
        /// </summary>
        public string SchemeName { get; set; }
        /// <summary>
        /// Registration number of the Medical Scheme.
        /// </summary>
        public string SchemeRegistrationNumber { get; set; }
        /// <summary>
        /// The type of medical scheme registration.
        /// 
        /// 01 - CMS Registration Number
        /// 02 - Phisc Registration Number
        /// 03 - Other
        /// </summary>
        public SchemeTypes SchemeRegistrationType { get; set; }
        /// <summary>
        /// Medical Scheme claiming arrangements specific to this claim.
        /// ie. Contract / network / re-imbursement arrangement.
        /// </summary>
        public string SchemeClaimOption { get; set; }
        /// <summary>
        /// SwitchOn Destination Code for the Medical Scheme / Plan.
        /// </summary>
        public string SwitchOnDestinationCode { get; set; }
        
        public string GetCSV()
        {
            var title = (Title == MemberTitle.NotApplicable) ? string.Empty : Title.ToString().ToUpper();
            var cardSwipeIndicator = (CardSwipeIndicator) ? "Y" : "N";

            var schemeRegType = (SchemeRegistrationType == SchemeTypes.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)SchemeRegistrationType);

            return $"{TYPE}|{IdNumber}|{title}|{Initials}|{Surname}|{FullNames}|{MembershipNumber}|{cardSwipeIndicator}|{PMANumber}|{Address1}|{Address2}|{City}|{PostalCode}|{PhoneNumber}|{Plan}|{SchemeRefNo}|{SchemeName}|{SchemeRegistrationNumber}|{schemeRegType}|{SchemeClaimOption}|{SwitchOnDestinationCode}|";
        }
    }
}