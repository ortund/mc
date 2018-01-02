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
    public class TestEraClaim
    {
        public ERA GetEra()
        {
            return GenerateEraClaim();
        }

        public string GetEraActual()
        {
            return GenerateEraClaimActual();
        }

        private string GenerateEraClaimActual()
        {
            var sb = new StringBuilder();

            sb.AppendLine("H|DISCOVERY HEALTH MED|Discovery Health Adm||DHEA0000|||||123456789|20171101|||");
            sb.AppendLine("S|1234567|Diagnostic TEST (TEST)|");
            sb.AppendLine("EB|1|00|UNKNOWN|20171031||131471697|79600|");
            sb.AppendLine("M|BOND|JAMES|123456789|");
            sb.AppendLine("P|03|BOND||LIAH|20130114||1761874|");
            sb.AppendLine("I|17|17618741|1761874||5tGveX|20171022||40105||ABDOMEN SUPINE ERECT  DECUBIT|09|");
            sb.AppendLine("R|865|We have paid the amount on this line.|");
            sb.AppendLine("EY|79600|79600|0|0|");
            sb.AppendLine("EZ|79600|79600|0|0|");
            sb.AppendLine("EF|79600|79600|0|0|0|");

            return sb.ToString();
        }

        public void WriteEraJson(ERA claim = null)
        {
            if (claim == null)
            {
                claim = GetEra();
            }

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Era.json");

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

        public ERA GenerateEraClaim()
        {
            var header = new Era.Header
            {
                SchemeName = "DISCOVERY HEALTH MED",
                SchemeAdminName = "Discovery Health Adm",
                SchemeRegistrationNumber = string.Empty,
                SwitchDestinationCode = "DHEA0000",
                SchemeContactDetails = string.Empty,
                SchemeTelephoneNumber = string.Empty,
                SchemeFaxNumber = string.Empty,
                SchemeEmailAddress = string.Empty,
                RaReferenceNumber = "123456789",
                RaIssueDate = DateTime.Parse("2017-11-01"),
                OpeningBalanceOmitted = true,
                ClosingBalanceOmitted = true
            };

            var serviceProvider = new Era.ServiceProvider
            {
                PCNSNumber = "1234567",
                Name = "Diagnostic TEST (TEST)"
            };

            var bankDeposit = new Era.BankDeposit
            {
                AccountNumber = "1",
                BranchCode = "00",
                BankName = "UNKNOWN",
                PaymentDate = DateTime.Parse("2017-10-31"),
                PaymentMethod = string.Empty,
                ReferenceNumber = "131471697",
                Amount = 79600
            };
            bankDeposit.IsDepositReferenceBlank = true;

            var member = new Era.Member
            {
                FirstNames = "JAMES",
                Surname = "BOND",
                MembershipNumber = "123456789"
            };

            var patient = new Era.Patient
            {
                DependantCode = "03",
                Surname = "BOND",
                Initials = string.Empty,
                FullNames = "LIAH",
                DOB = DateTime.Parse("2013-01-14"),
                PmaAccountNumber = "1761874"
            };
            patient.OmitIdNumber = true;

            var claimItem = new Era.ClaimItem
            {
                PmaIdentifier = "17",
                PmaClaimLineNumber = "17618741",
                PmaClaimNumber = "1761874",
                LabReferenceNumber = string.Empty,
                TrackingNumber = "5tGveX",
                TreatmentStartDate = DateTime.Parse("2017-10-22"),
                TreatmentEndDate = null,
                ModifierCode = "40105",
                NAPPICode = string.Empty,
                TariffDescription = "ABDOMEN SUPINE ERECT  DECUBIT",
                ResponseResultCodeOverride = "09"
            };

            var response = new Era.Response
            {
                Code = "865",
                Description = "We have paid the amount on this line."
            };

            var itemFinancialRecord = new Era.ItemFinancialRecord
            {
                ClaimedAmount = 79600,
                PaidAmount = 79600,
                AmountPaidToMember = 0,
                PatientLiableAmount = 0
            };

            var patientFinancialRecord = new Era.PatientFinancialRecord
            {
                ClaimedAmount = 79600,
                PaidAmount = 79600,
                TotalPaidToMember = 0,
                PatientLiableAmount = 0
            };

            var financialTotals = new Era.FinancialTotals
            {
                TotalClaimedAmount = 79600,
                TotalPaidAmount = 79600,
                TotalJournalAmount = 0,
                TotalPaidToMember = 0,
                TotalPatientLiableAmount = 0
            };

            return new ERA
            {
                Header = header,
                ServiceProvider = serviceProvider,
                ERABankDeposit = bankDeposit,
                Member = member,
                Patient = patient,
                ERAClaimItem = claimItem,
                ERAResponse = response,
                ERAItemFinancialRecord = itemFinancialRecord,
                ERAPatientFinancialRecord = patientFinancialRecord,
                ERAFinancialTotals = financialTotals
            };
        }
    }
}
