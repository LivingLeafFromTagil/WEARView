using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using mobileDemo.ViewModels;
using mobileDemo.DTOs;
using mobileDemo.Views;

namespace mobileDemo
{
    public partial class LoginPage : ContentPage, IClothesListPage, ILooksListPage
    {
        public LoginPage()
        {
            InitializeComponent();
            var loginPageVM = new LoginPageVM(ShowNextPage);
            this.BindingContext = loginPageVM;
        }

        public async void ShowHarderobePage(UserDTO user)
        {
            var harderobePageVM = new HarderobePageVM(user, ShowNextPage, ShowProfilePage, this);
            var harderobePage = new HarderobePage(harderobePageVM);
            await Navigation.PushAsync(harderobePage);
        }
        
        public async void ShowProfilePage(UserDTO user)
        {
            var profilePageVM = new ProfilePageVM(user);
            var profilePage = new ProfilePage(profilePageVM);
            await Navigation.PushAsync(profilePage);
        }

        public async void ShowNextPage(UserDTO user) 
        {
            var mainPageVM = new MainPageVM(user, ShowHarderobePage, ShowProfilePage, this);
            var mainPage = new MainPage(mainPageVM);
            await Navigation.PushAsync(mainPage);
        }

        public async void ShowClothesItemPage(ClothesItemDTO dto)
        {
            await Navigation.PushAsync(new MainPageItem(dto));
        }

        public async void ShowLooksItemPage(LooksItemDTO dto)
        {
            await Navigation.PushAsync(new HarderobePageItem(dto));
        }
    }
}
