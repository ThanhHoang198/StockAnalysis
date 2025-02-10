using StockAnalysis.UI.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysis.UI.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly StockInfoViewModel stockInfoViewModel;
        private readonly FinanceInfoViewModel financeInfoViewModel;
        private readonly ComparisonViewModel comparisonViewModel;

        public ViewModelAbstractFactory(StockInfoViewModel stockInfoViewModel,FinanceInfoViewModel financeInfoViewModel,ComparisonViewModel comparisonViewModel)
        {
            this.stockInfoViewModel = stockInfoViewModel;
            this.financeInfoViewModel = financeInfoViewModel;
            this.comparisonViewModel = comparisonViewModel;
        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Stock:
                    return stockInfoViewModel;
                case ViewType.Finance:
                    return financeInfoViewModel; ;
                case ViewType.Comparison:
                    return comparisonViewModel; ;
                default:
                    throw new ArgumentException("The view type does not have a ViewModel");
                    break ;
            }
        }
    }
}
