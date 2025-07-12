using MediatR;
using System;

namespace MyShop.Application.Commands
{
    /// <summary>
    /// Command to update an existing product.
    /// </summary>
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public UpdateProductCommand(Guid id, string name, decimal price, string? description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }
    }
}