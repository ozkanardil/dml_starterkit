using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DmlStarterkit.Application.Features.Auth.Constants;
using DmlStarterkit.Application.Features.Auth.Models;
using DmlStarterkit.Infrastructure.Results;
using DmlStarterkit.Persistance.Context;
using DmlStarterkit.Infrastructure.Security.JwtToken;
using DmlStarterkit.Infrastructure.Security.Hashing;
using DmlStarterkit.Application.Features.UserRole.Models;

namespace DmlStarterkit.Application.Features.Auth.Queries
{
    public class GetLoginQuery : IRequest<IRequestDataResult<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class GetLoginQueryHandler : IRequestHandler<GetLoginQuery, IRequestDataResult<LoginResponse>>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private ITokenHelper _tokenHelper;

        public GetLoginQueryHandler(IMapper mapper, DatabaseContext context, ITokenHelper tokenHelper)
        {
            _mapper = mapper;
            _context = context;
            _tokenHelper = tokenHelper;
        }
        public async Task<IRequestDataResult<LoginResponse>> Handle(GetLoginQuery request, CancellationToken cancellationToken)
        {
            var userToCheck = _context.User.FirstOrDefault(u => u.Email == request.Email);

            if (userToCheck == null || userToCheck.Status == 3)
                return new ErrorRequestDataResult<LoginResponse>(null, AuthMessages.UserNotFound);

            if (userToCheck.Status == 0)
                return new ErrorRequestDataResult<LoginResponse>(null, AuthMessages.UserNotApproved);

            if (!HashingHelper.VerifyPasswordHash(request.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
                return new ErrorRequestDataResult<LoginResponse>(null, AuthMessages.UserLoginErr);

            var userClaims = await _context.UserRole.Where(ur => ur.UserId == userToCheck.Id).Include(r => r.Role).ToListAsync();
            var claims = _mapper.Map<List<UserRoleDto>>(userClaims);

            var token = _tokenHelper.CreateToken(userToCheck, claims);

            var userVClaims = await _context.UserRoleV.Where(ur => ur.UserId == userToCheck.Id).ToListAsync();
            foreach (var item in userVClaims)
            {
                item.OperationName = item.OperationName.Trim();
            }

            TokenResult tokenResult = new TokenResult();
            tokenResult.Token = token.Token;
            tokenResult.Expiration = token.Expiration;
            tokenResult.refreshToken = "";

            LoginResponse result = new LoginResponse();
            result.Token = tokenResult;
            result.Roles = _mapper.Map<List<UserRoleResponse>>(userVClaims);

            if (token == null)
                return new ErrorRequestDataResult<LoginResponse>(result, AuthMessages.UserLoginErr);

            return new SuccessRequestDataResult<LoginResponse>(result, AuthMessages.UserLoginOk);
        }
    }
}
