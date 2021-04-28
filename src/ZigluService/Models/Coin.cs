using System;

namespace ZigluService.Models
{
    public class Coin
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal MarketValue { get; set; }
        public decimal NumberOfTwitterFollowers { get; set; }
        public decimal MarketCap { get; set; }
        public decimal PriceChange { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}