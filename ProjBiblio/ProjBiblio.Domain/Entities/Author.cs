using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public ICollection<BookAuthor> BoAuthors { get; set; }
    }
}