using CourierManagement.Common.Enums;

namespace CourierManagement.Repository
{
    public interface IFixedPriceSettingsRepository
    {
        decimal GetPriceForParcelItem(ParcelSize parcelSize);
    }
}