using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using MediatR;

namespace Application.Features.CQRS.Commands
{
    public class CreateProductCommandRequest : IRequest<ProductCreateDto>
    {
        public string? Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }
    }
}