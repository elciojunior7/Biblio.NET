using System;
using System.Collections.Generic;

namespace ProjBiblio.Domain.Entities
{
    public class MarketingCampaign
    {
        public int MarketingCampaignID { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DiscountPercentage { get; set; }
        public ICollection<BookMarketingCampaign> BoMarketing { get; set; }
    }
}