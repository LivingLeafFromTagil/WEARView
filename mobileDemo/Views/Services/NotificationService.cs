using mobileDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobileDemo.Views.Services
{
    public class NotificationService : INotificationService
    {
        public Task ShowNotification(string message)
        {
            var page = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();
            return page?.DisplayAlert("Внимание", message, "Ок");
        }
    }
}
