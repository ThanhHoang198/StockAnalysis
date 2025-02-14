using Newtonsoft.Json.Linq;
using StockAnalysis.Domain.Models;
using StockAnalysis.Domain.Services;
using StockAnalysis.UI.State.Companies;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockAnalysis.UI.ViewModels
{
    public class CompanyViewModel : ViewModelBase
    {
        private string searchText;
        private bool hasResults;
        private readonly CompanyStore companyStore;

        public CompanyViewModel(CompanyStore companyStore)
        {
            this.companyStore = companyStore;
        }
        public ObservableCollection<Company> MatchedCompanies { get; set; } = new ObservableCollection<Company>();

        public ICommand SearchSymbolCommand { get; set; }
        public string Symbol
        {
            get => SelectedCompany?.Symbol ?? string.Empty;
        }
        public string StockExchange
        {
            get => SelectedCompany?.StockExchange ?? string.Empty;
        }
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                UpdateMatchedCompanies(searchText);
                OnPropertyChanged(nameof(SearchText));
            }
        }
        public Company SelectedCompany
        {
            get => companyStore.CurrentCompany;
            set
            {
                companyStore.CurrentCompany = value;
                OnPropertyChanged(nameof(SelectedCompany));
                if(companyStore.CurrentCompany !=null)
                {
                    SearchText = companyStore.CurrentCompany.Name;
                    LoadCompanyInfo();
                }
            }
        }
        private void LoadCompanyInfo()
        {
            HasResults = false;
            OnPropertyChanged(nameof(Symbol));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(BusinessField));
            OnPropertyChanged(nameof(StockExchange));
        }


        //public static CompanyViewModel LoadListedCompanyViewModel(IStockExchangeService stockExchangeService)
        //{

        //}
        
        public bool HasResults
        {
            get
            {
                return hasResults;
            }
            set
            {
                hasResults = value;
                OnPropertyChanged(nameof(HasResults));
            }
        }

        public string Name
        {
            get => SelectedCompany?.Name ?? string.Empty;
        }

        public string BusinessField
        {
            get => SelectedCompany?.BusinessField ?? string.Empty;
        }
        private void UpdateMatchedCompanies(string symbol)
        {
            MatchedCompanies.Clear();
            if (symbol != string.Empty)
            {
                var list = companyStore.Companies.Where(item => item.Name.Contains(symbol, StringComparison.OrdinalIgnoreCase)).ToList();
                foreach (var company in list)
                {
                    MatchedCompanies.Add(company);
                }
            }
            if(MatchedCompanies.Count > 0)
            {
                HasResults = true;
            }
            else
            {
                HasResults = false;
            }
        }
    }
}
