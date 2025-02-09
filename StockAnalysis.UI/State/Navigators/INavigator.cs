using StockAnalysis.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockAnalysis.UI.State.Navigators
{
    public enum ViewType
    {
        Stock,
        Finance,
        Comparison
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
