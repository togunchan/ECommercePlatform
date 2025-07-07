using System;

namespace MyShop.Application.DTOs
{
    public class ProductDto
    {
        /// <summary>
        /// The unique identifier of the product.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the product.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// The price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Optional description.
        /// </summary>
        public string? Description { get; set; }
    }
}