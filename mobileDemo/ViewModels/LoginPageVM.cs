using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using mobileDemo.Services;
using mobileDemo.DTOs;

namespace mobileDemo.ViewModels
{
    public class LoginPageVM : BasePageVM
    {
        private string _loginText;
        private string _passwordText;
        public string LoginText 
        {
            get
            {
                return _loginText;
            }
            set
            {
                if (_loginText != value)
                {
                    _loginText = value;
                    InvokePropertyChanged(this, new PropertyChangedEventArgs(nameof(LoginText)));
                }
            }
        }
        public string PasswordText
        {
            get
            {
                return _passwordText;
            }
            set
            {
                if (_passwordText != value)
                {
                    _passwordText = value;
                    InvokePropertyChanged(this, new PropertyChangedEventArgs(nameof(PasswordText))); 
                }
            }
        }

       
        public ICommand LoginButton { get; set; }

        private Action<UserDTO> _showNextPageAction;

        public LoginPageVM(Action<UserDTO> showNextPageAction) 
        {
            _showNextPageAction = showNextPageAction;
            LoginButton = new Command(Authorise);
        }

        private async void Authorise()
        {
            //try
            //{
            //    IsLoading = true;
            //    var vers = await Context.LoginService.GetVersion();
            //    IsLoading = false;
            //    await Context.NotificationService.ShowNotification($"Name: {vers.Name}; Version: {vers.Version}");
            //}
            //catch (Exception ex)
            //{
            //    await Context.NotificationService.ShowNotification(ex.Message);
            //    IsLoading = false;
            //}
            //return;
            try
            {
                IsLoading = true;
                var user = await Context.LoginService.Autorise(_loginText, _passwordText);
                IsLoading = false;
                _showNextPageAction?.Invoke(user);
            }
            catch (Exception ex)
            {
                await Context.NotificationService.ShowNotification(ex.Message);
                IsLoading = false;
            }
        }
    }
}
