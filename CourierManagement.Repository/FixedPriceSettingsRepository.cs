using System.Collections.Generic;
using System.ComponentModel;
using CourierManagement.Common.Enums;

namespace CourierManagement.Repository
{
    public class FixedPriceSettingsRepository : IFixedPriceSettingsRepository
    {
        private readonly Dictionary<ParcelSize, decimal> _prices= new Dictionary<ParcelSize, decimal>
        {
            {ParcelSize.Small, 3 },
            {ParcelSize.Medium, 8 },
            { ParcelSize.Large, 15},
            {ParcelSize.Xl, 25 }
        };

        public decimal GetPriceForParcelItem(ParcelSize parcelSize)
        {
            if (_prices.ContainsKey(parcelSize))
            {
                return _prices[parcelSize];
            }
            throw new InvalidEnumArgumentException("Invalid parcel size");
        }
    }
}
