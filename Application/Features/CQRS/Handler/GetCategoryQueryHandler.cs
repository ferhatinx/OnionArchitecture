using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handler
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQueryRequest, CategoryDto>
    {
        private readonly IRepository<Category> _categoryrepository;
        private readonly IMapper _mapper;

        public GetCategoryQueryHandler(IRepository<Category> categoryrepository, IMapper mapper)
        {
            _categoryrepository = categoryrepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category =await _categoryrepository.GetByFilterAsync(x=>x.Id == request.Id);
            var dtocategory = _mapper.Map<CategoryDto>(category);    
            return dtocategory;
            
            

        }
    }
}