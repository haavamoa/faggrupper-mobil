using System.Collections.Generic;
using System.Threading.Tasks;
using FriendsBluePrint.Models;

namespace FriendsBluePrint.Services
{
    public interface IFriendsService
    {
        Task<List<Friend>> Get();
    }
}