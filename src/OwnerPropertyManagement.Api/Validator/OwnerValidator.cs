using FluentValidation;
using OwnerPropertyManagement.Contracts.Dtos;

namespace OwnerPropertyManagement.Api.Validator
{
    public class OwnerValidator:AbstractValidator<OwnerDto>
    {
        public OwnerValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("FirstName is required");
            RuleFor(r => r.Surname).NotEmpty().WithMessage("FirstName is required");
            RuleFor(r => r.PersonalPhoneNumber).NotEmpty().WithMessage("Personal phone number is required");
        }
    }
}
