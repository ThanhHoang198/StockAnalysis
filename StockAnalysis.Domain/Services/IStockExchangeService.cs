using StockAnalysis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.Domain.Services
{
    public enum StockExchangeType
    {
        HOSE,
        HNX,
        UPCOM,
        All
    }
    public interface IStockExchangeService
    {       
        Task<List<Company>> GetListedCompanies(StockExchangeType stockExchangeType);
    }
}
