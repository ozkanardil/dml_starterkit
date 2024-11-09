using FluentValidation;

namespace DmlStarterkit.Application.Features.UserRole.Command
{
    public class CreateUserRoleCommandValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleCommandValidator()
        {
            RuleFor(x => x.userEmailAdd)
                .NotEmpty().WithMessage("E-mail field is mandatory.")
                .EmailAddress().WithMessage("E-mail address is not in a valid format.");

            RuleFor(x => x.userRoleIdAdd).GreaterThan(0).WithMessage("User role Id must be greater than zero.");
        }
    }
}
