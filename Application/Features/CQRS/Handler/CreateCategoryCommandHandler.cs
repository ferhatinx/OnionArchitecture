using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.CQRS.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handler
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest,CategoryCreateDto>
    {
        private readonly IRepository<Category> _categoryrepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> categoryrepository, IMapper mapper)
        {
            _categoryrepository = categoryrepository;
            _mapper = mapper;
        }

        public async Task<CategoryCreateDto> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = new CategoryCreateDto{Definition=request.Definition};
            var data = _mapper.Map<Category>(dto);
            await _categoryrepository.CreateAsync(data);
            return dto;
        }
    }
}