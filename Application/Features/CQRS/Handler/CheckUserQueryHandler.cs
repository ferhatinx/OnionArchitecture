using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Features.CQRS.Queries;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handler
{
    public class CheckUserQueryHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto>
    {
        private readonly IRepository<AppUser> _userepository;
        private readonly IRepository<AppRole> _rolerepository;

        public CheckUserQueryHandler(IRepository<AppUser> userepository, IRepository<AppRole> rolerepository)
        {
            _userepository = userepository;
            _rolerepository = rolerepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {
            var dto = new CheckUserResponseDto();
            var user =await _userepository.GetByFilterAsync(x=>x.Username == request.Username && x.Password == request.Password);
            if (user==null)
                dto.IsExist = false;
            else
            {
                var role =await _rolerepository.GetByFilterAsync(x=>x.Id ==user.AppRoleId);
                if(role!= null)
                {
                    dto.Username = user.Username;
                    dto.Role = role.Definition;
                    dto.IsExist=true;
                    dto.Id = user.Id;
                }
                
                                    
            }
            return dto;

            
            
        }
    }
}