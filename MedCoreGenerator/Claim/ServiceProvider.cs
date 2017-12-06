using System;

namespace MedCore.Claim
{
    /// <summary>
    /// Record showing information regarding the Service Provider who is submitting the claim.
    /// </summary>
    public class ServiceProvider
    {
        private const string TYPE = "S";
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

        public override string ToString()
        {
            return $"{TYPE}|{DateCreated.ToString("yyyyMMddHHmm")}|{PracticePCNSNumber}|{BillingPracticeName}|{DatasetIdentifier}|{VATNumber}|";
        }
    }
}