using System;
using System.Collections.Generic;
using CourierManagement.Domain;

namespace CourierManagement.Repository
{
    public class CartRepository : ICartRepository
    {
        private static Dictionary<Guid, Cart> _cartBag = new Dictionary<Guid, Cart>();

        public Cart GetCart(Guid cartId)
        {
            if (_cartBag.ContainsKey(cartId)) return _cartBag[cartId];
            return null;
        }

        public void SaveCart(Cart cart)
        {
            _cartBag[cart.CartId] = cart;
        }
    }
}
