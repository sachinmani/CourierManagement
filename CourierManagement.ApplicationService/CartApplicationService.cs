using System;
using CourierManagement.Domain;
using CourierManagement.DomainService;
using CourierManagement.Repository;
using CourierManagement.RequestModels;

namespace CourierManagement.ApplicationService
{
    public class CartApplicationService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IParcelItemSizeDeterminer _parcelItemDimensionCalculator;
        private readonly IFixedPriceSettingsRepository _fixedPriceSettingsRepository;

        public CartApplicationService(ICartRepository cartRepository, IParcelItemSizeDeterminer parcelItemDimensionCalculator, IFixedPriceSettingsRepository fixedPriceSettingsRepository)
        {
            _cartRepository = cartRepository;
            _parcelItemDimensionCalculator = parcelItemDimensionCalculator;
            _fixedPriceSettingsRepository = fixedPriceSettingsRepository;
        }

        public Guid AddParcelItem(AddParcelItemRequest parcelItemRequest)
        {
            var cart = _cartRepository.GetCart(parcelItemRequest.SessionId) ?? Cart.Create(parcelItemRequest.SessionId);
            _cartRepository.SaveCart(cart);
            //Determine Parcel Size and price
            var size = _parcelItemDimensionCalculator.DetermineParcelSize(parcelItemRequest);
            var price = _fixedPriceSettingsRepository.GetPriceForParcelItem(size);
            cart.AddItemToCart(parcelItemRequest, size, price);
            return cart.CartId;
        }
    }
}
