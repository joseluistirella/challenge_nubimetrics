using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediatR;
using AutoMapper;
using Service.Middlewares;
using Service.Queries;
using Service.Repositories;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUser, User>();
            CreateMap<UpdateUser, User>();
            CreateMap<ListUser, User>();
            
        }
        
        

    }
}
