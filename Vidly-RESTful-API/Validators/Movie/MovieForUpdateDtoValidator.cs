using FluentValidation;
using Vidly_RESTful_API.Dtos;

namespace Vidly_RESTful_API.Validators.Movie
{
    public class MovieForUpdateDtoValidator : AbstractValidator<MovieForUpdateDto>
    {
        public MovieForUpdateDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Title can't be blank");

            RuleFor(m => m.NumberInStock)
                .NotEmpty()
                .WithMessage("NumberInStock can't be blank");

            RuleFor(m => m.DailyRentalRate)
                .NotEmpty()
                .WithMessage("Daily Rental Rate can't be blank");
        }
    }
}