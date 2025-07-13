using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using MyShop.Application.Interfaces;

namespace MyShop.Application.Commands
{
    /// <summary>
    /// Handles deletion of a product.
    /// </summary>
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.Id);
        }
    }
}