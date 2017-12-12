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
    public class TestDentistClaim
    {
        public Dentist GetDentist()
        {
            return GenerateDentist();
        }

        public string GetDentistActual()
        {
            return GenerateDentistClaimActual();
        }

        public void WriteDentistJson(Dentist claim = null)
        {
            if (claim == null)
            {
                claim = GetDentist();
            }

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore\\Claims\\Dentist.json");
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

        private Dentist GenerateDentist()
        {
            var header = new Header
            {
                TransmissionNumber = "1077917",
                Version = "118",
                PackageInfo = "TEST Live:2014.1.1",
                ERAVersionOmitted = true
            };
            var serviceProvider = new ServiceProvider
            {
                DateCreated = DateTime.Parse("2017-10-11 10:16"),
                BillingPracticeName = "TEST DR",
                PracticePCNSNumber = "1234567",
                DatasetIdentifier = "731",
            };
            var member = new Member
            {
                IdNumber = 1234567891012,
                Title = Enums.MemberTitle.NotApplicable,
                Initials = "L E",
                Surname = "BOND",
                FullNames = "JAMES",
                MembershipNumber = 12345678910,
                CardSwipeIndicator = false,
                OmitCardSwipeIndicator = false,
                PMANumber = "00015",
                Address1 = "PO BOX 123",
                Address2 = string.Empty,
                City = "LIBODE",
                PostalCode = "5160",
                PhoneNumber = "0826564106",
                Plan = string.Empty,
                SchemeName = "POLMED  AQUARIUM AC",
                SchemeRegistrationNumber = string.Empty,
                SchemeRegistrationType = Enums.SchemeTypes.NotApplicable,
                SchemeClaimOption = string.Empty,
                SwitchOnDestinationCode = "MHPO00001"
            };
            var patient = new Patient
            {
                DependantCode = "00",
                Surname = "BOND",
                Initials = "L E",
                FullName = "JAMES",
                DOB = DateTime.Parse("2017-11-02"),
                Gender = Enums.Gender.Male,
                PatientRelationCode = Enums.PatientRelationCode.NotApplicable,
                IdNumber = null,
                RecallDate = null,
                COID = string.Empty,
                InjuryDate = null,
                EmployerName = string.Empty,
                EmployerRegistrationNumber = string.Empty,
                EmployeeNumber = string.Empty,
                InsuranceNumber = string.Empty,
                AuthorizationNumber = string.Empty,
                ConfirmationNumber = "00015",
                PMANumber = string.Empty,
                PatientType = Enums.PatientType.NotApplicable,
                Height = null,
                Weight = 1077917,
                PMAClaimReferenceNumber = string.Empty
            };
            var treatments = new List<Treatment>
            {
                new Treatment
                {
                    Number = "1",
                    StartDate = DateTime.Parse("2017-10-02 00:00"),
                    EndDate = DateTime.Parse("2017-10-02 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "15",
                    ClaimLineNumber = "11731223",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "8101",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "ORAL EXAMINATION",
                    PMBCondition = false,
                    IsPmbConditionEmpty = true,
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimDate = null,
                    PHISCPlaceOfService = "11",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = string.Empty,
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "DP1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "K02.9",
                            Description = string.Empty,
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 21120,
                        GrossAmount = 21120,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 0,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 21120,
                        MemberReimbursementAmount = 0
                    }
                },
                new Treatment
                {
                    Number = "2",
                    StartDate = DateTime.Parse("2017-10-05 00:00"),
                    EndDate = DateTime.Parse("2017-10-05 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "15",
                    ClaimLineNumber = "11731224",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 200,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "8159",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "PROPHYLAXIS  COMPLETE DENTITION",
                    PMBCondition = false,
                    IsPmbConditionEmpty = true,
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimDate = null,
                    PHISCPlaceOfService = "11",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "TEST TN DR",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "DP1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "K02.9",
                            Description = string.Empty,
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 3800,
                        GrossAmount = 3800,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 0,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 3800,
                        MemberReimbursementAmount = 0
                    }
                },
                new Treatment
                {
                    Number = "3",
                    StartDate = DateTime.Parse("2017-10-05 00:00"),
                    EndDate = DateTime.Parse("2017-10-05 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "15",
                    ClaimLineNumber = "11731225",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "8110",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "STERILIZED INSTRUMENTATION",
                    PMBCondition = false,
                    IsPmbConditionEmpty = true,
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimDate = null,
                    PHISCPlaceOfService = "11",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "TEST TN DR",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "DP1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "K02.9",
                            Description = string.Empty,
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 4900,
                        GrossAmount = 4900,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 0,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 4900,
                        MemberReimbursementAmount = 0
                    }
                },
                new Treatment
                {
                    Number = "4",
                    StartDate = DateTime.Parse("2017-10-05 00:00"),
                    EndDate = DateTime.Parse("2017-10-05 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "15",
                    ClaimLineNumber = "11731226",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "8235",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "PARTIAL DENTURE  RESIN BASE  THREE TEETH",
                    PMBCondition = false,
                    IsPmbConditionEmpty = true,
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimDate = null,
                    PHISCPlaceOfService = "11",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "TEST TN DR",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "DP1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "K02.9",
                            Description = string.Empty,
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 89680,
                        GrossAmount = 89680,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 0,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 89680,
                        MemberReimbursementAmount = 0
                    }
                },
                new Treatment
                {
                    Number = "5",
                    StartDate = DateTime.Parse("2017-10-05 00:00"),
                    EndDate = DateTime.Parse("2017-10-05 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "15",
                    ClaimLineNumber = "11731227",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "8255",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "CLASP OR REST  STAINLESS STEEL",
                    PMBCondition = false,
                    IsPmbConditionEmpty = true,
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimDate = null,
                    PHISCPlaceOfService = "11",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "TEST TN DR",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "DP1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "K02.9",
                            Description = string.Empty,
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    Teeth = new List<Tooth>
                    {
                        new Tooth { Number = 16 },
                        new Tooth { Number = 26 },
                        new Tooth { Number = 37 },
                        new Tooth { Number = 45 }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 12500,
                        GrossAmount = 12500,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 0,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 12500,
                        MemberReimbursementAmount = 0
                    }
                },
                new Treatment
                {
                    Number = "6",
                    StartDate = DateTime.Parse("2017-10-05 00:00"),
                    EndDate = DateTime.Parse("2017-10-05 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "15",
                    ClaimLineNumber = "11731228",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "8117",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "DIAGNOSTIC MODELS",
                    PMBCondition = false,
                    IsPmbConditionEmpty = true,
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimDate = null,
                    PHISCPlaceOfService = "11",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "TEST TN DR",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "DP1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "K02.9",
                            Description = string.Empty,
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 9190,
                        GrossAmount = 9190,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 0,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 9190,
                        MemberReimbursementAmount = 0
                    }
                },
                new Treatment
                {
                    Number = "7",
                    StartDate = DateTime.Parse("2017-10-05 00:00"),
                    EndDate = DateTime.Parse("2017-10-05 00:00"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "15",
                    ClaimLineNumber = "11731229",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "8273",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "IMPRESSION TO REPAIR OR MODIFY A DENTURE OR OTHER INTRAORAL APPLIANCE",
                    PMBCondition = false,
                    IsPmbConditionEmpty = true,
                    BenefitType = Enums.BenefitType.NotApplicable,
                    HospitalTariff = Enums.HospitalTariffType.NotApplicable,
                    LabPCNS = string.Empty,
                    LabReferenceNumber = string.Empty,
                    LabName = string.Empty,
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable,
                    ClaimDate = null,
                    PHISCPlaceOfService = "11",
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "TEST TN DR",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "DP1234567",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "K02.9",
                            Description = string.Empty,
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 9500,
                        GrossAmount = 9500,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 0,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 9500,
                        MemberReimbursementAmount = 0
                    }
                }
            };

            var claimFinancialRecord = new ClaimFinancialRecord
            {
                NetAmount = 150690,
                GrossAmount = 150690,
                ClaimDiscountAmount = 0,
                ClaimDeductibleAmount = 0,
                MMAPSurchargeAmount = 0,
                CoPaymentAmount = 0,
                PatientLiableAmount = 0,
                MedicalFundLiableAmount = 150690,
                MemberReimbursementAmount = 0
            };

            var footer = new Footer
            {
                TransmissionNumber = "12345678",
                NumberOfClaims = 1,
                OmitValueOfClaims = true
            };

            return new Dentist
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

        public string GenerateDentistClaimActual()
        {
            var sb = new StringBuilder();

            sb.AppendLine("H|1077917|118|TEST Live:2014.1.1|");
            sb.AppendLine("S|201710111016|1234567|TEST DR|731||");
            sb.AppendLine("M|1234567891012||L E|BOND|JAMES|12345678910|N|00015|PO BOX 123||LIBODE|5160|0826564106|||POLMED  AQUARIUM AC||||MHPO0001|");
            sb.AppendLine("P|00|BOND|L E|JAMES|12345678|M||1234567891012||||||||||00015||||1077917|");
            sb.AppendLine("T|1|201710050000|201710050000||15|11731223|02|100|06|8101|01|||01|ORAL EXAMINATION|||||||||||11|");
            sb.AppendLine("DR|1234567|TEST TN DR|01|DP1234567|01||||");
            sb.AppendLine("D|01|01|K02.9||01|");
            sb.AppendLine("Z|21120|21120|0|0|0|0|0|0|0|0|0|0|0|0|0|21120|0|");
            sb.AppendLine("T|2|201710050000|201710050000||15|11731224|02|200|06|8159|01|||01|PROPHYLAXIS  COMPLETE DENTITION|||||||||||11|");
            sb.AppendLine("DR|1234567|TEST TN DR|01|DP1234567|01||||");
            sb.AppendLine("D|01|01|K02.9||01|");
            sb.AppendLine("Z|3800|3800|0|0|0|0|0|0|0|0|0|0|0|0|0|3800|0|");
            sb.AppendLine("T|3|201710050000|201710050000||15|11731225|02|100|06|8110|01|||01|STERILIZED INSTRUMENTATION|||||||||||11|");
            sb.AppendLine("DR|1234567|TEST TN DR|01|DP1234567|01||||");
            sb.AppendLine("D|01|01|K02.9||01|");
            sb.AppendLine("Z|4900|4900|0|0|0|0|0|0|0|0|0|0|0|0|0|4900|0|");
            sb.AppendLine("T|4|201710050000|201710050000||15|11731226|02|100|06|8235|01|||01|PARTIAL DENTURE  RESIN BASE  THREE TEETH|||||||||||11|");
            sb.AppendLine("DR|1234567|TEST TN DR|01|DP1234567|01||||");
            sb.AppendLine("D|01|01|K02.9||01|");
            sb.AppendLine("Z|89680|89680|0|0|0|0|0|0|0|0|0|0|0|0|0|89680|0|");
            sb.AppendLine("T|5|201710050000|201710050000||15|11731227|02|100|06|8255|01|||01|CLASP OR REST  STAINLESS STEEL|||||||||||11|");
            sb.AppendLine("DR|1234567|TEST TN DR|01|DP1234567|01||||");
            sb.AppendLine("D|01|01|K02.9||01|");
            sb.AppendLine("N|16|||");
            sb.AppendLine("N|26|||");
            sb.AppendLine("N|37|||");
            sb.AppendLine("N|45|||");
            sb.AppendLine("Z|12500|12500|0|0|0|0|0|0|0|0|0|0|0|0|0|12500|0|");
            sb.AppendLine("T|6|201710050000|201710050000||15|11731228|02|100|06|8117|01|||01|DIAGNOSTIC MODELS|||||||||||11|");
            sb.AppendLine("DR|1234567|TEST TN DR|01|DP1234567|01||||");
            sb.AppendLine("D|01|01|K02.9||01|");
            sb.AppendLine("Z|9190|9190|0|0|0|0|0|0|0|0|0|0|0|0|0|9190|0|");
            sb.AppendLine("T|7|201710050000|201710050000||15|11731229|02|100|06|8273|01|||01|IMPRESSION TO REPAIR OR MODIFY A DENTURE OR OTHER INTRAORAL APPLIANCE|||||||||||11|");
            sb.AppendLine("DR|1234567|TEST TN DR|01|DP1234567|01||||");
            sb.AppendLine("D|01|01|K02.9||01|");
            sb.AppendLine("Z|9500|9500|0|0|0|0|0|0|0|0|0|0|0|0|0|9500|0|");
            sb.AppendLine("F|150690|150690|150690|0|0|0|0||0|150690|0|");
            sb.AppendLine("E|1077917|1|150690|");

            return sb.ToString();
        }
    }
}
