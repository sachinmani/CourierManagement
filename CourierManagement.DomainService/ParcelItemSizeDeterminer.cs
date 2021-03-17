using System;
using System.Linq;
using CourierManagement.Common.Enums;
using CourierManagement.Dto;
using CourierManagement.Repository;

namespace CourierManagement.DomainService
{
    public class ParcelItemSizeDeterminer : IParcelItemSizeDeterminer
    {
        private readonly IParcelDimensionRepository _parcelDimensionRepository;

        public ParcelItemSizeDeterminer(IParcelDimensionRepository parcelDimensionRepository)
        {
            _parcelDimensionRepository = parcelDimensionRepository;
        }

        public ParcelSizeDimensionPriceInfo DetermineParcelSize(AddParcelItemDto addParcelItemRequest)
        {
            var dimensions = _parcelDimensionRepository.GetDimensions();

            ParcelSizeDimensionPriceInfo parcelSize = dimensions.First(d => d.ParcelSize == ParcelSize.Xl);
            foreach (var parcelSizeDimensionInfo in dimensions)
            {
                if (Math.Round(addParcelItemRequest.Length, 2) <= parcelSizeDimensionInfo.MaxLength &&
                    Math.Round(addParcelItemRequest.Breadth, 2) <= parcelSizeDimensionInfo.MaxBreadth &&
                    Math.Round(addParcelItemRequest.Width, 2) <= parcelSizeDimensionInfo.MaxWidth)
                {
                    parcelSize = parcelSizeDimensionInfo;
                    break;
                }
            }

            return parcelSize;
        }

        public decimal DetermineParcelWeightInKg(AddParcelItemDto parcelItemRequest)
        {
            return new Random(1).Next(1, 10);
        }
    }
}
