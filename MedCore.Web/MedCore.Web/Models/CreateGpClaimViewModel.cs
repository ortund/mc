using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedCore.Web.Models
{
    public class CreateGpClaimViewModel : GpClaim
    {
        public IEnumerable<SelectListItem> Titles { get; set; }
        public IEnumerable<SelectListItem> SchemeTypes { get; set; }
        public IEnumerable<SelectListItem> PatientRelationCodes { get; set; }
        public IEnumerable<SelectListItem> PatientTypes { get; set; }
        public IEnumerable<SelectListItem> DoctorTypes { get; set; }
        public IEnumerable<SelectListItem> DiagnosisCodeTypes { get; set; }
        public IEnumerable<SelectListItem> ExtendedDiagnoses { get; set; }
        public IEnumerable<SelectListItem> TreatmentTypes { get; set; }
        public IEnumerable<SelectListItem> UnitTypes { get; set; }
        public IEnumerable<SelectListItem> TariffCodeTypes { get; set; }
        public IEnumerable<SelectListItem> TreatmentModifierType { get; set; }
        public IEnumerable<SelectListItem> ServiceTariffs { get; set; }
        public IEnumerable<SelectListItem> BenefitTypes { get; set; }
        public IEnumerable<SelectListItem> HospitalTariffTypes { get; set; }
        public IEnumerable<SelectListItem> ResubmissionReasons { get; set; }
    }
}