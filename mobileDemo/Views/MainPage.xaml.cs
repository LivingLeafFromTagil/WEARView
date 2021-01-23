using mobileDemo.DTOs;
using mobileDemo.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage, IClothesListPage
    {
        public MainPage(MainPageVM mainPageVM)
        {
            this.BindingContext = mainPageVM;
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
            
        }

        public async void ShowClothesItemPage(ClothesItemDTO dto)
        {
            await Navigation.PushAsync(new MainPageItem(dto));
        }

    }
}