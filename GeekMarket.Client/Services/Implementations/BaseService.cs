using GeekMarket.Client.Services.Interfaces;
using GeekMarket.Client.Utils;
using GeekMarket.Shared.Reponse;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GeekMarket.Client.Services.Implementations
{
    public class BaseService : IBaseService
    {
        private readonly HttpClient _httpClient;

        protected JsonSerializerOptions SerializerOptions;

        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            SerializerOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<Result<T>> SendAsync<T>(Request request)
        {
            try
            {
                HttpRequestMessage requestMessage = new()
                {
                    Method = new HttpMethod(request.Method.ToString()),
                    Content = request.Data != null ? new StringContent(
                        JsonSerializer.Serialize(request.Data, SerializerOptions),
                        Encoding.UTF8,
                        "application/json"
                    ) : null
                };

                requestMessage.Headers.Add("Accept", "application/json");

                requestMessage.RequestUri = BuildUri(request);

                HttpResponseMessage httpResponse = await _httpClient.SendAsync(requestMessage);

                var contentResponse = await httpResponse.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<Result<T>>(contentResponse, SerializerOptions)!;

                if (!httpResponse.IsSuccessStatusCode && string.IsNullOrEmpty(result.Error))
                {
                    return Result<T>.Failure($"Ocorreu um erro ao fazer a requisição [{httpResponse.ReasonPhrase}]");
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Result> SendAsync(Request request)
        {
            try
            {
                HttpRequestMessage requestMessage = new()
                {
                    Method = new HttpMethod(request.Method.ToString()),
                    Content = request.Data != null ? new StringContent(
                        JsonSerializer.Serialize(request.Data, SerializerOptions),
                        Encoding.UTF8,
                        "application/json"
                    ) : null
                };

                requestMessage.Headers.Add("Accept", "application/json");

                requestMessage.RequestUri = BuildUri(request);

                HttpResponseMessage httpResponse = await _httpClient.SendAsync(requestMessage);

                var contentResponse = await httpResponse.Content.ReadAsStringAsync();
                
                var result = JsonSerializer.Deserialize<Result>(contentResponse, SerializerOptions)!;

                if (!httpResponse.IsSuccessStatusCode && string.IsNullOrEmpty(result.Error))
                {
                    return Result.Failure($"Ocorreu um erro ao fazer a requisição [{httpResponse.ReasonPhrase}]");
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Uri BuildUri(Request request)
        {
            var builder = new UriBuilder(new Uri(_httpClient.BaseAddress!, request.Url));

            if(request.QueryParameters != null)
            {
                var query = string.Join("&", Array.ConvertAll(request.QueryParameters.ToArray(), x=> string.Format("{0}={1}", x.Key, x.Value)));
                builder.Query = query;
            }

            return builder.Uri;
        }
    }
}
