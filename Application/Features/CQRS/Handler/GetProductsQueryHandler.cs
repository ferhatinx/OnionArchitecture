using System.Net.Http.Headers;
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
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, List<ProductDto>>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync();
            var dtos = _mapper.Map<List<ProductDto>>(products);
            return dtos;
        }
    }
}