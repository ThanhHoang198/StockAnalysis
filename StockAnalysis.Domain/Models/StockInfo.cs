using System;

namespace StockAnalysis.Domain.Models
{
    public class StockInfo
    {
        public string Symbol { get; set; }
        public double Price { get; set; }
        public double PriceChange { get; set; }
        public double PriceChangeRatio { get; set; }
        public double Volumne { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}