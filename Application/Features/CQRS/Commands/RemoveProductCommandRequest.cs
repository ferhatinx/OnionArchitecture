using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Features.CQRS.Commands
{
    public class RemoveProductCommandRequest : IRequest
    {
        public int Id { get; set; }
        public RemoveProductCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}