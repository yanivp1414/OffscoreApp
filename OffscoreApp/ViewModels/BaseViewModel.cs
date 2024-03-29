﻿using System.ComponentModel;
using System.Windows.Input;
using OffscoreApp.Services;
using Xamarin.Forms;
using OffscoreApp.Models;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Text;
using System.Collections.ObjectModel;
using OffscoreApp.Views;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace OffscoreApp.ViewModels
{
    //This VM will act as a base for all child classes. The class inherits INPC and has an additional method for setting a value
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(
               [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(
                         backingField, value)) return;
            backingField = value;
            OnPropertyChanged(propertyName);
        }
    }
}
