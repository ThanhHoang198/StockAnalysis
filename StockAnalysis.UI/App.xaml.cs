using Microsoft.Extensions.DependencyInjection;
using StockAnalysis.Domain.Services;
using StockAnalysis.ModelingAPI.Services;
using StockAnalysis.UI.State.Companies;
using StockAnalysis.UI.State.Navigators;
using StockAnalysis.UI.ViewModels;
using StockAnalysis.UI.ViewModels.Factories;
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
            //new StockInfoService().GetStockInfo("TCB").ContinueWith((task) =>
            //{
            //    var result = task.Result;
            //});
            var serviceProvider=CreateServiceProvider();
            Window window=serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services=new ServiceCollection();
            services.AddSingleton<IStockExchangeService, StockExchangeService>();
            services.AddSingleton<IStockInfoService, StockInfoService>();
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<StockInfoViewModel>();
            services.AddSingleton<FinanceInfoViewModel>();
            services.AddSingleton<ComparisonViewModel>();
            services.AddSingleton<CompanyViewModel>();
            services.AddSingleton<IViewModelAbstractFactory,ViewModelAbstractFactory>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<CompanyStore>();
            services.AddSingleton<MainWindow>(s=>new MainWindow() { DataContext = s.GetRequiredService<MainViewModel>() });
            return services.BuildServiceProvider();
        }

    }
}
