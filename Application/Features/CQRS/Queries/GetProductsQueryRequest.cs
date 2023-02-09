using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using MediatR;

namespace Application.Features.CQRS.Queries
{
    public class GetProductsQueryRequest : IRequest<List<ProductDto>>
    {
        
    }
}