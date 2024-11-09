using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmlStarterkit.Application.Features.Auth.Queries
{
    public class GetLoginQueryValidator : AbstractValidator<GetLoginQuery>
    {
        public GetLoginQueryValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail address is required")
                .EmailAddress().WithMessage("Not a valid e-mail address");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("{PropertyName} is empty")
                .Length(4, 8).WithMessage("Password must be at least 4 and maximum 8 characters");
        }
    }
}
