﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StockAnalysis.UI.Models
{
    public class ObservableObject:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
