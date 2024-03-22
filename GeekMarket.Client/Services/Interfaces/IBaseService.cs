using GeekMarket.Client.Utils;
using GeekMarket.Shared.Reponse;

namespace GeekMarket.Client.Services.Interfaces
{
    public interface IBaseService
    {
        Task<Result<T>> SendAsync<T>(Request request);
        Task<Result> SendAsync(Request request);
    }
}
