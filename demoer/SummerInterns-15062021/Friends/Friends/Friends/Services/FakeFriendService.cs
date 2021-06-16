using System.Collections.Generic;
using System.Threading.Tasks;
using Friends.Models;

namespace Friends.Services
{
    public class FakeFriendService : IFriendsService
    {
        public Task<List<Friend>> GetAllFriends()
        {
            return Task.FromResult(new List<Friend>());
        }
    }
}