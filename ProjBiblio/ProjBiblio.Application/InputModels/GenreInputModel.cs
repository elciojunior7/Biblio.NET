using FluentValidation;

namespace ProjBiblio.Application.InputModels
{
    public class GenreInputModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class GenreInputModelValidator : AbstractValidator<GenreInputModel>
    {
        public GenreInputModelValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("A Descrição é obrigatória.")
                            .Length(0, 100).WithMessage("Descrição não pode exceder 100 caracteres.");
        }
    }
}