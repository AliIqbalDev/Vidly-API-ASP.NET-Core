using FluentValidation;
using Vidly_RESTful_API.Dtos;

namespace Vidly_RESTful_API.Validators.Genre
{
    public class GenreForUpdateDtoValidator : AbstractValidator<GenreForUpdateDto>
    {
        public GenreForUpdateDtoValidator()
        {
            RuleFor(g => g.Name)
                .NotEmpty()
                .WithMessage("Name can't be blank");
        }
    }
}