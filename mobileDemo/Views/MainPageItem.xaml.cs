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
    public partial class MainPageItem : ContentPage, IClothesPage
    {
        public MainPageItem(ClothesItemDTO dto)
        {
            
            InitializeComponent();
            this.BindingContext = new MainPageItemVM(dto, this);
            //picker.Items.Add("Тип1");
            //picker.Items.Add("Тип2");
            //picker.Items.Add("Тип3");
            //picker.Items.Add("Тип4");
            //picker.Items.Add("Тип5");
        }

        //private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    label.Text = picker.Items[picker.SelectedIndex];
        //}

        //protected override void OnAppearing()
        //{
        //    object name = "";
        //    if (App.Current.Properties.TryGetValue("name", out name))
        //    {
        //        imgName.Text = (string)name;
        //    }
        //    base.OnAppearing();
        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //App.Current.Properties.Add("name", imgName.Text);

            await Navigation.PopAsync();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void Button_Clicked_1(object sender, EventArgs e)
        //{
        //    App.Current.Properties.Remove("name");
        //}
    }
}