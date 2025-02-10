using StockAnalysis.UI.State.Navigators;
using StockAnalysis.UI.ViewModels;
using StockAnalysis.UI.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StockAnalysis.UI.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator navigator;
        private readonly IViewModelAbstractFactory viewModelAbstractFactory;

        public event EventHandler CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator, IViewModelAbstractFactory viewModelAbstractFactory)
        {
            this.navigator = navigator;
            this.viewModelAbstractFactory = viewModelAbstractFactory;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType viewType)
            {
                navigator.CurrentViewModel=viewModelAbstractFactory.CreateViewModel(viewType);              
            }
        }
    }
}
