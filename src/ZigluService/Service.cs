using System;
using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
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
        private readonly CoinGeckoClient _coinGeckoClient;

        public Service(CoinGeckoClient coinGeckoClient)
        {
            _coinGeckoClient = coinGeckoClient;
        }

        public async Task<IEnumerable<Exchange>> TopThreeExchanges()
        {
            var result = await _coinGeckoClient
                .GetExchanges(3, 1);

            return result.Select(x => new Exchange
            {
                Url = x.Url,
                YearEstablished = x.YearEstablished,
                TrustScore = x.TrustScore,
                TrustScoreRank = x.TrustScoreRank,
            });
        }

        public async Task <IEnumerable<Exchange>> TopExchangesBitCoinTradingVolume(int limit)
        {
            var response = new List<Exchange>();
            
            // using this to get round the poor performance/api restriction of listing all the exchanges
            // and then having to sort by normalised 24 hour trade volume
            var derivatives = await _coinGeckoClient
                .GetDerivatives("trade_volume_24h_btc_desc", limit, 1);

            foreach (var derivative in derivatives)
            {
                var exchange = await _coinGeckoClient.GetExchange(derivative.Id);

                response.Add(new Exchange
                {
                    Name = exchange.Name,
                    Url = exchange.Url,
                    YearEstablished = exchange.YearEstablished,
                    TradeVolume24HoursBitcoin = exchange.TradeVolume24HoursBitcoin,
                    TradeVolume24HoursNormalized = exchange.TradeVolume24HoursNormalized,
                });
            }

            return response;
        }

        public async Task<Coin> CoinInfo(string coinName)
        {
            var coin = await _coinGeckoClient.GetCoin(coinName);

            return new Coin
            {
                Id = coin.Id,
                Name = coin.Name,
                MarketValue = coin.MarketData.CurrentPrice.Gbp,
                MarketCap = coin.MarketData.MarketCap.Gbp,
                PriceChange = coin.MarketData.PriceChange24HourCurrency.Gbp,
                NumberOfTwitterFollowers = coin.CommunityData.TwitterFollowers
            };
        }

        // not needed now :/ use the other endpoint
        /*private async Task<IEnumerable<GetExchangesResponse>> GetPaginatedExchanges(int limit, int page)
        {
            var allExchangesResponses = new List<GetExchangesResponse>();

            var response = await _coinGeckoClient.GetExchange(limit, page);

            return response.Any()
                ? allExchangesResponses.Concat(await GetPaginatedExchanges(limit, page + 1))
                : allExchangesResponses;
        }*/
    }
}
