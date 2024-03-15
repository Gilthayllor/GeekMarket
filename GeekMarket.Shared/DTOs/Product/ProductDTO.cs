using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeekMarket.Shared.DTOs.Product
{
    public record ProductDTO(Guid id, string Name, string Description, decimal Price, string Base64Image, int Quantity, bool Featured, DateTime LastUpdate);

    public class ProductEditDTO
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public decimal Price { get; set; }
        [DisplayName("Imagem do produto"), Required]
        public string Base64Image { get; set; } = null!;
        [Required]
        public int Quantity { get; set; }
        public bool Featured { get; set; }

        public ProductEditDTO(string name, string description, decimal price, string base64Image, int quantity, bool featured)
        {
            Name = name;
            Description = description;
            Price = price;
            Base64Image = base64Image;
            Quantity = quantity;
            Featured = featured;
        }
        public ProductEditDTO()
        {

        }
    }

}
