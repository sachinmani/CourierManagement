using System.Collections.Generic;
using System.Linq;
using CourierManagement.Common.Enums;
using CourierManagement.Dto;

namespace CourierManagement.Repository
{
    public class ParcelDimensionRepository : IParcelDimensionRepository
    {

        private readonly Dictionary<ParcelSize, ParcelSizeDimensionPriceInfo> _parcelSizeDimensionInfos = new Dictionary<ParcelSize, ParcelSizeDimensionPriceInfo>
        {
            { ParcelSize.Small, new ParcelSizeDimensionPriceInfo(9.99, 9.99, 9.99, ParcelSize.Small, 1, 2)},
            { ParcelSize.Medium, new ParcelSizeDimensionPriceInfo(49.99, 49.99, 49.99, ParcelSize.Medium, 3, 2)},
            { ParcelSize.Large, new ParcelSizeDimensionPriceInfo(99.99, 99.99, 99.99, ParcelSize.Large, 6, 2)},
            { ParcelSize.Xl, new ParcelSizeDimensionPriceInfo(5000, 5000, 5000, ParcelSize.Xl, 10, 2)}
        };

        public List<ParcelSizeDimensionPriceInfo> GetDimensions()
        {
            return _parcelSizeDimensionInfos.Values.ToList();
        }
    }
}
