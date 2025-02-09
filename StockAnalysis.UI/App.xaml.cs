using StockAnalysis.Domain.Services;
using StockAnalysis.ModelingAPI.Services;
using StockAnalysis.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StockAnalysis.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //new StockExchangeService().GetListedCompanies(StockExchangeType.HOSE).ContinueWith((task) =>
            //{
            //    var result = task.Result; 
            //});
            Window window=new MainWindow();
            window.DataContext = new MainViewModel(CompanyViewModel.LoadListedCompanyViewModel(new StockExchangeService()));
            window.Show();
            base.OnStartup(e);
        }
    }
}
