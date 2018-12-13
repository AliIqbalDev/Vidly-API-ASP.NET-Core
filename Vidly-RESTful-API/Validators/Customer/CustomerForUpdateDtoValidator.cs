using FluentValidation;
using Vidly_RESTful_API.Dtos;

namespace Vidly_RESTful_API.Validators.Customer
{
    public class CustomerForUpdateDtoValidator : AbstractValidator<CustomerForUpdateDto>
    {
        public CustomerForUpdateDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Customer name can't be blank");

            RuleFor(c => c.Phone)
                .NotEmpty()
                .WithMessage("Phone number can't be blank");
        }
    }
}