using StockAnalysis.UI.Commands;
using StockAnalysis.UI.Models;
using StockAnalysis.UI.ViewModels;
using StockAnalysis.UI.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace StockAnalysis.UI.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase currentViewModel;
        public Navigator(IViewModelAbstractFactory viewModelAbstractFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this,viewModelAbstractFactory);
        }
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

    }
}
