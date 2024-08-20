using AutoMapper;
using MediatR;
using DmlStarterkit.Application.Features.Auth.Constants;
using DmlStarterkit.Application.Features.Auth.Rules;
using DmlStarterkit.Infrastructure.Results;
using DmlStarterkit.Persistance.Context;

namespace DmlStarterkit.Application.Features.Auth.Commands
{
    public class CreateUserCommand : IRequest<IRequestResult>
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IRequestResult>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IMapper mapper,
                                        DatabaseContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<IRequestResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            return new SuccessRequestResult(AuthMessages.UserCreateSuccess);
        }

    }
}
