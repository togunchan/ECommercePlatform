using MediatR;
using MyShop.Application.DTOs;
using MyShop.Application.Interfaces;

namespace MyShop.Application.Queries
{
    /// <summary>
    /// Handles retrieving all products.
    /// </summary>
    public class ListProductsQueryHandler : IRequestHandler<ListProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _repository;
        public ListProductsQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.ListAllAsync();

            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description
            });
        }
    }
}