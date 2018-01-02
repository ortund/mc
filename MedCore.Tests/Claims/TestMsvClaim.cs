using MedCore.Claim;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedCore.Tests.Claims
{
    public class TestMsvClaim
    {
        public MSV GetMsv()
        {
            return GenerateMsv();
        }
        public string GetMsvActual()
        {
            return GenerateMsvClaimActual();
        }

        public void WriteMsvJson(MSV claim = null)
        {
            if (claim == null)
            {
                claim = GetMsv();
            }
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Msv.json");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims"));
            }
            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, claim);
            }
        }

        private MSV GenerateMsv()
        {
            var header = new Header
            {
                TransmissionNumber = "12345678",
                Version = "119",
                PackageInfo = "TEST:10.130.212.11729",
                ERAVersionOmitted = true
            };
            var serviceProvider = new ServiceProvider
            {
                DateCreated = DateTime.Parse("2017-11-01 00:36"),
                PracticePCNSNumber = "1234567",
                BillingPracticeName = "DIAGNOSTIC TEST INC.",
                DatasetIdentifier = "1234567",
                VATNumber = string.Empty,
                IsVatNumberBlank = true
            };
            var member = new Member
            {
                IdNumber = 3,
                Title = Enums.MemberTitle.NotApplicable,
                Initials = string.Empty,
                Surname = string.Empty,
                FullNames = string.Empty,
                MembershipNumber = 12345678911,
                OmitCardSwipeIndicator = true,
                PMANumber = string.Empty,
                Address1 = string.Empty,
                SwitchOnDestinationCode = "OPLA0001",
                OmitAddress2 = true,
                OmitCity = true,
                OmitPostalCode = true,
                OmitPhoneNumber = true,
                OmitPlan = true,
                OmitSchemeRefNo = true,
                OmitSchemeName = true,
                OmitSchemeRegistrationNumber = true,
                OmitSchemeRegistrationType = true,
                OmitSchemeClaimOption = true,
                
            };
            var footer = new Footer
            {
                TransmissionNumber = "12345678",
                NumberOfClaims = 1,
                OmitValueOfClaims = true
            };

            return new MSV
            {
                Header = header,
                ServiceProvider = serviceProvider,
                Member = member,
                Footer = footer
            };
        }

        private string GenerateMsvClaimActual()
        {
            var sb = new StringBuilder();
            sb.AppendLine("H|12345678|119|TEST:10.130.212.11729|");
            sb.AppendLine("S|201711010036|1234567|DIAGNOSTIC TEST INC.|1234567|");
            sb.AppendLine("M|3|||||12345678911||||OPLA0001|");
            sb.AppendLine("E|12345678|1|");
            return sb.ToString();
        }
    }
}
