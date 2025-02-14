using StockAnalysis.Domain.Services;
using StockAnalysis.UI.State.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis.UI.ViewModels.Factories
{
    public class CompanyViewModelFactory : IViewModelFactory<CompanyViewModel>
    {
        private readonly CompanyStore companyStore;

        public CompanyViewModelFactory(CompanyStore companyStore)
        {
            this.companyStore = companyStore;
        }
        public CompanyViewModel CreateViewModel()
        {
            var companyViewModel = new CompanyViewModel(companyStore);
            return companyViewModel;
        }
    }
}
