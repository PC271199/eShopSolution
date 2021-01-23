using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.System.Users
{
    public class RegisterValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("first name is required")
                .MaximumLength(200).WithMessage("first name can not over 200 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("first name is required")
                .MaximumLength(200).WithMessage("first name can not over 200 characters");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("birthday can not greater than 100 years");
            RuleFor(x => x.Email).NotEmpty().WithMessage("email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("phone number is required");

            RuleFor(x => x.Username).NotEmpty().WithMessage("user name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("password is required")
                .MinimumLength(6).WithMessage("password is at least 6 characters");

            RuleFor(x => x ).Custom((request, context) => {
                if (request.Password!=request.ConfirmPassword)
                {
                    context.AddFailure("confirm password is not match");
                }
            });
        }
    }
}
