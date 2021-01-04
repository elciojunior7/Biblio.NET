using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public string Photo { get; set; }
        public ICollection<BookAuthor> BoAuthors { get; set; }
        public ICollection<BookLoan> BoLoan { get; set; }
        public int GenreID { get; set; }
        public virtual Genre Genres { get; set; }
        public int Year { get; set; }
        public int Edition { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public ICollection<BookMarketingCampaign> BoMarketing { get; set; }
        public Book()
        {
            BoAuthors = new List<BookAuthor>();
            BoLoan = new List<BookLoan>();
            BoMarketing = new List<BookMarketingCampaign>();
        }
    }
}