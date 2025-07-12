using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Application.Interfaces;
using MyShop.Domain.Entities;
using System.Reflection.Metadata.Ecma335;

namespace MyShop.Application.Commands
{
    /// <summary>
    /// Handles the update of an existing product.
    /// </summary>
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _repository.GetByIdAsync(request.Id);
            if (existingProduct is null)
                return false;

            existingProduct.Name = request.Name;
            existingProduct.Price = request.Price;
            existingProduct.Description = request.Description;

            await _repository.UpdateAsync(existingProduct);

            return true;
        }
    }

}