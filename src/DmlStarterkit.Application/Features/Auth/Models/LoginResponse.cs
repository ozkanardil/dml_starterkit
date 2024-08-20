using DmlStarterkit.Application.Features.UserRole.Models;
using DmlStarterkit.Infrastructure.Security.JwtToken;

namespace DmlStarterkit.Application.Features.Auth.Models
{
    public class LoginResponse
    {
        public TokenResult Token { get; set; }
        public List<UserRoleResponse> Roles { get; set; }
    }

    public class TokenResult : AccessToken
    {
        public string refreshToken { get; set; }
    }

}
