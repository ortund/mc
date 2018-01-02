using MedCore.Enums;
using System.Text;

namespace MedCore.Claim
{
    public class Member : EnumParser, ICreatesCSV
    {
        private const string TYPE = "M";
        /// <summary>
        /// ID/Passport number of the principal 
        /// </summary>
        public long? IdNumber { get; set; }
        /// <summary>
        /// The title of the principal
        /// </summary>
        public MemberTitle Title { get; set; }
        /// <summary>
        /// Initial(s) of the principal 
        /// </summary>
        public string Initials { get; set; }
        /// <summary>
        /// Surname of the prinicipal 
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Fill name(s) of the prinicipal 
        /// </summary>
        public string FullNames { get; set; }
        /// <summary>
        /// Medical Fund membership number of the principal 
        /// </summary>
        public long? MembershipNumber { get; set; }
        /// <summary>
        /// Indicator to show if the member information was retrieved by swiping a membership card.
        /// </summary>
        public bool CardSwipeIndicator { get; set; }
        /// <summary>
        /// Member's account number in the Service Provier's PMA
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
        /// Telephone/Cellphone number of the principal 
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

        public bool OmitCardSwipeIndicator { get; set; }
        public bool OmitAddress2 { get; set; }
        public bool OmitCity { get; set; }
        public bool OmitPostalCode { get; set; }
        public bool OmitPhoneNumber { get; set; }
        public bool OmitPlan { get; set; }
        public bool OmitSchemeRefNo { get; set; }
        public bool OmitSchemeName { get; set; }
        public bool OmitSchemeRegistrationNumber { get; set; }
        public bool OmitSchemeRegistrationType { get; set; }
        public bool OmitSchemeClaimOption { get; set; }

        public bool IsAddress2Blank { get; set; }
        public bool IsCityBlank { get; set; }
        public bool IsPostalCodeBlank { get; set; }
        public bool IsPhoneNumberBlank { get; set; }
        public bool IsPlanBlank { get; set; }
        public bool IsSchemeRefNoBlank { get; set; }
        public bool IsSchemeNameBlank { get; set; }
        public bool IsSchemeRegistrationNumberBlank { get; set; }
        public bool IsSchemeRegistrationTypeBlank { get; set; }
        public bool IsSchemeClaimOptionBlank { get; set; }

        private string _title;
        private string _membershipNumber;
        private string _cardSwipeIndicator;
        private string _schemeRegType;

        private void DoRefactoring()
        {
            _title = (Title == MemberTitle.NotApplicable) ? string.Empty : Title.ToString().ToUpper();
            _membershipNumber = (MembershipNumber != null) ? MembershipNumber.ToString() : string.Empty;
            _cardSwipeIndicator = (OmitCardSwipeIndicator) ? string.Empty : (CardSwipeIndicator) ? "Y" : "N";
            _schemeRegType = (SchemeRegistrationType == SchemeTypes.NotApplicable) ? string.Empty : GetStringFromEnumValue((int)SchemeRegistrationType);
        }

        public string GetCSV()
        {
            DoRefactoring();

            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{IdNumber}|");
            sb.Append($"{_title}|");
            sb.Append($"{Initials}|");
            sb.Append($"{Surname}|");
            sb.Append($"{FullNames}|");
            sb.Append($"{_membershipNumber}|");
            sb.Append($"{_cardSwipeIndicator}|");
            sb.Append($"{PMANumber}|");
            sb.Append($"{Address1}|");
            
            if (!OmitAddress2) sb.Append((IsAddress2Blank) ? $"{string.Empty}|" : $"{Address2}|");
            if (!OmitCity) sb.Append((IsCityBlank) ? $"{string.Empty}|" : $"{City}|");
            if (!OmitPostalCode) sb.Append((IsPostalCodeBlank) ? $"{string.Empty}|" : $"{PostalCode}|");
            if (!OmitPhoneNumber) sb.Append((IsPhoneNumberBlank) ? $"{string.Empty}|" : $"{PhoneNumber}|");
            if (!OmitPlan) sb.Append((IsPlanBlank) ? $"{string.Empty}|" : $"{Plan}|");
            if (!OmitSchemeRefNo) sb.Append((IsSchemeRefNoBlank) ? $"{string.Empty}|" : $"{SchemeRefNo}|");
            if (!OmitSchemeName) sb.Append((IsSchemeNameBlank) ? $"{string.Empty}|" : $"{SchemeName}|");
            if (!OmitSchemeRegistrationNumber) sb.Append((IsSchemeRegistrationNumberBlank) ? $"{string.Empty}|" : $"{SchemeRegistrationNumber}|");
            if (!OmitSchemeRegistrationType) sb.Append((IsSchemeRegistrationTypeBlank) ? $"{string.Empty}|" : $"{_schemeRegType}|");
            if (!OmitSchemeClaimOption) sb.Append((IsSchemeClaimOptionBlank) ? $"{string.Empty}|" : $"{SchemeClaimOption}|");
            
            sb.Append($"{SwitchOnDestinationCode}|");

            return sb.ToString();
        }
    }
}