using System;
using System.Text.Json.Serialization;

namespace ApiClients.Models
{
    public class GetCoinResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("market_data")]
        public MarketData MarketData { get; set; }
        [JsonPropertyName("community_data")]
        public CommunityData CommunityData { get; set; }
    }

    public class MarketData
    {
        [JsonPropertyName("current_price")]
        public CurrentPrice CurrentPrice { get; set; }
        [JsonPropertyName("market_cap")]
        public MarketCap MarketCap { get; set; }
        [JsonPropertyName("price_change_24h_in_currency")]
        public PriceChange24HourCurrency PriceChange24HourCurrency { get; set; }
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }
    }

    public class CurrentPrice
    {
        [JsonPropertyName("gbp")]
        public decimal Gbp { get; set; }
    }

    public class MarketCap
    {
        [JsonPropertyName("gbp")]
        public decimal Gbp { get; set; }
    }

    public class PriceChange24HourCurrency
    {
        [JsonPropertyName("gbp")]
        public decimal Gbp { get; set; }
    }

    public class CommunityData
    {
        [JsonPropertyName("twitter_followers")]
        public long TwitterFollowers { get; set; }
    }
}
