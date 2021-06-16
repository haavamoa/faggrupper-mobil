using System.Collections.Generic;
using System.Threading.Tasks;
using Friends.Models;

namespace Friends.Services
{
    public interface IFriendsService
    {
        Task<List<Friend>> GetAllFriends();
    }
}