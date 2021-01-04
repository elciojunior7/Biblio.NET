using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Domain.Interfaces
{
    public interface IMarketingCampaignRepository: IRepository<MarketingCampaign>
    {
        void DeleteMarketingBooks(int mktID);
    }
}