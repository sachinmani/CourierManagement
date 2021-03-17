using CourierManagement.Dto;

namespace CourierManagement.DomainService
{
    public interface IParcelItemSizeDeterminer
    {
        ParcelSizeDimensionPriceInfo DetermineParcelSize(AddParcelItemDto addParcelItemRequest);
        decimal DetermineParcelWeightInKg(AddParcelItemDto parcelItemRequest);
    }
}