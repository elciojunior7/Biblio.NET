using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AuthorRepository _authorRepo;
        private BookRepository _bookRepo;
        private KartRepository _kartRepo;
        private UserRepository _userRepo;
        private LoanRepository _loanRepo;
        private GenreRepository _genreRepo;
        private MarketingCampaignRepository _marketingRepo;
        private BiblioDbContext _context;

        public IBookRepository BookRepository
        {
            get
            {
                return _bookRepo = _bookRepo ?? new BookRepository(_context);
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                return _authorRepo = _authorRepo ?? new AuthorRepository(_context);
            }
        }

        public IKartRepository KartRepository
        {
            get
            {
                return _kartRepo = _kartRepo ?? new KartRepository(_context);
            }
        }
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepo = _userRepo ?? new UserRepository(_context);
            }
        }
        public ILoanRepository LoanRepository
        {
            get
            {
                return _loanRepo = _loanRepo ?? new LoanRepository(_context);
            }
        }

        public IGenreRepository GenreRepository
        {
            get
            {
                return _genreRepo = _genreRepo ?? new GenreRepository(_context);
            }
        }

        public IMarketingCampaignRepository MarketingCampaignRepository
        {
            get
            {
                return _marketingRepo = _marketingRepo ?? new MarketingCampaignRepository(_context);
            }
        }

        public UnitOfWork(BiblioDbContext contexto)
        {
            _context = contexto;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}