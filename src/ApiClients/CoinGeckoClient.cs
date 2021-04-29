using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ApiClients.Models;

namespace ApiClients
{
    public class CoinGeckoClient : ICoinGeckoClient
    {
        private readonly HttpClient _httpClient;

        public CoinGeckoClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GetExchangesResponse>> GetExchanges(int limit, int page)
        {
            var response = await _httpClient.GetAsync($"/exchanges?per_page={limit}&page={page}");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<GetExchangesResponse>>(responseContent);
        }

        public async Task<GetExchangesResponse> GetExchange(string id)
        {
            var response = await _httpClient.GetAsync($"/exchanges/{id}");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetExchangesResponse>(responseContent);
        }

        public async Task<GetCoinResponse> GetCoin(string coinId)
        {
            var response = await _httpClient.GetAsync($"/coins/{coinId}");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<GetCoinResponse>(responseContent);
        }
        
        public async Task <IEnumerable<GetDerivativesResponse>> GetDerivatives(string order, int perPage, int page)
        {
            var response = await _httpClient
                .GetAsync($"/derivatives/exchanges?order={order}&per_page={perPage}&page={page}");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<GetDerivativesResponse>>(responseContent);
        }
    }
}
