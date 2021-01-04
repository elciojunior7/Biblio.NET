namespace ProjBiblio.Domain.Entities
{
    public class BookMarketingCampaign
    {
        public int BookID { get; set; }
        public Book Books { get; set; }
        public int MarketingCampaignID { get; set; }
        public MarketingCampaign Marketings { get; set; }
    }
}