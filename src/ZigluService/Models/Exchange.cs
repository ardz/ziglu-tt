﻿namespace ZigluService.Models
{
    public class Exchange
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? YearEstablished { get; set; }
        public int? TrustScore { get; set; }
        public int? TrustScoreRank { get; set; }
        public decimal TradeVolume24HoursBitcoin { get; set; }
        public decimal TradeVolume24HoursNormalized { get; set; }
    }
}