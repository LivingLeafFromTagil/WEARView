using mobileDemo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mobileDemo.Services.Fakes
{
    class FakeLoginService : ILoginService
    {
        public async Task<UserDTO> Autorise(string login, string password)
        {
            await Task.Delay(2000);

            if(login != "123" || password != "111")
                throw new Exception("Такого пользователя нет");
            return new UserDTO
            {
                Id = 1,
                Name = "Romich",
                SetsNumber = 3
            };
        }

        public Task<AppDTO> GetVersion()
        {
            throw new NotImplementedException();
        }
    }
}
