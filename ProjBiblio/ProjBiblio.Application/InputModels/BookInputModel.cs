using System.Collections.Generic;
using FluentValidation;
using ProjBiblio.Application.DTOs;

namespace ProjBiblio.Application.InputModels
{
    public class BookInputModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Amount { get; set; }
        public string Photo { get; set; }
        public int? Year { get; set; }
        public int? Edition { get; set; }
        public int? Pages { get; set; }
        public string Publisher { get; set; }
        public int? GenreID { get; set; }

        public IList<AuthorSelectListDto> Authors { get; set; }
    }

    public class BookInputModelValidator : AbstractValidator<BookInputModel>
    {
        public BookInputModelValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("O título é obrigatório.")
                            .Length(0, 100).WithMessage("O título não pode exceder 100 caracteres.");

            RuleFor(x => x.Amount)
                            .GreaterThanOrEqualTo(0).WithMessage("A quantidade não pode ter valor negativo.");

            RuleFor(x => x.Photo).Length(0, 300).WithMessage("O Nome não pode exceder 300 caracteres.");     
        }
    }
}