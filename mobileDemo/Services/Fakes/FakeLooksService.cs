using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace mobileDemo.Services.Fakes
{
    public class FakeLooksService : ILooksService
    {
        private List<LooksItemDTO> _looks = new List<LooksItemDTO>();

        public FakeLooksService()
        {
            
        }
        public async Task<LooksDTO> LoadListLooks()
        {
            await Task.Delay(2000);
            return new LooksDTO()
            {
                LooksItems = _looks.Select(x => new LooksItemDTO()
                {
                    LooksId = x.LooksId,
                    LooksTitle = x.LooksTitle,
                    LooksSource = x.LooksSource
                }).ToArray()
            };
        }

        public async Task<LooksItemDTO> LoadLook(LooksItemDTO dTO)
        {
            await Task.Delay(2000);
            _looks.Add(dTO);
            var looks = _looks.FirstOrDefault(x => x.LooksId == dTO.LooksId);
            if (looks == null)
                throw new Exception("Такого набора нет");
            return new LooksItemDTO()
            {
                LooksId = dTO.LooksId,
                LooksTitle = dTO.LooksTitle,
                LooksSource = dTO.LooksSource
            };
        }
    }
}
