using Core3Layers.Core.Models;
using FluentValidation;

namespace Core3Layers.API.Validators
{
    public class CustomerDTOValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(11);
        }
    }
}
