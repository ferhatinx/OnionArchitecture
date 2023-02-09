using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.CQRS.Queries;
using MediatR;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using AutoMapper;

namespace Application.Features.CQRS.Handler
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryDto>>
    {
        private readonly IRepository<Category> _categoryrepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IRepository<Category> categoryrepository, IMapper mapper)
        {
            _categoryrepository = categoryrepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories =await _categoryrepository.GetAllAsync();
            var dto = _mapper.Map<List<CategoryDto>>(categories);
            return dto;
        }       
    }
}