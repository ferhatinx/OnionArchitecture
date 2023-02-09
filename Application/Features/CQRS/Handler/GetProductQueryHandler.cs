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
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product =await _repository.GetByFilterAsync(x=>x.Id == request.Id);
            var dto = _mapper.Map<ProductDto>(product);
            return dto; 
        }
    }
}