using System.Collections.Generic;
using System.Threading.Tasks;
using ApiClients.Models;

namespace ApiClients
{
    public interface ICoinGeckoClient
    {
        Task<IEnumerable<GetExchangesResponse>> GetExchanges(int limit, int page);
        Task<GetExchangesResponse> GetExchange(string id);
        Task<GetCoinResponse> GetCoin(string coinId);
        Task <IEnumerable<GetDerivativesResponse>> GetDerivatives(string order, int perPage, int page);
    }
}