using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobileDemo.ViewModels
{
    public interface IClothesListPage
    {
        void ShowClothesItemPage(ClothesItemDTO dto);
    }
}
