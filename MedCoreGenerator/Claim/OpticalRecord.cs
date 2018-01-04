using MedCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace MedCore.Claim
{
    public class OpticalRecord : ICreatesCSV
    {
        private const string TYPE = "OP";
        [Display(Name = "Item Number")]
        public string ItemNumber { get; set; }
        [Display(Name = "Frame Supplier Name")]
        public string FrameSupplierName { get; set; }
        [Display(Name = "Frame Model Name")]
        public string FrameModelName { get; set; }
        [Display(Name = "Frame Model Number")]
        public string FrameModelNumber { get; set; }
        [Display(Name = "Frame Size")]
        public string FrameSize { get; set; }
        public Eye Eye { get; set; }
        [Display(Name = "Lens Prescription Sphere")]
        public string LensPrescriptionSphere { get; set; }
        [Display(Name = "Lens Prescription Cylinder")]
        public string LensPrescriptionCylinder { get; set; }
        [Display(Name = "Lens Prescription Axis")]
        public string LensPrescriptionAxis { get; set; }
        [Display(Name = "Lens Prescription Reading Additions")]
        public string LensPrescriptionReadingAdditions { get; set; }
        [Display(Name = "Lens Prescription Prism")]
        public string LensPrescriptionPrism { get; set; }
        [Display(Name = "Lens Prescription Base")]
        public string LensPrescriptionBase { get; set; }
        [Display(Name = "Tint Density")]
        public string TintDensity { get; set; }
        public string Description { get; set; }

        public string GetCSV()
        {
            return $"{TYPE}|{ItemNumber}|{FrameSupplierName}|{FrameModelName}|{FrameModelNumber}|{FrameSize}|{Eye}|{LensPrescriptionSphere}|{LensPrescriptionCylinder}|{LensPrescriptionAxis}|{LensPrescriptionReadingAdditions}|{LensPrescriptionPrism}|{LensPrescriptionBase}|{TintDensity}|{Description}|";
        }
    }
}
