using GeekMarket.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GeekMarket.Server.Data
{
    public class GeekMarketContext : DbContext
    {
        public GeekMarketContext(DbContextOptions<GeekMarketContext> options)
            :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
