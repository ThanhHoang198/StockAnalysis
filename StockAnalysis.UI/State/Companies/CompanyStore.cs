using System;
using System.Collections.Generic;
using System.Text;
using StockAnalysis.Domain.Models;
using StockAnalysis.Domain.Services;
using StockAnalysis.ModelingAPI.Services;


namespace StockAnalysis.UI.State.Companies
{
    public class CompanyStore
    {
        private readonly IStockExchangeService stockExchangeService;

        public CompanyStore(IStockExchangeService stockExchangeService)
        {
            this.stockExchangeService = stockExchangeService;
            LoadListedCompany();
        }
        public Company CurrentCompany { get; set; }
        public void LoadListedCompany()
        {
            stockExchangeService.GetListedCompanies(StockExchangeType.All).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Companies = task.Result;
                }
            });
        }
        public List<Company> Companies { get; set; }

    }
}
