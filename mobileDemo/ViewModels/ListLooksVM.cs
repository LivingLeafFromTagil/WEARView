using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mobileDemo.ViewModels
{
    public class ListLooksVM
    {
        public string LooksTitle { get; set; }
        public long LooksId { get; set; }

        public ImageSource LooksSource { get; set; }
        public LooksItemDTO DTO { get; set; }
        public ListLooksVM(LooksItemDTO dto)
        {
            LooksTitle = dto.LooksTitle;
            LooksId = dto.LooksId;
            LooksSource = dto.LooksSource;
            DTO = dto;
        }
    }
}
