using mobileDemo.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace System
{
    public class Context
    {
        public static ILooksService LooksService => Service<ILooksService>.GetInstance();
        public static IClothesService ClothesService => Service<IClothesService>.GetInstance();
        public static ILoginService LoginService => Service<ILoginService>.GetInstance();
        public static INotificationService NotificationService => Service<INotificationService>.GetInstance();
        public static IDataService DataClothesService => Service<IDataService>.GetInstance();
        
        public static ImageSource img;
    }
}
