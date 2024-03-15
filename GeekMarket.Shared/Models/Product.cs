using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeekMarket.Shared.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required, Range(0.1, 9999999)]
        public decimal Price { get; set; }
        [Required, DisplayName("Imagem do produto")]
        public string Base64Image { get; set; } = null!;
        public int Quantity { get; set; }
        public bool Featured { get; set; }
        public DateTime LastUpdate { get; set; } = DateTime.Now;

        public Product()
        {
            Id = Guid.NewGuid();
        }
    }
}
