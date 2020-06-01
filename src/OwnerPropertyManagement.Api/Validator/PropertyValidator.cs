using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using OwnerPropertyManagement.Contracts.Dtos;

namespace OwnerPropertyManagement.Api.Validator
{
    public class PropertyValidator : AbstractValidator<OwnerDto>
    {
        public PropertyValidator() {

        }
    }
}
