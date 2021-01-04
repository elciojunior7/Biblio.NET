using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;
using ProjBiblio.Domain.Interfaces;
using ProjBiblio.Infrastructure.Data.Context;

namespace ProjBiblio.Infrastructure.Data.Repositories
{
    public class MarketingCampaignRepository : Repository<MarketingCampaign>, IMarketingCampaignRepository
    {
        public MarketingCampaignRepository(BiblioDbContext context) : base(context)
        {
            
        }

        public void DeleteMarketingBooks(int mktID)
        {
            var mktBooks = _context.BookMarketingCampaign.AsNoTracking()
                                    .Where(bm => bm.MarketingCampaignID == mktID);

            _context.BookMarketingCampaign.RemoveRange(mktBooks);
        }
    }
}