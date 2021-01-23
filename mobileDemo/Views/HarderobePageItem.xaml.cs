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
    public partial class HarderobePageItem : ContentPage
    {
        public HarderobePageItem(LooksItemDTO dto)
        {
            InitializeComponent();
            this.BindingContext = new HarderobePageItemVM(dto, layout, BackToHarderobe);
        }

        public async void BackToHarderobe(LooksItemDTO dto)
        {
           
            await Navigation.PopAsync();
            
        }
    }
}