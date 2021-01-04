using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context
{
    public class BiblioDbContext : DbContext
    {
        public BiblioDbContext (DbContextOptions<BiblioDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Kart> Kart { get; set; }
        public DbSet<Loan> Loan { get; set; }
        public DbSet<BookLoan> BookLoan { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookMarketingCampaign> BookMarketingCampaign { get; set; }
        public DbSet<MarketingCampaign> MarketingCampaign { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}