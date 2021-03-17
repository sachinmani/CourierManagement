using System.Collections.Generic;
using CourierManagement.Dto;

namespace CourierManagement.Repository
{
    public interface IParcelDimensionRepository
    {
        List<ParcelSizeDimensionPriceInfo> GetDimensions();
    }
}