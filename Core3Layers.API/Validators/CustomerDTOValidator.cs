using Core3Layers.Core.Models;
using FluentValidation;

namespace Core3Layers.API.Validators
{
    public class CustomerDTOValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(100);
            RuleFor(x => x.Email).NotNull().MaximumLength(100);
            RuleFor(x => x.PostalCode).Length(7).When(w => w.PostalCode != null);
        }
    }
}
