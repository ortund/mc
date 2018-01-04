using MedCore.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedCore.Claim
{
    public class Member : EnumParser, ICreatesCSV
    {
        private const string TYPE = "M";
        /// <summary>
        /// ID/Passport number of the principal 
        /// </summary>
        /// 
        [Display(Name = "ID Number")]
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
        /// 
        [Display(Name = "Full Names")]
        public string FullNames { get; set; }
        /// <summary>
        /// Medical Fund membership number of the principal 
        /// </summary>
        /// 
        [Display(Name = "Membership Number")]
        public long? MembershipNumber { get; set; }
        /// <summary>
        /// Indicator to show if the member information was retrieved by swiping a membership card.
        /// </summary>
        /// 
        [Display(Name = "Card Swipe Indicator")]
        public bool CardSwipeIndicator { get; set; }
        /// <summary>
        /// Member's account number in the Service Provier's PMA
        /// </summary>
        /// 
        [Display(Name = "PMA Number")]
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
        /// 
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        /// <summary>
        /// Telephone/Cellphone number of the principal 
        /// </summary>
        /// 
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// The plan/option name of the medical scheme.
        /// </summary>
        public string Plan { get; set; }
        /// <summary>
        /// The plan/option number of the medical scheme.
        /// </summary>
        /// 
        [Display(Name = "Scheme Reference Number")]
        public string SchemeRefNo { get; set; }
        /// <summary>
        /// The name of the medical scheme.
        /// </summary>
        /// 
        [Display(Name = "Scheme Name")]
        public string SchemeName { get; set; }
        /// <summary>
        /// Registration number of the Medical Scheme.
        /// </summary>
        /// 
        [Display(Name = "Scheme Registration Number")]
        public string SchemeRegistrationNumber { get; set; }
        /// <summary>
        /// The type of medical scheme registration.
        /// 
        /// 01 - CMS Registration Number
        /// 02 - Phisc Registration Number
        /// 03 - Other
        /// </summary>
        /// 
        [Display(Name = "Scheme Registration Type")]
        public SchemeTypes SchemeRegistrationType { get; set; }
        /// <summary>
        /// Medical Scheme claiming arrangements specific to this claim.
        /// ie. Contract / network / re-imbursement arrangement.
        /// </summary>
        /// 
        [Display(Name = "Scheme Claim Option")]
        public string SchemeClaimOption { get; set; }
        /// <summary>
        /// SwitchOn Destination Code for the Medical Scheme / Plan.
        /// </summary>
        /// 
        [Display(Name = "SwitchOn Destination Code")]
        public string SwitchOnDestinationCode { get; set; }

        /// <summary>
        /// If true, the Card Swipe Indicator field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Card Swipe Indicator")]
        public bool OmitCardSwipeIndicator { get; set; }
        /// <summary>
        /// If true, the Address2 field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Address2")]
        public bool OmitAddress2 { get; set; }
        /// <summary>
        /// If true, the City field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit City")]
        public bool OmitCity { get; set; }
        /// <summary>
        /// If true, the Postal Code field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Postal Code")]
        public bool OmitPostalCode { get; set; }
        /// <summary>
        /// If true, the Phone Number field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Phone Number")]
        public bool OmitPhoneNumber { get; set; }
        /// <summary>
        /// If true, the Plan field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Plan")]
        public bool OmitPlan { get; set; }
        /// <summary>
        /// If true, the Scheme Reference Number field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Scheme Reference Number")]
        public bool OmitSchemeRefNo { get; set; }
        /// <summary>
        /// If true, the Scheme Name field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Scheme Name")]
        public bool OmitSchemeName { get; set; }
        /// <summary>
        /// If true, the Scheme Registration Number field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Scheme Registration Number")]
        public bool OmitSchemeRegistrationNumber { get; set; }
        /// <summary>
        /// If true, the Scheme Registration Type field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Scheme Registration Type")]
        public bool OmitSchemeRegistrationType { get; set; }
        /// <summary>
        /// If true, the Scheme Claim Option field will be completely omitted from the output of the GetCSV method.
        /// </summary>
        [Display(Name = "Omit Scheme Claim Option")]
        public bool OmitSchemeClaimOption { get; set; }

        /// <summary>
        /// If true, the Address2 will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Address2 Blank")]
        public bool IsAddress2Blank { get; set; }
        /// <summary>
        /// If true, the City will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is City Blank")]
        public bool IsCityBlank { get; set; }
        /// <summary>
        /// If true, the Postal Code will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Postal Code Blank")]
        public bool IsPostalCodeBlank { get; set; }
        /// <summary>
        /// If true, the Phone Number will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Phone Number Blank")]
        public bool IsPhoneNumberBlank { get; set; }
        /// <summary>
        /// If true, the Plan will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Plan Blank")]
        public bool IsPlanBlank { get; set; }
        /// <summary>
        /// If true, the Scheme Reference Number will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Scheme Reference Number Blank")]
        public bool IsSchemeRefNoBlank { get; set; }
        /// <summary>
        /// If true, the Scheme Name will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Scheme Name Blank")]
        public bool IsSchemeNameBlank { get; set; }
        /// <summary>
        /// If true, the Scheme Registration Number will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Scheme Registration Number Blank")]
        public bool IsSchemeRegistrationNumberBlank { get; set; }
        /// <summary>
        /// If true, the Scheme Registration Type will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Scheme Registration Type Blank")]
        public bool IsSchemeRegistrationTypeBlank { get; set; }
        /// <summary>
        /// If true, the Scheme Claim Option will appear in the output of GetCSV as a blank value.
        /// </summary>
        [Display(Name = "Is Scheme Claim Option Blank")]
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