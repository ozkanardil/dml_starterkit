using DmlStarterkit.Application.Features.Auth.Models;
using DmlStarterkit.Application.Features.UserRole.Models;
using DmlStarterkit.Domain.Entities;
using DmlStarterkit.Infrastructure.Security.JwtToken;
using AutoMapper;

namespace DmlStarterkit.Application.Features.Auth.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<UserRoleVEntity, UserRoleResponse>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.operationClaimId, opt => opt.MapFrom(src => src.ClaimId))
                .ForMember(dest => dest.operationName, opt => opt.MapFrom(src => src.OperationName))
                .ReverseMap();

            CreateMap<AccessToken, TokenResult>().ReverseMap();

            CreateMap<UserRoleEntity, RoleEntity>().ReverseMap();

            CreateMap<UserRoleEntity, UserRoleDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Role.Name))
                .ReverseMap();
        }
    }
}
