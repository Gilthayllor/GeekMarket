using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeekMarket.Shared.DTOs.Product
{
    public record ProductDTO(Guid id, string Name, string Description, decimal Price, string Base64Image, int Quantity, bool Featured, DateTime LastUpdate);

    public record ProductEditDTO
    {
        [Required]
        public string Name { get; init; } = null!;
        [Required]
        public string Description { get; init; } = null!;
        [Required]
        public decimal Price { get; init; }
        [DisplayName("Imagem do produto"), Required]
        public string Base64Image { get; init; } = null!;
        [Required]
        public int Quantity { get; init; }
        public bool Featured { get; init; }

        public ProductEditDTO(string name, string description, decimal price, string base64Image, int quantity, bool featured)
        {
            Name = name;
            Description = description;
            Price = price;
            Base64Image = base64Image;
            Quantity = quantity;
            Featured = featured;
        }
    }

}
