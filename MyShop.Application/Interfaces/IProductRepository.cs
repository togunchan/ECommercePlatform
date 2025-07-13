using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyShop.Domain.Entities;

namespace MyShop.Application.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Adds a new product to the store.
        /// </summary>
        /// <param name="product">The product entity to add.</param>
        /// <returns>The Guid of the created product.</returns>
        Task<Guid> AddAsync(Product product);

        /// <summary>
        /// Retrieves a product by its unique identifier.
        /// </summary>
        /// <param name="id">The Guid of the product.</param>
        /// <returns>The product entity, or null if not found.</returns>
        Task<Product?> GetByIdAsync(Guid id);

        /// <summary>
        /// Lists all products in the store.
        /// </summary>
        /// <returns>A collection of product entities.</returns>
        Task<IEnumerable<Product>> ListAllAsync();

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="product">The updated product entity.</param>
        Task UpdateAsync(Product product);

        /// <summary>
        /// Deletes a product by its Id.
        /// </summary>
        /// <param name="id">The Guid of the product to delete.</param>
        /// <returns>True if deleted, false if not found.</returns>
        Task<bool> DeleteAsync(Guid id);

    }
}