using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobileDemo.Services
{
    public interface INotificationService
    {
        Task ShowNotification(string message);
    }
}
