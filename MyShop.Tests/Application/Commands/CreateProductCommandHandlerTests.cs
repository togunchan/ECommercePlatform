using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using MyShop.Application.Commands;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;

namespace MyShop.Tests.Application.Commands
{
    public class CreateProductCommandHandlerTests
    {
        private class FakeProductRepository : IProductRepository
        {
            public Task<Guid> AddAsync(Product product)
            {
                return Task.FromResult(product.Id);
            }

            public Task<Product?> GetByIdAsync(Guid id) => Task.FromResult<Product?>(null);
            public Task<IEnumerable<Product>> ListAllAsync() => Task.FromResult<IEnumerable<Product>>(Array.Empty<Product>());
        }


        [Fact]
        public async Task Handle_ValidCommand_ReturnsNewProductId()
        {
            // Arrange
            var repository = new FakeProductRepository();
            var handler = new CreateProductCommandHandler(repository);
            var command = new CreateProductCommand("Test Product", 99.99m, "Test Description");

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotEqual(Guid.Empty, result);
        }
    }
}