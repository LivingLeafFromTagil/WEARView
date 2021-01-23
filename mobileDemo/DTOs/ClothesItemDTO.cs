using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mobileDemo.DTOs
{
    public class ClothesItemDTO
    {
        public ImageSource ClothesSource { get; set; }
        public string ClothesTitle { get; set; }
        public long ClothesId { get; set; }
    }
}
