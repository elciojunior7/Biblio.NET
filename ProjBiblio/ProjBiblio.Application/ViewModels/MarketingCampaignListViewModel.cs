using System.Collections.Generic;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Application.ViewModels
{
    public class MarketingCampaignListViewModel
    {
        public IEnumerable<MarketingCampaignViewModel> MarketingCampaigns { get; set; }
    }
}