using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
             var updatedentity = await _repository.GetByIdAsync(request.Id);
             if (updatedentity != null)
             {
                updatedentity.Name = request.Name;
                updatedentity.Price=request.Price;
                updatedentity.Stock=request.Stock;
                updatedentity.CategoryId = request.CategoryId;
                await _repository.CommintAsync();
             }
             return Unit.Value; 
        }
    }
}