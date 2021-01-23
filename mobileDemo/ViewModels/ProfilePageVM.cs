using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace mobileDemo.ViewModels
{
    public class ProfilePageVM : INotifyPropertyChanged
    {
        public ProfilePageVM(UserDTO user)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
