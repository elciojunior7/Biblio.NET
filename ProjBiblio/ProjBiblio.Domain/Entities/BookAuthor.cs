namespace ProjBiblio.Domain.Entities
{
    public class BookAuthor
    {
        public int BookID { get; set; }
        public Book Books { get; set; }
        public int AuthorID { get; set; }
        public Author Authors { get; set; }
    }
}