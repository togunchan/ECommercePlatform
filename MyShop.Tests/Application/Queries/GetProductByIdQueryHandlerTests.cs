using MyShop.Application.DTOs;
using MyShop.Application.Queries;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;

namespace MyShop.Tests.Application.Queries
{
    public class GetProductByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnProductDto_WhenProductExists()
        {
            // Arrange
            var productId = Guid.NewGuid();

            var fakeRepo = new FakeProductRepository(productId);
            var handler = new GetProductByIdQueryHandler(fakeRepo);
            var query = new GetProductByIdQuery(productId);

            // Act
            ProductDto? result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(productId, result!.Id);
            Assert.Equal("Test Product", result.Name);
            Assert.Equal(42.5m, result.Price);
        }

        // Fake repository for testing
        private class FakeProductRepository : IProductRepository
        {
            private readonly List<Product> _products = new();
            private readonly Guid _id;

            public FakeProductRepository(Guid id)
            {
                _id = id;
            }

            public Task<Product?> GetByIdAsync(Guid id)
            {
                if (id != _id)
                    return Task.FromResult<Product?>(null);

                var product = new Product(_id, "Test Product", 42.5m, "For testing");
                return Task.FromResult<Product?>(product);
            }

            public Task<Guid> AddAsync(Product product)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<Product>> ListAllAsync()
            {
                return Task.FromResult<IEnumerable<Product>>(new List<Product>());

            }
            public Task UpdateAsync(Product product)
            {
                var index = _products.FindIndex(p => p.Id == product.Id);
                if (index != -1)
                {
                    _products[index] = product;
                }
                return Task.CompletedTask;
            }
        }
    }
}