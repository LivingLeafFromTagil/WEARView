using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace mobileDemo.ViewModels
{
    public abstract class BasePageVM : INotifyPropertyChanged
    {
        private bool _isloading;
        public bool IsLoading
        {
            get
            {
                return _isloading;
            }
            set
            {
                _isloading = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLoading)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(sender, args);
        }
    }


}
