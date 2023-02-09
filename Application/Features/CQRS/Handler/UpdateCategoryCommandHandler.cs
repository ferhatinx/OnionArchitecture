using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Commands;
using MediatR;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Features.CQRS.Handler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _categoryrepository;

        public UpdateCategoryCommandHandler(IRepository<Category> categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
             var updatedentity = await _categoryrepository.GetByIdAsync(request.Id);
             if (updatedentity != null)
             {
                updatedentity.Definition = request.Definiton;
                await _categoryrepository.UpdateAsync(updatedentity);
             }
             return Unit.Value; 
                
        }
    }
}