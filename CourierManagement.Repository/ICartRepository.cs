using System;
using CourierManagement.Domain;

namespace CourierManagement.Repository
{
    public interface ICartRepository
    {
        Cart GetCart(Guid cartId);
        void SaveCart(Cart cart);
    }
}