using mobileDemo.DTOs;
using mobileDemo.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobileDemo.ViewModels
{
    public class MainPageVM : BasePageVM
    {
        private long counter = 2;
        private UserDTO _user;
        private Action<UserDTO> _showHarderobePageAction;
        private Action<UserDTO> _showProfilePageAction;
        private ObservableCollection<ListClothesVM> _clothes;
        private ListClothesVM _selectedItem;

        public ListClothesVM SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    InvokePropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                }
            }
        }
        IClothesListPage _page;

        public ObservableCollection<ListClothesVM> Clothes
        {
            get
            {
                return _clothes;
            }
            set
            {
                if (_clothes != value)
                {
                    _clothes = value;
                    InvokePropertyChanged(this, new PropertyChangedEventArgs(nameof(Clothes))); 
                }

            }
        }

        public ICommand CameraButton { get; set; }
        public ICommand HarderobeButton { get; set; }
        public ICommand ProfileButton { get; set; }
        public ICommand AddButton { get; set; }


        public MainPageVM(UserDTO user, Action<UserDTO> showHarderobePageAction, Action<UserDTO> showProfilePageAction, IClothesListPage page)
        {
            _page = page;
            _user = user;
            _showHarderobePageAction = showHarderobePageAction;
            _showProfilePageAction = showProfilePageAction;
            CameraButton = new Command(ShowCamera);
            HarderobeButton = new Command(ShowHarderobePage);
            AddButton = new Command(AddClothes);
            ProfileButton = new Command(ShowProfilePage);
            Clothes = new ObservableCollection<ListClothesVM>();
            LoadData();
            PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(SelectedItem))
                {
                    if (SelectedItem == null)
                        return;

                    _page.ShowClothesItemPage(SelectedItem.DTO);

                    SelectedItem = null;
                }
            };
        }

        
        private async void ShowCamera()
        {
            Image img = new Image();
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "Clothes",
                    Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
                });

                if (file == null)
                    return;
                img.Source = ImageSource.FromFile(file.Path);
                string stringSource = (FileImageSource)img.Source;
                Clothes.Add(new ListClothesVM(new ClothesItemDTO
                {
                    ClothesId = counter + 1,
                    ClothesSource = stringSource,
                    ClothesTitle = "default"
                }));
                counter++;
            }
        }

        private async void AddClothes()
        {
            Image img = new Image();
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                Uri uri = new Uri("http://192.168.0.102:3000/Files/NcJt28shWN0.jpg");
                img.Source = ImageSource.FromFile(photo.Path);
                //string stringSource = (FileImageSource)img.Source;
                Clothes.Add(new ListClothesVM(new ClothesItemDTO
                {
                    ClothesId = counter + 1,
                    ClothesSource = img.Source,
                    ClothesTitle = "default"
                }));
                counter++;
            }
        }

        private async void LoadData()
        {
            this.IsLoading = true;
            
            try
            {
                var clothes = await Context.ClothesService.LoadListClothes();
                Clothes = new ObservableCollection<ListClothesVM>(clothes.ClothesItems.Select(x => new ListClothesVM(x)).ToList());
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

        private async void ShowHarderobePage()
        {
            try
            {
                _showHarderobePageAction?.Invoke(_user);
            }
            catch(Exception ex)
            {
                await Context.NotificationService.ShowNotification(ex.Message);
            }
        }

        private async void ShowProfilePage()
        {
            try
            {
                _showProfilePageAction?.Invoke(_user);
            }
            catch (Exception ex)
            {
                await Context.NotificationService.ShowNotification(ex.Message);
            }
        }
    }
}
