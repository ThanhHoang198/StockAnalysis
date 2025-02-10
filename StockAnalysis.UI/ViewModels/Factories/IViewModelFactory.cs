using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis.UI.ViewModels.Factories
{
    public interface IViewModelFactory<T> where T : ViewModelBase
    {
        T CreateViewModel();
    }
}
