using StockAnalysis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.Domain.Services
{
    public interface IStockInfoService
    {
        Task<StockInfo> GetStockInfo(string symbol);
    }
}
