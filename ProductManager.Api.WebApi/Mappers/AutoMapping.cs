using AutoMapper;
using ProductManager.Core.Services.Dtos;
using ProductManager.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Api.WebApi.Mappers;

public class AutoMapping: Profile
{
    public AutoMapping()
    {
        CreateMap<ProductDto, Product>().ReverseMap();

        CreateMap<UserDto, User>()
           .ForMember(d => d.Id, o => o.MapFrom(src => src.UserName));

        CreateMap<User, RolDto>()
            .ForMember(d => d.UserName, o => o.MapFrom(src => src.Id))
            .ForMember(d => d.Role, o => o.MapFrom(src => src.Role.Name));
    }
}
