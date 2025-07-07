using System;
using MyShop.Domain.Entities;
using Xunit;

namespace MyShop.Tests.Domain
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateProduct()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Test Product";
            decimal price = 10.5m;
            var description = "Sample description";

            // Act
            var product = new Product(id, name, price, description);

            // Assert
            Assert.Equal(id, product.Id);
            Assert.Equal(name, product.Name);
            Assert.Equal(price, product.Price);
            Assert.Equal(description, product.Description);
        }

        [Fact]
        public void Constructor_EmptyId_ShouldThrowArgumentException()
        {
            // Arrange
            var id = Guid.Empty;
            var name = "Test";
            decimal price = 1m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(id, name, price));
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_InvalidName_ShouldThrowArgumentException(string? invalidName)
        {
            // Arrange
            var id = Guid.NewGuid();
            decimal price = 1m;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(id, invalidName!, price));
        }

        [Fact]
        public void Constructor_NegativePrice_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Test";

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(id, name, -0.01m));
        }

        [Fact]
        public void UpdatePrice_ValidPrice_ShouldUpdatePrice()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Test", 5m);

            // Act
            product.UpdatePrice(15.75m);

            // Assert
            Assert.Equal(15.75m, product.Price);
        }

        [Fact]
        public void UpdatePrice_NegativePrice_ShouldThrowArgumentOutOfRangeException()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Test", 5m);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => product.UpdatePrice(-1m));
        }

        [Fact]
        public void UpdateName_ValidName_ShouldUpdateName()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Test", 5m);

            // Act
            product.UpdateName("New Name");

            // Assert
            Assert.Equal("New Name", product.Name);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void UpdateName_InvalidName_ShouldThrowArgumentException(string? invalidName)
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Test", 5m);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.UpdateName(invalidName!));
        }

        [Fact]
        public void UpdateDescription_ShouldUpdateDescription()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Test", 5m);

            // Act
            product.UpdateDescription("New Description");

            // Assert
            Assert.Equal("New Description", product.Description);
        }
    }
}