using Friends.Models;

namespace Friends.ViewModels
{
    public class FriendDetailViewModel
    {
        public void BeforeNavigation(Friend friend)
        {
            Friend = friend;
        }

        public Friend Friend { get; set; }
    }
}