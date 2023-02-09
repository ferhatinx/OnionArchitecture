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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, ProductCreateDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductCreateDto> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = new ProductCreateDto()
            {
                Name=request.Name,
                Price=request.Price,
                Stock=request.Stock,
                CategoryId=request.CategoryId
                
            };
            var createddata = _mapper.Map<Product>(dto);
            await _repository.CreateAsync(createddata);
            return dto;
        }
    }
}