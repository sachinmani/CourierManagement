using System;
using System.Linq;
using CourierManagement.ApplicationService;
using CourierManagement.Common.Enums;
using CourierManagement.DomainService;
using CourierManagement.Repository;
using CourierManagement.RequestModels;
using Moq;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class CartApplicationServiceTest
    {
        private Mock<IParcelItemSizeDeterminer> _parcelDimensionDeterminerMock;

        private CartRepository _cartRepository;

        [SetUp]
        public void Setup()
        {
            _parcelDimensionDeterminerMock = new Mock<IParcelItemSizeDeterminer>();
            _parcelDimensionDeterminerMock.Setup(m => m.DetermineParcelSize(It.IsAny<AddParcelItemRequest>()))
                .Returns(ParcelSize.Small);
            _cartRepository = new CartRepository();
        }

        [Test]
        public void AddParcelItem_Should_Successfully_CreateACart_And_AddItemsToIt()
        {
            //
            // Arrange
            //
            var cartAppSvc = new CartApplicationService(new CartRepository(), _parcelDimensionDeterminerMock.Object, new FixedPriceSettingsRepository());

            //
            // Act
            //
            var cartId = cartAppSvc.AddParcelItem(new AddParcelItemRequest
            {
                SessionId = Guid.NewGuid(),
                ItemName = "Test",
                Address = "Test Address 1",
                Breadth = 9,
                Length = 9,
                Width = 9
            });
            var cart = _cartRepository.GetCart(cartId);

            //
            // Assert
            //
            Assert.That(cart.Items.Count == 1);
            Assert.That(cart.TotalCost() == 3);
            Assert.That(cart.Items.First().ItemName == "Test");
            Assert.That(cart.Items.First().Address == "Test Address 1");
            Assert.That(cart.Items.First().FixedDeliveryCost == 3);
        }

        [Test]
        public void AddParcelItem_Should_Successfully_CreateACart_And_AddMultipleItemsToIt_And_TotalCorrect()
        {
            //
            // Arrange
            //
            var sessionId = Guid.NewGuid();
            var cartAppSvc = new CartApplicationService(_cartRepository, _parcelDimensionDeterminerMock.Object, new FixedPriceSettingsRepository());
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
                Breadth = 9,
                Length = 9,
                Width = 9
            };

            var item3 = new AddParcelItemRequest
            {
                SessionId = sessionId,
                ItemName = "Test",
                Address = "Test Address 3",
                Breadth = 9,
                Length = 9,
                Width = 9
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
            Assert.That(cart.TotalCost() == 9);
        }

    }
}
