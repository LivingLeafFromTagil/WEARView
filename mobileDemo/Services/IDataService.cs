using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobileDemo.Services
{
    public interface IDataService
    {
        void SendValue(ClothesItemDTO dto);
        Task<ClothesItemDTO> GetValue(ClothesItemDTO dto);
    }
}
