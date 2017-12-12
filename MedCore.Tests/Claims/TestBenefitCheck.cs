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
    public class TestBenefitCheck
    {
        public BenefitCheck1 GetBenefitCheck()
        {
            return GenerateBenefitCheck();
        }

        public string GetBenefitCheckActual()
        {
            return GenerateBenefitCheckActual();
        }

        public void WriteBenefitCheckJson(BenefitCheck1 claim = null)
        {
            if (claim == null)
            {
                claim = GetBenefitCheck();
            }
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\BenefitCheck1.json");
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

        private string GenerateBenefitCheckActual()
        {
            var sb = new StringBuilder();

            sb.AppendLine("H|4567899|100|test:10.130.212.11729|");
            sb.AppendLine("S|201711010337|1234567|DIAGNOSTIC TEST  INC.|1234567||"); // Made a space for the vat number
            sb.AppendLine("M||||||123456789||||||||||||||DHEA0000|");
            sb.AppendLine("P|4|BOND|NZ|JAMES |20171002|F||1234567891011||||||||||4567899|01|02|01|01|"); // Made a space for many properties
            sb.AppendLine("D|01|01|Z03.8||01|");
            sb.AppendLine("T|1|201711010337||00|||02|100|06|30110|||||CHEST 2 VIEWS|||||||||||01|");
            sb.AppendLine("DR|1234567||05||||||");
            sb.AppendLine("Z|57030|");
            sb.AppendLine("F|57030|");
            sb.AppendLine("E|4567899|");

            return sb.ToString();
        }

        private BenefitCheck1 GenerateBenefitCheck()
        {
            var header = new Header
            {
                TransmissionNumber = "4567899",
                Version = "100",
                PackageInfo = "test:10.130.212.11729",
                ERAVersionOmitted = true
            };
            var serviceProvider = new ServiceProvider
            {
                DateCreated = DateTime.Parse("2017-11-01 03:37"),
                PracticePCNSNumber = "1234567",
                BillingPracticeName = "DIAGNOSTIC TEST  INC.",
                DatasetIdentifier = "1234567",
                VATNumber = string.Empty
            };
            var member = new Member
            {
                IdNumber = null,
                Title = Enums.MemberTitle.NotApplicable,
                Initials = string.Empty,
                Surname = string.Empty,
                FullNames = string.Empty,
                MembershipNumber = 123456789,
                CardSwipeIndicator = false,
                OmitCardSwipeIndicator = true,
                PMANumber = string.Empty,
                Address1 = string.Empty, // Spec is missing fields starting here.
                Address2 = string.Empty,
                City = string.Empty,
                PostalCode = string.Empty,
                PhoneNumber = string.Empty,
                Plan = string.Empty,
                SchemeRefNo = string.Empty,
                SchemeName = string.Empty,
                SchemeRegistrationNumber = string.Empty,
                SchemeRegistrationType = Enums.SchemeTypes.NotApplicable, // Missing fields end here.
                SchemeClaimOption = string.Empty,
                SwitchOnDestinationCode = "DHEA0000"
            };
            var patients = new List<Patient>
            {
                new Patient
                {
                    DependantCode = "4",
                    Surname = "BOND",
                    Initials = "NZ",
                    FullName = "JAMES ",
                    DOB = DateTime.Parse("2017-10-02"),
                    Gender = Enums.Gender.Female,
                    PatientRelationCode = Enums.PatientRelationCode.NotApplicable,
                    IdNumber = 1234567891011,
                    COID = string.Empty,
                    PMANumber = "4567899",
                    PatientType = Enums.PatientType.Outpatient,
                    Height = 02,
                    Weight = 01,
                    PMAClaimReferenceNumber = "01",
                    PadDecimals = true
                }
            };
            var diagnoses = new List<DoctorDiagnosis>
            {
                new DoctorDiagnosis
                {
                    DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                    DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10, // Default to "01"
                    Diagnosis = "Z03.8",
                    Description = string.Empty,
                    ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                }
            };
            var treatments = new List<Treatment>
            {
                new Treatment
                {
                    Number = "1",
                    StartDate = DateTime.Parse("2017-11-01 03:37"),
                    EndDate = null,
                    AuthorizationNumber = "00",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "30110",
                    TariffCode = Enums.TariffCodeType.NotApplicable,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    ServiceTariff = Enums.ServiceTariff.NotApplicable,
                    Description = "CHEST 2 VIEWS",
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 57030,
                        OmitPatientLiableAmount = true,
                        OmitMMAPSurchargeAmount = true,
                        OmitMemberReimbursementAmount = true,
                        OmitMedicalFundLiableAmount = true,
                        OmitGrossAmount = true,
                        OmitContainerFee = true,
                        OmitContractFee = true,
                        OmitCoPaymentAmount = true,
                        OmitDiscountAmount = true,
                        OmitDispensingFee = true,
                        OmitExcessTimeFee = true,
                        OmitPatientLevyAmount = true,
                        OmitPrescriptionCalloutFee = true,
                        OmitPrescriptionClaimedAmount = true,
                        OmitPrescriptionCopyFee = true,
                        OmitPrescriptionDeliveryFee = true
                    },
                    PHISCPlaceOfService = "01",
                    IncludeTimeOnDates = true,
                    IsPmbConditionEmpty = true
                }
            };

            var doctor = new Doctor
            {
                PCNSNumber = "1234567",
                Name = string.Empty,
                DoctorType = Enums.DoctorType.Referring,
                CMSRegistrationNumber = string.Empty,
                CMSType = Enums.SchemeTypes.NotApplicable,
                LicenseNumber = string.Empty,
                DesignatedProvider = false,
                DesignatedProviderOmitted = true,
                TrackingNumber = string.Empty
            };

            var claimFinancialRecord = new ClaimFinancialRecord
            {
                NetAmount = 57030,
                OmitClaimDeductibleAmount = true,
                OmitClaimDiscountAmount = true,
                OmitGrossAmount = true,
                OmitMedicalFundLiableAmount = true,
                OmitMemberReimbursementAmount = true,
                OmitMMAPSurchargeAmount = true,
                OmitPatientLiableAmount = true,
                OmitCoPaymentAmount = true,
                OmitReceiptNumber = true,
                OmitTotalClaimedAmount = true,
                IsReceiptNumberBlank = true
            };

            var footer = new Footer
            {
                TransmissionNumber = "4567899",
                OmitNumberOfClaims = true,
                OmitValueOfClaims = true
            };

            return new BenefitCheck1
            {
                Header = header,
                ServiceProvider = serviceProvider,
                Member = member,
                Patients = patients,
                Diagnosis = diagnoses.First(),
                Treatment = treatments.First(),
                Doctor = doctor,
                ClaimFinancialRecord = claimFinancialRecord,
                Footer = footer
            };
        }
    }
}
