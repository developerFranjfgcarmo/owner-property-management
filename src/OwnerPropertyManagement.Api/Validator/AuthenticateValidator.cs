using FluentValidation;
using OwnerPropertyManagement.Contracts.Dtos;

namespace OwnerPropertyManagement.Api.Validator
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateModel>
    {
        public AuthenticateValidator()
        {
            RuleFor(r => r.Password).NotEmpty().WithMessage("The password is required");
            RuleFor(r => r.Username).NotEmpty().WithMessage("The Username is required");
        }
    }
}