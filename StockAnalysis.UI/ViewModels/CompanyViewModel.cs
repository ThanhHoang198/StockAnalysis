using StockAnalysis.Domain.Models;
using StockAnalysis.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.UI.ViewModels
{
    public class CompanyViewModel
    {
        private readonly IStockExchangeService stockExchangeService;
        public List<Company> Companies { get; set; }
        public CompanyViewModel(IStockExchangeService stockExchangeService)
        {
            this.stockExchangeService = stockExchangeService;
        }

        public static CompanyViewModel LoadListedCompanyViewModel(IStockExchangeService stockExchangeService)
        {
            var companyViewModel = new CompanyViewModel(stockExchangeService);
            companyViewModel.LoadListedCompany();
            return companyViewModel;
        }
        private void LoadListedCompany()
        {
            stockExchangeService.GetListedCompanies(StockExchangeType.All).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Companies = task.Result;
                }
            });
        }
    }
}
