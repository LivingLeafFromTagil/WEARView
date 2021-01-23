using mobileDemo.DTOs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Essentials;
using mobileDemo.Views;
using System.Reflection;

namespace mobileDemo.ViewModels
{
    public class HarderobePageItemVM
    {
        //SKBitmap bitmap;
        //        SKPath screenCut = SKPath.ParseSvgPathData("M 100 100 L 100 300 L 300 300 L 300 100 L 100 300 Z");
        public Stream stream { get; set; }
        Action<LooksItemDTO> _showHarderobePage;
        object name = "";
        public LooksItemDTO DTO;
        private StackLayout _content;
        public ICommand AddButton { get; set; }
        public ICommand SaveButton { get; set; }
        public HarderobePageItemVM(LooksItemDTO dto, StackLayout content, Action<LooksItemDTO> showHarderobePage)
        {
            _showHarderobePage = showHarderobePage;
            DTO = dto;
            _content = content;
            AddButton = new Command(AddClothes);
            SaveButton = new Command(SaveLook);
            
            //if(App.Current.Properties.TryGetValue("name", out name))
            //{
            //    dto.LooksSource = (string)name;
            //}
        }

        private async void SaveLook()
        {
            if (Screenshot.IsCaptureSupported)
            {
                
                

                var result = await Screenshot.CaptureAsync();
                
                //SKCanvasView canvasView = new SKCanvasView();
                stream = await result.OpenReadAsync();
                //canvasView.PaintSurface += OnCanvasViewPointSurface;
                //_content.Children.Add(canvasView);
                var source = ImageSource.FromStream(() => stream);
                //bitmap = SKBitmap.Decode(stream);
                DTO.LooksSource = source;
                MessagingCenter.Send(this, "NewImage");
                _showHarderobePage?.Invoke(DTO);
                
                

            }
        }

        //private void OnCanvasViewPointSurface(object sender, SKPaintSurfaceEventArgs args)
        //{
        //    SKImageInfo info = args.Info;
        //    SKSurface surface = args.Surface;
        //    SKCanvas canvas = surface.Canvas;

        //    canvas.Clear();

        //    // Set transform to center and enlarge clip path to window height
        //    SKRect bounds;
        //    screenCut.GetTightBounds(out bounds);

        //    canvas.Translate(info.Width / 2, info.Height / 2);
        //    canvas.Scale(0.98f * info.Height / bounds.Height);
        //    canvas.Translate(-bounds.MidX, -bounds.MidY);

        //    // Set the clip path
        //    canvas.ClipPath(screenCut);

        //    // Reset transforms
        //    canvas.ResetMatrix();

        //    // Display monkey to fill height of window but maintain aspect ratio
            
        //    bitmap = SKBitmap.Decode(stream);
        //    canvas.DrawBitmap(bitmap,
        //        new SKRect((info.Width - info.Height) / 2, 0,
        //                   (info.Width + info.Height) / 2, info.Height));
        //}

        private async void AddClothes()
        {
            Image img = new Image();
            try
            {
                if (CrossMedia.Current.IsPickPhotoSupported)
                {
                    MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                    img.Source = ImageSource.FromFile(photo.Path);
                    string stringSource = (FileImageSource)img.Source;
                    _content.Children.Add(new StackLayout
                    {
                        HorizontalOptions = LayoutOptions.Start,
                        Children =
                    {
                        new PanContainer
                        {
                            Content = new Image
                            {
                                Source = img.Source,
                                WidthRequest = 100,
                                HeightRequest = 100
                            }
                        }
                    }
                    });
                }
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
