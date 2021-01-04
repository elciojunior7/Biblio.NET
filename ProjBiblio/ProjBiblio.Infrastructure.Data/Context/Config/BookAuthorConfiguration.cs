using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {

            builder.HasKey(bc => new { bc.BookID, bc.AuthorID }); 
            
            builder.HasOne(bc => bc.Books)
                .WithMany(b => b.BoAuthors)
                .HasForeignKey(bc => bc.BookID); 

            builder.HasOne(bc => bc.Authors)
                .WithMany(c => c.BoAuthors)
                .HasForeignKey(bc => bc.AuthorID); 
        }
    }
}