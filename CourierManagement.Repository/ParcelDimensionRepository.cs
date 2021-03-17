using System.Collections.Generic;
using System.Linq;
using CourierManagement.Common.Enums;
using CourierManagement.Dto;

namespace CourierManagement.Repository
{
    public class ParcelDimensionRepository : IParcelDimensionRepository
    {

        private readonly Dictionary<ParcelSize, ParcelSizeDimensionInfo> _parcelSizeDimensionInfos = new Dictionary<ParcelSize, ParcelSizeDimensionInfo>
        {
            { ParcelSize.Small, new ParcelSizeDimensionInfo(9.99, 9.99, 9.99, ParcelSize.Small)},
            { ParcelSize.Medium, new ParcelSizeDimensionInfo(49.99, 49.99, 49.99, ParcelSize.Medium)},
            { ParcelSize.Large, new ParcelSizeDimensionInfo(99.99, 99.99, 99.99, ParcelSize.Large)}
        };

        public List<ParcelSizeDimensionInfo> GetDimensions()
        {
            return _parcelSizeDimensionInfos.Values.ToList();
        }
    }
}
