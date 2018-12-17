using FluentValidation;
using Vidly_RESTful_API.Dtos;

namespace Vidly_RESTful_API.Validators.Rental
{
    public class RentalForCreationDtoValidator : AbstractValidator<RentalForCreationDto>
    {
        public RentalForCreationDtoValidator()
        {
            RuleFor(r => r.CustomerId)
                .NotEmpty()
                .WithMessage("Customer Id can't be blank");

            RuleFor(r => r.MovieId)
                .NotEmpty()
                .WithMessage("Movie Id can't be blank");

            RuleFor(r => r.DateReturned)
                .NotEmpty()
                .WithMessage("Date Returned can't be blank");
        }
    }
}