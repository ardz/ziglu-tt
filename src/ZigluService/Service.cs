using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ApiClients;
using ApiClients.Models;
using ZigluService.Models;

namespace ZigluService
{
    public class Service
    {
        private readonly ICoinGeckoClient _coinGeckoClient;

        public Service(ICoinGeckoClient coinGeckoClient)
        {
            _coinGeckoClient = coinGeckoClient;
        }

        public async Task<IEnumerable<Exchange>> GetExchanges(int numberOfExchanges)
        {
            var result = await GetPaginatedExchanges(250, 1);

            return result.Select(x => new Exchange
            {
                Url = x.Url,
                YearEstablished = x.YearEstablished,
                TrustScore = x.TrustScore,
                TrustScoreRank = x.TrustScoreRank,
            }).Take(numberOfExchanges);
        }

        public async Task<IEnumerable<Exchange>> TopBitcoinTradingVolumesByExchange(int numberOfExchanges)
        {
            var result = await GetPaginatedExchanges(250, 1);

            return result.Select(x => new Exchange
            {
                Name = x.Name,
                Url = x.Url,
                YearEstablished = x.YearEstablished,
                TradeVolume24HoursBitcoin = x.TradeVolume24HoursBitcoin,
                TradeVolume24HoursNormalized = x.TradeVolume24HoursNormalized,
            }).OrderByDescending(x => x.TradeVolume24HoursNormalized).Take(numberOfExchanges);
        }

        public async Task<Coin> CoinInfo(string coinId)
        {
            var coin = await _coinGeckoClient.GetCoin(coinId);

            return new Coin
            {
                Id = coin.Id,
                Name = coin.Name,
                MarketValue = coin.MarketData.CurrentPrice.Gbp,
                MarketCap = coin.MarketData.MarketCap.Gbp,
                PriceChange = coin.MarketData.PriceChange24HourCurrency.Gbp,
                NumberOfTwitterFollowers = coin.CommunityData.TwitterFollowers,
                LastUpdated = coin.MarketData.LastUpdated
            };
        }

        // just added this so there's something to actually test when
        // we're checking for props on the data that the API returns :/
        public static string ModelToTextOutput(object obj)
        {
            return JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
        
        // using a recursive function here to basically query the exchanges endpoint twice
        // there's a limit of 250 results per page so we need all the exchanges to be able
        // to then sort which 5 have the top trading volumes normalised in 24 hours as per the requirement
        private async Task<IEnumerable<GetExchangesResponse>> GetPaginatedExchanges(int limit, int page)
        {
            var response = (await _coinGeckoClient
                .GetExchanges(limit, page)).ToList();

            return response.Any()
                ? response.Concat(await GetPaginatedExchanges(limit, page + 1))
                : response;
        }
    }
}
