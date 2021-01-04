using System;
using System.Collections.Generic;

namespace ProjBiblioFront.Models
{
    public class MarketingCampaignViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DiscountPercentage { get; set; }
        public IList<BookSelectListDto> Books { get; set; }
    }
}