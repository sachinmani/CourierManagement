using System;
using System.Collections.Generic;
using System.Linq;
using CourierManagement.Common.Enums;
using CourierManagement.RequestModels;

namespace CourierManagement.Domain
{
    public class Cart
    {
        public Cart(Guid cartId)
        {
            CartId = cartId;
            Items = new List<ParcelItem>();
        }
        public Guid CartId { get; }

        public List<ParcelItem> Items { get; }

        public static Cart Create(Guid sessionId)
        {
            return new Cart(sessionId);
        }

        public Cart AddItemToCart(AddParcelItemRequest request, ParcelSize size, decimal cost)
        {
            var parcel = ParcelItem.Create(request, size, cost);
            Items.Add(parcel);
            return this;
        }

        public decimal TotalCost()
        {
            return Items.Sum(i => i.FixedDeliveryCost);
        }
    }
}
