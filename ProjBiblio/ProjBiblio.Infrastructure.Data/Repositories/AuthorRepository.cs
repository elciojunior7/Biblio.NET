using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BiblioDbContext context) : base(context)
        {
            
        }

        public IEnumerable<Author> GetAuthorsByBook(int idBook)
        {
             return _context.Author.AsNoTracking()
                .Include(l => l.BoAuthors)
                .Where(l => l.BoAuthors.Any(la => la.BookID == idBook));
        }

        public IEnumerable<Author> GetAuthorsContainsName(string name)
        {
            return _context.Set<Author>().Where(a => a.Name.Contains(name));
        }
    }
}