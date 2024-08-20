using DmlStarterkit.Application.Features.Role.Models;
using DmlStarterkit.Domain.Entities;
using AutoMapper;

namespace DmlStarterkit.Application.Features.Role.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleEntity, RoleResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
