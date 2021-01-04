using ProjBiblio.Application.InputModels;
using ProjBiblio.Application.ViewModels;

namespace ProjBiblio.Application.Interfaces
{
    public interface IMarketingCampaignService
    {
         MarketingCampaignListViewModel Get();
         MarketingCampaignViewModel Get(int id);
         MarketingCampaignViewModel Post(MarketingCampaignInputModel mkt);
         MarketingCampaignViewModel Put(int id, MarketingCampaignInputModel mkt);
         MarketingCampaignViewModel Delete(int id);
    }
}