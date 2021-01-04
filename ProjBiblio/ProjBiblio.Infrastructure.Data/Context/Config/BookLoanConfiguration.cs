using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class BookLoanConfiguration : IEntityTypeConfiguration<BookLoan>
    {
        public void Configure(EntityTypeBuilder<BookLoan> builder)
        {
            builder.HasKey(bc => new { bc.BookID, bc.LoanID }); 
            
            builder.HasOne(bc => bc.Books)
                .WithMany(b => b.BoLoan)
                .HasForeignKey(bc => bc.BookID); 

            builder.HasOne(bc => bc.Loans)
                .WithMany(c => c.BoLoan)
                .HasForeignKey(bc => bc.LoanID); 
        }
    }
}