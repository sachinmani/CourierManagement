using System;
using CourierManagement.Common.Enums;
using CourierManagement.Dto;
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

        public decimal ExcessKg { get; private set; }

        public decimal ExcessKgCost { get; private set; }

        public static ParcelItem Create(AddParcelItemDto request, ParcelSizeDimensionPriceInfo dimensionPriceInfo, decimal cost)
        {
            return new ParcelItem
            {
                Size = dimensionPriceInfo.ParcelSize,
                Address = request.Address,
                ItemName = request.ItemName,
                FixedDeliveryCost = cost,
                ExcessKg = request.ExcessInKg,
                ExcessKgCost = request.ExcessInKg * dimensionPriceInfo.CostPerExtraKg
            };
        }
    }

    
}
