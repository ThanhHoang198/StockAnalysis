using StockAnalysis.UI.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis.UI.ViewModels.Factories
{
    public interface IViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
