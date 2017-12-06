using MedCore.Enums;

namespace MedCore.Claim
{
    public class OpticalRecord
    {
        private const string TYPE = "OP";
        public string ItemNumber { get; set; }
        public string FrameSupplierName { get; set; }
        public string FrameModelName { get; set; }
        public string FrameModelNumber { get; set; }
        public string FrameSize { get; set; }
        public Eye Eye { get; set; }
        public string LensPrescriptionSphere { get; set; }
        public string LensPrescriptionCylinder { get; set; }
        public string LensPrescriptionAxis { get; set; }
        public string LensPrescriptionReadingAdditions { get; set; }
        public string LensPrescriptionPrism { get; set; }
        public string LensPrescriptionBase { get; set; }
        public string TintDensity { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{TYPE}|{ItemNumber}|{FrameSupplierName}|{FrameModelName}|{FrameModelNumber}|{FrameSize}|{Eye}|{LensPrescriptionSphere}|{LensPrescriptionCylinder}|{LensPrescriptionAxis}|{LensPrescriptionReadingAdditions}|{LensPrescriptionPrism}|{LensPrescriptionBase}|{TintDensity}|{Description}|";
        }
    }
}
