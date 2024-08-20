using DmlStarterkit.Application.Features.Auth.Constants;
using DmlStarterkit.Application.Features.Auth.Commands;
using DmlStarterkit.Infrastructure.Errors.Errors;

namespace DmlStarterkit.Application.Features.Auth.Rules
{
    public static class GuardCreateUser
    {
        public static GuardClause Against(CreateUserCommand request)
        {
            return new GuardClause(request);
        }
    }

    public class GuardClause
    {
        private readonly CreateUserCommand _request;

        public GuardClause(CreateUserCommand request)
        {
            _request = request;
        }
      
        public GuardClause FieldsMustNotBeNull()
        {

            if (_request.email == null || _request.firstName == null || _request.lastName == null || _request.password == null)
            {
                throw new CustomException(AuthMessages.RequestCanNotBeNull, false);
            }

            return this;
        }

        // Add more methods here for other guard clauses...

        public void KeepGoing()
        {

        }
    }
}
