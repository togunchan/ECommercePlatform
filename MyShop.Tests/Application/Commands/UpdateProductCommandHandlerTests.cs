using MyShop.Application.Commands;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;

namespace MyShop.Tests.Application.Commands
{
    public class UpdateProductCommandHandlerTests
    {
        private class FakeProductRepository : IProductRepository
        {
            private readonly List<Product> _products = new();

            public Task<Guid> AddAsync(Product product)
            {
                _products.Add(product);
                return Task.FromResult(product.Id);
            }

            public Task<Product?> GetByIdAsync(Guid id)
            {
                return Task.FromResult(_products.Find(p => p.Id == id));
            }

            public Task<IEnumerable<Product>> ListAllAsync()
            {
                return Task.FromResult<IEnumerable<Product>>(_products);
            }

            public Task UpdateAsync(Product product)
            {
                var index = _products.FindIndex(p => p.Id == product.Id);
                if (index != -1)
                    _products[index] = product;

                return Task.CompletedTask;
            }
        }

        [Fact]
        public async Task Handle_ValidCommand_UpdatesProduct()
        {
            // Arrange
            var product = new Product(Guid.NewGuid(), "Old Name", 10.0m, "Old Desc");
            var repository = new FakeProductRepository();
            await repository.AddAsync(product);

            var command = new UpdateProductCommand
            (
                product.Id,
                "New Name",
                99.99m,
                "New Desc"
            );

            var handler = new UpdateProductCommandHandler(repository);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            var updated = await repository.GetByIdAsync(product.Id);

            Assert.NotNull(updated);
            Assert.Equal("New Name", updated.Name);
            Assert.Equal(99.99m, updated.Price);
            Assert.Equal("New Desc", updated.Description);
        }
    }
}