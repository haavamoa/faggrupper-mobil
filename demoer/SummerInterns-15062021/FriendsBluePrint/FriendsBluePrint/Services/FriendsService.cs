using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FriendsBluePrint.Models;
using Newtonsoft.Json;

namespace FriendsBluePrint.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly HttpClient m_httpClient;

        public FriendsService()
        {
            m_httpClient = new HttpClient();
        }
        
        public async Task<List<Friend>> Get()
        {
            var responseMessage = await m_httpClient.GetAsync("https://raw.githubusercontent.com/haavamoa/faggrupper-mobil/main/demoer/SummerInterns-15062021/data/friends.json");
            if (responseMessage.IsSuccessStatusCode)
            {
                var stringContent = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Friend>>(stringContent);
            }

            return new List<Friend>();
        }
    }
}