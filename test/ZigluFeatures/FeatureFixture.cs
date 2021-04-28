using System;
using System.Net.Http;
using ApiClients;
using Microsoft.Extensions.Configuration;
using ZigluService;

namespace ZigluFeatures
{
    public class FeatureFixture : IDisposable
    {
        protected Service ZigluService { get; }

        protected FeatureFixture()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(System.IO.Directory.GetCurrentDirectory() + "\\appsettings.json")
                .Build();

            var coinGeckoHttpClient = new HttpClient {BaseAddress = new Uri(config["coingecko:baseaddress"])};
            coinGeckoHttpClient
                .DefaultRequestHeaders
                .Add("x-rapidapi-key", config["coingecko:x-rapidapi-key"]);
            coinGeckoHttpClient
                .DefaultRequestHeaders.Add("x-rapidapi-host", config["coingecko:x-rapidapi-host"]);

            var coinGeckoClient = new CoinGeckoClient(coinGeckoHttpClient);

            ZigluService = new Service(coinGeckoClient);
        }

        public void Dispose()
        {
        }
    }
}