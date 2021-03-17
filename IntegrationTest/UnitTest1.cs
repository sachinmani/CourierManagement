using System;
using System.Linq;
using CourierManagement.ApplicationService;
using CourierManagement.DomainService;
using CourierManagement.Repository;
using CourierManagement.RequestModels;
using NUnit.Framework;

namespace IntegrationTest
{
    public class CartApplicationServiceIntegrationTest
    {
        private ICartRepository _cartRepository;
        private IFixedPriceSettingsRepository _fixedPriceSettingsRepository;
        private IParcelItemSizeDeterminer _parcelItemSizeDeterminer;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
            _fixedPriceSettingsRepository = new FixedPriceSettingsRepository();
            _parcelItemSizeDeterminer = new ParcelItemSizeDeterminer(new ParcelDimensionRepository());
        }

        [Test]
        public void AddParcelItem_Should_CreateCart_AndParcelItem_WithCorrectSize_And_Price()
        {
            //
            // Arrange
            //
            var sessionId = Guid.NewGuid();
            var cartAppSvc = new CartApplicationService(_cartRepository, _parcelItemSizeDeterminer, _fixedPriceSettingsRepository);
            var item1 = new AddParcelItemRequest
            {
                SessionId = sessionId,
                ItemName = "Test",
                Address = "Test Address 1",
                Breadth = 9,
                Length = 9,
                Width = 9
            };

            var item2 = new AddParcelItemRequest
            {
                SessionId = sessionId,
                ItemName = "Test",
                Address = "Test Address 2",
                Breadth = 19,
                Length = 51,
                Width = 9
            };

            var item3 = new AddParcelItemRequest
            {
                SessionId = sessionId,
                ItemName = "Test",
                Address = "Test Address 3",
                Breadth = 100,
                Length = 10,
                Width = 20
            };

            //
            // Act
            //
            var cartId = cartAppSvc.AddParcelItem(item1);
            cartAppSvc.AddParcelItem(item2);
            cartAppSvc.AddParcelItem(item3);
            var cart = _cartRepository.GetCart(cartId);

            //
            // Assert
            //
            Assert.That(cart.Items.Count == 3);
            Assert.That(cart.TotalCost() == 43);
            Assert.That(cart.Items.First().FixedDeliveryCost == 3);
            Assert.That(cart.Items[2].FixedDeliveryCost == 15);
            Assert.That(cart.Items.Last().FixedDeliveryCost == 25);
        }
    }
}