using DmlStarterkit.Application.Features.UserRole.Command;
using DmlStarterkit.Application.Features.UserRole.Models;
using DmlStarterkit.Domain.Entities;
using AutoMapper;

namespace DmlStarterkit.Application.Features.UserRole.Profiles
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRoleVEntity, UserRoleResponse>().ReverseMap();
            CreateMap<CreateUserRoleCommand, UserRoleEntity>().ReverseMap();
        }
    }
}
