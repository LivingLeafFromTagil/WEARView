using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobileDemo.Services
{
    public interface ILooksService
    {
        Task<LooksDTO> LoadListLooks();
        Task<LooksItemDTO> LoadLook(LooksItemDTO dto);
        
    }
}
