using StockAnalysis.UI.State.Navigators;
using StockAnalysis.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockAnalysis.UI.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator navigator;

        public event EventHandler CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            this.navigator = navigator;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType viewType)
            {
                switch (viewType)
                {
                    case ViewType.Stock:
                        navigator.CurrentViewModel=new StockInfoViewModel();
                        break;
                    case ViewType.Finance:
                        navigator.CurrentViewModel = new FinanceInfoViewModel();
                        break;
                    case ViewType.Comparison:
                        navigator.CurrentViewModel = new ComparisonViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
