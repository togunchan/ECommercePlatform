using MediatR;
using MyShop.Application.DTOs;

namespace MyShop.Application.Queries
{
    /// <summary>
    /// Query to retrieve a product by its Id.
    /// </summary>
    public class GetProductByIdQuery : IRequest<ProductDto?>
    {
        public Guid Id { get; set; }
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}