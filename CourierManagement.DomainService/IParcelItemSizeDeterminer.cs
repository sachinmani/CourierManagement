using CourierManagement.Common.Enums;
using CourierManagement.RequestModels;

namespace CourierManagement.DomainService
{
    public interface IParcelItemSizeDeterminer
    {
        ParcelSize DetermineParcelSize(AddParcelItemRequest addParcelItemRequest);
    }
}