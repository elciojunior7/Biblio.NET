namespace ProjBiblio.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get;}
        IBookRepository BookRepository { get;}
        IKartRepository KartRepository { get; }
        IUserRepository UserRepository { get; }
        ILoanRepository LoanRepository { get; }
        IGenreRepository GenreRepository { get;}
        IMarketingCampaignRepository MarketingCampaignRepository { get;}

         void Commit();
    }
}