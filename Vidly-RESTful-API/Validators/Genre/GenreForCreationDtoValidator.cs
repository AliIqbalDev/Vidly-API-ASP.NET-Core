using FluentValidation;
using Vidly_RESTful_API.Dtos;

namespace Vidly_RESTful_API.Validators.Genre
{
    public class GenreForCreationDtoValidator : AbstractValidator<GenreForCreationDto>
    {
        public GenreForCreationDtoValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty()
                .WithMessage("Name can't be blank");
        }
    }
}