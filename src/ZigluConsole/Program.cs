using System;
using System.Net.Http;
using System.Text.Json;
using ApiClients;
using Microsoft.Extensions.Configuration;
using ZigluService;

namespace ZigluConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            var zigluService = CreateService();

            var exchanges = zigluService.TopThreeExchanges();
            
            Console.WriteLine(JsonSerializer.Serialize(exchanges, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }

        private static Service CreateService()
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

            return new Service(coinGeckoClient);
        }
    }
}