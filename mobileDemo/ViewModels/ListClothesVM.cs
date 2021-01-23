using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace mobileDemo.ViewModels
{
    public class ListClothesVM
    {
        public ImageSource ClothesSource { get; set; }
        public string ClothesTitle { get; set; } 
        public long ClothesId { get; set; }

        public ClothesItemDTO DTO { get; private set; }
        public ListClothesVM(ClothesItemDTO dto)
        {
            ClothesSource = dto.ClothesSource;
            ClothesTitle = dto.ClothesTitle;
            ClothesId = dto.ClothesId;
            DTO = dto;
        }
    }

    
}
