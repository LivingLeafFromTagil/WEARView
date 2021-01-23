using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobileDemo.Services.Fakes
{
    class FakeDataClothesService : IDataService
    {
        private string _clothesTitle;
        public async Task<ClothesItemDTO> GetValue(ClothesItemDTO dto)
        {
            await Task.Delay(500);
            return new ClothesItemDTO()
            {
                ClothesTitle = _clothesTitle,
                ClothesSource = dto.ClothesSource,
                ClothesId = dto.ClothesId
            };
        }

        public async void SendValue(ClothesItemDTO dto)
        {
            await Task.Delay(2000);
            _clothesTitle = dto.ClothesTitle;
            
        }
    }
}
