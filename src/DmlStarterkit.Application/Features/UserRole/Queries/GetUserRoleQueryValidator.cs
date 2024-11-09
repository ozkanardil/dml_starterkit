using FluentValidation;

namespace DmlStarterkit.Application.Features.UserRole.Queries
{
    public class GetUserRoleQueryValidator : AbstractValidator<GetUserRoleQuery>
    {
        public GetUserRoleQueryValidator()
        {
            RuleFor(x => x.userEmail)
                .NotEmpty().WithMessage("E-mail field is mandatory.")
                .EmailAddress().WithMessage("E-mail address is not in a valid format.");
        }
    }
}
