using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace mobileDemo.DTOs
{
    public class LooksDTO
    {
        public LooksItemDTO[] LooksItems { get; set; } = new LooksItemDTO[0];
        public string LooksTittle { get; set; }
        public long LooksId { get; set; }
        public ImageSource LooksSource { get; set; }
    }
}
