using System;
using CourierManagement.Common.Enums;
using CourierManagement.RequestModels;

namespace CourierManagement.Domain
{
    /// <summary>
    /// Represent the individual parcel
    /// </summary>

    public class ParcelItem
    {
        public ParcelItem()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }

        public string ItemName { get; private set; }

        public ParcelSize Size { get; private set; }

        public string Address { get; private set; }

        public decimal FixedDeliveryCost { get; private set; }

        public static ParcelItem Create(AddParcelItemRequest request, ParcelSize size, decimal cost)
        {
            return new ParcelItem
            {
                Size = size,
                Address = request.Address,
                ItemName = request.ItemName,
                FixedDeliveryCost = cost
            };
        }
    }

    
}
