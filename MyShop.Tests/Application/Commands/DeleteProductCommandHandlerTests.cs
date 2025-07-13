using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using MyShop.Application.Commands;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;

namespace MyShop.Tests.Application.Commands
{
    public class DeleteProductCommandHandlerTests
    {
        private class FakeProductRepository : IProductRepository
        {
            public List<Product> _products = new();

            public Task<Guid> AddAsync(Product product)
            {
                _products.Add(product);
                return Task.FromResult(product.Id);
            }

            public Task<Product?> GetByIdAsync(Guid id)
            {
                var product = _products.Find(p => p.Id == id);
                return Task.FromResult<Product?>(product);
            }

            public Task<IEnumerable<Product>> ListAllAsync() => Task.FromResult<IEnumerable<Product>>(_products);

            public Task UpdateAsync(Product product)
            {
                var index = _products.FindIndex(p => p.Id == product.Id);
                if (index != -1)
                    _products[index] = product;
                return Task.CompletedTask;
            }

            public Task<bool> DeleteAsync(Guid id)
            {
                var removed = _products.RemoveAll(p => p.Id == id) > 0;
                return Task.FromResult(removed);
            }
        }

        [Fact]
        public async Task Handle_ExistingProductId_DeletesProductAndReturnsTrue()
        {
            // Arrange
            var repository = new FakeProductRepository();
            var product = new Product(Guid.NewGuid(), "To be deleted", 10m, "temp");
            await repository.AddAsync(product);

            var handler = new DeleteProductCommandHandler(repository);
            var command = new DeleteProductCommand(product.Id);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            var deleted = await repository.GetByIdAsync(product.Id);
            Assert.Null(deleted);
        }
    }
}