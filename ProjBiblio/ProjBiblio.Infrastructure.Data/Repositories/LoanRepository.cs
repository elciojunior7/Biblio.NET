using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(BiblioDbContext context) : base(context)
        {
        }

        public IEnumerable<Loan> GetLoanByUser(int userId)
        {
            return _context.Loan
                .Where(l => l.UserID == userId);
        }

        public Loan GetLoanInclude(int loanId)
        {
            return (_context.Loan
                .Include(e => e.BoLoan)
                .ThenInclude(e => e.Books)
                .ThenInclude(e => e.BoAuthors)
                .ThenInclude(e => e.Authors)
                .Where(l => l.LoanID == loanId))
                .SingleOrDefault();
        }
    }
}