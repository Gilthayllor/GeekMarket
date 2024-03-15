using GeekMarket.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeekMarket.Server.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name);

            builder.Property(x => x.Description);

            builder.Property(x => x.Quantity);

            builder.Property(x => x.Price).HasPrecision(18, 2);

            builder.Property(x => x.Featured);

            builder.Property(x => x.Base64Image);

            builder.Property(x => x.LastUpdate);

        }
    }
}
