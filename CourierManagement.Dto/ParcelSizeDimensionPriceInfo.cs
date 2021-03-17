using CourierManagement.Common.Enums;

namespace CourierManagement.Dto
{
    public class ParcelSizeDimensionPriceInfo
    {
        public ParcelSizeDimensionPriceInfo(double maxLength, double maxBreadth, double maxWidth, ParcelSize parcelSize, int maxWeight, decimal costPerExtraKg)
        {
            MaxLength = maxLength;
            MaxBreadth = maxBreadth;
            MaxWidth = maxWidth;
            ParcelSize = parcelSize;
            MaxWeight = maxWeight;
            CostPerExtraKg = costPerExtraKg;
        }

        public double MaxLength { get; }

        public double MaxBreadth { get; }

        public double MaxWidth { get; }

        public ParcelSize ParcelSize { get;}

        public int MaxWeight { get; }

        public decimal CostPerExtraKg { get; }
    }
}
