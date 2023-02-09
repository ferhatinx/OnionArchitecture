using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Dtos;

namespace Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            this.Id=id;
        }
    }
}