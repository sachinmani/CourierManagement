using CourierManagement.Common.Enums;

namespace CourierManagement.Dto
{
    public class ParcelSizeDimensionInfo
    {
        public ParcelSizeDimensionInfo(double maxLength, double maxBreadth, double maxWidth, ParcelSize parcelSize)
        {
            MaxLength = maxLength;
            MaxBreadth = maxBreadth;
            MaxWidth = maxWidth;
            ParcelSize = parcelSize;
        }

        public double MaxLength { get; }

        public double MaxBreadth { get; }

        public double MaxWidth { get; }

        public ParcelSize ParcelSize { get;}
    }
}
