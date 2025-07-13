using MediatR;
using System;

namespace MyShop.Application.Commands
{
    ///<summary>
    /// Command to request deletion of a products by its Id
    /// </summary>
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; }
        public DeleteProductCommand(Guid id)
        {
            Id = id;
        }
    }
}