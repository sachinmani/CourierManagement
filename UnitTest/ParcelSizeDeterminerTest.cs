using CourierManagement.Common.Enums;
using CourierManagement.DomainService;
using CourierManagement.Dto;
using CourierManagement.Repository;
using CourierManagement.RequestModels;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class ParcelSizeDeterminerTest
    {
        

        [Test]
        [TestCase(9,9,9, ParcelSize.Small)]
        [TestCase(9.90, 9.99, 9.98, ParcelSize.Small)]
        [TestCase(9.90, 9.99, 10, ParcelSize.Medium)]
        [TestCase(9.90, 9.99, 19.98, ParcelSize.Medium)]
        [TestCase(10, 10, 10, ParcelSize.Medium)]
        [TestCase(14, 20, 30, ParcelSize.Medium)]
        [TestCase(49.99, 49.99, 49.99, ParcelSize.Medium)]
        [TestCase(99.99, 99.99, 49.99, ParcelSize.Large)]
        [TestCase(100, 100, 100, ParcelSize.Xl)]
        public void DetermineParcelSize_Should_Determine_ParcelSize_Correctly(double length, double breadth,
            double width, ParcelSize expectedResult)
        {

            //
            // Arrange
            //
            IParcelItemSizeDeterminer parcelItemSizeDeterminer = new ParcelItemSizeDeterminer(new ParcelDimensionRepository());

            //
            // Act
            //
            var actual = parcelItemSizeDeterminer.DetermineParcelSize(new AddParcelItemDto
            {
                Length = length,
                Breadth = breadth,
                Width = width
            });

            //
            //
            //
            Assert.AreEqual(expectedResult, actual.ParcelSize);
        }
    
    }
}
