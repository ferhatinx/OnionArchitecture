using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using MediatR;

namespace Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest : IRequest<ProductDto>
    {
        public GetProductQueryRequest(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}