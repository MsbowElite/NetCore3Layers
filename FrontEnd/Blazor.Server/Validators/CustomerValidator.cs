using Blazor.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Server.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Person.CPF).NotEmpty().When(w => w.Person != null);
            RuleFor(customer => customer.Company.CNPJ).NotEmpty().When(w => w.Company != null);
        }
    }
}
