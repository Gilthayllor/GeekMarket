using GeekMarket.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekMarket.Server.Data
{
    public class GeekMarketContext : DbContext
    {
        public GeekMarketContext(DbContextOptions<GeekMarketContext> options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeekMarketContext).Assembly);
        }
    }
}
