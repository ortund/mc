using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MedCore.Claim;
using Newtonsoft.Json;

namespace MedCore.Tests.Claims
{
    public class TestAnaesthetistClaim
    {
        public Anaesthetist GetAnaesthetist()
        {
            return GenerateAnaesthetist();
        }

        public string GetAnaesthetistActual()
        {
            return GenerateAnaesthetistClaimActual();
        }

        public void WriteAnaesthetistJson(Anaesthetist claim = null)
        {
            if (claim == null)
            {
                claim = GetAnaesthetist();
            }
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Anaesthetist.json");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims"));
            }
            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, claim);

                Process.Start(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims"));
            }
        }

        public Anaesthetist GenerateAnaesthetist()
        {
            var header = new Header
            {
                TransmissionNumber = "9150",
                Version = "119",
                PackageInfo = "TEST:21100",
                ERAVersionOmitted = true
            };
            var serviceProvider = new ServiceProvider
            {
                DateCreated = DateTime.Parse("2017-10-03 17:27"),
                PracticePCNSNumber = "1234567",
                BillingPracticeName = "DR P.H. TEST  SPECIALIST ANAESTHETIS",
                DatasetIdentifier = "{0E028DC11706447B8DA552205A99CDD7}",
                VATNumber = "4280204720"
            };
            var member = new Member
            {
                IdNumber = 1234567891012,
                Title = Enums.MemberTitle.NotApplicable,
                Initials = "FC",
                Surname = "BOND",
                FullNames = "JAMES C",
                MembershipNumber = 12345678910,
                CardSwipeIndicator = false,
                PMANumber = "H007210",
                Address1 = string.Empty,
                Address2 = string.Empty,
                City = string.Empty,
                PostalCode = string.Empty,
                PhoneNumber = string.Empty,
                Plan = "MARINE",
                SchemeRefNo = string.Empty,
                SchemeName = "POLMED",
                SchemeRegistrationNumber = string.Empty,
                SchemeRegistrationType = Enums.SchemeTypes.SACSSP,
                SchemeClaimOption = string.Empty,
                SwitchOnDestinationCode = "MHPO0001"
            };
            var patient = new Patient
            {
                DependantCode = "00",
                Surname = "BOND",
                Initials = "FC",
                FullName = "JAMES C",
                DOB = DateTime.Parse("2017-10-02"),
                Gender = Enums.Gender.Male,
                PatientRelationCode = Enums.PatientRelationCode.MainMember,
                IdNumber = 1234567891012,
                COID = string.Empty,
                AuthorizationNumber = "77711087",
                ConfirmationNumber = "77711087",
                PMANumber = "H007210",
                PatientType = Enums.PatientType.Outpatient,
                PMAClaimReferenceNumber = "9150"
            };
            var doctor = new Doctor
            {
                PCNSNumber = "1234567",
                Name = "Dr TESTS",
                DoctorType = Enums.DoctorType.Referring,
                CMSRegistrationNumber = "L    0000000",
                CMSType = Enums.SchemeTypes.HPCSA,
                DesignatedProvider = false,
                DesignatedProviderOmitted = true
            };

            var treatments = new List<Treatment>
            {
                new Treatment
                {
                    IncludeTimeOnDates = true,
                    Number = "1",
                    StartDate = DateTime.Parse("2017-09-28 00:00"),
                    EndDate = DateTime.Parse("2017-09-28 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "9150",
                    ClaimLineNumber = "34927",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "0151",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.SAMA,
                    Description = "Preanaesthetic assessment: Preanaesthetic assess",
                    PMBCondition = false,
                    ScriptWrittenDate = DateTime.MinValue,
                    BenefitType = Enums.BenefitType.Acute,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimNumber = string.Empty,
                    ClaimDate = DateTime.MinValue,
                    PHISCPlaceOfService = "24",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "DR P.H. TEST ",
                        DoctorType = Enums.DoctorType.Anaesthetist,
                        CMSRegistrationNumber = "MP   1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false,
                        DesignatedProviderOmitted = true
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "R39.1",
                            Description = "Other difficulties with micturition",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        },
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "N41.9",
                            Description = "Inflammatory disease of prostate, unspecified",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Secondary
                        },
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "N40",
                            Description = "Hyperplasia of prostate",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Secondary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 50370,
                        GrossAmount = 50370,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 50370,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 50370,
                        MemberReimbursementAmount = 0
                    }
                },
                new Treatment
                {
                    IncludeTimeOnDates = true,
                    Number = "2",
                    StartDate = DateTime.Parse("2017-09-28 00:00"),
                    EndDate = DateTime.Parse("2017-09-28 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "9150",
                    ClaimLineNumber = "34928",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "1949",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.SAMA,
                    Description = "Cystoscopy: Hospital equipment",
                    PMBCondition = false,
                    ScriptWrittenDate = DateTime.MinValue,
                    BenefitType = Enums.BenefitType.Acute,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimNumber = string.Empty,
                    ClaimDate = DateTime.MinValue,
                    PHISCPlaceOfService = "24",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "DR P.H. TEST ",
                        DoctorType = Enums.DoctorType.Anaesthetist,
                        CMSRegistrationNumber = "MP   1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false,
                        DesignatedProviderOmitted = true
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "R39.1",
                            Description = "Other difficulties with micturition",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        },
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "N41.9",
                            Description = "Inflammatory disease of prostate, unspecified",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Secondary
                        },
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "N40",
                            Description = "Hyperplasia of prostate",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Secondary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 36700,
                        GrossAmount = 36700,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 36700,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 36700,
                        MemberReimbursementAmount = 0
                    }
                },
                new Treatment
                {
                    IncludeTimeOnDates = true,
                    Number = "3",
                    StartDate = DateTime.Parse("2017-09-28 14:01"),
                    EndDate = DateTime.Parse("2017-09-28 14:28"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "9150",
                    ClaimLineNumber = "34929",
                    Type = Enums.TreatmentType.Modifier,
                    UnitQuantity = 2700,
                    UnitType = Enums.UnitType.Minute,
                    ProcedureModifierCode = "0023",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.Add,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.SAMA,
                    Description = "Anaesthetic Time",
                    PMBCondition = false,
                    ScriptWrittenDate = DateTime.MinValue,

                    BenefitType = Enums.BenefitType.Acute,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimNumber = string.Empty,
                    ClaimDate = DateTime.MinValue,
                    PHISCPlaceOfService = "24",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "DR P.H. TEST ",
                        DoctorType = Enums.DoctorType.Anaesthetist,
                        CMSRegistrationNumber = "MP   1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false,
                        DesignatedProviderOmitted = true
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "R39.1",
                            Description = "Other difficulties with micturition",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        },
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "N41.9",
                            Description = "Inflammatory disease of prostate, unspecified",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Secondary
                        },
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "N40",
                            Description = "Hyperplasia of prostate",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Secondary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 48930,
                        GrossAmount = 48930,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 48930,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 48930,
                        MemberReimbursementAmount = 0
                    }
                }
            };

            var claimFinancialRecord = new ClaimFinancialRecord
            {
                NetAmount = 136000,
                GrossAmount = 136000,
                TotalClaimedAmount = 136000,
                ClaimDiscountAmount = 0,
                ClaimDeductibleAmount = 0,
                MMAPSurchargeAmount = 0,
                CoPaymentAmount = 0,
                ReceiptNumber = string.Empty,
                PatientLiableAmount = 0,
                MedicalFundLiableAmount = 136000,
                MemberReimbursementAmount = 0
            };
            var footer = new Footer
            {
                TransmissionNumber = "9150",
                NumberOfClaims = 1,
                ValueOfClaims = 136000
            };

            return new Anaesthetist
            {
                Header = header,
                ServiceProvider = serviceProvider,
                Member = member,
                Patient = patient,
                Doctor = doctor,
                Treatments = treatments,
                ClaimFinancialRecord = claimFinancialRecord,
                Footer = footer
            };
        }

        private string GenerateAnaesthetistClaimActual()
        {
            var sb = new StringBuilder();

            sb.AppendLine("H|9150|119|TEST:21100|");
            sb.AppendLine("S|201710031727|1234567|DR P.H. TEST  SPECIALIST ANAESTHETIS|{0E028DC11706447B8DA552205A99CDD7}|4280204720|");
            sb.AppendLine("M|1234567891012||FC|BOND|JAMES C|12345678910|N|H007210||||||MARINE||POLMED||03||MHPO0001|");
            sb.AppendLine("P|00|BOND|FC|JAMES C|20171002|M|01|1234567891012||||||||77711087|77711087|H007210|01|||9150|");
            sb.AppendLine("DR|1234567|Dr TESTS|05|L    0000000|01||||");
            sb.AppendLine("T|1|201709280000|201709280000||9150|34927|02|100|06|0151|01|||08|Preanaesthetic assessment: Preanaesthetic assess|N||01||||||||24|");
            sb.AppendLine("DR|1234567|DR P.H. TEST |03|MP   1234567|01||||");
            sb.AppendLine("D|01|01|R39.1|Other difficulties with micturition|01|");
            sb.AppendLine("D|01|01|N41.9|Inflammatory disease of prostate, unspecified|02|");
            sb.AppendLine("D|01|01|N40|Hyperplasia of prostate|02|");
            sb.AppendLine("Z|50370|50370|0|0|0|0|0|0|0|50370|0|0|0|0|0|50370|0|");
            sb.AppendLine("T|2|201709280000|201709280000||9150|34928|02|100|06|1949|01|||08|Cystoscopy: Hospital equipment|N||01||||||||24|");
            sb.AppendLine("DR|1234567|DR P.H. TEST |03|MP   1234567|01||||");
            sb.AppendLine("D|01|01|R39.1|Other difficulties with micturition|01|");
            sb.AppendLine("D|01|01|N41.9|Inflammatory disease of prostate, unspecified|02|");
            sb.AppendLine("D|01|01|N40|Hyperplasia of prostate|02|");
            sb.AppendLine("Z|36700|36700|0|0|0|0|0|0|0|36700|0|0|0|0|0|36700|0|");
            sb.AppendLine("T|3|201709281401|201709281428||9150|34929|03|2700|03|0023|01|03||08|Anaesthetic Time|N||01||||||||24|");
            sb.AppendLine("DR|1234567|DR P.H. TEST |03|MP   1234567|01||||");
            sb.AppendLine("D|01|01|R39.1|Other difficulties with micturition|01|");
            sb.AppendLine("D|01|01|N41.9|Inflammatory disease of prostate, unspecified|02|");
            sb.AppendLine("D|01|01|N40|Hyperplasia of prostate|02|");
            sb.AppendLine("Z|48930|48930|0|0|0|0|0|0|0|48930|0|0|0|0|0|48930|0|");
            sb.AppendLine("F|136000|136000|136000|0|0|0|0||0|136000|0|");
            sb.AppendLine("E|9150|1|136000|");

            return sb.ToString();
        }
    }
}
