using GeekMarket.Client.Services.Interfaces;
using GeekMarket.Client.Utils;
using GeekMarket.Shared.DTOs.Product;
using GeekMarket.Shared.Reponse;

namespace GeekMarket.Client.Services.Implementations
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(HttpClient client) : base(client) { }


        public async Task<Result<IEnumerable<ProductDTO>>> GetAll(bool featured)
        {
            var result = await SendAsync<IEnumerable<ProductDTO>>(new Request
            {
                Url = "api/v1/products",
                QueryParameters = new Dictionary<string, string> 
                {
                    { "featured", "true" }
                }
            });
            
            return result;
        }
        
        public async Task<Result<ProductDTO>> EditProduct(Guid id, ProductEditDTO productEdit)
        {
            var result = await SendAsync<ProductDTO>(new Request
            {
                Url = $"api/v1/products/{id}",
                Method = Request.MethodTypeEnumeration.PUT,
                Data = productEdit
            });
            
            return result;
        }
        public async Task<Result> DeleteProduct(string id)
        {
            var result = await SendAsync<Result>(new Request
            {
                Url = $"api/v1/products/{id}",
                Method = Request.MethodTypeEnumeration.DELETE
            });

            return result;
        }
    }
}
