using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Enums;
using Application.Features.CQRS.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handler
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, CreatedUserDto>
    {
        private readonly IRepository<AppUser> _repository;
        private readonly IMapper _mapper;
        public RegisterUserCommandHandler(IRepository<AppUser> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedUserDto> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
          var data = await _repository.CreateAsync(new AppUser
           {
                AppRoleId = (int)RoleType.Member,
                Username = request.Username,
                Password=request.Password
           });
           return _mapper.Map<CreatedUserDto>(data);
        }
    }
}