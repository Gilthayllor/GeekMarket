using GeekMarket.Shared.DTOs.Product;
using GeekMarket.Shared.Models;

namespace GeekMarket.Shared.Extensions
{
    public static class ProductExtensions
    {
        public static ProductDTO ToDTO(this Product product)
        {
            return new ProductDTO(product.Id, product.Name, product.Description, product.Price, product.Base64Image, product.Quantity, product.Featured, product.LastUpdate);
        }
        
        public static List<ProductDTO> ToDTO(this IEnumerable<Product> product)
        {
            var list = new List<ProductDTO>();

            foreach (var item in product)
            {
                list.Add(ToDTO(item));
            }

            return list;
        }

        public static ProductEditDTO ToEdit(this ProductDTO product)
        {
            return new ProductEditDTO
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Base64Image = product.Base64Image,
                Quantity = product.Quantity,
                Featured = product.Featured
            };
        }

        public static Product ToModel(this ProductEditDTO productEditDTO)
        {
            return new Product
            {
                Name = productEditDTO.Name,
                Description = productEditDTO.Description,
                Price = productEditDTO.Price,
                Featured = productEditDTO.Featured,
                Base64Image = productEditDTO.Base64Image,
                Quantity = productEditDTO.Quantity
            };
        }
    }
}
