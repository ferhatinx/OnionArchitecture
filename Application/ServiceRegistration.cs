﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Mappings;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class ServiceRegistration
    {
       
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(opt => {
                opt.AddProfiles(new List<Profile>
                {
                        new CategoryProfile(),
                        new ProductProfile(),
                        new AppUserProfile()

                });
            
            
            });
        }
    }
}
