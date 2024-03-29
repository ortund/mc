﻿using System.Text;

namespace MedCore.Claim
{
    /// <summary>
    /// Represents a claim header record.
    /// </summary>
    public class Header : ICreatesCSV
    {
        private const string TYPE = "H";
        /// <summary>
        /// The unique sequential number generated by the PMA to identify this claim or batch of claims.
        /// </summary>
        public string TransmissionNumber { get; set; }
        /// <summary>
        /// The version of the SwitchClaim Format.
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// The PMA software package and version number via which the claim is submitted.
        /// 
        /// The version number and package name should be separated with a colon.
        /// </summary>
        public string PackageInfo { get; set; }
        /// <summary>
        /// The version number of the eRA format that must be returned.
        /// </summary>
        public string ERAVersion { get; set; }

        /// <summary>
        /// Determine whether or not the ERA Version information is omitted from this entry.
        /// </summary>
        public bool ERAVersionOmitted { get; set; }

        public string GetCSV()
        {
            var sb = new StringBuilder();

            sb.Append($"{TYPE}|");
            sb.Append($"{TransmissionNumber}|");
            sb.Append($"{Version}|");
            sb.Append($"{PackageInfo}|");

            if (!ERAVersionOmitted)
            {
                sb.Append($"{ERAVersion}|");
            }
            return sb.ToString();
        }
    }
}
