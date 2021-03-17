using System;
using CourierManagement.Common.Enums;
using CourierManagement.Repository;
using CourierManagement.RequestModels;

namespace CourierManagement.DomainService
{
    public class ParcelItemSizeDeterminer : IParcelItemSizeDeterminer
    {
        private readonly IParcelDimensionRepository _parcelDimensionRepository;

        public ParcelItemSizeDeterminer(IParcelDimensionRepository parcelDimensionRepository)
        {
            _parcelDimensionRepository = parcelDimensionRepository;
        }

        public ParcelSize DetermineParcelSize(AddParcelItemRequest addParcelItemRequest)
        {
            ParcelSize parcelSize = ParcelSize.Xl;
            var dimensions = _parcelDimensionRepository.GetDimensions();
            foreach (var parcelSizeDimensionInfo in dimensions)
            {
                if (Math.Round(addParcelItemRequest.Length, 2) <= parcelSizeDimensionInfo.MaxLength &&
                    Math.Round(addParcelItemRequest.Breadth, 2) <= parcelSizeDimensionInfo.MaxBreadth &&
                    Math.Round(addParcelItemRequest.Width, 2) <= parcelSizeDimensionInfo.MaxWidth)
                {
                    parcelSize = parcelSizeDimensionInfo.ParcelSize;
                    break;
                }
            }

            return parcelSize;
        }
    }
}
