using System.Collections.Generic;

namespace ProjBiblioFront.Models
{
    public class BookViewModel
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
}