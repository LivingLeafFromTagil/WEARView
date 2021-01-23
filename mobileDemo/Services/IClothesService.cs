using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobileDemo.Services
{
    public interface IClothesService
    {
        Task<ClothesDTO> LoadListClothes(); //тут был List айтемов
        Task<ClothesItemDTO> LoadClothes(ClothesItemDTO dTO);

    }
}
