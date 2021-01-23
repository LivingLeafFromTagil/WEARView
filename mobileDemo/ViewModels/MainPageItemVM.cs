using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace mobileDemo.ViewModels
{
    public class MainPageItemVM : BasePageVM
    {
        private ClothesItemDTO _dto;
        private IClothesPage _page;

        private string _clothesTitle;
        private ImageSource _clothesSource;
        private Picker _clothesPicker;

        
        public string ClothesTitle
        {
            get
            {
                return _clothesTitle;
            }
            set
            {
                if (_clothesTitle != value)
                {
                    _clothesTitle = value;
                    InvokePropertyChanged(this, new PropertyChangedEventArgs(nameof(ClothesTitle)));
                }
            }
        }

        public ImageSource ClothesSource
        {
            get
            {
                return _clothesSource;
            }
            set
            {
                if (_clothesSource != value)
                {
                    _clothesSource = value;
                    InvokePropertyChanged(this, new PropertyChangedEventArgs(nameof(ClothesSource)));
                }
            }
        }
        public MainPageItemVM(ClothesItemDTO dto, IClothesPage page)
        {
            _clothesPicker.Items.Add("Головной убор");
            _clothesPicker.Items.Add("Верхняя одежда");
            _clothesPicker.Items.Add("Обувь");
            _clothesPicker.Items.Add("Аксессуар (голова)");
            _clothesPicker.Items.Add("Аксессуар (тело)");
            _dto = dto;
            _page = page;
            LoadData();
            
        }

        private void ClothesPicker(object sender, EventArgs e)
        {
            _dto.ClothesTitle = _clothesPicker.Items[_clothesPicker.SelectedIndex];
            Context.DataClothesService.SendValue(_dto);
        }

        private async void LoadData()
        {
            this.IsLoading = true;

            try
            {
                var clothes = await Context.ClothesService.LoadClothes(_dto);
                ClothesTitle = clothes.ClothesTitle;
                ClothesSource = clothes.ClothesSource;
            }
            catch (Exception ex)
            {
                await Context.NotificationService.ShowNotification(ex.Message);
            }
            finally
            {
                this.IsLoading = false;
            }
        }
    }
}
