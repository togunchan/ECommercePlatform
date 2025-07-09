using MediatR;
using MyShop.Application.DTOs;

namespace MyShop.Application.Queries
{
    /// <summary>
    /// Query to retrieve all products.
    /// </summary>
    public class ListProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
    }
}