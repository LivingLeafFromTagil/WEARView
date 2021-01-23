using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace mobileDemo.DTOs
{
    public class LooksItemDTO : INotifyPropertyChanged
    {
        private ImageSource _looksSource;
        public ImageSource LooksSource
        {
            get
            {
                return _looksSource;
            }
            set
            {
                if (_looksSource != value)
                {
                    _looksSource = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LooksSource)));
                }
            }
        }
        public long LooksId { get; set; }
        public string LooksTitle { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
