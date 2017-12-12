using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MedCore.Claim;
using Newtonsoft.Json;

namespace MedCore.Tests.Claims
{
    public class TestGpClaim
    {
        public GpClaim GetGp()
        {
            return GenerateGp();
        }
        public string GetGpActual()
        {
            return GenerateGpClaimActual();
        }

        public void WriteGpJson(GpClaim claim = null)
        {
            if (claim == null)
            {
                claim = GetGp();
            }
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Gp.json");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims"));
            }
            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, claim);

                //Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims"));
            }
        }
   
        private GpClaim GenerateGp()
        {
            var header = new Header
            {
                TransmissionNumber = "13590",
                Version = "118",
                PackageInfo = "TEST SOTWARE : RELEASE 3.5.35",
                ERAVersionOmitted = true
            };
            var serviceProvider = new ServiceProvider
            {
                DateCreated = DateTime.Parse("2017-10-02 18:04"),
                PracticePCNSNumber = "1234567",
                BillingPracticeName = "DR TEST  GP  (SO)",
                DatasetIdentifier = "161",
                VATNumber = string.Empty
            };
            var member = new Member
            {
                IdNumber = 1234567891011,
                Title = Enums.MemberTitle.Mrs,
                Initials = string.Empty,
                Surname = "BOND",
                FullNames = "JAMES",
                MembershipNumber = 123456789,
                CardSwipeIndicator = false,
                PMANumber = "BAL009",
                Address1 = "MIDRAND",
                Address2 = string.Empty,
                City = string.Empty,
                PostalCode = "0157",
                PhoneNumber = "0826564106",
                Plan = "ACCESS PRIMARY ACUTE",
                SchemeRefNo = string.Empty,
                SchemeName = "DISCOVERY KEYCARE",
                SchemeRegistrationNumber = string.Empty,
                SchemeRegistrationType = Enums.SchemeTypes.NotApplicable,
                SchemeClaimOption = string.Empty,
                SwitchOnDestinationCode = "DHEA0000"
            };
            var patient = new Patient
            {
                DependantCode = "00",
                Surname = "BOND",
                Initials = string.Empty,
                FullName = "JAMES",
                DOB = DateTime.Parse("2017-10-02"),
                Gender = Enums.Gender.Female,
                PatientRelationCode = Enums.PatientRelationCode.MainMember,
                IdNumber = 1234567891011,
                PatientType = Enums.PatientType.NotApplicable,
                COID = string.Empty,
                PMANumber = "ZUN00393",
                PMAClaimReferenceNumber = "13591"
            };

            var doctor = new Doctor
            {
                PCNSNumber = "1234567",
                Name = "DR  TEST",
                DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                CMSRegistrationNumber = "MP",
                CMSType = Enums.SchemeTypes.HPCSA,
                DesignatedProvider = false
            };
            var diagnoses = new List<DoctorDiagnosis>
            {
                new DoctorDiagnosis
                {
                    DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                    DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                    Diagnosis = "R53",
                    Description = "Malaise and fatigue",
                    ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                }
            };
            var treatmentFinancialRecord = new TreatmentFinancialRecord
            {
                NetAmount = 34030,
                GrossAmount = 34030,
                DispensingFee = 0,
                ContainerFee = 0,
                ExcessTimeFee = 0,
                PrescriptionCalloutFee = 0,
                PrescriptionCopyFee = 0,
                PrescriptionDeliveryFee = 0,
                ContractFee = 0,
                PrescriptionClaimedAmount = 34030,
                DiscountAmount = 0,
                PatientLevyAmount = 0,
                MMAPSurchargeAmount = 0,
                CoPaymentAmount = 0,
                PatientLiableAmount = 0,
                MedicalFundLiableAmount = 34030,
                MemberReimbursementAmount = 0
            };

            var treatments = new List<Treatment>
            {
                new Treatment
                {
                    Number = "1",
                    StartDate = DateTime.Parse("2017-10-02"),
                    EndDate = DateTime.Parse("2017-10-02"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "18162",
                    ClaimLineNumber = "18162",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "0191",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "New and established patient: Consultatio",
                    PMBCondition = true,
                    ScriptWrittenDate = DateTime.MinValue,
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimNumber = string.Empty,
                    ClaimDate = DateTime.MinValue,
                    PHISCPlaceOfService = "11",
                    Doctor = doctor,
                    Diagnoses = diagnoses,
                    FinancialRecord = treatmentFinancialRecord,
                    IsPmbConditionEmpty = true
                }
            };
            var claimFinancialRecord = new ClaimFinancialRecord
            {
                NetAmount = 34030,
                GrossAmount = 34030,
                TotalClaimedAmount = 34030,
                ClaimDiscountAmount = 0,
                ClaimDeductibleAmount = 0,
                MMAPSurchargeAmount = 0,
                CoPaymentAmount = 0,
                ReceiptNumber = string.Empty,
                PatientLiableAmount = 0,
                MedicalFundLiableAmount = 34030,
                MemberReimbursementAmount = 0
            };
            var footer = new Footer
            {
                TransmissionNumber = "13590",
                NumberOfClaims = 1,
                ValueOfClaims = 34030
            };

            return new GpClaim
            {
                Header = header,
                ServiceProvider = serviceProvider,
                Member = member,
                Patient = patient,
                Treatments = treatments,
                ClaimFinancialRecord = claimFinancialRecord,
                Footer = footer
            };
        }

        private string GenerateGpClaimActual()
        {
            var sb = new StringBuilder();

            sb.AppendLine("H|13590|118|TEST SOTWARE : RELEASE 3.5.35|");
            sb.AppendLine("S|201710021804|1234567|DR TEST  GP  (SO)|161||");
            sb.AppendLine("M|1234567891011|MRS||BOND|JAMES|123456789|N|BAL009|MIDRAND|||0157|0826564106|ACCESS PRIMARY ACUTE||DISCOVERY KEYCARE||||DHEA0000|");
            sb.AppendLine("P|00|BOND||JAMES|20171002|F|01|1234567891011||||||||||ZUN00393||||13591|");
            sb.AppendLine("T|1|20171002|20171002||18162|18162|02|100|06|0191|01|||01|New and established patient: Consultatio|||||||||||11|");
            sb.AppendLine("DR|1234567|DR  TEST|01|MP|01||N||");
            sb.AppendLine("D|01|01|R53|Malaise and fatigue|01|");
            sb.AppendLine("Z|34030|34030|0|0|0|0|0|0|0|34030|0|0|0|0|0|34030|0|");
            sb.AppendLine("F|34030|34030|34030|0|0|0|0||0|34030|0|");
            sb.AppendLine("E|13590|1|34030|");

            return sb.ToString();
        }
    }
}
