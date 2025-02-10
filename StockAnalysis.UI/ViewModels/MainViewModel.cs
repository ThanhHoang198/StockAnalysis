using StockAnalysis.UI.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis.UI.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public CompanyViewModel CompanyViewModel { get; set; }
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateCurrentViewModelCommand.Execute(ViewType.Stock);
        }
    }
}
