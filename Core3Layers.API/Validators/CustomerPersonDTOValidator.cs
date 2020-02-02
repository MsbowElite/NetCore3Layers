using Core3Layers.Core.Models;
using FluentValidation;

namespace Core3Layers.API.Validators
{
    public class CustomerPersonDTOValidator : AbstractValidator<CustomerPersonDTO>
    {
        public CustomerPersonDTOValidator()
        {
            RuleFor(x => x.CPF).NotNull().Length(11);
        }
    }
}
