using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;

namespace MyShop.Application.Queries
{
    /// <summary>
    /// Handles retrieving a product by its Id.
    /// </summary>
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _reposityory;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _reposityory = repository;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _reposityory.GetByIdAsync(request.Id);

            if (product is null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };
        }
    }
}