using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.CQRS.Commands
{
    public class RemoveCategoryCommandRequest : IRequest
    {
        public RemoveCategoryCommandRequest(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
        
    }
}