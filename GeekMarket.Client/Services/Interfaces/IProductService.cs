using GeekMarket.Shared.DTOs.Product;
using GeekMarket.Shared.Reponse;

namespace GeekMarket.Client.Services.Interfaces
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductDTO>>> GetAll(bool featured);
        Task<Result> DeleteProduct(string id);
    }
}
