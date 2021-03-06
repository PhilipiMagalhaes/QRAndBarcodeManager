﻿using Plugin.Vibrate;
using QRAndBarCodeManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace QRAndBarCodeManager.ViewModels
{
   public class BaseViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs((propertyName)));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
        protected readonly INavigationService NavigationService = DependencyService.Get<INavigationService>();
        protected readonly IMessageService MessageService = DependencyService.Get<IMessageService>();
        protected readonly IAlertService AlertService = DependencyService.Get<IAlertService>();
    }
}
