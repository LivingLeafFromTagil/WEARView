using mobileDemo.Services;
using mobileDemo.Services.Fakes;
using mobileDemo.Services.Implementations;
using mobileDemo.Views.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileDemo
{
    public partial class App : Application
    {
        public static double ScreenWidth;
        public static double ScreenHeight;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());

            RegisterServices(true);
        }

        private void RegisterServices(bool enableFakes)
        {
            Service<INotificationService>.Register(new NotificationService());
            if (enableFakes)
            {
                Service<ILoginService>.Register(new FakeLoginService());
                Service<IClothesService>.Register(new FakeClothesService());
                Service<ILooksService>.Register(new FakeLooksService());
                Service<IDataService>.Register(new FakeDataClothesService());
            }
            else
            {
                Service<ILoginService>.Register(new LoginService());
                Service<IClothesService>.Register(new ClothesService());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
