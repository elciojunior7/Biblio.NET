using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BiblioDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Book> GetBooksContainsTitle(string title)
        {
            return _context.Set<Book>().Where(b => b.Title.Contains(title));
        }

        public IEnumerable<Book> GetBooksNotStock()
        {
            return _context.Set<Book>().Where(b => b.Amount.Equals(0));
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            return _context.Book
                .Include(b => b.BoAuthors)
                .Where(b => b.BoAuthors.Any(ba => ba.AuthorID.Equals(authorId)));
        }
        public IEnumerable<Book> GetBooksByGenre(int genreId)
        {
            return _context.Book
                .Where(l => l.GenreID == genreId);
        }

        public IEnumerable<Book> GetBooksByMkt(int idMkt)
        {
             return _context.Book.AsNoTracking()
                .Include(m => m.BoMarketing)
                .Where(m => m.BoMarketing.Any(bm => bm.MarketingCampaignID == idMkt));
        }

        public void DeleteBooksAuthor(int bookID)
        {
            var booksAuthors = _context.BookAuthor.AsNoTracking()
                                    .Where(la => la.BookID == bookID);

            _context.BookAuthor.RemoveRange(booksAuthors);
        }
    }
}