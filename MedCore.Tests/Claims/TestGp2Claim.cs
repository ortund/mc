using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using MedCore.Claim;
using Newtonsoft.Json;

namespace MedCore.Tests.Claims
{
    public class TestGp2Claim
    {
        private readonly string _claimsDirectory;

        private const string _json = "Gp2.json";
        private const string _fromClass = "Gp2.csv";
        private const string _fromString = "Gp2action.csv";

        public TestGp2Claim()
        {
            _claimsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MedCore", "Claims");

            if (!Directory.Exists(_claimsDirectory))
                Directory.CreateDirectory(_claimsDirectory);
        }

        public string GetGp2Actual()
        {
            return GetExampleCSV();
        }

        public void CreateFiles()
        {
            var claim = GetExampleClaim();

            var path = Path.Combine(_claimsDirectory, _json);

            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file, claim);

                Process.Start(_claimsDirectory);
            }

            var txtPath = Path.Combine(_claimsDirectory, _fromClass);
            File.WriteAllText(txtPath, claim.GenerateClaim());

            txtPath = Path.Combine(_claimsDirectory, _fromString);
            File.WriteAllText(txtPath, GetExampleCSV());
        }
        
        private static Gp2Claim GetExampleClaim()
        {
            var header = new Header
            {
                TransmissionNumber = "13650",
                Version = "118",
                PackageInfo = "TEST SOTWARE : RELEASE 3.5.35",
                ERAVersionOmitted = true
            };
            var serviceProvider = new ServiceProvider
            {
                DateCreated = DateTime.Parse("2017-10-04 06:23"),
                PracticePCNSNumber = "1234567",
                BillingPracticeName = "DR S TEST  GP  (SO)",
                DatasetIdentifier = "161",
                VATNumber = string.Empty
            };
            var member = new Member
            {
                // M|1234567891012|MR||BOND|JAMES|189693291|N|Q7|NOWHERE|||0157|0826564106|COMPREHENSIVE CLASSI||DISCOVERY||||DHEA0000|
                IdNumber = 1234567891012,
                Title = Enums.MemberTitle.Mr,
                Initials = string.Empty,
                Surname = "BOND",
                FullNames = "JAMES",
                MembershipNumber = 189693291,
                CardSwipeIndicator = false,
                PMANumber = "Q7",
                Address1 = "NOWHERE",
                Address2 = string.Empty,
                City = string.Empty,
                PostalCode = "0157",
                PhoneNumber = "0826564106",
                Plan = "COMPREHENSIVE CLASSI",
                SchemeRefNo = string.Empty,
                SchemeName = "DISCOVERY",
                SchemeRegistrationNumber = string.Empty,
                SchemeRegistrationType = Enums.SchemeTypes.NotApplicable,
                SchemeClaimOption = string.Empty,
                SwitchOnDestinationCode = "DHEA0000"
            };
            var patient = new Patient
            {
                // P|0|BOND||JAMES|12345678|M|01|1234567891012||||||||||HAS001||||13651|
                DependantCode = "0",
                Surname = "BOND",
                Initials = string.Empty,
                FullName = "JAMES",
                DOB = DateTime.Parse("2017-10-02"),
                Gender = Enums.Gender.Male,
                PatientRelationCode = Enums.PatientRelationCode.MainMember,
                IdNumber = 1234567891012,
                PatientType = Enums.PatientType.NotApplicable,
                COID = string.Empty,
                PMANumber = "HAS001",
                PMAClaimReferenceNumber = "13651"
            };

            var doctor = new Doctor
            {
                PCNSNumber = "1234567",
                Name = "DR SS TEST",
                DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                CMSRegistrationNumber = "MP",
                CMSType = Enums.SchemeTypes.HPCSA,
                DesignatedProvider = false
            };

            var treatments = new List<Treatment>
            {
                new Treatment // 0
                {
                    Number = "1",
                    StartDate = DateTime.Parse("2017-10-03"),
                    EndDate = DateTime.Parse("2017-10-03"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "18238",
                    ClaimLineNumber = "18238",
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
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "M70.99",
                            Description = "Unspecified soft tissue disorder related to use, overuse and pressure,",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 40600,
                        GrossAmount = 40600,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 40600,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 40600,
                        MemberReimbursementAmount = 0
                    },
                    IsPmbConditionEmpty = true
                },
                new Treatment // 1
                {
                    Number = "2",
                    StartDate = DateTime.Parse("2017-10-03"),
                    EndDate = DateTime.Parse("2017-10-03"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "18239",
                    ClaimLineNumber = "18239",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "0201",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "RAYZON IVIM POWDER [40MG INJ]",
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
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "DR SS TEST",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "MP",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "M70.99",
                            Description = "Unspecified soft tissue disorder related to use, overuse and pressure,",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 11400,
                        GrossAmount = 11400,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 11400,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 11400,
                        MemberReimbursementAmount = 0
                    },
                    IsPmbConditionEmpty = true
                },
                new Treatment // 2
                {
                    Number = "3",
                    StartDate = DateTime.Parse("2017-10-03"),
                    EndDate = DateTime.Parse("2017-10-03"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "18240",
                    ClaimLineNumber = "18240",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "0201",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "SYRINGE & NEEDLE 20G 3ML 10371 [10371 SNG]",
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
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "DR SS TEST",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "MP",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "M70.99",
                            Description = "Unspecified soft tissue disorder related to use, overuse and pressure,",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 1100,
                        GrossAmount = 1100,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 1100,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 1100,
                        MemberReimbursementAmount = 0
                    },
                    IsPmbConditionEmpty = true
                },
                new Treatment // 3
                {
                    Number = "4",
                    StartDate = DateTime.Parse("2017-10-03"),
                    EndDate = DateTime.Parse("2017-10-03"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "18241",
                    ClaimLineNumber = "18241",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "0201",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "WEBCOL ALCOHOL SWABS [MED16818 CSM]",
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
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "DR SS TEST",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "MP",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "M70.99",
                            Description = "Unspecified soft tissue disorder related to use, overuse and pressure,",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 60,
                        GrossAmount = 60,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 60,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 60,
                        MemberReimbursementAmount = 0
                    },
                    IsPmbConditionEmpty = true
                },
                new Treatment // 4
                {
                    Number = "5",
                    StartDate = DateTime.Parse("2017-10-03"),
                    EndDate = DateTime.Parse("2017-10-03"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "18242",
                    ClaimLineNumber = "18242",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "0201",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "GLOVE  PEHA SOFT P [9421505SML BBR]",
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
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "DR SS TEST",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "MP",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "M70.99",
                            Description = "Unspecified soft tissue disorder related to use, overuse and pressure,",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 102,
                        GrossAmount = 102,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 102,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 102,
                        MemberReimbursementAmount = 0
                    },
                    IsPmbConditionEmpty = true
                },
                new Treatment // 5
                {
                    Number = "6",
                    StartDate = DateTime.Parse("2017-10-03"),
                    EndDate = DateTime.Parse("2017-10-03"),
                    AuthorizationNumber = string.Empty,
                    InvoiceNumber = "18243",
                    ClaimLineNumber = "18243",
                    Type = Enums.TreatmentType.Tariff,
                    UnitQuantity = 100,
                    UnitType = Enums.UnitType.Unit,
                    ProcedureModifierCode = "0147",
                    TariffCode = Enums.TariffCodeType.NHRRPL,
                    ModifierType = Enums.TreatmentModifierType.NotApplicable,
                    NAPPICode = string.Empty,
                    ServiceTariff = Enums.ServiceTariff.NHRPL,
                    Description = "For an emergency consultation/visit away",
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
                    Doctor = new Doctor
                    {
                        PCNSNumber = "1234567",
                        Name = "DR SS TEST",
                        DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                        CMSRegistrationNumber = "MP",
                        CMSType = Enums.SchemeTypes.HPCSA,
                        DesignatedProvider = false
                    },
                    Diagnoses = new List<DoctorDiagnosis>
                    {
                        new DoctorDiagnosis
                        {
                            DoctorType = Enums.DoctorType.AttendingTreatingPrescribing,
                            DiagnosisCodeType = Enums.DiagnosisCodeType.ICD10,
                            Diagnosis = "M70.99",
                            Description = "Unspecified soft tissue disorder related to use, overuse and pressure,",
                            ExtendedDiagnosis = Enums.ExtendedDiagnosis.Primary
                        }
                    },
                    FinancialRecord = new TreatmentFinancialRecord
                    {
                        NetAmount = 28070,
                        GrossAmount = 28070,
                        DispensingFee = 0,
                        ContainerFee = 0,
                        ExcessTimeFee = 0,
                        PrescriptionCalloutFee = 0,
                        PrescriptionCopyFee = 0,
                        PrescriptionDeliveryFee = 0,
                        ContractFee = 0,
                        PrescriptionClaimedAmount = 28070,
                        DiscountAmount = 0,
                        PatientLevyAmount = 0,
                        MMAPSurchargeAmount = 0,
                        CoPaymentAmount = 0,
                        PatientLiableAmount = 0,
                        MedicalFundLiableAmount = 28070,
                        MemberReimbursementAmount = 0
                    },
                    IsPmbConditionEmpty = true
                }
            };

            var itemFinancialRecords = new List<ItemFinancialRecord>
            {
                new ItemFinancialRecord // Treatment 2
                {
                    NetPrice = 11400,
                    GrossPrice = 11400,
                    DispensingFee = 0,
                    ContainerFee = 0,
                    ExcessTimeFee = 0,
                    ItemContractFee = 0,
                    ClaimedAmount = 11400,
                    DiscountAmount = 0,
                    PatientLevyAmount = 0,
                    MMAPSurchargeAmount = 0,
                    CoPaymentAmount = 0,
                    PatientLiableAmount = 0,
                    MedicalFundLiableAmount = 11400,
                    MemberReimbursementAmount = 0
                },
                new ItemFinancialRecord // Treatment 3
                {
                    NetPrice = 1100,
                    GrossPrice = 1100,
                    DispensingFee = 0,
                    ContainerFee = 0,
                    ExcessTimeFee = 0,
                    ItemContractFee = 0,
                    ClaimedAmount = 1100,
                    DiscountAmount = 0,
                    PatientLevyAmount = 0,
                    MMAPSurchargeAmount = 0,
                    CoPaymentAmount = 0,
                    PatientLiableAmount = 0,
                    MedicalFundLiableAmount = 1100,
                    MemberReimbursementAmount = 0
                },
                new ItemFinancialRecord // Treatment 4
                {
                    NetPrice = 60,
                    GrossPrice = 60,
                    DispensingFee = 0,
                    ContainerFee = 0,
                    ExcessTimeFee = 0,
                    ItemContractFee = 0,
                    ClaimedAmount = 60,
                    DiscountAmount = 0,
                    PatientLevyAmount = 0,
                    MMAPSurchargeAmount = 0,
                    CoPaymentAmount = 0,
                    PatientLiableAmount = 0,
                    MedicalFundLiableAmount = 60,
                    MemberReimbursementAmount = 0
                },
                new ItemFinancialRecord // Treatment 5
                {
                    NetPrice = 102,
                    GrossPrice = 102,
                    DispensingFee = 0,
                    ContainerFee = 0,
                    ExcessTimeFee = 0,
                    ItemContractFee = 0,
                    ClaimedAmount = 102,
                    DiscountAmount = 0,
                    PatientLevyAmount = 0,
                    MMAPSurchargeAmount = 0,
                    CoPaymentAmount = 0,
                    PatientLiableAmount = 0,
                    MedicalFundLiableAmount = 102,
                    MemberReimbursementAmount = 0
                }
            };

            var meds = new List<DispensedMedicine>
            {
                new DispensedMedicine
                {
                    Treatment = treatments[1],
                    FinancialRecord = itemFinancialRecords[0],
                    MixtureIndicator = false,
                    MixtureIngredient = "0",
                    MedicineCost = 0,
                    Type = Enums.MedicineType.NotApplicable,
                    NappiCode = "700838001",
                    EanCode = string.Empty,
                    Description = "RAYZON IVIM POWDER [40MG INJ]",
                    Quantity = 100,
                    Dosage = string.Empty,
                    Length = 1,
                    LengthBasis = string.Empty,
                    Repeats = 0,
                    AuthorizedRepeats = 0,
                    OriginalPrescriptionNumber = "0",
                    Daw = Enums.Daw.None,
                    AuthorizationNumber = string.Empty,
                    PriceBasis = Enums.PriceBasis.SingleExistPrice,
                    PMAMedicineItemLineNumber = "18239",
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable
                },
                new DispensedMedicine
                {
                    Treatment = treatments[2],
                    FinancialRecord = itemFinancialRecords[1],
                    MixtureIndicator = false,
                    MixtureIngredient = "0",
                    MedicineCost = 0,
                    Type = Enums.MedicineType.NotApplicable,
                    NappiCode = "500268007",
                    EanCode = string.Empty,
                    Description = "SYRINGE & NEEDLE 20G 3ML 10371 [10371 SNG]",
                    Quantity = 100,
                    Dosage = string.Empty,
                    Length = 1,
                    LengthBasis = string.Empty,
                    Repeats = 0,
                    AuthorizedRepeats = 0,
                    OriginalPrescriptionNumber = "0",
                    Daw = Enums.Daw.None,
                    AuthorizationNumber = string.Empty,
                    PriceBasis = Enums.PriceBasis.SingleExistPrice,
                    PMAMedicineItemLineNumber = "18240",
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable
                },
                new DispensedMedicine
                {
                    Treatment = treatments[3],
                    FinancialRecord = itemFinancialRecords[2],
                    MixtureIndicator = false,
                    MixtureIngredient = "0",
                    MedicineCost = 0,
                    Type = Enums.MedicineType.NotApplicable,
                    NappiCode = "496125003",
                    EanCode = string.Empty,
                    Description = "WEBCOL ALCOHOL SWABS [MED16818 CSM]",
                    Quantity = 100,
                    Dosage = string.Empty,
                    Length = 1,
                    LengthBasis = string.Empty,
                    Repeats = 0,
                    AuthorizedRepeats = 0,
                    OriginalPrescriptionNumber = "0",
                    Daw = Enums.Daw.None,
                    AuthorizationNumber = string.Empty,
                    PriceBasis = Enums.PriceBasis.SingleExistPrice,
                    PMAMedicineItemLineNumber = "18241",
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable
                },
                new DispensedMedicine
                {
                    Treatment = treatments[4],
                    FinancialRecord = itemFinancialRecords[3],
                    MixtureIndicator = false,
                    MixtureIngredient = "0",
                    MedicineCost = 0,
                    Type = Enums.MedicineType.NotApplicable,
                    NappiCode = "429631001",
                    EanCode = string.Empty,
                    Description = "GLOVE  PEHA SOFT P [9421505SML BBR]",
                    Quantity = 100,
                    Dosage = string.Empty,
                    Length = 1,
                    LengthBasis = string.Empty,
                    Repeats = 0,
                    AuthorizedRepeats = 0,
                    OriginalPrescriptionNumber = "0",
                    Daw = Enums.Daw.None,
                    AuthorizationNumber = string.Empty,
                    PriceBasis = Enums.PriceBasis.SingleExistPrice,
                    PMAMedicineItemLineNumber = "18242",
                    ResubmissionReason = Enums.ResubmissionReason.NotApplicable
                },
            };

            var claimFinancialRecord = new ClaimFinancialRecord
            {
                NetAmount = 81332,
                GrossAmount = 81332,
                TotalClaimedAmount = 81332,
                ClaimDiscountAmount = 0,
                ClaimDeductibleAmount = 0,
                MMAPSurchargeAmount = 0,
                CoPaymentAmount = 0,
                ReceiptNumber = string.Empty,
                PatientLiableAmount = 0,
                MedicalFundLiableAmount = 81332,
                MemberReimbursementAmount = 0
            };
            var footer = new Footer
            {
                TransmissionNumber = "13650",
                NumberOfClaims = 1,
                ValueOfClaims = 81332
            };

            return new Gp2Claim
            {
                Header = header,
                ServiceProvider = serviceProvider,
                Member = member,
                Patient = patient,
                Treatments = treatments,
                DispensedMedicines = meds,
                ClaimFinancialRecord = claimFinancialRecord,
                Footer = footer
            };
        }

        private static string GetExampleCSV()
        {
            var sb = new StringBuilder();

            sb.AppendLine("H|13650|118|TEST SOTWARE : RELEASE 3.5.35|");
            sb.AppendLine("S|201710040623|1234567|DR S TEST  GP  (SO)|161||");
            sb.AppendLine("M|1234567891012|MR||BOND|JAMES|189693291|N|Q7|NOWHERE|||0157|0826564106|COMPREHENSIVE CLASSI||DISCOVERY||||DHEA0000|");
            sb.AppendLine("P|0|BOND||JAMES|20171002|M|01|1234567891012||||||||||HAS001||||13651|");
            sb.AppendLine("T|1|20171003|20171003||18238|18238|02|100|06|0191|01|||01|New and established patient: Consultatio|||||||||||11|");
            sb.AppendLine("DR|1234567|DR SS TEST|01|MP|01||N||");
            sb.AppendLine("D|01|01|M70.99|Unspecified soft tissue disorder related to use, overuse and pressure,|01|");
            sb.AppendLine("Z|40600|40600|0|0|0|0|0|0|0|40600|0|0|0|0|0|40600|0|");
            sb.AppendLine("T|2|20171003|20171003||18239|18239|02|100|06|0201|01|||01|RAYZON IVIM POWDER [40MG INJ]|||||||||||11|");
            sb.AppendLine("DR|1234567|DR SS TEST|01|MP|01||N||");
            sb.AppendLine("D|01|01|M70.99|Unspecified soft tissue disorder related to use, overuse and pressure,|01|");
            sb.AppendLine("C|N|0|0||700838001||RAYZON IVIM POWDER [40MG INJ]|100||1||||0|01|01||01|18239||");
            sb.AppendLine("Y|11400|11400|0|0|0|0|11400|0|0|0|0|0|11400|0|");
            sb.AppendLine("Z|11400|11400|0|0|0|0|0|0|0|11400|0|0|0|0|0|11400|0|");
            sb.AppendLine("T|3|20171003|20171003||18240|18240|02|100|06|0201|01|||01|SYRINGE & NEEDLE 20G 3ML 10371 [10371 SNG]|||||||||||11|");
            sb.AppendLine("DR|1234567|DR SS TEST|01|MP|01||N||");
            sb.AppendLine("D|01|01|M70.99|Unspecified soft tissue disorder related to use, overuse and pressure,|01|");
            sb.AppendLine("C|N|0|0||500268007||SYRINGE & NEEDLE 20G 3ML 10371 [10371 SNG]|100||1||||0|01|01||01|18240||");
            sb.AppendLine("Y|1100|1100|0|0|0|0|1100|0|0|0|0|0|1100|0|");
            sb.AppendLine("Z|1100|1100|0|0|0|0|0|0|0|1100|0|0|0|0|0|1100|0|");
            sb.AppendLine("T|4|20171003|20171003||18241|18241|02|100|06|0201|01|||01|WEBCOL ALCOHOL SWABS [MED16818 CSM]|||||||||||11|");
            sb.AppendLine("DR|1234567|DR SS TEST|01|MP|01||N||");
            sb.AppendLine("D|01|01|M70.99|Unspecified soft tissue disorder related to use, overuse and pressure,|01|");
            sb.AppendLine("C|N|0|0||496125003||WEBCOL ALCOHOL SWABS [MED16818 CSM]|100||1||||0|01|01||01|18241||");
            sb.AppendLine("Y|60|60|0|0|0|0|60|0|0|0|0|0|60|0|");
            sb.AppendLine("Z|60|60|0|0|0|0|0|0|0|60|0|0|0|0|0|60|0|");
            sb.AppendLine("T|5|20171003|20171003||18242|18242|02|100|06|0201|01|||01|GLOVE  PEHA SOFT P [9421505SML BBR]|||||||||||11|");
            sb.AppendLine("DR|1234567|DR SS TEST|01|MP|01||N||");
            sb.AppendLine("D|01|01|M70.99|Unspecified soft tissue disorder related to use, overuse and pressure,|01|");
            sb.AppendLine("C|N|0|0||429631001||GLOVE  PEHA SOFT P [9421505SML BBR]|100||1||||0|01|01||01|18242||");
            sb.AppendLine("Y|102|102|0|0|0|0|102|0|0|0|0|0|102|0|");
            sb.AppendLine("Z|102|102|0|0|0|0|0|0|0|102|0|0|0|0|0|102|0|");
            sb.AppendLine("T|6|20171003|20171003||18243|18243|02|100|06|0147|01|||01|For an emergency consultation/visit away|||||||||||11|");
            sb.AppendLine("DR|1234567|DR SS TEST|01|MP|01||N||");
            sb.AppendLine("D|01|01|M70.99|Unspecified soft tissue disorder related to use, overuse and pressure,|01|");
            sb.AppendLine("Z|28070|28070|0|0|0|0|0|0|0|28070|0|0|0|0|0|28070|0|");
            sb.AppendLine("F|81332|81332|81332|0|0|0|0||0|81332|0|");
            sb.AppendLine("E|13650|1|81332|");

            return sb.ToString();
        }
    }
}
