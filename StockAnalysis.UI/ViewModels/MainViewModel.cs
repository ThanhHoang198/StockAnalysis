using StockAnalysis.UI.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis.UI.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();
        public MainViewModel()
        {
            
        }
    }
}
