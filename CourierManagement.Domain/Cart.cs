using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ChosenDeliveryType = DeliveryType.Normal;
        }
        public Guid CartId { get; }

        public List<ParcelItem> Items { get; }

        public DeliveryType ChosenDeliveryType { get; private set; }

        private decimal DeliveryCost
        {
            get
            {
                switch (ChosenDeliveryType)
                {
                    case DeliveryType.Speed:
                        return TotalItemCost() * 2;
                    case DeliveryType.Normal:
                        return 0;
                    default:
                        throw new InvalidEnumArgumentException("Invalid delivery type");

                }
            }
        }

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

        public void UpdateDeliveryType(DeliveryType deliveryType)
        {

            ChosenDeliveryType = deliveryType;
            
        }

        public decimal GetDeliveryCost()
        {
            return DeliveryCost;
        }

        public decimal TotalItemCost()
        {
            return Items.Sum(i => i.FixedDeliveryCost);
        }
    }
}
