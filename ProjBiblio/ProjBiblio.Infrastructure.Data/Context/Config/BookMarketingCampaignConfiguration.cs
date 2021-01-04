using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class BookMarketingCampaignConfiguration : IEntityTypeConfiguration<BookMarketingCampaign>
    {        
        public void Configure(EntityTypeBuilder<BookMarketingCampaign> builder)
        {
            builder.HasKey(bc => new { bc.BookID, bc.MarketingCampaignID }); 
            
            builder.HasOne(bc => bc.Books)
                .WithMany(b => b.BoMarketing)
                .HasForeignKey(bc => bc.BookID); 

            builder.HasOne(bc => bc.Marketings)
                .WithMany(c => c.BoMarketing)
                .HasForeignKey(bc => bc.MarketingCampaignID); 
        }
    }
}