using System.Text.Json.Serialization;

namespace ApiClients.Models
{
    public class GetExchangesResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }
        
        [JsonPropertyName("year_established")]
        public int? YearEstablished { get; set; }

        [JsonPropertyName("trust_score")]
        public int? TrustScore { get; set; }
        
        [JsonPropertyName("trust_score_rank")]
        public int? TrustScoreRank { get; set; }
        
        [JsonPropertyName("trade_volume_24h_btc")]
        public decimal TradeVolume24HoursBitcoin { get; set; }
        [JsonPropertyName("trade_volume_24h_btc_normalized")]
        public decimal TradeVolume24HoursNormalized { get; set; }
    }
}