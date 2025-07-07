using System;

namespace MyShop.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string? Description { get; private set; }

        public Product(Guid id, string name, decimal price, string? description = null)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Id cannot be empty.", nameof(id));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than or equal to zero.");

            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Price must be greater than or equal to zero.");

            Price = newPrice;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be null or empty.", nameof(newName));

            Name = newName;
        }

        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
        }
    }
}