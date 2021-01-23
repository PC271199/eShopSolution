using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.System.Users
{
    public class LoginRequestValidator: AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("user name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("password is required")
                .MinimumLength(6).WithMessage("password is at least 6 characters");

        }
    }
}
