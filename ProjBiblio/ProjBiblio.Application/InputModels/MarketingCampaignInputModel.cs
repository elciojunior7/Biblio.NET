using System;
using System.Collections.Generic;
using ProjBiblio.Application.DTOs;

namespace ProjBiblio.Application.InputModels
{
    public class MarketingCampaignInputModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public IList<BookSelectListDto> Books { get; set; }
    }
}