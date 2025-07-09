using MyShop.Application.Queries;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;

namespace MyShop.Tests.Application.Queries
{
    public class ListProductsQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnAllProductsAsDto()
        {
            // Arrange
            var fakeProducts = new List<Product>
            {
                new Product(Guid.NewGuid(), "Item 1", 10.0m, "Desc 1"),
                new Product(Guid.NewGuid(), "Item 2", 20.0m, "Desc 2")
            };

            var fakeRepo = new FakeProductRepository(fakeProducts);
            var handler = new ListProductsQueryHandler(fakeRepo);
            var query = new ListProductsQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Contains(result, p => p.Name == "Item 1");
            Assert.Contains(result, p => p.Name == "Item 2");
        }

        private class FakeProductRepository : IProductRepository
        {
            private readonly List<Product> _products;

            public FakeProductRepository(List<Product> products)
            {
                _products = products;
            }

            public Task<IEnumerable<Product>> ListAllAsync()
            {
                return Task.FromResult<IEnumerable<Product>>(_products);
            }

            public Task<Product?> GetByIdAsync(Guid id)
            {
                return Task.FromResult<Product?>(_products.FirstOrDefault(p => p.Id == id));
            }

            public Task<Guid> AddAsync(Product product)
            {
                _products.Add(product);
                return Task.FromResult(product.Id);
            }
        }
    }
}