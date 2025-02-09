using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis.Domain.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string BusinessField { get; set; }
        public StockInfo StockInfo { get; set; }
        public FinanceInfo FinanceInfo { get; set; }
    }
}
