using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace mobileDemo.Services.Fakes
{
    public class FakeClothesService : IClothesService
    {
        private List<ClothesItemDTO> _clothes = new List<ClothesItemDTO>();
        public FakeClothesService()
        {
            
        }

        public async Task<ClothesItemDTO> LoadClothes(ClothesItemDTO dTO)
        {
            await Task.Delay(2000);
            _clothes.Add(dTO);
            var clothes = _clothes.FirstOrDefault(x => x.ClothesId == dTO.ClothesId);
            if (clothes == null)
                throw new Exception("Такой одежды нет");
            return new ClothesItemDTO()
            {
                ClothesId = dTO.ClothesId,
                ClothesSource = dTO.ClothesSource,
                ClothesTitle = dTO.ClothesTitle
            };
        }

        public async Task<ClothesDTO> LoadListClothes()
        {
            await Task.Delay(2000);
            return new ClothesDTO()
            {
                ClothesItems = _clothes.Select(x => new ClothesItemDTO()
                {
                    ClothesId = x.ClothesId,
                    ClothesSource = x.ClothesSource,
                    ClothesTitle = x.ClothesTitle
                }).ToArray()
            };
            
        }
    }
}
