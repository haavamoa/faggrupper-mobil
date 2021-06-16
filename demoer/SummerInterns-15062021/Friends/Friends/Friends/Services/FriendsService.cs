using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Friends.Models;
using Newtonsoft.Json;

namespace Friends.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly HttpClient m_httpClient;

        public FriendsService()
        {
            m_httpClient = new HttpClient();
        }
        
        public async Task<List<Friend>> GetAllFriends()
        {
            var response = await m_httpClient.GetAsync("https://raw.githubusercontent.com/haavamoa/faggrupper-mobil/main/demoer/SummerInterns-15062021/data/friends.json");
            if (response.IsSuccessStatusCode)
            {
                var rawJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject <List<Friend>>(rawJson);
            }

            return new List<Friend>();
        }
    }
}