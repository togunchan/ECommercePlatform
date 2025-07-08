using MediatR;
using System;

namespace MyShop.Application.Commands
{
    /// <summary>
    /// Command to request creation of a new product.
    /// </summary>
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}