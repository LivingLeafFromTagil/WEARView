using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace mobileDemo.ViewModels
{
    public class HarderobePageVM : BasePageVM
    {
        private int counter = 0;
        private UserDTO _user;
        private Action<UserDTO> _showClothesPageAction;
        private Action<UserDTO> _showProfilePageAction;
        private ObservableCollection<ListLooksVM> _looks;
        private ListLooksVM _selectedItem;
        private ImageSource _looksSource;

        public ImageSource LooksSource
        {
            get
            {
                return _looksSource;
            }
            set
            {
                if (_looksSource != value)
                {
                    _looksSource = value;
                    InvokePropertyChanged(this, new PropertyChangedEventArgs(nameof(LooksSource)));
                }
            }
        }
        public ObservableCollection<ListLooksVM> Looks
        {
            get
            {
                return _looks;
            }
            set
            {
                if (_looks != value)
                {
                    _looks = value;
                    InvokePropertyChanged(this, new PropertyChangedEventArgs(nameof(Looks)));
                }
            }
        }

        public ListLooksVM SelectedItem
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
        public ICommand AddButton { get; set; }
        public ICommand ClothesButton { get; set; }
        public ICommand ProfileButton { get; set; }

        public ILooksListPage _page;

        public HarderobePageVM(UserDTO user, Action<UserDTO> showClothesPageAction, Action<UserDTO> showProfilePageAction, ILooksListPage page)
        {
            _page = page;
            _user = user;
            _showClothesPageAction = showClothesPageAction;
            _showProfilePageAction = showProfilePageAction;
            AddButton = new Command(AddLooks);
            ClothesButton = new Command(ShowClothesPage);
            ProfileButton = new Command(ShowProfilePage);

            LoadData();
            //Subscribe();

            PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(SelectedItem))
                {
                    if (SelectedItem == null)
                        return;

                    _page.ShowLooksItemPage(SelectedItem.DTO);

                    SelectedItem = null;
                }
            };
        }

        private void Subscribe()
        {
            MessagingCenter.Subscribe<HarderobePageItemVM>(this, "NewImage", (sender) => {
                if (Looks.Contains(Looks.Last()))
                {
                    Looks.Remove(Looks.Last());
                    Looks.Add(new ListLooksVM(new LooksItemDTO
                    {
                        LooksId = 0,
                        LooksTitle = "New",
                        LooksSource = sender.DTO.LooksSource
                    }));
                }
            });
            
        }

        private async void LoadData()
        {
            this.IsLoading = true;

            try
            {
                var looks = await Context.LooksService.LoadListLooks();
                Looks = new ObservableCollection<ListLooksVM>(looks.LooksItems.Select(x => new ListLooksVM(x)).ToList());
                Subscribe();
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

        private async void ShowClothesPage()
        {
            try
            {
                _showClothesPageAction?.Invoke(_user);
            }
            catch (Exception ex)
            {
                await Context.NotificationService.ShowNotification(ex.Message);
            }
        }

        private void AddLooks()
        {
            _page.ShowLooksItemPage(new LooksItemDTO
            {
                LooksId = counter + 1,
                LooksTitle = "default",
                LooksSource = "shirts.png"
            });
            Looks.Add(new ListLooksVM(new LooksItemDTO
            {
                LooksId = counter + 1,
                LooksTitle = "default",
                LooksSource = "shirts.png"
            }));
            counter++;

            
        }
    }
}
