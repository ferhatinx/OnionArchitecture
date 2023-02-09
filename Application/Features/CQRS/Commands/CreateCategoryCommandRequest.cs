using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using MediatR;

namespace Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest<CategoryCreateDto>
    {
        public string? Definition { get; set; }
    }
}