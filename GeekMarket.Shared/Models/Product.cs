namespace GeekMarket.Shared.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string Base64Image { get; set; } = null!;
        public int Quantity { get; set; }
        public bool Featured { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.UtcNow;

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}
