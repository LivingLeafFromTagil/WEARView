using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobileDemo.Services
{
    public interface ILoginService
    {
        Task<UserDTO> Autorise(string login, string password);
        Task<AppDTO> GetVersion();
    }
}
