using NUnit.Framework;

namespace LaptopDiscount.LaptopDiscoutUnitTests
{
    [TestFixture]
    public class EmployeeDiscountTests
    {
        [Test]
        // PartTime employees receive no discount
        public void CalculateDiscountedPrice_PartTime_NoDiscount()
        {
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartTime,
                Price = 1000m
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(1000m, result, "PartTime employees should not receive a discount.");
        }

        [Test]
        // PartialLoad employees receive a 5% discount
        public void CalculateDiscountedPrice_PartialLoad_5PercentDiscount()
        {
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartialLoad,
                Price = 1000m
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(950m, result, "PartialLoad employees should receive a 5% discount.");
        }

        [Test]
        // FullTime employees receive a 10% discount
        public void CalculateDiscountedPrice_FullTime_10PercentDiscount()
        {
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.FullTime,
                Price = 1000m
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(900m, result, "FullTime employees should receive a 10% discount.");
        }

        [Test]
        // CompanyPurchasing receives a 20% discount
        public void CalculateDiscountedPrice_CompanyPurchasing_20PercentDiscount()
        {
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.CompanyPurchasing,
                Price = 1000m
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(800m, result, "CompanyPurchasing should receive a 20% discount.");
        }

        [Test]
        // Check lowest price range
        public void CalculateDiscountedPrice_ZeroPrice()
        {
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.FullTime,
                Price = 0m
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(0m, result, "The price of 0 should return a discounted price of 0 regardless of the employee type.");
        }

        [Test]
        // check highest price 10000
        public void CalculateDiscountedPrice_HighPrice()
        {
            // Arrange
            var employeeDiscount = new EmployeeDiscount
            {
                EmployeeType = EmployeeType.PartialLoad,
                Price = 10000m
            };

            // Act
            var result = employeeDiscount.CalculateDiscountedPrice();

            // Assert
            Assert.AreEqual(9500m, result, "PartialLoad employees should receive a 5% discount on a high price.");
        }
    }
}