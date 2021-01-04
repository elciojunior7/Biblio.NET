using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksNotStock();
        IEnumerable<Book> GetBooksContainsTitle(string title);
        IEnumerable<Book> GetBooksByAuthor(int authorId);
        void DeleteBooksAuthor(int bookID);
        IEnumerable<Book> GetBooksByGenre(int genreId);
        IEnumerable<Book> GetBooksByMkt(int mktId);
    }
}