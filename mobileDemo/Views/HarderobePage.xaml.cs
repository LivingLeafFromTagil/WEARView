using mobileDemo.DTOs;
using mobileDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HarderobePage : ContentPage
    {
        public HarderobePage(HarderobePageVM harderobePageVM)
        {
            this.BindingContext = harderobePageVM;
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }

        public async void ShowHarderobePageItem(LooksItemDTO dto)
        {
            await Navigation.PushAsync(new HarderobePageItem(dto));
        }
    }
}