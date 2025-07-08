using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;

namespace MyShop.Application.Commands
{
    /// <summary>
    /// Handles the creation of a new product.
    /// </summary>
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Create domain entity (validates invariants)
            var product = new Product(Guid.NewGuid(), request.Name, request.Price, request.Description);

            // Persist entity and return its Id
            var id = await _repository.AddAsync(product);
            return id;
        }
    }
}