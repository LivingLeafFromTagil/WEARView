using mobileDemo.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace mobileDemo.Services.Implementations
{
    class LoginService : ILoginService
    {
        public Task<UserDTO> Autorise(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<AppDTO> GetVersion()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://testapp.telemed.chat/api/v2/app");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var response = await client.SendAsync(request);

            var str = await response.Content.ReadAsStringAsync();

            var dto = JsonConvert.DeserializeObject<AppDTO>(str);
            return dto;

        }
    }
}
