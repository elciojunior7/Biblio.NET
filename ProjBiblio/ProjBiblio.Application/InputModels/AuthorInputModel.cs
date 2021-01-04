using FluentValidation;

namespace ProjBiblio.Application.InputModels
{
    public class AuthorInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AuthorInputModelValidator : AbstractValidator<AuthorInputModel>
    {
        public AuthorInputModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome é obrigatório.")
                            .Length(0, 100).WithMessage("O nome não pode exceder 100 caracteres.");
        }
    }
}