using System;

namespace MedCore.Claim
{
    /// <summary>
    /// Record showing information regarding the Service Provider who is submitting the claim.
    /// </summary>
    public class ServiceProvider : ICreatesCSV
    {
        private const string _type = "S";
        /// <summary>
        /// DateTime stamp for when the file is created. Will be formatted to YYYYMMDDhhmm.
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// PCNS number of the Billing Practice.
        /// </summary>
        public string PracticePCNSNumber { get; set; }
        /// <summary>
        /// Name of Billing Practice.
        /// </summary>
        public string BillingPracticeName { get; set; }
        /// <summary>
        /// The PMA dataset from which the claim originated.
        /// </summary>
        public string DatasetIdentifier { get; set; }
        /// <summary>
        /// The VAT registration number of the Service Provider / Billing Practice.
        /// </summary>
        public string VATNumber { get; set; }
        
        public string GetCSV()
        {
            return $"{_type}|{DateCreated:yyyyMMddHHmm}|{PracticePCNSNumber}|{BillingPracticeName}|{DatasetIdentifier}|{VATNumber}|";
        }
    }
}