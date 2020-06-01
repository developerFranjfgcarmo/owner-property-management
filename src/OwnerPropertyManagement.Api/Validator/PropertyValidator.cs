using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using OwnerPropertyManagement.Contracts.Dtos;

namespace OwnerPropertyManagement.Api.Validator
{
    public class PropertyValidator : AbstractValidator<PropertyDto>
    {
        public PropertyValidator()
        {
            RuleFor(r => r.OwnerId).NotEmpty().WithMessage("The owner is required");
            RuleFor(r => r.Name).NotEmpty().WithMessage("The name is required");
            RuleFor(r => r.TownId).NotEqual(0).WithMessage("The town is required");
            RuleFor(r => r.Facilities).Must(m=>m.Any()).WithMessage("You must select some facility");
        }
    }
}
